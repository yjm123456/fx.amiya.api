using Fx.Weixin.MP.AdvanceApi.MiniApi;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Tests
{
    [TestFixture]
    public class FxAmiyaMIniTest
    {
        [Test]
        public void 测试用户信息解密()
        {
            string encryptedData = "DIvVmMs2NS5J/z8CBD/pe2mUrDr+F0gFfmaKh3G8mJknAw8EApRla6C1id2kXt2/ulVQTOQLPy80LGPb0ZtaFBxnf+5XjD1/ibZZ1o/TqoSn9XT+JeUe7vfZL0N+0N3GYgxBE3CGAbdgw9uALdB45IxKEmVQ6sUhlyGLO5NY1qp2IT8zEvNa46jtEJ7W/ne0rWzoWNB9un1jFHohBFXtkw==";
            string iv = "IrBuY8hCKv6WIFHSSbeTXA==";
            string sessionKey = "9M+Vryevmz9KIdDBhEYt/g==";
            var decodeUserInfoString = WxMiniBaseApi.DecodeUserInfo(encryptedData, iv, sessionKey);
            Assert.IsNotNull(decodeUserInfoString);
        }
    }
}
