using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.UserInfo
{
    /// <summary>
    /// 解密手机号参数类
    /// </summary>
    public class DecryptWxPhoneNumberVo
    {
        public string EncryptedData { get; set; }
        public string Iv { get; set; }
    }
}
