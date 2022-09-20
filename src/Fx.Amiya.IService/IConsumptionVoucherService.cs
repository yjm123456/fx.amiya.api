using Fx.Amiya.Dto.ConsumptionVoucher;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IConsumptionVoucherService
    {
        /// <summary>
        /// 添加新抵用券
        /// </summary>
        /// <param name="addConsumptionVoucher"></param>
        /// <returns></returns>
        Task AddAsync(AddConsumptionVoucherDto addConsumptionVoucher);
        /// <summary>
        /// 根据抵用券编码获取抵用券信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<ConsumptionVoucherDto> GetConsumptionVoucherByCodeAsync(string code);
        /// <summary>
        /// 获取抵用券名称列表
        /// </summary>
        /// <returns></returns>
        Task<List<ConsumptionVoucherDto>> GetConsumptionVoucherkNameListAsync();   
    }
}
