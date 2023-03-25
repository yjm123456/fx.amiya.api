using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlatFormOrderAddWork.Input
{
    public class QueryContentPlatFormOrderAddWorkPageDto : BaseQueryDto
    {
        public int? HospitalId { get; set; }
        public int? CheckState { get; set; }

        /// <summary>
        /// 提交人
        /// </summary>
        public int? CreateBy { get; set; }

        /// <summary>
        /// 接收人
        /// </summary>
        public int? AcceptBy { get; set; }
    }
}
