using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerInfo
{
    public class QueryBIndCustomerServicePageVo:BaseQueryVo
    {
        /// <summary>
        /// 客服id
        /// </summary>
        public int? EmployeeId { get; set; }
        /// <summary>
        /// 最小消费金额
        /// </summary>
        public decimal? MinAmount { get; set; }
        /// <summary>
        /// 最大消费金额
        /// </summary>
        public decimal? MaxAmount { get; set; }
        
    }
}
