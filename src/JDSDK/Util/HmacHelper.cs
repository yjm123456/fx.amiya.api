using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Jd.Api.Util
{
    public class HmacHelper
    {
        public static string Hmac(string plainText, string appSecret)
        {
            var h = new HMACSHA256(Encoding.UTF8.GetBytes(appSecret));
            var sum = h.ComputeHash(Encoding.UTF8.GetBytes(plainText));

            var sb = new StringBuilder();
            foreach (byte b in sum)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
