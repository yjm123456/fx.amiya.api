using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerInfo
{
    public class NewCustomerInfoVo
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 加密电话
        /// </summary>

        public string EncryptPhone { get; set; }      
        /// <summary>
        /// 绑定客服编号
        /// </summary>
        public int? CustomerServiceId { get; set; }
        /// <summary>
        /// 绑定客服名称
        /// </summary>
        public string CustomerServiceName { get; set; }

        
    }
}
