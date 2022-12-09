using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlatFormOrderSend
{
    public class HospitalCurrentDayNotRepeatedSendOrderVo
    {
        public int Id { get; set; }
        /// <summary>
        /// 派单状态
        /// </summary>
        public int OrderStatus { get; set; }
        /// <summary>
        /// 派单状态文本
        /// </summary>
        public string OrderStatusText { get; set; }
        /// <summary>
        /// 处理状态
        /// </summary>
        public string ProcessStatus { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Item { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public string UserInfo { get; set; }
        /// <summary>
        /// 最后更近内容
        /// </summary>
        public string LastFollowContent { get; set; }
    }
}
