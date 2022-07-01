using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IService;
using Fx.Amiya.SyncOrder.Core;
using Fx.Amiya.SyncOrder.JD;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fx.Amiya.JD.Api
{
    public class FxAmiyaJDInitializer : IHostedService
    {
        private ISyncOrder syncOrder;
        private IOrderService orderService;
        private IInitializerService initializerService;
        private ILogger<FxAmiyaJDInitializer> logger;
        private IIntegrationAccount integrationAccountService;
        private ICustomerService customerService;
        private IMemberCard memberCardService;
        private IMemberRankInfo memberRankInfoService;
        public FxAmiyaJDInitializer(
           ISyncOrder syncOrder,
            IOrderService orderService,
            IInitializerService initializerService,
            ILogger<FxAmiyaJDInitializer> logger,
             IIntegrationAccount integrationAccountService,
            ICustomerService customerService,
            IMemberCard memberCardService,
             IMemberRankInfo memberRankInfoService)
        {
            this.syncOrder = syncOrder;
            this.orderService = orderService;
            this.initializerService = initializerService;
            this.logger = logger;
            this.integrationAccountService = integrationAccountService;
            this.customerService = customerService;
            this.memberCardService = memberCardService;
            this.memberRankInfoService = memberRankInfoService;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var isInitializer = await initializerService.GetIsInitializerByTypeAsync((byte)AppType.JD);
            if (isInitializer == false)
                return;

             DateTime date = DateTime.Now;

            // 获取京东全部订单，开始时间和结束时间最多不超过一个月
            var orderList = await syncOrder.TranslateAllTradesSoldOrders(date.AddDays(-20), date);
          
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
            await initializerService.AddAsync((byte)AppType.JD);

            foreach (var item in consumptionIntegrationList)
            {
                await integrationAccountService.AddByConsumptionAsync(item);
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {

        }
    }
}
