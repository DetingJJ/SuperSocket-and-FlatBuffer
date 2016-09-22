using SuperSocket.Common;
using SuperSocket.Facility.Protocol;
using System;
using System.Text;

namespace NetworkEngine
{
    class MyReceiveFilter : FixedHeaderReceiveFilter<MyRequestInfo>
    {
        public MyReceiveFilter() : base(6)
        {
        }

        protected override int GetBodyLengthFromHeader(byte[] header, int offset, int length)
        {
            return BitConverter.ToInt32(header, offset + 2);
        }

        protected override MyRequestInfo ResolveRequestInfo(ArraySegment<byte> header, byte[] bodyBuffer, int offset, int length)
        {
            return new MyRequestInfo(Encoding.UTF8.GetString(header.Array, header.Offset, 2), bodyBuffer.CloneRange(offset, length));
        }
    }
}
