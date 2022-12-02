using Fx.Amiya.Dto.CheckBaseInfo;
using Fx.Amiya.Dto.ContentPlatform;
using Fx.Amiya.Dto.CustomerConsumptionCredentials;
using Fx.Amiya.Dto.Province;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ICustomerConsumptionCredentialsService
    {
        /// <summary>
        /// 获取列表（分页）系统端
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<CustomerConsumptionCredentialsDto>> GetListAsync(string keyWord, bool valid, int? checkState, int pageNum, int pageSize);

        /// <summary>
        ///  获取列表（分页）小程序端
        /// </summary>
        /// <returns></returns>
        Task<FxPageInfo<CustomerConsumptionCredentialsDto>> GetByCustomerIdListAsync(string customerId, int pageNum, int pageSize);

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        Task AddAsync(AddCustomerConsumptionCredentialsDto addDto);

        /// <summary>
        /// 根据编号获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
          Task<CustomerConsumptionCredentialsDto> GetByIdAsync(string id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateCustomerConsumptionCredentialsDto updateDto);

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task CheckAsync(CheckInfoDto updateDto);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);
    }
}
