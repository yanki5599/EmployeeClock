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
    public partial class PasswordChangeForm : Form
    {
        FormHandler FormHandler;
        private bool ShouldExit = true;

        public PasswordChangeForm(FormHandler formHandler)
        {
            FormHandler = formHandler;
            InitializeComponent();
        }


        internal void CloseWithoutExit()
        {
            ShouldExit = false;
            this.Close();
        }

        private void PasswordChangeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ShouldExit)
                Application.Exit();
        }

        private void linkLabel_cancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormHandler.Goto(GoTo.Login);
        }

        private void button_changePassword_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }

        private void ChangePassword()
        {
            throw new NotImplementedException();
        }
    }
}
