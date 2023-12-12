using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlatFormOrderAddWork.Input
{
    public class QueryContentplatFormOrderAddWorkHistoryDto : BaseQueryDto
    {
        public int? HospitalId { get; set; }
        public int? CheckState { get; set; }
        public bool? Valid { get; set; }
    }
}
