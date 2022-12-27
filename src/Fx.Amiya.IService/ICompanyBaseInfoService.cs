using Fx.Amiya.Dto;
using Fx.Amiya.Dto.CompanyBaseInfo;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ICompanyBaseInfoService
    {
        Task AddAsync(AddCompanyBaseInfoDto addCompanyBaseInfoDto);
        Task UpdateAsync(UpdateCompanyBaseInfoDto updateCompanyBaseInfoDto);
        Task<FxPageInfo<CompanyBaseInfoDto>> GetListWithPageAsync(string keyword,int pageNum,int pageSize);
        /// <summary>
        /// 获取公司名称列表
        /// </summary>
        /// <returns></returns>
        Task<List<BaseKeyValueDto>> GetCompanyNameListAsync();
        /// <summary>
        /// 根据id获取公司信息
        /// </summary>
        /// <returns></returns>
        Task<CompanyBaseInfoDto> GetByIdAsync(string id);
        /// <summary>
        /// 删除公司信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);
    }
}
