using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport
{
    /// <summary>
    /// 内容平台订单成交报表查询类
    /// </summary>
    public class QueryContentPlatFormOrderDeal : BaseQueryVo
    {
        /// <summary>
        /// 归属月份
        /// </summary>
        public int? BelongMonth { get; set; }
        /// <summary>
        /// 最小下单金额
        /// </summary>
        public decimal? MinAddOrderPrice { get; set; }
        /// <summary>
        /// 最大下单金额
        /// </summary>
        public decimal? MaxAddOrderPrice { get; set; }
        /// <summary>
        /// 成交医院（全部则不传）
        /// </summary>
        public int? DealHospitalId { get; set; }
        /// <summary>
        /// 审核情况（查询全部传空）
        /// </summary>
        public int? CheckState { get; set; }
        /// <summary>
        /// 主播id
        /// </summary>
        public int? LiveAnchorId { get; set; }

    }
}
