using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 机构运营批注
    /// </summary>
    public class Remark:BaseDbModel
    {
        /// <summary>
        /// 医院id
        /// </summary>
        public int? HospitalId { get; set; }
        /// <summary>
        /// 运营指标id
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// 啊美雅批注
        /// </summary>
        public string AmiyaRemark { get; set; }
        /// <summary>
        /// 机构运营数据分析批注
        /// </summary>
        public string HospitalOperationRemark { get; set; }
        /// <summary>
        /// 机构网咨运营数据分析批注
        /// </summary>
        public string HospitalOnlineConsultRemark { get; set; }
        /// <summary>
        /// 机构咨询师运营数据分析批注
        /// </summary>
        public string HospitalConsultRemark { get; set; }
        /// <summary>
        /// 机构医生运营数据分析
        /// </summary>
        public string HospitalDoctorRemark { get; set; }
        /// <summary>
        /// 机构成交品项数据分析批注
        /// </summary>
        public string HospitalDealRemark { get; set; }
        /// <summary>
        /// 啊美雅运营数据分析批注
        /// </summary>
        public string AmiyaOperationRemark { get; set; }
        /// <summary>
        /// 啊美雅网咨运营数据分析批注
        /// </summary>
        public string AmiyaOnlineConsultRemark { get; set; }
        /// <summary>
        /// 啊美雅咨询师运营数据分析批注
        /// </summary>
        public string AmiyaConsultRemark { get; set; }
        /// <summary>
        /// 啊美雅医生运营数据分析
        /// </summary>
        public string AmiyaDoctorRemark { get; set; }
        /// <summary>
        /// 啊美雅成交品项数据分析
        /// </summary>
        public string AmiyaDealRemark { get; set; }
       
    }
}
