using Fx.Amiya.Dto.CarouselImage;
using Fx.Amiya.Dto.ReconciliationDocuments;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
   public interface IRecommandDocumentSettleService
    {
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="isSettle"></param>
        /// <param name="accountType"></param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<RecommandDocumentSettleDto>> GetListByPageAsync(DateTime? startDate, DateTime? endDate, bool? isSettle, bool? accountType, string keyword, int pageNum, int pageSize);

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="isSettle"></param>
        /// <param name="accountType"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        Task<List<RecommandDocumentSettleDto>> ExportListByPageAsync(DateTime? startDate, DateTime? endDate, bool? isSettle, bool? accountType, string keyword);
        /// <summary>
        /// 根据对账单获取回款单未回款的数据
        /// </summary>
        /// <param name="recommandDocumentId"></param>
        /// <returns></returns>
        Task<List<RecommandDocumentSettleDto>> GetRecommandDocumentSettleAsync(List<string> recommandDocumentId,bool? isSettle);

        /// <summary>
        /// 审核时加入回款单
        /// </summary>
        /// <param name="addRecommandDocumentSettleDto"></param>
        /// <returns></returns>
        Task AddAsync(AddRecommandDocumentSettleDto addRecommandDocumentSettleDto);

        /// <summary>
        /// 更新回款单状态为“已回款”
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task UpdateIsRerturnBackAsync(string Id);
    }
}
