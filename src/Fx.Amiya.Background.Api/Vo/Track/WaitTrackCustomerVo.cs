using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Track
{
    public class WaitTrackCustomerVo
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string EncryptPhone { get; set; }
        public DateTime PlanTrackDate { get; set; }
        public int? TrackTypeId { get; set; }
        public string TrackTypeName { get; set; }
        public int? TrackThemeId { get; set; }
        public string TrackTheme { get; set; }
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 回访计划
        /// </summary>
        public string TrackPlan { get; set; }
        public int CreateBy { get; set; }
        public string CreateName { get; set; }
        public bool Status { get; set; }

        /// <summary>
        /// 待回访员工编号
        /// </summary>
        public int PlanTrackEmployeeId { get; set; }

        /// <summary>
        /// 待回访员工姓名
        /// </summary>
        public string PlanTrackEnmployeeName { get; set; }
    }
}
