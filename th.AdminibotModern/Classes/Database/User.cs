using System;
using System.ComponentModel.DataAnnotations;

namespace th.AdminibotModern.Classes.Database
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public int Points { get; set; }
        public bool IsRegular { get; set; }
        public bool IsSubscriber { get; set; }
        public string Tag { get; set; }
        public Types.UserLevel Level { get; set; }
        public TimeSpan WatchTime { get; set; }
    }
}
