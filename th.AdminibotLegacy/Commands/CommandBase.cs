namespace th.AdminibotLegacy.Command
{
    public class CommandBase
    {
        protected Database _db;

        public CommandBase(Database db)
        {
            _db = db;
        }
    }
}
