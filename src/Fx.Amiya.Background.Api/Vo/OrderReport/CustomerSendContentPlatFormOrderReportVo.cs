using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport
{
    /// <summary>
    /// 内容平台已派单模块报表
    /// </summary>
    public class CustomerSendContentPlatFormOrderReportVo
    {

        /// <summary>
        /// 派单人员
        /// </summary>
        [Description("派单人员")]
        public string SenderName { get; set; }

        /// <summary>
        /// 派单时间
        /// </summary>
        [Description("派单时间")]
        public DateTime SendDate { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        [Description("订单编号")]
        public string OrderId { get; set; }

        /// <summary>
        /// 平台
        /// </summary>
        [Description("平台")]
        public string ContentPlatFormName { get; set; }

        /// <summary>
        /// 主播
        /// </summary>
        [Description("主播")]
        public string LiveAnchorName { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        [Description("项目")]
        public string GoodsName { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        [Description("客户姓名")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 客户手机号
        /// </summary>
        [Description("客户手机号")]
        public string Phone { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        [Description("订单状态")]
        public string OrderStatusText { get; set; }

        /// <summary>
        /// 三方订单号
        /// </summary>
        [Description("抖店订单号")]
        public string OtherContentPlatFormOrderId { get; set; }

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
        /// 派单医院
        /// </summary>
        [Description("派单医院")]
        public string SendHospital { get; set; }



        /// <summary>
        /// 派单留言
        /// </summary>
        [Description("派单留言")]
        public string SendOrderRemark { get; set; }

    }
}
