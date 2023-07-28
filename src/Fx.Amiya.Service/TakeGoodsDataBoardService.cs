using Fx.Amiya.Dto.TakeGoods;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class TakeGoodsDataBoardService : ITakeGoodsDataBoardService
    {
        #region GMV看板

        /// <summary>
        /// GMV看板
        /// </summary>
        /// <param name="contentPlatformId"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public Task<GMVDataDto> GetGMVDataAsync(string contentPlatformId, string liveAnchorId, int year, int month)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 业绩趋势折线图
        /// </summary>
        /// <param name="contentPlatformId"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public Task<GMVDataBrokenLineDto> GetGMVDataBrokenLineDataAsync(string contentPlatformId, string liveAnchorId, int year, int month)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 件数看板
        /// </summary>
        /// <param name="contentPlatformId"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public Task<PackagesDataDto> GetPackagesDataAsync(string contentPlatformId, string liveAnchorId, int year, int month)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 件单价看板
        /// </summary>
        /// <param name="contentPlatformId"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public Task<SinglePriceDataDto> GetSinglePriceAsync(string contentPlatformId, string liveAnchorId, int year, int month)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
