using Fx.Amiya.Dto;
using Fx.Amiya.Dto.LivingDailyTakeGoods.Input;
using Fx.Amiya.Dto.LivingDailyTakeGoods.OutPut;
using Fx.Amiya.Dto.TakeGoods;
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
        /// <summary>
        /// 获取带货业绩数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="contentPlatformId"></param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        Task<List<TakeGoodsDataDto>> GetTakeGoodsDataAsync(DateTime startDate,DateTime endDate,string contentPlatformId,List<int> liveAnchorIds);

        /// <summary>
        /// 根据主播IP获取单品带货TOP10数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="contentPlatformId"></param>
        /// <param name="liveAnchorId"></param>
        /// <returns></returns>
        Task<List<LivingDailyTakeGoodsDto>> GetTopTakeGoodsDateByLiveAnchorAsync(DateTime startDate, DateTime endDate, string contentPlatformId, int liveAnchorId);

        /// <summary>
        /// 获取当月带货业绩数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="contentPlatformId"></param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        Task<List<LivingDailyTakeGoodsDto>> GetTakeGoodsAnalizeDataAsync(DateTime startDate, DateTime endDate, string contentPlatformId, List<int> liveAnchorIds);
        /// <summary>
        /// 直播中带货数据自动填写
        /// </summary>
        /// <param name="monthTargetId">月目标id</param>
        /// <param name="takeGoodsDate">带货时间</param>
        /// <returns></returns>
        Task<AutoCompleteTakeGoodsGmvDto> AutoCompleteTakeGoodsGmvDataAsync(DateTime takeGoodsDate,string monthTargetId);
        /// <summary>
        /// 导入带货数据
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task ImportTakeGoodsDataAsync(List<LivingDailyTakeGoodsImportDto> import);
    }
}
