using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace jos_sdk_net.Util
{
    public class RAS2EncriptUtil
    {
        /// <summary>
        /// RSA私钥，从Java格式转.net格式(不依赖第三方包)
        /// </summary>
        /// <param name="privateKey">私钥</param>
        /// <returns></returns>
        public static string RSAPrivateKeyJava2DotNet(string privateKey)
        {
            var cert = new X509Certificate2("myCertificate.pfx", "myPassword");
            bool hasPrivateKey=cert.HasPrivateKey;
            var s=cert.PrivateKey;           
            RsaPrivateCrtKeyParameters privateKeyParam = (RsaPrivateCrtKeyParameters)PrivateKeyFactory.CreateKey(Convert.FromBase64String(privateKey));
            return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent><P>{2}</P><Q>{3}</Q><DP>{4}</DP><DQ>{5}</DQ><InverseQ>{6}</InverseQ><D>{7}</D></RSAKeyValue>",
              Convert.ToBase64String(privateKeyParam.Modulus.ToByteArrayUnsigned()),
              Convert.ToBase64String(privateKeyParam.PublicExponent.ToByteArrayUnsigned()),
              Convert.ToBase64String(privateKeyParam.P.ToByteArrayUnsigned()),
              Convert.ToBase64String(privateKeyParam.Q.ToByteArrayUnsigned()),
              Convert.ToBase64String(privateKeyParam.DP.ToByteArrayUnsigned()),
              Convert.ToBase64String(privateKeyParam.DQ.ToByteArrayUnsigned()),
              Convert.ToBase64String(privateKeyParam.QInv.ToByteArrayUnsigned()),
              Convert.ToBase64String(privateKeyParam.Exponent.ToByteArrayUnsigned()));
        }
        /// <summary>
        /// 256私钥签名
        /// </summary>
        /// <param name="contentForSign">签名数据</param>
        /// <param name="privateKey">私钥地址</param>
        /// <returns></returns>
        public static string Sign(string contentForSign, string privateKey)
        {
            var netKey = RSAPrivateKeyJava2DotNet(privateKey); //转换成适用于.net的私钥

            //var rsa = FromXmlString(netKey); //.net core2.2及其以下版本使用，重写FromXmlString(string)方法

            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(netKey); //.net core3.0直接使用，不需要重写

            var rsaClear = new RSACryptoServiceProvider();
            var paras = rsa.ExportParameters(true);
            rsaClear.ImportParameters(paras); //签名返回
            using (var sha256 = new SHA256CryptoServiceProvider())
            {
                var signData = rsa.SignData(Encoding.Default.GetBytes(contentForSign), sha256);
                return Convert.ToBase64String(signData);
            }
        }
        /// <summary>
        /// RSA公钥，从Java格式转.net格式(不依赖第三方包)
        /// </summary>
        /// <param name="publikKey"></param>
        /// <returns></returns>
        private static string RSAPublicKeyJava2DotNet(string publicKey)
        {
            RsaKeyParameters publicKeyParam = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(publicKey));
            return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>",
              Convert.ToBase64String(publicKeyParam.Modulus.ToByteArrayUnsigned()),
              Convert.ToBase64String(publicKeyParam.Exponent.ToByteArrayUnsigned()));
        }

        /// <summary>        
        /// RSA签名验证
        /// </summary> 
        /// <param name="encryptSource">签名</param>
        /// <param name="c">验证的字符串</param>
        /// <param name="publicKey">公钥</param>
        /// <returns>是否相同，true验证成功，false验证失败。</returns>
        public static bool VerifySignature(string encryptSource, string compareString, string publicKey)
        {
            try
            {
                //.net core2.2及其以下版本使用，重写FromXmlString(string)方法
                //using (RSACryptoServiceProvider rsa = FromXmlString(RSAPublicKeyJava2DotNet(publicKey)))
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(RSAPublicKeyJava2DotNet(publicKey)); //.net core3.0直接使用，不需要重写
                    byte[] signature = Convert.FromBase64String(encryptSource);
                    SHA256Managed sha256 = new SHA256Managed();
                    RSAPKCS1SignatureDeformatter df = new RSAPKCS1SignatureDeformatter(rsa);
                    df.SetHashAlgorithm("SHA256");
                    byte[] compareByte = sha256.ComputeHash(Encoding.Default.GetBytes(compareString));

                    return df.VerifySignature(compareByte, signature);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
