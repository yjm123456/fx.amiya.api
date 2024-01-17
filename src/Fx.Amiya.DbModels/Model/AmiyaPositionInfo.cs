using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class AmiyaPositionInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }
        public bool IsDirector { get; set; }
        public int DepartmentId { get; set; }
        public bool ReadDataCenter { get; set; }
        /// <summary>
        /// 查看主播数据
        /// </summary>
        public bool ReadLiveAnchorData { get; set; }
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
        public AmiyaEmployee UpdateByAmiyaEmployee { get; set; }

        public List<AmiyaEmployee> AmiyaEmployeeList { get; set; }
        public List<AmiyaPositionDefaultRoute> PositionDefaultRouteList { get; set; }
        public List<AmiyaPositionModulePermission> PositionModulePermissionList { get; set; }
        public List<AmiyaPositionPermission> AmiyaPositionPermissionList { get; set; }
        public AmiyaDepartment AmiyaDepartment { get; set; }
    }
}
