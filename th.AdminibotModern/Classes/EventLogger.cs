using System;
using th.AdminibotModern.Classes.Database;

namespace th.AdminibotModern.Classes
{
    class EventLogger
    {
        /// <summary>
        /// Add a new event to the database etc.
        /// </summary>
        /// <param name="type">A Types.EventLevel describing what level the current event is.</param>
        /// <param name="description">The body of the event, includes details, information, etc.</param>
        public static void AddEvent(Types.EventLevel type, string description)
        {
            Console.WriteLine(description);
        }

        /// <summary>
        /// Add a new event to the database etc.
        /// </summary>
        /// <param name="type">A Types.EventLevel describing what level the current event is.</param>
        /// <param name="description">The body of the event, includes details, information, etc.</param>
        /// <param name="user">(Optional) The user that triggered the warning.</param>
        public static void AddEvent(Types.EventLevel type, string description, User user = null)
        {
            Console.WriteLine(description);
        }

        /// <summary>
        /// Add a new event to the database etc.
        /// </summary>
        /// <param name="type">A Types.EventLevel describing what level the current event is.</param>
        /// <param name="description">The body of the event, includes details, information, etc.</param>
        /// <param name="origin">(Optional) The origin of the event.</param>
        /// <param name="user">(Optional) The user that triggered the warning.</param>
        public static void AddEvent(Types.EventLevel type, string description, string origin = null, User user = null)
        {
            Console.WriteLine(description);
        }

        /// <summary>
        /// Add a new event to the database etc.
        /// </summary>
        /// <param name="type">A Types.EventLevel describing what level the current event is.</param>
        /// <param name="description">The body of the event, includes details, information, etc.</param>
        /// <param name="exception">(Optional) Details of the exception.</param>
        /// <param name="origin">(Optional) The origin of the event.</param>
        /// <param name="user">(Optional) The user that triggered the warning.</param>
        public static void AddEvent(Types.EventLevel type, string description, Exception exception = null, string origin = null, User user = null)
        {
            Console.WriteLine(description + " / Exception: " + exception);
        }
    }
}
