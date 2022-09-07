using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 会员卡发放记录
    /// </summary>
    public class MemberCardSendRecord
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        /// <summary>
        /// 发放时间
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 会员卡编号
        /// </summary>
        public string MemberCardNum { get; set; }
        /// <summary>
        /// 会员卡id
        /// </summary>
        public byte MemberRankId { get; set; }
        /// <summary>
        /// 发放人
        /// </summary>
        public int? HandleBy { get; set; }
    }
}
