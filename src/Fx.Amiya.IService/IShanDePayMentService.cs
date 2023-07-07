using Fx.Amiya.Dto.ShanDePay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IShanDePayMentService
    {
        Task<ShanDeOrderResult> OrderAsync(ShanDeOrderInfo orderInfo);
    }
}
