using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.PermissionModule
{
    /// <summary>
    /// 移动主菜单基础类
    /// </summary>
    public class ModuleCategoryMoveVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 移动方向（true上/顶，false下/底）
        /// </summary>
        public bool MoveState { get; set; }
    }
}
