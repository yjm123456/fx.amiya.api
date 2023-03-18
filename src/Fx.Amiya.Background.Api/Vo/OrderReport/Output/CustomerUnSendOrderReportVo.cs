using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport.OutPut
{
    /// <summary>
    /// 客服未派单报表
    /// </summary>
    public class CustomerUnSendOrderReportVo
    {
        /// <summary>
        /// 客服
        /// </summary>
        [Description("客服")]
        public string BindCustomerServiceName { get; set; }
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
        /// 下单日期
        /// </summary>
        [Description("下单日期")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 预约医院
        /// </summary>
        [Description("预约医院")]
        public string AppointmentHospital { get; set; }
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
        /// 实付款
        /// </summary>
        [Description("实付款")]
        public decimal? ActualPayment { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Description("手机号")]
        public string EncryptPhone { get; set; }
    }
}
