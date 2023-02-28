

using Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlateFormOrder;
using Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlatFormOrderSend;
using Fx.Amiya.BusinessWeChat.Api.Vo.OrderCheckPicture;
using Fx.Amiya.BusinessWeChat.Api.Vo.Performance;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWechat.Api.Controllers
{
    /// <summary>
    /// 数据中心板块接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class AmiyaBusinessPerformanceController : ControllerBase
    {
        private IAmiyaPerformanceService amiyaPerformanceService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amiyaPerformanceService"></param>
        public AmiyaBusinessPerformanceController(IAmiyaPerformanceService amiyaPerformanceService)
        {
            this.amiyaPerformanceService = amiyaPerformanceService;
        }
        #region 【达人业绩】
        /// <summary>
        /// 达人业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorBaseId">主播基础id，不传查询所有</param>
        /// <param name="isSelfLiveAnchor">是否为自播主播</param>
        /// <returns></returns>
        [HttpGet("PerformanceByLiveAnchorName")]
        public async Task<ResultData<LiveAnchorMonthPerformanceVo>> GetPerformanceByGroupAsync(int year, int month, string liveAnchorBaseId, bool? isSelfLiveAnchor)
        {
            //获取当前月同比,环比等数据
            var groupPerformance = await amiyaPerformanceService.GetMonthPerformanceBySelfLiveAnchorAsync(year, month, liveAnchorBaseId, isSelfLiveAnchor);
            LiveAnchorMonthPerformanceVo groupPerformanceVo = new LiveAnchorMonthPerformanceVo();

            #region 【总业绩】
            groupPerformanceVo.CueerntMonthTotalPerformance = groupPerformance.CueerntMonthTotalPerformance;
            groupPerformanceVo.TotalPerformanceYearOnYear = groupPerformance.TotalPerformanceYearOnYear;
            groupPerformanceVo.TotalPerformanceChainratio = groupPerformance.TotalPerformanceChainratio;
            groupPerformanceVo.TotalPerformanceTargetComplete = groupPerformance.TotalPerformanceTargetComplete;
            #endregion
            #region 【新诊业绩】
            groupPerformanceVo.CurrentMonthNewCustomerPerformance = groupPerformance.CurrentMonthNewCustomerPerformance;
            groupPerformanceVo.NewCustomerPerformanceYearOnYear = groupPerformance.NewCustomerPerformanceYearOnYear;
            groupPerformanceVo.NewCustomerPerformanceChainRatio = groupPerformance.NewCustomerPerformanceChainRatio;
            groupPerformanceVo.NewCustomerPerformanceTargetComplete = groupPerformance.NewCustomerPerformanceTargetComplete;
            #endregion
            #region 【老客业绩】
            groupPerformanceVo.CurrentMonthOldCustomerPerformance = groupPerformance.CurrentMonthOldCustomerPerformance;
            groupPerformanceVo.OldCustomerPerformanceYearOnYear = groupPerformance.OldCustomerPerformanceYearOnYear;
            groupPerformanceVo.OldCustomerPerformanceChainRatio = groupPerformance.OldCustomerPerformanceChainRatio;
            groupPerformanceVo.OldCustomerTargetComplete = groupPerformance.OldCustomerTargetComplete;
            #endregion

            return ResultData<LiveAnchorMonthPerformanceVo>.Success().AddData("performance", groupPerformanceVo);
        }

        #endregion



    }
}
