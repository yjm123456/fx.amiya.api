using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class TrackRecord
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public DateTime TrackDate { get; set; }
        public string TrackContent { get; set; }
        public string TrackTheme { get; set; }
        public int TrackTypeId { get; set; }

        /// <summary>
        /// 回访计划
        /// </summary>
        public string TrackPlan { get; set; }
        public int? TrackThemeId { get; set; }
        public int TrackToolId { get; set; }
        public int EmployeeId { get; set; }
        public bool Valid { get; set; }
        public string CallRecordId{get;set;}

       
        public TrackType TrackType { get; set; }
        public TrackTool TrackTool { get; set; }
        public AmiyaEmployee AmiyaEmployee { get; set; }
        public TrackTheme TrackThemeInfo { get; set; }

        public WaitTrackCustomer WaitTrackCustomer { get; set; }
    }
}
