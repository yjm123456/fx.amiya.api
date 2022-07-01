using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.WareHouse.WareHouseInfo
{
    public class AmiyaWareHouseUpdateDto
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

        /// <summary>
        /// 单价
        /// </summary>
        public decimal? SinglePrice { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int? Amount { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal? TotalPrice { get; set; }
        /// <summary>
        /// 领用部门id
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// 领用人id
        /// </summary>
        public int EmployeeId { get; set; }

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
