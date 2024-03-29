﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.AmiyaPositionInfo
{
    public class AddAmiyaPositionInfoDto
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public bool IsDirector { get; set; }
        public bool ReadDataCenter { get; set; }
        /// <summary>
        /// 查看主播数据
        /// </summary>
        public bool ReadLiveAnchorData { get; set; }
    }
}
