using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.LiveRequirementInfo
{
   public class UnConfirmLiveRequirementInfoDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public string CreateName { get; set; }
        public string Anchor { get; set; }
        public int LiveAnchorId { get; set; }
        public int LiveTypeId { get; set; }
        public string LiveTypeName { get; set; }
        public int RequirementTypeId { get; set; }
        public string RequirementTypeName { get; set; }
        public string FansInfo { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public byte PriorityLevel { get; set; }
        public string PriorityLevelText { get; set; }
        public DateTime? ExecuteDate { get; set; }
        public string Executor { get; set; }
        public string ExecuteRemark { get; set; }
        public int? ExecuteBy { get; set; }
        public string ExecuteByName { get; set; }
    }
}
