using Fx.Amiya.Dto.MemberRankPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IGoodsMemberRankPriceService
    {
        /// <summary>
        /// 根据商品id获取对应的会员价格列表
        /// </summary>
        /// <param name="goodsId">商品id</param>
        /// <returns></returns>
        Task<List<GoodsMemberRankPriceDto>> GetMemeberRankPriceByGoodsIdAsync(string goodsId);
        Task AddAsync(GoodsMemberRankPriceAddDto goodsMemberRankPriceAddDto);
        /// <summary>
        /// 根据商品id删除会员价格
        /// </summary>
        /// <param name="goodsId">商品id</param>
        /// <returns></returns>
        Task DeleteByGoodsIdAsync(string goodsId);
    }
}
