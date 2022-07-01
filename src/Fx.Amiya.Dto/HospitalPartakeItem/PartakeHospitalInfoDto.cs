using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalPartakeItem
{
   public class PartakeHospitalInfoDto
    {
        public int HospitalId { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }

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
