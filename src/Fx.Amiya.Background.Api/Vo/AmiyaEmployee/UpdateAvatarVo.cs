using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaEmployee
{
    /// <summary>
    /// 修改头像输入类
    /// </summary>
    public class UpdateAvatarVo
    {
        /// <summary>
        /// 1:啊美雅端,2:医院端
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string Url { get; set; }
    }
}
