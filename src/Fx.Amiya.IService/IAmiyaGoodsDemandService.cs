using Fx.Amiya.Dto.GoodsDemand;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IAmiyaGoodsDemandService
    {
        /// <summary>
        /// 获取商品需求列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<AmiyaGoodsDemandDto>> GetListWithPageAsync(string keyword, int pageNum, int pageSize);

        Task<List<AmiyaGoodsDemandKeyAndValueDto>> GetIdAndNames(string hospitalDepartmentId);


        /// <summary>
        /// 添加商品需求
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddAmiyaGoodsDemandDto addDto);

        Task<List<AmiyaGoodsDemandDto>> GetAll();

        /// <summary>
        /// 根据商品需求编号获取商品需求信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AmiyaGoodsDemandDto> GetByIdAsync(string id);

        /// <summary>
        /// 根据商品名称获取商品需求信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<AmiyaGoodsDemandDto> GetByNameAsync(string name);

        /// <summary>
        /// 修改商品需求信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateAmiyaGoodsDemandDto updateDto);

        /// <summary>
        /// 删除商品需求信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);
    }
}
