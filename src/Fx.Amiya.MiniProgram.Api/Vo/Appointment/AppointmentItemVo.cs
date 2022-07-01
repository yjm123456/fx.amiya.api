using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Appointment
{
    public class AppointmentItemVo
    {

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 项目简介
        /// </summary>
        public string ItemDescription { get; set; }


        /// <summary>
        /// 项目规格
        /// </summary>
        public string Standard { get; set; }


        /// <summary>
        /// 部位
        /// </summary>
        public string Parts { get; set; }
    }
}
