﻿using Fx.Amiya.Dto.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAmiyaPerformanceService
    {

        Task<MonthPerformanceDto> GetMonthPerformance(int year,int month);

        Task<MonthDealPerformanceDto> GetMonthDealPerformance(int year, int month);

        /// <summary>
        /// 获取当月/历史派单当月成交折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isOldSendOrder">是否为历史派单订单</param>
        /// <returns></returns>
        Task<List<PerformanceBrokenLine>> GetHistorySendThisMonthDealOrders(int year, int month, bool isOldSendOrder);
    }
}
