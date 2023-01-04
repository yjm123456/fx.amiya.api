using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Gift
{
    public class SendGiftBaseInfoVo
    {
        /*public string Id { get; set; }*/
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string ReceiveName { get; set; }
        /// <summary>
        /// 收货人手机号
        /// </summary>
        public string ReceivePhone { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string Address { get; set; }

    }
}
