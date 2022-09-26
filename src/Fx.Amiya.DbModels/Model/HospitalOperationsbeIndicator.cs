﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 机构运营指标
    /// </summary>
    public class HospitalOperationsbeIndicator:BaseDbModel
    {
        /// <summary>
        /// 指标名称
        /// </summary>
        public string Name { get; set; }
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
        /// 优秀机构
        /// </summary>
        public string ExcellentHospital { get; set; }
        /// <summary>
        /// 优秀机构运营健康指标
        /// </summary>
        public ExcellentHospitalOperationsbe ExcellentHospitalOperationsbe { get; set; }
        /// <summary>
        /// 派发医院
        /// </summary>
        public List<OperationsbeIndicatorToHospital> OperationsbeIndicatorToHospitalList { get; set; }
    }
}
