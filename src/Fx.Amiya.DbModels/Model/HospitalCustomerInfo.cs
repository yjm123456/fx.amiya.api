using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class HospitalCustomerInfo : BaseDbModel
    {
        /// <summary>
        /// 客户手机号
        /// </summary>
        public string CustomerPhone { get; set; }

        /// <summary>
        /// 查重时间
        /// </summary>
        public DateTime? ConfirmOrderDate { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>

        public int hospitalId { get; set; }

        /// <summary>
        /// 最新项目需求
        /// </summary>
        public string NewGoodsDemand { get; set; }

        /// <summary>
        /// 派单次数
        /// </summary>
        public int SendAmount { get; set; }

        /// <summary>
        /// 成交次数
        /// </summary>
        public int DealAmount { get; set; }
    }
}
