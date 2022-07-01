using System;
using System.IO;
using System.Security.Cryptography;

namespace Jd.ACES.Common
{
    public class KeyEncryption
    {
        private const int IV_SIZE = 16;
        private const int RANDOM_SIZE = 16;
        private static readonly byte[] zeroIV = new byte[16];

        /// <summary>
        /// Attemps to encrypt a plaintext with specifed master key.
        /// </summary>
        /// <param name="k">The specified master key for encryption.</param>
        /// <param name="pt">The byte array of plaintext to encrypt.</param>
        /// <returns>The byte array of encrypted data.</returns>
        /// <exception cref="ArgumentNullException"/>
        public static byte[] Encrypt(MKey k, byte[] pt)
        {
            // Check arguments.
            if (pt == null)
                throw new ArgumentNullException("plaintext is null.");

            if (k == null)
                throw new ArgumentNullException("MKey is null.");

            byte[] ciphertext = null;
            byte[] iv = null;
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.KeySize = Constants.DEFAULT_DKEY_LEN * 8;
                aesAlg.BlockSize = 128;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.Key = k.GetRawKey();
                aesAlg.GenerateIV();
                // however we only use 4 bytes in weak standard
                iv = aesAlg.IV;
                Array.Clear(iv, RANDOM_SIZE, iv.Length - RANDOM_SIZE);
                aesAlg.IV = iv;

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

            var combinedIvCt = new byte[RANDOM_SIZE + ciphertext.Length];
            Array.Copy(iv, 0, combinedIvCt, 0, RANDOM_SIZE);
            Array.Copy(ciphertext, 0, combinedIvCt, RANDOM_SIZE, ciphertext.Length);

            // Return the encrypted bytes from the memory stream.
            return combinedIvCt;
        }

        /// <summary>
        /// Attemps to decrypt a ciphertext with specifed master key.
        /// </summary>
        /// <param name="k">The specified master key for decryption.</param>
        /// <param name="ct">The byte array of ciphertext to decrypt.</param>
        /// <returns>The byte array of decrypted data.</returns>
        /// <exception cref="ArgumentNullException"/>
        public static byte[] Decrypt(MKey k, byte[] ct)
        {
            // Check arguments.
            if (ct == null || ct.Length == 0)
                throw new ArgumentNullException("ciphertext is null or empty.");
            if (k == null)
                throw new ArgumentNullException("MKey is null.");

            // Declare the string used to hold
            // the decrypted text.
            byte[] decipher = null;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.KeySize = Constants.DEFAULT_DKEY_LEN * 8;
                aesAlg.BlockSize = 128;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.Key = k.GetRawKey();

                byte[] iv = new byte[aesAlg.BlockSize/8];
                byte[] cipherText = new byte[ct.Length - RANDOM_SIZE];

                Array.Copy(ct, iv, RANDOM_SIZE);
                Array.Copy(ct, RANDOM_SIZE, cipherText, 0, cipherText.Length);

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
        /// Attemps to wrap a data key with specified master key.
        /// </summary>
        /// <param name="k">The specified master key for encryption.</param>
        /// <param name="dkey">The byte array of data key to wrap.</param>
        /// <returns>The byte array of wrapped data key.</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        public static byte[] Wrap(MKey k, byte[] dkey)
        {
            if (dkey == null || dkey.Length == 0)
                throw new ArgumentNullException("DKey is null or empty.");

            if (dkey.Length%Constants.DEFAULT_DKEY_LEN!=0)
                throw new ArgumentException($"Dkey size should be multiple of {Constants.DEFAULT_DKEY_LEN}.");

            if (k == null)
                throw new ArgumentNullException("MKey is null.");

            byte[] keyCipher = null;
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.KeySize = Constants.DEFAULT_DKEY_LEN * 8;
                aesAlg.BlockSize = 128;
                aesAlg.Padding = PaddingMode.None;
                aesAlg.Key = k.GetRawKey();
                aesAlg.IV = zeroIV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(dkey, 0, dkey.Length);
                        csEncrypt.FlushFinalBlock();
                    }
                    keyCipher = msEncrypt.ToArray();
                }
            }

            // Return the encrypted bytes from the memory stream.
            return keyCipher;
        }

        /// <summary>
        /// Attemps to unwrap an encrypted data key with specified master key.
        /// </summary>
        /// <param name="k">The specified master key for decryption.</param>
        /// <param name="ct">The byte array of wrapped data key.</param>
        /// <returns>The byte array of unwrapped data key.</returns>
        /// <exception cref="ArgumentNullException"/>
        public static byte[] Unwrap(MKey k, byte[] ct)
        {
            if (ct == null || ct.Length == 0)
                throw new ArgumentNullException("key cpher is null or empty.");

            if (k == null)
                throw new ArgumentNullException("MKey is null.");

            // Declare the string used to hold
            // the decrypted text.
            byte[] dkey = null;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.KeySize = Constants.DEFAULT_DKEY_LEN * 8;
                aesAlg.BlockSize = 128;
                aesAlg.Padding = PaddingMode.None;
                aesAlg.Key = k.GetRawKey();
                aesAlg.IV = zeroIV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream())
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                    {
                        csDecrypt.Write(ct, 0, ct.Length);
                        csDecrypt.Close();
                    }
                    dkey = msDecrypt.ToArray();
                }
            }

            return dkey;
        }
    }
}
