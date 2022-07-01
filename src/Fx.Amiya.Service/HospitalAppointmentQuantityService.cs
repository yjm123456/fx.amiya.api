using Fx.Amiya.Dto.HospitalAppointmentQuantity;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fx.Amiya.DbModels.Model;
using Fx.Common;

namespace Fx.Amiya.Service
{
    public class HospitalAppointmentQuantityService : IHospitalAppointmentQuantityService
    {
        private IDalHospitalAppointmentNumer dalHospitalAppointmentNumer;

        public HospitalAppointmentQuantityService(IDalHospitalAppointmentNumer dalHospitalAppointmentNumer)
        {
            this.dalHospitalAppointmentNumer = dalHospitalAppointmentNumer;
        }



        /// <summary>
        /// 获取医院可预约人数列表
        /// </summary>
        /// <param name="hospitalName"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<HospitalAppointmentQuantityDto>> GetListWithPage(string hospitalName, int pageNum, int pageSize)
        {
            try
            {
                var q = from d in dalHospitalAppointmentNumer.GetAll()
                        where d.HospitalInfo.Valid
                        && (hospitalName == null || d.HospitalInfo.Name.Contains(hospitalName))
                        select new HospitalAppointmentQuantityDto
                        {
                            Id = d.Id,
                            HospitalId = d.HospitalId,
                            HospitalName = d.HospitalInfo.Name,
                            ForenoonCanAppointmentNumer = d.ForenoonCanAppointmentNumer,
                            AfternoonCanAppointmentNumer = d.AfternoonCanAppointmentNumer
                        };

                FxPageInfo<HospitalAppointmentQuantityDto> quantityPageInfo = new FxPageInfo<HospitalAppointmentQuantityDto>();
                quantityPageInfo.TotalCount = await q.CountAsync();
                quantityPageInfo.List = await q.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

                return quantityPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(AddHospitalAppointmentQuantityDto addDto)
        {
            try
            {
                var appointmentQuantityCount = await dalHospitalAppointmentNumer.GetAll()
                   .CountAsync(e => e.HospitalId == addDto.HospitalId);

                if (appointmentQuantityCount > 0)
                    throw new Exception("该医院已添加过可预约人数");

                HospitalAppointmentNumer appointmentQuantity = new HospitalAppointmentNumer();
                appointmentQuantity.HospitalId = addDto.HospitalId;
                appointmentQuantity.ForenoonCanAppointmentNumer = addDto.ForenoonCanAppointmentNumer;
                appointmentQuantity.AfternoonCanAppointmentNumer = addDto.AfternoonCanAppointmentNumer;

                await dalHospitalAppointmentNumer.AddAsync(appointmentQuantity, true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 根据编号获取医院可预约人数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HospitalAppointmentQuantityDto> GetByIdAsync(int id)
        {
            try
            {
                var appointmentQuantityInfo = await dalHospitalAppointmentNumer.GetAll()
                    .Include(e => e.HospitalInfo)
                    .SingleOrDefaultAsync(e => e.Id == id);

                if (appointmentQuantityInfo == null)
                    throw new Exception("编号错误");

                HospitalAppointmentQuantityDto appointmentQuantity = new HospitalAppointmentQuantityDto();
                appointmentQuantity.Id = appointmentQuantityInfo.Id;
                appointmentQuantity.HospitalId = appointmentQuantityInfo.HospitalId;
                appointmentQuantity.HospitalName = appointmentQuantityInfo.HospitalInfo.Name;
                appointmentQuantity.ForenoonCanAppointmentNumer = appointmentQuantityInfo.ForenoonCanAppointmentNumer;
                appointmentQuantity.AfternoonCanAppointmentNumer = appointmentQuantityInfo.AfternoonCanAppointmentNumer;

                return appointmentQuantity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        /// <summary>
        /// 修改医院可预约人数
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateHospitalAppointmentQuantityDto updateDto)
        {
            try
            {
                var appointmentQuantityInfo = await dalHospitalAppointmentNumer.GetAll()
                   .SingleOrDefaultAsync(e => e.Id == updateDto.Id);

                if (appointmentQuantityInfo == null)
                    throw new Exception("编号错误");

                appointmentQuantityInfo.ForenoonCanAppointmentNumer = updateDto.ForenoonCanAppointmentNumer;
                appointmentQuantityInfo.AfternoonCanAppointmentNumer = updateDto.AfternoonCanAppointmentNumer;

                await dalHospitalAppointmentNumer.UpdateAsync(appointmentQuantityInfo, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task DeleteAsync(int id)
        {
            try
            {
                var appointmentQuantityInfo = await dalHospitalAppointmentNumer.GetAll()
                   .SingleOrDefaultAsync(e => e.Id == id);

                if (appointmentQuantityInfo == null)
                    throw new Exception("编号错误");

                await dalHospitalAppointmentNumer.DeleteAsync(appointmentQuantityInfo,true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
