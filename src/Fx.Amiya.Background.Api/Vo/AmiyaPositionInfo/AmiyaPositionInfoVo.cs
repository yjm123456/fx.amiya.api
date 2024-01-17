using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaPositionInfo
{
    public class AmiyaPositionInfoVo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }
        public string UpdateName { get; set; }
        public bool IsDirector { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool ReadDataCenter { get; set; }
        /// <summary>
        /// 查看主播数据
        /// </summary>
        public bool ReadLiveAnchorData { get; set; }
        /// <summary>
        /// 读取数据中心自播达人数据
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
