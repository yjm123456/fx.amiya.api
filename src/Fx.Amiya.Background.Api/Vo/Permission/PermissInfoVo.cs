using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Permission
{
    /// <summary>
    /// 按钮展示
    /// </summary>
    public class PermissInfoVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set;}
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
