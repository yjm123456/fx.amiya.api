using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalInfo
{
    public class UpdateHospitalContractUrlVo
    {
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 合同信息
        /// </summary>
        public string ContractUrl { get; set; }
    }
}
