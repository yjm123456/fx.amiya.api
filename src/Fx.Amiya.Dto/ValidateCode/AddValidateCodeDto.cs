using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.ValidateCode
{
   public class AddValidateCodeDto
    {
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
        public int ExpireInSeconds { get; set; }
    }
}
