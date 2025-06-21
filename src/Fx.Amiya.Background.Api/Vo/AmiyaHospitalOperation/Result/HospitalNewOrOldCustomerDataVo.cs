using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaHospitalOperation.Result
{
    /// <summary>
    /// 机构新老客业绩漏斗图
    /// </summary>
    public class HospitalNewOrOldCustomerDataVo
    {

        /// <summary>
        /// 新客业绩
        /// </summary>
        public HospitalNewCustomerOperationDataVo NewCustomerData { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>

        public HospitalOldCustomerOperationDataVo OldCustomerData { get; set; }
    }


    /// <summary>
    /// 新客业绩输出类
    /// </summary>
    public class HospitalNewCustomerOperationDataVo
    {
      
        /// <summary>
        /// 上门率
        /// </summary>
        public decimal? ToHospitalRate { get; set; }
        /// <summary>
        /// 上门率健康值(当月)
        /// </summary>
        public decimal ToHospitalRateHealthValueThisMonth { get; set; }
        /// <summary>
        /// 成交率
        /// </summary>
        public decimal? DealRate { get; set; }
        /// <summary>
        /// 成交率健康值(当月)
        /// </summary>
        public decimal DealRateHealthValueThisMonth { get; set; }

        /// <summary>
        /// 漏斗图详情数据
        /// </summary>
        public List<HospitalNewCustomerOperationDataDetailsVo> newCustomerOperationDataDetails { get; set; }

    }

    /// <summary>
    /// 老客业绩输出类
    /// </summary>
    public class HospitalOldCustomerOperationDataVo
    {
        /// <summary>
        /// 总成交人数
        /// </summary>
        public int TotalDealPeople { get; set; }

        /// <summary>
        /// 二次复购人数
        /// </summary>
        public int SecondDealPeople { get; set; }


        /// <summary>
        /// 三次复购人数
        /// </summary>
        public int ThirdDealPeople { get; set; }
        /// <summary>
        /// 四次复购人数
        /// </summary>
        public int FourthDealCustomer { get; set; }
        /// <summary>
        /// 五次及以上复购人数
        /// </summary>
        public int FifThOrMoreOrMoreDealCustomer { get; set; }


        /// <summary>
        /// 二次复购占比
        /// </summary>
        public decimal SecondTimeBuyRateProportion { get; set; }
        /// <summary>
        /// 三次复购占比
        /// </summary>
        public decimal ThirdTimeBuyRateProportion { get; set; }
        /// <summary>
        /// 四次复购占比
        /// </summary>
        public decimal FourthTimeBuyRateProportion { get; set; }
        /// <summary>
        /// 五次及以上复购占比
        /// </summary>
        public decimal FifthTimeOrMoreBuyRateProportion { get; set; }
        /// <summary>
        /// 复购率
        /// </summary>
        public decimal BuyRate { get; set; }
        /// <summary>
        /// 二次复购周期
        /// </summary>
        public decimal SecondDealCycle { get; set; }
        /// <summary>
        /// 三次复购周期
        /// </summary>
        public decimal ThirdDealCycle { get; set; }
        /// <summary>
        /// 四次复购周期
        /// </summary>
        public decimal FourthDealCycle { get; set; }
        /// <summary>
        /// 五次复购周期
        /// </summary>
        public decimal FifthDealCycle { get; set; }

    }

    /// <summary>
    /// 业绩输出详情
    /// </summary>
    public class HospitalNewCustomerOperationDataDetailsVo
    {
        /// <summary>
        /// 标识码
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public decimal Value { get; set; }
    }
}
