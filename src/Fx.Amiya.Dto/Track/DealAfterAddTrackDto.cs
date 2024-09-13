using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Track
{
    public class DealAfterAddTrackDto
    {
        /// <summary>
        /// 员工id
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// 成交的创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 成交客户手机号
        /// </summary>
        public string Phone { get; set; }

        public int Days { get; set; }
    }
}
