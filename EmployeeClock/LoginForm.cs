using EmployeeClock.Model;
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
            bool validInfo = ValidateInfo(out EmpInfo empInfo);
            if (validInfo)
            {
                FormHandler.Goto(FormName.Clock, empInfo);
            }
        }

        private bool ValidateInfo(out EmpInfo empInfo)
        {
            // get id from form

            string idStr = textBox_id.Text;

            bool valid = Utils.isValidNatId(idStr);


            //check if exist in db
            valid &= 
            //get pass from form
            // hash
            // get pass from db
            // compare
            // return

            return true;
        }

        internal void CloseWithoutExit()
        {
            ShouldExit = false;
            this.Close();
        }

        private void button_changePassword_Click(object sender, EventArgs e)
        {
            FormHandler.Goto(FormName.PasswordChange);
        }

        
    }
}
