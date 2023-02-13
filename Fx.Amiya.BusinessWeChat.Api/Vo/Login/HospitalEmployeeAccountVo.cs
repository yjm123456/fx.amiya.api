using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWechat.Api.Vo.Login
{
    public class HospitalEmployeeAccountVo
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }

        public int HospitalPositionId { get; set; }
        public string HospitalPositionName { get; set; }

        /// <summary>
        /// 员工类型
        /// </summary>
        public string EmployeeType { get; set; }
        public bool IsCustomerService { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
