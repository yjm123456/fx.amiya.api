using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.WareHouse.WareHouseStorageRacks.Output
{
    /// <summary>
    /// 货架板块输出类
    /// </summary>
    public class AmiyaWareHouseStorageRacksVo:BaseVo
    {
        /// <summary>
        /// 仓库id
        /// </summary>
        public string WareHouseId { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WareHouseName { get; set; }
        /// <summary>
        /// 创建人id
        /// </summary>
        public int CreateBy { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateByEmpName { get; set; }
        /// <summary>
        /// 货架名称
        /// </summary>
        public string Name { get; set; }

    }
}
