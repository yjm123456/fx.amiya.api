using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.RecommendHospital
{
    public class RecommendHospitalInfoVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

       /// <summary>
       /// 医院编号
       /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 排列序号
        /// </summary>
        public int RecommendIndex { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 创建人编号
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string CreateName { get; set; }

        /// <summary>
        /// 修改人编号
        /// </summary>
        public int? UpdateBy { get; set; }

        /// <summary>
        /// 修改人姓名
        /// </summary>
        public string UpdateName { get; set; }
    }
}
