using System.ComponentModel.DataAnnotations;

namespace th.AdminibotModern.Classes.Database
{
    public class Command
    {
        [Key]
        public int CommandId { get; set; }
        public string Name { get; set; }
        public string Response { get; set; }
        public Types.UserLevel Level { get; set; }
    }
}
