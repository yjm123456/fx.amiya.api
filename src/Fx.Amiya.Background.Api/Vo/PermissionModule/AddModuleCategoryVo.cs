using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.PermissionModule
{
    public class AddModuleCategoryVo
    {
        /// <summary>
        /// 分类名称（一级菜单）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }
    }
}
