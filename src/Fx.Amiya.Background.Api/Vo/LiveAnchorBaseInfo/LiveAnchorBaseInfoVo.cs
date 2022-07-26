using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveAnchorBaseInfo
{
    public class LiveAnchorBaseInfoVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 主播名称
        /// </summary>
        public string LiveAnchorName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string ThumbPicture { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 个性签名
        /// </summary>
        public string IndividualitySignature { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 详情图
        /// </summary>
        public string DetailPicture { get; set; }
        /// <summary>
        /// 视频地址
        /// </summary>
        public string VideoUrl { get; set; }
        /// <summary>
        /// 合同地址
        /// </summary>
        public string ContractUrl { get; set; }
        /// <summary>
        /// 是否主推，默认传否
        /// </summary>
        public int? IsMain { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime? DueTime { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Valid { get; set; }
    }
}
