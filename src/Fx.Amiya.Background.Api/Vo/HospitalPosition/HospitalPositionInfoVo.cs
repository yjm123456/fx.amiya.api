using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalPosition
{
    /// <summary>
    /// 医院职位信息模型
    /// </summary>
    public class HospitalPositionInfoVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 职位名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateDate { get; set; }

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
