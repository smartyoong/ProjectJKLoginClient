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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LoginClient
{
    public partial class LoginClient : Form
    {
        const int BufferSize = 1024;
        bool IsLogOn = false;
        byte[] SocketBuffer = new byte[BufferSize];
        private CancellationTokenSource LoginCancellationTokenSource;
        public LoginInputForm LoginInputDlg = new LoginInputForm();
        private MessageDataProcess PacketProccessor = new MessageDataProcess();
        private string MyNickName = string.Empty;
        public LoginClient()
        {
            InitializeComponent();
            LoginCancellationTokenSource = new CancellationTokenSource();
            PacketProccessor.InitMessageDataProcess(this);
            ConnectToLoginServer();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (!IsLogOn)
            {
                LoginInputDlg.Owner = this;
                LoginInputDlg.ShowDialog();
            }
            else
            {
                LoginMessagePacket Packet = new LoginMessagePacket();
                Packet.StringValue1 = MyNickName;
                Packet.IDNum = LOGIN_CLIENT_PACKET_ID.LOGIN_CLIENT_TRY_LOGOUT;
                byte[] DataByte = SocketDataSerializer.Serialize(Packet);
                SendSocketData(ref DataByte);
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
                Task MessageTask = PacketProccessor.Run();
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
            PacketProccessor.Cancel();
        }
        public int SendSocketData(ref byte[] data)
        {
            return LoginClientSocket.Send(data);
        }
        private void RecvData(CancellationToken Cancled)
        {
            while (!Cancled.IsCancellationRequested)
            {
                try
                {
                    LoginClientSocket.Receive(SocketBuffer);
                    ProcessData(ref SocketBuffer);
                }
                catch (SocketException ex)
                {
                    Console.WriteLine($"SocketException: {ex.Message}");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void ProcessData(ref byte[] ReceivedData)
        {
            PacketProccessor.BufferToMessageQueue(ref ReceivedData);
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectToLoginServer();
        }
        public void LoginSuccess()
        {
            LoginButton.Text = "로그아웃";
            IsLogOn = true;
            MessageBox.Show($"{MyNickName}님 환영합니다!");
        }
        public void SetNickName(string NickName)
        {
            MyNickName = NickName;
        }
        public void LogOutSuccess()
        {
            LoginButton.Text = "로그인";
            IsLogOn = false;
        }
    }
}