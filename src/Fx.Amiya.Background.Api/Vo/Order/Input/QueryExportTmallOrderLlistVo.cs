using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order
{
    public class QueryExportTmallOrderLlistVo : BaseQueryVo
    {
        /// <summary>
        /// 核销开始时间
        /// </summary>
        public DateTime? WriteOffStartDate { get; set; }
        /// <summary>
        /// 核销结束时间
        /// </summary>
        public DateTime? WriteOffEndDate { get; set; }
        /// <summary>
        /// 关键词
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// 状态码
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// 渠道
        /// </summary>
        public byte? AppType { get; set; }
        /// <summary>
        /// 订单性质
        /// </summary>
        public byte? OrderNature { get; set; }
    }
}
