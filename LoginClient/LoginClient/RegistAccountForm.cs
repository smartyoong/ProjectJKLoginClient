using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LoginClient
{
    public partial class RegistAccountForm : Form
    {
        public RegistAccountForm()
        {
            InitializeComponent();
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
    }
}
