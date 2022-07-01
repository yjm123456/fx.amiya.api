using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.PermissionModule
{
    public class UpdatePositionAuthDto
    { /// <summary>
      /// 职位id
      /// </summary>
        public int AmyPositionId { get; set; }

        /// <summary>
        /// 一级菜单id
        /// </summary>
        public int ModuleCategoryId { get; set; }
        /// <summary>
        /// 二级菜单id
        /// </summary>
        public int ModuleId { get; set; }
    }
}
