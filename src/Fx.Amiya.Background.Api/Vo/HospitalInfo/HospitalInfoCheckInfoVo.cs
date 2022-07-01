using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalInfo
{
    /// <summary>
    /// 医院审核操作
    /// </summary>
    public class HospitalInfoCheckInfoVo
    {
        /// <summary>
        /// 医院编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 审核状态id
        /// </summary>
        public int CheckState { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>
        public string Remark { get; set; }
    }
}
