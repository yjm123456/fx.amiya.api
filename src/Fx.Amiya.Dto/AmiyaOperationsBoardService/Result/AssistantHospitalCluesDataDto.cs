using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class AssistantHospitalCluesDataDto
    {
        /// <summary>
        /// 总派单数
        /// </summary>
        public int TotalSendOrderCount => Items.Sum(e => e.SendOrderCount);
        /// <summary>
        /// 总上门数
        /// </summary>
        public int TotalVisitCount => Items.Sum(e => e.VisitCount);
        /// <summary>
        /// 总成交数
        /// </summary>
        public int TotalDealCount => Items.Sum(e => e.DealCount);
        public List<AssistantCluesDataItemDto> Items { get; set; }
    }
    public class AssistantCluesDataItemDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 派单数
        /// </summary>
        public int SendOrderCount { get; set; }
        /// <summary>
        /// 上门数
        /// </summary>
        public int VisitCount { get; set; }
        /// <summary>
        /// 成交数
        /// </summary>
        public int DealCount { get; set; }
    }
}
