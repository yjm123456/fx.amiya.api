using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.Core.Dto.GoodsHospitalPrice;
using Fx.Amiya.Core.Dto.OrderWriteOff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Interfaces.OrderWriteOff
{
    public interface IOrderWriteOff
    {
        Task AddAsync(OrderWriteOffAddDto goodsInfoAdd);
    }
}
