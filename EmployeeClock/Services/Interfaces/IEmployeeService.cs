using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeClock.Model;

namespace EmployeeClock.Services.Interfaces
{
    internal interface IEmployeeService
    {
        //C - create R- read U- update D-delete
        bool Create(EmpInfo empInfo);
        EmpInfo? GetById(int id);
        EmpInfo? GeyByTz(string tz);

        bool Update(EmpInfo empInfo);
        bool Delete(EmpInfo empInfo);

    }
}
