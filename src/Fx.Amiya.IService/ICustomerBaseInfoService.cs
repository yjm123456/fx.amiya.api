using Fx.Amiya.Dto.CustomerBaseInfo;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ICustomerBaseInfoService
    {
        Task<CustomerBaseInfoDto> GetByEncryptPhoneAsync(string encryptPhone);
        Task UpdateAsync(UpdateCustomerBaseInfoDto updateDto);
    }
}
