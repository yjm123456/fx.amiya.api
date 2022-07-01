using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Gift
{
    public class ReceiveGiftOfWxVo
    {
        /// <summary>
        /// 快递单号
        /// </summary>
        public string CourierNumber { get; set; }
        /// <summary>
        /// 发货状态
        /// </summary>
        public string DeliveryStatus { get; set; }
        /// <summary>
        /// 快递公司id
        /// </summary>
        public string ExpressId { get; set; }

        /// <summary>
        /// 收货人手机号
        /// </summary>
        public string ReceiverPhone { get; set; }
        /// <summary>
        /// 礼品详情
        /// </summary>

        public List<ReceiveGiftInfoSimpleVo> GiftInfos { get; set; }
    }
}
