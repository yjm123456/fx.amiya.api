using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Permission
{
   public class SubMenuDto
    {
        public int ModuleId { get; set; }
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
        public int Sort { get; set; }
        public int CategoryId { get; set; }
        /// <summary>
        /// 父级菜单
        /// </summary>
        public string ParentName { get; set; }
    }
}
