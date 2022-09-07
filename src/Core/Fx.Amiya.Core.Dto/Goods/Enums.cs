using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Goods
{
    /// <summary>
    /// 商品类型
    /// </summary>
    public enum GoodsType
    {
        /// <summary>
        /// 普通商品
        /// </summary>
        General
    }


    /// <summary>
    /// 交易类型
    /// </summary>
    public enum ExchangeType
    {
        /// <summary>
        /// 积分=0
        /// </summary>
        Integration,
        /// <summary>
        /// 三方支付=1(支付宝，微信)
        /// </summary>
        ThirdPartyPayment,
        /// <summary>
        /// 线下支付
        /// </summary>
        OffLinePay,
        /// <summary>
        /// 余额支付
        /// </summary>
        BalancePay
    }

    /// <summary>
    /// 商品分类展示方向枚举类型
    /// </summary>
    public enum ShowDirectionType
    {
        /// <summary>
        /// 积分兑换
        /// </summary>
        Integral,
        /// <summary>
        /// 商城
        /// </summary>
        Store
       
    }
}
