using Fx.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Goods.Domin.IRepository
{
    public interface IGoodsCategoryRepository: IRepositoryBase<GoodsCategory,int>
    {
        Task<GoodsCategory> GetNearGoodsCategory(int Id,int showDirectionType,bool IsUp);
        Task<int> GetMaxOrMinSortByShowDirectionType(int directionType,bool IsMax);
        Task<GoodsCategory> GetGoodsCategoryBySimpleCode(string code);
    }
}
