using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlatFormOrderSend
{
    /// <summary>
    /// 医院内容平台派单报表导出
    /// </summary>
    public class ExportContentPlatFormSendOrderInfoVo
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        [Description("订单编号")]
        public string OrderId { get; set; }
        /// <summary>
        /// 派单时间
        /// </summary>
        [Description("派单时间")]
        public DateTime SendDate { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Description("手机号")]
        public string Phone { get; set; }


        /// <summary>
        /// 客户昵称
        /// </summary>
        [Description("客户昵称")]
        public string CustomerName { get; set; }
        /// <summary>
        /// 项目
        /// </summary>
        [Description("项目")]
        public string GoodsName { get; set; }
        /// <summary>
        /// 咨询内容
        /// </summary>
        [Description("咨询内容")]
        public string ConsultingContent { get; set; }


        /// <summary>
        /// 预约时间
        /// </summary>
        [Description("预约时间")]
        public string AppointmentDate { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        [Description("订单状态")]
        public string OrderStatusText { get; set; }
        /// <summary>
        /// 订单来源（1：面诊卡，2：非面诊卡）
        /// </summary>
        [Description("订单来源")]
        public string OrderSourceText { get; set; }


        /// <summary>
        /// 院方接诊人员
        /// </summary>
        [Description("院方接诊人员")]
        public string AcceptConsulting { get; set; }

        /// <summary>
        /// 定金
        /// </summary>
        [Description("定金")]
        public decimal? DepositAmount { get; set; }

        /// <summary>
        /// 成交金额
        /// </summary>
        [Description("成交金额")]
        public decimal? DealAmount { get; set; }
        /// <summary>
        /// 未成交原因
        /// </summary>
        [Description("未成交原因")]
        public string UnDealReason { get; set; }
        /// <summary>
        /// 后期项目铺垫
        /// </summary>
        [Description("后期项目铺垫")]
        public string LateProjectStage { get; set; }
        /// <summary>
        /// 订单备注
        /// </summary>
        [Description("订单备注")]
        public string OrderRemark { get; set; }
        /// <summary>
        /// 派单留言
        /// </summary>
        [Description("派单留言")]
        public string SendOrderRemark { get; set; }

        /// <summary>
        /// 医院备注
        /// </summary>
        [Description("医院备注")]
        public string HospitalRemark { get; set; }
    }
}
