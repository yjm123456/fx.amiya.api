using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Permission
{
   public class AddPositionPermissionDto
    {
        public int PositionId { get; set; }
        public string DefaultRoute { get; set; }

        public List<int> PermissionIds { get; set; }

        public List<ModuleCategroyePermission> ModuleCategroyePermissionList { get; set; }
    }


    public class ModuleCategroyePermission
    { 
        public int ModuleCategoryId { get; set; }
        public List<int> ModuleIds { get; set; }
    }
}
