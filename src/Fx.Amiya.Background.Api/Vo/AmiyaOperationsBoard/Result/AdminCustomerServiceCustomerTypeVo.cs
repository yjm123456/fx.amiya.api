using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class AdminCustomerServiceCustomerTypeVo
    {
        /// <summary>
        /// 一类客资
        /// </summary>
        public int FirstTypeTotal { get; set; }
        /// <summary>
        /// 当日数据
        /// </summary>
        public int FirstTypeToday { get; set; }

        /// <summary>
        /// 一类客资环比
        /// </summary>
        public decimal FirstTypeChainRate { get; set; }
        /// <summary>
        /// 一类客资同比
        /// </summary>

        public decimal FirstTypeYearOnYear { get; set; }

        /// <summary>
        /// 直播前客资目标
        /// </summary>
        public decimal FirstTypeCustomerTarget { get; set; }
        /// <summary>
        /// 直播前客资完成率
        /// </summary>
        public decimal? FirstTypeCustomerComplete { get; set; }


        /// <summary>
        /// 二类客资
        /// </summary>
        public int SecondTypeTotal { get; set; }
        /// <summary>
        /// 当日数据
        /// </summary>
        public int SecondTypeToday { get; set; }

        /// <summary>
        /// 二类客资环比
        /// </summary>
        public decimal SecondTypeChainRate { get; set; }
        /// <summary>
        /// 二类客资同比
        /// </summary>

        public decimal SecondTypeYearOnYear { get; set; }
        /// <summary>
        /// 直播中客资目标
        /// </summary>
        public decimal SecondTypeCustomerTarget { get; set; }
        /// <summary>
        /// 直播中客资完成率
        /// </summary>
        public decimal? SecondTypeCustomerComplete { get; set; }


        /// <summary>
        /// 三类客资
        /// </summary>
        public int ThirdTypeTotal { get; set; }
        /// <summary>
        /// 当日数据
        /// </summary>
        public int ThirdTypeToday { get; set; }

        /// <summary>
        /// 三类客资环比
        /// </summary>
        public decimal ThirdTypeChainRate { get; set; }
        /// <summary>
        /// 三类客资同比
        /// </summary>

        public decimal ThirdTypeYearOnYear { get; set; }
        /// <summary>
        /// 直播后客资目标
        /// </summary>
        public decimal ThirdTypeCustomerTarget { get; set; }
        /// <summary>
        /// 直播后客资完成率
        /// </summary>
        public decimal? ThirdTypeCustomerComplete { get; set; }

        /// <summary>
        /// 总客资
        /// </summary>
        public int TotalTypeTotal { get; set; }
        /// <summary>
        /// 当日数据
        /// </summary>
        public int TotalTypeToday { get; set; }

        /// <summary>
        /// 总客资环比
        /// </summary>
        public decimal TotalTypeChainRate { get; set; }
        /// <summary>
        /// 总客资同比
        /// </summary>

        public decimal TotalTypeYearOnYear { get; set; }

        /// <summary>
        /// 总客资目标
        /// </summary>
        public decimal TotalCustomerTarget { get; set; }
        /// <summary>
        /// 总客资完成率
        /// </summary>
        public decimal? TotalCustomerComplete { get; set; }
    }
}
