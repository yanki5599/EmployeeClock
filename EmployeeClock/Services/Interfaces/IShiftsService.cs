using EmployeeClock.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock.Services.Interfaces
{
    internal interface IShiftsService
    {
        bool IsEmployeeExist(int empId);
        bool ValidatePassword(PasswordRecord passwordRecord, string password);
        bool GetEmpPassword(int empId);
        DateTime GetLastAttendenseRecord(int empId);
    }
}
