using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class WaitTrackCustomer
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public DateTime PlanTrackDate { get; set; }
        public string TrackTheme { get; set; }
        public int? TrackTypeId { get; set; }
        public int? TrackThemeId { get; set; }
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 回访计划
        /// </summary>
        public string TrackPlan { get; set; }
        public int CreateBy { get; set; }
        public bool Status { get; set; }
        public int? TrackRecordId { get; set; }
        public int PlanTrackEmployeeId { get; set; }

        public TrackRecord TrackRecord { get; set; }
        public AmiyaEmployee CreateEmployee { get; set; }
        public AmiyaEmployee PlanTrackEmployee { get; set; }
        public TrackType TrackType { get; set; }
        public TrackTheme TrackThemeInfo { get; set; }
    }
}
