using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AestheticsDesign
{
    public class UpdateAestheticsDesgnDto
    {
        /// <summary>
        /// 美学设计id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 设计内容
        /// </summary>
        public string Design { get; set; }
        /// <summary>
        /// 推荐医院简称
        /// </summary>
        public string SimpleHospitalName { get; set; }
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
        public List<string> PictureTags { get; set; }
        /// <summary>
        /// 侧面图片标签
        /// </summary>
        public string SidePicture { get; set; }
        /// <summary>
        /// 正面图片标签
        /// </summary>
        public string FrontPicture { get; set; }
    }
}
