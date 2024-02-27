using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.NewBusinessDashboard
{
    public class LivingAestheticMedicineBrokenDataItemDto
    {
        /// <summary>
        /// 时间
        /// </summary>
        public string Time { get; set; }
        public string BaseLiveAnchorId { get; set; }
        /// <summary>
        /// 设计卡下单
        /// </summary>
        public decimal DesignCardOrder { get; set; }

        /// <summary>
        /// 设计卡退单
        /// </summary>
        public decimal DesignCardRefund { get; set; }

        /// <summary>
        /// 设计卡实际
        /// </summary>
        public decimal DesignCardActual { get; set; }

       
    }
}
