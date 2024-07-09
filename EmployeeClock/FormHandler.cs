using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock
{
    internal class FormHandler
    {
        LoginForm loginForm;
        PasswordChangeForm passwordChangeForm;
        ClockForm clockForm;
        public FormHandler() 
        { 
            loginForm = new LoginForm();
            passwordChangeForm = new PasswordChangeForm();

        }
    }
}
