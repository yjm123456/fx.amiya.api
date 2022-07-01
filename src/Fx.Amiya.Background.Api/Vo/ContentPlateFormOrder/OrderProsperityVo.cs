using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder
{
    public class OrderProsperityVo
    {
        /// <summary>
        /// 医院图片
        /// </summary>
        public string hospitalPicture { get; set; }

        /// <summary>
        /// 主播名称
        /// </summary>
        public string LiveAnchorName { get; set; }

        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 成交时间
        /// </summary>
        public DateTime DealDate { get; set; }
    }
}
