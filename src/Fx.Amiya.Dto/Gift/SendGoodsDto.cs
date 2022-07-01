using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Gift
{
   public class SendGoodsDto
    {
        public int Id { get; set; }
        public string CourierNumber { get; set; }
        /// <summary>
        /// 物流公司编号
        /// </summary>
        public string ExpressId { get; set; }
    }
}
