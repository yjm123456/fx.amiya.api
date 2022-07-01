using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.MemberCard
{
    public class MemberCardHandleVo
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string MemberCardNum { get; set; }
        /// <summary>
        /// 会员级别编号
        /// </summary>
        public byte MemberRankId { get; set; }

        /// <summary>
        /// 会员级别名称
        /// </summary>
        public string MemberRankName { get; set; }
        /// <summary>
        /// 经手人
        /// </summary>
        public int? HandleBy { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }

        /// <summary>
        /// 会员级别描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 会员卡图片url
        /// </summary>
        public string ImageUrl { get; set; }
    }
}
