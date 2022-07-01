using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.LiveRequirementInfo
{
   public class HeadCollectivityDataDto
    {
        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 已解决数量
        /// </summary>
        public int TreatedQuantity { get; set; }

        /// <summary>
        /// 未解决数量
        /// </summary>
        public int UnTreatedQuantity { get; set; }

        /// <summary>
        /// 作废数量
        /// </summary>
        public int CancelQuantity { get; set; }

        /// <summary>
        /// 解决率
        /// </summary>
        public decimal TreatedRate { get; set; }

        /// <summary>
        /// 需求类型比率
        /// </summary>
        public List<RequirementTypeRateDto> RequirementTypeRateList { get; set; }

        /// <summary>
        /// 平均响应时长
        /// </summary>
        public decimal AvgResponseHour { get; set; }

        /// <summary>
        /// 平均处理时长
        /// </summary>
        public decimal AvgExecuteHour { get; set; }

        /// <summary>
        /// 待确认完成的需求数量
        /// </summary>
        public int WaitConfirmFinishQuantity { get; set; }
    }
}
