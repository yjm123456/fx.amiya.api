using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport
{
    public class ShootingAndClipReportVo
    {

        /// <summary>
        /// 登记日期
        /// </summary>
        [Description("登记日期")]
        public DateTime RecordDate { get; set; }
        /// <summary>
        /// 拍摄人员
        /// </summary>
        [Description("拍摄人员")]
        public string ShootingEmpName { get; set; }
        /// <summary>
        /// 剪辑人员
        /// </summary>
        [Description("剪辑人员")]
        public string ClipEmpName { get; set; }
        /// <summary>
        /// 主播
        /// </summary>
        [Description("主播")]
        public string LiveAnchorName { get; set; }
        /// <summary>
        /// 视频标题
        /// </summary>
        [Description("视频标题")]
        public string Title { get; set; }
        /// <summary>
        /// 视频类型
        /// </summary>
        [Description("视频类型")]
        public string VideoType { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Description("创建日期")]
        public DateTime CreateDate { get; set; }
    }
}
