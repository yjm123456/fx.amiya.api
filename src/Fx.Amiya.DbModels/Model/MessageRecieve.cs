using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class MessageRecieve:BaseDbModel
    {
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 医院员工id
        /// </summary>
        public int? HospitalEmployeeId { get; set; }
        /// <summary>
        /// 是否绑定微信号
        /// </summary>
        public bool IsBindWechat { get; set; }
        /// <summary>
        /// 是否绑定公众号
        /// </summary>
        public bool IsBindOfficialAccounts { get; set; }
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
