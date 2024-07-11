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

        FormName appState = FormName.Login;
        public FormHandler() 
        { 
        }

        internal void Goto(FormName state , object? empInfo = null)
        {
            CloseAllForms();
            switch (state)
            {
                case FormName.Login:
                    loginForm = new LoginForm(this);
                    loginForm.Show();
                    break;
                case FormName.PasswordChange:
                    passwordChangeForm = new PasswordChangeForm(this);
                    passwordChangeForm.Show();
                    break;
                case FormName.Clock:
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
