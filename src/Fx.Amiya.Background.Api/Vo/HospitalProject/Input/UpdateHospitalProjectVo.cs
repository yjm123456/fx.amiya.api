using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalProject.Input
{
    public class UpdateHospitalProjectVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 合同名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 合同地址
        /// </summary>
        public string ProjectUrl { get; set; }
    }
}
