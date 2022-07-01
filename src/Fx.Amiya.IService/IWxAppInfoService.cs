using Fx.Amiya.Dto.WxAppInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
   public interface IWxAppInfoService
    {
        Task<bool> AddAsync(WxAppInfoAddDto addDto);
        Task EditAsync(WxAppInfoEditDto editDto);
        Task<List<WxAppInfoDto>> GetWxAppInfosAsync(bool? valid);
        Task<WxAppInfoDto> GetByIdAsync(string appid);
    }
}
