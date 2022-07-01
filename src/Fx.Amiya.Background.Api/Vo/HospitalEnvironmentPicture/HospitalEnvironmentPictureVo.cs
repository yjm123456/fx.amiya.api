using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalEnvironmentPicture
{
    /// <summary>
    /// 医院环境图
    /// </summary>
    public class HospitalEnvironmentPictureVo
    {
        /// <summary>
        /// 医院id
        /// </summary>
        public int hospitalId { get; set; }

        /// <summary>
        /// 医院环境id
        /// </summary>
        public string HospitalEnvironmentId { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public List<string> PictureUrl { get; set; }
    }
}
