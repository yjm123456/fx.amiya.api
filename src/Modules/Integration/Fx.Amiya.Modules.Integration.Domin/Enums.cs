using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Integration.Domin
{
    public enum GenerateType
    {
        /// <summary>
        /// 消费产生=0
        /// </summary>
        Consumption,

        /// <summary>
        /// 赠送=1
        /// </summary>
        Handsel,

        /// <summary>
        /// 活动=2
        /// </summary>
        Activity,

        /// <summary>
        /// 期初=3
        /// </summary>
        Init,

        /// <summary>
        /// 退费归还=4
        /// </summary>
        ReturnMoneyAndReturnIntegration,

        /// <summary>
        /// 退还礼品=5
        /// </summary>
        ReturnGift
    }


}
