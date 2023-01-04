using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.GIftCategory
{
    public class GiftCategoryInfoVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 简码
        /// </summary>
        public string SimpleCode { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateDate { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }
    }
}
