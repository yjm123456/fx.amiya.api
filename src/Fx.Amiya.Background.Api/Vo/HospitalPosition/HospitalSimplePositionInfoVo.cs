using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalPosition
{
    /// <summary>
    /// 医院端获取职位下拉框
    /// </summary>
    public class HospitalSimplePositionInfoVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 职位名称
        /// </summary>
        public string Name{ get; set; }
    }
}
