using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Valid { get; set; }
        public string Path { get; set; }
        public int ModuleCategoryId { get; set; }
        public int Sort { get; set; }

        public ModuleCategory ModuleCategory { get; set; }
        public List<AmiyaPositionModulePermission> PositionModulePermissionList { get; set; }
        public List<HospitalPositionModulePermission> HospitalPositionModulePermissionList { get; set; }
    }
}
