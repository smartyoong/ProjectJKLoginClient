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
        bool IsLogOn = false;
        byte[] SocketBuffer = new byte[BufferSize];
        private static CancellationTokenSource LoginCancellationTokenSource;
        public LoginInputForm LoginInputDlg = new LoginInputForm();
        public LoginClient()
        {
            InitializeComponent();
            LoginCancellationTokenSource = new CancellationTokenSource();
            MessageDataProcess.InitMessageDataProcess(this);
            ConnectToLoginServer();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if(!IsLogOn) 
            {
                LoginInputDlg.Owner = this;
                LoginInputDlg.ShowDialog();
            }
        }
        private async void ConnectToLoginServer()
        {
            LoginClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress IPAddr = IPAddress.Parse("115.136.46.23");
            IPEndPoint IPEnd = new IPEndPoint(IPAddr, 11220);
            try
            {
                LoginClientSocket.Connect(IPEnd);
                Task MessageTask = MessageDataProcess.Run();
                Task RecvTask = Task.Run(() => RecvData(LoginCancellationTokenSource.Token), LoginCancellationTokenSource.Token);
                await Task.WhenAll(RecvTask, MessageTask);
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                System.Windows.Forms.MessageBox.Show("서버와 연결을 실패했습니다.\n자세한 정보는 공지사항을 확인해주세요", "연결 실패", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }
        }
        private void DisconnectToLoginServer()
        {
            LoginCancellationTokenSource.Cancel();
            LoginClientSocket.Close();
            MessageDataProcess.Cancel();
        }
        public int SendSocketData(ref byte[] data)
        {
            return LoginClientSocket.Send(data);
        }
        private void RecvData(CancellationToken Cancled)
        {
            while (!Cancled.IsCancellationRequested)
            {
                LoginClientSocket.Receive(SocketBuffer);
                ProcessData(ref SocketBuffer);
            }
        }
        private void ProcessData(ref byte[] ReceivedData)
        {
            MessageDataProcess.BufferToMessageQueue(ref ReceivedData);
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectToLoginServer();
        }
        public void LoginSuccess()
        {
            LoginButton.Text = "로그아웃";
            IsLogOn = true;
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
