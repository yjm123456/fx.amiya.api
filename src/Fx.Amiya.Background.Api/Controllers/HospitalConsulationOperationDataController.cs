using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.HospitalConsulationOperationData;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.HospitalConsulationOperationData;
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
    /// 机构咨询师运营数据分析板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HospitalConsulationOperationDataController : ControllerBase
    {
        private IHospitalConsulationOperationDataService hospitalConsulationOperationDataService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalConsulationOperationDataService"></param>
        public HospitalConsulationOperationDataController(
            IHospitalConsulationOperationDataService hospitalConsulationOperationDataService
            )
        {
            this.hospitalConsulationOperationDataService = hospitalConsulationOperationDataService;
        }


        /// <summary>
        /// 获取机构咨询师运营数据分析信息列表
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="indicatorsId">归属指标id</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<HospitalConsulationOperationDataVo>>> GetListAsync(string keyword, string indicatorsId, int hospitalId)
        {
            try
            {
                var q = await hospitalConsulationOperationDataService.GetListAsync(keyword, indicatorsId, hospitalId);

                var hospitalOperationData = from d in q
                                            select new HospitalConsulationOperationDataVo
                                            {
                                                Id = d.Id,
                                                HospitalId = d.HospitalId,
                                                IndicatorId = d.IndicatorId,
                                                ConsulationName = d.ConsulationName,
                                                SendOrderNum = d.SendOrderNum,
                                                NewCustomerVisitNum = d.NewCustomerVisitNum,
                                                NewCustomerVisitRate = d.NewCustomerVisitRate,
                                                NewCustomerDealNum = d.NewCustomerDealNum,
                                                NewCustomerDealRate = d.NewCustomerDealRate,
                                                NewCustomerDealPrice = d.NewCustomerDealPrice,
                                                NewCustomerUnitPrice = d.NewCustomerUnitPrice,

                                                OldCustomerVisitNum = d.OldCustomerVisitNum,
                                                OldCustomerDealNum = d.OldCustomerDealNum,
                                                OldCustomerDealRate = d.OldCustomerDealRate,
                                                OldCustomerDealPrice = d.OldCustomerDealPrice,
                                                OldCustomerUnitPrice = d.OldCustomerUnitPrice,

                                                OldCustomerAchievementRate = d.OldCustomerAchievementRate,
                                                LasttMonthTotalAchievement = d.LasttMonthTotalAchievement,
                                            };

                List<HospitalConsulationOperationDataVo> hospitalOperationDataResult = new List<HospitalConsulationOperationDataVo>();
                hospitalOperationDataResult = hospitalOperationData.ToList();
                return ResultData<List<HospitalConsulationOperationDataVo>>.Success().AddData("hospitalOperationDataInfo", hospitalOperationDataResult);
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalConsulationOperationDataVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 添加机构咨询师运营数据分析信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [FxTenantAuthorize]
        [HttpPost]
        public async Task<ResultData> AddAsync(AddHospitalConsulationOperationDataVo addVo)
        {
            try
            {
                AddHospitalConsulationOperationDataDto addDto = new AddHospitalConsulationOperationDataDto();
                addDto.HospitalId = addVo.HospitalId;
                addDto.IndicatorId = addVo.IndicatorId;
                addDto.ConsulationName = addVo.ConsulationName;
                addDto.SendOrderNum = addVo.SendOrderNum;
                addDto.NewCustomerVisitNum = addVo.NewCustomerVisitNum;
                addDto.NewCustomerVisitRate = addVo.NewCustomerVisitRate;
                addDto.NewCustomerDealNum = addVo.NewCustomerDealNum;
                addDto.NewCustomerDealRate = addVo.NewCustomerDealRate;
                addDto.NewCustomerDealPrice = addVo.NewCustomerDealPrice;
                addDto.NewCustomerUnitPrice = addVo.NewCustomerUnitPrice;

                addDto.OldCustomerVisitNum = addVo.OldCustomerVisitNum;
                addDto.OldCustomerDealNum = addVo.OldCustomerDealNum;
                addDto.OldCustomerDealRate = addVo.OldCustomerDealRate;
                addDto.OldCustomerDealPrice = addVo.OldCustomerDealPrice;
                addDto.OldCustomerUnitPrice = addVo.OldCustomerUnitPrice;

                addDto.OldCustomerAchievementRate = addVo.OldCustomerAchievementRate;
                addDto.LasttMonthTotalAchievement = addVo.LasttMonthTotalAchievement;

                await hospitalConsulationOperationDataService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据机构咨询师运营数据分析编号获取机构咨询师运营数据分析信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData<HospitalConsulationOperationDataVo>> GetByIdAsync(string id)
        {
            try
            {
                var hospitalOperationData = await hospitalConsulationOperationDataService.GetByIdAsync(id);
                HospitalConsulationOperationDataVo hospitalOperationDataVo = new HospitalConsulationOperationDataVo();
                hospitalOperationDataVo.Id = hospitalOperationData.Id;
                hospitalOperationDataVo.CreateDate = hospitalOperationData.CreateDate;
                hospitalOperationDataVo.UpdateDate = hospitalOperationData.UpdateDate;
                hospitalOperationDataVo.DeleteDate = hospitalOperationData.DeleteDate;
                hospitalOperationDataVo.Valid = hospitalOperationData.Valid;
                hospitalOperationDataVo.HospitalId = hospitalOperationData.HospitalId;
                hospitalOperationDataVo.IndicatorId = hospitalOperationData.IndicatorId;
                hospitalOperationDataVo.HospitalId = hospitalOperationData.HospitalId;
                hospitalOperationDataVo.IndicatorId = hospitalOperationData.IndicatorId;
                hospitalOperationDataVo.ConsulationName = hospitalOperationData.ConsulationName;
                hospitalOperationDataVo.SendOrderNum = hospitalOperationData.SendOrderNum;
                hospitalOperationDataVo.NewCustomerVisitNum = hospitalOperationData.NewCustomerVisitNum;
                hospitalOperationDataVo.NewCustomerVisitRate = hospitalOperationData.NewCustomerVisitRate;
                hospitalOperationDataVo.NewCustomerDealNum = hospitalOperationData.NewCustomerDealNum;
                hospitalOperationDataVo.NewCustomerDealRate = hospitalOperationData.NewCustomerDealRate;
                hospitalOperationDataVo.NewCustomerDealPrice = hospitalOperationData.NewCustomerDealPrice;
                hospitalOperationDataVo.NewCustomerUnitPrice = hospitalOperationData.NewCustomerUnitPrice;

                hospitalOperationDataVo.OldCustomerVisitNum = hospitalOperationData.OldCustomerVisitNum;
                hospitalOperationDataVo.OldCustomerDealNum = hospitalOperationData.OldCustomerDealNum;
                hospitalOperationDataVo.OldCustomerDealRate = hospitalOperationData.OldCustomerDealRate;
                hospitalOperationDataVo.OldCustomerDealPrice = hospitalOperationData.OldCustomerDealPrice;
                hospitalOperationDataVo.OldCustomerUnitPrice = hospitalOperationData.OldCustomerUnitPrice;

                hospitalOperationDataVo.OldCustomerAchievementRate = hospitalOperationData.OldCustomerAchievementRate;
                hospitalOperationDataVo.LasttMonthTotalAchievement = hospitalOperationData.LasttMonthTotalAchievement;

                return ResultData<HospitalConsulationOperationDataVo>.Success().AddData("hospitalOperationDataInfo", hospitalOperationDataVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalConsulationOperationDataVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改机构咨询师运营数据分析信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxTenantAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateHospitalConsulationOperationDataVo updateVo)
        {
            try
            {
                UpdateHospitalConsulationOperationDataDto updateDto = new UpdateHospitalConsulationOperationDataDto();

                updateDto.Id = updateVo.Id;
                updateDto.HospitalId = updateVo.HospitalId;
                updateDto.IndicatorId = updateVo.IndicatorId;
                updateDto.HospitalId = updateVo.HospitalId;
                updateDto.IndicatorId = updateVo.IndicatorId;
                updateDto.ConsulationName = updateVo.ConsulationName;
                updateDto.SendOrderNum = updateVo.SendOrderNum;
                updateDto.NewCustomerVisitNum = updateVo.NewCustomerVisitNum;
                updateDto.NewCustomerVisitRate = updateVo.NewCustomerVisitRate;
                updateDto.NewCustomerDealNum = updateVo.NewCustomerDealNum;
                updateDto.NewCustomerDealRate = updateVo.NewCustomerDealRate;
                updateDto.NewCustomerDealPrice = updateVo.NewCustomerDealPrice;
                updateDto.NewCustomerUnitPrice = updateVo.NewCustomerUnitPrice;

                updateDto.OldCustomerVisitNum = updateVo.OldCustomerVisitNum;
                updateDto.OldCustomerDealNum = updateVo.OldCustomerDealNum;
                updateDto.OldCustomerDealRate = updateVo.OldCustomerDealRate;
                updateDto.OldCustomerDealPrice = updateVo.OldCustomerDealPrice;
                updateDto.OldCustomerUnitPrice = updateVo.OldCustomerUnitPrice;

                updateDto.OldCustomerAchievementRate = updateVo.OldCustomerAchievementRate;
                updateDto.LasttMonthTotalAchievement = updateVo.LasttMonthTotalAchievement;

                await hospitalConsulationOperationDataService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除机构咨询师运营数据分析信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await hospitalConsulationOperationDataService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
