using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.WareHouse.InventoryList
{
    public class InventoryListExportVo
    {

        /// <summary>
        /// 物料名称
        /// </summary>
        [Description("物料名称")]
        public string GoodsName { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Description("单位")]
        public string Unit { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        [Description("仓库")]
        public string WareHouseName { get; set; }
        /// <summary>
        /// 货架
        /// </summary>
        [Description("货架")]
        public string StorageRacksName { get; set; }

        /// <summary>
        /// 盘库状态文本
        /// </summary>
        [Description("盘库状态")]
        public string InventoryStateText { get; set; }

        /// <summary>
        /// 盈亏总量；正则红色展示，平则正常展示，负责绿色展示
        /// </summary>
        [Description("盈亏总量")]
        public int InventoryNum { get; set; }

        /// <summary>
        /// 盈亏总金额：正则红色展示，平则正常展示，负责绿色展示
        /// </summary>
        [Description("盈亏总金额")]
        public decimal InventoryPrice { get; set; }

        /// <summary>
        /// 盘前单价
        /// </summary>
        [Description("盘前单价")]
        public decimal BeforeInventorySinglePrice { get; set; }

        /// <summary>
        /// 盘前数量
        /// </summary>
        [Description("盘前数量")]
        public int BeforeInventoryNum { get; set; }

        /// <summary>
        /// 盘前总价
        /// </summary>
        [Description("盘前总价")]
        public decimal BeforeInventoryAllPrice { get; set; }
        /// <summary>
        /// 盘后单价
        /// </summary>
        [Description("盘后单价")]
        public decimal AfterInventorySinglePrice { get; set; }

        /// <summary>
        /// 盘后数量
        /// </summary>
        [Description("盘后数量")]
        public int AfterInventoryNum { get; set; }

        /// <summary>
        /// 盘后总价
        /// </summary>
        [Description("盘后总价")]
        public decimal AfterInventoryAllPrice { get; set; }

        /// <summary>
        /// 操作人员
        /// </summary>
        [Description("操作人员")]
        public string CreateByEmpName { get; set; }

        /// <summary>
        /// 盘库时间
        /// </summary>
        [Description("盘库时间")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; }
    }
}
