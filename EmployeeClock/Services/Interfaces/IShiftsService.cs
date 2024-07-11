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
        bool IsEmployeeExist(string empTz, out EmpInfo? empInfo);
        PasswordRecord? GetEmpPassword(int empId);
        AttendenceRec? GetLastAttendenseRecord(int empId);
    }
}
