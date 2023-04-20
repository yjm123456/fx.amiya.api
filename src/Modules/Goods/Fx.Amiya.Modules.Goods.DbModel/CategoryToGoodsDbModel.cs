using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text;

namespace Fx.Amiya.Modules.Goods.DbModel
{

    public class CategoryToGoodsDbModel
    {
        
        public string Id { get; set; }
        public int CategoryId { get; set; }
        public string GoodsId { get; set; }
    }
}
