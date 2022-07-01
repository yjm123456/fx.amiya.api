using Fx.Amiya.Dto.ExpressManage;
using Fx.Amiya.Dto.GoodsDemand;
using Fx.Amiya.Dto.HospitalInfo;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHospitalBrandApplyService
    {
        /// <summary>
        /// 获取医院品牌报名列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<HospitalBrandApplyDto>> GetListWithPageAsync(string keyword, int pageNum, int pageSize);



        /// <summary>
        /// 添加医院品牌报名
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddHospitalBrandApplyDto addDto);



        /// <summary>
        /// 根据医院品牌报名编号获取医院品牌报名信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<HospitalBrandApplyDto> GetByIdAsync(string id);

        /// <summary>
        /// 修改医院品牌报名信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateHospitalBrandApplyDto updateDto);

        /// <summary>
        /// 删除医院品牌报名信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);
        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>

        Task<List<ExportHospitalBrandApplyAndTmallGoodsDto>> GetDetailAsync(string keyword);
    }
}
