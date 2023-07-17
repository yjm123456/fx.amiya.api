using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.WareHouse.WareHouseStorageRacks.Input
{

    /// <summary>
    /// 货架查询板块基础类
    /// </summary>
    public class QueryAmiyaWareHouseStorageRacksVo:BaseQueryVo
    {
        /// <summary>
        /// 仓库id
        /// </summary>
        public string WarehouseId { get; set; }
        /// <summary>
        /// 是否有效（默认有效筛选）
        /// </summary>
        public bool? Valid { get; set; }
    }
}
