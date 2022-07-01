using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Permission
{
   public class RouteDto
    {
        public int CategoryId{ get; set; }
        public int MosuleId { get; set; }
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
        public int Sort { get; set; }
    }
}
