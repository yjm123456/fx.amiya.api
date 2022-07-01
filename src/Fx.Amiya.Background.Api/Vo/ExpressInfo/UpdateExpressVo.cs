using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ExpressInfo
{
    /// <summary>
    /// 修改物流公司信息
    /// </summary>
    public class UpdateExpressVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
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
