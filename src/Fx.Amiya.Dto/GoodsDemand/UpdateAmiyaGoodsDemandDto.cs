using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.GoodsDemand
{
    public class UpdateAmiyaGoodsDemandDto
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
        /// 医院科室id
        /// </summary>
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
        public bool Valid { get; set; }
    }
}
