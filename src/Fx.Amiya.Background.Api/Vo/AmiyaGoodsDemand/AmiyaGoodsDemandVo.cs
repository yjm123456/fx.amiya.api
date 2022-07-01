using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaGoodsDemand
{
    /// <summary>
    /// 商品需求
    /// </summary>
    public class AmiyaGoodsDemandVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectNname { get; set; }
        /// <summary>
        /// 医院科室名称Id
        /// </summary>
        public string HospitalDepartmentId { get; set; }
        /// <summary>
        /// 医院科室名称
        /// </summary>
        public string HospitalDepartmentName { get; set; }
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
        public bool Valid { get; set; }
    }
}
