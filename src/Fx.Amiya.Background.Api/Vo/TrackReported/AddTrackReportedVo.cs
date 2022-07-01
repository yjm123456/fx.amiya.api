using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TrackReported
{
    public class AddTrackReportedVo
    {
        /// <summary>
        /// 客户电话
        /// </summary>
        public string Phone { get; set; }


        /// <summary>
        /// 提报内容
        /// </summary>
        public string SendContent { get; set; }

        /// <summary>
        /// 提报医院id
        /// </summary>
        public int SendHospitalId { get; set; }

    }
}
