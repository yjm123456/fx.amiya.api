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
    public interface IGoodsCategory
    {
        /// <summary>
        /// 获取商品分类列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="showDirection"></param>
        /// <returns></returns>
        Task<FxPageInfo<GoodsCategoryDto>> GetListAsync(string keyword, string showDirection);

        /// <summary>
        /// 根据编号获取商品分类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GoodsCategoryDto> GetByIdAsync(int id);


        /// <summary>
        /// 获取分类名称列表
        /// </summary>
        /// <param name="valid">是否有效，null：全部</param>
        /// <returns></returns>
        Task<List<GoodsCategoryNameDto>> GetCategoryNameListAsync(bool? valid);


        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <param name="goodsCategoryAdd"></param>
        /// <returns></returns>
        Task AddAsync(GoodsCategoryAddDto goodsCategoryAdd);


        /// <summary>
        /// 修改商品分类
        /// </summary>
        /// <param name="goodsCategoryUpdate"></param>
        /// <returns></returns>
        Task UpdateAsync(GoodsCategoryUpdateDto goodsCategoryUpdate);

        /// <summary>
        /// 移动商品分类
        /// </summary>
        /// <param name="goodsCategoryUpdate"></param>
        /// <returns></returns>
        Task MoveAsync(GoodsCategoryMoveDto goodsCategoryMove);
        /// <summary>
        /// 置顶/底商品分类
        /// </summary>
        /// <param name="goodsCategoryMove"></param>
        /// <returns></returns>
        Task MoveTopOrDownAsync(GoodsCategoryMoveDto goodsCategoryMove);

        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);


        /// <summary>
        /// 获取展示方向列表
        /// </summary>
        /// <returns></returns>
        List<ShowDirectionTypeDto> GetshowDirectionTypeList();
    }
}
