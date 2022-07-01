using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerInfo
{
    public class CustomerSimpleInfoVo
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }
        public string EncryptPhone { get; set; }

        /// <summary>
        /// 交易完成数量
        /// </summary>
        public int TradeFinishedOrderQuantity { get; set; }

        /// <summary>
        /// 已支付订单数
        /// </summary>
        public int PaymentOrderQuantity { get; set; }
    }
}
