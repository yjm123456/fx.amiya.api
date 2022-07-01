using Fx.Amiya.Dto.AmiyaPositionInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAmiyaPositionInfoService
    {
        /// <summary>
        /// 获取职位列表
        /// </summary>
        /// <returns></returns>
        Task<List<AmiyaPositionInfoDto>> GetListAsync();


        /// <summary>
        /// 添加职位
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddAmiyaPositionInfoDto addDto);


        /// <summary>
        /// 根据职位编号获取职位信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AmiyaPositionInfoDto> GetByIdAsync(int id);

        /// <summary>
        /// 根据部门编号获取职位信息
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        Task<List<AmiyaPositionInfoDto>> GetByDepartmentIdAsync(int departmentId);


        /// <summary>
        /// 修改职位信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateAmiyaPositionInfoDto updateDto, int employeeId);


        /// <summary>
        /// 根据职位编号删除职位信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
