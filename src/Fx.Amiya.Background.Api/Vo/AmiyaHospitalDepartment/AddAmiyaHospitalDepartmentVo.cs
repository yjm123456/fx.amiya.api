using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaHospitalDepartment
{
    /// <summary>
    /// 新增医院科室
    /// </summary>
    public class AddAmiyaGoodsDemandVo
    {
        /// <summary>
        /// 科室名称
        /// </summary>
        [Required]
        public string DepartmentName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
