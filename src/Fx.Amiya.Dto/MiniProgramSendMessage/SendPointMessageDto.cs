using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.MiniProgramSendMessage
{
    public class SendPointMessageDto
    {
        /// <summary>
        /// 小程序用户openid
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 商户名称
        /// </summary>
        public string MerchantName { get; set; }
        /// <summary>
        /// 活动名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 变更数量(如"+100","-100")
        /// </summary>
        public string ChangeCount { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public string ExpireDate { get; set; }
        /// <summary>
        /// 积分余额
        /// </summary>
        public decimal PointBalance { get; set; }
    }
}
