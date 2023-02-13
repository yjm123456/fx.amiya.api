using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Login
{
    /// <summary>
    /// 啊美雅员工账户信息
    /// </summary>
    public class AmiyaEmployeeAccountVo
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int AmiyaPositionId { get; set; }
        public string AmiyaPositionName { get; set; }
        public string EmployeeType { get; set; }
        public bool IsCustomerService { get; set; }
        public string Token { get; set; }

        public string RefreshToken { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
