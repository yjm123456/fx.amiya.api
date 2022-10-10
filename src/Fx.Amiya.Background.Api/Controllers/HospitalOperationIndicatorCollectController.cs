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
        private IIndicatorSendHospitalService _indicatorSendHospitalService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="indicatorSendHospitalService"></param>
        public HospitalOperationIndicatorCollectController(IIndicatorSendHospitalService indicatorSendHospitalService)
        {
            _indicatorSendHospitalService = indicatorSendHospitalService;
        }

        //public HospitalOperationIndicatorCollectController(
        //    // IHospitalNetWorkConsulationOperationDataService hospitalOperationDataService
        //    )
        //{
        //    //this.hospitalOperationDataService = hospitalOperationDataService;
        //}
        /// <summary>
        /// 获取指标数据汇总列表
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="indicatorsId">归属指标id</param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<HospitalOperationIndicatorCollectVo>>> GetListAsync(string indicatorId, int? hospitalId, int pageNum, int pageSize)
        {
            FxPageInfo<HospitalOperationIndicatorCollectVo> pageInfo = new FxPageInfo<HospitalOperationIndicatorCollectVo>();

            try
            {
                var list = await _indicatorSendHospitalService.GetHospitalOperationIndicatorCollectList(indicatorId, hospitalId, pageNum, pageSize, null);
                pageInfo.TotalCount = list.TotalCount;
                pageInfo.List = list.List.Select(e => new HospitalOperationIndicatorCollectVo
                {
                    HospitalId = e.HospitalId,
                    IndicatorId = e.IndicatorId,
                    IndicatorName = e.IndicatorName,
                    HospitalName = e.HospitalName,
                    HospitalAddress = e.HospitalAddress,
                    IsSubmit = e.IsSubmit,
                    IsRemark=e.IsRemark
                });

                return ResultData<FxPageInfo<HospitalOperationIndicatorCollectVo>>.Success().AddData("hospitalOperationIndicatorCollectData", pageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<HospitalOperationIndicatorCollectVo>>.Fail(ex.Message);
            }
        }
    }
}
