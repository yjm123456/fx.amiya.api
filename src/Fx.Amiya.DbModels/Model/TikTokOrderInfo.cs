using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class TikTokOrderInfo
    {
        public string Id { get; set; }
        public string GoodsName { get; set; }
        public string GoodsId { get; set; }
        public string Phone { get; set; }
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
        public long? OrderType { get; set; }
        public byte? OrderNature { get; set; }
        public int? Quantity { get; set; }
        public decimal? IntegrationQuantity { get; set; }
        public byte? ExchangeType { get; set; }
        //public string TradeId { get; set; }
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
        /// 订单完成时间
        /// </summary>
        public DateTime? FinishDate { get; set; }

        public int BelongLiveAnchorId { get; set; }

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
        public string TikTokUserInfoId { get; set; }

        #endregion

        public TikTokUserInfo TikTokUserInfo { get; set; }
    }
}
