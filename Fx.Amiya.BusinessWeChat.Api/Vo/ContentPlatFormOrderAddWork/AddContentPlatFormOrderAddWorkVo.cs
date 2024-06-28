using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlatFormOrderAddWork
{
    public class AddContentPlatFormOrderAddWorkVo
    {

        /// <summary>
        /// 接收人
        /// </summary>
        public int AcceptBy { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 申请类型
        /// </summary>
        public int AddWorkType { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 申请理由
        /// </summary>
        public string SendRemark { get; set; }
        /// <summary>
        /// 截图
        /// </summary>
        public string Picture { get; set; }
    }
}
