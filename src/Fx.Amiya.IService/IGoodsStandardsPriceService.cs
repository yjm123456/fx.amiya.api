using Fx.Amiya.Dto.AmiyaLessonApply;
using Fx.Amiya.Dto.GoodsStandardsPrice;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IGoodsStandardsPriceService
    {
        /// <summary>
        /// 添加商品规格
        /// </summary>
        /// <param name="goodsInfoAdd"></param>
        /// <returns></returns>
        Task AddAsync(GoodsStandardsPriceAddDto goodsInfoAdd);
        /// <summary>
        /// 重置商品规格
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        Task DeleteByGoodsId(string goodsId);

        /// <summary>
        /// 根据商品id获取规格列表
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        Task<List<GoodsStandardsPriceDto>> GetByGoodsId(string goodsId);
        /// <summary>
        /// 根据商品id和规格获取价格
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="standards"></param>
        /// <returns></returns>
        Task<GoodsStandardsPriceDto> GetByGoodsIdAndHospitalId(string goodsId, string standards);
    }
}
