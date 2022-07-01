using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Gift
{
    /// <summary>
    /// 核销好礼快递信息查询输入类
    /// </summary>
    public class GetGiftExpressInfoVo
    {
        /// <summary>
        /// 快递单号
        /// </summary>
        public string CourierNumber { get; set; }
        /// <summary>
        /// 收货人手机号
        /// </summary>
        public string ReceiverPhone { get; set; } 
        /// <summary>
        /// 物流公司id
        /// </summary>
        public string ExpressId { get; set; }
    }
}
