using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalEnvironment
{
    /// <summary>
    /// 医院环境修改
    /// </summary>
    public class HospitalEnvironmentUpdateVo
    {
        /// <summary>
        /// 环境id
        /// </summary>
        public string  Id { get; set; }

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
