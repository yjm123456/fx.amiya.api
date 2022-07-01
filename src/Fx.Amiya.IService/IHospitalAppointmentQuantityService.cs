using Fx.Amiya.Dto.HospitalAppointmentQuantity;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHospitalAppointmentQuantityService
    {
        /// <summary>
        /// 获取医院可预约人数列表
        /// </summary>
        /// <param name="hospitalName"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<HospitalAppointmentQuantityDto>> GetListWithPage(string hospitalName, int pageNum, int pageSize);




        /// <summary>
        /// 添加医院可预约人数
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddHospitalAppointmentQuantityDto addDto);


        /// <summary>
        /// 根据编号获取医院可预约人数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HospitalAppointmentQuantityDto> GetByIdAsync(int id);


        /// <summary>
        /// 修改医院可预约人数
        /// </summary>
        /// <param name="updateDto"></param>
        Task UpdateAsync(UpdateHospitalAppointmentQuantityDto updateDto);



        /// <summary>
        /// 删除医院可预约人数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);



    }
}
