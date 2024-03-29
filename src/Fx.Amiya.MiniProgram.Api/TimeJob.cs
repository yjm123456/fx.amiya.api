﻿using Fx.Amiya.Core.Dto.Goods;
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
        /// 处理啊美雅超时未支付的商城订单
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
                //var thridOrder = ordres.Where(e => e.ExchageType != (int)ExchangeType.PointAndMoney).ToList();
                var pointAndMoneyOrder = ordres.Where(e => e.ExchageType == (int)ExchangeType.PointAndMoney||e.ExchageType==(int)ExchangeType.HuiShouQian).Select(e=>new { e.TradeId ,e.CustomerId}).Distinct().ToList();
                var pointOrder = ordres.Where(e => e.ExchageType == (int)ExchangeType.Integration).Select(e => e.TradeId).Distinct().ToList();
                List<UpdateOrderDto> updateOrderList = new List<UpdateOrderDto>();         
                foreach (var item in pointOrder)
                {
                   await orderService.CancelPointOrderAsync(item);
                } 

                foreach (var item in pointAndMoneyOrder)
                {
                    await orderService.CancelPointAndMoneyOrderAsync(item.TradeId,item.CustomerId);
                }
                
                //退还抵用券
                //foreach (var item in pointAndMoneyOrder)
                //{
                //    if (item.IsUseCoupon)
                //    {
                //        UpdateCustomerConsumptionVoucherDto updateCustomerConsumptionVoucherDto = new UpdateCustomerConsumptionVoucherDto();
                //        updateCustomerConsumptionVoucherDto.CustomerVoucherId = item.CouponId;
                //        updateCustomerConsumptionVoucherDto.IsUsed = false;
                //        updateCustomerConsumptionVoucherDto.UseDate = DateTime.Now;
                //        await customerConsumptionVoucherService.UpdateCustomerConsumptionVoucherUseStatusAsync(updateCustomerConsumptionVoucherDto);
                //    }

                //}
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
                throw new Exception("处理超时充值订单失败");
            }
        }



    }
}
