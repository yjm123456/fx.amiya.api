using Fx.Amiya.Dto.GoodsDemand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaHospitalDepartment
{
    public class AmiyaHospitalDepartmentKeyAndValueDto
    {
        /// <summary>
        /// 科室编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>

        public string DepartmentName{ get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>

        public List<AmiyaGoodsDemandKeyAndValueDto> GoodsDemandList { get; set; }
    }
}
