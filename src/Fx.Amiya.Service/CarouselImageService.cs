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

namespace Fx.Amiya.Service
{
    public class CarouselImageService : ICarouselImageService
    {
        private IDalHomepageCarouselImage dalHomepageCarouselImage;
        public CarouselImageService(IDalHomepageCarouselImage dalHomepageCarouselImage)
        {
            this.dalHomepageCarouselImage = dalHomepageCarouselImage;
        }

        /// <summary>
        /// 获取轮播图列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<HomepageCarouselImageDto>> GetListAsync()
        {
            try
            {
                var carouselImage = from d in dalHomepageCarouselImage.GetAll()
                                    select new HomepageCarouselImageDto
                                    {
                                        Id = d.Id,
                                        PicUrl = d.PicUrl,
                                        DisplayIndex = d.DisplayIndex,
                                        CreateDate = d.CreateDate
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
    }
}
