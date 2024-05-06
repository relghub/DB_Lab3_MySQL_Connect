using MySql.Data.MySqlClient;

namespace DB_L3_MySQL_Connect
{
    internal class MySqlUtils
    {
        public static MySqlConnection
            GetDBConnection(string host, int port, string database,
                                  string username, string password)
        {
            string connStr = "Server=" + host + ";Database=" + database +
            ";Port=" + port + ";User ID=" + username + ";Password=" + password;

            MySqlConnection conn = new(connStr);

            return conn;
        }
    }
}
