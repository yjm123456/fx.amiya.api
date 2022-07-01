using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Permission
{
    public class SubMenuVo
    {
        public int ModuleId{ get; set; }
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
        public int CategoryId { get; set; }
        /// <summary>
        /// 父级菜单
        /// </summary>
        public string ParentName { get; set; }
    }
}
