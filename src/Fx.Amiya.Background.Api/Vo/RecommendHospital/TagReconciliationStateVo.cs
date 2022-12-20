using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.RecommendHospital
{
    public class TagReconciliationStateVo
    {
        /// <summary>
        /// 对账单编号（id）
        /// </summary>
        public List<string>IdList { get; set; }
        /// <summary>
        /// 对账单状态（1:待确认,2:问题账单,3:对账完成）
        /// </summary>
        public int ReconciliationState { get; set; }
        /// <summary>
        /// 问题原因(当标记为问题账单时必填)
        /// </summary>
        public string QuestionReason { get; set; }
    }
}
