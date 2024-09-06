using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class AssistantDistributeConsulationVo
    {
        /// <summary>
        /// 当日一类客资
        /// </summary>
        public int FirstTypeCurrentDay { get; set; }

        /// <summary>
        /// 一类客资累计
        /// </summary>
        public int FirstTypeTotal { get; set; }

        /// <summary>
        /// 一类客资环比
        /// </summary>
        public decimal FirstTypeChainRate { get; set; }
        /// <summary>
        /// 一类客资同比
        /// </summary>

        public decimal FirstTypeYearOnYear { get; set; }

        /// <summary>
        /// 当日二类客资
        /// </summary>
        public int SecondTypeCurrentDay { get; set; }

        /// <summary>
        /// 二类客资累计
        /// </summary>
        public int SecondTypeTotal { get; set; }

        /// <summary>
        /// 二类客资环比
        /// </summary>
        public decimal SecondTypeChainRate { get; set; }
        /// <summary>
        /// 二类客资同比
        /// </summary>

        public decimal SecondTypeYearOnYear { get; set; }


        /// <summary>
        /// 当日三类客资
        /// </summary>
        public int ThirdTypeCurrentDay { get; set; }

        /// <summary>
        /// 三类客资累计
        /// </summary>
        public int ThirdTypeTotal { get; set; }

        /// <summary>
        /// 三类客资环比
        /// </summary>
        public decimal ThirdTypeChainRate { get; set; }
        /// <summary>
        /// 三类客资同比
        /// </summary>

        public decimal ThirdTypeYearOnYear { get; set; }


        /// <summary>
        /// 当日总客资
        /// </summary>
        public int TotalTypeCurrentDay { get; set; }

        /// <summary>
        /// 总客资累计
        /// </summary>
        public int TotalTypeTotal { get; set; }

        /// <summary>
        /// 总客资环比
        /// </summary>
        public decimal TotalTypeChainRate { get; set; }
        /// <summary>
        /// 总客资同比
        /// </summary>
        public decimal TotalTypeYearOnYear { get; set; }

    }
    
}
