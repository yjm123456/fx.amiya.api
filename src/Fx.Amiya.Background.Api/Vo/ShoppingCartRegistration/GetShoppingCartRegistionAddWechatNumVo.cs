using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ShoppingCartRegistration
{
    public class GetShoppingCartRegistionAddWechatNumVo
    {
        /// <summary>
        /// 医美客资加v量
        /// </summary>
        public int BeautyCustomerAddWechatNum { get; set; }

        /// <summary>
        /// 带货客资加v量
        /// </summary>
        public int TakeGoodsCustomerAddWechatNum { get; set; }
        /// <summary>
        /// 当前组加v率
        /// </summary>
        public decimal? AddWeChatRate { get; set; }
        public ShoppingCartRegistionAddNumAndCompleteRateVo shoppingCartRegistionAddNumAndCompleteRateVo { get; set; }
    }

    public class ShoppingCartRegistionAddNumAndCompleteRateVo
    {
        /// <summary>
        /// 小黄车创建量
        /// </summary>
        public int CreateNum { get; set; }
        /// <summary>
        /// 小黄车创建目标
        /// </summary>
        public int CreateNumTarget { get; set; }
        /// <summary>
        /// 小黄车创建目标完成率
        /// </summary>
        public decimal? CreateNumCompleteRate { get; set; }
    }
}
