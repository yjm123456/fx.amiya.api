using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalBoard
{
    public class RankData
    {
        /// <summary>
        /// 排名
        /// </summary>
        public int Rank{ get; set; }
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
        /// 复购率
        /// </summary>
        public decimal? RepurchaseRatio { get; set; }
        /// <summary>
        /// 新客客单价
        /// </summary>
        public decimal? NewCustomerUnitPrice { get; set; }
    }
    public class RankDataVo {
        /// <summary>
        /// 机构排名列表
        /// </summary>
        public List<RankData> RankList { get; set; }
        /// <summary>
        /// 本机构排名
        /// </summary>
        public RankData MyRank { get; set; }
    }
}
