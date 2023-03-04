using Fx.Amiya.Dto;
using Fx.Amiya.Dto.TagDetailInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ITagDetailInfoService
    {
        /// <summary>
        /// 添加标签关联
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        public Task AddTagDetailInfoAsync(AddTagDetailInfoDto add);
        /// <summary>
        /// 根据用户或商品id和标签id删除标签关联关系
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tagid"></param>
        /// <returns></returns>
        public Task DeleteAsync(string id, string tagid);
        /// <summary>
        /// 根据商品或用户id删除所有的关联关系
        /// </summary>
        /// <param name="goodsOrCustomerId"></param>
        /// <returns></returns>
        public Task DeleteGoodsTagAsync(string goodsOrCustomerId);
        /// <summary>
        /// 根据用户或商品id获取所有的标签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<List<TagDetailInfoDto>> GetTagNameListAsync(string id);
      
    }
}
