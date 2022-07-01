using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class LiveRequirementInfo
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public int LiveAnchorId { get; set; }
        public int LiveTypeId { get; set; }
        public int RequirementTypeId { get; set; }
        public string FansInfo { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public byte PriorityLevel { get; set; }
        public byte Status { get; set; }
        public DateTime? ResponseDate { get; set; }
        public string  ResponseRemark { get; set; }
        public int?  ResponseBy { get; set; }
        public DateTime? DecideDate { get; set; }
        public int? DecideBy { get; set; }
        public string DecideRemark { get; set; }
        public DateTime? ExecuteDate { get; set; }
        public string ExecuteRemark { get; set; }
        public int? ExecuteBy { get; set; }

        public LiveAnchor LiveAnchor { get; set; }
        public LiveType LiveType { get; set; }
        public RequirementType RequirementType { get; set; }
        public AmiyaDepartment AmiyaDepartment { get; set; }
        public AmiyaEmployee CreateAmiyaEmployee { get; set; }
        public AmiyaEmployee ResponseEmployee { get; set; }
        public AmiyaEmployee DecideEmployee { get; set; }
        public AmiyaEmployee ExecuteEmployee { get; set; }

    }
}
