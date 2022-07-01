using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TmallOrder
{
    public class OrderNatureDto
    {
        /// <summary>
        /// 订单性质key
        /// </summary>
        public byte OrderNature { get; set; }
        /// <summary>
        /// 订单性质value
        /// </summary>
        public string OrderNatureText { get; set; }
    }
}
