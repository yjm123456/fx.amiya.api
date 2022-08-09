using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ShoppingCartRegistration
{
    public class EmergencyLevelVo
    {
        /// <summary>
        /// 重要程度 0可忽略，1轻微，2一般，3重要，4非常重要
        /// </summary>
        public int EmergencyLevel { get; set; }
        /// <summary>
        /// 重要程度文本描述
        /// </summary>
        public string EmergencyLevelText { get; set; }
    }
}
