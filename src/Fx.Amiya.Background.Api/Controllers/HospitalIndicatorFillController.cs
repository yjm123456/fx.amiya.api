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
        //private IHospitalNetWorkConsulationOperationDataService hospitalOperationDataService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalOperationDataService"></param>
        public HospitalIndicatorFillController(
            // IHospitalNetWorkConsulationOperationDataService hospitalOperationDataService
            )
        {
            //this.hospitalOperationDataService = hospitalOperationDataService;
        }
        /// <summary>
        /// 获取机构填报数据列表
        /// </summary>
        /// <param name="submit">是否提报</param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxTenantAuthorize]
        public async Task<ResultData<List<HospitalIndicatorFillVo>>> GetListAsync(bool submit)
        {
            try
            {
                //  var q = await hospitalOperationDataService.GetListAsync(keyword, indicatorsId);

                //var hospitalOperationData = from d in q.List
                //              select new HospitalIndicatorFillVo
                //              {
                //                  Id = d.Id,
                //                  ExpressCode = d.ExpressCode,
                //                  ExpressName = d.ExpressName,
                //                  Valid = d.Valid
                //              };

                List<HospitalIndicatorFillVo> hospitalOperationDataPageInfo = new List<HospitalIndicatorFillVo>();
                HospitalIndicatorFillVo re = new HospitalIndicatorFillVo();



                return ResultData<List<HospitalIndicatorFillVo>>.Success().AddData("hospitalIndicatorFillData", hospitalOperationDataPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalIndicatorFillVo>>.Fail(ex.Message);
            }
        }
    }
}
