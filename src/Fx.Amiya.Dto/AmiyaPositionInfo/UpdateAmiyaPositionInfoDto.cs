using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.AmiyaPositionInfo
{
   public class UpdateAmiyaPositionInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        /// <summary>
        /// 是否为管理员
        /// </summary>
        public bool IsDirector { get; set; }
    }
}
