using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.OrderAppInfo;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.TikTokOrder;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ITikTokOrderInfoService
    {
        /// <summary>
        /// 添加tiktok订单
        /// </summary>
        /// <param name="tikTokOrderAddDto"></param>
        /// <returns></returns>
        Task AddAsync(List<TikTokOrderAddDto> tikTokOrderAddDto);
        /// <summary>
        /// 获取tiktok订单列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="writeOffStartDate"></param>
        /// <param name="writeOffEndDate"></param>
        /// <param name="belongEmpId"></param>
        /// <param name="keyword"></param>
        /// <param name="statusCode"></param>
        /// <param name="appType"></param>
        /// <param name="orderNature"></param>
        /// <param name="employeeId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<TikTokOrderDto>> GetOrderListWithPageAsync(DateTime? startDate, DateTime? endDate, string keyword, int pageNum, int pageSize);
        
        /// <summary>
        /// 获取已成交订单列表
        /// </summary>
        /// <param name="writeOffStartDate"></param>
        /// <param name="writeOffEndDate"></param>
        /// <param name="CheckState"></param>
        /// <param name="ReturnBackPriceState"></param>
        /// <param name="keyword"></param>
        /// <param name="appType"></param>
        /// <param name="orderNature"></param>
        /// <param name="employeeId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<TikTokOrderDto>> GetOrderFinishListWithPageAsync(DateTime? writeOffStartDate, DateTime? writeOffEndDate, int? CheckState, bool? ReturnBackPriceState, string keyword, byte? appType, byte? orderNature, int employeeId, int pageNum, int pageSize);
        Task<List<TikTokOrderDto>> ExportOrderListAsync(DateTime? startDate, DateTime? endDate, DateTime? writeOffStartDate, DateTime? writeOffEndDate, string keyword, string statusCode, byte? appType, byte? orderNature, int employeeId, bool isHidePhone);

        /// <summary>
        /// 根据加密手机号获取订单列表（分页）
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns></returns>
        Task<FxPageInfo<TikTokOrderDto>> GetListByEncryptPhoneAsync(string encryptPhone, int pageNum, int pageSize);

        /// <summary>
        /// 根据手机判断是否存在该用户
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<bool> IsExistPhoneAsync(string phone);
        /// <summary>
        /// 获取未绑定客服的订单列表
        /// </summary>
        /// <param name="status"></param>
        /// <param name="keyword"></param>
        /// <param name="minPayment">最小金额</param>
        /// <param name="maxPayment">最大金额</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<TikTokOrderDto>> GetUnBindCustomerServiceOrderListAsync(string status, string keyword, decimal? minPayment, decimal? maxPayment, byte? appType, int pageNum, int pageSize);

        /// <summary>
        /// 获取当日订单数量
        /// </summary>
        /// <returns></returns>
        Task<string> GetTodayOrderCount();

        /// <summary>
        /// 获取已绑定客服的订单列表
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="customerServiceId"></param>
        /// <param name="appType">下单平台</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<BindCustomerServiceOrderDto>> GetBindCustomerServieOrderListAsync(string phone, int? customerServiceId, byte? appType, string statusCode, decimal? minPayment, decimal? maxPayment, int pageNum, int pageSize);




        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="orderList"></param>
        /// <returns></returns>
        Task AddOrderAsync(List<TikTokOrderAddDto> orderList);


        /// <summary>
        /// 添加阿美雅订单
        /// </summary>
        /// <param name="orderTradeAddDto"></param>
        /// <returns>交易编号</returns>
        Task<string> AddAmiyaOrderAsync(OrderTradeAddDto orderTradeAddDto);

        /// <summary>
        /// 获取微信支付参数
        /// </summary>
        /// <param name="packageInfo"></param>
        /// <returns></returns>
        Task<WxPayRequestInfo> BuildPayRequest(WxPackageInfo packageInfo);
        /// <summary>
        /// 验证微信支付提交字段
        /// </summary>
        /// <param name="errmsg"></param>
        /// <returns></returns>
        bool CheckVxSetParams(out string errmsg);

        bool CheckVxPackage(WxPackageInfo package, out string errmsg);
        /// <summary>
        /// 根据交易编号获取交易信息
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        Task<OrderTradeForWxDto> GetOrderTradeByTradeIdAsync(string tradeId);

        /// <summary>
        /// 根据交易编号获取订单物流信息
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        Task<OrderExpressInfoDto> GetOrderExpressInfoAsync(string tradeId);

        /// <summary>
        /// 根据手机号，快递单号，物流公司id获取快递信息
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="num">快递单号</param>
        /// <param name="expressId">物流公司id</param>
        /// <returns></returns>
        Task<OrderExpressInfoDto> GetExpressInfo(string phone, string num, string expressId);
        /// <summary>
        /// 根据交易编号获取订单列表
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        Task<List<TikTokOrderDto>> GetOrderListByTradeIdAsync(string tradeId);

        /// <summary>
        /// 根据核销编号获取订单信息
        /// </summary>
        /// <param name="WriteOffCode"></param>
        /// <returns></returns>
        Task<List<TikTokOrderDto>> GetOrderInfoByWriteOffCode(string WriteOffCode);
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="updateListDto"></param>
        /// <returns></returns>
        Task UpdateAsync(List<UpdateTikTokOrderDto> updateListDto);

        /// <summary>
        /// 修改录单的订单
        /// </summary>
        /// <param name="updateListDto"></param>
        /// <returns></returns>
        Task UpdateAddedOrderAsync(TikTokOrderInfoUpdateDto updateListDto);
        /// <summary>
        /// 删除录单的订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);

        /// <summary>
        /// 完成录单的订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task FinishOrderAsync(string orderId);

        /// <summary>
        /// 审核订单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CheckOrderAsync(ContentPlateFormOrderCheckDto input);

        /// <summary>
        /// 订单回款
        /// </summary>
        /// <param name="input"></param>
        Task ReturnBackOrderAsync(ReturnBackOrderDto input);
        /// <summary>
        /// 修改交易信息
        /// </summary>
        /// <returns></returns>
        Task UpdateOrderTradeAsync(UpdateOrderTradeDto updateOrderTrade);


        /// <summary>
        /// 获取超时未支付阿美雅订单列表
        /// </summary>
        /// <returns></returns>
        Task<List<OrderInfoSimpleDto>> TimeOutOrderAsync();


        /// <summary>
        /// 根据客户编号获取未领取礼品的订单列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<List<OrderInfoSimpleDto>> GetUnReceiveGiftOrderListByCustomerIdAsync(string customerId);

        /// <summary>
        /// 获取核销好礼接口数据订单
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<FxPageInfo<OrderInfoSimpleDto>> GetReceiveGiftOrderListByCustomerIdAsync(string customerId, int pageNum, int pageSize);


        /// <summary>
        /// 根据客户编号获取已购买订单列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<FxPageInfo<OrderInfoSimpleDto>> GetAlreadyBuyOrderListAsync(string customerId, int ExchangeType, int pageNum, int pageSize);


        /// <summary>
        /// 获取总订单数量
        /// </summary>
        /// <returns></returns>
        Task<int> GetTotalOrderQuantityAsync(int employeeId);



        /// <summary>
        /// 获取今日新增订单数量
        /// </summary>
        /// <returns></returns>
        Task<int> GetTodayIncrementQuantityAsync(int employeeId);

        /// <summary>
        /// 获取今日新增订单数量(无员工编号查询)
        /// </summary>
        /// <returns></returns>
        Task<int> GetTodayIncrementQuantityAsync();


        /// <summary>
        /// 获取今日录单订单数量
        /// </summary>
        /// <returns></returns>
        Task<List<TodayOrderAddDto>> GetTodayOrderAddAsync();

        /// <summary>
        /// 获取今日核销订单数量(无员工编号查询)
        /// </summary>
        /// <returns></returns>
        Task<int> GetTodayWriteOffQuantityAsync();

        /// <summary>
        /// 获取今日关闭订单数量
        /// </summary>
        /// <returns></returns>
        Task<int> GetTodayClosedQuantityAsync();

        /// <summary>
        /// 获取最新订单状态改变时间
        /// </summary>
        /// <returns>订单状态最新改变时间，null：今天暂无状态改变订单</returns>
        Task<DateTime?> GetLatelyStatusChangeDateAsync(int employeeId);

        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        Task UpdateOrderStatusAsync(string OrderId, string OrderStatus, decimal? ActuralPayment, decimal? AccountReceivable, DateTime? UpdateTime, DateTime? WriteOffDate);

        /// <summary>
        /// 订单归属主播
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        Task UpdateOrderLiveAnchorAsync(UpdateLiveAnchorOrderDto dto);
        /// <summary>
        /// 订单归属客服
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        Task UpdateOrderBelongEmpIdAsync(UpdateBelongEmpInfoOrderDto input);


        /// <summary>
        /// 获取未绑定客服订单数量
        /// </summary>
        /// <returns></returns>
        Task<int?> GetUnBindOrderQuantityAsync(int employeeId);



        /// <summary>
        /// 获取未派单订单数量
        /// </summary>
        /// <returns></returns>
       // Task<int> GetUnSendOrderQuantityAsync(int employeeId);


        /// <summary>
        /// 获取各订单状态的订单数量
        /// </summary>
        /// <returns></returns>
        Task<List<OrderStatusDataDto>> GetOrderStatusDataAsync(int employeeId);

        /// <summary>
        /// 获取今天新增订单
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<TikTokOrderDto>> GetTodayIncrementListAsync(int pageNum, int pageSize);



        /// <summary>
        /// 获取今日订单状态发生改变的订单列表
        /// </summary>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="keyword"></param>
        /// <param name="statusCode"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<TikTokOrderDto>> GetTodayStatusChangeListAsync(int employeeId, string keyword, string statusCode, int pageNum, int pageSize);


        /// <summary>
        /// 根据员工编号获取订单列表
        /// </summary>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="statusCode"></param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<TikTokOrderDto>> GetOrderByEmployeeIdAsync(int employeeId, string statusCode, string keyword, int pageNum, int pageSize);



        /// <summary>
        /// 根据订单编号获取订单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TikTokOrderDto> GetByIdAsync(string id);

        /// <summary>
        /// 根据订单编号获取订单信息(crm系统用)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TikTokOrderDto> GetByIdInCRMAsync(string id);

        /// <summary>
        /// 修改京东退款成功的订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task UpdateRefundOfJdAsync(string id);

        /// <summary>
        /// 订单核销
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task WriteOffAsync(string orderId, int hospitalId);
        /// <summary>
        /// 记录订单最终核销医院
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task UpdateOrderFinalConsumptionHospital(string orderId, int hospitalId);

        /// <summary>
        /// 获取所有已核销注册过小程序的客户订单
        /// </summary>
        /// <returns></returns>
        Task<List<CustomerOrderDto>> GetCustomerTradeFinishOrderListAsync();


        /// <summary>
        /// 根据客户编号获取已核销订单
        /// </summary>
        /// <returns></returns>
        Task<List<CustomerOrderDto>> GetTradeFinishOrderListByCustomerIdAsync(string customerId);


        /// <summary>
        /// 根据订单编号获取客户订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<CustomerOrderDto> GetOrderByIdAsync(string orderId);



        /// <summary>
        /// 根据客户编号获取tiktok所有订单列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="statusCode"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<OrderTradeForWxDto>> GetOrderListForAllTikTokByCustomerId(string customerId, string statusCode, int pageNum, int pageSize);

        /// <summary>
        /// 获取小程序实物订单交易列表
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="isSendGoods">是否已发货,null:全部</param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<OrderTradeDto>> GetMiniProgramMaterialOrderTradeList(DateTime startDate, DateTime endDate, int employeeId, bool? isSendGoods, string keyword, int pageNum, int pageSize);


        /// <summary>
        /// 导出小程序实物订单交易列表
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="isSendGoods">是否已发货,null:全部</param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        Task<List<OrderTradeDto>> ExportMiniProgramMaterialOrderTradeList(DateTime startDate, DateTime endDate, int employeeId, bool? isSendGoods, string keyword);

        /// <summary>
        /// 根据交易编号获取订单列表
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        Task<List<TikTokOrderDto>> GetListByTradeIdAsync(int employeeId, string tradeId);


        /// <summary>
        /// 发货
        /// </summary>
        /// <param name="sendGoodsDto"></param>
        /// <returns></returns>
        Task SendGoodsAsync(SendGoodsDto sendGoodsDto);


        /// <summary>
        /// 获取下单平台列表
        /// </summary>
        /// <returns></returns>
        List<OrderAppTypeDto> GetOrderAppTypeList();
        /// <summary>
        /// 获取订单性质列表
        /// </summary>
        /// <returns></returns>
        List<OrderNatureDto> GetOrderNatureList();

        /// <summary>
        /// 根据电话号获取已核销的总金额
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<decimal> GetTradeFinishAmountByPhoneAsync(string phone);


        #region 报表模块

        /// <summary>
        /// 获取天猫订单报表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="statusCode"></param>
        /// <param name="employeeId"></param>
        /// <param name="isHidePhone"></param>
        /// <returns></returns>
        Task<List<TikTokOrderDto>> GetTikTokOrderListAsync(DateTime? startDate, DateTime? endDate, string statusCode, int employeeId, bool isHidePhone);
        /// <summary>
        /// 获取订单经营情况报表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<List<OrderOperationConditionDto>> GetOrderOperationConditionAsync(DateTime? startDate, DateTime? endDate);
        Task<List<OrderWriteOffDto>> GetOrderWriteOffAsync(DateTime? startDate, DateTime? endDate, bool isHidePhone);
        Task<List<BuyOrderReportDto>> GetOrderBuyAsync(DateTime? startDate, DateTime? endDate, int belongEmpId, bool isHidePhone);
        Task<List<BuyOrderReportDto>> GetOrderCloseAsync(DateTime? startDate, DateTime? endDate, bool isHidePhone);
        Task<List<OrderWriteOffDto>> GetCustomerOrderReceivableAsync(DateTime? startDate, DateTime? endDate, int? CheckState, bool? ReturnBackPriceState, string customerName, bool isHidePhone);

        #endregion

        #region  【数据中心模块】
        //Task<List<OrderPriceConditionDto>> GetOrderDealPriceDataAsync(DateTime startDate, DateTime endDate);

        //Task<List<OrderOperationConditionDto>> GetOrderToHospitalDataAsync(DateTime startDate, DateTime endDate);
        //Task<List<OrderPriceConditionDto>> GetCheckForPerformanceDataAsync(DateTime startDate, DateTime endDate);
        //Task<List<OrderPriceConditionDto>> GetReturnBackPriceDataAsync(DateTime startDate, DateTime endDate);
        //Task<List<HospitalOrderNumAndPriceDto>> GetCustomerServicePerformanceInfoAsync(DateTime startDate, DateTime endDate);
        #endregion
    }
}
