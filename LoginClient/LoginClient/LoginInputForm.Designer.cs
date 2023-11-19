namespace LoginClient
{
    partial class LoginInputForm
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
            LoginButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            IDTextBox = new System.Windows.Forms.TextBox();
            PWTextBox = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            RegistButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // LoginButton
            // 
            LoginButton.Font = new System.Drawing.Font("휴먼엑스포", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LoginButton.Location = new System.Drawing.Point(306, 15);
            LoginButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new System.Drawing.Size(75, 69);
            LoginButton.TabIndex = 0;
            LoginButton.Text = "로그인";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 19);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(30, 15);
            label1.TabIndex = 1;
            label1.Text = "ID : ";
            // 
            // IDTextBox
            // 
            IDTextBox.Location = new System.Drawing.Point(56, 15);
            IDTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            IDTextBox.Name = "IDTextBox";
            IDTextBox.Size = new System.Drawing.Size(232, 23);
            IDTextBox.TabIndex = 2;
            // 
            // PWTextBox
            // 
            PWTextBox.Location = new System.Drawing.Point(56, 56);
            PWTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            PWTextBox.Name = "PWTextBox";
            PWTextBox.Size = new System.Drawing.Size(231, 23);
            PWTextBox.TabIndex = 3;
            PWTextBox.Enter += PWTextBox_Enter;
            PWTextBox.Leave += PWTextBox_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 60);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(36, 15);
            label2.TabIndex = 4;
            label2.Text = "PW : ";
            // 
            // RegistButton
            // 
            RegistButton.Font = new System.Drawing.Font("휴먼모음T", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            RegistButton.Location = new System.Drawing.Point(12, 112);
            RegistButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            RegistButton.Name = "RegistButton";
            RegistButton.Size = new System.Drawing.Size(369, 49);
            RegistButton.TabIndex = 5;
            RegistButton.Text = "회원가입";
            RegistButton.UseVisualStyleBackColor = true;
            RegistButton.Click += RegistAccountClick;
            // 
            // LoginInputForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(402, 176);
            Controls.Add(RegistButton);
            Controls.Add(label2);
            Controls.Add(PWTextBox);
            Controls.Add(IDTextBox);
            Controls.Add(label1);
            Controls.Add(LoginButton);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "LoginInputForm";
            Text = "LoginInputForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.TextBox PWTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RegistButton;
    }
}