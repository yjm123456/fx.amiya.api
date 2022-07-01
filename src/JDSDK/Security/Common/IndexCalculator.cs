using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Jd.ACES.Common.Exceptions;

namespace Jd.ACES.Common
{
    public class IndexCalculator
    {
        readonly static string LONG_PLACEHOLDER;

        static IndexCalculator()
        {
            LONG_PLACEHOLDER = GeneratePlaceholderForNonAscii();
        }

        /// <summary>
        /// Computes hash value for the specified input and salt with SHA256 algorithm. 
        /// </summary>
        /// <param name="input">The byte array of input to compute.</param>
        /// <param name="salt">The byte array of salt to compute.</param>
        /// <returns>The byte array of computed hash code.</returns>
        /// <exception cref="ArgumentException">Thrown when input is null.</exception>
        /// <exception cref="InsufficientSaltLengthException">Thrown when salt lenght is too short.</exception>
        public static byte[] Sha256Index(byte[] input, byte[] salt)
        {
            if (input == null)
                throw new ArgumentException("Input is null for sha256Index function.");
            if (salt == null || salt.Length < Constants.MIN_SALT_LEN)
                throw new InsufficientSaltLengthException("Salt length is too short.");
            byte[] combined = new byte[input.Length + salt.Length];
            // append input and salt together
            Array.Copy(input, 0, combined, 0, input.Length);
            Array.Copy(salt, 0, combined, input.Length, salt.Length);

            using (SHA256 hash = SHA256.Create())
            {
                return hash.ComputeHash(combined);
            }
        }

        static string GeneratePlaceholderForNonAscii()
        {
            StringBuilder buffer = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                buffer.Append(WildcardPattern.ASCII);
            }
            return buffer.ToString();
        }

        /// <summary>
        /// Attempts to format the specified plaintext to unicode encoding.
        /// </summary>
        /// <param name="plaintext">The original plaintext to format.</param>
        /// <returns>formatted plaintext if the plaintext contains non-ASCII character.</returns>
        public static string FormatPlaintext(string plaintext)
        {
            return UnicodeEncode(plaintext);
        }

        /// <summary>
        /// Attempts to format the query keyword to unicode encoding.
        /// </summary>
        /// <param name="keyword">The original query keyword to format.</param>
        /// <returns>formatted keyword.</returns>
        public static string FormatQueryKeyword(string keyword)
        {
            return FormatQueryKeyword(keyword, WildcardPattern.NON_ASCII);
        }

        /// <summary>
        /// Attempts to format the query keyword to unicode encoding.
        /// <para>Each placeholder for non-ASCII character, such as '#',
        /// in keyword will be replaced with the long placeholder.</para>
        /// </summary>
        /// <param name="keyword">The original query keyword to format.</param>
        /// <param name="placeholderForNonAscii">The placeholder for non-ASCII character.</param>
        /// <returns>formatted keyword.</returns>
        public static string FormatQueryKeyword(string keyword, char placeholderForNonAscii)
        {
            keyword = UnicodeEncode(keyword);
            if (!keyword.Contains(placeholderForNonAscii))
            {
                return keyword;
            }

            StringBuilder buffer = new StringBuilder();
            for (int i = 0, len = keyword.Length; i < len; i++)
            {
                if (keyword[i] == placeholderForNonAscii)
                {
                    buffer.Append(LONG_PLACEHOLDER);
                }
                else if (keyword[i] == WildcardPattern.ASCII)
                {
                    buffer.Append(keyword[i]);
                }
                else
                {
                    buffer.Append(keyword.Substring(i, keyword.Length - i));
                    break;
                }
            }
            return buffer.ToString();
        }

        /// <summary>
        /// Encodes the specified non-ASCII string to unicode encoding.
        /// </summary>
        /// <param name="data">The string to encode.</param>
        /// <returns>unicode encoding string.</returns>
        public static string UnicodeEncode(string data)
        {
            if (IsPureAscii(data))
                return data;
            char[] utfBytes = data.ToCharArray();
            StringBuilder buffer = new StringBuilder();
            for (int byteIndex = 0, len = utfBytes.Length; byteIndex < len; byteIndex++)
            {
                if (IsPureAscii(utfBytes[byteIndex]))
                {
                    buffer.Append(utfBytes[byteIndex]);
                    continue;
                }

                buffer.Append("\\u").AppendFormat("{0:x2}", (int)utfBytes[byteIndex]);
            }
            return buffer.ToString();
        }

        /// <summary>
        /// Decodes the specified unicode encoding string.
        /// </summary>
        /// <param name="data">The string to decode.</param>
        /// <returns>decoded string.</returns>
        public static string UnicodeDecode(string data)
        {
            StringBuilder buffer = new StringBuilder();

            string charStr = "";
            for (int i = 0, len = data.Length; i < len;)
            {
                int offset = data.IndexOf("\\u", i);
                if (offset == -1 || offset + 6 > data.Length)
                {
                    charStr = data.Substring(i, data.Length - i);
                    buffer.Append(charStr);
                    i = data.Length;
                }
                else
                {
                    buffer.Append(data.Substring(i, offset - i));
                    charStr = data.Substring(offset + 2, 4);
                    string letter = Char.ConvertFromUtf32(Convert.ToInt32(charStr, 16));
                    buffer.Append(letter);
                    i = offset + 6;
                }
            }
            return buffer.ToString();
        }

        public static bool IsPureAscii(char c)
        {
            return c >= 0 && c < 128;
        }

        public static bool IsPureAscii(string s)
        {
            return Encoding.UTF8.GetByteCount(s) == s.Length;
        }

        public static string GenerateWildcardKeyword(string keyword, int asciiCharPrefixNumber, int nonAsciiCharPrefixNumber)
        {
            int length = asciiCharPrefixNumber + nonAsciiCharPrefixNumber * 6;
            if (length == 0)
            {
                return keyword;
            }
            StringBuilder buffer = new StringBuilder();
            char[] prefix = Enumerable.Repeat(WildcardPattern.ASCII, length).ToArray();
            return buffer.Append(prefix).Append(keyword).ToString();
        }
    }
    public class WildcardPattern
    {
        public static char ASCII { get { return '*'; } }
        public static char NON_ASCII { get { return '#'; } }
    }
}
