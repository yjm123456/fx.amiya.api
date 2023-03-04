using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Integration
{
    public enum IntegrationGenerateType
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


    public enum IntegrationUseType
    {
        /// <summary>
        /// 消费抵用
        /// </summary>
        Consumption,
        /// <summary>
        /// 归还信用积分
        /// </summary>
        Credit,
        /// <summary>
        /// 积分过期
        /// </summary>
        Expired,
        /// <summary>
        /// 自己退费
        /// </summary>
        SelfReturnMoney,
        /// <summary>
        /// 转介绍人退费
        /// </summary>
        ProviderReturnMoney,
        /// <summary>
        /// 兑换礼品
        /// </summary>
        GiftExchange,
        /// <summary>
        /// 客服修正积分
        /// </summary>
        CustomerServiceEdit
    }
}
