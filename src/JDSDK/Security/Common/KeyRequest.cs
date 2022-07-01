using System;
using System.Text;
using Newtonsoft.Json;
using Jd.ACES.Utils;

namespace Jd.ACES.Common
{
    public class KeyRequest
    {
        [JsonProperty("data")]
        public KeyRequestData Data { get; set; }
        [JsonProperty("sig")]
        public string Sig;

        public KeyRequest() { }

        /// <summary>
        /// Initialize an instance of KeyRequest class for specified token to request key with major SDK version.
        /// <para>The token will sign the key request data.</para>
        /// </summary>
        /// <param name="t">The token to request key.</param>
        /// <param name="major_sdk_ver">The major version of SDK.</param>
        /// <exception cref="InvalidTokenException"/>
        public KeyRequest(Token t, int major_sdk_ver)
        {
            Data = new KeyRequestData(t.GetId(), major_sdk_ver);
            // sign with given token
            Sig = Convert.ToBase64String(t.DoSign(Encoding.Default.GetBytes(JsonHelper.ToJson(Data))));
        }

        /// <summary>
        /// Create a new request data for specified token to request key with major SDK version.
        /// <para>The token will sign the key request data.</para>
        /// </summary>
        /// <param name="t">The token to request key.</param>
        /// <param name="major_sdk_ver">The major version of SDK.</param>
        /// <returns>the string of request data with signature.</returns>
        /// <exception cref="InvalidTokenException"/>
        public static KeyRequest CreateNewKeyRequest(Token t, int major_sdk_ver)
        {
            return new KeyRequest(t, major_sdk_ver);
        }
    }

    public class KeyRequestData
    {
        [JsonProperty("sdk_ver")]
        public int SdkVer { get; set; }   
        [JsonProperty("ts")]
        public long Ts { get; set; }
        [JsonProperty("tid")]
        public string Tid { get; set; }

        public KeyRequestData() { }
        public KeyRequestData(string tid, int major_sdk_ver)
        {
            // basic header construction
            this.SdkVer = major_sdk_ver;
            this.Ts = EnvironmentHelper.GetCurrentMillis();
            this.Tid = tid;
        }
    }
}
