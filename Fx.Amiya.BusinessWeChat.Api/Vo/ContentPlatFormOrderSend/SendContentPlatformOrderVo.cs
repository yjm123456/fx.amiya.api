using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlatFormOrderSend
{
    /// <summary>
    /// 获取已派单数据信息
    /// </summary>
    public class SendContentPlatformOrderVo
    {
        /// <summary>
        /// 派单编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 内容平台订单编号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 归属月份
        /// </summary>
        public int BelongMonth { get; set; }

        /// <summary>
        /// 内容平台名称
        /// </summary>
        public string ContentPlatFormName { get; set; }

        /// <summary>
        /// 主播
        /// </summary>
        public string LiveAnchorName { get; set; }
        /// <summary>
        /// 微信编号
        /// </summary>
        public string LiveAnchorWeChatNo { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>   
        /// 下单金额
        /// </summary>
        public decimal AddOrderPrice { get; set; }

        /// <summary>
        /// 加密电话
        /// </summary>
        public string EncryptPhone { get; set; }
        /// <summary>
        /// 医院是否已查看过该单电话
        /// </summary>
        public bool IsHospitalCheckPhone { get; set; }

        /// <summary>
        /// 预约医院
        /// </summary>
        public string AppointmentHospital { get; set; }
        /// <summary>
        /// 派单医院id
        /// </summary>
        public int SendHospitalId { get; set; }
        /// <summary>
        /// 派单医院
        /// </summary>
        public string SendHospital { get; set; }
        /// <summary>
        /// 是否到院
        /// </summary>
        public bool IsToHospital { get; set; }

        /// <summary>
        /// 到院类型
        /// </summary>
        public string ToHospitalTypeText { get; set; }

        /// <summary>
        /// 到院时间
        /// </summary>
        public DateTime? ToHospitalDate { get; set; }

        /// <summary>
        /// 预约时间
        /// </summary>
        public string AppointmentDate { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 咨询内容
        /// </summary>
        public string ConsultingContent { get; set; }

        /// <summary>
        /// 项目图片
        /// </summary>
        public string ThumbPictureUrl { get; set; }

        /// <summary>
        /// 后期项目铺垫
        /// </summary>
        public string LateProjectStage { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderTypeText { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderStatusText { get; set; }

        /// <summary>
        /// 定金
        /// </summary>
        public decimal? DepositAmount { get; set; }

        /// <summary>
        /// 成交金额
        /// </summary>
        public decimal? DealAmount { get; set; }

        /// <summary>
        /// 成交截图
        /// </summary>
        public string DealPictureUrl { get; set; }
        /// <summary>
        /// 成交时间
        /// </summary>
        public DateTime? DealDate { get; set; }

        /// <summary>
        /// 未成交原因
        /// </summary>
        public string UnDealReason { get; set; }
        /// <summary>
        /// 未成交截图
        /// </summary>
        public string UnDealPictureUrl { get; set; }


        /// <summary>
        /// 派单人id
        /// </summary>
        public int Sender { get; set; }

        /// <summary>
        /// 派单人姓名
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// 派单时间
        /// </summary>
        public DateTime SendDate { get; set; }

        /// <summary>
        /// 派单留言
        /// </summary>
        public string SendOrderRemark { get; set; }
        /// <summary>
        /// 订单备注
        /// </summary>
        public string OrderRemark { get; set; }

        /// <summary>
        /// 医院备注
        /// </summary>
        public string HospitalRemark { get; set; }
        /// <summary>
        /// 订单来源（1：面诊卡，2：非面诊卡）
        /// </summary>
        public string OrderSourceText { get; set; }
        /// <summary>
        /// 面诊状态
        /// </summary>
        public string ConsultatioType { get; set; }


        /// <summary>
        /// 院方接诊人员
        /// </summary>
        public string AcceptConsulting { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int? CheckState { get; set; }
        /// <summary>
        /// 三方订单号
        /// </summary>
        public string OtherContentPlatFormOrderId { get; set; }

        /// <summary>
        /// 新客/老客
        /// </summary>
        public string IsOldCustomer { get; set; }

        /// <summary>
        /// 是否陪诊
        /// </summary>
        public bool IsAcompanying { get; set; }

        /// <summary>
        /// 佣金比例
        /// </summary>
        public decimal CommissionRatio { get; set; }
        /// <summary>
        /// 是否是重单可深度订单
        /// </summary>
        public bool IsRepeatProfundityOrder { get; set; }
    }
}
