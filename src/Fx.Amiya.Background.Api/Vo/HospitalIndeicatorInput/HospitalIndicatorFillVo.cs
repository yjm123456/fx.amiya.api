﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalIndeicatorInput
{
    /// <summary>
    /// 医院指标填报
    /// </summary>
    public class HospitalIndicatorFillVo
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
        /// 指标名称
        /// </summary>
        public string IndicatorName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 批注状态
        /// </summary>
        public bool IsRemark { get; set; }
    }
}
