using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaHospitalOperation.Result
{
    public class HospitalsCluesDataDto
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
        public List<HospitalCluesDataItemDto> Items { get; set; }
    }

    public class HospitalCluesDataItemDto
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
