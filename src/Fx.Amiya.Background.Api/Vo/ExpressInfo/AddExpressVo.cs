using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ExpressInfo
{
    /// <summary>
    /// 添加物流公司
    /// </summary>
    public class AddExpressVo
    {

        /// <summary>
        /// 物流公司名称
        /// </summary>

        public string ExpressName { get; set; }
        /// <summary>
        /// 物流公司编码
        /// </summary>
        public string ExpressCode { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Valid { get; set; }
    }
}
