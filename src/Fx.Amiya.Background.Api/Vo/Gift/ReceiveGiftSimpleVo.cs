using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Gift
{
    public class ReceiveGiftSimpleVo
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

        /// <summary>
        /// 收货人电话
        /// </summary>
        public string ReceivePhone { get; set; }

        /// <summary>
        /// 领取时间
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 是否已发货
        /// </summary>
        public bool IsSendGoods { get; set; }

        /// <summary>
        /// 快递单号
        /// </summary>
        public string CourierNumber { get; set; }

        /// <summary>
        /// 发货时间
        /// </summary>
        public DateTime? SendGoodsDate { get; set; }

        /// <summary>
        /// 绑定订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string CategoryName { get; set; }
    }
}
