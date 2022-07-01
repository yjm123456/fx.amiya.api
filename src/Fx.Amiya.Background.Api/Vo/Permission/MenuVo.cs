using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Permission
{
    public class MenuVo
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 菜单描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 菜单路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 父级菜单
        /// </summary>
        public string ParentName { get; set; }
        /// <summary>
        /// 子菜单
        /// 为NULL，表示没有子菜单
        /// </summary>

        public List<SubMenuVo> SubMenus { get; set; }
    }
}
