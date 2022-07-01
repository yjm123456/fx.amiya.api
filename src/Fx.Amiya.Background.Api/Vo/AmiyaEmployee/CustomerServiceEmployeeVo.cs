using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaEmployee
{
    public class CustomerServiceEmployeeVo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }

        /// <summary>
        /// 绑定客户人数
        /// </summary>
        public int BindCustomerQuantity { get; set; }

        /// <summary>
        /// 绑定订单数
        /// </summary>
        public int BindOrderQuantity { get; set; }
    }
}
