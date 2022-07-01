using System;

namespace Jd.ACES.Utils
{
    public class BitConverterHelper
    {
        public static string ToHexString(byte[] value)
        {
            return BitConverter.ToString(value).Replace("-", string.Empty);
        }

        public static string ToString(byte[] value)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(value);
            return BitConverter.ToString(value);
        }

        public static ushort ToUInt16(byte[] value, int startIndex)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(value);
            return BitConverter.ToUInt16(value, startIndex);
        }

        public static int ToInt32(byte[] value, int startIndex)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(value);
            return BitConverter.ToInt32(value, startIndex);
        }

        public static ulong ToUInt64(byte[] value, int startIndex)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(value);
            return BitConverter.ToUInt64(value, startIndex);
        }

        public static byte[] GetBytes(ushort value)
        {
            byte[] res = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(res);
            return res;
        }

        public static byte[] GetBytes(uint value)
        {
            byte[] res = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(res);
            return res;
        }

        public static byte[] GetBytes(long value)
        {
            byte[] res = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(res);
            return res;
        }
    }
}
