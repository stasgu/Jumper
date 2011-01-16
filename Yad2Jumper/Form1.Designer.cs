namespace Yad2Jumper
{
    partial class Form1
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
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.buttonJump = new System.Windows.Forms.Button();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.postsListBox = new System.Windows.Forms.CheckedListBox();
            this.buttonFill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(99, 52);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(100, 20);
            this.textBoxUserName.TabIndex = 0;
            this.textBoxUserName.Text = "sales@go-systems.co.il";
            this.textBoxUserName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(23, 55);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(61, 13);
            this.labelUserName.TabIndex = 1;
            this.labelUserName.Text = "User name:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(23, 100);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(99, 97);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.Text = "walk0nby";
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(99, 147);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 4;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxOut
            // 
            this.textBoxOut.Location = new System.Drawing.Point(325, 38);
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.Size = new System.Drawing.Size(243, 20);
            this.textBoxOut.TabIndex = 5;
            // 
            // buttonJump
            // 
            this.buttonJump.Location = new System.Drawing.Point(325, 147);
            this.buttonJump.Name = "buttonJump";
            this.buttonJump.Size = new System.Drawing.Size(75, 23);
            this.buttonJump.TabIndex = 6;
            this.buttonJump.Text = "Jump!";
            this.buttonJump.UseVisualStyleBackColor = true;
            this.buttonJump.Click += new System.EventHandler(this.buttonJump_Click);
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(209, 147);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonCheck.TabIndex = 7;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // postsListBox
            // 
            this.postsListBox.FormattingEnabled = true;
            this.postsListBox.Location = new System.Drawing.Point(406, 78);
            this.postsListBox.Name = "postsListBox";
            this.postsListBox.Size = new System.Drawing.Size(462, 199);
            this.postsListBox.TabIndex = 8;
            // 
            // buttonFill
            // 
            this.buttonFill.Location = new System.Drawing.Point(325, 244);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(75, 23);
            this.buttonFill.TabIndex = 9;
            this.buttonFill.Text = "Fill";
            this.buttonFill.UseVisualStyleBackColor = true;
            this.buttonFill.Click += new System.EventHandler(this.buttonFill_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 358);
            this.Controls.Add(this.buttonFill);
            this.Controls.Add(this.postsListBox);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.buttonJump);
            this.Controls.Add(this.textBoxOut);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.textBoxUserName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.Button buttonJump;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.CheckedListBox postsListBox;
        private System.Windows.Forms.Button buttonFill;
    }
}

