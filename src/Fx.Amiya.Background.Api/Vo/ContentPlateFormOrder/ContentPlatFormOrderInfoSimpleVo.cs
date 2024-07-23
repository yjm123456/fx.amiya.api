using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder
{
    /// <summary>
    /// 根据加密手机号获取的简易订单信息内容
    /// </summary>
    public class ContentPlatFormOrderInfoSimpleVo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderTypeText { get; set; }
        /// <summary>
        /// 下单平台
        /// </summary>
        public string ContentPlatformName { get; set; }
        /// <summary>
        /// 主播IP账号
        /// </summary>
        public string LiveAnchorName { get; set; }
        /// <summary>
        /// 预约日期
        /// </summary>
        public string AppointmentDate { get; set; }
        /// <summary>
        /// 预约医院
        /// </summary>
        public string AppointmentHospitalName { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 主派咨询内容
        /// </summary>
        public string ConsultingContent { get; set; }
        /// <summary>
        /// 次派咨询内容
        /// </summary>
        public string ConsultingContent2 { get; set; }
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
        /// 未成交原因
        /// </summary>
        public string UnDealReason { get; set; }
        /// <summary>
        /// 后期项目铺垫
        /// </summary>
        public string LateProjectStage { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
