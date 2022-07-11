using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.GoodsShopCar
{
    public class AddGoodsShopCarDto
    {
        /// <summary>
        /// 客户id
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public string GoodsId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 购物车状态
        /// </summary>
        public int Status { get; set; }
    }
}
