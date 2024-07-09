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
        EmpInfo GetEmpByTz(string tz);
        PasswordRecord GetPasswordById(int id);
        List<EmpAttendence> GetEmpAttendences(int empId);
    }
}
