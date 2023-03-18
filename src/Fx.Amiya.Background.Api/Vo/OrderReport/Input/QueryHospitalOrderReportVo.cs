using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport.Input
{
    /// <summary>
    /// 医院订单/预约量报表查询类
    /// </summary>
    public class QueryHospitalOrderReportVo:BaseQueryVo
    {
        /// <summary>
        /// 医院名称（支持模糊查找）
        /// </summary>
        public string HospitalName { get; set; }
    }
}
