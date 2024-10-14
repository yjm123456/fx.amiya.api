using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerServiceCompensation.Input
{
    public class QueryDealInfoDto:BaseQueryDto
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
