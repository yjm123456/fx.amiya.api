using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.GIftCategory
{
    public class SendGiftVo
    {
        public string CustomerId { get; set; }
        /// <summary>
        /// 订单id
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 礼品id
        /// </summary>
        public int GiftId { get; set; }
        /// <summary>
        /// 收货地址id
        /// </summary>
        public int? AddressId { get; set; }
        /// <summary>
        /// 收件人号码
        /// </summary>
        public string ReceivePhone { get; set; }
        /// <summary>
        /// 收件人姓名
        /// </summary>
        public string ReceiveName { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }

    }
}
