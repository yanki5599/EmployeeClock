using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.DAL
{
    internal class DBConfig
    {

        const string server = "DESKTOP-UCE3JF7";
        const string database = "empAttendence";
        const string username = "sa";
        const string password = "1234";
         
        public const string connectionString = $"Server={server};Database={database};User Id={username};Password={password};";
    }
}
