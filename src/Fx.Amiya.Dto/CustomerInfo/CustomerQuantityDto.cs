using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.CustomerInfo
{
   public class CustomerQuantityDto
    {
        /// <summary>
        /// 绑定客服客户数量
        /// </summary>
        public int BindCustomerServiceTotalQuantity { get; set; }
        /// <summary>
        /// 今天绑定客服客户数量
        /// </summary>
        public int TodayBindCustomerServiceQuantity { get; set; }

        /// <summary>
        /// 已注册小程序客户数量
        /// </summary>
        public int MiniProgramCustomerTotalQuantity { get; set; }

        /// <summary>
        /// 未注册小程序客户数量
        /// </summary>
        public int UnMiniProgramCustomerTotalQuantity { get; set; }
    }
}
