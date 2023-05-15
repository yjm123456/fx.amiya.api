using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalBoard
{
    public class OperateConsultantRankDataDto
    {
        /// <summary>
        /// 排名
        /// </summary>
        public int Rank { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 上门率
        /// </summary>
        public decimal? ToHospitalRatio { get; set; }
        /// <summary>
        /// 成交率
        /// </summary>
        public decimal? DealRation { get; set; }
        /// <summary>
        /// 累计上门率
        /// </summary>
        public decimal? AccumulateToHospitalRatio { get; set; }
        /// <summary>
        /// 累计成交率
        /// </summary>
        public decimal? AccumulateDealRation { get; set; }
        /// <summary>
        /// 新客客单价
        /// </summary>
        public decimal? NewCustomerUnitPrice { get; set; }
        /// <summary>
        /// 老客客单价
        /// </summary>
        public decimal? OldCustomerUnitPrice { get; set; }
        /// <summary>
        /// 业绩
        /// </summary>
        public decimal? Performance { get; set; }
        /// <summary>
        /// 占比
        /// </summary>
        public decimal? PerformanceRatio { get; set; }
    }
}
