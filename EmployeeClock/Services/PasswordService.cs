using EmployeeClock.DAL;
using EmployeeClock.Model;
using EmployeeClock.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.Services
{
    internal class PasswordService : IPasswordService
    {
        #region Constants

        private const string TableName = "Passwords";
        private const string Col_ID = "ID";
        private const string Col_EmployeeID = "EmployeeID";
        private const string Col_EmployeePassword = "EmployeePassword";
        private const string Col_ExpiryDate = "ExpiryDate";
        private const string Col_IsActive = "IsActive";

        #endregion


       

        public bool Create(PasswordRecord record)
        {
            string query = $"INSERT INTO {TableName} ({Col_EmployeeID}, {Col_EmployeePassword}, {Col_ExpiryDate}, {Col_IsActive}) " +
                           $"VALUES ({record.EmployeeID}, '{record.EmployeePassword}', '{record.ExpiryDate}', '{(record.IsActive ? 1 : 0)}')";

            var dt = DBContext.MakeQuery(query); 
            return dt != null; 
        }

        public bool Delete(PasswordRecord record)
        {
            string query = $"DELETE FROM {TableName} WHERE {Col_ID} = {record.ID}";

            var dt = DBContext.MakeQuery(query); 
            return dt != null; 
        }

        public PasswordRecord? GetByEmpId(int empId)
        {
            PasswordRecord? passwordRecord = null;

            string query = $"SELECT {Col_ID}, {Col_EmployeeID}, {Col_EmployeePassword}, {Col_ExpiryDate}, {Col_IsActive} " +
                           $"FROM {TableName} " +
                           $"WHERE {Col_EmployeeID} = {empId}";

            var dt = DBContext.MakeQuery(query); 

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                int id = Convert.ToInt32(row[Col_ID]);
                int employeeID = Convert.ToInt32(row[Col_EmployeeID]);
                byte[] employeePassword = (byte[])row[Col_EmployeePassword];
                DateTime expiryDate = Convert.ToDateTime(row[Col_ExpiryDate]);
                bool isActive = Convert.ToBoolean(row[Col_IsActive]);

                passwordRecord = new PasswordRecord(id, employeeID, employeePassword, expiryDate, isActive);
            }

            return passwordRecord;
        }

        public bool Update(PasswordRecord record)
        {
            string query = $"UPDATE {TableName} " +
                           $"SET {Col_EmployeePassword} = '{record.EmployeePassword}', " +
                               $"{Col_ExpiryDate} = '{record.ExpiryDate}', " +
                               $"{Col_IsActive} = '{(record.IsActive ? 1 : 0)}' " +
                           $"WHERE {Col_ID} = {record.ID}";

            var dt = DBContext.MakeQuery(query); 
            return dt != null; // Return true if update was successful
        }
    }

}
