using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class OrderInfo
    {
        public string Id { get; set; }
        public string GoodsName { get; set; }
        public string GoodsId { get; set; }
        public string Phone { get; set; }
        public string AppointmentCity { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string AppointmentHospital { get; set; }
        /// <summary>
        /// 最终消费医院
        /// </summary>
        public string FinalConsumptionHospital { get; set; }
        public string StatusCode { get; set; }
        /// <summary>
        /// 价格（商品正常价格）
        /// </summary>
        public decimal? ActualPayment { get; set; }
        /// <summary>
        /// 应收款（优惠后实际价格，财务用）
        /// </summary>
        public decimal? AccountReceivable { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? WriteOffDate { get; set; }
        public string ThumbPicUrl { get; set; }
        public string BuyerNick { get; set; }
        public byte AppType { get; set; }
        public bool IsAppointment { get; set; }
        public byte? OrderType { get; set; }
        public byte? OrderNature { get; set; }
        public int? Quantity { get; set; }
        public decimal? IntegrationQuantity { get; set; }
        public byte? ExchangeType { get; set; }
        public string TradeId { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Standard { get; set; }
        /// <summary>
        /// 部位
        /// </summary>
        public string Parts { get; set; }
        /// <summary>
        /// 核销码
        /// </summary>
        public string WriteOffCode { get; set; }
        /// <summary>
        /// 已核销数量
        /// </summary>
        public int AlreadyWriteOffAmount { get; set; }
        /// <summary>
        /// 归属主播
        /// </summary>
        public int LiveAnchorId { get; set; }

        /// <summary>
        /// 归属客服
        /// </summary>
        public int BelongEmpId { get; set; }
        /// <summary>
        /// 是否使用抵用券
        /// </summary>
        public bool IsUseCoupon { get; set; }
        /// <summary>
        /// 使用的抵用券id
        /// </summary>
        public string CouponId { get; set; }
        /// <summary>
        /// 抵用券抵扣金额
        /// </summary>
        public decimal DeductMoney { get; set; }
        /// <summary>
        /// 是否开票
        /// </summary>
        public bool IsCreateBill { get; set; }
        /// <summary>
        /// 开票公司id
        /// </summary>
        public string BelongCompany { get; set; }

        #region  财务审核板块
        /// <summary>
        /// 审核状态
        /// </summary>
        public int? CheckState { get; set; }

        public decimal? CheckPrice { get; set; }
        public DateTime? CheckDate { get; set; }

        public decimal? SettlePrice { get; set; }
        public int? CheckBy { get; set; }
        public string CheckRemark { get; set; }
        public bool IsReturnBackPrice { get; set; }

        public decimal? ReturnBackPrice { get; set; }
        public DateTime? ReturnBackDate { get; set; }


        /// <summary>
        /// 对账单id
        /// </summary>
        public string ReconciliationDocumentsId { get; set; }
        #endregion

        public List<SendOrderInfo> SendOrderInfoList { get; set; }
        public ReceiveGift ReceiveGift { get; set; }
        public OrderTrade OrderTrade { get; set; }
    }
}
