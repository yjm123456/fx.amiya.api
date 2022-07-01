using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.BeautyDiaryTagInfo
{
    public class UpdateBeautyDiaryTagInfoVo
    {
       /// <summary>
       /// 标签编号
       /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }
    }
}
