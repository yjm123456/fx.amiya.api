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
    public class IndicatorSendHospital
    {
        public string Id { get; set; }
        public string IndicatorId { get; set; }
        public int HospitalId { get; set; }
        public bool SubmitStatus { get; set; }
        public bool RemarkStatus { get; set; }
        public HospitalInfo HospitalInfo { get; set; }
        public HospitalOperationalIndicator HospitalOperationalIndicator { get; set; }
    }
}
