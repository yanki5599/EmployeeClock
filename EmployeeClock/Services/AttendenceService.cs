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
    internal class AttendenceService : IAttendenceService
    {



        #region Constants

        private const string TableName = "EmployeeAttendance";
        private const string Col_ID = "ID";
        private const string Col_EmployeeCode = "EmployeeCode";
        private const string Col_EntryTime = "EntryTime";
        private const string Col_ExitTime = "ExitTime";

        #endregion

        public bool Create(AttendenceRec AttendRecord)
        {
            string query = $"INSERT INTO {TableName} ({Col_EmployeeCode}, {Col_EntryTime}, {Col_ExitTime}) " +
                           $"VALUES ({AttendRecord.EmployeeCode}, '{AttendRecord.EntryTime}', '{AttendRecord.ExitTime}')";

            var dt = DBContext.MakeQuery(query);
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
                    DateTime exitTime = Convert.ToDateTime(row[Col_ExitTime]);

                    AttendenceRec attendee = new AttendenceRec(attendanceID, employeeCode, entryTime, exitTime);
                    attendees.Add(attendee);
                }
            }

            return attendees;
        }
        public bool Update(AttendenceRec AttendRecord)
        {
            string query = $"UPDATE {TableName} " +
                           $"SET {Col_EmployeeCode} = {AttendRecord.EmployeeCode}, " +
                               $"{Col_EntryTime} = '{AttendRecord.EntryTime}', " +
                               $"{Col_ExitTime} = '{AttendRecord.ExitTime}' " +
                           $"WHERE {Col_ID} = {AttendRecord.ID}";

            var dt = DBContext.MakeQuery(query); 
            return dt != null; 
        }

    }
}
