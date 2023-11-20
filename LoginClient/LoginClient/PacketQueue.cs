using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginClient
{
    public class MessageDataProcess
    {
        private BlockingCollection<LoginSendToClientMessagePacket> LoginMessageQueue = new BlockingCollection<LoginSendToClientMessagePacket>();
        private readonly CancellationTokenSource CancelProgress = new CancellationTokenSource();
        private LoginClient MainForm;

        public void InitMessageDataProcess(LoginClient LoginForm)
        {
            MainForm = LoginForm;
        }
        public void BufferToMessageQueue(ref byte[] ReceivedData)
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
        private void ProcessMessage()
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
                        case LOGIN_SERVER_PACKET_ID.LOGIN_SERVER_LOGOUT_RESULT:
                            Func_LogOut_Result(TempPacket);
                            break;
                        case LOGIN_SERVER_PACKET_ID.LOGIN_SERVER_REGIST_RESULT:
                            Func_Regist_Result(TempPacket);
                            break;
                        case LOGIN_SERVER_PACKET_ID.LOGIN_SERVER_CHECK_ID_UNIQUE_RESULT: 
                            Func_Check_ID_Result(TempPacket); 
                            break;
                    }

                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task Run()
        {
            await Task.Run(() =>
            {
                while (!CancelProgress.IsCancellationRequested)
                {
                    ProcessMessage();
                }
            }, CancelProgress.Token);
        }

        public void Cancel()
        {
            CancelProgress.Cancel();
            LoginMessageQueue?.CompleteAdding();
        }

        private void Func_Login_Result(LoginSendToClientMessagePacket Packet)
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
                    MainForm.LoginInputDlg.Close();
                    MainForm.SetNickName(Packet.StringValue1);
                    MainForm.LoginSuccess();
                    break;
                default :
                    MessageBox.Show("알수 없는 버그");
                    break;

            }
        }

        private void Func_LogOut_Result(LoginSendToClientMessagePacket Packet)
        {
            switch (Packet.IntegerValue1)
            {
                case 0:
                    MessageBox.Show("로그아웃 되었습니다.");
                    MainForm.LogOutSuccess();
                    break;
                default:
                    MessageBox.Show("알수 없는 버그");
                    break;
            }
        }

        private void Func_Regist_Result(LoginSendToClientMessagePacket Packet)
        {

        }

        private void Func_Check_ID_Result(LoginSendToClientMessagePacket Packet)
        {
            switch (Packet.IntegerValue1)
            {
                case -1:
                    if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows) && OperatingSystem.IsWindowsVersionAtLeast(10, 0, 19041))
                    {
                        SystemSounds.Beep.Play();
                    }
                    MessageBox.Show("해당 ID는 이미 사용중입니다.", "ID 중복", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 0:
                    if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows) && OperatingSystem.IsWindowsVersionAtLeast(10, 0, 19041))
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    MessageBox.Show("해당 ID 사용 가능", "ID 사용 가능", MessageBoxButtons.OK, MessageBoxIcon.None);
                    if(MainForm.LoginInputDlg.GetRegistAccountForm() != null)
                        MainForm.LoginInputDlg.GetRegistAccountForm().CheckIDOK();
                    break;
                default:
                    MessageBox.Show("알수 없는 버그");
                    break;
            }
        }
    }
}
