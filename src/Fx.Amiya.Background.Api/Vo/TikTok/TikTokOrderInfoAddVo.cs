using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TikTok
{
    public class TikTokOrderInfoAddVo
    {

        /// <summary>
        /// 订单号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required]
        public string GoodsName { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        public string ThumbPicUrl { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        [Required]
        public string GoodsId { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 订单状态(SEEK_ADVICE:咨询，BARGAIN_MONEY:定金)
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// 实付金额
        /// </summary>
        [Required]
        public decimal? ActualPayment { get; set; }
        /// <summary>
        /// 应收款（优惠后实际价格，财务用）
        /// </summary>
        public decimal? AccountReceivable { get; set; }
        /// <summary>
        /// 买家昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 是否预约
        /// </summary>
        public bool IsAppointment { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public long? OrderType { get; set; }


        /// <summary>
        /// 商品数量
        /// </summary>
        public int? Quantity { get; set; }


        /// <summary>
        /// 交易类型：0=积分
        /// </summary>
        public byte? ExchangeType { get; set; }

        /// <summary>
        /// 订单描述
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 加密手机号
        /// </summary>
        public string CipherName { get; set; }
        /// <summary>
        /// 加密昵称
        /// </summary>
        public string CipherPhone { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateDate { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 订单归属主播
        /// </summary>
        public string BelongLiveAnchorId { get; set; }
    }
}

