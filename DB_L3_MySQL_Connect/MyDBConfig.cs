using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_L3_MySQL_Connect
{
    internal class MyDBConfig
    {
        public static MySqlConnection GetDBConnection(string db)
        {
            string host = "Lucerne";
            int port = 3306;
            string database = db;
            string username = "wideprism";
            string password = "rootpass";

            return MySqlUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
