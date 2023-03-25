using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.MiniProgramSendMessage
{
    public class SendAestheticsDesignMessageDto
    {
        public string CustomerId { get; set; }
        /// <summary>
        /// 美学设计报告id
        /// </summary>
        public string ReportId { get; set; }
        /// <summary>
        /// 服务内容
        /// </summary>
        public string   Content { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 设计时间
        /// </summary>
        public string DesignDate { get; set; }
    }
}
