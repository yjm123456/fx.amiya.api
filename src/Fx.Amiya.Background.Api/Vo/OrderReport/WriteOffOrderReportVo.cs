using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport
{
    /// <summary>
    /// 核销订单
    /// </summary>
    public class WriteOffOrderReportVo
    {

        /// <summary>
        /// 订单号
        /// </summary>
        [Description("订单号")]
        public string Id { get; set; }

        /// <summary>
        /// 下单平台
        /// </summary>
        [Description("下单平台")]
        public string AppTypeText { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        [Description("下单时间")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 核销时间
        /// </summary>
        [Description("核销时间")]
        public DateTime? WriteOffDate { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [Description("商品名称")]
        public string GoodsName { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        [Description("购买数量")]
        public int? Quantity { get; set; }
        /// <summary>
        /// 实付款
        /// </summary>
        [Description("实付款")]
        public decimal? ActualPayment { get; set; }
        /// <summary>
        /// 订单状态文本
        /// </summary>
        [Description("订单状态")]
        public string StatusText { get; set; }

        /// <summary>
        /// 客户昵称
        /// </summary>
        [Description("客户昵称")]
        public string NickName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Description("手机号")]
        public string EncryptPhone { get; set; }

        /// <summary>
        /// 预约门店
        /// </summary>
        [Description("预约门店")]
        public string AppointmentHospital { get; set; }
        /// <summary>
        /// 派单门店
        /// </summary>
        [Description("派单门店")]
        public string SendOrderHospital{ get; set; }

    }
}
