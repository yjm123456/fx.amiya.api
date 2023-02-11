using Fx.Amiya.Dto.CustomerHospitalConsume;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.ReconciliationDocuments;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.Dto.UpdateCreateBillAndCompany;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ICustomerHospitalConsumeService
    {
        Task AddAsync(AddCustomerHospitalConsumeDto addDto, int hospitalId);

        Task CustomerManageAddAsync(AddCustomerHospitalConsumeDto addDto, int hospitalId);
        Task CustomerManageImportAsync(List<ImportCustomerHospitalConsumeDto> importDto);

        Task CustomerManageUpdateAsync(CustomerManageUpdateconsumeDto updateDto);
        Task CustomerServiceCheckAsync(int Id);
        Task<CustomerHospitalConsumeDto> GetByIdAsync(int Id);
        Task<CustomerHospitalConsumeDto> GetByConsumeIdAsync(string consumeId);
        Task CustomerManageCheckAsync(CustomerManageCheckconsumeDto updateDto);

        Task ReturnBackOrderAsync(ReturnBackOrderDto input);
        /// <summary>
        /// 根据对账单id批量回款
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task ReturnBackOrderByReconciliationDocumentsIdsAsync(ReturnBackOrderDto input);
        Task CustomerManageDeleteAsync(int Id, int enployeeId);

        /// <summary>
        /// 根据加密电话获取客户消费追踪列表
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<CustomerHospitalConsumeDto>> GetListByEncryptPhoneAsync(string encryptPhone, int? hospitalId, int pageNum, int pageSize);

        Task<List<CustomerHospitalConsumeDto>> GetListByPhoneAsync(string encryptPhone);

        List<BuyAgainTypeDto> GetBuyAgainTypeList();

        List<ChannelTypeDto> GetChannelTypeList();

        /// <summary>
        /// 获取客户消费追踪列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="channel">渠道（0：医院，1：天猫，2抖音，3抖音代运营）</param>
        /// <param name="keyword"></param>
        /// <param name="consumeType">消费类型：0=当天其他消费，1=再消费</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<CustomerHospitalConsumeDto>> GetListAsync(int? hospitalId, int? channel, int? liveAnchorId, int? buyAgainType, int? employeeId, bool? isConfirmOrder, DateTime? consumeStartDate, DateTime? consumeEndDate, string keyword, int? consumeType, DateTime? startDate, DateTime? endDate, int checkState, int? addedBy, int pageNum, int pageSize);

        /// <summary>
        /// 根据对账单编号获取升单信息
        /// </summary>
        /// <param name="reconciliationDocumentsId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<CustomerHospitalConsumeDto>> GetByReconciliationDocumentsIdListAsync(string reconciliationDocumentsId, int pageNum, int pageSize);


        /// <summary>
        /// 根据手机号获取客户消费追踪列表
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<CustomerHospitalConsumeDto>> GetListByPhoneAsync(string phone, int pageNum, int pageSize);
        /// <summary>
        /// 更新订单和成交信息开票和开票公司信息
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        Task UpdateCreateBillAndBelongCompany(UpdateCreateBillAndCompanyDto update);

        #region 报表相关
        Task<List<CustomerHospitalConsumeDto>> GetCustomerHospitalConsuleReportAsync(int? channel, DateTime? checkDateStart, DateTime? checkDateEnd, int? CheckState, int? hospitalId, bool? isCreateBill, string belongCompanyId, string customerName, DateTime startDate, DateTime endDate, bool IsHidePhone);

        #endregion

        #region 【数据中心板块】
        Task<List<OrderPriceConditionDto>> GetOrderDealPriceDataAsync(DateTime startDate, DateTime endDate);
        Task<List<OrderOperationConditionDto>> GetOrderToHospitalDataAsync(DateTime startDate, DateTime endDate);

        Task<List<HospitalOrderNumAndPriceDto>> GetOrderDealPriceAndNumDataAsync(DateTime startDate, DateTime endDate);
        Task<List<OrderPriceConditionDto>> GetCheckForPerformanceDataAsync(DateTime startDate, DateTime endDate);
        Task<List<OrderPriceConditionDto>> GetReturnBackPriceDataAsync(DateTime startDate, DateTime endDate);
        #endregion


        #region 【对账单板块】
        Task<List<UnCheckHospitalOrderDto>> GetUnCheckHospitalOrderAsync(DateTime? startDate, DateTime? endDate, int? hospitalId);
        #endregion
        List<CheckStateTypeDto> GetCheckStateType();
    }
}
