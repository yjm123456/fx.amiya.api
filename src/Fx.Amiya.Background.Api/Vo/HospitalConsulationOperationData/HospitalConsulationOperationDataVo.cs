using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalConsulationOperationData
{
    public class HospitalConsulationOperationDataVo:BaseVo
    {
        /// <summary>
        /// 指标id
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 咨询师名字
        /// </summary>
        public string ConsulationName { get; set; }

        /// <summary>
        /// 派单数
        /// </summary>
        public int SendOrderNum { get; set; }
        /// <summary>
        /// 新客上门数
        /// </summary>

        public int NewCustomerVisitNum { get; set; }

        /// <summary>
        /// 新客上门率
        /// </summary>
        public decimal NewCustomerVisitRate { get; set; }

        /// <summary>
        /// 新客成交数
        /// </summary>

        public int NewCustomerDealNum { get; set; }

        /// <summary>
        /// 新客成交率
        /// </summary>
        public decimal NewCustomerDealRate { get; set; }

        /// <summary>
        /// 新客业绩
        /// </summary>

        public decimal NewCustomerDealPrice { get; set; }

        /// <summary>
        /// 新客客单价
        /// </summary>
        public decimal NewCustomerUnitPrice { get; set; }


        /// <summary>
        /// 老客上门数
        /// </summary>

        public int OldCustomerVisitNum { get; set; }

        /// <summary>
        /// 老客成交数
        /// </summary>

        public int OldCustomerDealNum { get; set; }

        /// <summary>
        /// 老客成交率
        /// </summary>
        public decimal OldCustomerDealRate { get; set; }

        /// <summary>
        /// 老客业绩
        /// </summary>

        public decimal OldCustomerDealPrice { get; set; }

        /// <summary>
        /// 老客客单价
        /// </summary>
        public decimal OldCustomerUnitPrice { get; set; }

        /// <summary>
        /// 老客业绩占比
        /// </summary>
        public decimal OldCustomerAchievementRate { get; set; }

        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal LasttMonthTotalAchievement { get; set; }

    }
}
