using System;
using System.IO;
using System.Security.Cryptography;

namespace Jd.ACES.Common
{
    public class DataEncryption
    {
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        private byte[] rawKey = null;

        public DataEncryption()
        {
            rawKey = new byte[Constants.DEFAULT_DKEY_LEN];
            rngCsp.GetBytes(rawKey);
        }

        public DataEncryption(byte[] keyBytes)
        {
            if (keyBytes.Length == Constants.DEFAULT_DKEY_LEN)
            {
                rawKey = keyBytes;
            }
            else if (keyBytes.Length > Constants.DEFAULT_DKEY_LEN)
            {
                rawKey = new byte[Constants.DEFAULT_DKEY_LEN];
                Array.Copy(keyBytes, 0, rawKey, 0, Constants.DEFAULT_DKEY_LEN);
            }
            else
            {
                throw new ArgumentException("Key is too short for DataEncryption Object.");
            }
        }

        /// <summary>
        /// Attemps to encrypt a specified plaintext.
        /// </summary>
        /// <param name="pt">The byte array of plaintext to encrypt.</param>
        /// <returns>The encrypted byte array.</returns>
        /// <exception cref="ArgumentNullException"/>
        public byte[] Encrypt(byte[] pt)
        {
            // Check arguments.
            if (pt == null)
                throw new ArgumentNullException("plaintext is null.");

            byte[] iv;
            byte[] ciphertext;

            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.KeySize = Constants.DEFAULT_DKEY_LEN * 8;
                aesAlg.BlockSize = 128;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.Key = rawKey;
                aesAlg.GenerateIV();
                iv = aesAlg.IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(pt, 0, pt.Length);
                        csEncrypt.FlushFinalBlock();
                    }
                    ciphertext = msEncrypt.ToArray();
                }
            }

            var combinedIvCt = new byte[iv.Length + ciphertext.Length];
            Array.Copy(iv, 0, combinedIvCt, 0, iv.Length);
            Array.Copy(ciphertext, 0, combinedIvCt, iv.Length, ciphertext.Length);

            // Return the encrypted bytes from the memory stream.
            return combinedIvCt;
        }

        /// <summary>
        /// Attemps to decrypt a specified ciphertext. 
        /// </summary>
        /// <param name="ct">The byte array of ciphertext to decrypt.</param>
        /// <returns>The decrypted byte array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when ciphertext is null or empty.</exception>
        public byte[] Decrypt(byte[] ct)
        {
            // Check arguments.
            if (ct == null || ct.Length == 0)
                throw new ArgumentNullException("ciphertext is null or empty.");

            // Declare the string used to hold
            // the decrypted text.
            byte[] decipher = null;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                byte[] iv = new byte[aesAlg.BlockSize / 8];
                byte[] cipherText = new byte[ct.Length - iv.Length];

                Array.Copy(ct, iv, iv.Length);
                Array.Copy(ct, iv.Length, cipherText, 0, cipherText.Length);

                aesAlg.Mode = CipherMode.CBC;
                aesAlg.KeySize = Constants.DEFAULT_DKEY_LEN * 8;
                aesAlg.BlockSize = 128;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.Key = rawKey;
                aesAlg.IV = iv;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream())
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                    {
                        csDecrypt.Write(cipherText, 0, cipherText.Length);
                        csDecrypt.Close();
                    }
                    decipher = msDecrypt.ToArray();
                }
            }

            return decipher;
        }

        /// <summary>
        /// Prepares a stream for specified file stream as encryption output.
        /// </summary>
        /// <param name="fout">The file stream.</param>
        /// <returns>A cryptographic data stream used for encryption.</returns>
        /// <exception cref="ArgumentNullException">Thrown when file output is null.</exception>
        public CryptoStream PrepareCipherOut(FileStream fout)
        {
            // Check arguments.
            if (fout == null)
                throw new ArgumentNullException("file output is null.");

            AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider
            {
                Mode = CipherMode.CBC,
                KeySize = Constants.DEFAULT_DKEY_LEN * 8,
                BlockSize = 128,
                Padding = PaddingMode.PKCS7,
                Key = rawKey
            };
            // randomized IV
            aesAlg.GenerateIV();
            // Wrtie IV first
            byte[] iv = aesAlg.IV;
            fout.Write(iv, 0, iv.Length);

            // Create an encryptor to perform the stream transform.
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for encryption
            return new CryptoStream(fout, encryptor, CryptoStreamMode.Write);
        }

        /// <summary>
        /// Prepares a stream for a specified file stream as decryption input.
        /// </summary>
        /// <param name="fout">The file stream to decrypt.</param>
        /// <returns>A cryptographic data stream used for decryption.</returns>
        /// <exception cref="ArgumentNullException">Thrown when file input is null.</exception>
        /// <exception cref="IOException">Thrown when ciphertext has no sufficient length for IV structure.</exception>
        public CryptoStream PrepareCipherIn(FileStream fin)
        {
            // Check arguments.
            if (fin == null)
                throw new ArgumentNullException("file input is null.");
            byte[] iv = new byte[16];
            // read iv first
            if (fin.Read(iv, 0, 16) != 16)
                throw new IOException("ciphertext has no sufficient length for IV structure.");

            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.KeySize = Constants.DEFAULT_DKEY_LEN * 8;
                aesAlg.BlockSize = 128;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.Key = rawKey;
                aesAlg.IV = iv;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                return new CryptoStream(fin, decryptor, CryptoStreamMode.Read);
            }
        }

        public byte[] ExportKey()
        {
            return rawKey;
        }
    }
}
