using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LoginClient
{
    public partial class RegistAccountForm : Form
    {
        private System.Windows.Forms.ToolTip PasswordToolTip = new System.Windows.Forms.ToolTip();
        public RegistAccountForm()
        {
            InitializeComponent();
            PasswordTextBox.PasswordChar = '●';
            PasswordCheckTextBox.PasswordChar = '●';
        }

        private void RegistAccountClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Visible = true;
        }

        private void RegistAccountClose(object sender, FormClosedEventArgs e)
        {

        }

        private void IDCheckClick(object sender, EventArgs e)
        {
            if (IDTextBox.TextLength > 24)
            {
                if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows) && OperatingSystem.IsWindowsVersionAtLeast(10, 0, 19041))
                {
                    SystemSounds.Beep.Play();
                }
                MessageBox.Show("ID의 최대 글자는 한글 12자 영문 24자 입니다.", "ID의 글자가 너무 깁니다.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoginMessagePacket Packet = new LoginMessagePacket();
            Packet.StringValue1 = IDTextBox.Text;
            Packet.IDNum = LOGIN_CLIENT_PACKET_ID.LOGIN_CLIENT_CHECK_ID_UNIQUE;
            byte[] DataByte = SocketDataSerializer.Serialize(Packet);
            LoginClient MainForm = (LoginClient)Owner.Owner;
            if (MainForm != null)
            {
                MainForm.SendSocketData(ref DataByte);
            }
        }
        public void CheckIDOK()
        {
            IsIDUnique = true;
        }

        private void IDTextBox_TextChanged(object sender, EventArgs e)
        {
            IsIDUnique = false;
        }

        private void RegistAccountCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void TryRegistClick(object sender, EventArgs e)
        {
            if(!IsIDUnique) 
            {
                MessageBox.Show("다른 ID를 사용해주세요.", "아이디 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!CheckPasswordValid(PasswordTextBox.Text))
            {
                MessageBox.Show("비밀번호 형식이 유효하지 않습니다.", "비밀번호 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (PasswordTextBox.Text != PasswordCheckTextBox.Text)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.", "비밀번호 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoginMessagePacket Packet = new LoginMessagePacket();
            Packet.StringValue1 = IDTextBox.Text;
            Packet.StringValue2 = PasswordTextBox.Text;
            Packet.IDNum = LOGIN_CLIENT_PACKET_ID.LOGIN_CLIENT_TRY_REGIST;
            byte[] DataByte = SocketDataSerializer.Serialize(Packet);
            LoginClient MainForm = (LoginClient)Owner.Owner;
            if (MainForm != null)
            {
                MainForm.SendSocketData(ref DataByte);
            }
        }
        private bool CheckPasswordValid(string PW)
        {
            string Pattern = "^[a-zA-Z0-9!@#$%]{8,16}$";
            if (!Regex.IsMatch(PW, Pattern))
            {
                return false;
            }
            return true;
        }

        private void PasswordBoxEnter(object sender, EventArgs e)
        {
            PasswordToolTip.Show("비밀번호는 길이가 8에서 16 사이이며, 소문자, 대문자, 숫자, 그리고 특수 문자 !, @, #, $, %만 가능합니다.", PasswordTextBox, 0, PasswordTextBox.Height, 5000);
        }

        private void PasswordBoxLeave(object sender, EventArgs e)
        {
            PasswordToolTip.Hide(PasswordTextBox);
        }
    }
}
