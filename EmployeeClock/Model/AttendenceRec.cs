using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.Model
{
    internal class AttendenceRec
    {
        public int ID { get; set; } // Primary key, identity column
        public int EmployeeCode { get; set; } // Foreign key to Employees table
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }

        public AttendenceRec(int iD, int employeeCode, DateTime entryTime, DateTime exitTime)
        {
            ID = iD;
            EmployeeCode = employeeCode;
            EntryTime = entryTime;
            ExitTime = exitTime;
        }

        public static bool operator >(AttendenceRec a, AttendenceRec b)
        {
            return a.EntryTime > b.EntryTime;
        }

        public static bool operator <(AttendenceRec a, AttendenceRec b)
        {

            return a.EntryTime < b.EntryTime;
        }
    }
}
