﻿using SuperSocket.SocketBase;
using System;
using System.Text;

namespace NetworkEngine
{
    class MySession : AppSession<MySession, MyRequestInfo>
    {
        public void Send(string key, byte[] body)
        {
            int length = body.Length;
            byte[] data = AppendByte(AppendByte(GetBytes(key), BitConverter.GetBytes(length)), body);
            base.Send(new ArraySegment<byte>(data));
        }

        private byte[] GetBytes(string str)
        {
            return Encoding.UTF8.GetBytes(str.ToCharArray());
        }

        private byte[] AppendByte(byte[] current, byte[] after)
        {
            var bytes = new byte[current.Length + after.Length];
            current.CopyTo(bytes, 0);
            after.CopyTo(bytes, current.Length);
            return bytes;
        }
    }
}
