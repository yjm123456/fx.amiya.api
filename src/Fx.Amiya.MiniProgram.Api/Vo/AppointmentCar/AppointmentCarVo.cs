﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.AppointmentCar
{
    public class AppointmentCarVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime AppointmentDate { get; set; }
        /// <summary>
        /// 预约地点
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 预约医院
        /// </summary>
        public string Hospital { get; set; }
        /// <summary>
        /// 预约车型
        /// </summary>
        public int CarType { get; set; }
        /// <summary>
        /// 预约车型文本
        /// </summary>
        public string CarTypeText { get; set; }
        /// <summary>
        /// 抵扣类型
        /// </summary>
        public int ExchageType { get; set; }
        /// <summary>
        /// 抵扣类型文本
        /// </summary>
        public string ExchageTypeText { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 状态文本
        /// </summary>
        public string StatusText { get; set; }
    }
}
