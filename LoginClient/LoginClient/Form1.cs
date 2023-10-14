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

    [Serializable]
    public class LoginMessagePacket
    {
        // 변수는 아무렇게나 추가 가능
        public LOGIN_CLIENT_PACKET_ID IDNum { get; set; }
        private byte[] Data = null;
        private int MessageSize = 0;
        public string StringValue1 { get; set; } = null;
        public string StringValue2 { get; set; } = null;
        public int IntegerValue1 { get; set; } = 0;

        public void SerializeData()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, this);
            byte[] bytes = stream.ToArray();

            // 데이터 길이 구하기
            MessageSize = bytes.Length + sizeof(int);

            // 데이터 길이를 바이트 배열로 변환
            byte[] LengthBytes = BitConverter.GetBytes(MessageSize);

            // 헤더와 데이터 합치기
            byte[] header = LengthBytes;
            byte[] packet = new byte[header.Length + bytes.Length];
            Array.Copy(header, packet, header.Length);
            Array.Copy(bytes, 0, packet, header.Length, bytes.Length);
            // 반드시 이게 나중에 들어와야 쓸모없는 값 참조를 안함
            Data = packet;
        }
        public void GetData(ref byte[] data)
        {
            data = Data;
        }
    }
}
