using EmployeeClock.Model;
using EmployeeClock.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.Services
{
    public class ShiftsService : IShiftsService
    {
        AttendenceService AttendenceService { get;  }
        EmployeeService EmployeeService { get; }
        PasswordService PasswordService { get;   }

        public ShiftsService() 
        { 
            AttendenceService = new AttendenceService();
            EmployeeService = new EmployeeService();
            PasswordService = new PasswordService();
        }
        public PasswordRecord? GetEmpPassword(int empId)
        {
            return PasswordService.GetByEmpId(empId);
        }

        public AttendenceRec? GetLastAttendenseRecord(int empId)
        {
            var list = AttendenceService.GetAttendeesByEmpId(empId);
            return list.Count > 0 ? list.Max() : null;
        }

        public bool IsEmployeeExist(string empTz , out EmpInfo? empInfo)
        {
            empInfo = EmployeeService.GeyByTz(empTz);
            return empInfo != null;
        }

        public bool ValidateUserPass(EmpInfo empInfo, string password)
        {
            var passRec = PasswordService.GetByEmpId(empInfo.ID);
            if (passRec == null)
            {
                return false;
                throw new Exception("Critic error: user does not have a password");
            }

            return passRec.CompareHash(password);
        }

        public bool IsPasswordUptodate(EmpInfo empInfo)
        {
            var passRec = PasswordService.GetByEmpId(empInfo.ID);
            return passRec.ExpiryDate > DateTime.UtcNow;
        }

        public void NewAttent(EmpInfo currentEmpInfo, DateTime entry)
        {
            AttendenceService.Create(currentEmpInfo.ID, entry);
        }

        public void UpdateExit( AttendenceRec last)
        {
            AttendenceService.Update(last);
        }

        public bool UpdatePassword(EmpInfo? empInfo, string newPassStr)
        {
            var passwordRec = PasswordService.GetByEmpId(empInfo.ID);
            if (passwordRec == null) throw new Exception("password not found");

            var newPass = new PasswordRecord(passwordRec);
            using (SHA256 sha256 = SHA256.Create())
            {
                newPass.EmployeePassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(newPassStr));
            }

            return PasswordService.Update(newPass);
        }
    }
}
