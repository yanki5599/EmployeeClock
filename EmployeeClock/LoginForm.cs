using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeClock
{
    public partial class LoginForm : Form
    {
        FormHandler FormHandler;
        private bool ShouldExit = true;
        public LoginForm(FormHandler formHandler)
        {
            FormHandler = formHandler;
            InitializeComponent();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ShouldExit)
                Application.Exit();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            bool validInfo = ValidateInfo(out object empInfo);
            if (validInfo)
            {
                FormHandler.Goto(GoTo.Clock, empInfo);
            }
        }

        private bool ValidateInfo(out object empInfo)
        {
            empInfo = null;
            return true;
        }

        internal void CloseWithoutExit()
        {
            ShouldExit = false;
            this.Close();
        }

        private void button_changePassword_Click(object sender, EventArgs e)
        {
            FormHandler.Goto(GoTo.PasswordChange);
        }

        
    }
}
