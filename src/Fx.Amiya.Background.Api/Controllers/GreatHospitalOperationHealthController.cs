using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.GreatHospitalOperationHealth;
using Fx.Amiya.Dto.GreatHospitalOperationHealth;
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
    /// 优秀机构运营健康指标板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class GreatHospitalOperationHealthController : ControllerBase
    {
        private IGreatHospitalOperationHealthService greatHospitalOperationHealthService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="greatHospitalOperationHealthService"></param>
        public GreatHospitalOperationHealthController(
            IGreatHospitalOperationHealthService greatHospitalOperationHealthService
            )
        {
            this.greatHospitalOperationHealthService = greatHospitalOperationHealthService;
        }


        /// <summary>
        /// 获取优秀机构运营健康指标信息列表
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="indicatorsId">归属指标id</param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<GreatHospitalOperationHealthVo>>> GetListAsync(string keyword, string indicatorsId)
        {
            try
            {
                var q = await greatHospitalOperationHealthService.GetListAsync(keyword, indicatorsId);

                var greatHospitalOperationHealth = from d in q
                                                   select new GreatHospitalOperationHealthVo
                                                   {
                                                       Id = d.Id,
                                                       HospitalId = d.HospitalId,
                                                       HospitalName = d.HospitalName,
                                                       IndicatorsId = d.IndicatorId,
                                                       IndicatorsName = d.IndicatorsName,
                                                       LastNewCustomerVisitRate = d.LastNewCustomerVisitRate,
                                                       ThisNewCustomerVisitRate = d.ThisNewCustomerVisitRate,
                                                       NewCustomerVisitChainRatio = d.NewCustomerVisitChainRatio,
                                                       LastNewCustomerDealRate = d.LastNewCustomerDealRate,
                                                       ThisNewCustomerDealRate = d.ThisNewCustomerDealRate,
                                                       NewCustomerDealChainRatio = d.NewCustomerDealChainRatio,
                                                       LastNewCustomerUnitPrice = d.LastNewCustomerUnitPrice,
                                                       ThisNewCustomerUnitPrice = d.ThisNewCustomerUnitPrice,
                                                       NewCustomerUnitPriceChainRatio = d.NewCustomerUnitPriceChainRatio,
                                                   };

                List<GreatHospitalOperationHealthVo> greatHospitalOperationHealthResult = new List<GreatHospitalOperationHealthVo>();
                greatHospitalOperationHealthResult = greatHospitalOperationHealth.ToList();
                return ResultData<List<GreatHospitalOperationHealthVo>>.Success().AddData("greatHospitalOperationHealthInfo", greatHospitalOperationHealthResult);
            }
            catch (Exception ex)
            {
                return ResultData<List<GreatHospitalOperationHealthVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 添加优秀机构运营健康指标信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [FxInternalAuthorize]
        [HttpPost]
        public async Task<ResultData> AddAsync(AddGreatHospitalOperationHealthVo addVo)
        {
            try
            {
                AddGreatHospitalOperationHealthDto addDto = new AddGreatHospitalOperationHealthDto();
                addDto.HospitalId = addVo.HospitalId;
                addDto.IndicatorsId = addVo.IndicatorsId;
                addDto.LastNewCustomerVisitRate = addVo.LastNewCustomerVisitRate;
                addDto.ThisNewCustomerVisitRate = addVo.ThisNewCustomerVisitRate;
                addDto.NewCustomerVisitChainRatio = addVo.NewCustomerVisitChainRatio;
                addDto.LastNewCustomerDealRate = addVo.LastNewCustomerDealRate;
                addDto.ThisNewCustomerDealRate = addVo.ThisNewCustomerDealRate;
                addDto.NewCustomerDealChainRatio = addVo.NewCustomerDealChainRatio;
                addDto.LastNewCustomerUnitPrice = addVo.LastNewCustomerUnitPrice;
                addDto.ThisNewCustomerUnitPrice = addVo.ThisNewCustomerUnitPrice;
                addDto.NewCustomerUnitPriceChainRatio = addVo.NewCustomerUnitPriceChainRatio;

                await greatHospitalOperationHealthService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据优秀机构运营健康指标编号获取优秀机构运营健康指标信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<GreatHospitalOperationHealthVo>> GetByIdAsync(string id)
        {
            try
            {
                var greatHospitalOperationHealth = await greatHospitalOperationHealthService.GetByIdAsync(id);
                GreatHospitalOperationHealthVo greatHospitalOperationHealthVo = new GreatHospitalOperationHealthVo();
                greatHospitalOperationHealthVo.Id = greatHospitalOperationHealth.Id;
                greatHospitalOperationHealthVo.CreateDate = greatHospitalOperationHealth.CreateDate;
                greatHospitalOperationHealthVo.UpdateDate = greatHospitalOperationHealth.UpdateDate;
                greatHospitalOperationHealthVo.DeleteDate = greatHospitalOperationHealth.DeleteDate;
                greatHospitalOperationHealthVo.Valid = greatHospitalOperationHealth.Valid;
                greatHospitalOperationHealthVo.HospitalId = greatHospitalOperationHealth.HospitalId;
                greatHospitalOperationHealthVo.IndicatorsId = greatHospitalOperationHealth.IndicatorId;
                greatHospitalOperationHealthVo.LastNewCustomerVisitRate = greatHospitalOperationHealth.LastNewCustomerVisitRate;
                greatHospitalOperationHealthVo.ThisNewCustomerVisitRate = greatHospitalOperationHealth.ThisNewCustomerVisitRate;
                greatHospitalOperationHealthVo.NewCustomerVisitChainRatio = greatHospitalOperationHealth.NewCustomerVisitChainRatio;
                greatHospitalOperationHealthVo.LastNewCustomerDealRate = greatHospitalOperationHealth.LastNewCustomerDealRate;
                greatHospitalOperationHealthVo.ThisNewCustomerDealRate = greatHospitalOperationHealth.ThisNewCustomerDealRate;
                greatHospitalOperationHealthVo.NewCustomerDealChainRatio = greatHospitalOperationHealth.NewCustomerDealChainRatio;
                greatHospitalOperationHealthVo.LastNewCustomerUnitPrice = greatHospitalOperationHealth.LastNewCustomerUnitPrice;
                greatHospitalOperationHealthVo.ThisNewCustomerUnitPrice = greatHospitalOperationHealth.ThisNewCustomerUnitPrice;
                greatHospitalOperationHealthVo.NewCustomerUnitPriceChainRatio = greatHospitalOperationHealth.NewCustomerUnitPriceChainRatio;

                return ResultData<GreatHospitalOperationHealthVo>.Success().AddData("greatHospitalOperationHealthInfo", greatHospitalOperationHealthVo);
            }
            catch (Exception ex)
            {
                return ResultData<GreatHospitalOperationHealthVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改优秀机构运营健康指标信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateGreatHospitalOperationHealthVo updateVo)
        {
            try
            {
                UpdateGreatHospitalOperationHealthDto updateDto = new UpdateGreatHospitalOperationHealthDto();
                updateDto.Id = updateVo.Id;
                updateDto.HospitalId = updateVo.HospitalId;
                updateDto.IndicatorsId = updateVo.IndicatorsId;
                updateDto.LastNewCustomerVisitRate = updateVo.LastNewCustomerVisitRate;
                updateDto.ThisNewCustomerVisitRate = updateVo.ThisNewCustomerVisitRate;
                updateDto.NewCustomerVisitChainRatio = updateVo.NewCustomerVisitChainRatio;
                updateDto.LastNewCustomerDealRate = updateVo.LastNewCustomerDealRate;
                updateDto.ThisNewCustomerDealRate = updateVo.ThisNewCustomerDealRate;
                updateDto.NewCustomerDealChainRatio = updateVo.NewCustomerDealChainRatio;
                updateDto.LastNewCustomerUnitPrice = updateVo.LastNewCustomerUnitPrice;
                updateDto.ThisNewCustomerUnitPrice = updateVo.ThisNewCustomerUnitPrice;
                updateDto.NewCustomerUnitPriceChainRatio = updateVo.NewCustomerUnitPriceChainRatio;
                await greatHospitalOperationHealthService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除优秀机构运营健康指标信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await greatHospitalOperationHealthService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
