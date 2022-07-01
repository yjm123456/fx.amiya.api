using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Partner.Api.Vo.ItemInfo
{
    public class ItemInfoVo
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string TmallGoodsId { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        public string ThumbPicUrl { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Standard { get; set; }

        /// <summary>
        /// 部位
        /// </summary>
        public string Parts { get; set; }

        /// <summary>
        /// 承诺
        /// </summary>
        public string Commitment { get; set; }

        /// <summary>
        /// 保障
        /// </summary>
        public string Guarantee { get; set; }

        /// <summary>
        /// 预约须知
        /// </summary>
        public string AppointmentNotice { get; set; }

    }
}
