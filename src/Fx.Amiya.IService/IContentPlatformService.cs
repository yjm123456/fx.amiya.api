using Fx.Amiya.Dto.ContentPlatform;
using Fx.Amiya.Dto.Province;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IContentPlatformService
    {
        /// <summary>
        /// 获取列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ContentPlatformDto>> GetListWithPageAsync(int pageNum, int pageSize);


        /// <summary>
        /// 获取省份列表
        /// </summary>
        /// <returns></returns>
        Task<List<ContentPlatformDto>> GetListAsync(string name, bool? valid);



        /// <summary>
        /// 获取有效的省份列表
        /// </summary>
        /// <returns></returns>
        Task<List<ContentPlatformDto>> GetValidListAsync();


        /// <summary>
        /// 添加省份
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddContentPlatformDto addDto);



        /// <summary>
        /// 根据编号获取省份
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ContentPlatformDto> GetByIdAsync(string id);

        /// <summary>
        /// 修改合作城市
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateContentPlatformDto updateDto);



        /// <summary>
        /// 删除省份
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);
    }
}
