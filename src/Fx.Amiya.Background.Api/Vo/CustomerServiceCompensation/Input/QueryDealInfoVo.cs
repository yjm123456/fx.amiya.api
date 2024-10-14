using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerServiceCompensation.Input
{
    public class QueryDealInfoVo:BaseQueryVo
    {
        /// <summary>
        /// 上传人
        /// </summary>
        public int? CreateBy { get; set; }
        /// <summary>
        /// 归属客服
        /// </summary>
        public int? BelongEmpId { get; set; }
    }
}
