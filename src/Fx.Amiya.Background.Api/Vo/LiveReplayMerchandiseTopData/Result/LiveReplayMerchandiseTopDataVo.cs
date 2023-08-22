using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveReplayMerchandiseTopData.Result
{
    public class LiveReplayMerchandiseTopDataVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 复盘主表id
        /// </summary>
        public string LiveReplayId { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ItemName { get; set; }
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

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }

    /// <summary>
    /// 成交量自动填写相关参数
    /// </summary>
    public class AutoWriteInteractionlDataVo
    {
        /// <summary>
        /// 同比数据获取
        /// </summary>
        public List<LiveReplayMerchandiseTopDataVo> LiveReplayInfoInteractionlDataVoList{ get;set;}
    }
}
