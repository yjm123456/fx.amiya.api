using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalPartakeItem
{
    public class PartakeHospitalInfoVo
    {
        public int HospitalId { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图片url
        /// </summary>
        public string ThumbPicUrl { get; set; }


        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 直播价
        /// </summary>
        public decimal LivingPrice { get; set; }
        /// <summary>
        /// 是否同意直播价
        /// </summary>
        public bool IsAgreeLivingPrice { get; set; }
        /// <summary>
        /// 医院提报价格
        /// </summary>
        public decimal HospitalPrice { get; set; }

    }
}
