using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalEnvironment
{
    /// <summary>
    /// 医院环境新增
    /// </summary>
    public class HospitalEnvironmentAddVo
    {

        /// <summary>
        /// 环境名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid{ get; set; }
    }
}
