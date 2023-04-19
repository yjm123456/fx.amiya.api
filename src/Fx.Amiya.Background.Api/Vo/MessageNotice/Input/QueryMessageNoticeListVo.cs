using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.MessageNotice.Input
{
    public class QueryMessageNoticeListVo : BaseQueryVo
    {
        /// <summary>
        /// 用户
        /// </summary>
        public int? AcceptBy { get; set; }
    }
}
