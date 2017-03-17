using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FirstFloor.ModernUI.Presentation;

namespace th.AdminibotModern.Pages.Connection
{
    public class SignInViewModel : NotifyPropertyChanged, IDataErrorInfo
    {
        private string _username;
        private string _channel;

        public string Username
        {
            get { return _username; }
            set
            {
                if (_username == value) return;
                _username = value;
                OnPropertyChanged("Username");
            }
        }
        public string Channel
        {
            get { return _channel; }
            set
            {
                if (_channel == value) return;
                _channel = value;
                OnPropertyChanged("Channel");
            }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Username":
                        if (string.IsNullOrWhiteSpace(_username))
                        {
                            return "Username cannot be empty.";
                        }
                        if (_username.Length < 4)
                        {
                            return "Username cannot be shorter than 4 characters.";
                        }
                        if (_username.Length > 25)
                        {
                            return "Username cannot be longer than 25 characters.";
                        }
                        if (_username.StartsWith("_"))
                        {
                            return "Username cannot begin with \"_\".";
                        }
                        if (!Regex.IsMatch(_username, "^[a-zA-Z0-9_]{4,25}$"))
                        {
                            return "Username contains invalid character(s).";
                        }
                        return null;
                    case "Channel":
                        if (string.IsNullOrWhiteSpace(_channel))
                        {
                            return "Channel cannot be empty.";
                        }
                        if (_channel.Length < 4)
                        {
                            return "Channel cannot be shorter than 4 characters.";
                        }
                        if (_channel.Length > 25)
                        {
                            return "Channel cannot be longer than 25 characters.";
                        }
                        if (_channel.StartsWith("_"))
                        {
                            return "Channel cannot begin with \"_\".";
                        }
                        if (!Regex.IsMatch(_channel, "^[a-zA-Z0-9_]{4,25}$"))
                        {
                            return "Channel contains invalid character(s).";
                        }
                        return null;
                    default:
                        return null;
                }
            }
        }

        public string Error => null;
    }
}
