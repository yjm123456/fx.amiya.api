using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Gift
{
    public class AddReceiveGiftVo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 礼品编号
        /// </summary>
        public int GiftId { get; set; }


        /// <summary>
        /// 收货地址编号
        /// </summary>
        public int AddressId { get; set; }


    }
}
