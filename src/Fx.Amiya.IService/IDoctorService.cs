using Fx.Amiya.Dto.Doctor;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IDoctorService
    {
        /// <summary>
        /// 获取医生列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<DoctorDto>> GetListWithPageAsync(int? hospitalId, string keyword,int? isLeaveOffice,int? isMain, int pageNum, int pageSize);

        /// <summary>
        /// 根据医院和科室获取医生
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        Task<List<DoctorDto>> GetListByHospitalIdAndDepartmentIdAsync(int hospitalId, string departmentId);
        /// <summary>
        /// 添加医生
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddDoctorDto addDto);



        /// <summary>
        /// 根据医生编号获取医生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DoctorDto> GetByIdAsync(int id);

        /// <summary>
        /// 修改医生信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateDoctorDto updateDto);
        /// <summary>
        /// 更新医生在职状态
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateStatusAsync(UpdateDoctorSatusDto updateDto);

        /// <summary>
        /// 删除医生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
