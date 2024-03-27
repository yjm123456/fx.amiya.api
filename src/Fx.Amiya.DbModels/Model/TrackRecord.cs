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
        public string   TrackPicture1 { get; set; }
        public string TrackPicture2 { get; set; }
        public string TrackPicture3 { get; set; }
        public string ShoppingCartRegistionId { get; set; }
        public TrackType TrackType { get; set; }
        public TrackTool TrackTool { get; set; }
        public AmiyaEmployee AmiyaEmployee { get; set; }
        public TrackTheme TrackThemeInfo { get; set; }

        public WaitTrackCustomer WaitTrackCustomer { get; set; }
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
    }
}
