using System.Net.Sockets;

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
            this.LoginButton = new System.Windows.Forms.Button();
            this.PatchProgress = new System.Windows.Forms.ProgressBar();
            this.GameStartButton = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.StatusPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.StatusPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Font = new System.Drawing.Font("휴먼엑스포", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LoginButton.Location = new System.Drawing.Point(593, 12);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(195, 37);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "로그인";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PatchProgress
            // 
            this.PatchProgress.Location = new System.Drawing.Point(12, 371);
            this.PatchProgress.Name = "PatchProgress";
            this.PatchProgress.Size = new System.Drawing.Size(565, 67);
            this.PatchProgress.TabIndex = 1;
            // 
            // GameStartButton
            // 
            this.GameStartButton.Font = new System.Drawing.Font("휴먼엑스포", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GameStartButton.Location = new System.Drawing.Point(593, 371);
            this.GameStartButton.Name = "GameStartButton";
            this.GameStartButton.Size = new System.Drawing.Size(194, 66);
            this.GameStartButton.TabIndex = 2;
            this.GameStartButton.Text = "게임시작";
            this.GameStartButton.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 12);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(565, 341);
            this.webBrowser1.TabIndex = 3;
            // 
            // StatusPictureBox
            // 
            this.StatusPictureBox.Location = new System.Drawing.Point(593, 55);
            this.StatusPictureBox.Name = "StatusPictureBox";
            this.StatusPictureBox.Size = new System.Drawing.Size(194, 297);
            this.StatusPictureBox.TabIndex = 4;
            this.StatusPictureBox.TabStop = false;
            // 
            // LoginClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StatusPictureBox);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.GameStartButton);
            this.Controls.Add(this.PatchProgress);
            this.Controls.Add(this.LoginButton);
            this.Name = "LoginClient";
            this.Text = "LoginClient";
            ((System.ComponentModel.ISupportInitialize)(this.StatusPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.ProgressBar PatchProgress;
        private System.Windows.Forms.Button GameStartButton;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.PictureBox StatusPictureBox;
    }
}

