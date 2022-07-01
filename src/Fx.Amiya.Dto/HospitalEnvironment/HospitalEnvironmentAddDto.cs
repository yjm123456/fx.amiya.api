using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalEnvironment
{
    public class HospitalEnvironmentAddDto
    {

        /// <summary>
        /// 医院环境名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Valid { get; set; }
    }
}
