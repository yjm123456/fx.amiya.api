using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaHospitalDepartment
{
    /// <summary>
    /// 修改医院科室
    /// </summary>
    public class UpdateAmiyaGoodsDemandVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public string Id { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        [Required]
        public string DepartmentName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 是否正常
        /// </summary>
        [Required]
        public bool Valid { get; set; }
    }
}
