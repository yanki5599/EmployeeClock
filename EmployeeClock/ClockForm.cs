
using EmployeeClock.Model;
using EmployeeClock.Services;

namespace EmployeeClock
{
    public partial class ClockForm : Form
    {
        FormHandler FormHandler;
        ShiftsService ShiftsService;
        EmpInfo? CurrentEmpInfo = null;
        private bool ShouldExit = true;

        public ClockForm(FormHandler formHandler, EmpInfo empInfo, ShiftsService shiftsService)
        {
            FormHandler = formHandler;
            CurrentEmpInfo = empInfo;
            ShiftsService = shiftsService;
            InitializeComponent();
            DisplayEmpInfo();
        }

        private void DisplayEmpInfo()
        {
            if (CurrentEmpInfo == null) throw new ArgumentNullException("emp was null");
            label_idNum.Text = CurrentEmpInfo?.EmployeeNat;
            AttendenceRec? lastAtten = ShiftsService.GetLastAttendenseRecord(CurrentEmpInfo.ID);
            label__lastEnrtyDate.Text = lastAtten?.EntryTime.ToString();
            label_lastExitDate.Text = lastAtten?.ExitTime.ToString();
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
            CurrentEmpInfo = null;
            FormHandler.Goto(FormName.Login);
        }

        private void button_enter_Click(object sender, EventArgs e)
        {
            EmployeeEnter();
            refresh();
        }

        private void EmployeeEnter()
        {
            ShiftsService.NewAttent(CurrentEmpInfo,DateTime.Now);
        }

        private void refresh()
        {
            DisplayEmpInfo();
            TuggleEntryExitBtns();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            EmployeeExit();
            refresh();
        }

        private void EmployeeExit()
        {
            // send to db
            var last = ShiftsService.GetLastAttendenseRecord(CurrentEmpInfo.ID);
            if (last == null) throw new Exception("last attendence was null");
            
            last.ExitTime = DateTime.Now;
            ShiftsService.UpdateExit(last);

        }

        private void ClockForm_Load(object sender, EventArgs e)
        {
            TuggleEntryExitBtns();
        }

        private void TuggleEntryExitBtns()
        {
            var last = ShiftsService.GetLastAttendenseRecord(CurrentEmpInfo.ID);

            // when entry enabled
            if (last == null || (last.ExitTime != null))
            {
                TuggleExitBtn(TurnBtn.Off);
                TuggleEntryBtn(TurnBtn.On);
            }
            else {// when exit enabled
                TuggleExitBtn(TurnBtn.On);
                TuggleEntryBtn(TurnBtn.Off);
            }
        }

        private void TuggleEntryBtn(TurnBtn tb)
        {
            TuggleBtn(button_enter,tb, Color.FromArgb(0, 192, 0),Color.Gray);
        }
        private void TuggleExitBtn(TurnBtn tb)
        {
            TuggleBtn(button_exit, tb, Color.IndianRed, Color.Gray);

        }

        private void TuggleBtn(Button button, TurnBtn tb, Color enabledColor, Color disabledColor)
        {
            switch (tb)
            {
                case TurnBtn.Off:
                    button.Enabled = false;
                    button.BackColor = disabledColor;
                    break;
                case TurnBtn.On:
                    button.Enabled = true;
                    button.BackColor = enabledColor;
                    break;
                case TurnBtn.Tuggle:
                    button.Enabled = !button.Enabled;
                    button.BackColor = button.Enabled ? enabledColor : disabledColor;
                    break;
                default: throw new ArgumentException("unknow case");
            }
        }
    }
}
