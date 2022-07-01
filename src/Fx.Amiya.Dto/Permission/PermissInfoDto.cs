using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Permission
{
    /// <summary>
    /// 按钮展示
    /// </summary>
    public class PermissInfoDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 描述
        /// </summary>
        public string Desciption { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}
