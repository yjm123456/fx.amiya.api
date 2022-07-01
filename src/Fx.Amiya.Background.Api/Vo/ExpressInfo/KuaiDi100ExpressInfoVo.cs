using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ExpressInfo
{
    /// <summary>
    /// 快递100返回参数
    /// </summary>
    public class KuaiDi100ExpressInfoVo
    {
        /// <summary>
        /// 快递单号
        /// </summary>
        public string ExpressNo { get; set; }
        /// <summary>
        /// 物流公司
        /// </summary>
        public string ExpressName { get; set; }

        /// <summary>
        /// 快递当前状态
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// 物流详情
        /// </summary>
        public List<KuaiDi100ExpressDetailsVo> ExpressDetailList { get; set; }
    }
}
