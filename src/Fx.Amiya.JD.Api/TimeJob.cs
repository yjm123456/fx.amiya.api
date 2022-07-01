using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IService;
using Fx.Amiya.SyncOrder.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pomelo.AspNetCore.TimedJob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.JD.Api
{
    public class TimeJob:Job
    {
        private IOrderService orderService;
        private ISyncOrder syncOrder;
        private ILogger<TimeJob> logger;
        private IIntegrationAccount integrationAccountService;
        private ICustomerService customerService;
        private IMemberCard memberCardService;
        private IMemberRankInfo memberRankInfoService;
        public TimeJob(IOrderService orderService, ISyncOrder syncOrder, ILogger<TimeJob> logger,
            IIntegrationAccount integrationAccountService,
            ICustomerService customerService,
            IMemberCard memberCardService,
             IMemberRankInfo memberRankInfoService)
        {
            this.orderService = orderService;
            this.syncOrder = syncOrder;
            this.logger = logger;
            this.integrationAccountService = integrationAccountService;
            this.customerService = customerService;
            this.memberCardService = memberCardService;
            this.memberRankInfoService = memberRankInfoService;
        }

        /// <summary>
        /// Begin:开始时间，Interval：隔多长时间执行一次（单位毫秒），SkipWhileExecuting：是否等待上个任务执行完再开始执行
        /// </summary>
        /// <returns></returns>
        [Invoke(Begin = "00:00:00", Interval = 1000 * 60 * 5, SkipWhileExecuting = true)]
        public async Task Run()
        {
            try
            {
                DateTime date = DateTime.Now;
               
                //获取京东发生改变的订单，开始时间和结束时间不能超过一个月
                var orderList = await syncOrder.TranslateTradesSoldChangedOrders(date.AddMinutes(-15),date);

                List<OrderInfoAddDto> amiyaOrderList = new List<OrderInfoAddDto>();
                List<ConsumptionIntegrationDto> consumptionIntegrationList = new List<ConsumptionIntegrationDto>();
                foreach (var order in orderList)
                {
                    OrderInfoAddDto amiyaOrder = new OrderInfoAddDto();
                    amiyaOrder.Id = order.Id;
                    amiyaOrder.GoodsName = order.GoodsName;
                    amiyaOrder.GoodsId = order.GoodsId;
                    amiyaOrder.Phone = order.Phone;
                    amiyaOrder.AppointmentHospital = order.AppointmentHospital;
                    amiyaOrder.StatusCode = order.StatusCode;
                    amiyaOrder.ActualPayment = order.ActualPayment;
                    amiyaOrder.CreateDate = order.CreateDate;
                    amiyaOrder.UpdateDate = order.UpdateDate;
                    amiyaOrder.ThumbPicUrl = order.ThumbPicUrl;
                    amiyaOrder.BuyerNick = order.BuyerNick;
                    amiyaOrder.AppType = order.AppType;
                    amiyaOrder.IsAppointment = order.IsAppointment;
                    amiyaOrder.OrderType = order.OrderType;
                    amiyaOrder.Quantity = order.Quantity;
                    amiyaOrderList.Add(amiyaOrder);

                    //计算积分
                    if (order.StatusCode == "TRADE_FINISHED" && order.ActualPayment >= 1 && !string.IsNullOrWhiteSpace(order.Phone))
                    {
                        bool isIntegrationGenerateRecord = await integrationAccountService.GetIsIntegrationGenerateRecordByOrderIdAsync(order.Id);
                        if (isIntegrationGenerateRecord == true)
                            continue;

                        var customerId = await customerService.GetCustomerIdByPhoneAsync(order.Phone);
                        if (string.IsNullOrWhiteSpace(customerId))
                            continue;

                        ConsumptionIntegrationDto consumptionIntegration = new ConsumptionIntegrationDto();
                        consumptionIntegration.CustomerId = customerId;
                        consumptionIntegration.OrderId = order.Id;
                        consumptionIntegration.AmountOfConsumption = (decimal)order.ActualPayment;
                        consumptionIntegration.Date = date;

                        var memberCard = await memberCardService.GetMemberCardHandelByCustomerIdAsync(customerId);
                        if (memberCard != null)
                        {
                            consumptionIntegration.Quantity = Math.Floor(memberCard.GenerateIntegrationPercent * (decimal)order.ActualPayment);
                            consumptionIntegration.Percent = memberCard.GenerateIntegrationPercent;
                        }
                        else
                        {
                            var memberRank = await memberRankInfoService.GetMinGeneratePercentMemberRankInfoAsync();
                            consumptionIntegration.Quantity = Math.Floor(memberRank.GenerateIntegrationPercent * (decimal)order.ActualPayment);
                            consumptionIntegration.Percent = memberRank.GenerateIntegrationPercent;

                        }
                        if (consumptionIntegration.Quantity > 0)
                            consumptionIntegrationList.Add(consumptionIntegration);
                       
                    }
                }
                await orderService.AddOrderAsync(amiyaOrderList);
                foreach (var item in consumptionIntegrationList)
                {
                    await integrationAccountService.AddByConsumptionAsync(item);
                }

                //退款订单
                var refundOrders = await syncOrder.GetRefundOrdersAsync(date.AddMinutes(-15), date);

                List<UpdateOrderDto> updateRefundListDto = new List<UpdateOrderDto>();
                foreach (var item in refundOrders)
                {
                    UpdateOrderDto updateRefundDto = new UpdateOrderDto();
                    updateRefundDto.OrderId = item.OrderId;
                    updateRefundDto.StatusCode = item.StatusCode;
                    updateRefundListDto.Add(updateRefundDto);
                }
                await orderService.UpdateAsync(updateRefundListDto);


                //已核销订单
                int codeStatus = 2; //码状态(-1：已退款，0：等待发码，1：未消费，2：已消费，3：已过期，101：退款锁定，103：过期锁定)
                var writeOffOrders = await syncOrder.GetOrderLocCodesAsync(date.AddMinutes(-15), date,codeStatus);
                List<UpdateOrderDto> updateWriteOffListDto = new List<UpdateOrderDto>();
                foreach (var order in writeOffOrders)
                {
                    UpdateOrderDto updateWriteOffDto = new UpdateOrderDto();
                    updateWriteOffDto.OrderId = order.OrderId;
                    updateWriteOffDto.StatusCode = order.StatusCode;
                    updateWriteOffDto.AppointmentHospital = order.AppointmentHospital;
                    updateWriteOffListDto.Add(updateWriteOffDto);

                    var orderInfo = await orderService.GetOrderByIdAsync(order.OrderId);
                    if (orderInfo == null)
                        continue;
                    //计算积分
                    if (order.StatusCode == "TRADE_FINISHED" && orderInfo.ActualPayment >= 1 && !string.IsNullOrWhiteSpace(orderInfo.Phone))
                    {
                        bool isIntegrationGenerateRecord = await integrationAccountService.GetIsIntegrationGenerateRecordByOrderIdAsync(order.OrderId);
                        if (isIntegrationGenerateRecord == true)
                            continue;

                        ConsumptionIntegrationDto consumptionIntegration = new ConsumptionIntegrationDto();
                        consumptionIntegration.CustomerId = orderInfo.CustomerId;
                        consumptionIntegration.OrderId = order.OrderId;
                        consumptionIntegration.AmountOfConsumption = orderInfo.ActualPayment;
                        consumptionIntegration.Date = date;

                        var memberCard = await memberCardService.GetMemberCardHandelByCustomerIdAsync(orderInfo.CustomerId);
                        if (memberCard != null)
                        {
                            consumptionIntegration.Quantity = Math.Floor(memberCard.GenerateIntegrationPercent * (decimal)orderInfo.ActualPayment);
                            consumptionIntegration.Percent = memberCard.GenerateIntegrationPercent;
                        }
                        else
                        {
                            var memberRank = await memberRankInfoService.GetMinGeneratePercentMemberRankInfoAsync();
                            consumptionIntegration.Quantity = Math.Floor(memberRank.GenerateIntegrationPercent * (decimal)orderInfo.ActualPayment);
                            consumptionIntegration.Percent = memberRank.GenerateIntegrationPercent;

                        }
                        if (consumptionIntegration.Quantity > 0)
                            await integrationAccountService.AddByConsumptionAsync(consumptionIntegration);
                    }
                }
               
                await orderService.UpdateAsync(updateWriteOffListDto);
                logger.LogInformation(date.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
