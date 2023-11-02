using Fx.Amiya.Dto.FeishuAppInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IFeishuAppinfoService
    {
        Task<FeishuAppInfoDto> GetFeishuAppinfoByCodeAsync(int liveAnchorId);
    }
}
