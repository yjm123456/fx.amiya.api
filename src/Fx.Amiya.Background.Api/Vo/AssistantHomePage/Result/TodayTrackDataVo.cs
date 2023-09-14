using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AssistantHomePage.Result
{
    public class TodayTrackDataVo
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 回访人
        /// </summary>
        public string TrackAssistantName { get; set; }
        /// <summary>
        /// 回访目的
        /// </summary>
        public string TrackPurpose { get; set; }
        /// <summary>
        /// 备注详情
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 加密手机号
        /// </summary>
        public string EncryptPhone { get; set; }
    }
}
