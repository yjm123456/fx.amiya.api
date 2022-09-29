using Fx.Amiya.Dto.Doctor;
using Fx.Amiya.Dto.HospitalOperationIndicator;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHospitalOperationIndicatorService
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<HospitalOperationIndicatorDto>> GetListAsync(string keyword, bool? valid, int pageNum, int pageSize);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddHospitalOperationIndicatorDto addDto);



        /// <summary>
        /// 根据编号获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HospitalOperationIndicatorDto> GetByIdAsync(string id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateHospitalOperationIndicatorDto updateDto);

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);

        /// <summary>
        /// 数据库删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteDataAsync(string id);
        /// <summary>
        /// 获取指标名称列表
        /// </summary>
        /// <returns></returns>
        Task<List<IndicatorNameList>> GetIndicatorListAsync();
        /// <summary>
        /// 获取未提报/未批注的运营指标
        /// </summary>
        /// <returns></returns>
        Task<List<OperationIndicatorSubmitAndRemarkDto>> GetUnSumbitAndUnRemarkIndicatorAsync();
        /// <summary>
        /// 修改运营指标提报和批注状态
        /// </summary>
        /// <returns></returns>
        Task UpdateRemarkAndSubmitStatusAsync(UpdateSubmitAndRemarkStatus updateDto);

    }
}
