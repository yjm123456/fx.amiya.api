using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaGoodsDemand
{
    /// <summary>
    /// 新增商品需求
    /// </summary>
    public class AddAmiyaGoodsDemandVo
    {
        /// <summary>
        /// 商品需求名称
        /// </summary>
        [Required]
        public string ProjectName { get; set; }
        /// <summary>
        /// 科室编号
        /// </summary>
        [Required]
        public string HospitalDepartmentId { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        public string ThumbPictureUrl { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
