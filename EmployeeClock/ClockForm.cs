
using EmployeeClock.Model;

namespace EmployeeClock
{
    public partial class ClockForm : Form
    {
        FormHandler FormHandler;
        private bool ShouldExit = true;

        public ClockForm(FormHandler formHandler, EmpInfo empInfo)
        {
            FormHandler = formHandler;
            InitializeComponent();
        }

        internal void CloseWithoutExit()
        {
            ShouldExit = false;
            this.Close();
        }

        private void ClockForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ShouldExit)
                Application.Exit();
        }

        private void linkLabel_cancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormHandler.Goto(FormName.Login);
        }

        private void button_enter_Click(object sender, EventArgs e)
        {
            EmployeeEnter();
        }

        private void EmployeeEnter()
        {
            throw new NotImplementedException();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            EmployeeExit();
        }

        private void EmployeeExit()
        {
            throw new NotImplementedException();
        }
    }
}
