using Fx.Amiya.Dto.CarouselImage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
   public interface ICarouselImageService
    {
        /// <summary>
        /// 获取轮播图列表
        /// </summary>
        /// <returns></returns>
        Task<List<HomepageCarouselImageDto>> GetListAsync();


        /// <summary>
        /// 添加轮播图
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddCarouselImageDto addDto);


        /// <summary>
        /// 根据轮播图编号获取轮播图信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HomepageCarouselImageDto> GetByIdAsync(int id);

        /// <summary>
        /// 修改轮播图
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
       Task UpdateAsync(UpdateCarouselImageDto updateDto);



        /// <summary>
        /// 删除轮播图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeletaAsync(int id);
    }
}
