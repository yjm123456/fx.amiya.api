using Fx.Amiya.Dto;
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
        /// <param name="code">抵用券编码</param>
        /// <returns></returns>
        Task<ConsumptionVoucherDto> GetConsumptionVoucherByCodeAsync(string code);
        /// <summary>
        /// 获取抵用券名称列表
        /// </summary>
        /// <returns></returns>
        Task<List<ConsumptionVoucherDto>> GetConsumptionVoucherkNameListAsync();
        /// <summary>
        /// 获取抵用券类型列表
        /// </summary>
        /// <returns></returns>
        Task<List<BaseKeyValueDto>> GetConsumptionVoucherTypeListAsync();
        /// <summary>
        /// 获取抵用券信息列表
        /// </summary>
        /// <returns></returns>
        Task<FxPageInfo<ConsumptionVoucherDto>> GetConsumptionListAsync(int pageNum,int pageSize);
        /// <summary>
        /// 根据抵用券id获取抵用券信息
        /// </summary>
        /// <returns></returns>
        Task<ConsumptionVoucherDto> GetConsumptionVoucherInfoByIdAsync(string voucherId);
        /// <summary>
        /// 修改抵用券信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateConsumptionVoucherAsync(UpdateConsumptionVoucherDto updateDto);
    }
}
