using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Gift
{
    public class GiftInfoSimpleVo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbPicUrl { get; set; }

        /// <summary>
        /// 抵扣积分
        /// </summary>
        public decimal Integration { get; set; }

     
        public int Quantity { get; set; }
    }
}
