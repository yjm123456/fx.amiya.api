using Fx.Amiya.Dto.MiniProgramSendMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IMiniProgramTemplateMessageSendService
    {
        /// <summary>
        /// 发送发放抵用券相关消息
        /// </summary>
        /// <returns></returns>
        Task SendVoucherMessageAsync(SendVoucherMessageDto sendVoucherMessageDto);
        /// <summary>
        /// 发送预约状态变更消息
        /// </summary>
        /// <returns></returns>
        Task SendAppointmentMessageAsync(SendAppointmentMessageDto sendAppointmentMessageDto);
        /// <summary>
        /// 发送积分变更消息
        /// </summary>
        /// <returns></returns>
        Task SendPointChangeMessgaeAsync(SendPointMessageDto sendPointMessageDto);
        /// <summary>
        /// 发送赠送礼品消息
        /// </summary>
        /// <param name="sendGiftPresentMessage"></param>
        /// <returns></returns>
        Task SendGiftPresentMessageAsync(SendGiftPresentMessageDto sendGiftPresentMessage);
    }
}
