using System;
using System.Security.Cryptography;

namespace Jd.ACES.Common
{
    public class KeyDerivation
    {
        /// <summary>
        /// Computes key ID based on service identifier and key version of specified master key.
        /// </summary>
        /// <param name="identifier">The service identifier of specified master key.</param>
        /// <param name="version">The key version of specified master key.</param>
        /// <returns>The base64 encoding string of computed key ID.</returns>
        public static string KeyIDString(string identifier, uint version)
        {
            return Convert.ToBase64String(KeyIDBytes(identifier, version),
                   Base64FormattingOptions.None);
        }

        /// <summary>
        /// Computes key ID based on service identifier and key version of specified master key.
        /// </summary>
        /// <param name="identifier">The service identifier of specified master key.</param>
        /// <param name="version">The key version of specified master key.</param>
        /// <returns>The byte array of computed key ID.</returns>
        public static byte[] KeyIDBytes(string identifier, uint version)
        {
            string id = identifier + ":" + version;
            byte[] keyidArr = null;
            using (MD5 hash = MD5.Create())
            {
                keyidArr = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(id));
            }
            return keyidArr;
        }
    }
}
