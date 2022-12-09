using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalCustomerInfo
{
    public class SendHospitalCustomerInfoDto:BaseDto
    {
        /// <summary>
        /// 客户手机号
        /// </summary>
        public string CustomerPhone { get; set; }

        /// <summary>
        /// 是否为我来跟进
        /// </summary>
        public bool IsMyFollow { get; set; }

        /// <summary>
        /// 客户昵称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>

        public int hospitalId { get; set; }
        /// <summary>
        /// 查重时间
        /// </summary>
        public DateTime? ConfirmOrderDate { get; set; }

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
