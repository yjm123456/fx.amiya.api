using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.MessageRecieve
{
    public class MessageRecieveDto
    {
        public string Id { get; set; }
      
        /// <summary>
        /// 是否接受消息
        /// </summary>
        public bool IsReceive { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime { get; set; }
    }
}
