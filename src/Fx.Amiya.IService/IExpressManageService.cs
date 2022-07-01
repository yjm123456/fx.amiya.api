using Fx.Amiya.Dto.ExpressManage;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IExpressManageService
    {
        /// <summary>
        /// 获取物流公司列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ExpressDto>> GetListWithPageAsync(string keyword, int pageNum, int pageSize);

        Task<List<ExpressKeyAndValueDto>> GetIdAndNames();


        /// <summary>
        /// 添加物流公司
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddExpressDto addDto);



        /// <summary>
        /// 根据物流公司编号获取物流公司信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ExpressDto> GetByIdAsync(string id);

        /// <summary>
        /// 修改物流公司信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateExpressDto updateDto);

        /// <summary>
        /// 删除物流公司信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);
    }
}
