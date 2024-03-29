﻿namespace UniversityRegistrationSystem.Boundry
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
            this.Emailtbx = new System.Windows.Forms.TextBox();
            this.Passwordtbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Loginbtn = new System.Windows.Forms.Button();
            this.ErrorLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Emailtbx
            // 
            this.Emailtbx.Location = new System.Drawing.Point(86, 98);
            this.Emailtbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Emailtbx.Name = "Emailtbx";
            this.Emailtbx.Size = new System.Drawing.Size(206, 20);
            this.Emailtbx.TabIndex = 0;
            // 
            // Passwordtbx
            // 
            this.Passwordtbx.Location = new System.Drawing.Point(86, 141);
            this.Passwordtbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Passwordtbx.Name = "Passwordtbx";
            this.Passwordtbx.PasswordChar = '*';
            this.Passwordtbx.Size = new System.Drawing.Size(206, 20);
            this.Passwordtbx.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 141);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Welcome to the University Registration System";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(278, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Please enter your Email address and Password to login in.";
            // 
            // Loginbtn
            // 
            this.Loginbtn.Location = new System.Drawing.Point(133, 169);
            this.Loginbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Loginbtn.Name = "Loginbtn";
            this.Loginbtn.Size = new System.Drawing.Size(57, 27);
            this.Loginbtn.TabIndex = 6;
            this.Loginbtn.Text = "Login";
            this.Loginbtn.UseVisualStyleBackColor = true;
            this.Loginbtn.Click += new System.EventHandler(this.Loginbtn_Click);
            // 
            // ErrorLbl
            // 
            this.ErrorLbl.AutoSize = true;
            this.ErrorLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ErrorLbl.Location = new System.Drawing.Point(46, 70);
            this.ErrorLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ErrorLbl.Name = "ErrorLbl";
            this.ErrorLbl.Size = new System.Drawing.Size(0, 13);
            this.ErrorLbl.TabIndex = 7;
            this.ErrorLbl.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 206);
            this.Controls.Add(this.ErrorLbl);
            this.Controls.Add(this.Loginbtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Passwordtbx);
            this.Controls.Add(this.Emailtbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Emailtbx;
        private System.Windows.Forms.TextBox Passwordtbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Loginbtn;
        private System.Windows.Forms.Label ErrorLbl;

        public System.Windows.Forms.Label _ErrorLbl
        {
            get
            {
                return ErrorLbl;
            }
            set
            {
                ErrorLbl = value;
            }
        }

        public System.Windows.Forms.TextBox _Emailtbx
        {
            get
            {
                return Emailtbx;
            }
            set
            {
                Emailtbx = value;
            }
        }

    }
}

