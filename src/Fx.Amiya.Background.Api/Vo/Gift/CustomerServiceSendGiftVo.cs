using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Gift
{
    public class CustomerServiceSendGiftVo
    {
        public int Id { get; set; }
        /// <summary>
        /// 收件人姓名
        /// </summary>
        public string ReceiveName { get; set; }
        /// <summary>
        /// 收件人手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 收件人地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 礼品数量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 礼品id
        /// </summary>
        public int GiftId { get; set; }
    }
}
