using Fx.Amiya.Dto.BeautyDiaryTagInfo;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IBeautyDiaryTagInfoService
    {


        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<BeautyDiaryTagInfoDto>> GetListWithPageAsync(string name, int pageNum, int pageSize);

        /// <summary>
        /// 获取标签列表id和name
        /// </summary>
        /// <returns></returns>
        Task<List<BeautyDiaryTagNameDto>> GetNameListAsync();

        /// <summary>
        /// 添加标签
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddBeautyDiaryTagInfoDto addDto);


        /// <summary>
        /// 根据标签编号获取标签信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BeautyDiaryTagInfoDto> GetByIdAsync(string id);


        /// <summary>
        /// 修改医院标签信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateBeautyDiaryTagInfoDto updateDto);


        /// <summary>
        /// 删除医院标签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);
    }
}
