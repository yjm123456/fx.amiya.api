using Fx.Amiya.Dto.AmiyaHospitalDepartment;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAmiyaHospitalDepartmentService
    {
        /// <summary>
        /// 获取医院科室列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<AmiyaHospitalDepartmentDto>> GetListWithPageAsync(string keyword);

        Task<List<AmiyaHospitalDepartmentKeyAndValueDto>> GetIdAndNames();


        /// <summary>
        /// 添加医院科室
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddAmiyaHospitalDepartmentDto addDto);

        /// <summary>
        /// 移动医院科室
        /// </summary>
        /// <param name="goodsCategoryUpdate"></param>
        /// <returns></returns>
        Task MoveAsync(AmiyaHospitalDepartmentMoveDto goodsCategoryMove);

        /// <summary>
        /// 置顶/底医院科室
        /// </summary>
        /// <param name="goodsCategoryMove"></param>
        /// <returns></returns>
        Task MoveTopOrDownAsync(AmiyaHospitalDepartmentMoveDto goodsCategoryMove);

        /// <summary>
        /// 根据医院科室编号获取医院科室信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AmiyaHospitalDepartmentDto> GetByIdAsync(string id);

        /// <summary>
        /// 修改医院科室信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateAmiyaHospitalDepartmentDto updateDto);

        /// <summary>
        /// 删除医院科室信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);
    }
}
