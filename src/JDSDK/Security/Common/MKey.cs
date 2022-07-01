using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Jd.ACES.Utils;
using Jd.ACES.Common.Exceptions;
using static Jd.ACES.Common.Constants;

namespace Jd.ACES.Common
{
    public class MKey
    {
        private string service_identifier;
        private byte[] id;
        private byte[] key;
        private byte[] skey;
        private uint ver;
        private KeyUsage keyUsage;
        private KeyStatus keyStatus;
        private KeyType keyType;
        private long expired;
        // v2.0.x effective date
        private long effective;
        private bool validFlag;
        private string key_digest;
        private const int MEGABYTE = 1024 * 1024;
        private Random r;

        /// <summary>
        /// Constructor of MKey.
        /// </summary>
        /// <exception cref="MalformedException"/>
        /// <exception cref="ArgumentException"/>
        public MKey(string service, byte[] kid, byte[] rawkey, string kdigest, uint kver, long effectiveTs, long expTs, string ktype, string kusage, int kstatus)
        {
            if (kid == null || service == null)
            {
                throw new MalformedException("ID and App fields cannot be null.");
            }
            this.service_identifier = service;
            this.id = kid;
            this.ver = kver;

            if (!EnumHelper.TryParse(kusage, out this.keyUsage))
            {
                throw new MalformedException("unknown key usage.");
            }
            // kstatus: 0->array(keystatus)-1
            if (kstatus >= Enum.GetValues(typeof(KeyStatus)).Length)
            {
                throw new MalformedException("unknown key status.");
            }
            // pass the key status check
            this.keyStatus = (KeyStatus)kstatus;
            if (!EnumHelper.TryParse(ktype, out this.keyType))
            {
                throw new MalformedException("unknown key type.");
            }

            this.validFlag = false;
            if (rawkey != null)
            {
                this.expired = expTs;
                this.effective = effectiveTs;
                if (rawkey.Length == DEFAULT_MSKEY_LEN)
                {
                    this.key = new byte[DEFAULT_MEKEY_LEN];
                    Array.Copy(rawkey, 0, this.key, 0, DEFAULT_MEKEY_LEN);
                    this.skey = rawkey;
                }
                else
                {
                    throw new ArgumentException("Key is too short for MKey Object.");
                }
            }

            // verify key itself by comparing key digest
            this.key_digest = kdigest;
            byte[] digest = Convert.FromBase64String(this.key_digest);
            using (SHA256 hash = SHA256.Create())
            {
                // has to compute over the whole key
                byte[] cdigest = hash.ComputeHash(rawkey);
                if (digest.SequenceEqual(cdigest))
                {
                    this.validFlag = true;
                }
            }

            r = new Random(Environment.TickCount);
        }

        public bool IsValid() { return validFlag; }

        public string GetName() { return service_identifier; }

        public uint GetVersion() { return ver; }

        public byte[] GetID() { return id; }

        public long GetExpiredTime() { return expired; }

        public long GetEffectiveTime() { return effective; }

        public KeyType GetKeyType() { return keyType; }

        public KeyStatus GetKeyStatus() { return keyStatus; }

        public KeyUsage GetKeyUsage() { return keyUsage; }

        public byte[] GetRawKey() { return key; }

        /// <summary>
        /// Attemps to encrypt specified plaintext with weak version.
        /// </summary>
        /// <param name="pt">The byte array of plaintext to encrypt.</param>
        /// <returns>The byte array of encrypted data.</returns>
        /// <exception cref="ArgumentNullException"/>
        public byte[] Encrypt(byte[] pt)
        {
            byte[] ct = null;
            // use default dkey constructor
            byte[] dataCipher = KeyEncryption.Encrypt(this, pt);
            // construct the header
            using (MemoryStream buf = new MemoryStream())
            {
                buf.WriteByte((byte)CipherType.WEAK);
                buf.WriteByte((byte)AlgoType.AES_CBC_128);
                buf.Write(id, 0, id.Length);
                buf.Write(dataCipher, 0, dataCipher.Length);
                ct = buf.ToArray();
                buf.Close();
            };
            return ct;
        }

