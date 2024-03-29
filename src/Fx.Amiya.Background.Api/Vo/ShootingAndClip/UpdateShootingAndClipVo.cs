﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ShootingAndClip
{
    public class UpdateShootingAndClipVo
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
        /// 剪辑人员
        /// </summary>
        public int ClipEmpId { get; set; }
        /// <summary>
        /// 主播id
        /// </summary>
        public int LiveAnchorId { get; set; }
        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime RecordDate { get; set; }
        /// <summary>
        /// 视频标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 视频类型
        /// </summary>
        public int VideoType { get; set; }
    }
}
