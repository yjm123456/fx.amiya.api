
using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IService;
using Fx.Amiya.SyncOrder.Core;
using Fx.Amiya.SyncOrder.Tmall;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api
{
    public class FxAmiyaBackgroundInitializer : IHostedService
    {
        private IOrderService orderService;
        private ISyncOrder syncOrder;
        private IInitializerService initializerService;
        private IMemberCard memberCardService;
        private IIntegrationAccount integrationAccountService;
        private IMemberRankInfo memberRankInfoService;
        public FxAmiyaBackgroundInitializer(IOrderService orderService,
            ISyncOrder syncOrder,
            IInitializerService initializerService,
            IMemberCard memberCardService,
           IIntegrationAccount integrationAccountService,
            IMemberRankInfo memberRankInfoService)
        {
            this.orderService = orderService;
            this.syncOrder = syncOrder;
            this.initializerService = initializerService;
            this.memberCardService = memberCardService;
            this.integrationAccountService = integrationAccountService;
            this.memberRankInfoService = memberRankInfoService;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            DateTime date = DateTime.Now;
            var isInitializer = await initializerService.GetIsInitializerByTypeAsync((byte)InitializerType.Tmall);
            if (isInitializer == true)
            {


                //同步天猫全部订单，开始时间和结束时间不能超过3个月
                var orderList = await syncOrder.TranslateAllTradesSoldOrders(date.AddDays(-2), date);

                List<OrderInfoAddDto> amiyaOrderList = new List<OrderInfoAddDto>();
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
                }
                await orderService.AddOrderAsync(amiyaOrderList);

                await initializerService.AddAsync((byte)InitializerType.Tmall);
            }



            //计算积分

            var isIntegrationInitializer = await initializerService.GetIsInitializerByTypeAsync((byte)InitializerType.Integration);

            if (isIntegrationInitializer == true)
            {
                var orders = await orderService.GetCustomerTradeFinishOrderListAsync();
                foreach (var order in orders)
                {
                    bool isIntegrationGenerateRecord = await integrationAccountService.GetIsIntegrationGenerateRecordByOrderIdAsync(order.Id);
                    if (isIntegrationGenerateRecord == true)
                        continue;
                    ConsumptionIntegrationDto consumptionIntegration = new ConsumptionIntegrationDto();
                    consumptionIntegration.CustomerId = order.CustomerId;
                    consumptionIntegration.OrderId = order.Id;
                    consumptionIntegration.AmountOfConsumption = order.ActualPayment;
                    consumptionIntegration.Date = date;

                    var memberCard = await memberCardService.GetMemberCardHandelByCustomerIdAsync(order.CustomerId);
                    if (memberCard != null)
                    {
                        consumptionIntegration.Quantity = Math.Floor(memberCard.GenerateIntegrationPercent * order.ActualPayment);
                        consumptionIntegration.Percent = memberCard.GenerateIntegrationPercent;
                    }
                    else
                    {
                        var memberRank = await memberRankInfoService.GetMinGeneratePercentMemberRankInfoAsync();
                        consumptionIntegration.Quantity = Math.Floor(memberRank.GenerateIntegrationPercent * order.ActualPayment);
                        consumptionIntegration.Percent = memberRank.GenerateIntegrationPercent;

                    }
                    if (consumptionIntegration.Quantity > 0)
                        await integrationAccountService.AddByConsumptionAsync(consumptionIntegration);
                }
                await initializerService.AddAsync((byte)InitializerType.Integration);
            }

        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
        }
    }
}
