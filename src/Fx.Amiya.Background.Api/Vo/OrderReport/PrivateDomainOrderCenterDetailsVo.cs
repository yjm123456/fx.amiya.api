using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport
{
    public class PrivateDomainOrderCenterDetailsVo
    {

        /// <summary>
        /// 老客消费业绩
        /// </summary>
        public PrivateDomainAchievement PrivateDomainAchievement { get; set; }

        /// <summary>
        /// 老客复购情况
        /// </summary>
        public List<OldCustomerBuyInfo> OldCustomerBuyInfo { get; set; }

        /// <summary>
        /// 医院复购情况
        /// </summary>
        public List<HospitalOrderAndPriceInfoVo> HospitalOrderAndPriceInfoVo { get; set; }

    }

    public class PrivateDomainAchievement
    {

        /// <summary>
        /// 累计老客业绩
        /// </summary>
        public decimal AllOldCustomerAchievement { get; set; }

        /// <summary>
        /// 老客业绩
        /// </summary>
        public List<OrderPriceConditionVo> OldCustomerAchievement { get; set; }
    }

    public class OldCustomerBuyInfo
    {

        /// <summary>
        /// 客户手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 业绩
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 订单量
        /// </summary>
        public int OrderNum { get; set; }
    }

}
