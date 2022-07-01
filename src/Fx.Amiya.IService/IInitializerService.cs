using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IInitializerService
    {
        /// <summary>
        /// 根据类型获取是否需要初始化
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<bool> GetIsInitializerByTypeAsync(byte type);

        
        /// <summary>
        /// 添加初始化类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        Task AddAsync(byte type);
    }
}
