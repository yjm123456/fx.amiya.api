using Fx.Amiya.Dto.GoodsConsumptionVoucher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IGoodsConsumptionVoucherService
    {
        /// <summary>
        /// 根据商品id获取商品可使用的抵用券列表
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        Task<List<GoodsConsumptionVoucherDto>> GetGoodsConsumptionVoucherByGoodsIdAsync(string goodsId);
        Task AddAsync(GoodsConsumptionVoucherAddDto goodsConsumptionVoucherAddDto);
        Task DeleteByGoodsIdAsync(string goodsId);
    }
}
