using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order.Input
{
    public class QueryExportMiniProgramOrderLlistVo : BaseQueryVo
    {
        /// <summary>
        /// 是否发货
        /// </summary>
        public bool? IsSendGoods { get; set; }
        /// <summary>
        /// 关键词
        /// </summary>
        public string Keyword { get; set; }
    }
}
