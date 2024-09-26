using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.ShoppingCartRegistration
{
    /// <summary>
    /// 小黄车指派输入类
    /// </summary>
    public class AssignVo
    {
        /// <summary>
        /// 小黄车编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 指派人
        /// </summary>
        public int AssignBy { get; set; }
    }
}
