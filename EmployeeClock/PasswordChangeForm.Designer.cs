namespace EmployeeClock
{
    partial class PasswordChangeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordChangeForm));
            label_id = new Label();
            label_oldPassword = new Label();
            label_newPassword = new Label();
            label_confirmNewPassword = new Label();
            linkLabel_cancel = new LinkLabel();
            textBox_id = new TextBox();
            textBox_oldPassword = new TextBox();
            textBox_newPassword = new TextBox();
            textBox_confirmNewPassword = new TextBox();
            button_changePassword = new Button();
            SuspendLayout();
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Font = new Font("Segoe UI", 14F);
            label_id.Location = new Point(72, 96);
            label_id.Name = "label_id";
            label_id.Size = new Size(108, 25);
            label_id.TabIndex = 0;
            label_id.Text = "תעודת זהות";
            // 
            // label_oldPassword
            // 
            label_oldPassword.AutoSize = true;
            label_oldPassword.Font = new Font("Segoe UI", 14F);
            label_oldPassword.Location = new Point(72, 153);
            label_oldPassword.Name = "label_oldPassword";
            label_oldPassword.Size = new Size(115, 25);
            label_oldPassword.TabIndex = 0;
            label_oldPassword.Text = "סיסמה ישנה";
            // 
            // label_newPassword
            // 
            label_newPassword.AutoSize = true;
            label_newPassword.Font = new Font("Segoe UI", 14F);
            label_newPassword.Location = new Point(72, 210);
            label_newPassword.Name = "label_newPassword";
            label_newPassword.Size = new Size(124, 25);
            label_newPassword.TabIndex = 0;
            label_newPassword.Text = "סיסמה חדשה";
            // 
            // label_confirmNewPassword
            // 
            label_confirmNewPassword.AutoSize = true;
            label_confirmNewPassword.Font = new Font("Segoe UI", 14F);
            label_confirmNewPassword.Location = new Point(72, 267);
            label_confirmNewPassword.Name = "label_confirmNewPassword";
            label_confirmNewPassword.Size = new Size(177, 25);
            label_confirmNewPassword.TabIndex = 0;
            label_confirmNewPassword.Text = "אישור סיסמה חדשה";
            // 
            // linkLabel_cancel
            // 
            linkLabel_cancel.AutoSize = true;
            linkLabel_cancel.Font = new Font("Segoe UI", 14F);
            linkLabel_cancel.Location = new Point(72, 324);
            linkLabel_cancel.Name = "linkLabel_cancel";
            linkLabel_cancel.Size = new Size(56, 25);
            linkLabel_cancel.TabIndex = 5;
            linkLabel_cancel.TabStop = true;
            linkLabel_cancel.Text = "ביטול";
            linkLabel_cancel.LinkClicked += linkLabel_cancel_LinkClicked;
            // 
            // textBox_id
            // 
            textBox_id.Font = new Font("Segoe UI", 14F);
            textBox_id.Location = new Point(286, 93);
            textBox_id.Name = "textBox_id";
            textBox_id.Size = new Size(151, 32);
            textBox_id.TabIndex = 0;
            // 
            // textBox_oldPassword
            // 
            textBox_oldPassword.Font = new Font("Segoe UI", 14F);
            textBox_oldPassword.Location = new Point(286, 146);
            textBox_oldPassword.Name = "textBox_oldPassword";
            textBox_oldPassword.Size = new Size(151, 32);
            textBox_oldPassword.TabIndex = 1;
            // 
            // textBox_newPassword
            // 
            textBox_newPassword.Font = new Font("Segoe UI", 14F);
            textBox_newPassword.Location = new Point(286, 203);
            textBox_newPassword.Name = "textBox_newPassword";
            textBox_newPassword.Size = new Size(151, 32);
            textBox_newPassword.TabIndex = 2;
            // 
            // textBox_confirmNewPassword
            // 
            textBox_confirmNewPassword.Font = new Font("Segoe UI", 14F);
            textBox_confirmNewPassword.Location = new Point(286, 260);
            textBox_confirmNewPassword.Name = "textBox_confirmNewPassword";
            textBox_confirmNewPassword.Size = new Size(151, 32);
            textBox_confirmNewPassword.TabIndex = 3;
            // 
            // button_changePassword
            // 
            button_changePassword.Location = new Point(286, 373);
            button_changePassword.Name = "button_changePassword";
            button_changePassword.Size = new Size(151, 37);
            button_changePassword.TabIndex = 4;
            button_changePassword.Text = "החלפת סיסמה";
            button_changePassword.UseVisualStyleBackColor = true;
            button_changePassword.Click += button_changePassword_Click;
            // 
            // PasswordChangeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 450);
            Controls.Add(button_changePassword);
            Controls.Add(textBox_confirmNewPassword);
            Controls.Add(textBox_newPassword);
            Controls.Add(textBox_oldPassword);
            Controls.Add(textBox_id);
            Controls.Add(linkLabel_cancel);
            Controls.Add(label_confirmNewPassword);
            Controls.Add(label_newPassword);
            Controls.Add(label_oldPassword);
            Controls.Add(label_id);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(535, 489);
            MinimumSize = new Size(535, 489);
            Name = "PasswordChangeForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "שעון נוכחות - החלפת סיסמה";
            FormClosed += PasswordChangeForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_id;
        private Label label_oldPassword;
        private Label label_newPassword;
        private Label label_confirmNewPassword;
        private LinkLabel linkLabel_cancel;
        private TextBox textBox_id;
        private TextBox textBox_oldPassword;
        private TextBox textBox_newPassword;
        private TextBox textBox_confirmNewPassword;
        private Button button_changePassword;
    }
}