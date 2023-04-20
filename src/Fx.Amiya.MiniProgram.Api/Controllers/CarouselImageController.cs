using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Vo.CarouselImage;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    public class CarouselImageController : ControllerBase
    {
        private ICarouselImageService carouselImageService;
        public CarouselImageController(ICarouselImageService carouselImageService)
        {
            this.carouselImageService = carouselImageService;
        }

        /// <summary>
        /// 获取轮播图列表
        /// </summary>
        /// <returns></returns>
       [HttpGet("list/{appid}")]
        public async Task<ResultData<List<HomepageCarouselImageVo>>> GetListAsync(string appid)
        {
            try
            {

                var carouselImage = from d in await carouselImageService.GetListAsync(appid)
                                    select new HomepageCarouselImageVo
                                    {
                                        Id = d.Id,
                                        DisplayIndex = d.DisplayIndex,
                                        LinkUrl=d.LinkUrl,
                                        PicUrl=d.PicUrl
                                    };
                return ResultData<List<HomepageCarouselImageVo>>.Success().AddData("carouselImage", carouselImage.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<HomepageCarouselImageVo>>.Fail(ex.Message);
            }
        }
    }
}