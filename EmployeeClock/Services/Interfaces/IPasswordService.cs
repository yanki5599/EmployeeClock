using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeClock.Model;

namespace EmployeeClock.Services.Interfaces
{
    internal interface IPasswordService
    {
        // CRUD
        bool Create(PasswordRecord record);
        PasswordRecord? GetByEmpId(int empId);
        bool Update(PasswordRecord record);
        bool Delete(PasswordRecord record);

    }
}
