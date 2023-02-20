using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TikTokOrder
{
    public class TikTokOrderAddDto
    {
        public string Id { get; set; }
        public string GoodsName { get; set; }
        public string GoodsId { get; set; }
        public string Phone { get; set; }
        public string AppointmentHospital { get; set; }
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
        public long OrderType { get; set; }
        public byte? OrderNature { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// 抵扣积分
        /// </summary>
        public decimal? IntegrationQuantity { get; set; }
        /// <summary>
        /// 商品简介
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Standard { get; set; }

        /// <summary>
        /// 部位
        /// </summary>
        public string Part { get; set; }

        /// <summary>
        /// 交易类型：0=积分
        /// </summary>
        public byte? ExchangeType { get; set; }

        /// <summary>
        /// 归属客服
        /// </summary>
        public int BelongEmpId { get; set; }

        public string TradeId { get; set; }
        public string TikTokUserId { get; set; }
        /// <summary>
        /// 加密手机号
        /// </summary>
        public string CipherPhone { get; set; }
        /// <summary>
        /// 加密昵称
        /// </summary>
        public string CipherName { get; set; }
        /// <summary>
        /// 订单完成时间
        /// </summary>
        public DateTime? FinishDate { get; set; }
        /// <summary>
        /// 归属主播ID
        /// </summary>
        public int BelongLiveAnchorId { get; set; }
    }
}
