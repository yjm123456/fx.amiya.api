using Fx.Amiya.Dto;
using Fx.Amiya.Dto.MiniProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IMiniprogramService
    {
        /// <summary>
        /// 获取小程序名称列表
        /// </summary>
        /// <returns></returns>
        Task<List<BaseKeyValueDto<string>>> GetMiniProgramNameListAsync();
        /// <summary>
        /// 根据appid获取小程序信息
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        Task<MiniprogramInfoDto> GetMiniprogramInfoByAppIdAsync(string appId);
        
    }
}
