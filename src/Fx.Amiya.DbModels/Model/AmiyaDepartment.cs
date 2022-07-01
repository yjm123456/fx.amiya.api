using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class AmiyaDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Valid { get; set; }
        /// <summary>
        /// 是否为处理需求部门
        /// </summary>
        public bool IsProcessingRequirementDepartment { get; set; }


        public List<LiveRequirementInfo> LiveRequirementInfoList { get; set; }
        public List<AmiyaPositionInfo> AmiyaPositionInfoList { get; set; }
        public List<AmiyaOutWarehouse> UseDepartmentInfoList { get; set; }
    }
}
