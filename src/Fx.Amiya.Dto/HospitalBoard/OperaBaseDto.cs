using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalBoard
{
    public class OperaBaseDto
    {
        /// <summary>
        /// 新客上门量
        /// </summary>
        public decimal NewCustomerToHospitalCount { get; set; }
        /// <summary>
        /// 累计新客上门量
        /// </summary>
        public decimal AccumulateNewCustomerToHospitalCount { get; set; }
        /// <summary>
        /// 新客成交量
        /// </summary>
        public decimal NewCustomerDealCount { get; set; }
        

        /// <summary>
        /// 老客上门量
        /// </summary>
        public decimal OldCustomerToHospitalCount { get; set; }
        
        /// <summary>
        /// 老客成交量
        /// </summary>
        public decimal OldCustomerDealCount { get; set; }
        


        /// <summary>
        /// 新客上门率
        /// </summary>
        public decimal? NewCustomerToHospitalRatio { get; set; }
       
        /// <summary>
        /// 新客上门率健康值
        /// </summary>
        public decimal? NewCustomerToHospitalRatioHealthValue { get; set; }


        /// <summary>
        /// 新客成交率
        /// </summary>
        public decimal? NewCustomerDealRation { get; set; }
        

        /// <summary>
        /// 新客成交率健康值
        /// </summary>
        public decimal NewCustomerDealRationHealthValue { get; set; }


        /// <summary>
        /// 老客复购率
        /// </summary>
        public decimal? OldCustomerRepurchaseRatio { get; set; }
        
        /// <summary>
        /// 老客复购率健康值
        /// </summary>
        public decimal OldCustomerRepurchaseRatioHealthValue { get; set; }



        /// <summary>
        /// 老客成交率
        /// </summary>
        public decimal? OldCustomerDealRation { get; set; }
       
        /// <summary>
        /// 老客成交率健康值
        /// </summary>
        public decimal OldCustomerDealRationHealthValue { get; set; }
    }
}
