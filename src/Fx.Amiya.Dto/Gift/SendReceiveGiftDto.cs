using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Gift
{
    public class SendReceiveGiftDto
    {
        public string CustomerId { get; set; }
        /// <summary>
        /// 订单id
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 收货人电话
        /// </summary>
        public string ReceivePhone { get; set; }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string ReceiveName { get; set; }
        /// <summary>
        /// 礼品id
        /// </summary>
        public int GiftId { get; set; }
        /// <summary>
        /// 地址id
        /// </summary>
        public int? AddressId { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }
    }
}
