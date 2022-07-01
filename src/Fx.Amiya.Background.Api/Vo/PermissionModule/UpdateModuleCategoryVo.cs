using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.PermissionModule
{
    public class UpdateModuleCategoryVo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Valid { get; set; }
        public string Path { get; set; }
    }
}
