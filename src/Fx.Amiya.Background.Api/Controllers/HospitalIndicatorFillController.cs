using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.HospitalDealGoodsOperation;
using Fx.Amiya.Background.Api.Vo.HospitalDoctorOperation;
using Fx.Amiya.Background.Api.Vo.HospitalImprovePlan;
using Fx.Amiya.Background.Api.Vo.HospitalIndeicatorInput;
using Fx.Amiya.Background.Api.Vo.HospitalNetWorkConsulationOperationData;
using Fx.Amiya.Background.Api.Vo.HospitalOperationIndicatorSubmit;
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
    /// 医院指标数据填报列表接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HospitalIndicatorFillController : ControllerBase
    {
        private IIndicatorSendHospitalService _indicatorSendHospitalService;
        private IHttpContextAccessor httpContextAccessor;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="indicatorSendHospitalService"></param>
        /// <param name="httpContextAccessor"></param>
        public HospitalIndicatorFillController(IIndicatorSendHospitalService indicatorSendHospitalService, IHttpContextAccessor httpContextAccessor)
        {
            _indicatorSendHospitalService = indicatorSendHospitalService;
            this.httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// 获取机构填报数据列表
        /// </summary>
        /// <param name="submit">是否提报</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxTenantAuthorize]
        public async Task<ResultData<FxPageInfo<HospitalIndicatorFillVo>>> GetListAsync(bool? submit, int pageNum, int pageSize)
        {
            FxPageInfo<HospitalIndicatorFillVo> fxPageInfo = new FxPageInfo<HospitalIndicatorFillVo>();
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
                int hospitalId = employee.HospitalId;
                var list = await _indicatorSendHospitalService.GetHospitalOperationIndicatorFillList(hospitalId, pageNum, pageSize, submit);
                fxPageInfo.TotalCount = list.TotalCount;
                fxPageInfo.List = list.List.Select(e => new HospitalIndicatorFillVo
                {
                    HospitalId = e.HospitalId,
                    IndicatorId = e.IndicatorId,
                    IndicatorName = e.IndicatorName,
                    Describe = e.Describe,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    IsRemark=e.IsRemark
                }).ToList();

                return ResultData<FxPageInfo<HospitalIndicatorFillVo>>.Success().AddData("hospitalIndicatorFillData", fxPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<HospitalIndicatorFillVo>>.Fail(ex.Message);
            }
        }
    }
}
