namespace EmployeeClock
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label_id = new Label();
            label_password = new Label();
            button_login = new Button();
            button_changePassword = new Button();
            textBox_id = new TextBox();
            textBox_password = new TextBox();
            SuspendLayout();
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Font = new Font("Segoe UI", 12F);
            label_id.Location = new Point(219, 95);
            label_id.Name = "label_id";
            label_id.Size = new Size(92, 21);
            label_id.TabIndex = 0;
            label_id.Text = "תעודת זהות";
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.Font = new Font("Segoe UI", 12F);
            label_password.Location = new Point(235, 183);
            label_password.Name = "label_password";
            label_password.Size = new Size(58, 21);
            label_password.TabIndex = 0;
            label_password.Text = "סיסמה";
            // 
            // button_login
            // 
            button_login.Location = new Point(174, 308);
            button_login.Name = "button_login";
            button_login.Size = new Size(183, 38);
            button_login.TabIndex = 1;
            button_login.Text = "כניסה";
            button_login.UseVisualStyleBackColor = true;
            button_login.Click += button_login_Click;
            // 
            // button_changePassword
            // 
            button_changePassword.Location = new Point(174, 365);
            button_changePassword.Name = "button_changePassword";
            button_changePassword.Size = new Size(183, 38);
            button_changePassword.TabIndex = 1;
            button_changePassword.Text = "החלפת סיסמה";
            button_changePassword.UseVisualStyleBackColor = true;
            button_changePassword.Click += button_changePassword_Click;
            // 
            // textBox_id
            // 
            textBox_id.Location = new Point(190, 119);
            textBox_id.Name = "textBox_id";
            textBox_id.Size = new Size(150, 23);
            textBox_id.TabIndex = 2;
            // 
            // textBox_password
            // 
            textBox_password.Location = new Point(190, 207);
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(150, 23);
            textBox_password.TabIndex = 2;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 450);
            Controls.Add(textBox_password);
            Controls.Add(textBox_id);
            Controls.Add(button_changePassword);
            Controls.Add(button_login);
            Controls.Add(label_password);
            Controls.Add(label_id);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(535, 489);
            MinimumSize = new Size(535, 489);
            Name = "LoginForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "שעון נוכחות- מסך התחברות";
            FormClosed += LoginForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_id;
        private Label label_password;
        private Button button_login;
        private Button button_changePassword;
        private TextBox textBox_id;
        private TextBox textBox_password;
    }
}