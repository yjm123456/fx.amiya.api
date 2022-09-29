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
        private IHospitalImprovePlanRemarkService hospitalImprovePlanRemarkService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalOperationDataService"></param>
        public HospitalImprovePlanController(IHospitalImprovePlanRemarkService hospitalImprovePlanRemarkService )
        {
            this.hospitalImprovePlanRemarkService = hospitalImprovePlanRemarkService;
        }
        /// <summary>
        /// 添加机构运营提升计划
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [FxInternalOrTenantAuthroize]
        [HttpPost]
        public async Task<ResultData> AddAsync(AddHospitalImprovePlanVo addVo)
        {
            try
            {

                AddHospitalImprovePlanDto addDto = new AddHospitalImprovePlanDto() {
                    IndicatorId = addVo.IndicatorId,
                    HospitalId = addVo.HospitalId,
                    HospitalImprovePlan = addVo.HospitalImprovePlan,
                    AmiyaImprovePlanRemark = addVo.AmiyaImprovePlanRemark,
                    HospitalShareSuccessCase = addVo.HospitalShareSuccessCase,
                    AmiyaShareSuccessCase = addVo.AmiyaShareSuccessCase,
                    ImproveSuggestionToAmiya = addVo.ImproveSuggestionToAmiya,
                    AmiyaImproveSuggestionRemark = addVo.AmiyaImproveSuggestionRemark,
                    ImproveDemandToAmiya = addVo.ImproveDemandToAmiya,
                    AmiyaImproveDemandRemark = addVo.AmiyaImproveDemandRemark
                };
                await hospitalImprovePlanRemarkService.AddHospitalImprovePlan(addDto);
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
                var plan =await hospitalImprovePlanRemarkService.GetHospitalImprovePlan(indicatorId,hospitalId);

                HospitalImprovePlanVo hospitalOperationDataVo = new HospitalImprovePlanVo() {
                    Id = plan.Id,
                    IndicatorId = plan.IndicatorId,
                    HospitalId = plan.HospitalId,
                    HospitalImprovePlan = plan.HospitalImprovePlan,
                    AmiyaImprovePlanRemark = plan.AmiyaImprovePlanRemark,
                    HospitalShareSuccessCase = plan.HospitalShareSuccessCase,
                    AmiyaShareSuccessCase = plan.AmiyaShareSuccessCase,
                    ImproveSuggestionToAmiya = plan.ImproveSuggestionToAmiya,
                    AmiyaImproveSuggestionRemark = plan.AmiyaImproveSuggestionRemark,
                    ImproveDemandToAmiya = plan.ImproveDemandToAmiya,
                    AmiyaImproveDemandRemark = plan.AmiyaImproveDemandRemark,
                };
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

                UpdateHospitalImprovePlanDto updateDto = new UpdateHospitalImprovePlanDto()
                {
                    Id = updateVo.Id,
                    IndicatorId = updateVo.IndicatorId,
                    HospitalId = updateVo.HospitalId,
                    HospitalImprovePlan = updateVo.HospitalImprovePlan,
                    AmiyaImprovePlanRemark = updateVo.AmiyaImprovePlanRemark,
                    HospitalShareSuccessCase = updateVo.HospitalShareSuccessCase,
                    AmiyaShareSuccessCase = updateVo.AmiyaShareSuccessCase,
                    ImproveSuggestionToAmiya = updateVo.ImproveSuggestionToAmiya,
                    AmiyaImproveSuggestionRemark = updateVo.AmiyaImproveSuggestionRemark,
                    ImproveDemandToAmiya = updateVo.ImproveDemandToAmiya,
                    AmiyaImproveDemandRemark = updateVo.AmiyaImproveDemandRemark,
                };
                await hospitalImprovePlanRemarkService.UpdateHospitalImprovePlan(updateDto);
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
