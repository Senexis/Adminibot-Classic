using System;
using System.ComponentModel.DataAnnotations;

namespace th.AdminibotModern.Classes.Database
{
    public class Event
    {
        [Key]
        public int LogId { get; set; }
        public DateTime Date { get; set; }
        public Types.EventLevel Level { get; set; }
        public string Desciption { get; set; }
        public string Origin { get; set; }
        public virtual User User { get; set; }
    }
}
