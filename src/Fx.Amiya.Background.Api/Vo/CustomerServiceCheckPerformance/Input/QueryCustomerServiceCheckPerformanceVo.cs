using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerServiceCheckPerformance.Input
{
    public class QueryCustomerServiceCheckPerformanceVo : BaseQueryVo
    {
        public bool? Valid { get; set; }
        /// <summary>
        /// 归属客服
        /// </summary>
        public int? BelongEmpId { get; set; }

        /// <summary>
        /// 是否为稽查业绩（默认传否）
        /// </summary>
        public bool IsCheckPerformance { get; set; }
        /// <summary>
        /// 稽查客服
        /// </summary>
        public int? CheckEmpId { get; set; }

        /// <summary>
        /// 业绩类型合集
        /// </summary>
        public List<int> PerformanceTypeList { get; set; }
    }
}
