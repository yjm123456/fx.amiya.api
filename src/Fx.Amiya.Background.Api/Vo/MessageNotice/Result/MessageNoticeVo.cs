using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.MessageNotice.Result
{
    public class MessageNoticeVo
    {

        public int ReadCount { get; set; }
        public int UnReadCount { get; set; }
        public List<MessageReturnVo> MessageReturnVos { get; set; }
    }
    public class MessageReturnVo {
        public DateTime CreateDate { get; set; }
        public List<MessageNoticeDetails> Details { get; set; }
    }
    public class MessageNoticeDetails : BaseVo
    {

        public DateTime CreateDateNotInHour { get; set; }
        /// <summary>
        /// 发送人
        /// </summary>
        public int AcceptBy { get; set; }

        /// <summary>
        /// 发送人名称
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
        /// 订单号，通知类型为订单通知时展示
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 通知内容
        /// </summary>
        public string NoticeContent { get; set; }
    }
}
