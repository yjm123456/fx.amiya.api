using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.WareHouse.AmiyaWareHouse.Input
{
    public class QueryAmiyaOutWareHouseExportVo:BaseQueryVo
    {
        /// <summary>
        /// 关键词
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// 仓库id
        /// </summary>
        public string WareHouseInfoId { get; set; }
    }
}
