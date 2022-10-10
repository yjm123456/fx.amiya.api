using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class GreatHospitalDataWrite : BaseDbModel
    {


        /// <summary>
        /// 归属指标id
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// 运营维度名称
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// 运营维度值
        /// </summary>
        public string OperationValue { get; set; }


        public HospitalOperationalIndicator HospitalOperationalIndicator { get; set; }
    }
}
