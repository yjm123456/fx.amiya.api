using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.BindCustomerService
{
    public class AddBindCustomerRFMLevelUpdateLog
    {
        /// <summary>
        /// 绑定客服信息表id
        /// </summary>
        public int BindCustomerServiceId { get; set; }

        /// <summary>
        /// 客服id
        /// </summary>
        public int CustomerServiceId { get; set; }

        /// <summary>
        /// 顾客原等级
        /// </summary>
        public int From { get; set; }
        /// <summary>
        /// 顾客新等级
        /// </summary>
        public int To { get; set; }
    }
}
