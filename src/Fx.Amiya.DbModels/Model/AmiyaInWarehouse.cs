using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class AmiyaInWarehouse
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public string WareHouseId { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal SinglePrice { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal AllPrice { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }

        public AmiyaWareHouse WareHouseInfo { get; set; }

        public AmiyaEmployee Employee { get; set; }
    }
}
