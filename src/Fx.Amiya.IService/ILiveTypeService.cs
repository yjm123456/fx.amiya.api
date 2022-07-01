using Fx.Amiya.Dto.LiveType;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ILiveTypeService
    {
        /// <summary>
        /// 获取所有直播类型列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<LiveTypeDto>> GetListWithPageAsync(int pageNum, int pageSize);



        /// <summary>
        /// 获取有效的直播类型名称列表
        /// </summary>
        /// <returns></returns>
        Task<List<LiveTypeDto>> GetNameListAsync();

        /// <summary>
        /// 添加直播类型
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddLiveTypeDto addDto);


        /// <summary>
        /// 根据编号获取直播类型信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<LiveTypeDto> GetByIdAsync(int id);


        /// <summary>
        /// 修改直播类型
        /// </summary>
        /// <param name="updateDto"></param>
        Task UpdateAsync(UpdateLiveTypeDto updateDto);


        /// <summary>
        /// 删除直播类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
