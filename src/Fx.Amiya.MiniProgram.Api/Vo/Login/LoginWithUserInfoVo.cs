using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Login
{
    public class LoginWithUserInfoVo
    {
        public string AppPath { get; set; }
        public int Scene { get; set; }
        public string Code { get; set; }
        public string Iv { get; set; }
        public string EncryptedData { get; set; }

        public string AppId { get; set; }
    }
}
