using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder
{
    public class ContentPlateFormOrderRepeateVo
    {
        /// <summary>
        /// 派单编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 重单截图
        /// </summary>
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
