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

        public bool IsEmployeeExist(int empId)
        {
            return EmployeeService.GetById(empId) != null;
        }

        public bool ValidatePassword(PasswordRecord passwordRecord, string password)
        {
            throw new NotImplementedException();
        }
    }
}
