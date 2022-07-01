using Fx.Amiya.Dto.Activity;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IActivityService
    {
        /// <summary>
        /// 获取报价活动列表（分页）
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="activityName"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ActivityInfoDto>> GetInfoListWithPageAsync(DateTime? startDate, DateTime? endDate, string activityName, int? status, bool valid, int pageNum, int pageSize);



        /// <summary>
        /// 获取有效的活动信息列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ActivityInfoSimpleDto>> GetValidListAsync(int hospitalId,int pageNum, int pageSize);




        /// <summary>
        /// 添加报价活动信息
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task AddInfoAsync(AddActivityInfoDto addDto, int employeeId);


        /// <summary>
        /// 根据活动编号获取报价活动信息
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        Task<ActivityInfoDto> GetInfoByIdAsync(int activityId);


        /// <summary>
        /// 修改报价活动
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task UpdateInfoAsync(UpdateActivityInfoDto updateDto, int employeeId);


        /// <summary>
        /// 删除报价活动
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        Task DeleteInfoAsync(int activityId);


        /// <summary>
        /// 批量添加报价活动项目
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
     Task AddDetailAsync(AddActivityItemDetailDto addDto);




        /// <summary>
        /// 根据活动编号获取明细中已存在的项目编号集合
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
       Task<List<int>> GetAlreadyExistItemIdListByActivityId(int activityId);

        /// <summary>
        /// 根据活动编号报价活动项目列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="activityId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ActivityItemDetailDto>> GetDetailListByActivityIdWithPageAsync(string keyword, int activityId, int pageNum, int pageSize);


        /// <summary>
        /// 根据活动编号报价活动项目列表
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        Task<List<ActivityItemDetailDto>> GetDetailListByActivityIdAsync(int activityId);



        /// <summary>
        /// 根据医院编号获取医院参与的活动列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ActivityInfoDto>> GetListByHospitalIdAsync(int hospitalId, string keyword, int pageNum, int pageSize);



        /// <summary>
        /// 获取所有活动名称列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        Task<FxPageInfo<ActivityNameDto>> GetNameListAsync(string keyword, int pageNum, int pageSize);
    }
}
