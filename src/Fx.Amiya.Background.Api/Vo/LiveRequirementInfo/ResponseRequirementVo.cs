using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveRequirementInfo
{
    public class ResponseRequirementVo
    {
        /// <summary>
        /// 需求编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 是否接受
        /// </summary>
        public bool IsAccept { get; set; }


        /// <summary>
        /// 描述说明
        /// </summary>
        public string ResponseDescription { get; set; }
    }
}
