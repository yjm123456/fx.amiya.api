using Fx.Amiya.Dto.Province;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IProvinceService
    {
        /// <summary>
        /// 获取省份列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<ProvinceDto>> GetListWithPageAsync(int pageNum, int pageSize);


        /// <summary>
        /// 获取省份列表
        /// </summary>
        /// <returns></returns>
        Task<List<ProvinceDto>> GetListAsync(string name, bool? valid);



        /// <summary>
        /// 获取有效的省份列表
        /// </summary>
        /// <returns></returns>
        Task<List<ProvinceDto>> GetValidListAsync();


        /// <summary>
        /// 添加省份
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddProvinceDto addDto);



        /// <summary>
        /// 根据编号获取省份
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProvinceDto> GetByIdAsync(string id);

        /// <summary>
        /// 修改合作城市
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateProvinceDto updateDto);



        /// <summary>
        /// 删除省份
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);
    }
}
