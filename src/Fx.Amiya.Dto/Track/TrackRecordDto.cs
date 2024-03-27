using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Track
{
   public class TrackRecordDto
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string EncryptPhone { get; set; }
        public DateTime TrackDate { get; set; }
        public string TrackContent { get; set; }
        public int? TrackThemeId { get; set; }
        public string TrackTheme { get; set; }
        /// <summary>
        /// 回访计划
        /// </summary>
        public string TrackPlan { get; set; }
        public int TrackTypeId { get; set; }
        public string TrackTypeName { get; set; }
        public int TrackToolId { get; set; }
        public string TrackToolName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public bool Valid { get; set; }
        public string CallRecordId { get; set; }

        /// <summary>
        /// 是否设置了下次回访
        /// </summary>
        public bool IsPlanTrack { get; set; }

        /// <summary>
        /// 下次回访主题
        /// </summary>
        public string PlanTrackTheme { get; set; }
        public string TrackPicture1 { get; set; }
        public string TrackPicture2 { get; set; }
        public string TrackPicture3 { get; set; }
        /// <summary>
        /// 新/老客回访
        /// </summary>
        public bool IsOldCustomerTrack { get; set; }

        /// <summary>
        /// 是否加v
        /// </summary>
        public bool IsAddWechat { get; set; }
        /// <summary>
        /// 未加v原因id
        /// </summary>

        public int UnAddWechatReasonId { get; set; }
        /// <summary>
        /// 未加v原因说明
        /// </summary>
        public string UnAddWechatReason { get; set; }
    }
}
