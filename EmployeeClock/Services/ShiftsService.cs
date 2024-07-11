using EmployeeClock.Model;
using EmployeeClock.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.Services
{
    internal class ShiftsService : IShiftsService
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
            return list.Max();
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

            return passRec.EmployeePassword == Utils.Hash256Password(password);
        }

    
    }
}
