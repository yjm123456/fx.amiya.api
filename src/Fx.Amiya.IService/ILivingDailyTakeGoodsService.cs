using Fx.Amiya.Dto;
using Fx.Amiya.Dto.LivingDailyTakeGoods.Input;
using Fx.Amiya.Dto.LivingDailyTakeGoods.OutPut;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ILivingDailyTakeGoodsService
    {
        Task<FxPageInfo<LivingDailyTakeGoodsDto>> GetListWithPageAsync(QueryLivingDailyTakeGoodsDto query);
        Task AddAsync(LivingDailyTakeGoodsAddDto addDto);
        Task<LivingDailyTakeGoodsDto> GetByIdAsync(string id);
        Task UpdateAsync(LivingDailyTakeGoodsUpdateDto updateDto);
        Task DeleteAsync(string id);
        /// <summary>
        /// 获取带货商品类型下拉框
        /// </summary>
        /// <returns></returns>
        Task<List<BaseKeyValueDto>> GetTakeGoodsTypeAsync();

    }
}
