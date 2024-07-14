using EmployeeClock.DAL;
using EmployeeClock.Model;
using EmployeeClock.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.Services
{
    internal class AttendenceService : IAttendenceService
    {



        #region Constants

        private const string TableName = "EmployeeAttendance";
        private const string Col_ID = "ID";
        private const string Col_EmployeeCode = "EmployeeCode";
        private const string Col_EntryTime = "EntryTime";
        private const string Col_ExitTime = "ExitTime";

        #endregion

        public bool Create(int empId, DateTime entry, DateTime? exit = null)
        {
            // Use parameterized query to avoid SQL injection
            string query = $"INSERT INTO {TableName} ({Col_EmployeeCode}, {Col_EntryTime}, {Col_ExitTime}) " +
                           $"VALUES (@empId, @entry, @exit)";

            // Create parameters and their values
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@empId", SqlDbType.Int) { Value = empId },
                new SqlParameter("@entry", SqlDbType.DateTime) { Value = entry }
            };

            // Add @exit parameter if it's not null
            if (exit.HasValue)
            {
                parameters.Add(new SqlParameter("@exit", SqlDbType.DateTime) { Value = exit.Value });
            }
            else
            {
                parameters.Add(new SqlParameter("@exit", SqlDbType.DateTime) { Value = DBNull.Value });
            }

            // Execute the query with parameters
            var dt =  DBContext.MakeQuery(query, parameters.ToArray());

            // Check if the query executed successfully
            return dt != null;
        }

        public bool Delete(AttendenceRec AttendRecord)
        {
            string query = $"DELETE FROM {TableName} WHERE {Col_ID} = {AttendRecord.ID}";

            var dt = DBContext.MakeQuery(query); 
            return dt != null; 
        }
        public List<AttendenceRec> GetAttendeesByEmpId(int id)
        {
            List<AttendenceRec> attendees = new List<AttendenceRec>();

            string query = $"SELECT {Col_ID}, {Col_EmployeeCode}, {Col_EntryTime}, {Col_ExitTime} " +
                           $"FROM {TableName} " +
                           $"WHERE {Col_EmployeeCode} = {id}";

            DataTable? dt = DBContext.MakeQuery(query); 

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int attendanceID = Convert.ToInt32(row[Col_ID]);
                    int employeeCode = Convert.ToInt32(row[Col_EmployeeCode]);
                    DateTime entryTime = Convert.ToDateTime(row[Col_EntryTime]);
                    DateTime? exitTime = row[Col_ExitTime] == DBNull.Value? null : Convert.ToDateTime(row[Col_ExitTime]);

                    AttendenceRec attendee = new AttendenceRec(attendanceID, employeeCode, entryTime, exitTime);
                    attendees.Add(attendee);
                }
            }

            return attendees;
        }


      
        public bool Update(AttendenceRec AttendRecord)
        {
            // Use parameterized query to avoid SQL injection
            string query = $"UPDATE {TableName} " +
                           $"SET {Col_EmployeeCode} = @EmployeeCode, " +
                               $"{Col_EntryTime} = @EntryTime, " +
                               $"{Col_ExitTime} = @ExitTime " +
                           $"WHERE {Col_ID} = @ID";

            // Create parameters and their values
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@EmployeeCode", SqlDbType.Int) { Value = AttendRecord.EmployeeCode },
                new SqlParameter("@EntryTime", SqlDbType.DateTime) { Value = AttendRecord.EntryTime },
                new SqlParameter("@ExitTime", SqlDbType.DateTime) { Value = AttendRecord.ExitTime },
                new SqlParameter("@ID", SqlDbType.Int) { Value = AttendRecord.ID }
            };

            // Execute the query with parameters
            var rowsAffected = DBContext.ExecuteNonQuery(query, parameters.ToArray());

            // Check if the query executed successfully
            return rowsAffected > 0;
        }


    }
}
