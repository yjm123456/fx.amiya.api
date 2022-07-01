﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaHospitalDepartment
{
    /// <summary>
    /// 医院科室id和名称（下拉框专用）
    /// </summary>
    public class AmiyaHospitalDepartmentIdAndNameVo
    {
        /// <summary>
        /// 科室编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>

        public string DepartmentName { get; set; }
    }
}
