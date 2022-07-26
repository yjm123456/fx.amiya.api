using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Common;
using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IService;
using Fx.Amiya.SyncOrder.Core;
using Fx.Amiya.SyncOrder.Tmall;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pomelo.AspNetCore.TimedJob;
using System.Threading;
using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.SyncOrder.TikTok;
using Fx.Amiya.Dto.TikTokOrder;

namespace Fx.Amiya.Background.Api
{
    public class TimeJob : Job
    {
        private IOrderService orderService;
        private ISyncOrder syncOrder;
        private ISyncWeiFenXiaoOrder _syncWeiFenXiaoOrder;
        private ISyncTikTokOrder _syncTikTokOrder;
        private FxAppGlobal _fxAppGlobal;
        private IIntegrationAccount integrationAccountService;
        private ICustomerService customerService;
        private IMemberCard memberCardService;
        private IMemberRankInfo memberRankInfoService;
        private IBindCustomerServiceService _bindCustomerService;
        private ITikTokOrderInfoService _tikTokOrderInfoService;
        public TimeJob(IOrderService orderService, ISyncOrder syncOrder, ISyncWeiFenXiaoOrder syncWeiFenXiaoOrder, FxAppGlobal fxAppGlobal, IBindCustomerServiceService bindCustomerService,
          IIntegrationAccount integrationAccountService,
            ICustomerService customerService,
             IMemberCard memberCardService,
             ISyncTikTokOrder syncTikTokOrder,
             IMemberRankInfo memberRankInfoService, ITikTokOrderInfoService tokOrderInfoService)
        {
            this.orderService = orderService;
            this.syncOrder = syncOrder;
            _fxAppGlobal = fxAppGlobal;
            _syncWeiFenXiaoOrder = syncWeiFenXiaoOrder;
            this.integrationAccountService = integrationAccountService;
            this.customerService = customerService;
            this.memberCardService = memberCardService;
            _syncTikTokOrder = syncTikTokOrder;
            this.memberRankInfoService = memberRankInfoService;
            _bindCustomerService = bindCustomerService;
            _tikTokOrderInfoService = tokOrderInfoService;
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
                List<AmiyaOrder> orderList = new List<AmiyaOrder>();
                List<TikTokOrder> tikTokOrderList = new List<TikTokOrder>();
                DateTime date = DateTime.Now;
                if (_fxAppGlobal.AppConfig.SyncOrderConfig.Tmall == true)
                {
                    ////获取天猫发生改变的订单，开始时间和结束时间不能超过一天
                    var tmallOrderResult = await syncOrder.TranslateTradesSoldChangedOrders(date.AddMinutes(-15), date);
                    orderList.AddRange(tmallOrderResult);
                }
                if (_fxAppGlobal.AppConfig.SyncOrderConfig.WeiFenXiao == true)
                {
                    ////获取微分销发生改变的订单，开始时间和结束时间不能超过一天
                    var weiFenXiaoOrderResult = await _syncWeiFenXiaoOrder.TranslateTradesSoldChangedOrders(date.AddMinutes(-15), date);
                    orderList.AddRange(weiFenXiaoOrderResult);
                }
                if (_fxAppGlobal.AppConfig.SyncOrderConfig.DouYin == true)
                {
                    ////获取抖音发生改变的订单，开始时间和结束时间不能超过一天
                    var douYinOrderResult = await _syncTikTokOrder.TranslateTradesSoldChangedOrders(date.AddMinutes(-15), date);
                    tikTokOrderList.AddRange(douYinOrderResult);
                }
                List<OrderInfoAddDto> amiyaOrderList = new List<OrderInfoAddDto>();
                List<TikTokOrderAddDto> tikTokOrderAddList = new List<TikTokOrderAddDto>();
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
                    amiyaOrder.WriteOffDate = order.WriteOffDate;
                    amiyaOrder.ThumbPicUrl = order.ThumbPicUrl;
                    amiyaOrder.BuyerNick = order.BuyerNick;
                    amiyaOrder.AppType = order.AppType;
                    if (order.AppType == 0)
                    {
                        amiyaOrder.AccountReceivable = order.AccountReceivable;
                    }
                    else
                    {
                        amiyaOrder.AccountReceivable = order.ActualPayment;
                    }
                    amiyaOrder.IsAppointment = order.IsAppointment;
                    amiyaOrder.OrderType = order.OrderType;
                    amiyaOrder.Quantity = order.Quantity;
                    amiyaOrder.ExchangeType = (byte)ExchangeType.ThirdPartyPayment;
                    int belongEmpId = await _bindCustomerService.GetEmployeeIdByPhone(order.Phone);
                    if (belongEmpId > 0)
                    { amiyaOrder.BelongEmpId = belongEmpId; }
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
                        var findInfo = await _bindCustomerService.GetEmployeeIdByPhone(order.Phone);
                        if (findInfo != 0)
                        {
                            await _bindCustomerService.UpdateConsumePriceAsync(order.Phone, order.ActualPayment.Value, (int)OrderFrom.ThirdPartyOrder);
                        }
                    }

                }
                //抖店订单
                foreach (var order in tikTokOrderList) {
                    TikTokOrderAddDto tikTokOrder = new TikTokOrderAddDto();
                    tikTokOrder.Id = order.Id;
                    tikTokOrder.GoodsName = order.GoodsName;
                    tikTokOrder.GoodsId = order.GoodsId;
                    tikTokOrder.AppointmentHospital = order.AppointmentHospital;
                    tikTokOrder.StatusCode = order.StatusCode;
                    tikTokOrder.ActualPayment = order.ActualPayment;
                    tikTokOrder.CreateDate = order.CreateDate;
                    tikTokOrder.UpdateDate = order.UpdateDate;
                    tikTokOrder.WriteOffDate = order.WriteOffDate;
                    tikTokOrder.ThumbPicUrl = order.ThumbPicUrl;
                    tikTokOrder.AppType = order.AppType;
                    tikTokOrder.AccountReceivable = order.ActualPayment;
                    tikTokOrder.IsAppointment = order.IsAppointment;
                    tikTokOrder.OrderType = order.OrderType;
                    tikTokOrder.Quantity = order.Quantity;
                    tikTokOrder.ExchangeType = (byte)ExchangeType.ThirdPartyPayment;
                    tikTokOrder.TikTokUserId = order.TikTokUserId;
                    tikTokOrder.CipherPhone = order.CipherPhone;
                    tikTokOrder.CipherName = order.CipherName;
                    //如果订单信息包含手机号则绑定,没有则暂时不绑定
                    if (!string.IsNullOrEmpty(order.Phone)) {
                        int belongEmpId = await _bindCustomerService.GetEmployeeIdByPhone(order.Phone);
                        if (belongEmpId > 0)
                        { tikTokOrder.BelongEmpId = belongEmpId; }
                    }                    
                    tikTokOrderAddList.Add(tikTokOrder);
                    //计算积分,如果订单信息包含手机号则计算积分,否则暂时不计算
                    if (!string.IsNullOrEmpty(order.Phone)) {
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
                            var findInfo = await _bindCustomerService.GetEmployeeIdByPhone(order.Phone);
                            if (findInfo != 0)
                            {
                                await _bindCustomerService.UpdateConsumePriceAsync(order.Phone, order.ActualPayment.Value, (int)OrderFrom.ThirdPartyOrder);
                            }

                        }
                    }
                }
                await orderService.AddOrderAsync(amiyaOrderList);
                await _tikTokOrderInfoService.AddAsync(tikTokOrderAddList);
                foreach (var item in consumptionIntegrationList)
                {
                    await integrationAccountService.AddByConsumptionAsync(item);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



    }
}
