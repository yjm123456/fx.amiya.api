using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Gift
{
    public class ReceiveGiftVo
    {
        public int Id { get; set; }
        public int GiftId { get; set; }
        public string GiftName { get; set; }
        public string ThumbPicUrl { get; set; }
        public string CustomerId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ReceiveName { get; set; }
        public string ReceivePhone { get; set; }

        /// <summary>
        /// 领取时间
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 快递单号
        /// </summary>
        public string CourierNumber { get; set; }
        public string ExpressId { get; set; }
        /// <summary>
        /// 物流公司
        /// </summary>
        public string ExpressName { get; set; }
        public int Quantity { get; set; }
        public bool IsSendGoods { get; set; }
        public int? SendGoodsBy { get; set; }
        public string SendGoodsName { get; set; }
        public DateTime? SendGoodsDate { get; set; }

        public string OrderId { get; set; }
        public string GoodsThumbPicUrl { get; set; }
        public string GoodsName { get; set; }
        public decimal? ActualPayment { get; set; }

        /// <summary>
        /// 淘宝昵称
        /// </summary>
        public string TbBuyerNick { get; set; }
        /// <summary>
        /// 礼品类别
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 发放类型
        /// </summary>
        public string SendType { get; set; }
    }
}
