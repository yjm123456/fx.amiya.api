using Fx.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Goods.Domin.IRepository
{
   public interface IGoodsInfoRepository: IRepositoryBase<GoodsInfo, string>
    {
        /// <summary>
        /// 根据简码获取商品信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<GoodsInfo> GetGoodsByCode(string code);
    }
}
