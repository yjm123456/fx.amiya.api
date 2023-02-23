using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order
{
    public class OrderInfoVo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string Id { get; set; }
        public string UserId { get; set; }

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

        public string EncryptPhone { get; set; }
        /// <summary>
        /// 预约城市
        /// </summary>
        public string AppointmentCity { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime? AppointmentDate { get; set; }

        /// <summary>
        /// 预约门店
        /// </summary>
        public string AppointmentHospital { get; set; }

        /// <summary>
        /// 系统派单门店
        /// </summary>
        public string SendOrderHospital { get; set; }

        /// <summary>
        /// 核销门店
        /// </summary>
        public string FinalConsumptionHospital { get; set; }

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
        /// 核销时间
        /// </summary>
        public DateTime? WriteOffDate { get; set; }
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


        public byte? OrderType { get; set; }
        public string OrderTypeText { get; set; }

        /// <summary>
        /// 订单性质
        /// </summary>
        public byte? OrderNature { get; set; }
        /// <summary>
        /// 订单性质说明
        /// </summary>
        public string OrderNatureText { get; set; }



        /// <summary>
        /// 购买数量
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// 支付积分
        /// </summary>
        public decimal? IntegrationQuantity { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public byte? ExchangeType { get; set; }
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
        public string CreateBillCompany { get; set; }
        /// <summary>
        /// 商品类别
        /// </summary>
        public string CategoryName { get; set; }

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

        /// <summary>
        /// 对账单id
        /// </summary>
        public string ReconciliationDocumentsId { get; set; }


        #endregion


    }
}
