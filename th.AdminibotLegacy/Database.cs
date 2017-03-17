using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using th.AdminibotLegacy.Properties;

namespace th.AdminibotLegacy
{
    public class Database
    {
        private SQLiteConnection _dbConnection;
        private SQLiteCommand _dbCommand;
        private string _channel;

        public Database()
        {
            _channel = Settings.Default.OptionChannel;
            InitializeDb();
        }

        private void InitializeDb()
        {
            if (!File.Exists("Adminibot_data.sqlite")) SQLiteConnection.CreateFile("Adminibot_data.sqlite");

            _dbConnection = new SQLiteConnection("Data Source=Adminibot_data.sqlite;Version=3;");
            _dbConnection.Open();

            _channel = EscapeString(_channel);

            string sql = "CREATE TABLE IF NOT EXISTS '" + _channel + "_users' (user_id INTEGER PRIMARY KEY, user_name VARCHAR(50), user_points DECIMAL(18,1) DEFAULT 0, user_isRegular INTEGER DEFAULT 0, user_isSubscriber INTEGER DEFAULT 0, user_tag TEXT DEFAULT null, user_level VARCHAR(50) DEFAULT 'Viewer', user_hoursWatched INTEGER DEFAULT 0, user_minutesWatched INTEGER DEFAULT 0, UNIQUE(user_name));";
            sql += "CREATE TABLE IF NOT EXISTS '" + _channel + "_commands' (command_id INTEGER PRIMARY KEY, command_name VARCHAR(26), command_level VARCHAR(50) DEFAULT 'Viewer', command_response VARCHAR(512), UNIQUE(command_name));";

            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                _dbCommand.ExecuteNonQuery();
            }
        }

        #region Methods for user management

