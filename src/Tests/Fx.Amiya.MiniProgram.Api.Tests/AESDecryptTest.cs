using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Fx.Amiya.MiniProgram.Api.Tests
{
    [TestFixture]
    public class AESDecryptTest
    {
        [Test]
        public void AESDecrypt()
        {
            try
            {
                string encrypted = "AAS2QGu5EUYo35u+GIPUbcPQrI8MbLvXIHaYS47i8I6De0Fzgdpyw7TT9Iti3RiIY30=";
                string key = "/xdYPxcavDO9IpsJP1uFfbbuv7WdIyckhJ9RBe3h9r8=";
                string iv = "ac8f0c6cbbd72076984b8ee2f08e837b";
                string res = AESDecrypt(encrypted, iv, key);
        

                Assert.AreEqual(res, "123");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private string AESDecrypt(string encrypted,string iv,string key)
        {

            byte[] encryptedData = Encoding.UTF8.GetBytes(encrypted);
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Key = Convert.FromBase64String(key); // Encoding.UTF8.GetBytes(key);
            rijndaelCipher.IV = Encoding.UTF8.GetBytes(iv);// Encoding.UTF8.GetBytes(iv);
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            ICryptoTransform transform = rijndaelCipher.CreateDecryptor();

            byte[] plainText = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            string result = Encoding.Default.GetString(plainText);
            return result;
        }


    }
}
