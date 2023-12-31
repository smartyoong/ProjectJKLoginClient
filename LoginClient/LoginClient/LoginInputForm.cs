﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LoginClient
{
    public partial class LoginInputForm : Form
    {
        private System.Windows.Forms.ToolTip CapsLockToolTip = new System.Windows.Forms.ToolTip();
        private RegistAccountForm RegistAccountDlg = new RegistAccountForm();
        public LoginInputForm()
        {
            InitializeComponent();
            PWTextBox.PasswordChar = '*';
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string IDString = IDTextBox.Text;
            string PWString = PWTextBox.Text;
            LoginClient MainForm = (LoginClient)this.Owner;
            if (MainForm == null)
                return;

            if (!string.IsNullOrEmpty(IDString) && !string.IsNullOrEmpty(PWString))
            {
                if (!CheckPasswordValid(PWString))
                    return;
                LoginMessagePacket Packet = new LoginMessagePacket();
                Packet.StringValue1 = IDString;
                Packet.StringValue2 = PWString;
                Packet.IDNum = LOGIN_CLIENT_PACKET_ID.LOGIN_CLIENT_TRY_LOGIN;
                byte[] DataByte = SocketDataSerializer.Serialize(Packet);
                if (MainForm != null)
                {
                    MainForm.SendSocketData(ref DataByte);
                }
            }
        }
        private bool CheckPasswordValid(string PW)
        {
            string Pattern = "^[a-zA-Z0-9!@#$%]{8,16}$";
            if (!Regex.IsMatch(PW, Pattern))
            {
                MessageBox.Show("비밀 번호 형식이 유효하지 않습니다.");
                return false;
            }
            return true;
        }

        private void PWTextBox_Enter(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                CapsLockToolTip.Show("캡스락이 켜져있습니다.", PWTextBox, 0, PWTextBox.Height, 2000);
            }
        }

        private void PWTextBox_Leave(object sender, EventArgs e)
        {
            CapsLockToolTip.Hide(PWTextBox);
        }

        private void RegistAccountClick(object sender, EventArgs e)
        {
            Visible = false;
            RegistAccountDlg.ShowDialog(this);
        }
        public RegistAccountForm GetRegistAccountForm()
        {
            return RegistAccountDlg;
        }

        private void LoginInputFormClose(object sender, FormClosedEventArgs e)
        {
            IDTextBox.Text = string.Empty;
            PWTextBox.Text = string.Empty;
        }
    }
}
