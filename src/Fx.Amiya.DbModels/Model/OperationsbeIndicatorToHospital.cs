using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 运营指标派发医院
    /// </summary>
    public class OperationsbeIndicatorToHospital
    {
        public string Id { get; set; }
        /// <summary>
        /// 运营指标id
        /// </summary>
        public string OperationsbeIndicatorId { get; set; }
        /// <summary>
        /// 派发医院id
        /// </summary>
        public int HospitalId { get; set; }
        public HospitalInfo HospitalInfo { get; set; }
        public HospitalOperationsbeIndicator HospitalOperationsbeIndicator { get; set; }
    }
}
