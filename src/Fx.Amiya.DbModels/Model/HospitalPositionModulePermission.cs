using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class HospitalPositionModulePermission
    {
        public int Id { get; set; }
        public int HospitalPositionId { get; set; }
        public int ModuleCategoryId { get; set; }
        public int ModuleId { get; set; }

        public HospitalPositionInfo HospitalPositionInfo { get; set; }
        public ModuleCategory ModuleCategory { get; set; }
        public Module Module { get; set; }
    }
}
