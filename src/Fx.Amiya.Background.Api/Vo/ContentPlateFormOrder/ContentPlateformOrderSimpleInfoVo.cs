using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder
{
    public class ContentPlateformOrderSimpleInfoVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 预约医院
        /// </summary>
        public string AppointmentHospital { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderStatus { get; set; }
        ///// <summary>
        ///// 咨询内容
        ///// </summary>
        //public string ConsultContent { get; set; }
        /// <summary>
        /// 派单医院
        /// </summary>
        public string SendHospital { get; set; }
        /// <summary>
        /// 是否到院
        /// </summary>
        public bool IsToHospital { get; set; }
    }
}
