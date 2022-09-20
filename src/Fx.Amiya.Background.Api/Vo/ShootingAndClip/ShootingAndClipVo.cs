using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ShootingAndClip
{
    public class ShootingAndClipVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 拍摄人员
        /// </summary>
        public int ShootingEmpId { get; set; }

        /// <summary>
        /// 拍摄人员文本
        /// </summary>
        public string ShootingEmpName { get; set; }
        /// <summary>
        /// 剪辑人员
        /// </summary>
        public int ClipEmpId { get; set; }
        /// <summary>
        /// 剪辑人员文本
        /// </summary>
        public string ClipEmpName { get; set; }

        /// <summary>
        /// 主播平台id
        /// </summary>
        public string ContentPlatFormId { get; set; }
        /// <summary>
        /// 主播id
        /// </summary>
        public int LiveAnchorId { get; set; }
        /// <summary>
        /// 主播名称
        /// </summary>
        public string LiveAnchorName { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime RecordDate { get; set; }
        /// <summary>
        /// 视频标题
        /// </summary>
        public string Title { get; set; }
    }
}