        /// <summary>
        /// Attemps to decrypt specified ciphertext with weak version.
        /// </summary>
        /// <param name="ct">The byte array of ciphertext to decrypt.</param>
        /// <returns>The byte array of decrypted data.</returns>
        /// <exception cref="MalformedException"/>
        /// <exception cref="ArgumentNullException"/>
        public byte[] Decrypt(byte[] ct)
        {
            byte[] pt = null;
            using (MemoryStream buf = new MemoryStream(ct))
            {
                byte ctype = (byte)buf.ReadByte();
                if (ctype != (byte)CipherType.WEAK)
                    throw new MalformedException($"Invalid CipherText Type:{ctype}");
                byte atype = (byte)buf.ReadByte();
                if (atype != (byte)AlgoType.AES_CBC_128)
                    throw new MalformedException($"Invalid Encryption Algorithm Type:{atype}");
                byte[] keyid = new byte[DEFAULT_KEYID_LEN];
                buf.Read(keyid, 0, DEFAULT_KEYID_LEN);
                if (!keyid.SequenceEqual(this.id))
                {
                    // error, wrong key id
                    throw new MalformedException("Invalid MKey ID:" + BitConverterHelper.ToString(keyid));
                }
                byte[] cipher = new byte[ct.Length - buf.Position];
                buf.Read(cipher, 0, cipher.Length);
                pt = KeyEncryption.Decrypt(this, cipher);
                buf.Close();
            }
            return pt;
        }

        /// <summary>
        /// Attemps to sign specified input.
        /// </summary>
        /// <param name="input">The array byte of input to sign.</param>
        /// <returns>The base64 encoding string of signature.</returns>
        /// <exception cref="MalformedException"/>
        public string Sign(byte[] input)
        {
            if (input == null)
            {
                throw new MalformedException("Illegal input.");
            }

            if (this.id == null || this.id.Length != DEFAULT_KEYID_LEN)
            {
                throw new MalformedException("Illegal Signing Key.");
            }

            byte[] random = new byte[DEFAULT_SEED_LEN];
            r.NextBytes(random);
            byte[] sig = DoSign(input, random);

            string base64Sig = null;
            using (MemoryStream m = new MemoryStream(DEFAULT_KEYID_LEN +
                DEFAULT_SEED_LEN + sig.Length))
            {
                m.Write(id, 0, DEFAULT_KEYID_LEN);
                m.Write(random, 0, DEFAULT_SEED_LEN);
                m.Write(sig, 0, sig.Length);
                base64Sig = Convert.ToBase64String(m.ToArray(), Base64FormattingOptions.None);
            }
            return base64Sig;
        }

        /// <summary>
        /// Attemps to verify the signature with specified input.
        /// </summary>
        /// <param name="input">The byte array of input.</param>
        /// <param name="sig">The base64 encoding string of signature to verify.</param>
        /// <returns>True if verify successfully; otherwise, false.</returns>
        /// <exception cref="MalformedException"/>
        public bool Verify(byte[] input, string sig)
        {
            return Verify(input, Convert.FromBase64String(sig));
        }

        /// <summary>
        /// Attemps to verify the signature with specified input.
        /// </summary>
        /// <param name="input">The byte array of input.</param>
        /// <param name="sig">The byte array of signature to verify.</param>
        /// <returns>True if verify successfully; otherwise, false.</returns>
        /// <exception cref="MalformedException"/>
        private bool Verify(byte[] input, byte[] sig)
        {
            if (input == null)
            {
                throw new MalformedException("Illegal input.");
            }
            if (sig == null || sig.Length <= DEFAULT_KEYID_LEN + DEFAULT_SEED_LEN)
            {
                throw new MalformedException("Illegal Signature.");
            }

            bool ret = false;
            using (MemoryStream buf = new MemoryStream(sig))
            {
                byte[] keyID = new byte[DEFAULT_KEYID_LEN];
                buf.Read(keyID, 0, DEFAULT_KEYID_LEN);
                // check keyid
                if (!keyID.SequenceEqual(this.id))
                    throw new MalformedException("Corrupted ciphertext header with illegal key id.");

                byte[] random = new byte[DEFAULT_SEED_LEN];
                buf.Read(random, 0, DEFAULT_SEED_LEN);
                byte[] sigCarried = new byte[sig.Length - DEFAULT_SEED_LEN - DEFAULT_KEYID_LEN];
                buf.Read(sigCarried, 0, sigCarried.Length);
                byte[] computed = DoSign(input, random);
                ret = computed.SequenceEqual(sigCarried);
            }
            return ret;
        }

