using Fx.Amiya.Dto.WxEventResponseSetting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IWxEventResponseSettingService
    {
        /// <summary>
        /// 根据微信事件类型获取回复消息
        /// </summary>
        /// <param name="eventType">1=首次关注，2=再次关注</param>
        /// <returns></returns>
        Task<WxEventResponseSettingDto> GetEventResponseByEventTypeAsync(byte eventType);


        /// <summary>
        /// 获取微信事件回复消息列表
        /// </summary>
        /// <param name="title">标题，可空</param>
        /// <param name="eventType">事件类型：1=首次关注，2=再次关注，可空</param>
        /// <param name="rspMsgType">消息类型：1=文本消息，2=图文消息，可空</param>
        /// <returns></returns>
        Task<List<WxEventResponseSettingDto>> GetWxEventRspMsgListAsync(string title, byte? eventType, byte? rspMsgType);



        /// <summary>
        /// 根据编号获取回复消息信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<WxEventResponseSettingXmlDeserializeDto> GetByIdAsync(int id);


        /// <summary>
        /// 添加事件回复消息
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task AddWxEventRspMsgAsync(AddWxEventResponseSettingDto addDto);


        /// <summary>
        /// 修改事件回复消息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        Task UpdateWxEventRspMsgAsync(UpdateWxEventResponseSettingDto updateDto);

    }
}
