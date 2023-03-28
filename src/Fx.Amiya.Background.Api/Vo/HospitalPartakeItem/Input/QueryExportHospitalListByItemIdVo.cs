using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalPartakeItem.Input
{
    public class QueryExportHospitalListByItemIdVo
    {
        /// <summary>
        /// 活动id
        /// </summary>

        public int? ActivityId { get; set; }
        /// <summary>
        /// 项目id
        /// </summary>
        public int? ItemId { get; set; }
    }
}
