﻿using Fx.Amiya.Dto.OrderAppInfo;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IOrderHistoryService
    {

        Task<FxPageInfo<OrderInfoDto>> GetOrderListWithPageAsync(DateTime? startDate, DateTime? endDate, DateTime? writeOffStartDate, DateTime? writeOffEndDate, string keyword, string statusCode, byte? appType, byte? orderNature, int employeeId, int pageNum, int pageSize);

         Task<List<OrderInfoDto>> ExportOrderListAsync(DateTime? startDate, DateTime? endDate, DateTime? writeOffStartDate, DateTime? writeOffEndDate, string keyword, string statusCode, byte? appType, byte? orderNature, int employeeId);

        /// <summary>
        /// 根据加密手机号获取订单列表（分页）
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns></returns>
        Task<FxPageInfo<OrderInfoDto>> GetListByEncryptPhoneAsync(string encryptPhone, int pageNum, int pageSize);

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
        /// 获取小程序实物订单交易列表
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="isSendGoods">是否已发货,null:全部</param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<OrderTradeDto>> GetMiniProgramMaterialOrderTradeList(int employeeId, bool? isSendGoods, string keyword, int pageNum, int pageSize);

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
        /// 获取订单经营情况报表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task <List<OrderOperationConditionDto>> GetOrderOperationConditionAsync(DateTime? startDate, DateTime? endDate);
        Task<List<OrderWriteOffDto>> GetOrderWriteOffAsync(DateTime? startDate, DateTime? endDate,bool isHidePhone);

        Task<List<OrderWriteOffDto>> GetCustomerOrderReceivableAsync(DateTime? startDate, DateTime? endDate,string customerName, bool isHidePhone);

        #endregion
    }
}
