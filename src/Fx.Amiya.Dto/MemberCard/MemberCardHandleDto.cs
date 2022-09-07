using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.MemberCard
{
    public class MemberCardHandleDto
    {
        /// <summary>
        /// 会员卡编号
        /// </summary>
        public string MemberCardNum { get; set; }
        public string CustomerId { get; set; }
        /// <summary>
        /// 会员卡名称
        /// </summary>
        public string MemberRankName { get; set; }
        /// <summary>
        /// 会员卡编码
        /// </summary>
        public string MemberRankCode { get; set; }
        /// <summary>
        /// 会员卡封面
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 会员卡描述
        /// </summary>
        public string Description { get; set; }
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
    }
}
