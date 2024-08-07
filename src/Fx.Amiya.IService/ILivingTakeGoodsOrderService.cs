using Fx.Amiya.Dto;
using Fx.Amiya.Dto.LivingTakeGoodsOrder;
using Fx.Amiya.Dto.LivingTakeGoodsOrder.Input;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ILivingTakeGoodsOrderService
    {
        Task<FxPageInfo<LivingTakeGoodsOrderDto>> GetListByPageAsync(QueryLivingTakeGoodsOrderByPageDto query);
        Task AddLivingTakeGoodsOrderAsync(AddLivingTakeGoodsOrderDto addDto);
        Task UpdateAsync(UpdateLivingTakeGoodsOrderDto updateDto);
        Task<LivingTakeGoodsOrderDto> GetByIdAsync(string id);
        Task DeleteAsync(string id);
        List<BaseIdAndNameDto<int>> GetOrderStatusList();

    }
}
