using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IControlPageShowService
    {
        /// <summary>
        /// 是否显示
        /// </summary>
        /// <returns></returns>
        Task<bool> IsShow();
    }
}
