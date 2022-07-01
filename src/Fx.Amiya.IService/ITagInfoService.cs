using Fx.Amiya.Dto.TagInfo;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ITagInfoService
    {


        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<TagInfoDto>> GetListWithPageAsync(byte? type, string name, int pageNum, int pageSize);


        /// <summary>
        /// 根据类型获取标签列表
        /// </summary>
        /// <param name="type">0=医院规模,1=医院设施</param>
        /// <returns></returns>
         Task<List<TagNameDto>> GetNameListAsync(byte? type);


        /// <summary>
        /// 添加标签
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddTagInfoDto addDto);


        /// <summary>
        /// 根据标签编号获取标签信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TagInfoDto> GetByIdAsync(int id);


        /// <summary>
        /// 修改医院标签信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateTagInfoDto updateDto);


        /// <summary>
        /// 删除医院标签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
