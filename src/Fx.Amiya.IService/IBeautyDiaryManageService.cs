using Fx.Amiya.Dto.BeautyDiaryManage;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IBeautyDiaryManageService
    {


        /// <summary>
        /// 获取日记列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<BeautyDiaryManageDto>> GetListWithPageAsync(string keyword, int pageNum, int pageSize,bool? isReleased);
        /// <summary>
        /// 从微信公众号获取日记列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<WechatBeautyDiaryNewsItem>> GetSimpleListFromWechatAsync(string keyword, int pageNum, int pageSize);


        /// <summary>
        /// 添加日记
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddBeautyDiaryManageDto addDto);



        /// <summary>
        /// 根据日记编号获取日记基础信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BeautyDiaryManageDetailDto> GetDetailByIdAsync(string id);

        /// <summary>
        /// 根据日记名字获取日记基础信息
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        Task<BeautyDiaryManageDto> GetBaseByNameAsync(string Name);

        /// <summary>
        /// 修改日记信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateBeautyDiaryManageDto updateDto);

        /// <summary>
        /// 日记点赞
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task GivingLikesAsync(string id);

        /// <summary>
        /// 日记浏览量+1
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task AddViewsAsync(string id);

        /// <summary>
        /// 删除日记
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);


        /// <summary>
        /// 修改日记是否发布
        /// </summary>
        /// <param name="id"></param>
        /// <param name="releaseState"></param>
        /// <returns></returns>
        Task UpdateReleaseStateAsync(string id, bool releaseState);

        /// <summary>
        /// 获取日记列表（小程序）
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        Task<FxPageInfo<BeautyDiaryManageSimpleDto>> GetSimpleListAsync(string keyword, int pageNum, int pageSize);

     
        /// <summary>
        /// 根据标签，名称，城市等筛选获取日记列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="city"></param>
        /// <param name="hospitalName"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        //Task<FxPageInfo<WxBeautyDiaryManageDto>> GetListHosPitalAsync(int pageNum, int pageSize, string city,string hospitalName, List<string> tags);

        ///// <summary>
        ///// 根据商品编号获取参与项目的日记名称列表
        ///// </summary>
        ///// <param name="goodsId"></param>
        ///// <param name="name">日记名称，null：全部</param>
        ///// <returns></returns>
        //Task<List<HospitalNameDto>> GetPartakeItemHospitalNameListAsync(string goodsId,string name);
    }
}
