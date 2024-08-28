using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class ThirdPartContentplatformInfo : BaseDbModel
    {
        /// <summary>
        /// 三方平台名称
        /// </summary>
        public string Name { get; set; }

        public List<HospitalContentplatformCode> HospitalContentplatformCodeList { get; set; }
    }
}
