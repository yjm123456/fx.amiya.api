using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ITaskService
    {
        /// <summary>
        /// 完成签到任务
        /// </summary>
        /// <returns></returns>
        Task CompleteSignTask(string customerid);
    }
}
