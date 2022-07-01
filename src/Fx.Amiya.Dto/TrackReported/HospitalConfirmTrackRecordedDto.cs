using Fx.Amiya.Dto.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TrackReported
{
    public class HospitalConfirmTrackRecordedDto
    {

        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 确认跟进/取消跟进
        /// </summary>
        public bool IsTrackedResult { get; set; }

        /// <summary>
        /// 追踪回访
        /// </summary>
        public AddTrackRecordDto addTrackRecord { get; set; }

        /// <summary>
        /// 医院跟进备注
        /// </summary>
        public string HospitalContent { get; set; }
    }
}
