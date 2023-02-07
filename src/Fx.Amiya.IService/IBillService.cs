using Fx.Amiya.Dto;
using Fx.Amiya.Dto.Bill;
using Fx.Amiya.Dto.WareHouse.OutWareHouse;
using Fx.Amiya.Dto.WareHouse.WareHouseInfo;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IBillService
    {
        /// <summary>
        /// 根据条件获取发票信息
        /// </summary>
        /// <param name="keyWord">关键词（可搜索费用备注，开票事由）</param>
        /// <param name="hospitalId">客户id</param>
        /// <param name="billType">票据类型（医美/其他）</param>
        /// <param name="returnBackState"></param>
        /// <param name="companyId">回款状态（未回款/回款中/已回款）</param>
        /// <param name="valid">是否作废（1正常，0作废）</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<BillDto>> GetListAsync(int? hospitalId, bool? valid, int? billType, int? returnBackState, string companyId, string keyWord, int pageNum, int pageSize);
        Task AddAsync(AddBillDto addDto);
        Task<BillDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateBillDto updateDto);
        Task DeleteAsync(string id);
        /// <summary>
        /// 发票回款
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task ReturnBakcPriceAsync(BillReturnBackPriceDto updateDto);

        #region [枚举下拉框]
        /// <summary>
        /// 票据类型列表
        /// </summary>
        /// <returns></returns>
        Task<List<BaseKeyValueDto>> GetBillTypeListAsync();
        /// <summary>
        /// 票据回款状态列表
        /// </summary>
        /// <returns></returns>
        Task<List<BaseKeyValueDto>> GetBillReturnBackStateTextListAsync();
        #endregion
    }
}
