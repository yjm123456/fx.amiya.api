using Fx.Amiya.Dto;
using Fx.Amiya.Dto.CustomerTagInfo;
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ICustomerTagInfoService
    {
        Task<FxPageInfo<CustomerTagInfoDto>> GetListWithPageAsync(string keyword, int pageNum, int pageSize);
        Task AddAsync(AddCustomerTagInfoDto addDto);
        Task<CustomerTagInfoDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateCustomerTagInfoDto updateDto);
        Task DeleteAsync(string id);
        /// <summary>
        /// 获取分类标签名称
        /// </summary>
        /// <returns></returns>
        Task<List<BaseKeyValueDto>> GetTagCategoryNameListAsync();
        /// <summary>
        /// 获取用户标签名称列表
        /// </summary>
        /// <returns></returns>
        Task<List<BaseKeyValueDto>> GetCustomerTagNameList();

    }
}
