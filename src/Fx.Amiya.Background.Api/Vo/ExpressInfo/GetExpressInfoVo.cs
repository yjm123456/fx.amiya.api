using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ExpressInfo
{
    /// <summary>
    /// 根据条件获取物流信息
    /// </summary>
    public class GetExpressInfoVo
    {
        /// <summary>
        /// 快递单号
        /// </summary>
        [Required]
        public string CourierNumber { get; set; }
        /// <summary>
        /// 收货人手机号
        /// </summary>
        public string ReceiverPhone { get; set; }
        /// <summary>
        /// 物流公司id
        /// </summary>
        [Required]
        public string ExpressId { get; set; }
    }
}
