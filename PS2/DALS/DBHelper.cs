using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class DBHelper
    {
        public static List<Log> logs = new List<Log>();
      //  static SqlConnection connDB;

        static DBHelper()
        {
            reloadData();
        }

        private static SqlConnection GetConnection()
        {
            var connDB = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Delia\source\repos\Oruet\PS2\DALS\Log.mdf;Integrated Security=True;Connect Timeout=30");
            connDB.Open();

            return connDB;
        }

        public static void reloadData()
        {
            try
            {
                var conn = GetConnection();
                SqlCommand command = new SqlCommand("SELECT * FROM Log", conn);
                SqlDataReader reader = command.ExecuteReader();
                logs.Clear();
                while (reader.Read())
                {
                    logs.Add(new Log(reader.GetString(1), reader.GetDateTime(2), reader.GetString(3), reader.GetString(4)));
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception a) { }
        }

        public static void addUser(string username, DateTime timestamp, string action, string state)
        {
            try
            {
                var conn = GetConnection();
                SqlCommand command = new SqlCommand("INSERT INTO Log VALUES (@Username,@Timestamp,@Action,@State)",conn);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Timestamp", timestamp);
                command.Parameters.AddWithValue("@Action", action);
                command.Parameters.AddWithValue("@State", state);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception a) {

            }
            logs.Add(new Log(username, timestamp, action, state));

        }
    }
}
