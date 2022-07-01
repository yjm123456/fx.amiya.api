using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerInfo
{
    public class CustomerTrackInfoSearchDto
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 创建开始时间
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 创建结束时间
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 绑定客服的编号，-1查全部
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 是否未回访(0查询所有，1：已回访过，2：未回访过)
        /// </summary>
        public int IsUnTrack { get; set; }

        /// <summary>
        /// 客户类型，0=全部，1=已注册小程序，2=未注册小程序
        /// </summary>
        public int CustomerType { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }
}
