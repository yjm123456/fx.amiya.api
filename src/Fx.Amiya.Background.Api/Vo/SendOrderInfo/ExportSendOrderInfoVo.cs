using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.SendOrderInfo
{
    public class ExportSendOrderInfoVo
    {

        /// <summary>
        /// 订单号
        /// </summary>
        [Description("订单编号")]
        public string OrderId { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        [Description("预约时间")]
        public string AppointmentDate { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Description("商品")]
        public string GoodsName { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        [Description("简介")]
        public string Description { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [Description("规格")]
        public string Standard { get; set; }
        /// <summary>
        /// 采购单价
        /// </summary>
        [Description("采购价格")]
        public decimal PurchaseSinglePrice { get; set; }
        /// <summary>
        /// 采购数量
        /// </summary>
        [Description("采购数量")]
        public int PurchaseNum { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [Description("电话")]
        public string Phone { get; set; }

        /// <summary>
        /// 派单时间
        /// </summary>
        [Description("派单时间")]
        public DateTime SendDate { get; set; }

    }
}
