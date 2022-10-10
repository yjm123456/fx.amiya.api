using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.GreatHospitalDataWrite
{
    public class AddGreatHospitalDataWriteDto
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
    }
}
