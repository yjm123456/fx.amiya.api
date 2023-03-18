using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport.Input
{
    /// <summary>
    /// 客户预约报表查询类
    /// </summary>
    public class QueryCustomerAppointmentVo:BaseQueryVo
    {
        /// <summary>
        /// 预约状态
        /// </summary>
        public int Status { get; set; }
    }
}
