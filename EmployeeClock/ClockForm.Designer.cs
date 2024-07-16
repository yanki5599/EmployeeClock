namespace EmployeeClock
{
    partial class ClockForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_idLabel = new Label();
            label_idNum = new Label();
            label_lastEnrtyDateLabel = new Label();
            label__lastEnrtyDate = new Label();
            label_lastExitDateLabel = new Label();
            linkLabel_cancel = new LinkLabel();
            button_enter = new Button();
            button_exit = new Button();
            label_lastExitDate = new Label();
            SuspendLayout();
            // 
            // label_idLabel
            // 
            label_idLabel.AutoSize = true;
            label_idLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label_idLabel.Location = new Point(271, 50);
            label_idLabel.Name = "label_idLabel";
            label_idLabel.Size = new Size(97, 25);
            label_idLabel.TabIndex = 0;
            label_idLabel.Text = "זהות עובד";
            // 
            // label_idNum
            // 
            label_idNum.AutoSize = true;
            label_idNum.Font = new Font("Segoe UI", 14F);
            label_idNum.Location = new Point(163, 50);
            label_idNum.Name = "label_idNum";
            label_idNum.Size = new Size(102, 25);
            label_idNum.TabIndex = 0;
            label_idNum.Text = "000000000";
            // 
            // label_lastEnrtyDateLabel
            // 
            label_lastEnrtyDateLabel.AutoSize = true;
            label_lastEnrtyDateLabel.Font = new Font("Segoe UI", 13F);
            label_lastEnrtyDateLabel.Location = new Point(184, 124);
            label_lastEnrtyDateLabel.Name = "label_lastEnrtyDateLabel";
            label_lastEnrtyDateLabel.Size = new Size(160, 25);
            label_lastEnrtyDateLabel.TabIndex = 1;
            label_lastEnrtyDateLabel.Text = "תאריך כניסה אחרון";
            // 
            // label__lastEnrtyDate
            // 
            label__lastEnrtyDate.AutoSize = true;
            label__lastEnrtyDate.BackColor = Color.Chartreuse;
            label__lastEnrtyDate.Font = new Font("Segoe UI", 12F);
            label__lastEnrtyDate.Location = new Point(205, 161);
            label__lastEnrtyDate.Name = "label__lastEnrtyDate";
            label__lastEnrtyDate.Size = new Size(137, 21);
            label__lastEnrtyDate.TabIndex = 1;
            label__lastEnrtyDate.Text = "dd/mm/yy hh:mm";
            // 
            // label_lastExitDateLabel
            // 
            label_lastExitDateLabel.AutoSize = true;
            label_lastExitDateLabel.Font = new Font("Segoe UI", 13F);
            label_lastExitDateLabel.Location = new Point(185, 213);
            label_lastExitDateLabel.Name = "label_lastExitDateLabel";
            label_lastExitDateLabel.Size = new Size(158, 25);
            label_lastExitDateLabel.TabIndex = 1;
            label_lastExitDateLabel.Text = "תאריך יציאה אחרון";
            // 
            // linkLabel_cancel
            // 
            linkLabel_cancel.AutoSize = true;
            linkLabel_cancel.Font = new Font("Segoe UI", 12F);
            linkLabel_cancel.Location = new Point(241, 333);
            linkLabel_cancel.Name = "linkLabel_cancel";
            linkLabel_cancel.Size = new Size(47, 21);
            linkLabel_cancel.TabIndex = 2;
            linkLabel_cancel.TabStop = true;
            linkLabel_cancel.Text = "ביטול";
            linkLabel_cancel.LinkClicked += linkLabel_cancel_LinkClicked;
            // 
            // button_enter
            // 
            button_enter.BackColor = Color.FromArgb(0, 192, 0);
            button_enter.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button_enter.ForeColor = Color.White;
            button_enter.Location = new Point(384, 333);
            button_enter.Name = "button_enter";
            button_enter.Size = new Size(82, 64);
            button_enter.TabIndex = 3;
            button_enter.Text = "כניסה";
            button_enter.UseVisualStyleBackColor = false;
            button_enter.Click += button_enter_Click;
            // 
            // button_exit
            // 
            button_exit.BackColor = Color.IndianRed;
            button_exit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button_exit.ForeColor = Color.White;
            button_exit.Location = new Point(53, 333);
            button_exit.Name = "button_exit";
            button_exit.Size = new Size(82, 64);
            button_exit.TabIndex = 3;
            button_exit.Text = "יציאה";
            button_exit.UseVisualStyleBackColor = false;
            button_exit.Click += button_exit_Click;
            // 
            // label_lastExitDate
            // 
            label_lastExitDate.AutoSize = true;
            label_lastExitDate.BackColor = Color.Red;
            label_lastExitDate.Font = new Font("Segoe UI", 12F);
            label_lastExitDate.ForeColor = Color.White;
            label_lastExitDate.Location = new Point(205, 249);
            label_lastExitDate.Name = "label_lastExitDate";
            label_lastExitDate.Size = new Size(137, 21);
            label_lastExitDate.TabIndex = 1;
            label_lastExitDate.Text = "dd/mm/yy hh:mm";
            // 
            // ClockForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 450);
            Controls.Add(button_exit);
            Controls.Add(button_enter);
            Controls.Add(linkLabel_cancel);
            Controls.Add(label_lastExitDateLabel);
            Controls.Add(label_lastExitDate);
            Controls.Add(label__lastEnrtyDate);
            Controls.Add(label_lastEnrtyDateLabel);
            Controls.Add(label_idNum);
            Controls.Add(label_idLabel);
            Name = "ClockForm";
            Padding = new Padding(50);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "שעון כניסה ויציאה";
            FormClosed += ClockForm_FormClosed;
            Load += ClockForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_idLabel;
        private Label label_idNum;
        private Label label_lastEnrtyDateLabel;
        private Label label__lastEnrtyDate;
        private Label label_lastExitDateLabel;
        private LinkLabel linkLabel_cancel;
        private Button button_enter;
        private Button button_exit;
        private Label label_lastExitDate;
    }
}
