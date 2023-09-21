using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalContract.Result
{
    public class HospitalContractInfoVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 合同地址
        /// </summary>
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
