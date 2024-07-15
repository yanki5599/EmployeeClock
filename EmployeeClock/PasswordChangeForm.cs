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
    public partial class PasswordChangeForm : ReaLTaiizor.Forms.MaterialForm
    {
        FormHandler FormHandler;
        ShiftsService ShiftsService;
        private bool ShouldExit = true;

        public PasswordChangeForm(FormHandler formHandler , ShiftsService shiftsService, EmpInfo? empInfo = null)
        {
            FormHandler = formHandler;
            ShiftsService = shiftsService;
            InitializeComponent();
            textBox_id.Text = empInfo?.EmployeeNat ?? "";
        }


        internal void CloseWithoutExit()
        {
            ShouldExit = false;
            this.Close();
        }

        private void PasswordChangeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ShouldExit)
            {
                if (Utils.AreYouSureMsg("האם אתה בטוח שברצונך לצאת?")) ;
                Application.Exit();
            }
        }

        private void linkLabel_cancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormHandler.Goto(FormName.Login);
        }

        private void button_changePassword_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }

        private void ChangePassword()
        {
            if (ValidateInfo())
            {
                MessageBox.Show("Password changed successfully", "Success!");
                FormHandler.Goto(FormName.Login);
            }
        }

        private bool ValidateInfo()
        {
            // get id from form

            string idStr = textBox_id.Text.Trim();
            bool valid = Utils.isValidNatId(idStr);
            if (!valid)
            {
                MessageBox.Show("הכנס מס' זהות תקין.", "שגיאת פורמט", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //check if exist in db
            valid = ShiftsService.IsEmployeeExist(idStr, out EmpInfo? empInfo);
            if (!valid)
            {
                MessageBox.Show("משתמש לא נמצא!", "לא נמצא", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox_id.Text = null; // reset field
                return false;
            }

            //get pass from form
            string password = textBox_oldPassword.Text.Trim();
            valid = ShiftsService.ValidateUserPass(empInfo, password);
            if (!valid)
            {
                MessageBox.Show("סיסמה שגויה!", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_oldPassword.Text = null; // reset field
                return false;
            }

            //validate new password
            string newPass = textBox_newPassword.Text.Trim();
            string newPassConfirm = textBox_confirmNewPassword.Text.Trim();
            valid = newPass == newPassConfirm && !string.IsNullOrEmpty(newPass);
            if (!valid)
            {
                MessageBox.Show("סיסמאות לא דומות", "שגיאה!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_newPassword.Text = null;
                textBox_confirmNewPassword.Text = null;
                return false;
            }

            bool success = ShiftsService.UpdatePassword(empInfo, newPass);
            if (!success) throw new Exception("cannot change pass");
            return true;
        }
    }
}
