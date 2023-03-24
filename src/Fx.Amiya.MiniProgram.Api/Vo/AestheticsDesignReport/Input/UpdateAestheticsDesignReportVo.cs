using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.AestheticsDesignReport.Input
{
    /// <summary>
    /// 修改美学设计报告
    /// </summary>
    public class UpdateAestheticsDesignReportVo
    {
        /// <summary>
        /// 美学设计报告id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? BirthDay { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 所在城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 是否有医美经历
        /// </summary>
        public bool? HasAestheticMedicineHistory { get; set; }
        /// <summary>
        /// 微创调整的部位以及所用材料
        /// </summary>
        public string HistoryDescribe1 { get; set; }
        /// <summary>
        /// 整形调整的部位
        /// </summary>
        public string HistoryDescribe2 { get; set; }
        /// <summary>
        /// 皮肤做过的仪器或项目
        /// </summary>
        public string HistoryDescribe3 { get; set; }
        /// <summary>
        /// 是否接受手术
        /// </summary>
        public bool? WhetherAcceptOperation { get; set; }
        /// <summary>
        /// 是否有过过敏史或其他疾病
        /// </summary>
        public bool? WhetherAllergyOrOtherDisease { get; set; }
        /// <summary>
        /// 过敏或疾病描述
        /// </summary>
        public string AllergyOrOtherDiseaseDescribe { get; set; }
        /// <summary>
        /// 变美需求
        /// </summary>
        public string BeautyDemand { get; set; }
        /// <summary>
        /// 预算
        /// </summary>
        public decimal Budget { get; set; }
        /// <summary>
        /// 正面照片
        /// </summary>
        public string FrontPicture { get; set; }
        /// <summary>
        /// 侧面照片
        /// </summary>
        public string SidePicture { get; set; }
    }
}
