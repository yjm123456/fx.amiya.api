using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalBindCustomerService
{
   public class AddHospitalBindCustomerServiceDto
    {
        /// <summary>
        /// 接单客服
        /// </summary>
        public int HospitalEmployeeId { get; set; }
        /// <summary>
        /// 客户手机号
        /// </summary>

        public string  CustomerPhone { get; set; }
        /// <summary>
        /// 首次项目需求
        /// </summary>
        public string FirstProjectDemand { get; set; }
        /// <summary>
        /// 最新消费平台
        /// </summary>
        public string NewContentPlatformName { get; set; }
    }
}
