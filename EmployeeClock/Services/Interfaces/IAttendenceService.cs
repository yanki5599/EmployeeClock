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
        bool Create(int empId, DateTime entry, DateTime? exit = null);
        List<AttendenceRec> GetAttendeesByEmpId(int id);
        bool Update(AttendenceRec AttendRecord);
        bool Delete(AttendenceRec AttendRecord);

    }
}
