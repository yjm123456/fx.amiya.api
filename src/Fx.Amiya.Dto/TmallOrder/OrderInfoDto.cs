using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.TmallOrder
{
   public class OrderInfoDto
    {
        public string Id { get; set; }

        public string UserId { get; set; }
        public string GoodsName { get; set; }
        public string GoodsId { get; set; }
        public string GoodsCategory{ get; set; }
        public string ThumbPicUrl { get; set; }
        public string BuyerNick { get; set; }
        public string Phone { get; set; }
        public string EncryptPhone { get; set; }
        public string AppointmentCity { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string AppointmentHospital { get; set; }
        public int SendOrderHospitalId { get; set; }
        public string SendOrderHospital { get; set; }
        public string FinalConsumptionHospital { get; set; }
        /// <summary>
        /// 产品价格单价
        /// </summary>
        public decimal? SinglePrice { get; set; }
        public bool IsAppointment { get; set; }
        public string StatusCode { get; set; }
        public string StatusText { get; set; }
        public decimal? ActualPayment { get; set; }
        /// <summary>
        /// 应收款（优惠后实际价格，财务用）
        /// </summary>
        public decimal? AccountReceivable { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? WriteOffDate { get; set; }
        public byte AppType { get; set; }
        public string AppTypeText { get; set; }
        public byte? OrderType { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Description { get; set; }
        public string OrderTypeText { get; set; }

        public byte? OrderNature { get; set; }
        public string OrderNatureText { get; set; }

        public int? Quantity { get; set; }
        public decimal? IntegrationQuantity { get; set; }
        public decimal? SingleQuantity { get; set; }
        /// <summary>
        /// 0积分支付,1三方支付,2线下支付,3余额支付
        /// </summary>
        public byte? ExchangeType { get; set; }
        public string ExchangeTypeText { get; set; }
        /// <summary>
        /// 核销码
        /// </summary>
        public string WriteOffCode { get; set; }

        public string WriteOffHospital { get; set; }
        public string TradeId { get; set; }
        /// <summary>
        /// 已核销数量
        /// </summary>
        public int AlreadyWriteOffAmount { get; set; }

        public string ContentPlatFormId { get; set; }
        /// <summary>
        /// 主播平台
        /// </summary>
        public string LiveAnchorPlatForm { get; set; }

        /// <summary>
        /// 归属主播
        /// </summary>
        public string LiveAnchorName { get; set; }

        public int LiveAnchorId { get; set; }
        public int BelongEmpId { get; set; }
        /// <summary>
        /// 是否使用抵扣券
        /// </summary>
        public bool IsUseCoupon { get; set; }
        /// <summary>
        /// 使用的抵扣券id
        /// </summary>
        public string CouponId { get; set; }
        /// <summary>
        /// 抵扣金额
        /// </summary>
        public decimal DeductMoney { get; set; }
        /// <summary>
        /// 归属客服
        /// </summary>
        public string BelongEmpName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Standard { get; set; }
        /// <summary>
        /// 是否开票
        /// </summary>
        public bool IsCreateBill { get; set; }
        /// <summary>
        /// 开票公司
        /// </summary>
        public string BelongCompany { get; set; }

        #region  财务审核板块
        /// <summary>
        /// 审核状态
        /// </summary>
        public string CheckState { get; set; }

        public decimal? CheckPrice { get; set; }
        public DateTime? CheckDate { get; set; }

        public decimal? SettlePrice { get; set; }
        public int? CheckBy { get; set; }

        public string CheckByEmpName { get; set; }
        public string CheckRemark { get; set; }
        public bool IsReturnBackPrice { get; set; }

        public decimal? ReturnBackPrice { get; set; }
        public DateTime? ReturnBackDate { get; set; }

        /// <summary>
        /// 对账单id
        /// </summary>
        public string ReconciliationDocumentsId { get; set; }


        #endregion


    }
}
