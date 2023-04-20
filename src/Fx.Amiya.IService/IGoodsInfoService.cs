using Fx.Amiya.Dto.GoodsInfo;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IGoodsInfoService
    {
        /// <summary>
        /// 根据关键字和类别搜索商品
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<FxPageInfo<SimpleGoodsInfoDto>> SearchAsync(string keyword,int? categoryId,bool? orderByPrice,bool? orderBySaleCount,int pageNum,int pageSize);

        /// <summary>
        /// 根据商品id集合
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<List<GoodsOrderInfoDto>> GetGoodListByIdsAsync(List<string> ids);
        /// <summary>
        /// 根据标签获取商品信息
        /// </summary>
        /// <param name="tagId">标签id</param>
        /// <param name="appId">归属小程序appid</param>
        /// <param name="sort">排序(0,序号排序,1价格排序,2销量排序)</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<SimpleGoodsInfoDto>> TagSearchAsync(string tagId,string appId, int sort, int pageNum, int pageSize);
    }
}
