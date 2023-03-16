using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order
{
    public class SendGoodsVo
    {
        [Required(ErrorMessage ="交易编号不能为空")]
        public string TradeId { get; set; }
        /// <summary>
        /// 订单id
        /// </summary>

        public string OrderId { get; set; }

        /// <summary>
        /// 快递单号
        /// </summary>
        [Required(ErrorMessage = "快递单号不能为空")]
        public string CourierNumber { get; set; }

        /// <summary>
        /// 物流公司id
        /// </summary>
        [Required(ErrorMessage = "物流公司不能为空")]
        public string ExpressId { get; set; }
    }
}
