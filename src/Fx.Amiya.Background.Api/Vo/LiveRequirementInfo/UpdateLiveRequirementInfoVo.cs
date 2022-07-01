using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveRequirementInfo
{
    public class UpdateLiveRequirementInfoVo
    {
        public int Id { get; set; }
        public int LiveAnchorId { get; set; }
        public int LiveTypeId { get; set; }
        public int RequirementTypeId { get; set; }
        public string FansInfo { get; set; }

        [Required(ErrorMessage ="直播需求描述不能为空")]
        public string Description { get; set; }
        public int DepartmentId { get; set; }

        /// <summary>
        /// 优先级   0=一般，1=紧急
        /// </summary>
        public byte PriorityLevel { get; set; }
    }
}
