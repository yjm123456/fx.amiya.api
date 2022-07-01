using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.WareHouse.InventoryList
{
    public class InventoryListAddDto
    {
        /// <summary>
        /// 库存id
        /// </summary>
        public string WareHouseId { get; set; }
        /// <summary>
        /// 盘前单价
        /// </summary>
        public decimal BeforeInventorySinglePrice { get; set; }

        /// <summary>
        /// 盘前数量
        /// </summary>
        public int BeforeInventoryNum { get; set; }

        /// <summary>
        /// 盘前总价
        /// </summary>
        public decimal BeforeInventoryAllPrice { get; set; }
        /// <summary>
        /// 盘后单价
        /// </summary>
        public decimal AfterInventorySinglePrice { get; set; }

        /// <summary>
        /// 盘后数量
        /// </summary>
        public int AfterInventoryNum { get; set; }

        /// <summary>
        /// 盘后总价
        /// </summary>
        public decimal AfterInventoryAllPrice { get; set; }

        /// <summary>
        /// 盘库人
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
