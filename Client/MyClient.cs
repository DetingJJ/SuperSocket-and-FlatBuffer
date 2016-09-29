using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class MyClient : EasyClient
    {
        public void Send(string key, byte[] body)
        {
            int length = body.Length;
            byte[] data = AppendByte(AppendByte(GetBytes(key), BitConverter.GetBytes(length)), body);
            base.Send(data);
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
