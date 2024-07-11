using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.Model
{
    internal class PasswordRecord
    {
        public int ID { get; set; } // Primary key, identity column
        public int EmployeeID { get; set; } // Foreign key to Employees table
        public byte[] EmployeePassword { get; set; } // remember Storing hashed passwords as VARBINARY(256)
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }

        public PasswordRecord(int iD, int employeeID, byte[] employeePassword, DateTime expiryDate, bool isActive)
        {
            ID = iD;
            EmployeeID = employeeID;
            EmployeePassword = employeePassword;
            ExpiryDate = expiryDate;
            IsActive = isActive;
        }
    }
}
