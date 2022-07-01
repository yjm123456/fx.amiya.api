using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Track
{
    public class AddTrackVo
    {
        public int WaitTrackId { get; set; }

        [Required(ErrorMessage = "回访内容不能为空")]
        [StringLength(500, ErrorMessage = "回访内容不能超过{1}个字符")]
        public string TrackContent { get; set; }


        [Required(ErrorMessage = "回访主题不能为空")]
        public string TrackTheme { get; set; }

        public int TrackTypeId { get; set; }
        public int TrackToolId { get; set; }
        public bool Valid { get; set; }
        public string CallRecordId { get;set; }

        public AddWaitTrackCustomerVo AddWaitTrackCustomer { get; set; }
    }
}
