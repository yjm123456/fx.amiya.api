using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlatFormOrderSend
{
    /// <summary>
    /// 未派单列表
    /// </summary>
    public class UnContentPlateFormSendOrderInfoVo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 下单平台
        /// </summary>
        public string ContentPlatFormName { get; set; }
        /// <summary>
        /// 主播IP账号
        /// </summary>
        public string LiveAnchorName { get; set; }
        /// <summary>
        /// 项目
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 项目图片
        /// </summary>
        public string ThumbPictureUrl { get; set; }
        /// <summary>
        /// 面诊类型文本
        /// </summary>
        public string ConsultationTypeText { get; set; }

        /// <summary>
        /// 咨询内容
        /// </summary>
        public string ConsultingContent { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 加密手机号
        /// </summary>
        public string EncryptPhone { get; set; }
        /// <summary>
        /// 定金
        /// </summary>
        public decimal? DepositAmount { get; set; }
        /// <summary>
        /// 成交金额
        /// </summary>
        public decimal? DealAmount { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderTypeText { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderStatusText { get; set; }
        /// <summary>
        /// 预约门店
        /// </summary>
        public string AppointmentHospital { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public string AppointmentDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 后期项目铺垫
        /// </summary>
        public string LateProjectStage { get; set; }
        /// <summary>
        /// 订单来源文本
        /// </summary>

        public string OrderSourceText { get; set; }

        /// <summary>
        /// 未派单原因
        /// </summary>
        public string UnSendReason { get; set; }

    }
}
