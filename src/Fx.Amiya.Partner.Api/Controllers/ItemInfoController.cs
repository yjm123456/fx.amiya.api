using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.IService;
using Fx.Amiya.Partner.Api.Vo.ItemInfo;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Partner.Api.Controllers
{
    [Route("partner/[controller]")]
    [ApiController]
    public class ItemInfoController : ControllerBase
    {
        private IItemInfoService itemInfoService;
        public ItemInfoController(IItemInfoService itemInfoService)
        {
            this.itemInfoService = itemInfoService;
        }

        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<ItemInfoVo>>> GetListWithAsync(string keyword, int pageNum, int pageSize)
        {
            var q = await itemInfoService.GetListWithPageAsync(keyword, pageNum, pageSize, true);
            var itemInfo = from d in q.List
                           select new ItemInfoVo
                           {
                               Id = d.Id,
                               TmallGoodsId = d.OtherAppItemId,
                               Name = d.Name,
                               ThumbPicUrl = d.ThumbPicUrl,
                               Description = d.Description,
                               Standard = d.Standard,
                               Parts = d.Parts,
                               Commitment = d.Commitment,
                               Guarantee = d.Guarantee,
                               AppointmentNotice = d.AppointmentNotice
                           };

            FxPageInfo<ItemInfoVo> itemPageInfo = new FxPageInfo<ItemInfoVo>();
            itemPageInfo.TotalCount = q.TotalCount;
            itemPageInfo.List = itemInfo;
            return ResultData<FxPageInfo<ItemInfoVo>>.Success().AddData("itemInfo",itemPageInfo);
        }
    }
}