        public void NewUser(string user, Types.UserLevel level)
        {
            if (user == "jtv") return;
            string sql = "INSERT OR IGNORE INTO '" + _channel + "_users' (user_name, user_level) VALUES ('" + EscapeString(user) +
                         "', '" + level + "');";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                _dbCommand.ExecuteNonQuery();
            }
        }

        public void NewUsers(List<string> users, Types.UserLevel level, Action progressAction = null)
        {
            List<List<string>> userLists = ChunkList(users, 500);
            foreach (List<string> userList in userLists)
            {
                if (userList.Count > 0)
                {
                    string sql = "INSERT OR IGNORE INTO '" + _channel + "_users' (user_name, user_level) VALUES";
                    bool isFirst = true;
                    foreach (string user in userList)
                    {
                        if (!isFirst)
                        {
                            sql += ", ";
                        }
                        else
                        {
                            isFirst = false;
                        }
                        sql += "('" + EscapeString(user) + "', '" + level + "')";
                        if (progressAction != null)
                        {
                            progressAction();
                        }
                    }

                    sql += ";";

                    using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
                    {
                        _dbCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        public bool UserExists(string user)
        {
            string sql = "SELECT * FROM '" + _channel + "_users';";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader r = _dbCommand.ExecuteReader())
                {
                    while (r.Read())
                    {
                        if (r["user_name"].ToString().Equals(user, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public Types.UserLevel GetUserLevel(string user)
        {
            if (!UserExists(user))
            {
                return Types.UserLevel.Viewer;
            }
            string sql = "SELECT * FROM '" + _channel + "_users' WHERE user_name = \"" + EscapeString(user) + "\";";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader r = _dbCommand.ExecuteReader())
                {
                    if (r.Read())
                    {
                        Types.UserLevel level;
                        if (Enum.TryParse(r["user_level"].ToString(), out level))
                        {
                            return level;
                        }
                        return Types.UserLevel.Viewer;
                    }
                    return Types.UserLevel.Viewer;
                }
            }
        }

        public void SetUserLevel(string user, int level)
        {
            string sql = "UPDATE '" + _channel + "_users' SET user_level = \"" + level + "\" WHERE user_name = \"" +
                         EscapeString(user) + "\";";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                _dbCommand.ExecuteNonQuery();
            }
        }

        #endregion
        
        #region Methods for Custom Commands

        public bool CommandExists(string command)
        {
            string sql = "SELECT * FROM '" + _channel + "_commands';";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader r = _dbCommand.ExecuteReader())
                {
                    while (r.Read())
                    {
                        if (r["command_name"].ToString().Equals(command, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void AddCommand(string command, string response, Types.CommandLevel level)
        {
            string sql = "INSERT OR IGNORE INTO '" + _channel +
                         "_commands' (command_name, command_level, command_response) VALUES ('" + EscapeString(command) + "', '" +
                         level + "', '" + EscapeString(response) + "');";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                _dbCommand.ExecuteNonQuery();
            }
        }

        public void UpdateCommandResponse(string command, string response)
        {
            string sql = "UPDATE '" + _channel + "_commands' SET command_name = '" + EscapeString(command) + "', command_response = '" +
                         EscapeString(response) + "' WHERE command_name = '" + EscapeString(command) + "';";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                _dbCommand.ExecuteNonQuery();
            }
        }

        public void UpdateCommandLevel(string command, Types.CommandLevel level)
        {
            string sql = "UPDATE '" + _channel + "_commands' SET command_name = '" + EscapeString(command) + "', command_level = '" +
                         level + "' WHERE command_name = '" + EscapeString(command) + "';";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                _dbCommand.ExecuteNonQuery();
            }
        }

        public void DeleteCommand(string command)
        {
            string sql = "DELETE FROM '" + _channel + "_commands' WHERE command_name = '" + EscapeString(command) + "';";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                _dbCommand.ExecuteNonQuery();
            }
        }

        #endregion

        #region Methods for Battletag Commands

        public bool BtagExists(string user)
        {
            string sql = "SELECT * FROM '" + _channel + "_users' WHERE user_name = '" + EscapeString(user) + "';";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader r = _dbCommand.ExecuteReader())
                {
                    while (r.Read())
                    {
                        if (!string.IsNullOrEmpty(r["user_tag"].ToString()))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public string GetBtag(string user)
        {
            string sql = "SELECT user_tag FROM '" + _channel + "_users' WHERE user_name = '" + EscapeString(user) + "';";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader r = _dbCommand.ExecuteReader())
                {
                    return r.Read() ? r["user_tag"].ToString() : null;
                }
            }
        }

        public void UpdateBtag(string user, string btag)
        {
            string sql = "UPDATE '" + _channel + "_users' SET user_tag = '" + EscapeString(btag) + "' WHERE user_name = '" + EscapeString(user) + "';";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                _dbCommand.ExecuteNonQuery();
            }
        }

        public void DeleteBtag(string user)
        {
            string sql = "UPDATE '" + _channel + "_users' SET user_tag = NULL WHERE user_name = '" + EscapeString(user) + "';";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                _dbCommand.ExecuteNonQuery();
            }
        }

        #endregion

        #region Methods for Time Watched Commands

        public string GetTime(string user)
        {
            string result = null;
            string sql = "SELECT user_hoursWatched, user_minutesWatched FROM '" + _channel +
                         "_users' WHERE user_name = '" + EscapeString(user) + "';";

            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader r = _dbCommand.ExecuteReader())
                {
                    while (r.Read())
                    {
                        result = string.Format("{0} hour(s) and {1} minute(s)", r["user_hoursWatched"],
                            r["user_minutesWatched"]);
                    }

                }
            }

            return result;
        }

        public string GetTimeTop(int number = 3)
        {
            if (number < 3) number = 3;
            if (number > 14) number = 14;

            string result = null;
            string sql = "SELECT user_name, user_hoursWatched, user_minutesWatched FROM '" + _channel +
                         "_users' ORDER BY user_hoursWatched DESC, user_minutesWatched DESC LIMIT '" + number + "';";
            int current = 1;

            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader r = _dbCommand.ExecuteReader())
                {
                    while (r.Read())
                    {
                        result += string.Format("{0}. {1} ({2}h {3}m) ", current++, r["user_name"],
                            r["user_hoursWatched"], r["user_minutesWatched"]);
                    }
                    if (result != null) result = result.TrimEnd(' ');
                }
            }

            return result;
        }

        #endregion

        #region Methods for Currency Commands

        public string GetPoints(string user)
        {
            string sql = "SELECT user_points FROM '" + _channel + "_users' WHERE user_name = '" +
                         EscapeString(user) + "';";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader r = _dbCommand.ExecuteReader())
                {
                    return r.Read() ? r["user_points"].ToString() : null;
                }
            }
        }

        public void AddPoints(string user, decimal amount)
        {
            string sql = "UPDATE '" + _channel + "_users' SET user_points = user_points + '" + amount + "' WHERE user_name = '" + EscapeString(user) + "';";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                _dbCommand.ExecuteNonQuery();
            }
        }

        public void AddPointsAll(decimal amount)
        {
            string sql = "UPDATE '" + _channel + "_users' SET user_points = user_points + '" + amount + "';";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                _dbCommand.ExecuteNonQuery();
            }
        }

        public void RemovePoints(string user, decimal amount)
        {
            string sql = "UPDATE '" + _channel + "_users' SET user_points = user_points - '" + amount + "' WHERE user_name = '" + EscapeString(user) + "';";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                _dbCommand.ExecuteNonQuery();
            }
        }

        public void RemovePointsAll(decimal amount)
        {
            string sql = "UPDATE '" + _channel + "_users' SET user_points = user_points - '" + amount + "';";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                _dbCommand.ExecuteNonQuery();
            }
        }

        public void SetPoints(string user, decimal amount)
        {
            string sql = "UPDATE '" + _channel + "_users' SET user_points = '" + amount + "' WHERE user_name = '" + EscapeString(user) + "';";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                _dbCommand.ExecuteNonQuery();
            }
        }

        public void SetPointsAll(decimal amount)
        {
            string sql = "UPDATE '" + _channel + "_users' SET user_points = '" + amount + "';";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                _dbCommand.ExecuteNonQuery();
            }
        }

        public void ClearPoints(string user)
        {
            string sql = "UPDATE '" + _channel + "_users' SET user_points = 0 WHERE user_name = '" + EscapeString(user) + "';";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                _dbCommand.ExecuteNonQuery();
            }
        }

        public void ClearPointsAll()
        {
            string sql = "UPDATE '" + _channel + "_users' SET user_points = 0;";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                _dbCommand.ExecuteNonQuery();
            }
        }

        public string GetPointsTop(int number = 3)
        {
            if (number < 3) number = 3;
            if (number > 14) number = 14;

            string result = null;
            string sql = "SELECT user_name, user_points FROM '" + _channel +
                         "_users' ORDER BY user_points DESC LIMIT '" + number + "';";
            int current = 1;

            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader r = _dbCommand.ExecuteReader())
                {
                    while (r.Read())
                    {
                        result += string.Format("{0}. {1} ({2} point(s)) ", current++, r["user_name"],
                            r["user_points"]);
                    }
                    if (result != null) result = result.TrimEnd(' ');
                }
            }

            return result;
        }

        #endregion
        
        private bool TableExists(string table)
        {
            string sql = "SELECT COUNT(*) FROM sqlite_master WHERE name = '" + EscapeString(table) + "';";
            try
            {
                using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
                {
                    using (SQLiteDataReader r = _dbCommand.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            if (int.Parse(r["COUNT(*)"].ToString()) != 0)
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                }
            }
            catch (SQLiteException e)
            {
                Program.ErrorLog(e, "TableExists()");
                return false;
            }
        }

        private bool TableHasData(string table)
        {
            string sql = "SELECT * FROM '" + EscapeString(table) + "';";

            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader r = _dbCommand.ExecuteReader())
                {
                    return r.HasRows;
                }
            }
        }

        public List<string[]> GetAllCommands()
        {
            List<string[]> commandsList = new List<string[]>();
            string sql = "SELECT * FROM '" + _channel + "_commands';";
            using (_dbCommand = new SQLiteCommand(sql, _dbConnection))
            {
                using (SQLiteDataReader r = _dbCommand.ExecuteReader())
                {
                    while (r.Read())
                    {
                        if (r.FieldCount == 4)
                        {
                            commandsList.Add(new[]
                            {
                                r["command_id"].ToString(),
                                r["command_name"].ToString(),
                                r["command_level"].ToString(),
                                r["command_response"].ToString()
 
                            });
                        }
                    }
                }
            }
            return commandsList;
        }

        private List<List<T>> ChunkList<T>(List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        private string EscapeString(string str)
        {
            StringBuilder escapedStr = new StringBuilder();
            foreach (char c in str)
                escapedStr.Append((c == '\'' ? @"'" : "") + c);

            return escapedStr.ToString();
        }
    }
}
        

