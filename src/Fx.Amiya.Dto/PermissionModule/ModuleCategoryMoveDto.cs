using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.PermissionModule
{
    public class ModuleCategoryMoveDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 移动方向（true上，false下）
        /// </summary>
        public bool MoveState { get; set; }
    }
}
