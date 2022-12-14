using Fx.Amiya.Dto.MessageRecieve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    /// <summary>
    /// 医院接收信息设置
    /// </summary>
    public interface IMessageRecieveService
    {
        /// <summary>
        /// 获取消息接收信息
        /// </summary>
        /// <returns></returns>
        Task<MessageRecieveDto> GetInfo(int hospitalId, int hospitalEmployeeId);
        /// <summary>
        /// 修改消息接收信息
        /// </summary>
        /// <returns></returns>
        Task UpdateInfo(UpdateMessageRecieveDto updateMessageRecieveDto);
        /// <summary>
        /// 添加消息接收信息
        /// </summary>
        /// <param name="addMessageRecieveDto"></param>
        /// <returns></returns>
        Task<MessageRecieveDto> AddInfo(AddMessageRecieveDto addMessageRecieveDto);
    }
}
