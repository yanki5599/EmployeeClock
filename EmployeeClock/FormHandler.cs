using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClock
{
    public class FormHandler
    {
        LoginForm? loginForm;
        PasswordChangeForm? passwordChangeForm;
        ClockForm? clockForm;

        GoTo appState = GoTo.Login;
        public FormHandler() 
        { 
        }

        internal void Goto(GoTo state , object? empInfo = null)
        {
            CloseAllForms();
            switch (state)
            {
                case GoTo.Login:
                    loginForm = new LoginForm(this);
                    loginForm.Show();
                    break;
                case GoTo.PasswordChange:
                    passwordChangeForm = new PasswordChangeForm(this);
                    passwordChangeForm.Show();
                    break;
                case GoTo.Clock:
                    clockForm = new ClockForm(this,empInfo);
                    clockForm.Show();
                    break;
                default : throw new Exception("Unknown AppState");
            }
        }

        public void Run()
        {
            loginForm = new LoginForm(this);
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
