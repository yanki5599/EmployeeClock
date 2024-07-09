using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.Model
{
    internal class EmpInfo
    {
        public EmpInfo(int iD, string employeeNat, string firstName, string lastName)
        {
            ID = iD;
            EmployeeNat = employeeNat;
            FirstName = firstName;
            LastName = lastName;
        }

        public int ID { get; set; } // Primary key, identity column
        public string EmployeeNat { get; set; } // TEUDAT ZEHUT, unique
        public string FirstName { get; set; }
        public string LastName { get; set; }



    }
}
