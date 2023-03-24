using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class FaceTagWithAestheticsDesignReport
    {
        /// <summary>
        /// 美学设计报告id
        /// </summary>
        public string ReportId { get; set; }
        /// <summary>
        /// 标签id
        /// </summary>
        public string TagId { get; set; }
        /// <summary>
        /// 图片方向(0,正面图片1,侧面图片)
        /// </summary>
        public int DirectType { get; set; }
    }
}