        /// <summary>
        /// Attemps to sign specified input and random data.
        /// </summary>
        /// <param name="input">The array byte of input to sign.</param>
        /// <param name="random">The array byte of random data to sign.</param>
        /// <returns>The array byte of signature.</returns>
        private byte[] DoSign(byte[] input, byte[] random)
        {
            byte[] dataToSign = new byte[random.Length + input.Length];
            Array.Copy(input, 0, dataToSign, 0, input.Length);
            Array.Copy(random, 0, dataToSign, input.Length, random.Length);

            byte[] sig = null;
            using (HMACSHA256 hmac = new HMACSHA256(this.skey))
            {
                sig = hmac.ComputeHash(dataToSign);
            }
            return sig;
        }

        /// <summary>
        /// Attemps to encrypt a specified file and output into another specified file.
        /// </summary>
        /// <param name="fin">The input file stream to read plaintext.</param>
        /// <param name="fout">The output file stream to write ciphertext.</param>
        /// <param name="filesize">The size of input file.</param>
        /// <returns>The size of encrypted data.</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="Exception"/>
        public long Encrypt(FileStream fin, FileStream fout, long filesize)
        {
            DataEncryption de = new DataEncryption();
            byte[] keyCipher = KeyEncryption.Wrap(this, de.ExportKey());
            long mod16 = filesize % 16;
            // + iv length
            long cipherlen = filesize + 16 + (mod16 == 0 ? 16 : 16 - mod16);

            byte[] header = null;
            // header calculation
            using (MemoryStream headerS = new MemoryStream())
            {
                headerS.WriteByte((byte)CipherType.LARGE);
                byte[] idlen = BitConverterHelper.GetBytes((ushort)id.Length);
                headerS.Write(idlen, 0, idlen.Length);
                headerS.Write(id, 0, id.Length);

                headerS.WriteByte((byte)AlgoType.AES_CBC_128);
                byte[] keylen = BitConverterHelper.GetBytes((ushort)keyCipher.Length);
                headerS.Write(keylen, 0, keylen.Length);
                headerS.Write(keyCipher, 0, keyCipher.Length);

                headerS.WriteByte((byte)AlgoType.AES_CBC_128);
                byte[] clen = BitConverterHelper.GetBytes(cipherlen);
                headerS.Write(clen, 0, clen.Length);

                header = headerS.ToArray();
            }

            CryptoStream encryptor = null;
            try
            {
                // seek to the original 
                fout.Write(header, 0, header.Length);

                // write continuous cipher
                encryptor = de.PrepareCipherOut(fout);
                // iterative encrypt block with CipherOutputStream
                byte[] chunk = new byte[MEGABYTE];
                int read;
                while ((read = fin.Read(chunk, 0, MEGABYTE)) > 0)
                {
                    encryptor.Write(chunk, 0, read);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"File encryption error occurred: {e.Message}");
            }
            finally
            {
                encryptor.Flush();
                encryptor.Close();
                fin.Close();
                fout.Close();
            }

            return (long)cipherlen + header.Length;
        }

