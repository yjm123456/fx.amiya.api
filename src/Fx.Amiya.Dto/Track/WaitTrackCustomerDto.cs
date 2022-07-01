using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Track
{
    public class WaitTrackCustomerDto
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string EncryptPhone { get; set; }
        public DateTime PlanTrackDate { get; set; }
        public int? TrackTypeId { get; set; }
        public string TrackTypeName { get; set; }

        /// <summary>
        /// 回访计划
        /// </summary>
        public string TrackPlan { get; set; }
        public int? TrackThemeId { get; set; }
        public string TrackTheme { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public string CreateName { get; set; }
        public bool Status { get; set; }
        public int PlanTrackEmployeeId { get; set; }
        public string PlanTrackEnmployeeName { get; set; }
    }
}
