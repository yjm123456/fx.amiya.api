using Fx.Amiya.Dto.HospitalPartakeItem;
using Fx.Amiya.Dto.ItemInfo;
using Fx.Amiya.Dto.ReconciliationDocuments;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IReconciliationDocumentsService
    {
        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="returnBackPricePercent">返款比例</param>
        /// <param name="reconciliationState">对账单状态（0：已提交，1:待确认,2:问题账单,3:对账完成）</param>
        /// <param name="startDealDate">成交时间（开始）</param>
        /// <param name="endDealDate">成交时间（结束）</param>
        /// <param name="keyword">关键词（客户姓名，手机号）</param>
        /// <param name="isCreateBill">是否开票</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ReconciliationDocumentsDto>> GetListWithPageAsync(decimal? returnBackPricePercent, int? reconciliationState, DateTime? startDate, DateTime? endDate, DateTime? startDealDate, DateTime? endDealDate, string keyword, int? hospitalId, bool? isCreateBill, int pageNum, int pageSize);

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="returnBackPricePercent"></param>
        /// <param name="reconciliationState"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="startDealDate"></param>
        /// <param name="endDealDate"></param>
        /// <param name="keyword"></param>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>

        Task<List<ReconciliationDocumentsDto>> ExportListWithPageAsync(decimal? returnBackPricePercent, int? reconciliationState, DateTime? startDate, DateTime? endDate, DateTime? startDealDate, DateTime? endDealDate, string keyword, int? hospitalId,bool? isCreateBill);
        /// <summary>
        /// 根据活动编号获取医院参与的项目
        /// </summary>
        /// <param name="addDtoList"></param>
        /// <returns></returns>
        Task AddAsync(List<AddReconciliationDocumentsDto> addDtoList);

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ReconciliationDocumentsDto> GetByIdAsync(string id);

        /// <summary>
        /// 根据发票号获取对账单
        /// </summary>
        /// <param name="billId"></param>
        /// <returns></returns>
        Task<List<ReconciliationDocumentsDto>> GetByBillIdListAsync(string billId);

        /// <summary>
        /// 根据对账单编号获取累计审核服务费
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<decimal> GetTotalCheckPriceAsync(string id);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateReconciliationDocumentsDto updateDto);

        /// <summary>
        /// 标记对账单状态（1:待确认,2:问题账单,3:对账完成）
        /// </summary>
        /// <param name="idList"></param>
        /// <param name="reconciliationState"></param>
        /// <param name="questionReason">当标记为问题账单时必填</param>
        /// <returns></returns>
        Task TagReconciliationStateAsync(List<string> idList, int reconciliationState, string questionReason);

        /// <summary>
        /// 对账单批量开票/作废发票
        /// </summary>
        /// <param name="reconciliationDocumentsCreateBillDto"></param>
        /// <returns></returns>
        Task ReconciliationDocumentsCreateBillAsync(ReconciliationDocumentsCreateBillDto reconciliationDocumentsCreateBillDto);

        /// <summary>
        /// 对账单批量回款
        /// </summary>
        /// <param name="reconciliationDocumentsReturnBackPriceDto"></param>
        /// <returns></returns>
        Task TagReconciliationStateAsync(ReconciliationDocumentsReturnBackPriceDto reconciliationDocumentsReturnBackPriceDto);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        Task DeleteAsync(List<string> idList);

        /// <summary>
        /// 根据对账单id获取对账详情列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<RecommandDocumentSettleDto>> GetRecommandDocumentSettleListAsync(List<string> ids);

        //#region 【对账单审核记录操作】
        ///// <summary>
        ///// 分页获取审核记录数据
        ///// </summary>
        ///// <param name="startDate"></param>
        ///// <param name="endDate"></param>
        ///// <param name="isSettle"></param>
        ///// <param name="accountType"></param>
        ///// <param name="chooseHospitalId">选中医院id（0查询）维多连天美之外的</param>
        ///// <param name="keyword"></param>
        ///// <param name="pageNum"></param>
        ///// <param name="pageSize"></param>
        ///// <returns></returns>
        //Task<FxPageInfo<RecommandDocumentSettleDto>> GetSettleListByPageAsync(DateTime? startDate, DateTime? endDate, bool? isSettle, bool? accountType, int chooseHospitalId, string keyword, int pageNum, int pageSize);

        ///// <summary>
        ///// 导出审核记录数据
        ///// </summary>
        ///// <param name="startDate"></param>
        ///// <param name="endDate"></param>
        ///// <param name="isSettle"></param>
        ///// <param name="accountType"></param>
        ///// <param name="keyword"></param>
        ///// <returns></returns>
        //Task<List<RecommandDocumentSettleDto>> ExportSettleListByPageAsync(DateTime? startDate, DateTime? endDate, bool? isSettle, bool? accountType, string keyword, bool isHidePhone);
        //#endregion
    }
}
