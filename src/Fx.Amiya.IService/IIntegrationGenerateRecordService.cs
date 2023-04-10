using Fx.Amiya.Dto.Integration;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IIntegrationGenerateRecordService
    {
        /// <summary>
        /// 获取积分发放记录
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<IntegrationgenerationRecordDto>> GetAllIntegrationgenerationRecordAsync(string keyword, DateTime? startDate, DateTime? endDate, int pageNum,int pageSize);
        /// <summary>
        /// 修改积分发放数量(积分超发时,客服修改积分数量)
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task EditIntegrationRecordAsync(EditIntegrationgenerationDto editIntegrationgenerationDto);
        /// <summary>
        /// 导出积分发放记录
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<List<IntegrationgenerationRecordDto>> ExportIntegrationgenerationRecordAsync(string keyword, DateTime? startDate, DateTime? endDate);
    }
}
