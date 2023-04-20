using Fx.Amiya.Dto.CarouselImage;
using Fx.Amiya.IDal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fx.Amiya.IService;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;

namespace Fx.Amiya.Service
{
    public class CarouselImageService : ICarouselImageService
    {
        private IDalHomepageCarouselImage dalHomepageCarouselImage;
        private IMiniprogramService miniprogramService;
        private IDalMiniprogram dalMiniprogram;
        public CarouselImageService(IDalHomepageCarouselImage dalHomepageCarouselImage, IMiniprogramService miniprogramService, IDalMiniprogram dalMiniprogram)
        {
            this.dalHomepageCarouselImage = dalHomepageCarouselImage;
            this.miniprogramService = miniprogramService;
            this.dalMiniprogram = dalMiniprogram;
        }

        /// <summary>
        /// 获取轮播图列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<HomepageCarouselImageDto>> GetListAsync(string appid=null)
        {
            try
            {
                var carouselImage = from d in dalHomepageCarouselImage.GetAll()
                                    where (appid == null ? true : d.AppId == appid)
                                    orderby d.DisplayIndex ascending
                                    select new HomepageCarouselImageDto
                                    {
                                        Id = d.Id,
                                        PicUrl = d.PicUrl,
                                        LinkUrl = d.LinkUrl,
                                        DisplayIndex = d.DisplayIndex,
                                        CreateDate = d.CreateDate,
                                        AppId = d.AppId,
                                        AppName = dalMiniprogram.GetAll().Where(e=>e.AppId==d.AppId).FirstOrDefault().Name ?? "未归属小程序"
                                    };
                return await carouselImage.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 添加轮播图
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddCarouselImageDto addDto)
        {
            try
            {
                var carouselImageCount = await dalHomepageCarouselImage.GetAll().CountAsync();


                HomepageCarouselImage carouselImage = new HomepageCarouselImage();
                carouselImage.PicUrl = addDto.PicUrl;
                if (carouselImageCount == 0)
                {
                    carouselImage.DisplayIndex = 0;
                }
                else
                {
                    carouselImage.DisplayIndex = (byte)carouselImageCount;
                }

                carouselImage.CreateDate = DateTime.Now;
                carouselImage.LinkUrl = addDto.LinkUrl;
                carouselImage.AppId = addDto.AppId;

                await dalHomepageCarouselImage.AddAsync(carouselImage, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 根据轮播图编号获取轮播图信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HomepageCarouselImageDto> GetByIdAsync(int id)
        {
            try
            {
                var carouselImage = await dalHomepageCarouselImage.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (carouselImage == null)
                    throw new Exception("轮播图编号错误");

                HomepageCarouselImageDto carouselImageDto = new HomepageCarouselImageDto();
                carouselImageDto.Id = carouselImage.Id;
                carouselImageDto.DisplayIndex = carouselImage.DisplayIndex;
                carouselImageDto.PicUrl = carouselImage.PicUrl;
                carouselImageDto.CreateDate = carouselImage.CreateDate;
                carouselImageDto.AppId = carouselImage.AppId;
                carouselImageDto.AppName = dalMiniprogram.GetAll().Where(e => e.AppId == carouselImage.AppId).FirstOrDefault().Name ?? "未归属小程序";
                carouselImageDto.LinkUrl = carouselImage.LinkUrl;
                return carouselImageDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        /// <summary>
        /// 修改轮播图
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateCarouselImageDto updateDto)
        {
            try
            {
                var carouselImage = await dalHomepageCarouselImage.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (carouselImage == null)
                    throw new Exception("轮播图编号错误");

                carouselImage.PicUrl = updateDto.PicUrl;
                carouselImage.DisplayIndex = updateDto.DisplayIndex;
                carouselImage.AppId = updateDto.AppId;
                await dalHomepageCarouselImage.UpdateAsync(carouselImage, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 删除轮播图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeletaAsync(int id)
        {
            try
            {
                var carouselImage = await dalHomepageCarouselImage.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (carouselImage == null)
                    throw new Exception("轮播图编号错误");

                await dalHomepageCarouselImage.DeleteAsync(carouselImage, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取小程序名称列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<BaseKeyValueDto>> GetMiniprogramNameListAsync()
        {
            var showDirectionTypes = Enum.GetValues(typeof(MiniprogramName));
            List<BaseKeyValueDto> requestTypeList = new List<BaseKeyValueDto>();
            foreach (var item in showDirectionTypes)
            {
                BaseKeyValueDto requestType = new BaseKeyValueDto();
                requestType.Value = ServiceClass.GetMiniprogramNameText(Convert.ToInt32(item));
                requestType.Key = ServiceClass.GetMiniprogramAppId(Convert.ToInt32(item));
                requestTypeList.Add(requestType);
            }
            return requestTypeList;
        }
    }
}
