using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.BindCustomerService
{
    public class UpdateBindCustomerServiceVo
    {
        /// <summary>
        /// 客服编号
        /// </summary>
        public int CustomerServiceId { get; set; }

        /// <summary>
        /// 加密手机号
        /// </summary>
        public List<string> EncryptPhoneList { get; set; }

    }
}
