using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.BindCustomerService
{
    public class AddBindCustomerServiceVo
    {
        /// <summary>
        /// 客服编号
        /// </summary>
        public int CustomerServiceId { get; set; }

        /// <summary>
        /// 订单编号集合
        /// </summary>
        public List<string> OrderIdList { get; set; }
    }
}
