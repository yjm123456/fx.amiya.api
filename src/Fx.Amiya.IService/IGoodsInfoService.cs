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
    }
}
