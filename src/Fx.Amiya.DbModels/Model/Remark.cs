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
        /// <summary>
        /// 类型(0,本机构运营数据分析
        /// 1本机构网咨运营数据分析
        /// 2,本机构咨询师运营数据分析,
        /// 3,本机构医生运营数据分析
        /// 4,本机构成交品项数据分析)
        /// </summary>
        public int Type { get; set; }
    }
}
