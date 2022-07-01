using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.AmiyaEmployee
{
  public  class UpdatePasswordAmiyaDto
    {
        /// <summary>
        /// 旧密码
        /// </summary>
        public string OldPassword { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPassword { get; set; }
    }
}
