using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Input
{
    public class QueryHospitalTransformDataDto
    {
        /// <summary>
        /// 主播id集合
        /// </summary>
        public List<string> LiveAnchorIds { get; set; }
        
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
        public List<int> HospitalId { get; set; }
    }
}
