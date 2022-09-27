using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.HospitalDealGoodsOperation;
using Fx.Amiya.Background.Api.Vo.HospitalDoctorOperation;
using Fx.Amiya.Background.Api.Vo.HospitalImprovePlan;
using Fx.Amiya.Background.Api.Vo.HospitalNetWorkConsulationOperationData;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 机构运营提升计划板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HospitalImprovePlanController : ControllerBase
    {
        //private IHospitalNetWorkConsulationOperationDataService hospitalOperationDataService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalOperationDataService"></param>
        public HospitalImprovePlanController(
            // IHospitalNetWorkConsulationOperationDataService hospitalOperationDataService
            )
        {
            //this.hospitalOperationDataService = hospitalOperationDataService;
        }
        /// <summary>
        /// 添加机构运营提升计划
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [FxTenantAuthorize]
        [HttpPost]
        public async Task<ResultData> AddAsync(AddHospitalImprovePlanVo addVo)
        {
            try
            {
                //AddExpressDto addDto = new AddExpressDto();
                //addDto.ExpressCode = addVo.ExpressCode;
                //addDto.ExpressName = addVo.ExpressName;
                //addDto.Valid = addVo.Valid;

                //await hospitalOperationDataService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据指标id和医院id获取提升计划
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        [HttpGet]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<HospitalImprovePlanVo>> GetByIdAsync(string indicatorId,int hospitalId)
        {
            try
            {
                //var hospitalOperationData = await hospitalOperationDataService.GetByIdAsync(id);
                HospitalImprovePlanVo hospitalOperationDataVo = new HospitalImprovePlanVo();
                //hospitalOperationDataVo.Id = hospitalOperationData.Id;
                //hospitalOperationDataVo.ExpressCode = hospitalOperationData.ExpressCode;
                //hospitalOperationDataVo.ExpressName = hospitalOperationData.ExpressName;
                //hospitalOperationDataVo.Valid = hospitalOperationData.Valid;

                return ResultData<HospitalImprovePlanVo>.Success().AddData("hospitalImprovePlanInfo", hospitalOperationDataVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalImprovePlanVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改机构提升计划信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateAsync(UpdateHospitalImprovePlanVo updateVo)
        {
            try { 
            
                //UpdateExpressDto updateDto = new UpdateExpressDto();
                //updateDto.Id = updateVo.Id;
                //updateDto.ExpressName = updateVo.ExpressName;
                //updateDto.ExpressCode = updateVo.ExpressCode;
                //updateDto.Valid = updateVo.Valid;
                //await hospitalOperationDataService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除机构提升计划
        /// </summary>
        /// <param name="id">提升计划id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                //await hospitalOperationDataService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
