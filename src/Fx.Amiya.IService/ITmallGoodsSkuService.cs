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
    public interface ITmallGoodsSkuService
    {
        /// <summary>
        /// 获取医院品牌报名列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<TmallGoodsSkuDto>> GetListWithPageAsync(string keyword, string hospitalName, int pageNum, int pageSize);

        Task<List<TmallGoodsSkuDto>> GetAllAsync();

        /// <summary>
        /// 添加医院品牌报名
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddTmallGoodsSkuDto addDto);



        /// <summary>
        /// 根据医院品牌报名编号获取天猫商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TmallGoodsSkuDto> GetByIdAsync(string id);

        /// <summary>
        /// 修改天猫商品
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateTmallGoodsSkuDto updateDto);

        /// <summary>
        /// 删除天猫商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);

        Task DeleteBySkuIdAndHospitalNameAsync(string SKUId,string hospitalName);
    }
}
