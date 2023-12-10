using System.Net.Sockets;
using System.Threading;

namespace LoginClient
{
    partial class LoginClient
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Socket LoginClientSocket = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            LoginButton = new System.Windows.Forms.Button();
            PatchProgress = new System.Windows.Forms.ProgressBar();
            GameStartButton = new System.Windows.Forms.Button();
            webBrowser1 = new System.Windows.Forms.WebBrowser();
            StatusPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)StatusPictureBox).BeginInit();
            SuspendLayout();
            // 
            // LoginButton
            // 
            LoginButton.Font = new System.Drawing.Font("휴먼엑스포", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LoginButton.Location = new System.Drawing.Point(593, 15);
            LoginButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new System.Drawing.Size(195, 46);
            LoginButton.TabIndex = 0;
            LoginButton.Text = "로그인";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // PatchProgress
            // 
            PatchProgress.Location = new System.Drawing.Point(12, 464);
            PatchProgress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            PatchProgress.Name = "PatchProgress";
            PatchProgress.Size = new System.Drawing.Size(565, 84);
            PatchProgress.TabIndex = 1;
            // 
            // GameStartButton
            // 
            GameStartButton.Font = new System.Drawing.Font("휴먼엑스포", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            GameStartButton.Location = new System.Drawing.Point(593, 464);
            GameStartButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            GameStartButton.Name = "GameStartButton";
            GameStartButton.Size = new System.Drawing.Size(194, 82);
            GameStartButton.TabIndex = 2;
            GameStartButton.Text = "게임시작";
            GameStartButton.UseVisualStyleBackColor = true;
            GameStartButton.Click += GameStartButtonClick;
            // 
            // webBrowser1
            // 
            webBrowser1.Location = new System.Drawing.Point(12, 15);
            webBrowser1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            webBrowser1.MinimumSize = new System.Drawing.Size(20, 25);
            webBrowser1.Name = "webBrowser1";
            webBrowser1.Size = new System.Drawing.Size(565, 426);
            webBrowser1.TabIndex = 3;
            // 
            // StatusPictureBox
            // 
            StatusPictureBox.Location = new System.Drawing.Point(593, 69);
            StatusPictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            StatusPictureBox.Name = "StatusPictureBox";
            StatusPictureBox.Size = new System.Drawing.Size(194, 371);
            StatusPictureBox.TabIndex = 4;
            StatusPictureBox.TabStop = false;
            // 
            // LoginClient
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 562);
            Controls.Add(StatusPictureBox);
            Controls.Add(webBrowser1);
            Controls.Add(GameStartButton);
            Controls.Add(PatchProgress);
            Controls.Add(LoginButton);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "LoginClient";
            Text = "LoginClient";
            FormClosing += MainFormClosing;
            ((System.ComponentModel.ISupportInitialize)StatusPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.ProgressBar PatchProgress;
        private System.Windows.Forms.Button GameStartButton;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.PictureBox StatusPictureBox;
    }
}

