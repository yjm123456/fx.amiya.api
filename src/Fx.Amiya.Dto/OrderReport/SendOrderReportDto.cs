using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OrderReport
{
    /// <summary>
    /// 派单报表
    /// </summary>
    public class SendOrderReportDto
    {

        /// <summary>
        /// 订单号
        /// </summary>
        [Description("订单号")]
        public string OrderId { get; set; }
        /// <summary>
        /// 下单平台
        /// </summary>
        [Description("下单平台")]
        public string AppTypeText { get; set; }
        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 派单医院名称
        /// </summary>
        [Description("派单医院名称")]
        public string HospitalName { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime? AppointmentDate { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        [Description("预约时间")]
        public string Time { get; set; }
        /// <summary>
        /// 商品
        /// </summary>
        [Description("商品")]
        public string GoodsName { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        [Description("订单状态")]
        public string StatusText { get; set; }
        /// <summary>
        /// 采购单价
        /// </summary>
        [Description("采购单价")]
        public decimal? PurchaseSinglePrice { get; set; }
        /// <summary>
        /// 采购数量
        /// </summary>
        [Description("采购数量")]
        public int PurchaseNum { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 部位
        /// </summary>
        public string Standard { get; set; }
        /// <summary>
        /// 采购总价
        /// </summary>
        [Description("采购总价")]
        public decimal? PurchasePrice { get; set; }
        /// <summary>
        /// 实付款
        /// </summary>
        [Description("实付款")]
        public decimal? ActualPayment { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [Description("电话")]
        public string EncryptPhone { get; set; }
        /// <summary>
        /// 派单人姓名
        /// </summary>
        [Description("派单人姓名")]
        public string SendName { get; set; }
        /// <summary>
        /// 派单日期
        /// </summary>
        [Description("派单日期")]
        public DateTime SendDate { get; set; }

        public int BelongEmpId { get; set; }
        /// <summary>
        /// 归属客服
        /// </summary>
        public string BelongEmpName { get; set; }
    }
}
