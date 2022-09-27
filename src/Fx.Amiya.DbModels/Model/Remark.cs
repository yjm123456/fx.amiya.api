using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class Remark
    {
        public string Id { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 运营指标id
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// 医院批注
        /// </summary>
        public string HospitalRemark { get; set; }
        /// <summary>
        /// 啊美雅批注
        /// </summary>
        public string AmiyaRemark { get; set; }
    }
}
