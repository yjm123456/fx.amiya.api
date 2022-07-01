using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.WareHouse.OutWareHouse
{
    public class AmiyaOutWareHouseUpdateDto
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
        /// 出库数量
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

    }
}
