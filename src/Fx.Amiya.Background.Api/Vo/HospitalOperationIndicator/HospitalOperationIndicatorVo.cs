﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalOperationIndicator
{
    public class HospitalOperationIndicatorVo:BaseVo
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 优秀机构
        /// </summary>
        public string ExcellentHospital { get; set; }
        /// <summary>
        /// 提报状态
        /// </summary>
        public bool SubmitStatus { get; set; }
        /// <summary>
        /// 批注状态
        /// </summary>
        public bool RemarkStatus { get; set; }
        /// <summary>
        /// 派发医院
        /// </summary>
        public List<HospitalNameList> SendHospital{ get; set; }


    }
}
