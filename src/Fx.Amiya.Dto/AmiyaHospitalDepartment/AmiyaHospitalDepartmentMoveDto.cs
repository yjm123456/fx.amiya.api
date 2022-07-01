using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaHospitalDepartment
{
    /// <summary>
    /// 
    /// </summary>
    public class AmiyaHospitalDepartmentMoveDto
    {
        /// <summary>
        /// 医院科室编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 移动方式：【上下移时：true为上移，false为下移；置顶置底时：true为置顶，false为置底】
        /// </summary>
        public bool MoveState { get; set; }
    }
}
