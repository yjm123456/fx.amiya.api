using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ShoppingCartRegistration
{
    public class ShoppingCartRegistrationIndicatorBaseDataDto
    {
        /// <summary>
        /// 人数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 派单人数
        /// </summary>
        public int SendOrderCount { get; set; }
        /// <summary>
        /// 7日派单数
        /// </summary>
        public int SevenDaySendOrderCount { get; set; }
        /// <summary>
        /// 15日上门数
        /// </summary>
        public int FifteenToHospitalCount { get; set; }
        /// <summary>
        /// 老客人数
        /// </summary>
        public int OldCustomerCount { get; set; }
        /// <summary>
        /// 老客成交人数
        /// </summary>
        public int OldCustomerDealCount { get; set; }
        /// <summary>
        /// 老客上门人数
        /// </summary>
        public int OldCustomerToHospitalCount { get; set; }
        /// <summary>
        /// 老客复购人数
        /// </summary>
        public int OldCustomerRepurchase { get; set; }
        /// <summary>
        /// 加v人数
        /// </summary>
        public int AddWechatCount { get; set; }
        /// <summary>
        /// 上门人数
        /// </summary>
        public int ToHospitalCount { get; set; }
        /// <summary>
        /// 新客人数
        /// </summary>
        public int NewCustomerCount { get; set; }
        /// <summary>
        /// 新客成交人数
        /// </summary>
        public int NewCustomerDealCount { get; set; }
        /// <summary>
        /// 新客总业绩
        /// </summary>
        public decimal NewCustomerTotalPerformance { get; set; }
        /// <summary>
        /// 老客总业绩
        /// </summary>
        public decimal OldCustomerTotalPerformance { get; set; }
        public int EmpId { get; set; }
    }
}
