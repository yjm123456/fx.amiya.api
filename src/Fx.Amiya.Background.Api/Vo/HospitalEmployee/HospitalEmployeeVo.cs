using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalEmployee
{
    public class HospitalEmployeeVo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }

        public bool Valid { get; set; }

        /// <summary>
        /// 是否允许创建子账户
        /// </summary>
        public bool IsCreateSubAccount { get; set; }

        /// <summary>
        /// 医院职位编号
        /// </summary>
        public int HospitalPositionId { get; set; }

        /// <summary>
        /// 医院职位名称
        /// </summary>
        public string HospitalPositionName { get; set; }
        public bool IsCustomerService { get; set; }
    }
}
