using Fx.Amiya.Background.Api.Vo.TakeGoods.Input;
using Fx.Amiya.Background.Api.Vo.TakeGoods.Result;
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
    /// <summary>
    /// 带货看板数据
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class TakeGoodsDataBoardController : ControllerBase
    {
        private readonly ITakeGoodsDataBoardService takeGoodsDataBoardService;

        public TakeGoodsDataBoardController(ITakeGoodsDataBoardService takeGoodsDataBoardService)
        {
            this.takeGoodsDataBoardService = takeGoodsDataBoardService;
        }
        #region GMV看板

        /// <summary>
        /// 获取GMV看板数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("gmvData")]
        public async Task<ResultData<GMVDataVo>> GetGMVDataAsync([FromQuery] QueryGmvDataVo query) {
            GMVDataVo result = new GMVDataVo();
            return ResultData<GMVDataVo>.Success().AddData("gmvData",result);
        }
        /// <summary>
        /// 获取件数看板数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("packagesData")]
        public async Task<ResultData<PackagesDataVo>> GetPackagesDataAsync([FromQuery] QueryGmvDataVo query) {
            PackagesDataVo result = new PackagesDataVo();
            return ResultData<PackagesDataVo>.Success().AddData("packagesData",result);
        }
        /// <summary>
        /// 获取件单价看板数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("singlePriceData")]
        public async Task<ResultData<SinglePriceDataVo>> GetSinglePriceAsync([FromQuery] QueryGmvDataVo query) {
            SinglePriceDataVo result = new SinglePriceDataVo();
            return ResultData<SinglePriceDataVo>.Success().AddData("singlePrice",result);
        }
        /// <summary>
        /// 获取业绩趋势折线图数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("gmvDataBrokenLineData")]
        public async Task<ResultData<GMVDataBrokenLineVo>> GetGMVDataBrokenLineDataAsync([FromQuery] QueryGmvDataVo query) {
            GMVDataBrokenLineVo result = new GMVDataBrokenLineVo();
            return ResultData<GMVDataBrokenLineVo>.Success().AddData("brokenLineData",result);
        }

        #endregion
    }
}
