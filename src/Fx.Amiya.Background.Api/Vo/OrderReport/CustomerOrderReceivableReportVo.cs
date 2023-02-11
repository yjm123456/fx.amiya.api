using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport
{
    /// <summary>
    /// 客户订单应收款统计
    /// </summary>
    public class CustomerOrderReceivableReportVo
    {

        /// <summary>
        /// 客户昵称
        /// </summary>
        [Description("客户昵称")]
        public string NickName { get; set; }
        /// <summary>
        /// 客户手机
        /// </summary>
        [Description("客户手机")]
        public string EncryptPhone { get; set; }
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
        /// 价格
        /// </summary>
        [Description("订单价格")]
        public decimal? ActuralPayment { get; set; }

        /// <summary>
        /// 应收款
        /// </summary>
        [Description("应收款")]
        public decimal? AccountReceivable { get; set; }
        /// <summary>
        /// 派单价格
        /// </summary>
        [Description("派单价格")]
        public decimal? SendOrderPirce { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        [Description("购买数量")]
        public int? Quantity { get; set; }
        /// <summary>
        /// 订单状态文本
        /// </summary>
        [Description("订单状态")]
        public string StatusText { get; set; }
        /// <summary>
        /// 预约门店
        /// </summary>
        [Description("预约门店")]
        public string AppointmentHospital { get; set; }

        /// <summary>
        /// 派单门店
        /// </summary>
        [Description("派单门店")]
        public string SendOrderHospital { get; set; }
        /// <summary>
        /// 最终消费门店
        /// </summary>
        [Description("最终消费门店")]
        public string FinalConsumptionHospital { get; set; }
        /// <summary>
        /// 派单人员
        /// </summary>
        [Description("派单人员")]
        public string SendHospitalEmployeeName { get; set; }
        /// <summary>
        /// 归属人员
        /// </summary>
        [Description("归属人员")]
        public string BelongEmployeeName { get; set; }

        #region  财务审核板块
        /// <summary>
        /// 审核状态
        /// </summary>

        [Description("审核状态")]
        public string CheckStateText { get; set; }

        /// <summary>
        /// 审核金额
        /// </summary>
        [Description("审核金额")]
        public decimal? CheckPrice { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>
        [Description("结算金额")]
        public decimal? SettlePrice { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        [Description("审核日期")]
        public DateTime? CheckDate { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>

        [Description("审核人")]
        public string CheckBy { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>
        [Description("归属人员")]
        public string CheckRemark { get; set; }
        /// <summary>
        /// 是否开票
        /// </summary>
        [Description("是否开票")]
        public string IsCreateBill { get; set; }

        /// <summary>
        /// 开票公司
        /// </summary>
        [Description("开票公司")]
        public string BelongCompanyName { get; set; }

        /// <summary>
        /// 是否回款
        /// </summary>
        [Description("是否回款")]
        public string IsReturnBackPrice { get; set; }
        /// <summary>
        /// 回款金额
        /// </summary>
        [Description("回款金额")]
        public decimal? ReturnBackPrice { get; set; }

        /// <summary>
        /// 回款日期
        /// </summary>
        [Description("回款日期")]
        public DateTime? ReturnBackDate { get; set; }


        #endregion
    }
}
