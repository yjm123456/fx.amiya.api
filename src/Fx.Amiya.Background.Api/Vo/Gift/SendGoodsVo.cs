using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Gift
{
    /// <summary>
    /// 礼品发货
    /// </summary>
    public class SendGoodsVo
    {
        /// <summary>
        /// 礼品编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 快递单号
        /// </summary>
        public string CourierNumber { get; set; }

        /// <summary>
        /// 物流公司编号
        /// </summary>
        public string ExpressId { get; set; }
    }
}
