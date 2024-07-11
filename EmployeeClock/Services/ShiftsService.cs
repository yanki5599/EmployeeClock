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
        public bool GetEmpPassword(int empId)
        {
            throw new NotImplementedException();
        }

        public DateTime GetLastAttendenseRecord(int empId)
        {
            throw new NotImplementedException();
        }

        public bool IsEmployeeExist(int empId)
        {
            throw new NotImplementedException();
        }

        public bool ValidatePassword(PasswordRecord passwordRecord, string password)
        {
            throw new NotImplementedException();
        }
    }
}
