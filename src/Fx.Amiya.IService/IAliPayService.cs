using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    /// <summary>
    /// 支付宝相关接口
    /// </summary>
    public interface IAliPayService
    {
        Task<string> BuildRequest(SortedDictionary<string, string> input);

        Task<bool> Verify(SortedDictionary<string,string>inputparam,string notify_id,string sign);
    }
}
