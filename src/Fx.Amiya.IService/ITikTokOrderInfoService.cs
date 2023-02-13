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
        /// <param name="endDate"></param
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<TikTokOrderDto>> GetOrderListWithPageAsync(DateTime? startDate, DateTime? endDate, string keyword, string belongLiveAnchorId, int pageNum, int pageSize);
             
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="orderList"></param>
        /// <returns></returns>
        Task AddOrderAsync(List<TikTokOrderAddDto> orderList);


        /// <summary>
        /// 添加啊美雅订单
        /// </summary>
        /// <param name="orderTradeAddDto"></param>
        /// <returns>交易编号</returns>
        Task<string> AddAmiyaOrderAsync(OrderTradeAddDto orderTradeAddDto);

 


        /// <summary>
        /// 根据订单编号获取订单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TikTokOrderDto> GetOrderById(string orderId);
        /// <summary>
        /// 根据订单号修改用户昵称和手机号
        /// </summary>
        /// <param name="tikTokOrderInfoUpdateDto"></param>
        /// <returns></returns>
        Task UpdateOrderAsync(TikTokOrderInfoUpdateDto tikTokOrderInfoUpdateDto);
        /// <summary>
        /// 校对订单修改订单信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statusCode"></param>
        /// <param name="actualPayment"></param>
        /// <param name="accountReceivable"></param>
        /// <param name="updateDate"></param>
        /// <param name="finishDate"></param>
        /// <returns></returns>
        Task UpdateOrderStatusAsync(string id, string statusCode, decimal? actualPayment,decimal? accountReceivable, DateTime? updateDate,DateTime? finishDate);

    }
}
