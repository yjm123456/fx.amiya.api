using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.PermissionModule
{
    public class ModuleMoveDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 移动方向（true上/顶，false下/底）
        /// </summary>
        public bool MoveState { get; set; }

        /// <summary>
        /// 主菜单id
        /// </summary>
        public int ModuleCategoryId { get; set; }
    }
}
