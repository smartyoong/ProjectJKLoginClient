using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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
            LoginInputDlg.Owner = this;
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
                this.Close();
            }
        }
        private void DisconnectToLoginServer()
        {
            LoginClientSocket.Shutdown(SocketShutdown.Both);
            LoginClientSocket.Close();
        }
        public int SendSocketData(ref byte[] data)
        {
            return LoginClientSocket.Send(data);
        }
    }

    [Serializable]
    public class LoginMessagePacket
    {
        // 변수는 아무렇게나 추가 가능
        public LOGIN_CLIENT_PACKET_ID IDNum { get; set; }
        public string StringValue1 { get; set; } = null;
        public string StringValue2 { get; set; } = null;
        public int IntegerValue1 { get; set; } = 0;
    }

    public static class SocketDataSerializer
    {
        public static byte[] Serialize<T>(T obj)
        {
            return JsonSerializer.SerializeToUtf8Bytes(obj);
        }

        public static T DeSerialize<T>(byte[] data)
        {
            var ByteData = new Utf8JsonReader(data);
            return JsonSerializer.Deserialize<T>(ref ByteData);
        }
    }
}
