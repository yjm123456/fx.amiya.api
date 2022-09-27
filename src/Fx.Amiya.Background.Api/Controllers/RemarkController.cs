using Fx.Amiya.Background.Api.Vo.Remark;
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




        #region 机构运营数据批注

        /// <summary>
        /// 添加机构运营数据批注
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
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

        

    }
}
