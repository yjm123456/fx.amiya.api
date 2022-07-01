using Fx.Amiya.Dto.RecommendHospital;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IRecommendHospitalService
    {
        /// <summary>
        /// 获取推荐医院列表
        /// </summary>
        /// <param name="hospitalName"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<RecommendHospitalInfoDto>> GetListWithPageAsync(string hospitalName, DateTime? startDate, DateTime? endDate, int pageNum, int pageSize);



        /// <summary>
        /// 添加推荐医院
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task AddAsync(AddRecommendHospitalInfoDto addDto, int employeeId);



        /// <summary>
        /// 根据编号获取医院推荐信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RecommendHospitalInfoDto> GetByIdAsync(int id);



        /// <summary>
        /// 修改医院推荐信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateRecommendHospitalInfoDto updateDto,int employeeId);



        /// <summary>
        /// 删除医院推荐信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
