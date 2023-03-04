using Fx.Amiya.Dto.FinancialBoard;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IFinancialboardService
    {
        
        /// <summary>
        /// 产出版块主播业绩
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="liveAnchorId"></param>
        /// <returns></returns>
        Task<List<LiveAnchorBoardDataDto>> GetBoardLiveAnchorDataAsync(DateTime? startDate,DateTime? endDate,List<int> liveAnchorId);
        /// <summary>
        /// 财务看板产出板块客服业绩数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="liveAnchorId"></param>
        /// <returns></returns>
        Task<List<CustomerServiceBoardDataDto>> GetBoardCustomerServiceDataAsync(DateTime? startDate, DateTime? endDate, int? customerServiceId);
        /// <summary>
        /// 财务看板产出板块归属客服业绩数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="liveAnchorId"></param>
        /// <returns></returns>
        Task<List<CustomerServiceBoardDataDto>> GetBoardCustomerServiceBelongDataAsync(DateTime? startDate, DateTime? endDate, int? customerServiceId);

        /// <summary>
        /// 医院对账业绩
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<FxPageInfo<FinancialHospitalDealPriceBoardDto>> GetHospitalDealPriceDataAsync(DateTime? startDate, DateTime? endDate, int? hospitalId,int pageNum,int pageSize);
    }
}
