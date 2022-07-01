using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TrackReported
{
    public class UpdateTrackReportedDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

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
