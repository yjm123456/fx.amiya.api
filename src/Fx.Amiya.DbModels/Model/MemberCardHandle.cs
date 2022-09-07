using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 用户会员卡
    /// </summary>
    public class MemberCardHandle
    {
        /// <summary>
        /// 会员卡编号
        /// </summary>
        public string MemberCardNum { get; set; }
        public string CustomerId { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 会员卡id
        /// </summary>
        public byte MemberRankId { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public int? HandleBy { get; set; }
        public MemberCardRankInfo MemberRankInfo { get; set; }
    }
}
