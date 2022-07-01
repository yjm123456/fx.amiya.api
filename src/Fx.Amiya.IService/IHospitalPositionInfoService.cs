using Fx.Amiya.Dto.HospitalPosition;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHospitalPositionInfoService
    {
        /// <summary>
        /// 获取医院职位列表
        /// </summary>
        /// <returns></returns>
        Task<List<HospitalPositionInfoDto>> GetListAsync();



        /// <summary>
        /// 添加医院职位
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddHospitalPositionInfoDto addDto);



        /// <summary>
        /// 根据职位编号获取医院职位信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HospitalPositionInfoDto> GetByIdAsync(int id);




        /// <summary>
        /// 修改医院职位
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateHospitalPositionInfoDto updateDto, int employeeId);



        /// <summary>
        /// 删除医院职位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
