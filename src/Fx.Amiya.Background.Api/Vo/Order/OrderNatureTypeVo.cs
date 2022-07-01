using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order
{
    /// <summary>
    /// 订单性质获取，下拉框使用
    /// </summary>
    public class OrderNatureTypeVo
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
