using Fx.Amiya.Dto.TakeGoods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ITakeGoodsDataBoardService
    {
        #region GMV看板

        Task<GMVDataDto> GetGMVDataAsync(string contentPlatformId, string liveAnchorId, int year, int month);
        Task<PackagesDataDto> GetPackagesDataAsync(string contentPlatformId, string liveAnchorId, int year, int month);
        Task<SinglePriceDataDto> GetSinglePriceAsync(string contentPlatformId, string liveAnchorId, int year, int month);
        Task<GMVDataBrokenLineDto> GetGMVDataBrokenLineDataAsync(string contentPlatformId, string liveAnchorId, int year, int month);
        Task<CategoryAnalizeDataDto> GetCategoryAnalizeDataAsync(string contentPlatformId, string liveAnchorId, int year, int month);
        Task<BrandAnalizeDataDto> GetBrandAnalizeDataAsync(string contentPlatformId, string liveAnchorId, int year, int month);
        Task<BrandAnalizeDataDto> GetItemDetailsAnalizeDataAsync(string contentPlatformId, string liveAnchorId, int year, int month);
        #endregion

    }
}
