﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoginClient
{
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

    [Serializable]
    public class ClientConnectGateServerTry
    {
        public string UserName { get; set; } = string.Empty;
    }

    public enum LOGIN_CLIENT_PACKET_ID : uint
    {
        LOGIN_CLIENT_TRY_LOGIN = 0,
        LOGIN_CLIENT_TRY_LOGOUT = 1,
        LOGIN_CLIENT_TRY_REGIST = 2,
        LOGIN_CLIENT_CHECK_ID_UNIQUE = 3,
        LOGIN_CLIENT_GOTO_GATE = 4
    }
    public enum LOGIN_SERVER_PACKET_ID : uint
    {
        LOGIN_SERVER_LOGIN_RESULT = 0,
        LOGIN_SERVER_LOGOUT_RESULT = 1,
        LOGIN_SERVER_REGIST_RESULT = 2,
        LOGIN_SERVER_CHECK_ID_UNIQUE_RESULT = 3,
        LOGIN_SERVER_GOTO_GATE_RESULT = 4
    }
    public enum CLIENT_TO_GATE_PACKET_ID : ushort
    {
        ID_NEW_USER_TRY_CONNECT = 0
    }
}
