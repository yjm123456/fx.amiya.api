using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Permission
{
    public class RouteVo
    {
        /// <summary>
        /// 路由名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 路由描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 路由地址
        /// </summary>
        public string Path { get; set; }
    }
}
