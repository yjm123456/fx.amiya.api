using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Input
{
    public class QueryCustomerFlowRateWithEmployeeAndHospitalDto
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? startDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// 关键词
        /// </summary>
        public string keyWord { get; set; }
        /// <summary>
        /// 是否查询当月数据
        /// </summary>
        public bool CurrentMonth { get; set; }
        /// <summary>
        /// 是否查询历史数据
        /// </summary>
        public bool History { get; set; }
    }
}
