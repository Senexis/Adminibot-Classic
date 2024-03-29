﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace th.AdminibotModern.Classes
{
    abstract class IrcClient
    {
        private string _nickname;
        private string _passwordToken;
        private string _channel;
        private TcpClient _ircClient;
        private StreamReader _streamReader;
        private StreamWriter _streamWriter;
        private Thread _listenerThread;
        private Thread _queueHandlerThread;
        private Queue<string> _messageQueue = new Queue<string>();
        private IrcStatus _ircStatus;

        /// <summary>
        /// Creates and runs a new IrcClient upon instantiating.
        /// </summary>
        /// <param name="nickname">The bot's Twitch username.</param>
        /// <param name="passwordToken">A password token generated by "https://twitchapps.com/tmi/".</param>
        /// <param name="channel">The bot's target channel (the "broadcaster").</param>
        protected IrcClient(string nickname, string passwordToken, string channel)
        {
            if (_ircClient != null)
            {
                EventLogger.AddEvent(Types.EventLevel.Error,
                    "A connection was already established. Ignoring request to start an additional one.",
                    "IrcClient()");
                return;
            }

            _ircStatus = new IrcStatus {State = Types.StatusLevel.Starting};

            _nickname = nickname;
            _passwordToken = passwordToken;
            _channel = channel;

            Connect();
        }

        /// <summary>
        /// Return the current state of the current instance of an IrcClient.
        /// </summary>
        /// <returns>An IrcStatus object containing the current status.</returns>
        protected IrcStatus Status()
        {
            return _ircStatus;
        }

        /// <summary>
        /// Add a message to the message processing queue.
        /// </summary>
        /// <param name="message">The message to add to the message processing queue.</param>
        protected void AddToQueue(string message)
        {
            _messageQueue.Enqueue(message);
        }

        /// <summary>
        /// Disconnects from Twitch's IRC client using the current instance of an IrcClient.
        /// </summary>
        protected void Disconnect()
        {
            if (_ircStatus != null && _ircStatus.State == Types.StatusLevel.Stopping)
            {
                EventLogger.AddEvent(Types.EventLevel.Error,
                    "A request to disconnect from the Twitch chat services has already been received, ignoring duplicate request.",
                    "Connect()");
                return;
            }

            _ircStatus = new IrcStatus { State = Types.StatusLevel.Stopping };
            _ircClient?.Close();
        }

        /// <summary>
        /// Connects to Twitch's IRC client using the current instance of an IrcClient.
        /// </summary>
        private void Connect()
        {
            var connectCount = 1;
            _ircClient = new TcpClient();

            // TODO: Add check for internet connection.

            while (!_ircClient.Connected)
            {
                if (connectCount == 1)
                {
                    EventLogger.AddEvent(Types.EventLevel.Info,
                        "Attempting to connect to the Twitch chat services.",
                        "Connect()");
                }
                else
                {
                    EventLogger.AddEvent(Types.EventLevel.Warning,
                        "Initial connection failed, attempting to reconnect." + Environment.NewLine + "Current amount of tries: " + connectCount,
                        "Connect()");
                }

                try
                {
                    _ircClient.Connect("irc.twitch.tv", 6667);

                    _streamReader = new StreamReader(_ircClient.GetStream());
                    _streamWriter = new StreamWriter(_ircClient.GetStream()) {AutoFlush = true};

                    AddToQueue("PASS " + _passwordToken);
                    AddToQueue("NICK " + _nickname);
                    AddToQueue("JOIN #" + _channel);
                }
                catch (SocketException exception)
                {
                    EventLogger.AddEvent(Types.EventLevel.Error,
                        "Unable to connect to the Twitch chat services, reattempting in 5 seconds.",
                        exception,
                        "Connect()");
                    _ircClient.Close();
                    connectCount++;
                    Thread.Sleep(5000);
                }
                catch (Exception exception)
                {
                    EventLogger.AddEvent(Types.EventLevel.Exception,
                        "An exception occured while trying to connect.",
                        exception,
                        "Connect()");
                    Disconnect();
                }

                if (_ircClient.Connected)
                {
                    EventLogger.AddEvent(Types.EventLevel.Info,
                        "Successfully connected to the Twitch chat services.",
                        "Connect()");
                    StartThreads();
                    _ircStatus = new IrcStatus {State = Types.StatusLevel.Running};
                }
            }
        }

        /// <summary>
        /// A Thread worker for the current message in the Writer Queue.
        /// </summary>
        private void HandleWriterQueue()
        {
            var lastMessage = "";
            var tryCounter = 1;

            while (true)
            {
                if (_messageQueue.Count == 0) continue;

                var message = _messageQueue.Peek();

                try
                {
                    lastMessage = message;
                    _streamWriter.WriteLine(message);
                    _messageQueue.Dequeue();
                    tryCounter = 1;
                }
                catch (IOException exception)
                {
                    if (tryCounter <= 10)
                    {
                        EventLogger.AddEvent(Types.EventLevel.Error,
                            "Could not send data to the Twitch chat services, reattempting in 5 seconds." +
                            Environment.NewLine + "Current amount of tries: " + tryCounter,
                            exception,
                            "HandleQueue()");

                        if (lastMessage == message) tryCounter++;
                        Thread.Sleep(5000);
                    }
                    else
                    {
                        EventLogger.AddEvent(Types.EventLevel.Error,
                            "Could not send data to the Twitch chat services, disconnecting from the services.",
                            exception,
                            "HandleQueue()");

                        Disconnect();
                    }
                }
                catch (ObjectDisposedException exception)
                {
                    EventLogger.AddEvent(Types.EventLevel.Error,
                        "Could not send data to the Twitch chat services, skipping the request. The connection was closed.",
                        exception,
                        "HandleQueue()");
                }
                catch (Exception exception)
                {
                    EventLogger.AddEvent(Types.EventLevel.Exception,
                        "An exception occured during the handling of message requests, disconnecting from the Twitch chat service.",
                        exception,
                        "HandleQueue()");

                    Disconnect();
                }
            }
        }

        /// <summary>
        /// A Thread worker for the current message in the Reader.
        /// </summary>
        private void HandleReader()
        {
            try
            {
                while (_ircClient.Connected)
                {
                    var currentMessage = _streamReader.ReadLine();
                    if (_ircStatus != null && _ircStatus.State == Types.StatusLevel.Running)
                        ReceivedMessage(currentMessage);
                }
            }
            catch (IOException exception)
            {
                EventLogger.AddEvent(Types.EventLevel.Error,
                    "A network error occured while trying to reconnect to the chat, disconnecting from the Twitch chat service.",
                    exception,
                    "HandleReader()");

                Disconnect();
            }
            catch (Exception exception)
            {
                EventLogger.AddEvent(Types.EventLevel.Exception,
                    "An unknown error occured while trying to reconnect to the chat, disconnecting from the Twitch chat service.",
                    exception,
                    "HandleReader()");

                Disconnect();
            }
        }

        /// <summary>
        /// Starts all required threads during IrcClient contstructing.
        /// </summary>
        private void StartThreads()
        {
            _listenerThread = new Thread(HandleReader) {IsBackground = true};
            _queueHandlerThread = new Thread(HandleWriterQueue) {IsBackground = true};

            _listenerThread.Start();
            _queueHandlerThread.Start();
        }

        /// <summary>
        /// Stops all required threads during IrcClient closing.
        /// </summary>
        private void StopThreads()
        {
            _listenerThread.Abort();
            _queueHandlerThread.Abort();
        }

        /// <summary>
        /// Properly parse a received message for further use.
        /// </summary>
        /// <param name="message">The raw form of a message received from an IrcClient.</param>
        protected abstract void ReceivedMessage(string message);
    }
}
