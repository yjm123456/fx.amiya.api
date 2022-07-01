using Fx.Amiya.Dto.OrderWriteOffIno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IOrderWriteOffInfoService
    {
        Task AddOrderWriteOffInfoAsync(OrderWriteOffInfoAddDto orderWriteOffInfo);
    }
}
