using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Track
{
   public class AddTrackRecordDto
    {
        public int? WaitTrackId { get; set; }
        public string EncryptPhone { get; set; }
        public string TrackContent { get; set; }
        public string TrackTheme { get; set; }
        public int TrackToolId { get; set; }

        /// <summary>
        /// 回访计划
        /// </summary>
        public string TrackPlan { get; set; }
        public int TrackTypeId { get; set; }
        public int? TrackThemeId { get; set; }
        public bool Valid { get; set; }
        public string CallRecordId { get; set; }
        /// <summary>
        /// 回访截图1
        /// </summary>
        public string TrackPicture1 { get; set; }
        /// <summary>
        /// 回访截图2
        /// </summary>
        public string TrackPicture2 { get; set; }
        /// <summary>
        /// 回访截图3
        /// </summary>
        public string TrackPicture3 { get; set; }
        public List<AddWaitTrackCustomerDto> AddWaitTrackCustomer { get; set; }
        /// <summary>
        /// 绑定小黄车id
        /// </summary>
        public string ShoppingCartRegistionId { get; set; }
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
