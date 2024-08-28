using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class HospitalContentplatformCode : BaseDbModel
    {
        /// <summary>
        /// 三方平台Id
        /// </summary>
        public string ThirdPartContentplatformInfoId { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
        public HospitalInfo HospitalInfo { get; set; }

        public ThirdPartContentplatformInfo ThirdPartContentplatformInfo { get; set; }
    }
}
