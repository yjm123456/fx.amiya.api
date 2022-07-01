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
        public List<AddWaitTrackCustomerDto> AddWaitTrackCustomer { get; set; }
    }
}
