﻿using Fx.Amiya.Dto;
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
        /// 根据条件获取所有审核记录
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="isSettle"></param>
        /// <param name="accountType"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        Task<List<RecommandDocumentSettleDto>> GetAllAsync(DateTime? startDate, DateTime? endDate, bool? isSettle, bool? accountType, int chooseHospitalId, string keyword);
        /// <summary>
        /// 分页查询待审核助理新增对账单数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<FxPageInfo<RecommandDocumentSettleDto>> GetListWithPageAsync(QueryReconciliationDocumentsSettleDto query);
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
        Task UpdateIsRerturnBackAsync(string Id, DateTime returnBackDate);

        /// <summary>
        /// 审核助理薪资记录
        /// </summary>
        /// <param name="checkDto"></param>
        /// <returns></returns>
        Task CheckAsync(CheckReconciliationDocumentSettleDto checkDto);

        /// <summary>
        /// 生成薪资单编号
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="customerServiceCompensationId"></param>
        /// <returns></returns>
        Task AddCustomerServiceCompensationIdAsync(List<string> ids, string customerServiceCompensationId);

        /// <summary>
        /// 根据薪资单id获取对账单记录
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<FxPageInfo<RecommandDocumentSettleDto>> GetListWithPageByCustomerServiceCompensationIdAsync(QueryReconciliationDocumentsSettleDto query);
        /// <summary>
        /// 获取业绩上传人列表
        /// </summary>
        /// <returns></returns>
        Task<List<BaseIdAndNameDto<int>>> GetCreateEmpNameListAsync();
    }
}
