using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.Dto.ConsumptionVoucher;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pomelo.AspNetCore.TimedJob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api
{
    public class TimeJob:Job
    {
       
        private ILogger<TimeJob> logger;
        private IServiceProvider _serviceProvider;
        public TimeJob(ILogger<TimeJob> logger,
            IServiceProvider serviceProvider)
        {
            this.logger = logger;
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Begin 起始时间
        /// Interval 表示时间间隔，单位是毫秒
        /// SkipWhileExecuting 是否等待上一个执行任务完成，true为等待 1000 * 3600 * 24
        /// </summary>
        /// <returns></returns>
        [Invoke(Begin = "00:00:00", Interval = 1000 * 3600 * 24, SkipWhileExecuting = true)]
        public async Task Run()
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var appointmentService = scope.ServiceProvider.GetService<IAppointmentService>();
                    await appointmentService.CancelOverTimeAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        


        /// <summary>
        /// 处理阿美雅超时未支付的商城订单
        /// </summary>
        /// <returns></returns>
        [Invoke(Begin = "00:00:00", Interval = 1000 * 60 * 5, SkipWhileExecuting = false)]
        public async Task HandleTimeOutOrderAsync()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var orderService = scope.ServiceProvider.GetService<IOrderService>();
                var goodsService = scope.ServiceProvider.GetService<IGoodsInfo>();
                var customerConsumptionVoucherService = scope.ServiceProvider.GetService<ICustomerConsumptionVoucherService>();
                var ordres = await orderService.TimeOutOrderAsync();
                List<UpdateOrderDto> updateOrderList = new List<UpdateOrderDto>();
                foreach (var item in ordres)
                {
                    UpdateOrderDto updateOrder = new UpdateOrderDto();
                    updateOrder.OrderId = item.Id;
                    updateOrder.StatusCode = OrderStatusCode.TRADE_CLOSED_BY_TAOBAO;
                    updateOrder.AppType = (byte)AppType.MiniProgram;
                    updateOrderList.Add(updateOrder);
                    await goodsService.AddGoodsInventoryQuantityAsync(item.GoodsId, (int)item.Quantity);
                    
                }
                await orderService.UpdateAsync(updateOrderList);
                //退还抵用券
                foreach (var item in ordres)
                {
                    if (item.IsUseCoupon)
                    {
                        UpdateCustomerConsumptionVoucherDto updateCustomerConsumptionVoucherDto = new UpdateCustomerConsumptionVoucherDto();
                        updateCustomerConsumptionVoucherDto.CustomerVoucherId = item.CouponId;
                        updateCustomerConsumptionVoucherDto.IsUsed = false;
                        updateCustomerConsumptionVoucherDto.UseDate = DateTime.Now;
                        await customerConsumptionVoucherService.UpdateCustomerConsumptionVoucherUseStatusAsync(updateCustomerConsumptionVoucherDto);
                    }

                }
            }
               
        }
        /// <summary>
        /// 处理超时未支付的充值订单
        /// </summary>
        /// <returns></returns>

        [Invoke(Begin = "00:00:00", Interval = 1000 * 60 * 5, SkipWhileExecuting = true)]
        public async Task HandleTimeOutRecharge()
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var balanceRechargeRecordService = scope.ServiceProvider.GetService<IBalanceRechargeService>();
                    await balanceRechargeRecordService.CancelUnPayREchargeOrderAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("处理超时订单失败");
            }
        }



    }
}
