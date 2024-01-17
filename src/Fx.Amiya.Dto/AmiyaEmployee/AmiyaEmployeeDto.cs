using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.AmiyaEmployee
{
    public class AmiyaEmployeeDto
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PositionId { get; set; }
        public string PositionName { get; set; }

        public bool Valid { get; set; }
        public string Email { get; set; }
        public bool IsCustomerService { get; set; }
        public bool IsDirector { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string UserId { get; set; }
        public string Code { get; set; }
        public bool ReadDataCenter { get; set; }
        /// <summary>
        /// 查看主播数据
        /// </summary>
        public bool ReadLiveAnchorData { get; set; }
        public string LiveAnchorBaseId { get; set; }
        public string LiveAnchorBaseName { get; set; }
        /// <summary>
        /// 新客提成
        /// </summary>
        public decimal? NewCustomerCommission { get; set; }
        /// <summary>
        /// 老客提成
        /// </summary>
        public decimal? OldCustomerCommission { get; set; }
        /// <summary>
        /// 稽查提成
        /// </summary>
        public decimal? InspectionCommission { get; set; }
        public List<int> LiveAnchorIds { get; set; }
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
