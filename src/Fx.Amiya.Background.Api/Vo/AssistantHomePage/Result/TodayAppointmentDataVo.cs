using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AssistantHomePage.Result
{
    public class TodayAppointmentDataVo
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
        /// 助理名称 
        /// </summary>
        public string AssistantName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 是否陪诊
        /// </summary>
        public bool IsAccompany { get; set; }
        /// <summary>
        /// 派单机构
        /// </summary>
        public string SendHospital { get; set; }
        /// <summary>
        /// 咨询情况
        /// </summary>
        public string ConsultSituation { get; set; }
        /// <summary>
        /// 加密手机号
        /// </summary>
        public string EncryptPhone { get; set; }
    }
}
