﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalOperationData
{
    /// <summary>
    /// 机构运营数据分析编辑
    /// </summary>
    public class UpdateHospitalOperationDataVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 归属指标id
        /// </summary>
        public string IndicatorsId { get; set; }
        /// <summary>
        /// 运营维度
        /// </summary>
        public string OperationName { get; set; }
        /// <summary>
        /// 上月数据
        /// </summary>
        public decimal LastMonthData { get; set; }
        /// <summary>
        /// 前月数据
        /// </summary>
        public decimal BeforeMonthData { get; set; }

        /// <summary>
        /// 环比
        /// </summary>
        public decimal ChainRatio { get; set; }

        /// <summary>
        /// 优秀机构
        /// </summary>
        public string GreatHospital { get; set; }
    }
}
