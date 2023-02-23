using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.Core.Infrastructure;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Interfaces.Goods
{
    public interface IGoodsInfo
    {
        /// <summary>
        /// 获取所有商品列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="categoryId">商品分类编号</param>
        /// <param name="valid"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<GoodsInfoForListDto>> GetListAsync(string keyword,int?exchangeType, int? categoryId, bool? valid, int pageNum, int pageSize);




        /// <summary>
        /// 根据编号获取商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GoodsInfoForSingleDto> GetByIdAsync(string id);


        /// <summary>
        /// 添加商品信息
        /// </summary>
        /// <param name="goodsInfoAdd"></param>
        /// <returns></returns>
        Task AddAsync(GoodsInfoAddDto goodsInfoAdd);

        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="goodsInfoUpdate"></param>
        /// <returns></returns>
        Task UpdateAsync(GoodsInfoUpdateDto goodsInfoUpdate);


        /// <summary>
        /// 删除商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);


        /// <summary>
        /// 修改商品信息是否有效
        /// </summary>
        /// <param name="id"></param>
        /// <param name="valid"></param>
        /// <returns></returns>
        Task UpdateValidAsync(string id, bool valid);


        /// <summary>
        /// 加商品库存
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task AddGoodsInventoryQuantityAsync(string id, int quantity);



        /// <summary>
        /// 减商品库存
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task ReductionGoodsInventoryQuantityAsync(string id, int quantity);


        /// <summary>
        /// 根据商品编号获取同商品组的所有商品列表
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
         Task<List<GoodsInfoSimpleDto>> GetGoodsListForGoodsGroupByGoodsIdAsync(string goodsId);


     

        /// <summary>
        /// 获取交易类型列表
        /// </summary>
        /// <returns></returns>
        List<ExchangeTypeDto> GetExchangeTypeList();
        /// <summary>
        /// 以销量排序获取首页展示商品
        /// </summary>
        /// <returns></returns>
        Task<FxPageInfo<GoodsInfoForListDto>> GetLikeListAsync(bool? valid, int pageNum, int pageSize);
        Task<FxPageInfo<GoodsInfoForListDto>> GetIntegraListAsync(bool? valid, int pageNum, int pageSize);
        /// <summary>
        /// 根据简码获取美肤卡信息
        /// </summary>
        /// <param name="code">简码</param>
        /// <returns></returns>
        Task<GoodsInfoForSingleDto> GetSkinCareByCode(string code);
        /// <summary>
        /// 根据id获取商品分类名称
        /// </summary>
        /// <returns></returns>
        Task<string> GetCategoryByIdAsync(string id);
    }
}
