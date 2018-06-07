using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    class DBHelper
    {
        static List<Log> logs = new List<Log>();
        static SqlConnection connDB;

        static DBHelper()
        {
            connDB = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Florin\source\repos\PS2\PS2\DAL\Log.mdf;Integrated Security=True;Connect Timeout=30");
            connDB.Open();
            reloadData();
        }

        public static void reloadData()
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Log", connDB);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    logs.Add(new Log(reader.GetString(1), reader.GetDateTime(2), reader.GetString(3), reader.GetString(4)));
                }
                reader.Close();
            }
            catch (Exception a) { }
        }

        public static void addUser(string username, DateTime timestamp, string action, string state)
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Log VALUES (@Username,@Timestamp,@Action,@State)", connDB);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Timestamp", timestamp);
                command.Parameters.AddWithValue("@Action", action);
                command.Parameters.AddWithValue("@State", state);
                command.ExecuteNonQuery();
            }
            catch (Exception a) { }
            logs.Add(new Log(username, timestamp, action, state));

        }
    }
}
