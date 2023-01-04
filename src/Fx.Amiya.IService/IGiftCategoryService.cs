using Fx.Amiya.Dto;
using Fx.Amiya.Dto.GiftCategory;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IGiftCategoryService
    {
        Task<FxPageInfo<GiftCategoryInfoDto>> GetListWithPageAsync(int pageNum,int pageSize);
        Task UpdateAsync(UpdateGiftCategoryDto update);
        Task<GiftCategoryInfoDto> GetByIdAsync(string id);
        Task AddAsync(AddGiftCategoryDto add);
        Task DeleteAsync(string id);
        /// <summary>
        /// 获取礼品分类名称列表
        /// </summary>
        /// <returns></returns>
        Task<List<BaseIdAndNameDto>> GetCategoryNameList();
    }
}
