using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.HospitalNetWorkConsulationOperationData;
using Fx.Amiya.Dto.HospitalNetWorkConsulationOperationData;
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
    /// 机构网咨运营数据分析板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HospitalNetWorkConsulationOperationDataController : ControllerBase
    {
        private IHospitalNetWorkConsulationOperationDataService hospitalOperationDataService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalOperationDataService"></param>
        public HospitalNetWorkConsulationOperationDataController(
             IHospitalNetWorkConsulationOperationDataService hospitalOperationDataService
            )
        {
            this.hospitalOperationDataService = hospitalOperationDataService;
        }


        /// <summary>
        /// 获取机构网咨运营数据分析信息列表
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="indicatorsId">归属指标id</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<HospitalNetWorkConsulationOperationDataVo>>> GetListAsync(string keyword, string indicatorsId, int hospitalId)
        {
            try
            {
                var q = await hospitalOperationDataService.GetListAsync(keyword, indicatorsId);

                var hospitalOperationData = from d in q
                                            select new HospitalNetWorkConsulationOperationDataVo
                                            {
                                                Id = d.Id,
                                                HospitalId = d.HospitalId,
                                                ConsulationName = d.ConsulationName,
                                                SendOrderNum = d.SendOrderNum,
                                                NewCustomerVisitNum = d.NewCustomerVisitNum,
                                                NewCustomerVisitRate = d.NewCustomerVisitRate,
                                            };

                List<HospitalNetWorkConsulationOperationDataVo> hospitalOperationDataResult = new List<HospitalNetWorkConsulationOperationDataVo>();
                hospitalOperationDataResult = hospitalOperationData.ToList();
                return ResultData<List<HospitalNetWorkConsulationOperationDataVo>>.Success().AddData("hospitalOperationDataInfo", hospitalOperationDataResult);
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalNetWorkConsulationOperationDataVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 添加机构网咨运营数据分析信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [FxTenantAuthorize]
        [HttpPost]
        public async Task<ResultData> AddAsync(AddHospitalNetWorkConsulationOperationDataVo addVo)
        {
            try
            {
                AddHospitalNetWorkConsulationOperationDataDto addDto = new AddHospitalNetWorkConsulationOperationDataDto();
                addDto.HospitalId = addVo.HospitalId;
                addDto.IndicatorId = addVo.IndicatorId;
                addDto.ConsulationName = addVo.ConsulationName;
                addDto.SendOrderNum = addVo.SendOrderNum;
                addDto.NewCustomerVisitNum = addVo.NewCustomerVisitNum;
                addDto.NewCustomerVisitRate = addVo.NewCustomerVisitRate;

                await hospitalOperationDataService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据机构网咨运营数据分析编号获取机构网咨运营数据分析信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData<HospitalNetWorkConsulationOperationDataVo>> GetByIdAsync(string id)
        {
            try
            {
                var hospitalNetWorkConsulationOperationData = await hospitalOperationDataService.GetByIdAsync(id);
                HospitalNetWorkConsulationOperationDataVo hospitalOperationDataVo = new HospitalNetWorkConsulationOperationDataVo();
                hospitalOperationDataVo.Id = hospitalNetWorkConsulationOperationData.Id;
                hospitalOperationDataVo.CreateDate = hospitalNetWorkConsulationOperationData.CreateDate;
                hospitalOperationDataVo.UpdateDate = hospitalNetWorkConsulationOperationData.UpdateDate;
                hospitalOperationDataVo.DeleteDate = hospitalNetWorkConsulationOperationData.DeleteDate;
                hospitalOperationDataVo.Valid = hospitalNetWorkConsulationOperationData.Valid;
                hospitalOperationDataVo.HospitalId = hospitalNetWorkConsulationOperationData.HospitalId;
                hospitalOperationDataVo.IndicatorId = hospitalNetWorkConsulationOperationData.IndicatorsId;
                hospitalOperationDataVo.ConsulationName = hospitalNetWorkConsulationOperationData.ConsulationName;
                hospitalOperationDataVo.SendOrderNum = hospitalNetWorkConsulationOperationData.SendOrderNum;
                hospitalOperationDataVo.NewCustomerVisitNum = hospitalNetWorkConsulationOperationData.NewCustomerVisitNum;
                hospitalOperationDataVo.NewCustomerVisitRate = hospitalNetWorkConsulationOperationData.NewCustomerVisitRate;

                return ResultData<HospitalNetWorkConsulationOperationDataVo>.Success().AddData("hospitalOperationDataInfo", hospitalOperationDataVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalNetWorkConsulationOperationDataVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改机构网咨运营数据分析信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxTenantAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateHospitalNetWorkConsulationOperationDataVo updateVo)
        {
            try
            {
                UpdateHospitalNetWorkConsulationOperationDataDto updateDto = new UpdateHospitalNetWorkConsulationOperationDataDto();

                updateDto.Id = updateVo.Id;
                updateDto.HospitalId = updateVo.HospitalId;
                updateDto.IndicatorsId = updateVo.IndicatorId;
                updateDto.ConsulationName = updateVo.ConsulationName;
                updateDto.SendOrderNum = updateVo.SendOrderNum;
                updateDto.NewCustomerVisitNum = updateVo.NewCustomerVisitNum;
                updateDto.NewCustomerVisitRate = updateVo.NewCustomerVisitRate;
                await hospitalOperationDataService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除机构网咨运营数据分析信息
        /// </summary>
        /// <param name="id"></param>
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
