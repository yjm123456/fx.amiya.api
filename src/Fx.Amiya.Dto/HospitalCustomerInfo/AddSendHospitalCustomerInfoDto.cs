using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalCustomerInfo
{
    public class AddSendHospitalCustomerInfoDto
    {
        /// <summary>
        /// 客户手机号
        /// </summary>
        public string CustomerPhone { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>

        public int hospitalId { get; set; }

        /// <summary>
        /// 最新项目需求
        /// </summary>
        public string NewGoodsDemand { get; set; }

        /// <summary>
        /// 派单量
        /// </summary>
        public int SendAmount { get; set; }

        /// <summary>
        /// 成交量
        /// </summary>
        public int DealAmount { get; set; }
    }
}
