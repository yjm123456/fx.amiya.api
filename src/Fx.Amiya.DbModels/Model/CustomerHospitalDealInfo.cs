using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class CustomerHospitalDealInfo
    {
        public string Id { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 类型（0收费，1退费）
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 客户手机号
        /// </summary>
        public string CustomerPhone { get; set; }
        /// <summary>
        /// 消费日期
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 货币总额
        /// </summary>
        public decimal TotalCashAmount { get; set; }
        /// <summary>
        /// 消费类型（0=交预交金，1=办卡，2=项目收费，3=划价单收费，4卡类欠款回收，5=欠款回收）
        /// </summary>
        public int ConsumptionType { get; set; }
        /// <summary>
        /// 退款类型（0=退预交金，1=退卡，2=退项目，3=退划价单,4退多余欠款）
        /// </summary>
        public int RefundType { get; set; }
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string MsgId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        public HospitalInfo HospitalInfoData { get; set; }

        public List<CustomerHospitalDealDetails> CustomerHospitalDealDetailsList { get; set; }
    }
}
