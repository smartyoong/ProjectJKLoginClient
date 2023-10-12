using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginClient
{
    public partial class LoginClient : Form
    {
        public LoginClient()
        {
            InitializeComponent();
            ConnectToLoginServer();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginInputForm LoginInputDlg = new LoginInputForm();
            LoginInputDlg.ShowDialog();
        }
        private void ConnectToLoginServer()
        {
            LoginClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress IPAddr = IPAddress.Parse("115.136.46.23");
            IPEndPoint IPEnd = new IPEndPoint(IPAddr,11220);
            try
            {
                LoginClientSocket.Connect(IPEnd);
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DisconnectToLoginServer()
        {
            LoginClientSocket.Shutdown(SocketShutdown.Both);
            LoginClientSocket.Close();
        }
    }
}
