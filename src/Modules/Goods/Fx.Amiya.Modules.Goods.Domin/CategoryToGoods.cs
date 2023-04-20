using Fx.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Goods.Domin
{
    public class CategoryToGoods:IEntity
    {
        public string Id { get; set; }
        public int CategoryId { get; set; }
        public string GoodsId { get; set; }
    }
}
