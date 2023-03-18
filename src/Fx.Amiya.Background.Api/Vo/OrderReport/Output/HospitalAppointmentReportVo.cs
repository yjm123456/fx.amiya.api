using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport.OutPut
{
    /// <summary>
    /// 医院预约报表
    /// </summary>
    public class HospitalAppointmentReportVo
    {
        /// <summary>
        /// 医院名称
        /// </summary>
        [Description("医院名称")]
        public string HospitalName { get; set; }
      
        /// <summary>
        /// 预约日期
        /// </summary>
        [Description("预约日期")]
        public DateTime AppointmentDate { get; set; }
        /// <summary>
        /// 星期
        /// </summary>
        [Description("星期")]
        public string Week { get; set; }

        /// <summary>
        /// 上午/下午
        /// </summary>
        [Description("上午/下午")]
        public string Time { get; set; }
        /// <summary>
        /// 客户电话
        /// </summary>
        [Description("客户电话")]
        public string Phone { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [Description("项目名称")]
        public string ItemName { get; set; }
        /// <summary>
        /// 预约状态
        /// </summary>
        [Description("预约状态")]
        public string StatusText { get; set; }
       
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; }
    }
}
