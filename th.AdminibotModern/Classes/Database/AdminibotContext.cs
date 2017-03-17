using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace th.AdminibotModern.Classes.Database
{
    public class AdminibotContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
