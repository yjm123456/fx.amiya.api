using Fx.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Integration.Domin.IRepository
{
    public interface IIntegrationAccountRepository
    {
        Task<IntegrationAccount> GetIntegrationAccountAsync(string customerId);
        Task SaveIntegrationAccountAsync(IntegrationAccount integrationAccount);
        /// <summary>
        /// 获取所有有几分的客户id
        /// </summary>
        /// <returns></returns>
        Task<List<string>> GetAllIntegrationAccountAsync();
    }
}
