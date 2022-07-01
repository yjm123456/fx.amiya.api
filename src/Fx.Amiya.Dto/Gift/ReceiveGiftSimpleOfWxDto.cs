using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Gift
{
   public class ReceiveGiftSimpleOfWxDto
    {
        /// <summary>
        /// 领取礼品编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 礼品编号
        /// </summary>
        public int GiftId { get; set; }

        /// <summary>
        /// 礼品名称
        /// </summary>
        public string GiftName { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        public string ThumbPicUrl { get; set; }
    }
}
