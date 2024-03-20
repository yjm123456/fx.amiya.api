using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Track
{
    public class TrackRecordVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 电话号
        /// </summary>
        public string Phone { get; set; }

        public string EncryptPhone { get; set; }

        /// <summary>
        /// 回访时间
        /// </summary>
        public DateTime TrackDate { get; set; }

        /// <summary>
        /// 回访内容
        /// </summary>
        public string TrackContent { get; set; }

        /// <summary>
        /// 回访主题编号
        /// </summary>
        public int? TrackThemeId { get; set; }

        /// <summary>
        /// 回访主题
        /// </summary>
        public string TrackTheme { get; set; }
        /// <summary>
        /// 回访计划
        /// </summary>
        public string TrackPlan { get; set; }

        /// <summary>
        /// 回访类型编号
        /// </summary>
        public int TrackTypeId { get; set; }

        /// <summary>
        /// 回访类型名称
        /// </summary>
        public string TrackTypeName { get; set; }

        /// <summary>
        /// 回访工具编号
        /// </summary>
        public int TrackToolId { get; set; }

        /// <summary>
        /// 回访工具名称
        /// </summary>
        public string TrackToolName { get; set; }

        /// <summary>
        /// 回访员工编号
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 回访员工姓名
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }

        /// <summary>
        /// 通话记录编号
        /// </summary>
        public string CallRecordId { get; set; }

        /// <summary>
        /// 是否设置了下次回访
        /// </summary>
        public bool IsPlanTrack { get; set; }

        /// <summary>
        /// 下次回访主题
        /// </summary>
        public string PlanTrackTheme { get; set; }
        /// <summary>
        /// 回访截图1
        /// </summary>
        public string TrackPicture1 { get; set; }
        /// <summary>
        /// 回访截图2
        /// </summary>
        public string TrackPicture2 { get; set; }
        /// <summary>
        /// 回访截图3
        /// </summary>
        public string TrackPicture3 { get; set; }
    }
}
