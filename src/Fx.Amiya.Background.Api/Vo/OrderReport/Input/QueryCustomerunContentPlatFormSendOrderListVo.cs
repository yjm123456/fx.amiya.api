using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport.Input
{
    /// <summary>
    /// 内容平台未派单报表查询类
    /// </summary>
    public class QueryCustomerunContentPlatFormSendOrderListVo : BaseQueryVo
    {
        /// <summary>
        /// 归属主播id
        /// </summary>
        public int? liveAnchorId { get; set; }
        /// <summary>
        /// 内容平台
        /// </summary>
        public string contentPlateFormId { get; set; }
        /// <summary>
        /// 归属客服id（-1查询所有）
        /// </summary>
        public int? employeeId { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int orderStatus { get; set; }
    }
}
