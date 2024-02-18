using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.MessageNotice.Result
{
    public class MessageNoticeDto : BaseDto
    {

        /// <summary>
        /// 接收人
        /// </summary>
        public int AcceptBy { get; set; }

        /// <summary>
        /// 接收人名称
        /// </summary>
        public string AcceptByEmpName { get; set; }

        /// <summary>
        /// 是否已读
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// 通知类型
        /// </summary>
        public int NoticeType { get; set; }
        /// <summary>
        /// 通知类型文本
        /// </summary>
        public string NoticeTypeText { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 通知内容
        /// </summary>
        public string NoticeContent { get; set; }
    }
}
