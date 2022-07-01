using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class HospitalPositionInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }

        public AmiyaEmployee UpdateByAmiyaEmployee { get; set; }


        public List<HospitalPositionDefaultRoute> HospitalPositionDefaultRouteList { get; set; }
        public List<HospitalPositionModulePermission> HospitalPositionModulePermissionList { get; set; }
        public List<HospitalEmployee> HospitalEmployeeList { get; set; }

    }
}
