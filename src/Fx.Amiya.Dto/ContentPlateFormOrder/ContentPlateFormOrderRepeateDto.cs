using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlateFormOrder
{
    public class ContentPlateFormOrderRepeateDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        public string RepeatePictureUrl { get; set; }
        /// <summary>
        /// 是否到院
        /// </summary>
        public bool IsToHospital { get; set; }

        /// <summary>
        /// 到院时间
        /// </summary>
        public DateTime ToHospitalDate { get; set; }
    }
}
