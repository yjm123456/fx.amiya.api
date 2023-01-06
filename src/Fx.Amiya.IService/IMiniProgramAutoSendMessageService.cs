using Fx.Amiya.Dto.MiniProgramAutoSendMessage;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IMiniProgramAutoSendMessageService
    {
        Task<MiniProgramAutoSendMessageDto> GetMiniProgramAutoSendMessageAsync();

        Task UpdateAsync(string message);
    }
}
