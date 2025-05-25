using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBOOO_PROJECT.Models;

namespace PBOOO_PROJECT.Controller
{
    internal class LoginController
    {
        public (string userType, int userId) AuthLogin(string table, string username, string password)
        {
            using (LoginContext context = new LoginContext())
            {
                string idColumn = GetIdColumnForTable(table);
                var (isAuthenticated, userId) = context.AuthenticateAndGetId(table, idColumn, username, password);

                if (isAuthenticated)
                {
                    return (table, userId);
                }
                else
                {
                    return ("Username atau password salah.", -1);
                }
            }
        }

        private string GetIdColumnForTable(string table)
        {
            switch (table)
            {
                case "Admin":
                    return "id_admin";
                case "Pemilik":
                    return "id_pemilik";
                case "Penyewa":
                    return "id_penyewa";
                default:
                    throw new ArgumentException("Invalid table name");
            }
        }
    }
}