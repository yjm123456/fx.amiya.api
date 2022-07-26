using Fx.Amiya.Dto.Track;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ITrackService
    {
        /// <summary>
        /// 获取回访类型列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<TrackTypeDto>> GetTrackTypeListWithPageAsync(int pageNum, int pageSize);



        /// <summary>
        /// 获取有效的回访类型列表
        /// </summary>
        /// <returns></returns>
        Task<List<TrackTypeDto>> GetTrackTypeListAsync();


        /// <summary>
        /// 添加回访类型
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddTrackTypeAsync(AddTrackTypeDto addDto);


        /// <summary>
        /// 根据id获取回访类型
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<TrackTypeDto> GetbyIdAsync(int Id);

        /// <summary>
        /// 修改回访类型
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateTrackTypeAsync(UpdateTrackTypeDto updateDto);


        /// <summary>
        /// 删除回访类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteTrackTypeAsync(int id);



        /// <summary>
        /// 获取回访工具列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<TrackToolDto>> GetTrackToolListWithPageAsync(int pageNum, int pageSize);


        /// <summary>
        /// 获取有效的回访工具列表
        /// </summary>
        /// <returns></returns>
        Task<List<TrackToolDto>> GetTrackToolListAsync();


        /// <summary>
        /// 添加回访工具
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddTrackToolAsync(AddTrackToolDto addDto);


        /// <summary>
        /// 修改回访工具
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateTrackToolAsync(UpdateTrackToolDto updateDto);


        /// <summary>
        /// 删除回访工具
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteTrackToolAsync(int id);






        /// <summary>
        ///  获取回访记录（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<TrackRecordDto>> GetRecordListWithPageAsync(string keyword, DateTime? startDate, DateTime? endDate, int employeeId, int pageNum, int pageSize);



        /// <summary>
        /// 根据加密电话号获取回访记录列表（分页）
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<TrackRecordDto>> GetRecordListByEncryptPhoneWithPageAsync(string phone, int pageNum, int pageSize);




        /// <summary>
        /// 添加回访记录
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<int> AddTrackRecordAsync(AddTrackRecordDto addDto, int employeeId);





        /// <summary>
        /// 获取待回访列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<WaitTrackCustomerDto>> GetWaitTrackListWithPageAsync(string keyword, DateTime? startDate, DateTime? endDate, int employeeId,int pageNum, int pageSize);


    }
}
