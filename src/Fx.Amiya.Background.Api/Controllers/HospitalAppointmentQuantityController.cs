using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.HospitalAppointmentQuantity;
using Fx.Amiya.Dto.HospitalAppointmentQuantity;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 医院预约人数API
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class HospitalAppointmentQuantityController : ControllerBase
    {

        private IHospitalAppointmentQuantityService service;

        public HospitalAppointmentQuantityController(IHospitalAppointmentQuantityService service)
        {
            this.service = service;
        }

        /// <summary>
        /// 获取医院可预约人数列表（分页）
        /// </summary>
        /// <param name="hospitalName">医院名称，可空</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<HospitalAppointmentQuantityVo>>> GetListWithPageAsync(string hospitalName, int pageNum, int pageSize)
        {
            try
            {
                var q = await service.GetListWithPage(hospitalName, pageNum, pageSize);

                var appointmentQuantity = from d in q.List
                                          select new HospitalAppointmentQuantityVo
                                          {
                                              Id = d.Id,
                                              HospitalId = d.HospitalId,
                                              HospitalName = d.HospitalName,
                                              ForenoonCanAppointmentNumer = d.ForenoonCanAppointmentNumer,
                                              AfternoonCanAppointmentNumer = d.AfternoonCanAppointmentNumer
                                          };

                FxPageInfo<HospitalAppointmentQuantityVo> quantityPageInfo = new FxPageInfo<HospitalAppointmentQuantityVo>();
                quantityPageInfo.TotalCount = q.TotalCount;
                quantityPageInfo.List = appointmentQuantity;

                return ResultData<FxPageInfo<HospitalAppointmentQuantityVo>>.Success().AddData("appointmentQuantityInfo", quantityPageInfo);

            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<HospitalAppointmentQuantityVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 添加医院可预约人数
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddHospitalAppointmentQuantityVo addVo)
        {
            try
            {
                AddHospitalAppointmentQuantityDto addDto = new AddHospitalAppointmentQuantityDto();
                addDto.HospitalId = addVo.HospitalId;
                addDto.ForenoonCanAppointmentNumer = addVo.ForenoonCanAppointmentNumer;
                addDto.AfternoonCanAppointmentNumer = addVo.AfternoonCanAppointmentNumer;

                await service.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据编号获取医院可预约人数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<HospitalAppointmentQuantityVo>> GetByIdAsync(int id)
        {
            try
            {
                var appointmentQuantityInfo = await service.GetByIdAsync(id);

                HospitalAppointmentQuantityVo appointmentQuantity = new HospitalAppointmentQuantityVo();
                appointmentQuantity.Id = appointmentQuantityInfo.Id;
                appointmentQuantity.HospitalId = appointmentQuantityInfo.HospitalId;
                appointmentQuantity.HospitalName = appointmentQuantityInfo.HospitalName;
                appointmentQuantity.ForenoonCanAppointmentNumer = appointmentQuantityInfo.ForenoonCanAppointmentNumer;
                appointmentQuantity.AfternoonCanAppointmentNumer = appointmentQuantityInfo.AfternoonCanAppointmentNumer;

                return ResultData<HospitalAppointmentQuantityVo>.Success().AddData("appointmentQuantityInfo", appointmentQuantity);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalAppointmentQuantityVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改医院可预约人数
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateHospitalAppointmentQuantityVo updateVo)
        {
            try
            {
                UpdateHospitalAppointmentQuantityDto updateDto = new UpdateHospitalAppointmentQuantityDto();
                updateDto.Id = updateVo.Id;
                updateDto.ForenoonCanAppointmentNumer = updateVo.ForenoonCanAppointmentNumer;
                updateDto.AfternoonCanAppointmentNumer = updateVo.AfternoonCanAppointmentNumer;

                await service.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 删除医院可预约人数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(int id)
        {
            try
            {
                await service.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}