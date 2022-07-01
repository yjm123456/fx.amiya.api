using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.WareHouse.AmiyaWareHouse
{
    public class InventoryWareHouseVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal SinglePrice { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 领用部门id
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// 领用人id
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
