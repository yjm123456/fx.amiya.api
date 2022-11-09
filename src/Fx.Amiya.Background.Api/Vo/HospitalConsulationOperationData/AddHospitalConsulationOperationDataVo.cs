using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalConsulationOperationData
{
    public class AddHospitalConsulationOperationDataVo 
    {
        /// <summary>
        /// 指标id
        /// </summary>
        [Description("指标编号")]
        public string IndicatorId { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        [Description("医院编号")]
        public int HospitalId { get; set; }

        /// <summary>
        /// 咨询师名字
        /// </summary>
        [Description("咨询师名字")]
        public string ConsulationName { get; set; }

        /// <summary>
        /// 派单数
        /// </summary>
        [Description("派单数")]
        public int SendOrderNum { get; set; }
        /// <summary>
        /// 新客上门数
        /// </summary>
        [Description("新客上门数")]
        public int NewCustomerVisitNum { get; set; }

        /// <summary>
        /// 新客上门率
        /// </summary>
        [Description("新客上门率")]
        public decimal NewCustomerVisitRate { get; set; }

        /// <summary>
        /// 新客成交数
        /// </summary>
        [Description("新客成交数")]

        public int NewCustomerDealNum { get; set; }

        /// <summary>
        /// 新客成交率
        /// </summary>
        [Description("新客成交率")]
        public decimal NewCustomerDealRate { get; set; }

        /// <summary>
        /// 新客业绩
        /// </summary>

        [Description("新客业绩")]
        public decimal NewCustomerDealPrice { get; set; }

        /// <summary>
        /// 新客客单价
        /// </summary>
        [Description("新客客单价")]
        public decimal NewCustomerUnitPrice { get; set; }


        /// <summary>
        /// 老客上门数
        /// </summary>

        [Description("老客上门数")]
        public int OldCustomerVisitNum { get; set; }

        /// <summary>
        /// 老客成交数
        /// </summary>
        [Description("老客成交数")]

        public int OldCustomerDealNum { get; set; }

        /// <summary>
        /// 老客成交率
        /// </summary>
        [Description("老客成交率")]
        public decimal OldCustomerDealRate { get; set; }

        /// <summary>
        /// 老客业绩
        /// </summary>
        [Description("老客业绩")]

        public decimal OldCustomerDealPrice { get; set; }

        /// <summary>
        /// 老客客单价
        /// </summary>
        [Description("老客客单价")]
        public decimal OldCustomerUnitPrice { get; set; }

        /// <summary>
        /// 老客业绩占比
        /// </summary>
        [Description("老客业绩占比")]
        public decimal OldCustomerAchievementRate { get; set; }

        /// <summary>
        /// 总业绩
        /// </summary>
        [Description("总业绩")]
        public decimal LasttMonthTotalAchievement { get; set; }

    }
}
