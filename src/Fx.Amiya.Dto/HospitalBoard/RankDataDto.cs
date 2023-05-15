using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalBoard
{
    public class RankDataDto
    {
        /// <summary>
        /// 排名
        /// </summary>
        public int Rank { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 机构名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 上门率
        /// </summary>
        public decimal? ToHospitalRatio { get; set; }
       
        /// <summary>
        /// 成交率
        /// </summary>
        public decimal? DealRatio { get; set; }
        /// <summary>
        /// 累计上门率
        /// </summary>
        public decimal? AccumulateToHospitalRatio { get; set; }
        /// <summary>
        /// 累计成交率
        /// </summary>
        public decimal? AccumulateDealRatio { get; set; }
        /// <summary>
        /// 复购率
        /// </summary>
        public decimal? RepurchaseRatio { get; set; }
        /// <summary>
        /// 新客客单价
        /// </summary>
        public decimal? NewCustomerUnitPrice { get; set; }
    }
}
