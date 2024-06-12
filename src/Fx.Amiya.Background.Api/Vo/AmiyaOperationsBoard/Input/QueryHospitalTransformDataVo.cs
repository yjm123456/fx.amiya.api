using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Input
{
    public class QueryHospitalTransformDataVo
    {
       
        /// <summary>
        /// 刀刀
        /// </summary>
        public bool ShowDaoDao { get; set; }
        /// <summary>
        /// 吉娜
        /// </summary>
        public bool ShowJiNa { get; set; }
        /// <summary>
        /// 合作达人
        /// </summary>
        public bool ShowCooperate { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
        
    }
}
