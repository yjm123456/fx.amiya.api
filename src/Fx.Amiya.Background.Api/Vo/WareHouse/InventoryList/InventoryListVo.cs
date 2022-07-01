using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.WareHouse.InventoryList
{
    public class InventoryListVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 物品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public string WareHouseName { get; set; }

        /// <summary>
        /// 盘库状态文本
        /// </summary>
        public string InventoryStateText { get; set; }

        /// <summary>
        /// 盈亏总量；正则红色展示，平则正常展示，负责绿色展示
        /// </summary>
        public int InventoryNum { get; set; }

        /// <summary>
        /// 盈亏总金额：正则红色展示，平则正常展示，负责绿色展示
        /// </summary>
        public decimal InventoryPrice { get; set; }

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
        /// 盘库人姓名
        /// </summary>
        public string CreateByEmpName { get; set; }

        /// <summary>
        /// 盘库时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
