using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.FinancialBoard;
using Fx.Amiya.Dto.HuiShouQianPay;
using Fx.Amiya.Dto.Order;
using Fx.Amiya.Dto.OrderAppInfo;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.ReconciliationDocuments;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.Dto.UpdateCreateBillAndCompany;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IOrderService
    {

        Task<FxPageInfo<OrderInfoDto>> GetOrderListWithPageAsync(DateTime? startDate, DateTime? endDate, DateTime? writeOffStartDate, DateTime? writeOffEndDate, int? belongEmpId, string keyword, string statusCode, byte? appType, byte? orderNature, int employeeId, int pageNum, int pageSize);

        Task<FxPageInfo<OrderInfoDto>> GetOrderFinishListWithPageAsync(DateTime? writeOffStartDate, DateTime? writeOffEndDate, int? CheckState, bool? ReturnBackPriceState, string keyword, byte? appType, byte? orderNature, int employeeId,string createBillCompanyId, bool? iscreateBill,int pageNum, int pageSize, bool? dataFrom);

        Task<FxPageInfo<OrderInfoDto>> GetOrderByReconciliationDocumentsIdLlistWithPageAsync(string reconciliationDocumentsId, int pageNum, int pageSize);

        Task<List<OrderInfoDto>> ExportOrderListAsync(DateTime? startDate, DateTime? endDate, DateTime? writeOffStartDate, DateTime? writeOffEndDate, string keyword, string statusCode, byte? appType, byte? orderNature, int employeeId, bool isHidePhone);

        /// <summary>
        /// 根据加密手机号获取订单列表（分页）
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns></returns>
        Task<FxPageInfo<OrderInfoDto>> GetListByEncryptPhoneAsync(string encryptPhone, int pageNum, int pageSize);

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
        Task<FxPageInfo<OrderInfoDto>> GetUnBindCustomerServiceOrderListAsync(string status, string keyword, decimal? minPayment, decimal? maxPayment, byte? appType, int pageNum, int pageSize);

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
        /// 用户是否已下单过美肤卡
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<bool> IsExistMFCard(string customerId);
        /// <summary>
        /// 判断用户是否下单过商品
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        bool IsOrdered(string goodsId,string customerId);
        /// <summary>
        /// 判断是否超出限购数量
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<bool> IsOverLimitOrderAsync(string goodsId,string customerId,int purcheCount);

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="orderList"></param>
        /// <returns></returns>
        Task AddOrderAsync(List<OrderInfoAddDto> orderList);


        /// <summary>
        /// 添加啊美雅订单
        /// </summary>
        /// <param name="orderTradeAddDto"></param>
        /// <returns>交易编号</returns>
        Task<string> AddAmiyaOrderAsync(OrderTradeAddDto orderTradeAddDto);
        /// <summary>
        /// 添加啊美雅订单无事务
        /// </summary>
        /// <param name="orderTradeAddDto"></param>
        /// <returns>交易编号</returns>
        Task<string> AddAmiyaOrderWithNoTransactionAsync(OrderTradeAddDto orderTradeAddDto);

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
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<OrderExpressInfoDto> GetOrderExpressInfoAsync(string tradeId,string orderId);

        /// <summary>
        /// 根据手机号，快递单号，物流公司id获取快递信息
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="num">快递单号</param>
        /// <param name="expressId">物流公司id</param>
        /// <returns></returns>
        Task<OrderExpressInfoDto>GetExpressInfo (string phone,string num,string expressId);
        /// <summary>
        /// 根据交易编号获取订单列表
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        Task<List<OrderInfoDto>> GetOrderListByTradeIdAsync(string tradeId);

        /// <summary>
        /// 根据核销编号获取订单信息
        /// </summary>
        /// <param name="WriteOffCode"></param>
        /// <returns></returns>
        Task<List<OrderInfoDto>> GetOrderInfoByWriteOffCode(string WriteOffCode);
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="updateListDto"></param>
        /// <returns></returns>
        Task UpdateAsync(List<UpdateOrderDto> updateListDto);
        /// <summary>
        /// 修改订单(无事务,解决积分下单事务嵌套问题)
        /// </summary>
        /// <param name="updateListDto"></param>
        /// <returns></returns>
        Task UpdateWithNoTranstionAsync(List<UpdateOrderDto> updateListDto);
        /// <summary>
        /// 修改录单的订单
        /// </summary>
        /// <param name="updateListDto"></param>
        /// <returns></returns>
        Task UpdateAddedOrderAsync(OrderInfoUpdateDto updateListDto);
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
        /// 根据对账单id批量回款
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task ReturnBackOrderByReconciliationDocumentsIdsAsync(ReturnBackOrderDto input);
        /// <summary>
        /// 修改交易信息
        /// </summary>
        /// <returns></returns>
        Task UpdateOrderTradeAsync(UpdateOrderTradeDto updateOrderTrade);


        /// <summary>
        /// 获取超时未支付啊美雅订单列表
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
        Task UpdateOrderStatusAsync(string OrderId,string OrderStatus,decimal? ActuralPayment,decimal? AccountReceivable,DateTime? UpdateTime, DateTime? WriteOffDate);

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
        Task<int> GetUnSendOrderQuantityAsync(int employeeId);


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
        Task<FxPageInfo<OrderInfoDto>> GetTodayIncrementListAsync(int pageNum, int pageSize);



        /// <summary>
        /// 获取今日订单状态发生改变的订单列表
        /// </summary>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="keyword"></param>
        /// <param name="statusCode"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<OrderInfoDto>> GetTodayStatusChangeListAsync(int employeeId, string keyword, string statusCode, int pageNum, int pageSize);


        /// <summary>
        /// 根据员工编号获取订单列表
        /// </summary>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="statusCode"></param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<OrderInfoDto>> GetOrderByEmployeeIdAsync(int employeeId, string statusCode, string keyword, int pageNum, int pageSize);



        /// <summary>
        /// 根据订单编号获取订单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OrderInfoDto> GetByIdAsync(string id);

        /// <summary>
        /// 根据订单编号获取订单信息(crm系统用)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OrderInfoDto> GetByIdInCRMAsync(string id);

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
        Task WriteOffAsync(string orderId,int hospitalId);
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
        /// 根据客户编号获取订单列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="statusCode"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<OrderTradeForWxDto>> GetOrderListForAmiyaByCustomerId(string customerId, string statusCode, int pageNum, int pageSize);

        /// <summary>
        /// 根据客户编号获取所有平台订单列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="statusCode"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<OrderTradeForWxDto>> GetOrderListForAllAmiyaByCustomerId(string customerId, string statusCode, int pageNum, int pageSize);

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
        Task<List<MiniprogramOrderExportDto>> ExportMiniProgramMaterialOrderTradeList(DateTime startDate, DateTime endDate, int employeeId, bool? isSendGoods, string keyword);

        /// <summary>
        /// 根据交易编号获取订单列表
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        Task<List<OrderInfoDto>> GetListByTradeIdAsync(int employeeId, string tradeId);


        /// <summary>
        /// 发货
        /// </summary>
        /// <param name="sendGoodsDto"></param>
        /// <returns></returns>
        Task SendGoodsAsync(SendGoodsDto sendGoodsDto);

        /// <summary>
        /// 修改发货信息
        /// </summary>
        /// <returns></returns>
        Task UpdateExpressInfoAsync(SendGoodsDto sendGoodsDto);
        /// <summary>
        /// 根据交易id获取发货物流信息
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        Task<OrderSendInfoDto> GetOrderSendInfoAsync(string tradeId,string orderId);
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
        /// <summary>
        /// 更改订单状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="order"></param>
        /// <param name=""></param>
        /// <returns></returns>
        Task UpdateOrderStatus(string orderId,string orderStatus);
        /// <summary>
        /// 根据交易id更新订单状态
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        Task UpdateStatusByTradeIdAsync(string tradeId,string statusCode);
        /// <summary>
        /// 获取下级订单
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<FxPageInfo<SubordinateOrderDto>> GetSubordinateOrder(string customerId,int pageNum,int pageSize);
        /// <summary>
        /// 根据phone获取订单id列表
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<List<string>> GetOrderIdListByPhone(string phone);
        /// <summary>
        /// 更新开票状态和开票公司
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        Task UpdateCreateBillAndBelongCompany(UpdateCreateBillAndCompanyDto update);
        /// <summary>
        /// 交易订单添加支付交易单号(用于退款)
        /// </summary>
        /// <typeparam name="List"></typeparam>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        Task TradeAddTransNoAsync(string tradeId,string transId);

        /// <summary>
        /// 取消积分加钱购订单
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        Task CancelPointAndMoneyOrderAsync(string tradeId,string customerId);

        /// <summary>
        /// 取消积分订单
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        Task CancelPointOrderAsync(string tradeId);

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
        Task<List<OrderInfoDto>> GetTmallOrderListAsync(DateTime? startDate, DateTime? endDate, string statusCode, int employeeId, bool isHidePhone);
        /// <summary>
        /// 获取订单经营情况报表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task <List<OrderOperationConditionDto>> GetOrderOperationConditionAsync(DateTime? startDate, DateTime? endDate);
        Task<List<OrderWriteOffDto>> GetOrderWriteOffAsync(DateTime? startDate, DateTime? endDate,bool isHidePhone);
        Task<List<BuyOrderReportDto>> GetOrderBuyAsync(DateTime? startDate, DateTime? endDate, int belongEmpId, bool isHidePhone);
        Task<List<BuyOrderReportDto>> GetOrderCloseAsync(DateTime? startDate, DateTime? endDate, bool isHidePhone);
        Task<List<OrderWriteOffDto>> GetCustomerOrderReceivableAsync(DateTime? startDate, DateTime? endDate, int? appType, int? CheckState, bool? ReturnBackPriceState, bool? isCreateBill, string companyId, string customerName, bool isHidePhone);

        Task<List<OrderWriteOffDto>> GetCustomerPaidOrderReceivableAsync(DateTime? startDate, DateTime? endDate, int? CheckState, bool? ReturnBackPriceState, string customerName, bool isHidePhone);
        /// <summary>
        /// 积分加钱购全部退款退还积分(无事务版本,事务有外层控制)
        /// </summary>
        /// <param name="tradeId">交易id</param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task CancelPointAndMoneyOrderWithNoTransactionAsync(string tradeId, string customerId);
        /// <summary>
        /// 积分加钱购部分退款退还积分(无事务版本,事务有外层控制)
        /// </summary>
        /// <param name="orderId">订单id</param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task CancelPartPointAndMoneyOrderWithNoTransactionAsync(string orderId, string customerId);

        /// <summary>
        /// 购物车生成订单
        /// </summary>
        /// <param name="orderTradeAddDto"></param>
        /// <returns></returns>
        Task AddAmiyaCartOrderWithNoTransactionAsync(CartOrderTradeAddDto orderTradeAddDto);

        #endregion

        #region  【数据中心模块】
        Task<List<OrderPriceConditionDto>> GetOrderDealPriceDataAsync(DateTime startDate, DateTime endDate);

        Task<List<OrderOperationConditionDto>> GetOrderToHospitalDataAsync(DateTime startDate, DateTime endDate);
        Task<List<OrderPriceConditionDto>> GetCheckForPerformanceDataAsync(DateTime startDate, DateTime endDate);
        Task<List<OrderPriceConditionDto>> GetReturnBackPriceDataAsync(DateTime startDate, DateTime endDate);
        Task<List<HospitalOrderNumAndPriceDto>> GetCustomerServicePerformanceInfoAsync(DateTime startDate, DateTime endDate);
        #endregion

        #region 【对账单板块】
        /// <summary>
        /// 获取时间段内未对账机构列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<UnCheckHospitalOrderDto>> GetUnCheckHospitalOrderAsync(DateTime? startDate, DateTime? endDate, int? hospitalId);
        #endregion
        /// <summary>
        /// 财务看板获取主播业绩数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="liveAnchorId"></param>
        /// <returns></returns>
        Task<List<LiveAnchorBoardDataDto>> GetLiveAnchorPriceByLiveAnchorIdAsync(DateTime? startDate, DateTime? endDate, List<int> liveAnchorId);
        /// <summary>
        /// 根据客服id获取财务看板客服业绩信息
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="customerServiceId"></param>
        /// <returns></returns>
        Task<List<CustomerServiceBoardDataDto>> GetCustomerServiceBoardDataByCustomerServiceIdAsync(DateTime? startDate, DateTime? endDate, int? customerServiceId);
        /// <summary>
        /// 新的购物车下单接口
        /// </summary>
        /// <returns></returns>
        Task<PayRequestInfoDto> NewCartOrderAsync(CartOrderAddDto cartOrderAddDto);
        /// <summary>
        /// 订单绑定客服无事务版
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateOrderBelongEmpIdWithNoTransactionAsync(UpdateBelongEmpInfoOrderDto input);
        /// <summary>
        /// 积分虚拟商品下单接口
        /// </summary>
        /// <param name="cartOrderAddDto"></param>
        /// <returns></returns>
        Task<string> CreateIntegralVirtualOrderAsync(CreateIntegralVirtualOrderDto virtualOrder);
        /// <summary>
        /// 添加积分虚拟商品订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task AddIntegralVirtualOrderAsync(AddIntegralVirtualOrderDto order);
        /// <summary>
        /// 判断核销码是否已存在
        /// </summary>
        /// <param name="code">核销码</param>
        /// <returns></returns>
        bool WriteOffCodeIsExist(string code);
    }
}
