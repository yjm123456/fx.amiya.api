using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.WxAppConfig
{
    /// <summary>
    /// 方旋消息中心配置
    /// </summary>
   public class FxMessageCenterConfigDto
    {
        public bool EnableMessageCenter { get; set; }
        public bool EnableMessageQueue { get; set; }
        public string MQHostName { get; set; }
        public string MQUserName { get; set; }
        public int Port { get; set; }
        public string MQPassword { get; set; }
        public string MQQueueName { get; set; }

        public string MessageCenterWebSocketUrl { get; set; }
    }
}
