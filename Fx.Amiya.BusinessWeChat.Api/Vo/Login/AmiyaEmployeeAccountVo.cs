using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWechat.Api.Vo.Login
{
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
        /// <summary>
        /// 读取数据中心
        /// </summary>
        public bool ReadDataCenter { get; set; }
        public string UserId { get; set; }
        public string Code { get; set; }
    }
}
