using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalContract.Input
{
    public class UpdateHospitalContractDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ContractUrl { get; set; }
        
        /// <summary>
        /// 合同生效时间
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 合同过期时间
        /// </summary>
        public DateTime? ExpireDate { get; set; }
    }
}
