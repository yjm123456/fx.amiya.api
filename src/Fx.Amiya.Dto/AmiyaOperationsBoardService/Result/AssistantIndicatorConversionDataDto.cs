using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService
{
    public class AssistantIndicatorConversionDataDto
    {
        /// <summary>
        /// 分组名
        /// </summary>
        public string AssistantName { get; set; }
        /// <summary>
        /// 7日派单率
        /// </summary>
        public decimal SevenDaySendOrderRate { get; set; }
        /// <summary>
        /// 15日上门率
        /// </summary>
        public decimal FifteenDaySendOrderRate { get; set; }
        /// <summary>
        /// 老客上门率
        /// </summary>
        public decimal OldCustomerToHospitalRate { get; set; }
        /// <summary>
        /// 复购率
        /// </summary>
        public decimal RePurchaseRate { get; set; }
        /// <summary>
        /// 加微率
        /// </summary>
        public decimal AddWechatRate { get; set; }
        /// <summary>
        /// 派单率
        /// </summary>
        public decimal SendOrderRate { get; set; }
        /// <summary>
        /// 上门率
        /// </summary>
        public decimal ToHospitalRate { get; set; }
        /// <summary>
        /// 新客成交率
        /// </summary>
        public decimal NewCustomerDealRate { get; set; }
        /// <summary>
        /// 新客客单价
        /// </summary>
        public decimal NewCustomerUnitPrice { get; set; }
        /// <summary>
        /// 老客客单价
        /// </summary>
        public decimal OldCustomerUnitPrice { get; set; }
    }
}
