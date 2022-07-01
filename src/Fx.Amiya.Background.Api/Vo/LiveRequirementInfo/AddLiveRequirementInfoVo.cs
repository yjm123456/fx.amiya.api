using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveRequirementInfo
{
    public class AddLiveRequirementInfoVo
    {
        /// <summary>
        /// 主播编号
        /// </summary>
        public int LiveAnchorId { get; set; }

        /// <summary>
        /// 直播类型编号
        /// </summary>
        public int LiveTypeId { get; set; }


        /// <summary>
        /// 需求类型编号
        /// </summary>
        public int RequirementTypeId { get; set; }

        /// <summary>
        /// 粉丝信息
        /// </summary>
        public string FansInfo { get; set; }

        /// <summary>
        /// 需求描述
        /// </summary>
        [Required(ErrorMessage = "需求描述不能为空")]
        [MinLength(20,ErrorMessage = "需求描述不能低于20个字符")]
        public string Description { get; set; }

        /// <summary>
        /// 指派部门
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// 优先级 0=一般，1=紧急
        /// </summary>
        public byte PriorityLevel { get; set; }
    }
}
