using Fx.Amiya.Background.Api.Vo.Remark;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemarkController : ControllerBase
    {
        private IRemarkService remarkService;
        public RemarkController(IRemarkService remarkService)
        {
            this.remarkService = remarkService;
        }

        #region 优秀机构运营健康指标批注

        /// <summary>
        /// 添加优秀机构运营健康指标批注
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("addAmiyaRemark")]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAmiyaRemarkAsync(AddAmiyaRemarkVo addVo)
        {
            try
            {
                AddAmiyaRemarkDto addDto = new AddAmiyaRemarkDto() { 
                    IndicatorId=addVo.IndicatorId,
                    Remark=addVo.Remark
                };
                await remarkService.AddAmiyaRemark(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 修改优秀机构运营健康批注
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPut("updateAmiyaRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateAmiyaRemarkAsync(UpdateAmiyaRemarkVo updateVo)
        {
            try
            {
                UpdateAmiyaRemarkDto updateDto = new UpdateAmiyaRemarkDto()
                {
                    Id=updateVo.Id,
                    Remark=updateVo.Remark
                };
                await remarkService.UpdateAmiyaRemark(updateDto);
                //AddExpressDto addDto = new AddExpressDto();
                //addDto.ExpressCode = addVo.ExpressCode;
                //addDto.ExpressName = addVo.ExpressName;
                //addDto.Valid = addVo.Valid;

                //await greatHospitalOperationHealthService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取优秀机构运营健康啊美雅批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        [HttpGet("getAmiyaRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<AmiyaRemarkVo>> GetAmiyaRemarkByIdAsync(string indicatorId)
        {
            try
            {
                var remark =await remarkService.GetAmiyaRemark(indicatorId);
                AmiyaRemarkVo hospitalOperationRemarkVo = new AmiyaRemarkVo() { 
                    Id= remark.Id,
                    AmiyaRemark= remark.AmiyaRemark
                };
                return ResultData<AmiyaRemarkVo>.Success().AddData("amiyaRemark", hospitalOperationRemarkVo);
            }
            catch (Exception ex)
            {
                return ResultData<AmiyaRemarkVo>.Fail(ex.Message);
            }
        }

        #endregion


        #region 机构运营数据批注

        /// <summary>
        /// 添加机构运营数据批注
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("addHospitalOperationRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> AddHospitalOperationRemarkAsync(AddHospitalOperationRemarkVo addVo)
        {
            try
            {
                AddHospitalOperationRemarkDto addDto = new AddHospitalOperationRemarkDto()
                {
                    IndicatorId=addVo.IndicatorId,
                    HospitalId=addVo.HospitalId,
                    HospitalOperationRemark=addVo.HospitalOperationRemark,
                    AmiyaOperationRemark=addVo.AmiyaOperationRemark
                };
                await remarkService.AddHospitalOperationRemark(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 修改机构运营数据批注
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPut("updateHospitalOperationRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateHospitalOperationRemarkAsync(UpdateHospitalOperationRemarkVo updateVo)
        {
            try
            {
                UpdateHospitalOperationRemarkDto updateDto = new UpdateHospitalOperationRemarkDto {
                    Id = updateVo.Id,
                    HospitalOperationRemark = updateVo.HospitalOperationRemark,
                    AmiyaOperationRemark=updateVo.AmiyaOperationRemark
                };
                await remarkService.UpdateHospitalOperationRemark(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取机构运营数据批注
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getHospitalOperationRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<HospitalOperationRemarkVo>> GetHospitalOperationRemarkByIdAsync(string indicatorId, int hospitalId)
        {
            try
            {
                var remark =await remarkService.GetHospitalOperationRemark(indicatorId,hospitalId);
                HospitalOperationRemarkVo hospitalOperationRemarkVo = new HospitalOperationRemarkVo() {
                    Id = remark.Id,
                    HospitalOperationRemark = remark.HospitalOperationRemark,
                    AmiyaOperationRemark=remark.AmiyaOperationRemark
                };
                return ResultData<HospitalOperationRemarkVo>.Success().AddData("hospitalOperationRemark", hospitalOperationRemarkVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalOperationRemarkVo>.Fail(ex.Message);
            }
        }

        #endregion


        #region 机构网咨运营数据批注

        /// <summary>
        /// 添加机构网咨运营数据分析批注
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("addHospitalOnlineConsultRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> AddHospitalOnlineConsultRemarkAsync(AddHospitalOnlineConsultRemarkVo addVo)
        {
            try
            {
                AddHospitalOnlineConsultRemarkDto addDto = new AddHospitalOnlineConsultRemarkDto()
                {
                    IndicatorId = addVo.IndicatorId,
                    HospitalId = addVo.HospitalId,
                    HospitalOnlineConsultRemark = addVo.HospitalOnlineConsultRemark,
                    AmiyaOnlineConsultRemark = addVo.AmiyaOnlineConsultRemark
                };
                await remarkService.AddHospitalOnlineConsultRemark(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 修改机构网咨运营数据分析批注
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPut("updateHospitalOnlineConsultRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateHospitalOnlineConsultRemarkAsync(UpdateHospitalOnlineConsultRemarkVo updateVo)
        {
            try
            {
                UpdateHospitalOnlineConsultRemarkDto updateDto = new UpdateHospitalOnlineConsultRemarkDto
                {
                    Id = updateVo.Id,
                    HospitalOnlineConsultRemark = updateVo.HospitalOnlineConsultRemark,
                    AmiyaOnlineConsultRemark = updateVo.AmiyaOnlineConsultRemark
                };
                await remarkService.UpdateHospitalOnlineConsultRemark(updateDto);
                
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取机构网咨运营数据分析批注
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getHospitalOnlineConsultRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<HospitalOnlineConsultRemarkVo>> GetHospitalOnlineConsultRemarkAsync(string indicatorId, int hospitalId)
        {
            try
            {
                var remark = await remarkService.GetHospitalOnlineConsultRemark(indicatorId, hospitalId);
                HospitalOnlineConsultRemarkVo hospitalOperationRemarkVo = new HospitalOnlineConsultRemarkVo()
                {
                    Id = remark.Id,
                    HospitalOnlineConsultRemark = remark.HospitalOnlineConsultRemark,
                    AmiyaOnlineConsultRemark = remark.AmiyaOnlineConsultRemark
                };

                return ResultData<HospitalOnlineConsultRemarkVo>.Success().AddData("hospitalOnlineConsultRemark", hospitalOperationRemarkVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalOnlineConsultRemarkVo>.Fail(ex.Message);
            }
        }

        #endregion


        #region 机构咨询师运营数据分析批注

        /// <summary>
        /// 添加机构咨询师运营数据分析批注
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("addHospitalConsultRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> AddHospitalConsultRemarkAsync(AddHospitalConsultRemarkVo addVo)
        {
            try
            {
                AddHospitalConsultRemarkDto addDto = new AddHospitalConsultRemarkDto()
                {
                    IndicatorId = addVo.IndicatorId,
                    HospitalId = addVo.HospitalId,
                    HospitalConsultRemark = addVo.HospitalConsultRemark,
                    AmiyaConsultRemark = addVo.AmiyaConsultRemark
                };
                await remarkService.AddHospitalConsultRemark(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 修改机构咨询师运营数据分析批注
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPut("updateHospitalConsultRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateHospitalConsultRemarkAsync(UpdateHospitalConsultRemarkVo updateVo)
        {
            try
            {
                UpdateHospitalConsultRemarkDto updateDto = new UpdateHospitalConsultRemarkDto
                {
                    Id = updateVo.Id,
                    HospitalConsultRemark = updateVo.HospitalConsultRemark,
                    AmiyaConsultRemark = updateVo.AmiyaConsultRemark
                };
                await remarkService.UpdateHospitalConsultRemark(updateDto);

                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取机构咨询师运营数据分析批注
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getHospitalConsultRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<HospitalConsultRemarkVo>> GetHospitalConsultRemarkByIdAsync(string indicatorId, int hospitalId)
        {
            try
            {
                var remark = await remarkService.GetHospitalConsultRemark(indicatorId, hospitalId);
                HospitalConsultRemarkVo hospitalOperationRemarkVo = new HospitalConsultRemarkVo()
                {
                    Id = remark.Id,
                    HospitalConsultRemark = remark.HospitalConsultRemark,
                    AmiyaConsultRemark = remark.AmiyaConsultRemark
                };

                return ResultData<HospitalConsultRemarkVo>.Success().AddData("hospitalConsultRemark", hospitalOperationRemarkVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalConsultRemarkVo>.Fail(ex.Message);
            }
        }

        #endregion



        #region 机构医生运营数据分析
        /// <summary>
        /// 添加机构医生运营数据分析
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("addHospitalDoctorRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> AddHospitalDoctorRemarkAsync(AddHospitalDoctorRemarkVo addVo)
        {
            try
            {
                AddHospitalDoctorRemarkDto addDto = new AddHospitalDoctorRemarkDto()
                {
                    IndicatorId = addVo.IndicatorId,
                    HospitalId = addVo.HospitalId,
                    HospitalDoctorRemark = addVo.HospitalDoctorRemark,
                    AmiyaDoctorRemark = addVo.AmiyaDoctorRemark
                };
                await remarkService.AddHospitalDoctorRemark(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 修改机构医生运营数据分析
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPut("updateHospitalDoctorRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateHospitalDoctorRemarkAsync(UpdateHospitalDoctorRemarkVo updateVo)
        {
            try
            {
                UpdateHospitalDoctorRemarkDto updateDto = new UpdateHospitalDoctorRemarkDto
                {
                    Id = updateVo.Id,
                    HospitalDoctorRemark = updateVo.HospitalDoctorRemark,
                    AmiyaDoctorRemark = updateVo.AmiyaDoctorRemark
                };
                await remarkService.UpdateHospitalDoctorRemark(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取机构医生运营数据分析
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getHospitalDoctorRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<HospitalDoctorRemarkVo>> GetHospitalDoctorRemarkByIdAsync(string indicatorId, int hospitalId)
        {
            try
            {
                var remark = await remarkService.GetHospitalDoctorRemark(indicatorId, hospitalId);
                HospitalDoctorRemarkVo hospitalOperationRemarkVo = new HospitalDoctorRemarkVo()
                {
                    Id = remark.Id,
                    HospitalDoctorRemark = remark.HospitalDoctorRemark,
                    AmiyaDoctorRemark = remark.AmiyaDoctorRemark
                };

                return ResultData<HospitalDoctorRemarkVo>.Success().AddData("hospitalDoctorRemark", hospitalOperationRemarkVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalDoctorRemarkVo>.Fail(ex.Message);
            }
        }


        #endregion

        #region 机构成交品项数据分析批注

        /// <summary>
        /// 添加机构成交品项数据分析批注
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("addHospitalDealRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> AddHospitalDealRemarkAsync(AddHospitalDealRemarkVo addVo)
        {
            try
            {
                AddHospitalDealRemarkDto addDto = new AddHospitalDealRemarkDto()
                {
                    IndicatorId = addVo.IndicatorId,
                    HospitalId = addVo.HospitalId,
                    HospitalDealRemark = addVo.HospitalDealRemark,
                    AmiyaDealRemark = addVo.AmiyaDealRemark
                };
                await remarkService.AddHospitalDealRemark(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 修改机构成交品项数据分析批注
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPut("updateHospitalDealRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateHospitalDealRemarkAsync(UpdateHospitalDealRemarkVo updateVo)
        {
            try
            {
                UpdateHospitalDealRemarkDto updateDto = new UpdateHospitalDealRemarkDto
                {
                    Id=updateVo.Id,
                    HospitalDealRemark = updateVo.HospitalDealRemark,
                    AmiyaDealRemark = updateVo.AmiyaDealRemark
                };
                await remarkService.UpdateHospitalDealRemark(updateDto);
                return ResultData.Success();            
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取机构成交品项数据分析批注
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getHospitalDealRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<HospitalDealRemarkVo>> GetHospitalDealRemarkByIdAsync(string indicatorId,int hospitalId)
        {
            try
            {
                var remark = await remarkService.GetHospitalDealRemark(indicatorId, hospitalId);
                HospitalDealRemarkVo hospitalOperationRemarkVo = new HospitalDealRemarkVo()
                {
                    Id = remark.Id,
                    HospitalDealRemark = remark.HospitalDealRemark,
                    AmiyaDealRemark = remark.AmiyaDealRemark
                };


                return ResultData<HospitalDealRemarkVo>.Success().AddData("hospitalDealRemark", hospitalOperationRemarkVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalDealRemarkVo>.Fail(ex.Message);
            }
        }

        #endregion
    }
}
