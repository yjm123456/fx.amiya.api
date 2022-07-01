using Fx.Amiya.Background.Api.Vo.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TrackReported
{
    public class HospitalConfirmTrackRecordedVo
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
        public AddTrackRecordVo addTrackRecord { get; set; }

        /// <summary>
        /// 医院跟进备注
        /// </summary>
        public string HospitalContent { get; set; }
    }
}
