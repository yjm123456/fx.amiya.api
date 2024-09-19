using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.ThirdPartContentPlatformInfo
{
    public class ThirdPartContentPlatformInfoToLangZiResultVo
    {
        /// <summary>
        /// 派单编号-接⼝发送时派单编号
        /// </summary>
        public string PDBH { get; set; }

        /// <summary>
        /// 总: 查重结果 【0 - ⽆重复 1 - 已被其他通路建档 2 - 已被所在通路建档】
        /// </summary>
        public string RESULT { get; set; }
        /// <summary>
        /// 状态 【0 - 报⽂接收失败 1 - 报⽂接收成功】
        /// </summary>
        public string RECODE { get; set; }

        /// <summary>
        /// 返回消息 
        /// </summary>
        public string REMSG { get; set; }
        /// <summary>
        /// ⼿机1查重结果
        /// </summary>
        public string RESULT1 { get; set; }
        /// <summary>
        /// ⼿机2查重结果
        /// </summary>
        public string RESULT2 { get; set; }
        /// <summary>
        /// ⼿机3查重结果
        /// </summary>
        public string RESULT3 { get; set; }

    }
}
