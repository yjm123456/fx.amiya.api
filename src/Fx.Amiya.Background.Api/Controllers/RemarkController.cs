using Fx.Amiya.Background.Api.Vo.Remark;
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
        public RemarkController(
            // IGreatHospitalOperationHealthService greatHospitalOperationHealthService
            )
        {
            //this.greatHospitalOperationHealthService = greatHospitalOperationHealthService;
        }

        #region 运营指标批注

        /// <summary>
        /// 添加机构运营指标批注
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("addAmiyaRemark")]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAmiyaRemarkAsync(AddAmiyaRemarkVo addVo)
        {
            try
            {
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
        /// 修改机构运营数据批注
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPut("updateAmiyaRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateAmiyaRemarkAsync(AddAmiyaRemarkVo addVo)
        {
            try
            {
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
        /// 获取指标啊美雅批注
        /// </summary>
        /// <param name="indicatorId"></param>
        /// <returns></returns>
        [HttpGet("getAmiyaRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<HospitalOperationRemarkVo>> GetAmiyaRemarkByIdAsync(string indicatorId)
        {
            try
            {
                //var greatHospitalOperationHealth = await greatHospitalOperationHealthService.GetByIdAsync(id);
                HospitalOperationRemarkVo hospitalOperationRemarkVo = new HospitalOperationRemarkVo();
                //greatHospitalOperationHealthVo.Id = greatHospitalOperationHealth.Id;
                //greatHospitalOperationHealthVo.ExpressCode = greatHospitalOperationHealth.ExpressCode;
                //greatHospitalOperationHealthVo.ExpressName = greatHospitalOperationHealth.ExpressName;
                //greatHospitalOperationHealthVo.Valid = greatHospitalOperationHealth.Valid;

                return ResultData<HospitalOperationRemarkVo>.Success().AddData("amiyaRemark", hospitalOperationRemarkVo);
            }
            catch (Exception ex)
            {
                return ResultData<HospitalOperationRemarkVo>.Fail(ex.Message);
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
        /// 修改机构运营数据批注
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPut("updateHospitalOperationRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateHospitalOperationRemarkAsync(AddHospitalOperationRemarkVo addVo)
        {
            try
            {
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
        /// 获取机构运营数据批注
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getHospitalOperationRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<HospitalOperationRemarkVo>> GetHospitalOperationRemarkByIdAsync(string indicatorId, string hospitalId)
        {
            try
            {
                //var greatHospitalOperationHealth = await greatHospitalOperationHealthService.GetByIdAsync(id);
                HospitalOperationRemarkVo hospitalOperationRemarkVo = new HospitalOperationRemarkVo();
                //greatHospitalOperationHealthVo.Id = greatHospitalOperationHealth.Id;
                //greatHospitalOperationHealthVo.ExpressCode = greatHospitalOperationHealth.ExpressCode;
                //greatHospitalOperationHealthVo.ExpressName = greatHospitalOperationHealth.ExpressName;
                //greatHospitalOperationHealthVo.Valid = greatHospitalOperationHealth.Valid;

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
        /// 修改机构网咨运营数据分析批注
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPut("updateHospitalOnlineConsultRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateHospitalOnlineConsultRemarkAsync(AddHospitalOnlineConsultRemarkVo addVo)
        {
            try
            {
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
        /// 获取机构网咨运营数据分析批注
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getHospitalOnlineConsultRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<HospitalOnlineConsultRemarkVo>> GetHospitalOnlineConsultRemarkAsync(string indicatorId, string hospitalId)
        {
            try
            {
                //var greatHospitalOperationHealth = await greatHospitalOperationHealthService.GetByIdAsync(id);
                HospitalOnlineConsultRemarkVo hospitalOperationRemarkVo = new HospitalOnlineConsultRemarkVo();
                //greatHospitalOperationHealthVo.Id = greatHospitalOperationHealth.Id;
                //greatHospitalOperationHealthVo.ExpressCode = greatHospitalOperationHealth.ExpressCode;
                //greatHospitalOperationHealthVo.ExpressName = greatHospitalOperationHealth.ExpressName;
                //greatHospitalOperationHealthVo.Valid = greatHospitalOperationHealth.Valid;

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
        public async Task<ResultData> AddHospitalConsultRemarkAsync(HospitalConsultRemarkVo addVo)
        {
            try
            {
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
        /// 修改机构咨询师运营数据分析批注
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPut("updateHospitalConsultRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateHospitalConsultRemarkAsync(AddHospitalConsultRemarkVo addVo)
        {
            try
            {
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
        /// 获取机构咨询师运营数据分析批注
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getHospitalConsultRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<HospitalConsultRemarkVo>> GetHospitalConsultRemarkByIdAsync(string indicatorId, string hospitalId)
        {
            try
            {
                //var greatHospitalOperationHealth = await greatHospitalOperationHealthService.GetByIdAsync(id);
                HospitalConsultRemarkVo hospitalOperationRemarkVo = new HospitalConsultRemarkVo();
                //greatHospitalOperationHealthVo.Id = greatHospitalOperationHealth.Id;
                //greatHospitalOperationHealthVo.ExpressCode = greatHospitalOperationHealth.ExpressCode;
                //greatHospitalOperationHealthVo.ExpressName = greatHospitalOperationHealth.ExpressName;
                //greatHospitalOperationHealthVo.Valid = greatHospitalOperationHealth.Valid;

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
        public async Task<ResultData> AddHospitalDoctorRemarkAsync(HospitalDoctorRemarkVo addVo)
        {
            try
            {
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
        /// 修改机构医生运营数据分析
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPut("updateHospitalDoctorRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateHospitalDoctorRemarkAsync(AddHospitalDoctorRemarkVo addVo)
        {
            try
            {
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
        /// 获取机构医生运营数据分析
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getHospitalDoctorRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<HospitalDoctorRemarkVo>> GetHospitalDoctorRemarkByIdAsync(string indicatorId, string hospitalId)
        {
            try
            {
                //var greatHospitalOperationHealth = await greatHospitalOperationHealthService.GetByIdAsync(id);
                HospitalDoctorRemarkVo hospitalOperationRemarkVo = new HospitalDoctorRemarkVo();
                //greatHospitalOperationHealthVo.Id = greatHospitalOperationHealth.Id;
                //greatHospitalOperationHealthVo.ExpressCode = greatHospitalOperationHealth.ExpressCode;
                //greatHospitalOperationHealthVo.ExpressName = greatHospitalOperationHealth.ExpressName;
                //greatHospitalOperationHealthVo.Valid = greatHospitalOperationHealth.Valid;

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
        public async Task<ResultData> AddHospitalDealRemarkAsync(HospitalDealRemarkVo addVo)
        {
            try
            {
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
        /// 修改机构成交品项数据分析批注
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPut("updateHospitalDealRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> UpdateHospitalDealRemarkAsync(AddHospitalDealRemarkVo addVo)
        {
            try
            {
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
        /// 获取机构成交品项数据分析批注
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getHospitalDealRemark")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<HospitalDealRemarkVo>> GetHospitalDealRemarkByIdAsync(string indicatorId)
        {
            try
            {
                //var greatHospitalOperationHealth = await greatHospitalOperationHealthService.GetByIdAsync(id);
                HospitalDealRemarkVo hospitalOperationRemarkVo = new HospitalDealRemarkVo();
                //greatHospitalOperationHealthVo.Id = greatHospitalOperationHealth.Id;
                //greatHospitalOperationHealthVo.ExpressCode = greatHospitalOperationHealth.ExpressCode;
                //greatHospitalOperationHealthVo.ExpressName = greatHospitalOperationHealth.ExpressName;
                //greatHospitalOperationHealthVo.Valid = greatHospitalOperationHealth.Valid;

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
