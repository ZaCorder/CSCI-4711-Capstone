namespace UniversityRegistrationSystem.Boundry
{
    partial class RegisterForClass
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
            this.classes = new System.Windows.Forms.ListBox();
            this.Register = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // classes
            // 
            this.classes.FormattingEnabled = true;
            this.classes.Location = new System.Drawing.Point(47, 76);
            this.classes.Name = "classes";
            this.classes.Size = new System.Drawing.Size(120, 160);
            this.classes.TabIndex = 0;
            this.classes.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Register
            // 
            this.Register.AllowDrop = true;
            this.Register.Location = new System.Drawing.Point(188, 76);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(75, 23);
            this.Register.TabIndex = 1;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = true;
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "Register for Classes";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(47, 292);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(606, 126);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Registered classes";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // RegisterForClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 440);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Register);
            this.Controls.Add(this.classes);
            this.Name = "RegisterForClass";
            this.Text = "RegisterForClass";
            this.Load += new System.EventHandler(this.RegisterForClass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox classes;
        private System.Windows.Forms.Button Register;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
    }
}