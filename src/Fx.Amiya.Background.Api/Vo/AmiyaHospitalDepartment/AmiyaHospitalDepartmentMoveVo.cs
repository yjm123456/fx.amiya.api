using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaHospitalDepartment
{
    /// <summary>
    /// 医院科室移动基础类
    /// </summary>
    public class AmiyaHospitalDepartmentMoveVo
    {
        /// <summary>
        /// 医院科室编号
        /// </summary>
        [Required]
        public string Id { get; set; }
        /// <summary>
        /// 移动方式：【上下移时：true为上移，false为下移；置顶置底时：true为置顶，false为置底】
        /// </summary>
        [Required]
        public bool MoveState { get; set; }
    }
}
