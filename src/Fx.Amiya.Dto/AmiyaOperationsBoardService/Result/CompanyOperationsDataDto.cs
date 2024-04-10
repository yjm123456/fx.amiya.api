using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService
{
    public class CompanyOperationsDataDto
    {
        /// <summary>
        /// 分组名
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 派单量 
        /// </summary>
        public int SendOrder { get; set; }
        /// <summary>
        /// 派单目标
        /// </summary>
        public int SendOrderTarget { get; set; }
        /// <summary>
        /// 派单目标达成率
        /// </summary>
        public decimal SendOrderTargetComplete { get; set; }
        /// <summary>
        /// 上门量
        /// </summary>
        public int ToHospital { get; set; }
        /// <summary>
        /// 上门目标
        /// </summary>
        public int ToHospitalTarget { get; set; }
        /// <summary>
        /// 上门达成率
        /// </summary>
        public decimal ToHospitalTargetComplete { get; set; }
        /// <summary>
        /// 成交量
        /// </summary>
        public decimal Deal { get; set; }
        /// <summary>
        /// 成交目标
        /// </summary>
        public decimal DealTarget { get; set; }
        /// <summary>
        /// 成交达成率
        /// </summary>
        public decimal DealTargetComplete { get; set; }
    }
}
