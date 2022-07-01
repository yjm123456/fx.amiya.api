using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.WareHouse.AmiyaWareHouse
{
    public class AmiyaWareHouseUpdateVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 归属仓库id
        /// </summary>
        public string GoodsSourceId { get; set; }
    }
}
