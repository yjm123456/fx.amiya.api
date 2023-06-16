using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaEmployee
{
    public class UpdateAvatarVo
    {
        /// <summary>
        /// 1:啊美雅端,2:医院端
        /// </summary>
        public int Type { get; set; }
        public int Id { get; set; }
        public string Url { get; set; }
    }
}
