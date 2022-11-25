using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalDoctorOperation
{
    public class AddHospitalDoctorOperationVo
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
        /// 科室
        /// </summary>
        [Description("科室")]
        public string SectionOffice { get; set; }
        /// <summary>
        /// 医生名称
        /// </summary>
        [Description("医生名称")]
        public string DoctorName { get; set; }
        /// <summary>
        /// 新客接诊人数
        /// </summary>
        [Description("新客接诊人数")]
        public int NewCustomerAcceptNum { get; set; }
        /// <summary>
        /// 新客成交人数
        /// </summary>
        [Description("新客成交人数")]
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
        public decimal NewCustomerAchievement { get; set; }
        /// <summary>
        /// 新客客单价
        /// </summary>
        [Description("新客客单价")]
        public decimal NewCustomerUnitPrice { get; set; }
        /// <summary>
        /// 新客业绩占比
        /// </summary>
        [Description("新客业绩占比")]
        public decimal NewCustomerAchievementRate { get; set; }
        /// <summary>
        /// 老客接诊人数
        /// </summary>
        [Description("老客接诊人数")]
        public int OldCustomerAcceptNum { get; set; }
        /// <summary>
        /// 老客成交人数
        /// </summary>
        [Description("老客成交人数")]
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
        public decimal OldCustomerAchievement { get; set; }
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
        public decimal TotalPerformance { get; set; }
    }
}
