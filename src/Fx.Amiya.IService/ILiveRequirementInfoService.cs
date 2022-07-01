using Fx.Amiya.Dto.LiveRequirementInfo;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ILiveRequirementInfoService
    {
        /// <summary>
        /// 获取总览数据
        /// </summary>
        /// <returns></returns>
        Task<HeadCollectivityDataDto> GetHeadCollectivityDataAsync(int employeeId);

        /// <summary>
        /// 获取直播需求信息列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="status"></param>
        /// <param name="liveTypeId"></param>
        /// <param name="keyword"></param>
        /// <param name="fansInfo">粉丝信息</param>
        /// <returns></returns>
        Task<FxPageInfo<LiveRequirementInfoDto>> GetListWithPageAsync(int pageNum, int pageSize, byte? status, byte? liveTypeId, string keyword,string fansInfo);

        /// <summary>
        /// 根据主播id获取需求列表
        /// </summary>
        /// <param name="liveAnchorId"></param>
        /// <returns></returns>
        Task<List<LiveRequirementInfoDto>> GetByLiveAnchorIdAsync(int liveAnchorId);

        /// <summary>
        /// 添加直播需求
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddLiveRequirementInfoDto addDto, int employeeId);




        /// <summary>
        /// 修改需求信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
       Task UpdateAsync(UpdateLiveRequirementInfoDto updateDto);

        /// <summary>
        /// 获取待响应的需求列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        Task<FxPageInfo<UnResponseLiveRequirementInfoDto>> GetUnResponseRequirementListAsync(int pageNum, int pageSize, int departmentId);



        /// <summary>
        /// 获取部门已拒绝的需求
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<LiveRequirementInfoDto>> GetRefuseRequirementListAsync(int pageNum, int pageSize);


        /// <summary>
        /// 获取未处理的需求
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        Task<FxPageInfo<LiveRequirementInfoDto>> GetUnTreatedRequirementListAsync(int pageNum, int pageSize, int departmentId);


        /// <summary>
        /// 部门响应直播需求
        /// </summary>
        /// <param name="responseRequirementDto"></param>
        /// <returns></returns>
        Task ResponseRequirementAsync(ResponseRequirementDto responseRequirementDto,int departmentId, int employeeId);


        /// <summary>
        /// 评判直播需求
        /// </summary>
        /// <param name="decideRequirementDto"></param>
        /// <returns></returns>
        Task DecideRequirementAsync(DecideRequirementDto decideRequirementDto,int employeeId);


        /// <summary>
        /// 执行需求
        /// </summary>
        /// <param name="executeDto"></param>
        /// <returns></returns>
        Task ExecuteAsync(ExecuteLiveRequirementInfoDto executeDto,int employeeId);

        /// <summary>
        /// 确定执行完成
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task ConfirmFinishAsync(int id);


        /// <summary>
        /// 获取进度
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProgressBarDto> GetProgressBarAsync(int id);


        /// <summary>
        /// 获取未确认完成的需求列表
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<UnConfirmLiveRequirementInfoDto>> GetUnConfirmFinishListAsync(int employeeId, int pageNum, int pageSize);
    }
}
