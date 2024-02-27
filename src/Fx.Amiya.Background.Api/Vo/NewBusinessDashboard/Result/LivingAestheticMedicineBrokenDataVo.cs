using Fx.Amiya.Background.Api.Vo.Performance.AmiyaPerformance2.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.NewBusinessDashboard
{
    public class LivingAestheticMedicineBrokenDataVo
    {
        /// <summary>
        /// 设计卡下单
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> DesignCardOrderData { get; set; }
        /// <summary>
        /// 设计卡退单
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> DesignCardRefundData { get; set; }
        /// <summary>
        /// 设计卡实际
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> DesignCardActualData { get; set; }
        
    }
}
