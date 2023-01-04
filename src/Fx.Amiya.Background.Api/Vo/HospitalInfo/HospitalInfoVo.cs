using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalInfo
{
    public class HospitalInfoVo
    {
        public int Id { get; set; }

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
        /// 经度
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// 医院电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }

        public int? CityId { get; set; }
        public string City { get; set; }
        public DateTime? DueTime { get; set; }
        public string ContractUrl { get; set; }
        /// <summary>
        /// 可用日期
        /// </summary>
        public string HasUsedTime { get; set; }
        /// <summary>
        /// 归属公司
        /// </summary>
        public string BelongCompany { get; set; }
        /// <summary>
        /// 是否在小程序展示
        /// </summary>
        public bool IsShareInMiniProgram { get; set; }


    }
}
