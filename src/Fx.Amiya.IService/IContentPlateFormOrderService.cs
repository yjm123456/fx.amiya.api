using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IContentPlateFormOrderService
    {

        /// <summary>
        /// 录单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task AddContentPlateFormOrderAsync(ContentPlateFormOrderAddDto input);

        /// <summary>
        /// 分页获取内容平台订单
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="keyword"></param>
        /// <param name="orderStatus"></param>
        /// <param name="contentPlateFormId"></param>
        /// <param name="consultationEmpId">面诊类型</param>
        /// <param name="employeeId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ContentPlatFormOrderInfoDto>> GetOrderListWithPageAsync(int? liveAnchorId, DateTime? startDate, DateTime? endDate, int? belongMonth, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, int? appointmentHospital, int? consultationType, string hospitalDepartmentId, string keyword, int? orderStatus, string contentPlateFormId, int? belongEmpId, int employeeId, int orderSource, int pageNum, int pageSize);

        /// <summary>
        /// 获取内容平台已完成订单
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="liveAnchorId">主播ID</param>
        /// <param name="endDate"></param>
        /// <param name="checkState"></param>
        /// <param name="keyword"></param>
        /// <param name="consultationEmpId">面诊人员</param>
        /// <param name="contentPlateFormId"></param>
        /// <param name="employeeId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ContentPlatFormOrderInfoDto>> GetOrderDealListWithPageAsync(int? liveAnchorId, DateTime? startDate, DateTime? endDate, int? belongMonth, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, int? consultationEmpId, int? checkState, bool? ReturnBackPriceState, string keyword, string contentPlateFormId, int? hospitalId, int? toHospitalType, int employeeId, int pageNum, int pageSize);

        /// <summary>
        /// 内容平台已完成订单报表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="checkState"></param>
        /// <param name="dealHospitalId">成交医院（全部则不传）</param>
        /// <param name="employeeId"></param>
        /// <param name="hidePhone"></param>
        /// <returns></returns>
        Task<List<ContentPlatFormOrderInfoDto>> GetOrderDealAsync(DateTime? startDate, DateTime? endDate, int? belongMonth, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, int? dealHospitalId, int? checkState, int? liveAnchorId, bool hidePhone);

        /// <summary>
        /// 根据条件获取未派单列表
        /// </summary>
        /// <param name="liveAnchorId">归属主播id</param>
        /// <param name="keyword">关键词</param>
        /// <param name="contentPlateFormId">内容平台</param>
        /// <param name="employeeId">员工id（-1查询所有）</param>
        /// <param name="orderStatus">订单状态</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<UnSendContentPlatFormOrderInfoDto>> GetUnSendOrderListWithPageAsync(int? liveAnchorId, string keyword, DateTime? startDate, DateTime? endDate, int? consultationEmpId, int employeeId, int statusCode, string contentPlatFormId, int orderSource, int pageNum, int pageSize);

        /// <summary>
        /// 客服未派单报表
        /// </summary>
        /// <param name="liveAnchorId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="employeeId"></param>
        /// <param name="statusCode"></param>
        /// <param name="contentPlatFormId"></param>
        /// <returns></returns>
        Task<List<UnSendContentPlatFormOrderInfoDto>> GetUnSendOrderReportListAsync(int? liveAnchorId, DateTime? startDate, DateTime? endDate, int employeeId, int statusCode, string contentPlatFormId, bool isHidePhone);
        Task UpdateOrderBelongEmpIdAsync(UpdateBelongEmpInfoOrderDto input);

        /// <summary>
        /// 导出内容平台订单列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="keyword"></param>
        /// <param name="orderStatus"></param>
        /// <param name="contentPlateFormId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<List<ContentPlatFormOrderInfoDto>> ExportOrderListWithPageAsync(DateTime? startDate, DateTime? endDate, int? consultationEmpId, int? appointmentHospital, int? belongEmpId, int? liveAnchorId, string keyword, string hospitalDepartmentId, int? orderStatus, int orderSource, string contentPlateFormId, int employeeId, bool IsHidePhone);

        /// <summary>
        /// 派单
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task SendOrderAsync(AddContentPlatFormSendOrderInfoDto addDto);

        /// <summary>
        /// 修改派单
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateContentPlatFormSendOrderInfoDto updateDto, int employeeId);
        /// <summary>
        /// 判断是否录单决定是否删除订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteOrderAsync(string id);

        /// <summary>
        /// 根据编号获取要修改的内容平台订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<ContentPlateFormOrderUpdateDto> GetByOrderIdAsync(string orderId);

        /// <summary>
        /// 根据订单号查看重单截图
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<string> SelectRepeateOrderPicAsync(string orderId);

        /// <summary>
        /// 根据加密手机号获取简易的订单信息
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ContentPlatFormOrderInfoSimpleDto>> GetListByEncryptPhoneAsync(string encryptPhone, int pageNum, int pageSize);
        /// <summary>
        /// 医院接单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task HospitalConfirmOrderAsync(string orderId, int hospitalId);
        /// <summary>
        ///  医院重单退回
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task RepeateContentPlateFormOrderAsync(ContentPlateFormOrderRepeateDto input,int hospitalEmployeeId);
        Task<List<ContentPlatFormOrderInfoSimpleDto>> GetOrderListByPhoneAsync(string phone);
        /// <summary>
        /// 编辑订单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateContentPlateFormOrderAsync(ContentPlateFormOrderUpdateDto input);

        /// <summary>
        /// 审核订单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CheckContentPlateFormOrderAsync(ContentPlateFormOrderCheckDto input);

        /// <summary>
        /// 订单回款
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task ReturnBackOrderAsync(ReturnBackOrderDto input);

        /// <summary>
        /// 订单只计算回款
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task ReturnBackOrderOnlyAsync(ReturnBackOrderDto input);

        /// <summary>
        /// 派单后修改订单状态并删除重单截图（针对重单再派单）
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task UpdateStateAndRepeateOrderPicAsync(string orderId, int sendBy, int? belongEmpId, int employee);

        /// <summary>
        /// 删除录单的订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);

        /// <summary>
        /// 医院确认订单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task FinishContentPlateFormOrderAsync(ContentPlateFormOrderFinishDto input);

        /// <summary>
        /// 修改订单完成后的信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateFinishContentPlateFormOrderAsync(UpdateContentPlateFormOrderFinishDto input);


        /// <summary>
        /// 获取订单类型
        /// </summary>
        /// <returns></returns>
        List<ContentPlateFormOrderTypeDto> GetOrderTypeList();

        /// <summary>
        /// 获取订单到院状态
        /// </summary>
        /// <returns></returns>
        List<ContentPlateFormOrderTypeDto> GetOrderToHospitalTypeList();
        /// <summary>
        /// 获取下单状态
        /// </summary>
        /// <returns></returns>
        List<ContentPlateFormOrderStatusDto> GetOrderStatusList();

        /// <summary>
        /// 获取已绑定客服的内容平台订单
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="customerServiceId"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<BindCustomerServiceContentPlatformOrderDto>> GetBindCustomerServieContentPlatformOrdersAsync(int? customerServiceId, int? liveAnchorId, DateTime? startDate, DateTime? endDate, string keyword, int pageNum, int pageSize);

        /// <summary>
        /// 获取订单来源枚举数据
        /// </summary>
        /// <returns></returns>
        List<ContentPlateFormOrderSourceDto> GetOrderSourceList();

        /// <summary>
        /// 获取面诊状态数据
        /// </summary>
        /// <returns></returns>
        List<ContentPlateFormOrderTypeDto> GetOrderConsultationTypeList();

        /// <summary>
        /// 内容平台已派单数据
        /// </summary>
        /// <param name="liveAnchorId"></param>
        /// <param name="employeeId"></param>
        /// <param name="belongEmpId"></param>
        /// <param name="orderStatus"></param>
        /// <param name="contentPlatFormId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="isHidePhone"></param>
        /// <returns></returns>
        Task<List<SendContentPlatformOrderDto>> GetSendOrderReportList(int? liveAnchorId, int employeeId, int belongEmpId, int? orderStatus
     , string contentPlatFormId, DateTime? startDate, DateTime? endDate, bool isHidePhone);
        #region 【数据中心】
        /// <summary>
        /// 获取时间段内未派单数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<List<OrderOperationConditionDto>> GetOrderUnSendDataAsync(DateTime startDate, DateTime endDate);

        Task<List<OrderPriceConditionDto>> GetOrderDealPriceAsync(DateTime startDate, DateTime endDate);

        Task<List<OrderOperationConditionDto>> GetOrderToHospitalDataAsync(DateTime startDate, DateTime endDate);
        Task<List<HospitalOrderNumAndPriceDto>> GetOrderSendAndDealDataAsync(DateTime startDate, DateTime endDate);
        Task<List<OrderOperationConditionDto>> GetOrderDealDataAsync(DateTime startDate, DateTime endDate);
        Task<List<OrderPriceConditionDto>> GetCheckForPerformanceDataAsync(DateTime startDate, DateTime endDate);
        Task<List<OrderPriceConditionDto>> GetReturnBackPriceDataAsync(DateTime startDate, DateTime endDate);
        Task<List<HospitalOrderNumAndPriceDto>> GetLiveAnchorPerformanceInfoAsync(DateTime startDate, DateTime endDate);
        Task<List<HospitalOrderNumAndPriceDto>> GetConsultationPerformanceInfoAsync(DateTime startDate, DateTime endDate);
        Task<List<HospitalOrderNumAndPriceDto>> GetCustomerServicePerformanceInfoAsync(DateTime startDate, DateTime endDate);

        #endregion
        #region 【业绩板块】
        /// <summary>
        ///  根据条件获取照片/视频面诊业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isVideo"></param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        Task<List<ContentPlatFormOrderInfoSimpleDto>> GetPictureOrVideoPerformanceByLiveAnchorAsync(int year, int month, bool isVideo, List<int> liveAnchorIds);

        /// <summary>
        /// 根据条件获取派单成交业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isSend"></param>
        /// <param name="isDeal"></param>
        /// <param name="isToHospital"></param>
        /// <param name="isOldCustomer"></param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        Task<List<ContentPlatFormOrderInfoDto>> GetSendOrDealPerformanceByLiveAnchorAsync(List<int> liveAnchorIds);

        /// <summary>
        /// 根据主播获取总订单数
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        Task<List<ContentPlatFormOrderInfoSimpleDto>> GetAddOrderPerformanceByLiveAnchorAsync(int year, int month, List<int> liveAnchorIds);
        /// <summary>
        /// 获取派单成交业绩(折线图使用)
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isSend"></param>
        /// <param name="isDeal"></param>
        /// <param name="isToHospital"></param>
        /// <param name="isOldCustomer"></param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        Task<List<ContentPlatFormOrderInfoDto>> GetSendOrDealPerformanceByLiveAnchorBrokenLineAsync(bool? isSend, bool? isDeal, bool? isToHospital, bool? isOldCustomer, List<int> liveAnchorIds);

        /// <summary>
        /// 获取照片/视频面诊业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isVideo"></param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetPictureOrVideoPerformanceByLiveAnchorBrokenLineAsync(int year, int month, bool isVideo, List<int> liveAnchorIds);
        #endregion
    }
}
