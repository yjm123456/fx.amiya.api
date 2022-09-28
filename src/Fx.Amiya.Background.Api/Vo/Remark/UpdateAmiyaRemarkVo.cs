using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Remark
{
    /// <summary>
    /// 添加优秀机构啊
    /// </summary>
    public class UpdateAmiyaRemarkVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 批注
        /// </summary>
        public string Remark { get; set; }
    }
}
