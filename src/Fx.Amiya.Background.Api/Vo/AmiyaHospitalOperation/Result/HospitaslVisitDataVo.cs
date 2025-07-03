using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaHospitalOperation.Result
{
    public class HospitaslVisitDataVo
    {

        /// <summary>
        /// 总上门数
        /// </summary>
        public int TotalVisitCount { get; set; }
        /// <summary>
        /// 总成交数
        /// </summary>
        public int TotalDealCount { get; set; }
        /// <summary>
        /// 总成交率
        /// </summary>
        public decimal DealRate { get; set; }
        /// <summary>
        /// 折线图数据
        /// </summary>
        public List<HospitalCluesDataItemVo> Items { get; set; }
    }

    public class HospitalCluesDataItemVo
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 上门数
        /// </summary>
        public int VisitCount { get; set; }
        /// <summary>
        /// 上门率
        /// </summary>
        public decimal VisitRate { get; set; }
        /// <summary>
        /// 成交数
        /// </summary>
        public int DealCount { get; set; }
        /// <summary>
        /// 成交率
        /// </summary>
        public decimal DealRate { get; set; }
    }
}
