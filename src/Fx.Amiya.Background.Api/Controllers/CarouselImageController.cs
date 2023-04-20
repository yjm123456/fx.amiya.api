using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.CarouselImage;
using Fx.Amiya.Dto.CarouselImage;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class CarouselImageController : ControllerBase
    {

        private ICarouselImageService carouselImageService;
        private IMiniprogramService miniprogramService;
        public CarouselImageController(ICarouselImageService carouselImageService, IMiniprogramService miniprogramService)
        {
            this.carouselImageService = carouselImageService;
            this.miniprogramService = miniprogramService;
        }



        /// <summary>
        /// 获取轮播图列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<List<HomepageCarouselImageVo>>> GetListAsync()
        {
            try
            {
                var q = from d in await carouselImageService.GetListAsync()
                        select new HomepageCarouselImageVo
                        {
                            Id = d.Id,
                            PicUrl = d.PicUrl,
                            DisplayIndex = d.DisplayIndex,
                            LinkUrl=d.LinkUrl,
                            CreateDate = d.CreateDate,
                            AppId=d.AppId,
                            AppName=d.AppName
                        };
                return ResultData<List<HomepageCarouselImageVo>>.Success().AddData("carouselImageList", q.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<HomepageCarouselImageVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 添加轮播图
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<ResultData> AddAsync(AddCarouselImageVo addVo)
        {
            try
            {
                AddCarouselImageDto addDto = new AddCarouselImageDto();
                addDto.PicUrl = addVo.PicUrl;
                addDto.LinkUrl = addVo.LinkUrl;
                addDto.AppId = addVo.AppId;
                await carouselImageService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据轮播图编号获取轮播图信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<HomepageCarouselImageVo>> GetByIdAsync(int id)
        {
            try
            {
                var carouselImage = await carouselImageService.GetByIdAsync(id);
                HomepageCarouselImageVo carouselImageVo = new HomepageCarouselImageVo();
                carouselImageVo.DisplayIndex = carouselImage.DisplayIndex;
                carouselImageVo.PicUrl = carouselImage.PicUrl;
                carouselImageVo.LinkUrl = carouselImage.LinkUrl;
                carouselImageVo.CreateDate = carouselImage.CreateDate;
                carouselImageVo.Id = carouselImage.Id;
                carouselImageVo.AppId = carouselImage.AppId;
                carouselImageVo.AppName = carouselImage.AppName;
                return ResultData<HomepageCarouselImageVo>.Success().AddData("carouselImageInfo", carouselImageVo);
            }
            catch (Exception ex)
            {
                return ResultData<HomepageCarouselImageVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改轮播图信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateCarouselImageVo updateVo)
        {
            try
            {
                UpdateCarouselImageDto updateDto = new UpdateCarouselImageDto();
                updateDto.Id = updateVo.Id;
                updateDto.PicUrl = updateVo.PicUrl;
                updateDto.DisplayIndex = updateVo.DisplayIndex;
                updateDto.LinkUrl = updateVo.LinkUrl;
                updateDto.AppId = updateVo.AppId;
                await carouselImageService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 删除轮播图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(int id)
        {
            try
            {
                await carouselImageService.DeletaAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 获取小程序名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("miniprogramNameList")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetMiniprogramNameList()
        {
            var nameList = await miniprogramService.GetMiniProgramNameListAsync();
            var result = nameList.Select(e => new BaseIdAndNameVo
            {
                Id = e.Key,
                Name = e.Value
            }).ToList();
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("nameList", result);
        }
    }
}