using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 机构运营指标
    /// </summary>
    public class HospitalOperationalIndicator : BaseDbModel
    {
        public string Name { get; set; }
        public string Describe { get; set; }
        public DateTime StartDate { get; set; }
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
        public List<IndicatorSendHospital> IndicatorSendHospitalList { get; set; }

        public List<GreatHospitalOperationHealth> GreatHospitalOperationHealthList { get; set; }
        public List<HospitalOperationData> HospitalOperationDataList { get; set; }

        public List<HospitalNetWorkConsulationOperationData> HospitalNetWorkConsulationOperationDataList { get; set; }
        public List<HospitalConsulationOperationData> HospitalConsulationOperationDataList { get; set; }

        public List<HospitalDoctorOperationData> HospitalDoctorOperationDataList { get; set; }
        public List<HospitalDealItem> HospitalDealItemList { get; set; }
        public List<HospitalImprovePlanRemark> HospitalImprovePlanRemarkList { get; set; }
    }
}
