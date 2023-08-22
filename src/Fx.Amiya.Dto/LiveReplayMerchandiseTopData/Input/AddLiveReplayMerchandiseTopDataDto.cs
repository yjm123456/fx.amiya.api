using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveReplayMerchandiseTopData.Input
{
    public class AddLiveReplayMerchandiseTopDataDto
    {
        /// <summary>
        /// 复盘主表id
        /// </summary>
        public string LiveReplayId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// GMV
        /// </summary>
        public decimal Gmv { get; set; }
        /// <summary>
        /// 商品曝光量
        /// </summary>
        public int MerchandiseShowNum { get; set; }
        /// <summary>
        /// 商品浏览量
        /// </summary>
        public int MerchandiseVisitNum { get; set; }
        /// <summary>
        /// 商品曝光-点击率
        /// </summary>
        public decimal MerchandiseShowVisitRate { get; set; }
        /// <summary>
        /// 创建订单量
        /// </summary>
        public int MerchandiseCreateOrderNum { get; set; }
        /// <summary>
        /// 商品点击-生单转化率
        /// </summary>
        public decimal MerchandiseVisitCreateOrderRate { get; set; }
        /// <summary>
        /// 成交量
        /// </summary>
        public int MerchandiseDealNum { get; set; }
        /// <summary>
        /// 生单-成交转化率
        /// </summary>
        public decimal MerchandiseCreateOrderDealRate { get; set; }
        /// <summary>
        /// 商品问题
        /// </summary>
        public string MerchandiseQuestion { get; set; }
    }
}
