using EmployeeClock.Model;
using EmployeeClock.Services;
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
        ShiftsService ShiftsService = new ShiftsService();

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
            if (ValidateInfo(out EmpInfo? empInfo))
            {
                FormHandler.Goto(FormName.Clock, empInfo);
            }
        }

        private bool ValidateInfo(out EmpInfo? empInfo)
        {
            // get id from form

            string idStr = textBox_id.Text.Trim();
            bool valid = Utils.isValidNatId(idStr);
            if (!valid)
            {
                MessageBox.Show("הכנס מס' זהות תקין.", "שגיאת פורמט", MessageBoxButtons.OK, MessageBoxIcon.Error);
                empInfo = null;
                return false;
            }

            //check if exist in db
            valid = ShiftsService.IsEmployeeExist(idStr , out EmpInfo? empInfo1);
            if (!valid)
            {
                MessageBox.Show("משתמש לא נמצא!", "לא נמצא", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                empInfo = null;
                textBox_id.Text = null; // reset field
                return false;
            }

            //get pass from form
            string password = textBox_password.Text.Trim();
            valid = ShiftsService.ValidateUserPass(empInfo1, password);
            if (!valid)
            {
                MessageBox.Show("סיסמה שגויה!", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                empInfo = null;
                textBox_password.Text = null; // reset field
                return false;
            }

            empInfo = empInfo1;
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
