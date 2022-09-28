using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalDoctorOperation
{
    public class UpdateHospitalDoctorOperationVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 指标id
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 医生名称
        /// </summary>
        public string DoctorName { get; set; }
        /// <summary>
        /// 新客接诊人数
        /// </summary>
        public int NewCustomerAcceptNum { get; set; }
        /// <summary>
        /// 新客成交人数
        /// </summary>
        public int NewCustomerDealNum { get; set; }
        /// <summary>
        /// 新客成交率
        /// </summary>
        public decimal NewCustomerDealRate { get; set; }
        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal NewCustomerAchievement { get; set; }
        /// <summary>
        /// 新客客单价
        /// </summary>
        public decimal NewCustomerUnitPrice { get; set; }
        /// <summary>
        /// 新客业绩占比
        /// </summary>
        public decimal NewCustomerAchievementRate { get; set; }
        /// <summary>
        /// 老客接诊人数
        /// </summary>
        public int OldCustomerAcceptNum { get; set; }
        /// <summary>
        /// 老客成交人数
        /// </summary>
        public int OldCustomerDealNum { get; set; }
        /// <summary>
        /// 老客成交率
        /// </summary>
        public decimal OldCustomerDealRate { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal OldCustomerAchievement { get; set; }
        /// <summary>
        /// 老客客单价
        /// </summary>
        public decimal OldCustomerUnitPrice { get; set; }
        /// <summary>
        /// 老客业绩占比
        /// </summary>
        public decimal OldCustomerAchievementRate { get; set; }
    }
}
