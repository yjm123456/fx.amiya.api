using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Permission
{
    public class PermissionCollectionVo
    {
        /// <summary>
        /// 默认启动页路由
        /// 为NULL或者空字符串时，表示没有默认页面
        /// </summary>
        public string DefaultPageRoutePage { get; set; }
        /// <summary>
        /// 菜单集合
        /// </summary>
        public List<MenuVo> Menus { get; set; }
        /// <summary>
        /// 前端路由集合
        /// </summary>
        public List<RouteVo> Routes { get; set; }

        /// <summary>
        /// 权限集合
        /// </summary>
        public List<string> Permissions { get; set; }

    }
}
