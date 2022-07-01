using Fx.Amiya.Dto.CustomerHospitalConsume;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.TmallOrder;
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
        Task<FxPageInfo<CustomerHospitalConsumeDto>> GetListAsync(int? hospitalId, int? channel, int? liveAnchorId, int? buyAgainType, int? employeeId, bool? isConfirmOrder, string keyword, int? consumeType, DateTime startDate,
            DateTime endDate, int checkState, int? addedBy, int pageNum, int pageSize);

        #region 报表相关
        Task<List<CustomerHospitalConsumeDto>> GetCustomerHospitalConsuleReportAsync(int? channel, DateTime? checkDateStart, DateTime? checkDateEnd, int? hospitalId, string customerName, DateTime startDate, DateTime endDate, bool IsHidePhone, int? CheckState);

        #endregion

        #region 【数据中心板块】
        Task<List<OrderPriceConditionDto>> GetOrderDealPriceDataAsync(DateTime startDate, DateTime endDate);
        Task<List<OrderOperationConditionDto>> GetOrderToHospitalDataAsync(DateTime startDate, DateTime endDate);

        Task<List<HospitalOrderNumAndPriceDto>> GetOrderDealPriceAndNumDataAsync(DateTime startDate, DateTime endDate);
        Task<List<OrderPriceConditionDto>> GetCheckForPerformanceDataAsync(DateTime startDate, DateTime endDate);
        Task<List<OrderPriceConditionDto>> GetReturnBackPriceDataAsync(DateTime startDate, DateTime endDate);
        #endregion

        List<CheckStateTypeDto> GetCheckStateType();
    }
}
