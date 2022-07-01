using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaGoodsDemand
{
    /// <summary>
    /// 修改商品需求
    /// </summary>
    public class UpdateAmiyaGoodsDemandVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public string Id { get; set; }
        /// <summary>
        /// 商品需求名称
        /// </summary>
        [Required]
        public string ProjectNname { get; set; }
        /// <summary>
        /// 科室名称
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
        /// <summary>
        /// 是否正常
        /// </summary>
        [Required]
        public bool Valid { get; set; }
    }
}
