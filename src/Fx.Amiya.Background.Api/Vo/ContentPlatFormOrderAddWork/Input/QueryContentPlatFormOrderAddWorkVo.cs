using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlatFormOrderAddWork.Input
{
    public class QueryContentPlatFormOrderAddWorkVo : BaseQueryVo
    {
        /// <summary>
        /// 医院id（空查询所有）
        /// </summary>
        public int? HospitalId { get; set; }
        /// <summary>
        /// 审核状态（空查询所有）
        /// </summary>
        public int? CheckState { get; set; }
    }
}
