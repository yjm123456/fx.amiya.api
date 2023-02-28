using Fx.Amiya.Dto.LiveAnchorBaseInfo;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
   public interface ILiveAnchorBaseInfoService
    {

        /// <summary>
        /// 获取有效的主播基础信息列表
        /// </summary>
        /// <returns></returns>
        Task<List<LiveAnchorBaseInfoDto>> GetValidAsync();

        /// <summary>
        /// 获取主播基础信息列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<LiveAnchorBaseInfoDto>> GetListAsync(string name, bool valid, int pageNum, int pageSize);

        Task DeleteAsync(string id);
        Task AddAsync(AddLiveAnchorBaseInfoDto addDto);
        Task<LiveAnchorBaseInfoDto> GetByIdAsync(string id);
        Task<LiveAnchorBaseInfoDto> GetByNameAsync(string name);
        Task<List<LiveAnchorBaseInfoDto>> GetByIdAndIsSelfLiveAnchorAsync(string id, bool? isSelfLiveAnchor);
        Task UpdateAsync(UpdateLiveAnchorBaseInfoDto updateDto);

    }
}
