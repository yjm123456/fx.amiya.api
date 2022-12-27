using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class GoodsStandardsPrice
    {
        public string Id { get; set; }
        /// <summary>
        /// 规格图片
        /// </summary>
        public string StandardsImg { get; set; }
        public string GoodsId { get; set; }
        public string Standards { get; set; }
        public decimal Price { get; set; }
    }
}
