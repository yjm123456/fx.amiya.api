using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TikTok
{
    public class TikTokInfoVo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public string GoodsId { get; set; }

        /// <summary>
        /// 商品缩略图
        /// </summary>
        public string ThumbPicUrl { get; set; }

        /// <summary>
        /// 客户昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 是否已预约
        /// </summary>
        public bool IsAppointment { get; set; }

        /// <summary>
        /// 实付款
        /// </summary>
        public decimal? ActualPayment { get; set; }

        /// <summary>
        /// 应收款
        /// </summary>
        public decimal? AccountReceivable { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 订单更新时间
        /// </summary>
        public DateTime? UpdateDate { get; set; }


        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 订单状态码
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// 订单状态文本
        /// </summary>
        public string StatusText { get; set; }


        /// <summary>
        /// 平台类型
        /// </summary>
        public byte AppType { get; set; }

        /// <summary>
        /// 平台类型名称
        /// </summary>
        public string AppTypeText { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        public long? OrderType { get; set; }
        /// <summary>
        /// 订单类型名称
        /// </summary>
        public string OrderTypeText { get; set; }





        /// <summary>
        /// 购买数量
        /// </summary>
        public int? Quantity { get; set; }


        /// <summary>
        /// 交易类型 0积分,1,三方支付
        /// </summary>
        public byte? ExchangeType { get; set; }
        /// <summary>
        /// 交易类型名称
        /// </summary>
        public string ExchangeTypeText { get; set; }
        public string TradeId { get; set; }
        /// <summary>
        /// 主播平台
        /// </summary>
        public string LiveAnchorPlatForm { get; set; }

        /// <summary>
        /// 归属主播
        /// </summary>
        public string LiveAnchor { get; set; }
        /// <summary>
        /// 归属客服
        /// </summary>
        public string BelongEmpName { get; set; }

        #region  财务审核板块
        /// <summary>
        /// 审核状态
        /// </summary>
        public string CheckState { get; set; }
        /// <summary>
        /// 审核金额
        /// </summary>

        public decimal? CheckPrice { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? CheckDate { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>

        public decimal? SettlePrice { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>

        public string CheckByEmpName { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>
        public string CheckRemark { get; set; }
        /// <summary>
        /// 是否回款
        /// </summary>
        public bool IsReturnBackPrice { get; set; }

        /// <summary>
        /// 回款金额
        /// </summary>
        public decimal? ReturnBackPrice { get; set; }

        /// <summary>
        /// 回款时间
        /// </summary>
        public DateTime? ReturnBackDate { get; set; }


        #endregion
        /// <summary>
        /// 加密昵称
        /// </summary>
        public string CipherName { get; set; }
        /// <summary>
        /// 加密手机号
        /// </summary>
        public string CipherPhone { get; set; }
        /// <summary>
        /// 订单完成时间
        /// </summary>
        public DateTime? FinishDate { get; set; }
    }
}
