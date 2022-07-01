using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderVerificationInfo
{
    public class OrderVerificationInfoVo
    {
        public int Id { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public long GoodsId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 核销账户
        /// </summary>
        public string Account { get; set; }


        /// <summary>
        /// 核销份数
        /// </summary>
        public int Quantity { get; set; }


        /// <summary>
        /// 核销时间
        /// </summary>
        public DateTime Date { get; set; }
    }
}
