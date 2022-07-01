using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.PermissionModule
{
    /// <summary>
    /// 修改职位权限输入类
    /// </summary>
    public class UpdatePositionAuthVo
    {
        /// <summary>
        /// 职位id
        /// </summary>
        [Required]
        public int AmyPositionId { get; set; }

        /// <summary>
        /// 一级菜单id
        /// </summary>
        [Required]
        public int ModuleCategoryId { get; set; }
        /// <summary>
        /// 二级菜单id
        /// </summary>
        [Required]
        public int ModuleId { get; set; }
    }
}
