using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using PBOOO_PROJECT.Models.Admin;
//using PBOOO_PROJECT.Models.Penjual;

namespace PBOOO_PROJECT.Controller.Admin
{
    internal class ProfileControllerA
    {
        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
    }
}
