using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.OrderWriteOff
{
    public class OrderWriteOffAddDto
    {

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string WriteOffOrderId{get;set;}
        /// <summary>
        /// 已核销数量
        /// </summary>
        public int WriteOffAmount { get; set; }
        /// <summary>
        /// 剩余未核销数量
        /// </summary>
        public int OrderLeaseAmount { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>

        public string  WriteOffGoods { get; set; }
    }
}
