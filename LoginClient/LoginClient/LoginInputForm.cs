using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginClient
{
    public partial class LoginInputForm : Form
    {
        public LoginInputForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string IDString = IDTextBox.Text;
            string PWString = PWTextBox.Text;
            if (IDString != null && PWString != null) 
            {
                LoginMessagePacket Packet = new LoginMessagePacket();
                Packet.StringValue1 = IDString;
                Packet.StringValue2 = PWString;
                Packet.IDNum = LOGIN_CLIENT_PACKET_ID.LOGIN_CLIENT_TRY_LOGIN;
                byte[] DataByte = SocketDataSerializer.Serialize<LoginMessagePacket>(Packet);
                LoginClient MainForm = (LoginClient)this.Owner;
                if(MainForm != null) 
                {
                    MainForm.SendSocketData(ref DataByte);
                    MessageBox.Show("데이터전송완료!");
                }
            }
        }
    }
}
