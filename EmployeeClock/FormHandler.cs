using EmployeeClock.Model;
using EmployeeClock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock
{
    public class FormHandler
    {
        ShiftsService ShiftsService = new ShiftsService();
        LoginForm? loginForm;
        PasswordChangeForm? passwordChangeForm;
        ClockForm? clockForm;

        //FormName appState = FormName.Login;
       

        internal void Goto(FormName state , EmpInfo? empInfo = null)
        {
            CloseAllForms();
            switch (state)
            {
                case FormName.Login:
                    loginForm = new LoginForm(this, ShiftsService);
                    loginForm.Show();
                    break;
                case FormName.PasswordChange:
                    passwordChangeForm = new PasswordChangeForm(this , ShiftsService);
                    passwordChangeForm.Show();
                    break;
                case FormName.Clock:
                    clockForm = new ClockForm(this,empInfo, ShiftsService);
                    clockForm.Show();
                    break;
                default : throw new Exception("Unknown AppState");
            }
        }

        public void Run()
        {
            loginForm = new LoginForm(this,ShiftsService);
            loginForm?.Show();
        }

        private void CloseAllForms()
        {
            /*foreach(Form form in  Application.OpenForms)
                form.Close();*/

            loginForm?.CloseWithoutExit();
            passwordChangeForm?.CloseWithoutExit();
            clockForm?.CloseWithoutExit();
        }
    }
}
