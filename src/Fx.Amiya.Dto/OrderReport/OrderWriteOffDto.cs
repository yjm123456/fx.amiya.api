using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OrderReport
{
    /// <summary>
    /// 订单核销情况
    /// </summary>
    public class OrderWriteOffDto
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 平台类型名称
        /// </summary>
        public string AppTypeText { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 核销时间
        /// </summary>
        public DateTime? WriteOffDate { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal? ActualPayment { get; set; }

        /// <summary>
        /// 实付款
        /// </summary>
        public decimal? AccountReceivable { get; set; }

        /// <summary>
        /// 派单价格
        /// </summary>
        public decimal? SendOrderPrice { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int? Quantity { get; set; }
        /// <summary>
        /// 订单状态文本
        /// </summary>
        public string StatusText { get; set; }

        /// <summary>
        /// 客户昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string EncryptPhone { get; set; }

        /// <summary>
        /// 预约门店
        /// </summary>
        public string AppointmentHospital { get; set; }

        /// <summary>
        /// 派单门店
        /// </summary>
        public string SendOrderHospital { get; set; }

        /// <summary>
        /// 最终消费门店
        /// </summary>
        public string FinalConsumptionHospital { get; set; }

        /// <summary>
        /// 派单人员姓名
        /// </summary>
        public string SendEmployeeName { get; set; }
        /// <summary>
        /// 归属人员id
        /// </summary>
        public int BelongEmpId { get; set; }
        /// <summary>
        /// 归属人员
        /// </summary>
        public string BenlongEmpName { get; set; }
        #region  财务审核板块

        public string CheckStateText { get; set; }

        public decimal? CheckPrice { get; set; }
        public DateTime? CheckDate { get; set; }

        public int? CheckBy { get; set; }

        public string CheckByEmpName { get; set; }
        public string CheckRemark { get; set; }
        public decimal? SettlePrice { get; set; }
        public bool IsReturnBackPrice { get; set; }

        public decimal? ReturnBackPrice { get; set; }
        public DateTime? ReturnBackDate { get; set; }


        #endregion
    }
}
