using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Login
{
    public class LoginVo
    {
        public string Code { get; set; }
        public string AppPath { get; set; }
        public int Scene { get; set; }
        /// <summary>
        /// 主小程序appid(啊美雅美容)
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 中转小程序appid
        /// </summary>
        public string AssisteAppId { get; set; }
    }
}
