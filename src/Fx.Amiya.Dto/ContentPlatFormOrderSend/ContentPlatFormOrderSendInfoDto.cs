using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlatFormOrderSend
{
    public class ContentPlatFormOrderSendInfoDto
    {
        /// <summary>
        /// 派单号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 主播IP
        /// </summary>
        public string LiveAnchor { get; set; }
        /// <summary>
        /// 客户昵称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public string AppointmentDate { get; set; }

        /// <summary>
        /// 派单医院名称
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 是否未确认时间
        /// </summary>
        public bool IsUncertainDate { get; set; }
        /// <summary>
        /// 科室id
        /// </summary>
        public string DepartmentId { get; set; }
        /// <summary>
        /// 科室
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        public string ThumbPicUrl { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderStatus { get; set; }
        /// <summary>
        /// 订单状态int类型
        /// </summary>
        public int OrderStatusIntType { get; set; }

        /// <summary>
        /// 成交截图
        /// </summary>
        public string DealPictureUrl { get; set; }
        /// <summary>
        /// 重单截图
        /// </summary>
        public string RepeateOrderPictureUrl { get; set; }

        /// <summary>
        /// 后期项目铺垫
        /// </summary>
        public string LateProjectStage { get; set; }
        /// <summary>
        /// 咨询内容
        /// </summary>
        public string ConsultingContent { get; set; }
        /// <summary>
        /// 未成交原因
        /// </summary>
        public string UnDealReason { get; set; }
        /// <summary>
        /// 未成交截图
        /// </summary>
        public string UnDealPictureUrl { get; set; }
        /// <summary>
        /// 定金
        /// </summary>
        public decimal? DepositAmount { get; set; }
        /// <summary>
        /// 成交金额
        /// </summary>
        public decimal? DealAmount { get; set; }

        /// <summary>
        /// 医院是否已查看过该订单的电话
        /// </summary>
        public bool IsHospitalCheckPhone { get; set; }

        /// <summary>
        /// 顾客电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 加密电话
        /// </summary>
        public string EncryptPhone { get; set; }

        /// <summary>
        /// 派单时间
        /// </summary>
        public DateTime SendDate { get; set; }
        /// <summary>
        /// 派单人员
        /// </summary>
        public string SendBy { get; set; }
        /// <summary>
        /// 订单备注
        /// </summary>
        public string OrderRemark { get; set; }
        /// <summary>
        /// 派单备注
        /// </summary>
        public string SendOrderRemark { get; set; }

        /// <summary>
        /// 医院备注
        /// </summary>
        public string HospitalRemark { get; set; }
        /// <summary>
        /// 订单来源（1：面诊卡，2：非面诊卡）
        /// </summary>
        public int? OrderSource { get; set; }
        public string OrderSourceText { get; set; }
        public int? CheckState { get; set; }
        public DateTime? DealDate { get; set; }
        public bool IsToHospital { get; set; }
        /// <summary>
        /// 到院时间（最新）
        /// </summary>
        public DateTime? ToHospitalDate { get; set; }
        public int ToHospitalType { get; set; }
        public string ToHospitalTypeText { get; set; }
        /// <summary>
        /// 是否陪诊
        /// </summary>
        public bool IsAcompanying { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>
        public string WeChatNo { get; set; }

        /// <summary>
        /// 最新消息
        /// </summary>
        public string FirstlyRemark { get; set; }
        /// <summary>
        /// 是否是重单可深度订单
        /// </summary>
        public bool IsRepeatProfundityOrder { get; set; }
        /// <summary>
        /// 是否为辅助订单
        /// </summary>
        public bool IsSupportOrder { get; set; }

        /// <summary>
        /// 辅助客服
        /// </summary>
        public int SupportEmpId { get; set; }

        /// <summary>
        /// 辅助客服名称
        /// </summary>
        public string SupportEmpName { get; set; }

        /// <summary>
        /// 归属客服
        /// </summary>
        public int BelongEmpId { get; set; }

        /// <summary>
        /// 归属客服名称
        /// </summary>
        public string BelongEmpName { get; set; }
    }
}
