using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.HospitalDealGoodsOperation;
using Fx.Amiya.Background.Api.Vo.HospitalDoctorOperation;
using Fx.Amiya.Background.Api.Vo.HospitalImprovePlan;
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
    /// 机构指标数据汇总
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HospitalOperationIndicatorCollectController : ControllerBase
    {
        //private IHospitalNetWorkConsulationOperationDataService hospitalOperationDataService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hospitalOperationDataService"></param>
        public HospitalOperationIndicatorCollectController(
            // IHospitalNetWorkConsulationOperationDataService hospitalOperationDataService
            )
        {
            //this.hospitalOperationDataService = hospitalOperationDataService;
        }
        /// <summary>
        /// 获取机构成交品项分析信息列表
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="indicatorsId">归属指标id</param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<HospitalOperationIndicatorCollectVo>>> GetListAsync(string indicatorId, int? hospitalId,int pageNum,int pageSize)
        {
            try
            {
                //  var q = await hospitalOperationDataService.GetListAsync(keyword, indicatorsId);

                //var hospitalOperationData = from d in q.List
                //              select new HospitalOperationIndicatorCollectVo
                //              {
                //                  Id = d.Id,
                //                  ExpressCode = d.ExpressCode,
                //                  ExpressName = d.ExpressName,
                //                  Valid = d.Valid
                //              };

                List<HospitalOperationIndicatorCollectVo> hospitalOperationDataPageInfo = new List<HospitalOperationIndicatorCollectVo>();
                HospitalOperationIndicatorCollectVo re = new HospitalOperationIndicatorCollectVo();



                return ResultData<List<HospitalOperationIndicatorCollectVo>>.Success().AddData("hospitalOperationIndicatorCollectData", hospitalOperationDataPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<List<HospitalOperationIndicatorCollectVo>>.Fail(ex.Message);
            }
        }
    }
}
