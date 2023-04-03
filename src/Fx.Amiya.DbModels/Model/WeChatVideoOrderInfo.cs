using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class WeChatVideoOrderInfo:BaseDbModel
    {
        
        public string GoodsName { get; set; }
        public string GoodsId { get; set; }
        public string Phone { get; set; }
        public string StatusCode { get; set; }
        /// <summary>
        /// 价格（商品正常价格）
        /// </summary>
        public decimal? ActualPayment { get; set; }
        /// <summary>
        /// 应收款（优惠后实际价格，财务用）
        /// </summary>
        public decimal? AccountReceivable { get; set; }

        
        public string ThumbPicUrl { get; set; }
        public string BuyerNick { get; set; }
        
        public long? OrderType { get; set; }
        public int? Quantity { get; set; }
        
        /// <summary>
        /// 归属客服
        /// </summary>
        public int BelongEmpId { get; set; }

        public int? BelongLiveAnchorId { get; set; }

        #region  财务审核板块
        /// <summary>
        /// 审核状态
        /// </summary>
        public int? CheckState { get; set; }

        public decimal? CheckPrice { get; set; }
        public DateTime? CheckDate { get; set; }

        public decimal? SettlePrice { get; set; }
        public int? CheckBy { get; set; }
        public string CheckRemark { get; set; }
        public bool IsReturnBackPrice { get; set; }

        public decimal? ReturnBackPrice { get; set; }
        public DateTime? ReturnBackDate { get; set; }

        #endregion
    }
}
