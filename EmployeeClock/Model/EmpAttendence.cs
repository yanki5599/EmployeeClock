using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.Model
{
    internal class EmpAttendence
    {
        public int ID { get; set; } // Primary key, identity column
        public int EmployeeCode { get; set; } // Foreign key to Employees table
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }

        public EmpAttendence(int iD, int employeeCode, DateTime entryTime, DateTime exitTime)
        {
            ID = iD;
            EmployeeCode = employeeCode;
            EntryTime = entryTime;
            ExitTime = exitTime;
        }
    }
}
