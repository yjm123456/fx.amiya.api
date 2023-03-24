using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AestheticsDesignReport
{
    public class AddFaceTagDto
    {
        /// <summary>
        /// 标签id
        /// </summary>
        public string TagId { get; set; }
        /// <summary>
        /// 美学设计报告id
        /// </summary>
        public string ReportId { get; set; }
        /// <summary>
        /// 图片方向(0正面图片,1侧面图片)
        /// </summary>
        public int DirectionType { get; set; }
    }
}
