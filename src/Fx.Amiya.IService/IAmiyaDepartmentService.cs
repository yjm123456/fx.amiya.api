using Fx.Amiya.Dto.AmiyaDepartment;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAmiyaDepartmentService
    {
        /// <summary>
        /// 获取所有部门列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<AmiyaDepartmentDto>> GetListWithPageAsync(int pageNum, int pageSize);

        /// <summary>
        /// 获取有效的部门名称列表
        /// </summary>
        /// <returns></returns>
        Task<List<AmiyaDepartmentDto>> GetNameListAsync();


        /// <summary>
        /// 获取有效的需求部门列表
        /// </summary>
        /// <returns></returns>
         Task<List<AmiyaDepartmentDto>> GetNameListOfRequirementAsync();

        Task AddAsync(AddAmiyaDepartmentDto addDto);


        Task<AmiyaDepartmentDto> GetByIdAsync(int id);

        Task UpdateAsync(UpdateAmiyaDepartmentDto updateDto);

        Task DeleteAsync(int id);
    }
}
