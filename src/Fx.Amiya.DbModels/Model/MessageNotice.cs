using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class MessageNotice : BaseDbModel
    {
        /// <summary>
        /// 发送人
        /// </summary>
        public int AcceptBy { get; set; }

        /// <summary>
        /// 是否已读
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// 通知类型
        /// </summary>
        public int NoticeType { get; set; }

        /// <summary>
        /// 通知内容
        /// </summary>
        public string NoticeContent { get; set; }

        public AmiyaEmployee AmiyaEmployeeInfo { get; set; }
    }
}
