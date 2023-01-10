using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerInfo
{
    public class AddCustomerTagVo
    {
        public string CustomerId { get; set; }
        /// <summary>
        /// 标签id集合
        /// </summary>
        public List<string> TagIds { get; set; }
    }
}
