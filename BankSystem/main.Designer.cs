﻿namespace BankSystem
{
    partial class main
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
            this.signup = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // signup
            // 
            this.signup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup.Location = new System.Drawing.Point(573, 464);
            this.signup.Name = "signup";
            this.signup.Size = new System.Drawing.Size(271, 96);
            this.signup.TabIndex = 1;
            this.signup.Text = "Sign up";
            this.signup.UseVisualStyleBackColor = true;
            this.signup.Click += new System.EventHandler(this.signup_Click);
            // 
            // login
            // 
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login.Location = new System.Drawing.Point(573, 260);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(271, 96);
            this.login.TabIndex = 2;
            this.login.Text = "Log in";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(520, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(380, 60);
            this.label6.TabIndex = 23;
            this.label6.Text = "Welcome to the bank";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1412, 758);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.login);
            this.Controls.Add(this.signup);
            this.Name = "main";
            this.Text = "Home Page";
            this.Load += new System.EventHandler(this.main_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button signup;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Label label6;
    }
}

