using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerHospitalDealInfo.Input
{
    public class QueryCustomerHospitalDealInfoPageListDto : BaseQueryDto
    {
        /// <summary>
        /// 类型（0收费，1退费）
        /// </summary>
        public int? Type { get; set; }
        /// <summary>
        /// 消费类型（0=交预交金，1=办卡，2=项目收费，3=划价单收费，4卡类欠款回收，5=欠款回收）
        /// </summary>
        public int? ConsumptionType { get; set; }
        /// <summary>
        /// 退款类型（0=退预交金，1=退卡，2=退项目，3=退划价单,4退多余欠款）
        /// </summary>
        public int? RefundType { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int? HospitalId { get; set; }
    }
}
