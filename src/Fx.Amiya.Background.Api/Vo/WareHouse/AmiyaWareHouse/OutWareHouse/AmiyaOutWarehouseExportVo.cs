using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.WareHouse.AmiyaWareHouse.OutWareHouse
{
    public class AmiyaOutWarehouseExportVo
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
        /// 单价
        /// </summary>
        [Description("单价")]
        public decimal SinglePrice { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        [Description("出库数量")]
        public int Num { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        [Description("总价")]
        public decimal AllPrice { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; }
        /// <summary>
        /// 领用部门
        /// </summary>
        [Description("领用部门")]
        public string Department { get; set; }

        /// <summary>
        /// 领用人
        /// </summary>
        [Description("领用人")]
        public string UseEmployee { get; set; }

        /// <summary>
        /// 出库日期
        /// </summary>
        [Description("出库日期")]
        public DateTime CreateDate { get; set; }


        /// <summary>
        /// 操作人员
        /// </summary>
        [Description("操作人员")]
        public string CreateByEmpName { get; set; }
    }
}
