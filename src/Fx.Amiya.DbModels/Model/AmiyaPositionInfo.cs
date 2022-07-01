using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class AmiyaPositionInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }
        public bool IsDirector { get; set; }
        public int DepartmentId { get; set; }

        public AmiyaEmployee UpdateByAmiyaEmployee { get; set; }

        public List<AmiyaEmployee> AmiyaEmployeeList { get; set; }
        public List<AmiyaPositionDefaultRoute> PositionDefaultRouteList { get; set; }
        public List<AmiyaPositionModulePermission> PositionModulePermissionList { get; set; }
        public List<AmiyaPositionPermission> AmiyaPositionPermissionList { get; set; }
        public AmiyaDepartment AmiyaDepartment { get; set; }
    }
}
