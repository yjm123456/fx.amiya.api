using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.HospitalDoctorOperation;
using Fx.Amiya.Background.Api.Vo.HospitalNetWorkConsulationOperationData;
using Fx.Amiya.Dto.HospitalDoctorOperationData;
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
    /// 机构医生运营数据分析板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HospitalDoctorOperationController : ControllerBase
    {
        private IHospitalDoctorOperationDataService hospitalDoctorOperationDataService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalDoctorOperationDataService"></param>
        public HospitalDoctorOperationController(
             IHospitalDoctorOperationDataService hospitalDoctorOperationDataService
            )
        {
            this.hospitalDoctorOperationDataService = hospitalDoctorOperationDataService;
        }


        /// <summary>
        /// 获取医生运营数据分析板块信息列表
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="indicatorsId">归属指标id</param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<HospitalDoctorOperationVo>>> GetListAsync(string keyword, string indicatorsId)
        {
            try
            {
                var q = await hospitalDoctorOperationDataService.GetListAsync(keyword, indicatorsId);

                var hospitalDoctorOperationData = from d in q
                                            select new HospitalDoctorOperationVo
                                            {
                                                Id = d.Id,
                                                HospitalId = d.HospitalId,
                                                IndicatorId = d.IndicatorId,
                                                DoctorName = d.DoctorName,
                                                NewCustomerAcceptNum = d.NewCustomerAcceptNum,
                                                NewCustomerDealNum = d.NewCustomerDealNum,
                                                NewCustomerDealRate = d.NewCustomerDealRate,
                                                NewCustomerAchievement = d.NewCustomerAchievement,
                                                NewCustomerUnitPrice = d.NewCustomerUnitPrice,
                                                NewCustomerAchievementRate = d.NewCustomerAchievementRate,
                                                OldCustomerAcceptNum = d.OldCustomerAcceptNum,
                                                OldCustomerDealNum = d.OldCustomerDealNum,
                                                OldCustomerDealRate = d.OldCustomerDealRate,
                                                OldCustomerAchievement = d.OldCustomerAchievement,
                                                OldCustomerUnitPrice = d.OldCustomerUnitPrice,
                                                OldCustomerAchievementRate = d.OldCustomerAchievementRate,
                                            };

                List<HospitalDoctorOperationVo> hospitalDoctorOperationDataPageInfo = new List<HospitalDoctorOperationVo>();

                hospitalDoctorOperationDataPageInfo = hospitalDoctorOperationData.ToList();
                return ResultData<List<HospitalDoctorOperationVo>>.Success().AddData("hospitalDoctorOperationData", hospitalDoctorOperationDataPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalDoctorOperationVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 添加医生运营数据分析信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [FxTenantAuthorize]
        [HttpPost]
        public async Task<ResultData> AddAsync(AddHospitalDoctorOperationVo addVo)
        {
            try
            {
                AddHospitalDoctorOperationDataDto addDto = new AddHospitalDoctorOperationDataDto();
                addDto.HospitalId = addVo.HospitalId;
                addDto.IndicatorId = addVo.IndicatorId;
                addDto.NewCustomerAcceptNum = addVo.NewCustomerAcceptNum;
                addDto.NewCustomerDealNum = addVo.NewCustomerDealNum;
                addDto.NewCustomerDealRate = addVo.NewCustomerDealRate;
                addDto.NewCustomerAchievement = addVo.NewCustomerAchievement;
                addDto.NewCustomerUnitPrice = addVo.NewCustomerUnitPrice;
                addDto.NewCustomerAchievementRate = addVo.NewCustomerAchievementRate;
                addDto.OldCustomerAcceptNum = addVo.OldCustomerAcceptNum;
                addDto.OldCustomerDealNum = addVo.OldCustomerDealNum;
                addDto.OldCustomerDealRate = addVo.OldCustomerDealRate;
                addDto.OldCustomerAchievement = addVo.OldCustomerAchievement;
                addDto.OldCustomerUnitPrice = addVo.OldCustomerUnitPrice;
                addDto.OldCustomerAchievementRate = addVo.OldCustomerAchievementRate;

                await hospitalDoctorOperationDataService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据医生运营数据板块分析编号获取机构医生运营数据分析信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData<HospitalDoctorOperationVo>> GetByIdAsync(string id)
        {
            try
            {
                var hospitalDoctorOperationData = await hospitalDoctorOperationDataService.GetByIdAsync(id);
                HospitalDoctorOperationVo hospitalDoctorOperationDataVo = new HospitalDoctorOperationVo();
                hospitalDoctorOperationDataVo.Id = hospitalDoctorOperationData.Id;
                hospitalDoctorOperationDataVo.CreateDate = hospitalDoctorOperationData.CreateDate;
                hospitalDoctorOperationDataVo.UpdateDate = hospitalDoctorOperationData.UpdateDate;
                hospitalDoctorOperationDataVo.DeleteDate = hospitalDoctorOperationData.DeleteDate;
                hospitalDoctorOperationDataVo.Valid = hospitalDoctorOperationData.Valid;
                hospitalDoctorOperationDataVo.HospitalId = hospitalDoctorOperationData.HospitalId;
                hospitalDoctorOperationDataVo.IndicatorId = hospitalDoctorOperationData.IndicatorId;
                hospitalDoctorOperationDataVo.NewCustomerAcceptNum = hospitalDoctorOperationData.NewCustomerAcceptNum;
                hospitalDoctorOperationDataVo.NewCustomerDealNum = hospitalDoctorOperationData.NewCustomerDealNum;
                hospitalDoctorOperationDataVo.NewCustomerDealRate = hospitalDoctorOperationData.NewCustomerDealRate;
                hospitalDoctorOperationDataVo.NewCustomerAchievement = hospitalDoctorOperationData.NewCustomerAchievement;
                hospitalDoctorOperationDataVo.NewCustomerUnitPrice = hospitalDoctorOperationData.NewCustomerUnitPrice;
                hospitalDoctorOperationDataVo.NewCustomerAchievementRate = hospitalDoctorOperationData.NewCustomerAchievementRate;
                hospitalDoctorOperationDataVo.OldCustomerAcceptNum = hospitalDoctorOperationData.OldCustomerAcceptNum;
                hospitalDoctorOperationDataVo.OldCustomerDealNum = hospitalDoctorOperationData.OldCustomerDealNum;
                hospitalDoctorOperationDataVo.OldCustomerDealRate = hospitalDoctorOperationData.OldCustomerDealRate;
                hospitalDoctorOperationDataVo.OldCustomerAchievement = hospitalDoctorOperationData.OldCustomerAchievement;
                hospitalDoctorOperationDataVo.OldCustomerUnitPrice = hospitalDoctorOperationData.OldCustomerUnitPrice;
                hospitalDoctorOperationDataVo.OldCustomerAchievementRate = hospitalDoctorOperationData.OldCustomerAchievementRate;

                return ResultData<HospitalDoctorOperationVo>.Success().AddData("hospitalDoctorOperationInfo", hospitalDoctorOperationDataVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalDoctorOperationVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改机构医生运营数据分析信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxTenantAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateHospitalDoctorOperationVo updateVo)
        {
            try {

                UpdateHospitalDoctorOperationDataDto updateDto = new UpdateHospitalDoctorOperationDataDto();
                updateDto.HospitalId = updateVo.HospitalId;
                updateDto.IndicatorId = updateVo.IndicatorId;
                updateDto.NewCustomerAcceptNum = updateVo.NewCustomerAcceptNum;
                updateDto.NewCustomerDealNum = updateVo.NewCustomerDealNum;
                updateDto.NewCustomerDealRate = updateVo.NewCustomerDealRate;
                updateDto.NewCustomerAchievement = updateVo.NewCustomerAchievement;
                updateDto.NewCustomerUnitPrice = updateVo.NewCustomerUnitPrice;
                updateDto.NewCustomerAchievementRate = updateVo.NewCustomerAchievementRate;
                updateDto.OldCustomerAcceptNum = updateVo.OldCustomerAcceptNum;
                updateDto.OldCustomerDealNum = updateVo.OldCustomerDealNum;
                updateDto.OldCustomerDealRate = updateVo.OldCustomerDealRate;
                updateDto.OldCustomerAchievement = updateVo.OldCustomerAchievement;
                updateDto.OldCustomerUnitPrice = updateVo.OldCustomerUnitPrice;
                updateDto.OldCustomerAchievementRate = updateVo.OldCustomerAchievementRate;
                await hospitalDoctorOperationDataService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除机构医生运营数据分析信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxTenantAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await hospitalDoctorOperationDataService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
