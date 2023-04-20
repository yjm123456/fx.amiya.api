using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 小程序用户上次登录的appid
    /// </summary>
    public class UserLastTimeLoginAppId:BaseDbModel
    {
        public string UserId { get; set; }
        public string AppId { get; set; }
    }
}
