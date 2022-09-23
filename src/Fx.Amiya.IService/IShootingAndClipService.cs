using Fx.Amiya.Dto;
using Fx.Amiya.Dto.ShootingAndClip;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IShootingAndClipService
    {
        /// <summary>
        /// 获取拍剪组数据列表（分页）
        /// </summary>
        /// <param name="shootingEmpId">拍摄人员id</param>
        /// <param name="clipEmpId">剪辑人员id</param>
        /// <param name="liveAnchorId">主播id</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ShootingAndClipDto>> GetListWithPageAsync(int? shootingEmpId, int? clipEmpId, int? liveAnchorId, string keyWord, int pageNum, int pageSize);

        /// <summary>
        /// 获取拍剪组数据列表（报表）
        /// </summary>
        /// <param name="shootingEmpId">拍摄人员id</param>
        /// <param name="clipEmpId">剪辑人员id</param>
        /// <param name="liveAnchorId">主播id</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<List<ShootingAndClipDto>> GetReportListAsync(DateTime? startDate, DateTime? endDate, int? shootingEmpId, int? clipEmpId, int? liveAnchorId);

        /// <summary>
        /// 添加拍剪组数据
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddShootingAndClipDto addDto);

        /// <summary>
        /// 根据拍剪组数据编号获取拍剪组数据信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ShootingAndClipDto> GetByIdAsync(string id);

        /// <summary>
        /// 修改拍剪组数据信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateShootingAndClipDto updateDto);

        /// <summary>
        /// 删除拍剪组数据信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);

        List<BaseIdAndNameDto> GetVideoTypeTextList();
    }
}
