using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.BindCustomerService
{
    public class BindCustomerInfoVo
    {
        /// <summary>
        /// 建档时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 首次项目需求
        /// </summary>
        public string FirstProjectDemand { get; set; }
        /// <summary>
        /// 最新消费渠道
        /// </summary>
        public string NewContentPlatForm { get; set; }

        /// <summary>
        /// 加密电话
        /// </summary>
        public string EncryptPhone { get; set; }
        /// <summary>
        /// 绑定客服名称
        /// </summary>
        public string CustomerServiceName { get; set; }
    }
}
