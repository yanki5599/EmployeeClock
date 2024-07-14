using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Collections;

namespace EmployeeClock.Model
{
    public class PasswordRecord
    {
        public int ID { get; set; } // Primary key, identity column
        public int EmployeeID { get; set; } // Foreign key to Employees table
        public byte[] EmployeePassword { get; set; } // remember Storing hashed passwords as VARBINARY(256)
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }

        public PasswordRecord(int iD, int employeeID, byte[] employeePassword, DateTime expiryDate, bool isActive = true)
        {
            ID = iD;
            EmployeeID = employeeID;
            EmployeePassword = employeePassword;
            ExpiryDate = expiryDate;
            IsActive = isActive;
        }
        
        
        // Copy constructor
        public PasswordRecord(PasswordRecord original)
        {
            ID = original.ID;
            EmployeeID = original.EmployeeID;
            EmployeePassword = original.EmployeePassword.ToArray(); // Deep copy of byte array
            ExpiryDate = original.ExpiryDate;
            IsActive = original.IsActive;
        }

        public bool CompareHash(string strPass)
        {
            byte[] hashedBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(strPass));
            }
            return hashedBytes.SequenceEqual(EmployeePassword);
        }

        
    }
}