        /// <summary>
        /// Attemps to decrypt a specified file and output into another specified file.
        /// </summary>
        /// <param name="fin">The input file stream to read ciphertext.</param>
        /// <param name="fout">The output file stream to write plaintext.</param>
        /// <param name="filesize">The size of input file.</param>
        /// <returns>The size of decrypted data.</returns>
        /// <exception cref="MalformedException"/>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        public long Decrypt(FileStream fin, FileStream fout, long filesize)
        {
            // parsing header, fix 16 for aes block size
            int hdlen = 1 * 3 + 2 * 2 + 8 + id.Length + 16;

            byte[] header = new byte[hdlen];
            if (fin.Read(header, 0, hdlen) != hdlen)
                throw new MalformedException("ciphertext has no sufficient length for header structure.");

            byte[] dkey = null;
            ulong dcipherLen = 0L;
            long plainLen = 0L;
            CryptoStream cis = null;
            // paring header
            using (MemoryStream buf = new MemoryStream(header))
            {
                byte ctype = (byte)buf.ReadByte();
                if (ctype != (byte)CipherType.LARGE)
                    throw new MalformedException("Invalid CipherText Type.");
                // id len
                byte[] len = new byte[2];
                buf.Read(len, 0, 2);
                ushort id_len = BitConverterHelper.ToUInt16(len, 0);
                if (id_len != DEFAULT_KEYID_LEN)
                    throw new MalformedException("Corrupted ciphertext header with illegal key id length.");
                byte[] keyid = new byte[DEFAULT_KEYID_LEN];
                buf.Read(keyid, 0, DEFAULT_KEYID_LEN);
                if (!keyid.SequenceEqual(this.id))
                {
                    // error, wrong key id
                    throw new MalformedException("Invalid MKey ID:" + BitConverterHelper.ToString(keyid));
                }

                byte atype = (byte)buf.ReadByte();
                if (atype != (byte)AlgoType.AES_CBC_128)
                    throw new MalformedException($"Invalid Encryption Algorithm Type:{atype}");

                buf.Read(len, 0, 2);
                ushort key_len = BitConverterHelper.ToUInt16(len, 0);
                if (key_len < DEFAULT_CIPHERBLK_LEN || key_len > (buf.Capacity - buf.Position))
                    throw new MalformedException($"Corrupted ciphertext with invalid key cipher length:{key_len}");
                byte[] keyCipher = new byte[key_len];
                buf.Read(keyCipher, 0, keyCipher.Length);
                // decrypt the key
                dkey = KeyEncryption.Unwrap(this, keyCipher);
                atype = (byte)buf.ReadByte();
                if (atype != (byte)AlgoType.AES_CBC_128)
                    throw new MalformedException($"Invalid Encryption Algorithm Type:{atype}");
                // cipher len
                len = new byte[8];
                buf.Read(len, 0, 8);
                dcipherLen = BitConverterHelper.ToUInt64(len, 0);
            }

            try
            {
                cis = new DataEncryption(dkey).PrepareCipherIn(fin);
                if (dcipherLen != (ulong)(filesize - header.Length))
                {
                    throw new MalformedException("Corrupted encrypted file: illegal data cipher length.");
                }

                // iterative encrypt block with CipherOutputStream
                byte[] chunk = new byte[MEGABYTE];
                int read;
                while ((read = cis.Read(chunk, 0, MEGABYTE)) > 0)
                {
                    plainLen += read;
                    fout.Write(chunk, 0, read);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"File decryption error occurred: {e.Message}");
            }
            finally
            {
                cis.Close();
                fout.Flush();
                fout.Close();
            }
            return plainLen;
        }

        /// <summary>
        /// Computes the minimum header based on specified key identifier for tracing master key.
        /// </summary>
        /// <param name="keyID">The byte array of key identifier.</param>
        /// <returns>The base64 encoding string of computed header.</returns>
        public static string GenerateMinHeaderByKeyID(byte[] keyID)
        {
            byte[] header = new byte[2 + keyID.Length];
            header[0] = 0;
            header[1] = 0;
            Array.Copy(keyID, 0, header, 2, keyID.Length);
            return Convert.ToBase64String(header);
        }
    }// end of MKey

    public class MKData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("key_string")]
        public string KeyString { get; set; }
        [JsonProperty("key_type")]
        public string KeyType { get; set; }
        [JsonProperty("key_exp")]
        public long KeyExp { get; set; }
        [JsonProperty("key_effective")]
        public long KeyEffective { get; set; }
        [JsonProperty("version")]
        public uint Version { get; set; }
        [JsonProperty("key_status")]
        public int KeyStatus { get; set; }
        [JsonProperty("key_digest")]
        public string KeyDigest { get; set; }
    }// end of MKeyData
}
