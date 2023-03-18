using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AestheticsDesign
{
    public class AestheticsDesignInfoDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 美学设计报告id
        /// </summary>
        public string AestheticsDesignReportId { get; set; }
        /// <summary>
        /// 设计内容
        /// </summary>
        public string Design { get; set; }
        /// <summary>
        /// 推荐医院简称
        /// </summary>
        public string SimpleHospitalName { get; set; }
        /// <summary>
        /// 推荐医生
        /// </summary>
        public string RecommendDoctor { get; set; }
    }
}
