using Fx.Amiya.Dto.GrowthPoints;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IGrowthPointsRecordService
    {
        /// <summary>
        /// 根据customerid分页获取用户成长值记录
        /// </summary>
        /// <param name="customerid"></param>
        /// <returns></returns>
        Task<FxPageInfo<GrowthPointsRecordListInfoDto>> GetGrowthPointsRecordListPageByCustomerId(string customerid,int page,int number);
        /// <summary>
        /// 根据customerid获取用户成长值记录(不分页)
        /// </summary>
        /// <param name="customerid"></param>
        /// <returns></returns>
        Task<List<GrowthPointsRecordListInfoDto>> GetGrowthPointsRecordListByCustomerId(string customerid);
        /// <summary>
        /// 添加用户成长值记录
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Task AddAsync(AddGrowthPointsRecordDto record);
        /// <summary>
        /// 根据orderid获取成长值记录
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        Task<GrowthPointsRecordListInfoDto> GetGrowthPointsRecordByOrderId(string orderid);
    }
}
