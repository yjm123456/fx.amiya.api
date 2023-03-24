using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AestheticsDesignReport.Input
{
    /// <summary>
    /// 美学设计
    /// </summary>
    public class AddAestheticsDesignVo
    {
        /// <summary>
        /// 美学设计报告id
        /// </summary>
        public string AestheticsDesignReportId { get; set; }
        /// <summary>
        /// 设计内容
        /// </summary>
        public string Design { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int? HospitalId { get; set; }
        /// <summary>
        /// 推荐医生
        /// </summary>
        public string RecommendDoctor { get; set; }
        /// <summary>
        /// 图片标签
        /// </summary>
        public List<string> PictireTags { get; set; }
        /// <summary>
        /// 调整后的侧面图片
        /// </summary>
        public string SidePicture { get; set; }
        /// <summary>
        /// 调整后的正面图片
        /// </summary>
        public string FrontPicture { get; set; }
        
    }
}
