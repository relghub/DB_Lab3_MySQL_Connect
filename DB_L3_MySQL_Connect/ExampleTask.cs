using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_L3_MySQL_Connect
{
    internal class Tasks
    {
        public static void Example(MySqlConnection conn, ref TextBox displayBox)
        {
            displayBox.Clear();
            string selTable = "country";
            string id, name, continent;
            string sql = "select Code, Name, Continent from " + selTable;

            MySqlCommand cmd = new();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader["Code"].ToString();
                        name = reader["Name"].ToString();
                        continent = reader["Continent"].ToString();
                        displayBox.AppendText(Environment.NewLine);
                        displayBox.AppendText("Код країни: " + id +
                            "\tНазва: " + name +
                            "\tКонтинент: " + continent);
                        displayBox.AppendText(Environment.NewLine);
                    }
                }
            }
        }

        public static void GasFees(MySqlConnection conn, ref TextBox displayBox)
        {
            displayBox.Clear();
            string sql = "select Last_Name, First_Name, " +
                "p.Current_Meter_Value, Cost, " +
                "sum(((p.Current_Meter_Value - Previous_Meter_Value) " +
                "* t.Fee) - Cost) as Total_Debt " +
                "from consumers c " +
                "inner join payments p " +
                "on p.Consumer_ID = c.Consumer_ID " +
                "inner join tariffs t " +
                "on c.Tariff_ID = t.Tariff_ID " +
                "group by c.Consumer_ID, p.Current_Meter_Value, Cost;";
            string lastName, firstName, currentMeter, cost, debt;

            MySqlCommand cmd = new();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        displayBox.AppendText(Environment.NewLine);
                        lastName = reader["Last_Name"].ToString();
                        firstName = reader["First_Name"].ToString();
                        currentMeter = reader["Current_Meter_Value"].ToString();
                        debt = reader["Total_Debt"].ToString();
                        cost = reader["Cost"].ToString();
                        displayBox.AppendText("Споживач: " + 
                            firstName + " " + lastName +
                            "\tЗначення лічильника: " + currentMeter + " м3" +
                            "\tСума переказу: " + cost + " грн" +
                            "\tБорг: " + debt + " грн");
                        displayBox.AppendText(Environment.NewLine);
                    }
                }
            }
        }
    }
}
