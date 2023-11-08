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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LoginClient
{
    public partial class LoginClient : Form
    {
        const int BufferSize = 1024;
        byte[] SocketBuffer = new byte[BufferSize];
        private static CancellationTokenSource LoginCancellationTokenSource;
        public LoginClient()
        {
            InitializeComponent();
            ConnectToLoginServer();
            LoginCancellationTokenSource = new CancellationTokenSource();
            MessageDataProcess.Run();
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
                Task.Run(() => RecvData(LoginCancellationTokenSource.Token));
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
        private void DisconnectToLoginServer()
        {
            LoginCancellationTokenSource.Cancel();
            LoginClientSocket.Shutdown(SocketShutdown.Both);
            LoginClientSocket.Close();
            MessageDataProcess.Cancel();
        }
        public int SendSocketData(ref byte[] data)
        {
            return LoginClientSocket.Send(data);
        }
        private void RecvData(CancellationToken Cancled)
        {
            while(!Cancled.IsCancellationRequested) 
            {
                LoginClientSocket.Receive(SocketBuffer);
                ProcessData(ref SocketBuffer);
            }
        }
        private void ProcessData(ref byte[] ReceivedData)
        {
            MessageDataProcess.BufferToMessageQueue(ref ReceivedData);
        }
    }

    [Serializable]
    public class LoginMessagePacket
    {
        // 변수는 아무렇게나 추가 가능
        public Socket ResponeSocket { get; set; }
        public LOGIN_CLIENT_PACKET_ID IDNum { get; set; }
        public string StringValue1 { get; set; } = null;
        public string StringValue2 { get; set; } = null;
        public int IntegerValue1 { get; set; } = 0;
    }

    [Serializable]
    public class LoginSendToClientMessagePacket
    {
        // 변수는 아무렇게나 추가 가능
        public LOGIN_SERVER_PACKET_ID IDNum { get; set; }
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
