using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Permission
{
   public class MenuDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
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
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 子菜单
        /// 为NULL，表示没有子菜单
        /// </summary>
        public List<SubMenuDto> SubMenuList{ get; set; }
    }
}
