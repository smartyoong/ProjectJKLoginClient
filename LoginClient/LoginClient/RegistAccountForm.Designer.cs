namespace LoginClient
{
    partial class RegistAccountForm
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
            IDTextBox = new System.Windows.Forms.TextBox();
            IDCheckButton = new System.Windows.Forms.Button();
            PasswordTextBox = new System.Windows.Forms.TextBox();
            PasswordCheckTextBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            RegistTryButton = new System.Windows.Forms.Button();
            RegistCancelButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // IDTextBox
            // 
            IDTextBox.Location = new System.Drawing.Point(123, 36);
            IDTextBox.Name = "IDTextBox";
            IDTextBox.Size = new System.Drawing.Size(265, 23);
            IDTextBox.TabIndex = 0;
            IDTextBox.TextChanged += IDTextBox_TextChanged;
            // 
            // IDCheckButton
            // 
            IDCheckButton.Location = new System.Drawing.Point(408, 36);
            IDCheckButton.Name = "IDCheckButton";
            IDCheckButton.Size = new System.Drawing.Size(97, 23);
            IDCheckButton.TabIndex = 1;
            IDCheckButton.Text = "아이디 확인";
            IDCheckButton.UseVisualStyleBackColor = true;
            IDCheckButton.Click += IDCheckClick;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new System.Drawing.Point(123, 76);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new System.Drawing.Size(265, 23);
            PasswordTextBox.TabIndex = 2;
            PasswordTextBox.Enter += PasswordBoxEnter;
            PasswordTextBox.Leave += PasswordBoxLeave;
            // 
            // PasswordCheckTextBox
            // 
            PasswordCheckTextBox.Location = new System.Drawing.Point(123, 120);
            PasswordCheckTextBox.Name = "PasswordCheckTextBox";
            PasswordCheckTextBox.Size = new System.Drawing.Size(265, 23);
            PasswordCheckTextBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(39, 44);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 15);
            label1.TabIndex = 4;
            label1.Text = "아이디";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(39, 84);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(55, 15);
            label2.TabIndex = 5;
            label2.Text = "비밀번호";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(39, 128);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(83, 15);
            label3.TabIndex = 6;
            label3.Text = "비밀번호 확인";
            // 
            // RegistTryButton
            // 
            RegistTryButton.Location = new System.Drawing.Point(298, 168);
            RegistTryButton.Name = "RegistTryButton";
            RegistTryButton.Size = new System.Drawing.Size(105, 33);
            RegistTryButton.TabIndex = 7;
            RegistTryButton.Text = "회원가입";
            RegistTryButton.UseVisualStyleBackColor = true;
            RegistTryButton.Click += TryRegistClick;
            // 
            // RegistCancelButton
            // 
            RegistCancelButton.Location = new System.Drawing.Point(409, 168);
            RegistCancelButton.Name = "RegistCancelButton";
            RegistCancelButton.Size = new System.Drawing.Size(105, 33);
            RegistCancelButton.TabIndex = 8;
            RegistCancelButton.Text = "취소";
            RegistCancelButton.UseVisualStyleBackColor = true;
            RegistCancelButton.Click += RegistAccountCancelClick;
            // 
            // RegistAccountForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(517, 213);
            Controls.Add(RegistCancelButton);
            Controls.Add(RegistTryButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PasswordCheckTextBox);
            Controls.Add(PasswordTextBox);
            Controls.Add(IDCheckButton);
            Controls.Add(IDTextBox);
            Name = "RegistAccountForm";
            Text = "회원가입";
            FormClosing += RegistAccountClosing;
            FormClosed += RegistAccountClose;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Button IDCheckButton;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox PasswordCheckTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button RegistTryButton;
        private System.Windows.Forms.Button RegistCancelButton;
        bool IsIDUnique = false;
        bool IsPasswordCheckSame = false;
    }
}