using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginClient
{
    public static class MessageDataProcess
    {
        private static BlockingCollection<LoginSendToClientMessagePacket>? LoginMessageQueue = new BlockingCollection<LoginSendToClientMessagePacket>();
        private readonly static CancellationTokenSource CancelProgress = new CancellationTokenSource();

        public static void BufferToMessageQueue(ref byte[] ReceivedData)
        {

            LoginSendToClientMessagePacket Msg;
            Msg = SocketDataSerializer.DeSerialize<LoginSendToClientMessagePacket>(ReceivedData);
            if (Msg != null)
            {
                if (LoginMessageQueue == null) return;
                LoginMessageQueue.Add(Msg);
            }
            else
            {
                MessageBox.Show("Msg is null");
            }
        }
        private static void ProcessMessage()
        {
            if (LoginMessageQueue == null) return;
            try
            {
                while (!LoginMessageQueue.IsCompleted)
                {
                    LoginSendToClientMessagePacket TempPacket = new LoginSendToClientMessagePacket();
                    TempPacket = LoginMessageQueue.Take(CancelProgress.Token);
                    if (TempPacket == null) return;
                    switch (TempPacket.IDNum)
                    {

                        case LOGIN_SERVER_PACKET_ID.LOGIN_SERVER_LOGIN_RESULT :
                            Func_Login_Result(TempPacket);
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static async Task Run()
        {
            await Task.Run(() =>
            {
                while (!CancelProgress.IsCancellationRequested)
                {
                    ProcessMessage();
                }
            });
        }

        public static void Cancel()
        {
            CancelProgress.Cancel();
            LoginMessageQueue?.CompleteAdding();
        }

        private static void Func_Login_Result(LoginSendToClientMessagePacket Packet)
        {
            switch (Packet.IntegerValue1) 
            {
                case 0:
                    MessageBox.Show("일치하는 계정 정보가 없습니다.");
                    break;
                case 1:
                    MessageBox.Show("ID랑 비밀번호가 일치하지 않습니다.");
                    break;
                case 2:
                    MessageBox.Show("로그인 성공");
                    break;
                default :
                    MessageBox.Show("알수 없는 버그");
                    break;

            }
        }

    }
}
