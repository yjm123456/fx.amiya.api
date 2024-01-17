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
        public bool IsDirector { get; set; }
        public string Token { get; set; }

        public string Avatar { get; set; }
        public string RefreshToken { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool ReadDataCenter { get; set; }
        /// <summary>
        /// 读取数据中心直播达人数据
        /// </summary>
        public bool ReadSelfLiveAnchorData { get; set; }
        /// <summary>
        /// 读取数据中心合作达人数据
        /// </summary>
        public bool ReadCooperateLiveAnchorData { get; set; }
        /// <summary>
        /// 读取数据中心带货板块数据
        /// </summary>
        public bool ReadTakeGoodsData { get; set; }
    }
}
