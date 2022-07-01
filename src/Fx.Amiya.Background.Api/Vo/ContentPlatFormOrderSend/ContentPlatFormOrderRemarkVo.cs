using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlatFormOrderSend
{
    /// <summary>
    /// 内容平台订单修改备注
    /// </summary>
    public class ContentPlatFormOrderRemarkVo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public int SendOrderId { get; set; }
        /// <summary>
        /// 医院填写备注
        /// </summary>
        public string HospitalRemark { get; set; }
    }
}
