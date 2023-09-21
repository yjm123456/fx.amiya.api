using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerServiceCompensation.Input
{
    /// <summary>
    /// 查询助理薪资单输入类
    /// </summary>
    public class QueryCustomerServiceCompensationVo:BaseQueryVo
    {
        /// <summary>
        /// 归属助理
        /// </summary>

        public int? BelongEmpId { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>

        public bool? Valid { get; set; }
    }
}
