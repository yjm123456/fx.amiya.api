using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.HospitalOperationData;
using Fx.Amiya.Dto.HospitalOperationData;
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
    /// 机构运营数据分析板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HospitalOperationDataController : ControllerBase
    {
        private IHospitalOperationDataService hospitalOperationDataService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalOperationDataService"></param>
        public HospitalOperationDataController(IHospitalOperationDataService hospitalOperationDataService)
        {
            this.hospitalOperationDataService = hospitalOperationDataService;
        }


        /// <summary>
        /// 获取机构运营数据分析信息列表
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="indicatorsId">归属指标id</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<HospitalOperationDataVo>>> GetListAsync(string keyword, string indicatorsId, int hospitalId)
        {
            try
            {
                var q = await hospitalOperationDataService.GetListAsync(keyword, indicatorsId,hospitalId);

                var hospitalOperationData = from d in q
                                            select new HospitalOperationDataVo
                                            {
                                                Id = d.Id,
                                                HospitalId = d.HospitalId,
                                                IndicatorsId = d.IndicatorsId,
                                                OperationName = d.OperationName,
                                                LastMonthData = d.LastMonthData,
                                                BeforeMonthData = d.BeforeMonthData,
                                                ChainRatio = d.ChainRatio,
                                                GreatHospital = d.GreatHospital,
                                            };

                List<HospitalOperationDataVo> hospitalOperationDataPageInfo = new List<HospitalOperationDataVo>();
                hospitalOperationDataPageInfo = hospitalOperationData.ToList();

                return ResultData<List<HospitalOperationDataVo>>.Success().AddData("hospitalOperationDataInfo", hospitalOperationDataPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalOperationDataVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 添加机构运营数据分析信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [FxTenantAuthorize]
        [HttpPost]
        public async Task<ResultData> AddAsync(List<AddHospitalOperationDataVo> addVo)
        {
            try
            {
                List<AddHospitalOperationDataDto> AddHospitalOperationDataDtoList = new List<AddHospitalOperationDataDto>();
                foreach (var x in addVo)
                {

                    AddHospitalOperationDataDto addDto = new AddHospitalOperationDataDto();
                    addDto.HospitalId = x.HospitalId;
                    addDto.IndicatorsId = x.IndicatorsId;
                    addDto.OperationName = x.OperationName;
                    addDto.LastMonthData = x.LastMonthData;
                    addDto.BeforeMonthData = x.BeforeMonthData;
                    addDto.ChainRatio = x.ChainRatio;
                    AddHospitalOperationDataDtoList.Add(addDto);
                }

                await hospitalOperationDataService.AddAsync(AddHospitalOperationDataDtoList);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据机构运营数据分析编号获取机构运营数据分析信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData<HospitalOperationDataVo>> GetByIdAsync(string id)
        {
            try
            {
                var hospitalOperationData = await hospitalOperationDataService.GetByIdAsync(id);
                HospitalOperationDataVo hospitalOperationDataVo = new HospitalOperationDataVo();
                hospitalOperationDataVo.Id = hospitalOperationData.Id;
                hospitalOperationDataVo.CreateDate = hospitalOperationData.CreateDate;
                hospitalOperationDataVo.UpdateDate = hospitalOperationData.UpdateDate;
                hospitalOperationDataVo.DeleteDate = hospitalOperationData.DeleteDate;
                hospitalOperationDataVo.Valid = hospitalOperationData.Valid;
                hospitalOperationDataVo.HospitalId = hospitalOperationData.HospitalId;
                hospitalOperationDataVo.IndicatorsId = hospitalOperationData.IndicatorsId;
                hospitalOperationDataVo.OperationName = hospitalOperationData.OperationName;
                hospitalOperationDataVo.LastMonthData = hospitalOperationData.LastMonthData;
                hospitalOperationDataVo.BeforeMonthData = hospitalOperationData.BeforeMonthData;
                hospitalOperationDataVo.ChainRatio = hospitalOperationData.ChainRatio;
                hospitalOperationDataVo.GreatHospital = hospitalOperationData.GreatHospital;

                return ResultData<HospitalOperationDataVo>.Success().AddData("hospitalOperationDataInfo", hospitalOperationDataVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalOperationDataVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改机构运营数据分析信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxTenantAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateHospitalOperationDataVo updateVo)
        {
            try
            {
                UpdateHospitalOperationDataDto updateDto = new UpdateHospitalOperationDataDto();
                updateDto.Id = updateVo.Id;
                updateDto.HospitalId = updateVo.HospitalId;
                updateDto.IndicatorsId = updateVo.IndicatorsId;
                updateDto.OperationName = updateVo.OperationName;
                updateDto.LastMonthData = updateVo.LastMonthData;
                updateDto.BeforeMonthData = updateVo.BeforeMonthData;
                updateDto.ChainRatio = updateVo.ChainRatio;
                await hospitalOperationDataService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除机构运营数据分析信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await hospitalOperationDataService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
