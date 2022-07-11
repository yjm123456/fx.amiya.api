using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class GoodsShopCar
    {

        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string GoodsId { get; set; }
        public int Num { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public GoodsInfo GoodsInfo { get; set; }

        public CustomerInfo CustomerInfo { get; set; }
    }
}
