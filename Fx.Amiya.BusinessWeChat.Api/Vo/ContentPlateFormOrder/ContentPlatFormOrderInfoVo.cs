using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlateFormOrder
{
    /// <summary>
    /// 内容平台订单列表
    /// </summary>
    public class ContentPlatFormOrderInfoVo
    {
        /// <summary>
        /// 订单号
        /// </summary>
       
        public string Id { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public string AppointmentDate { get; set; }
        /// <summary>
        /// 归属客服
        /// </summary>
        public string BelongEmpName { get; set; }
        /// <summary>
        /// 客户昵称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 加密电话
        /// </summary>
        public string EncryptPhone { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 新/老客业绩
        /// </summary>
        public string IsOldCustomer { get; set; }
        /// <summary>
        /// 下单金额
        /// </summary>
        public decimal AddOrderPrice { get; set; }
        /// <summary>
        /// 预约医院
        /// </summary>
        public string AppointmentHospitalName { get; set; }
        /// <summary>
        /// 项目
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 项目图片
        /// </summary>
        public string ThumbPictureUrl { get; set; }

        /// <summary>
        /// 科室
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 咨询内容
        /// </summary>
        public string ConsultingContent { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 下单平台
        /// </summary>
        public string ContentPlatformName { get; set; }
        /// <summary>
        /// 主播ip账号
        /// </summary>
        public string LiveAnchorName { get; set; }
        /// <summary>
        /// 主播微信号
        /// </summary>
        public string LiveAnchorWeChatNo { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderTypeText { get; set; }
        /// <summary>
        /// 归属月份
        /// </summary>

        public int BelongMonth { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderStatusText { get; set; }

        /// <summary>
        /// 三方订单号
        /// </summary>
        public string OtherContentPlatFormOrderId { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public string OrderSourceText { get; set; }
        /// <summary>
        /// 派单医院
        /// </summary>
        public string SendHospital { get; set; }
        /// <summary>
        /// 派单人
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// 派单时间
        /// </summary>
        public DateTime? SendDate { get; set; }
        /// <summary>
        /// 面诊状态
        /// </summary>
        public string ConsultationType { get; set; }
        /// <summary>
        /// 院方接诊人员
        /// </summary>
        public string AcceptConsulting { get; set; }
        /// <summary>
        /// 定金金额
        /// </summary>
        public decimal? DepositAmount { get; set; }
        /// <summary>
        /// 是否到院
        /// </summary>
        public bool IsToHospital { get; set; }

        /// <summary>
        /// 最近到院时间
        /// </summary>
        public DateTime? ToHospitalDate { get; set; }
        /// <summary>
        /// 最终成交医院
        /// </summary>
        public string LastDealHospital { get; set; }
        /// <summary>
        /// 成交金额
        /// </summary>
        public decimal? DealAmount { get; set; }

        /// <summary>
        /// 成交时间
        /// </summary>
        public DateTime? DealDate { get; set; }
        /// <summary>
        /// 未成交原因
        /// </summary>
        public string UnDealReason { get; set; }
        /// <summary>
        /// 后期项目铺垫
        /// </summary>
        public string LateProjectStage { get; set; }

        /// <summary>
        /// 未派单原因
        /// </summary>
        public string UnSendReason { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public string CheckStateText { get; set; }

        /// <summary>
        /// 审核金额
        /// </summary>
        public decimal? CheckPrice { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal? SettlePrice { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? CheckDate { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>

        public string CheckByName { get; set; }
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
        /// 是否是重单深度订单
        /// </summary>
        public bool IsRepeatProfundityOrder { get; set; }
        /// <summary>
        /// 归属部门
        /// </summary>
        public int BelongChannel { get; set; }
        /// <summary>
        /// 归属部门名称
        /// </summary>
        public string BelongChannelText { get; set; }

        /// <summary>
        /// 是否为日不落直播顾客
        /// </summary>
        public bool IsRiBuLuoLiving { get; set; }
    }
}
