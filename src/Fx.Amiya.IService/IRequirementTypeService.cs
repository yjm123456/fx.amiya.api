using Fx.Amiya.Dto.RequirementType;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IRequirementTypeService
    {
        /// <summary>
        /// 获取所有需求类型列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<RequirementTypeDto>> GetListWithPageAsync(int pageNum, int pageSize);


        /// <summary>
        /// 获取有效的需求类型名称列表
        /// </summary>
        /// <returns></returns>
        Task<List<RequirementTypeDto>> GetNameListAsync();


        Task AddAsync(AddRequirementTypeDto addDto);


        Task<RequirementTypeDto> GetByIdAsync(int id);

        Task UpdateAsync(UpdateRequirementTypeDto updateDto);

        Task DeleteAsync(int id);

    }
}
