using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaHospitalOperation.Input
{
    public class QueryHospitalVisitDataDto
    {
        /// <summary>
        /// 开始时间(开始时间结束时间都为null时查询当日数据)
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 机构id
        /// </summary>
        public int? HospitalId { get; set; }
        /// <summary>
        /// 新客
        /// </summary>
        public bool NewCustomer { get; set; }
        /// <summary>
        /// 老客
        /// </summary>
        public bool OldCustomer { get; set; }
    }
}
