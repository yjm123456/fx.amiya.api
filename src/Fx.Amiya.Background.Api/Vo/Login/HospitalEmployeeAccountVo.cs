using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Login
{
    /// <summary>
    /// 医院员工账户信息
    /// </summary>
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
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }
    }
}
