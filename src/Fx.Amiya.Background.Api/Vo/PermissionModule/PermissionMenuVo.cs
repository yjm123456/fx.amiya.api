using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.PermissionModule
{
    public class PermissionMenuVo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Valid { get; set; }
        public string Path { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        public List<PermissionModuleVo> ModuleList { get; set; }
    }
}
