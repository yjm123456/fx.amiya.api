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
    public interface IBillReturnBackPriceDataService
    {
        /// <summary>
        /// 根据条件获取发票回款记录信息
        /// </summary>
        /// <param name="startDate">回款时间（起）</param>
        /// <param name="endDate">回款时间（止）</param>
        /// <param name="keyWord">关键词（支持模糊搜索票据单，备注）</param>
        /// <param name="hospitalId">客户id</param>
        /// <param name="returnBackState">回款状态（未回款/回款中/已回款）</param>
        /// <param name="companyId">收款公司id</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>

        Task<FxPageInfo<BillReturnBackPriceDataDto>> GetListAsync(DateTime? startDate, DateTime? endDate, int? hospitalId, int? returnBackState, string companyId, string keyWord, int pageNum, int pageSize);
        /// <summary>
        /// 根据条件导出发票回款记录信息
        /// </summary>
        /// <param name="startDate">回款时间（起）</param>
        /// <param name="endDate">回款时间（止）</param>
        /// <param name="keyWord">关键词（支持模糊搜索票据单，备注）</param>
        /// <param name="hospitalId">客户id</param>
        /// <param name="returnBackState">回款状态（未回款/回款中/已回款）</param>
        /// <param name="companyId">收款公司id</param>
        /// <returns></returns>
        Task<List<BillReturnBackPriceDataDto>> ExportListAsync(DateTime? startDate, DateTime? endDate, int? hospitalId, int? returnBackState, string companyId, string keyWord);

        /// <summary>
        /// 添加发票回款记录
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddAsync(AddBillReturnBackPriceDataDto addDto);
    }
}
