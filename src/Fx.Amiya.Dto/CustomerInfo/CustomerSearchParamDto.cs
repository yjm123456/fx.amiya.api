using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerInfo
{
    public class CustomerSearchParamDto
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
        /// 生日月份
        /// </summary>
        public int? BirthMonth { get; set; }

        /// <summary>
        /// 绑定客服的编号，-1查全部
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 会员级别编号，-1=普通客户（非会员），null=全部
        /// </summary>
        public int? MemberRankId { get; set; }

        /// <summary>
        /// 是否未回访
        /// </summary>
        public bool IsUnTrack { get; set; }

        /// <summary>
        /// 未回访开始时间
        /// </summary>
        public DateTime? UnTrackStartDate { get; set; }

        /// <summary>
        /// 未回访结束时间
        /// </summary>
        public DateTime? UnTrackEndDate { get; set; }

        /// <summary>
        /// 会员客户编号数组
        /// </summary>
        public List<string> MemberCustomerIds { get; set; }

        /// <summary>
        /// 订单总额类型，0=下单总额，1=核销总额
        /// </summary>
        public int AmountType { get; set; }

        /// <summary>
        /// 最小总额
        /// </summary>
        public decimal? MinAmount { get; set; }
        /// <summary>
        /// 最大总额
        /// </summary>
        public decimal? MaxAmount { get; set; }


        /// <summary>
        /// 客户类型，0=全部，1=已注册小程序，2=未注册小程序
        /// </summary>
        public int CustomerType { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }
}
