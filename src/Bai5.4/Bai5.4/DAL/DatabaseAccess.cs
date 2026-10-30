using System.Data;
using MySql.Data.MySqlClient;

namespace Bai5._4.DAL
{
    public class DatabaseAccess
    {
        protected string connectionString = "Server=localhost;Database=HotelDB;Uid=root;Pwd=;Port=3306;";

        public DataTable ExecuteQuery(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (parameters != null) cmd.Parameters.AddRange(parameters);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }
    }
}