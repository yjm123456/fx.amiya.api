using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalCheckPhoneRecord
{
    public class HospitalCheckPhoneRecordVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 医院员工编号
        /// </summary>
        public int HospitalEmployeeId { get; set; }

        /// <summary>
        /// 医院员工名称
        /// </summary>
        public string HospitalEmployeeName { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 查看时间
        /// </summary>
        public DateTime Date { get; set; }
    }
}
