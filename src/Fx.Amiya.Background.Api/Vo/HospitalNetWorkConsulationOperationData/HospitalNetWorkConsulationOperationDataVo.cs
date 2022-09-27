﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalNetWorkConsulationOperationData
{
    public class HospitalNetWorkConsulationOperationDataVo:BaseVo
    {
        /// <summary>
        /// 指标id
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 咨询师名字
        /// </summary>
        public string ConsulationName { get; set; }

        /// <summary>
        /// 派单数
        /// </summary>
        public int SendOrderNum { get; set; }

        /// <summary>
        /// 新客上门数
        /// </summary>
        public int NewCustomerVisitNum { get; set; }

        /// <summary>
        /// 新客上门率
        /// </summary>
        public decimal NewCustomerVisitRate { get; set; }
    }
}
