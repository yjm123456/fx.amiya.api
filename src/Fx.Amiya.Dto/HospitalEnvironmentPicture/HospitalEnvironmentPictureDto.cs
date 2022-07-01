using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalEnvironmentPicture
{
    public class HospitalEnvironmentPictureDto
    {
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 医院环境id
        /// </summary>
        public string HospitalEnvironmentId { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string PictureUrl { get; set; }
    }
}
