using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBOOO_PROJECT.Tools;

namespace PBOOO_PROJECT.Models
{
    public class LoginContext : IDisposable
    {
        private NpgsqlConnection _connection;

        public LoginContext()
        {
            // Initialize the _connection field to avoid the CS8618 warning
            _connection = new NpgsqlConnection();
        }

        public (bool isAuthenticated, int userId) AuthenticateAndGetId(string table, string idColumn, string username, string password)
        {
            string query = $"SELECT {idColumn} FROM {table} WHERE username=@username AND password=@password";
            using (var db = new DBConnection())
            {
                db.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, db.Connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int userId = Convert.ToInt32(result);
                        return (true, userId);
                    }
                    else
                    {
                        return (false, -1);
                    }
                }
            }
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}
