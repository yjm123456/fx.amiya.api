using Fx.Amiya.Dto.HospitalPartakeItem;
using Fx.Amiya.Dto.ItemInfo;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHospitalPartakeItemService
    {
        /// <summary>
        /// 添加医院报价项目
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task AddAsync(AddHospitalPartakeItemDto addDto, int hospitalId);


        /// <summary>
        /// 根据活动编号获取医院参与的项目
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<HospitalPartakeItemDto>> GetListByActivityIdAsync(int hospitalId, int activityId, string keyword, int pageNum, int pageSize);




        /// <summary>
        /// 根据医院编号获取参与的报价项目编号集合
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<ItemSimpleListDto>> GetItemIdListByHospitalIdAsync(int hospitalId, int activityId);





        /// <summary>
        /// 根据项目编号获取参与的医院列表（分页）
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="itemId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<PartakeHospitalInfoDto>> GetHospitalListByItemIdWithPageAsync(int? activityId, int itemId, int pageNum, int pageSize);



        /// <summary>
        /// 根据项目编号获取参与的医院列表
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        Task<List<PartakeHospitalInfoDto>> GetHospitalListByItemIdAsync(int? activityId, int itemId);



        /// <summary>
        /// 根据医院编号获取参与的项目列表（分页）
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<PartakeItemInfoDto>> GetItemListByHospitalIdWithPageAsync(int? activityId, int hospitalId, int pageNum, int pageSize);


        /// <summary>
        /// 根据医院编号获取参与的项目列表（不分页）
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        Task<List<PartakeItemInfoDto>> GetItemListByHospitalIdAsync(int? activityId, int hospitalId);


        /// <summary>
        /// 根据城市和项目获取参与的医院列表（分页）
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="cityId"></param>
        /// <param name="itemId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
         Task<FxPageInfo<PartakeHospitalInfoDto>> GetHospitalListByCityWithPageAsync(int? activityId, int cityId, int itemId, int pageNum, int pageSize);

        /// <summary>
        /// 根据城市和项目获取参与的医院列表（不分页）
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="cityId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        Task<List<PartakeHospitalInfoDto>> GetHospitalListByCityAsync(int? activityId, int cityId, int itemId);
    }
}
