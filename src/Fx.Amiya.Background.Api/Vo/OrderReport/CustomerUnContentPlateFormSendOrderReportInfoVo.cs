using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport
{
    /// <summary>
    /// 客服内容平台未派单报表
    /// </summary>
    public class CustomerUnContentPlateFormSendOrderReportInfoVo
    {
        /// <summary>
        /// 客服
        /// </summary>
        [Description("客服")]
        public string EmployeeName { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [Description("订单号")]
        public string OrderId { get; set; }
        /// <summary>
        /// 下单平台
        /// </summary>
        [Description("下单平台")]
        public string ContentPlatFormName { get; set; }
        /// <summary>
        /// 主播IP账号
        /// </summary>
        [Description("主播IP账号")]
        public string LiveAnchorName { get; set; }
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
        /// 客户姓名
        /// </summary>
        [Description("客户姓名")]
        public string CustomerName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Description("手机号")]
        public string Phone { get; set; }
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
        /// 订单类型
        /// </summary>
        [Description("订单类型")]
        public string OrderTypeText { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        [Description("订单状态")]
        public string OrderStatusText { get; set; }
        /// <summary>
        /// 预约门店
        /// </summary>
        [Description("预约门店")]
        public string AppointmentHospital { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        [Description("预约时间")]
        public string AppointmentDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; }
        /// <summary>
        /// 后期项目铺垫
        /// </summary>
        [Description("后期项目铺垫")]
        public string LateProjectStage { get; set; }
    }
}
