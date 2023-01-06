
using Fx.Amiya.Dto.MiniProgramAutoSendMessage;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class MiniProgramAutoSendMessageService: IMiniProgramAutoSendMessageService
    {
        private IDalMiniProgramAutoSendMessage _dalMiniProgramAutoSendMessage;
        public MiniProgramAutoSendMessageService(IDalMiniProgramAutoSendMessage dalMiniProgramAutoSendMessage)
        {
            _dalMiniProgramAutoSendMessage = dalMiniProgramAutoSendMessage;
        }

        public async Task<MiniProgramAutoSendMessageDto> GetMiniProgramAutoSendMessageAsync()
        {
            var miniProgramAutoSendMessage = await _dalMiniProgramAutoSendMessage.GetAll().FirstOrDefaultAsync();
            if (miniProgramAutoSendMessage == null)
                throw new Exception("留言数据不存在！");
            MiniProgramAutoSendMessageDto miniProgramAutoSendMessageDto = new MiniProgramAutoSendMessageDto()
            {
                Id = miniProgramAutoSendMessage.Id,
                Message = miniProgramAutoSendMessage.Message,
            };
            return miniProgramAutoSendMessageDto;
        }

        public async Task UpdateAsync(string  message)
        {
            var result = await _dalMiniProgramAutoSendMessage.GetAll().FirstOrDefaultAsync();
            if (result == null)
                throw new Exception("留言数据不存在");
            result.Message = message;
            await _dalMiniProgramAutoSendMessage.UpdateAsync(result, true);
        }


    }
}
