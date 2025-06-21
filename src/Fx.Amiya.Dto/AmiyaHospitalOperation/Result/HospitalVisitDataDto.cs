using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaHospitalOperation.Result
{
    public class HospitalVisitDataDto
    {
        /// <summary>
        /// 今日新客上门人数
        /// </summary>
        public int TodayNewCustomerNum { get; set; }
        /// <summary>
        /// 累计新客上门人数
        /// </summary>
        public int TotalNewCustomerNum { get; set; }
        /// <summary>
        /// 新客上门人数上月环比
        /// </summary>
        public decimal NewCustomerNumChainRate { get; set; }

        /// <summary>
        /// 新客上门人数去年同比
        /// </summary>
        public decimal NewCustomerNumYearOnYearData { get; set; }

        /// <summary>
        /// 今日老客上门人数
        /// </summary>
        public int TodayOldCustomerNum { get; set; }
        /// <summary>
        /// 累计老客上门人数
        /// </summary>
        public int TotalOldCustomerNum { get; set; }
        /// <summary>
        /// 老客上门人数上月环比
        /// </summary>
        public decimal OldCustomerNumChainRate { get; set; }

        /// <summary>
        /// 老客上门人数去年同比
        /// </summary>
        public decimal OldCustomerNumYearOnYearData { get; set; }

        /// <summary>
        /// 今日总上门人数
        /// </summary>
        public int TodayTotalCustomerNum { get; set; }
        /// <summary>
        /// 累计总上门人数
        /// </summary>
        public int TotalTotalCustomerNum { get; set; }
        /// <summary>
        /// 总上门人数上月环比
        /// </summary>
        public decimal TotalCustomerNumChainRate { get; set; }

        /// <summary>
        /// 总上门人数去年同比
        /// </summary>
        public decimal TotalCustomerNumYearOnYearData { get; set; }
    }
}
