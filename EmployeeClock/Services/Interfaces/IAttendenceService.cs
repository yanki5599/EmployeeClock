using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeClock.Model;

namespace EmployeeClock.Services.Interfaces
{
    internal interface IAttendenceService
    {
        // CRUD
        bool Create(EmpAttendence AttendRecord);
        List<EmpAttendence> GetAttendeesByEmpId(int id);
        bool Update(EmpAttendence AttendRecord);
        bool Delete(EmpAttendence AttendRecord);

    }
}
