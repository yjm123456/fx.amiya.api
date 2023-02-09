using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order
{
    /// <summary>
    /// 订单导出基础类
    /// </summary>
    public class ExportOrderVo
    {

        /// <summary>
        /// 订单编号
        /// </summary>
        [Description("订单编号")]
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
        /// 商品编号
        /// </summary>
        [Description("商品编号")]
        public string GoodsId { get; set; }

        /// <summary>
        /// 商品
        /// </summary>
        [Description("商品")]
        public string GoodsName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        [Description("规格")]
        public string Standard { get; set; }

        /// <summary>
        /// 实付款
        /// </summary>
        [Description("实付款")]
        public decimal? ActualPayment { get; set; }

        /// <summary>
        /// 实付积分
        /// </summary>
        [Description("实付积分")]
        public decimal? IntegrationQuantity { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        [Description("购买数量")]
        public int? Quantity { get; set; }
        /// <summary>
        /// 订单状态
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
        public string Phone { get; set; }
        /// <summary>
        /// 预约城市
        /// </summary>
        [Description("预约城市")]
        public string AppointmentCity { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        [Description("预约时间")]
        public DateTime? AppointmentDate { get; set; }
        /// <summary>
        /// 预约门店
        /// </summary>
        [Description("预约门店")]
        public string AppointmentHospital { get; set; }
        /// <summary>
        /// 系统派单医院
        /// </summary>
        [Description("系统派单医院")]
        public string SendOrderHospital { get; set; }
        


    }
}
