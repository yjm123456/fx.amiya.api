using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.HospitalDealGoodsOperation;
using Fx.Amiya.Background.Api.Vo.HospitalDoctorOperation;
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
    /// 机构成交品项分析板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HospitalDealItemOperationController : ControllerBase
    {
        //private IHospitalNetWorkConsulationOperationDataService hospitalOperationDataService;
        private IHospitalDealItemService hospitalDealItemService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalOperationDataService"></param>
        public HospitalDealItemOperationController(IHospitalDealItemService hospitalDealItemService )
        {
            this.hospitalDealItemService = hospitalDealItemService;
        }


        /// <summary>
        /// 获取机构成交品项分析信息列表
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="indicatorsId">归属指标id</param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<HospitalDealItemOperationVo>>> GetListAsync(string keyword, string indicatorsId)
        {
            try
            {
                var list = await hospitalDealItemService.GetListAsync(keyword,indicatorsId);

                List<HospitalDealItemOperationVo> hospitalOperationDataPageInfo = list.Select(e=> new HospitalDealItemOperationVo
                {
                    Id = e.Id,
                    HospitalId = e.HospitalId,
                    IndicatorId = e.IndicatorId,
                    DealItemName = e.DealItemName,
                    DealCount = e.DealCount,
                    DealPrice = e.DealPrice,
                    PerformanceRatio = e.PerformanceRatio,
                }).ToList();
                
                

                return ResultData<List<HospitalDealItemOperationVo>>.Success().AddData("hospitalDealItemData", hospitalOperationDataPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalDealItemOperationVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 添加机构成交品项分析信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [FxTenantAuthorize]
        [HttpPost]
        public async Task<ResultData> AddAsync(AddHospitalDealItemOperationVo addVo)
        {
            try
            {
                AddHospitalDealItemOperationDto addDto = new AddHospitalDealItemOperationDto
                {
                    HospitalId = addVo.HospitalId,
                    IndicatorId = addVo.IndicatorId,
                    DealItemName = addVo.DealItemName,
                    DealCount = addVo.DealCount,
                    DealPrice = addVo.DealPrice,
                    PerformanceRatio = addVo.PerformanceRatio,
                };
                await hospitalDealItemService.AddAsync(addDto);


                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据机构成交品项分析编号获取机构成交品项分析信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData<HospitalDealItemOperationVo>> GetByIdAsync(string id)
        {
            try
            {
                
                HospitalDealItemOperationVo hospitalOperationDataVo = new HospitalDealItemOperationVo();
                var item=await hospitalDealItemService.GetByIdAsync(id);
                hospitalOperationDataVo.Id = item.Id;
                hospitalOperationDataVo.HospitalId = item.HospitalId;
                hospitalOperationDataVo.IndicatorId = item.IndicatorId;
                hospitalOperationDataVo.DealItemName = item.DealItemName;
                hospitalOperationDataVo.DealCount = item.DealCount;
                hospitalOperationDataVo.DealPrice = item.DealPrice;
                hospitalOperationDataVo.PerformanceRatio = item.PerformanceRatio;
                return ResultData<HospitalDealItemOperationVo>.Success().AddData("hospitalDealItemOperationInfo", hospitalOperationDataVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalDealItemOperationVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改机构成交品项分析信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxTenantAuthorize]
        public async Task<ResultData> UpdateAsync(HospitalDealItemOperationVo updateVo)
        {
            try {
                UpdateHospitalDealItemOperationDto updateDto = new UpdateHospitalDealItemOperationDto();
                updateDto.Id = updateDto.Id;
                updateDto.HospitalId = updateDto.HospitalId;
                updateDto.IndicatorId = updateDto.IndicatorId;
                updateDto.DealItemName = updateDto.DealItemName;
                updateDto.DealCount = updateDto.DealCount;
                updateDto.DealPrice = updateDto.DealPrice;
                updateDto.PerformanceRatio = updateDto.PerformanceRatio;
               await hospitalDealItemService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除机构成交品项分析信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await hospitalDealItemService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
