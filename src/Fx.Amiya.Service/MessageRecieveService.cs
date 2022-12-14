using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.MessageRecieve;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class MessageRecieveService : IMessageRecieveService
    {
        private readonly IDalMessageRecieve dalMessageRecieve;

        public MessageRecieveService(IDalMessageRecieve dalMessageRecieve)
        {
            this.dalMessageRecieve = dalMessageRecieve;
        }

        public async Task<MessageRecieveDto> AddInfo(AddMessageRecieveDto addMessageRecieveDto)
        {
            MessageRecieve messageRecieve = new MessageRecieve();
            messageRecieve.Id = Guid.NewGuid().ToString().Replace("-", "");
            messageRecieve.IsBindWechat = false;
            messageRecieve.IsBindOfficialAccounts = false;
            messageRecieve.HospitalId = addMessageRecieveDto.HospitalId;
            messageRecieve.HospitalEmployeeId = addMessageRecieveDto.HospitalEmployeeId;
            messageRecieve.IsReceive = addMessageRecieveDto.IsReceive;
            messageRecieve.StartTime = addMessageRecieveDto.StartTime;
            messageRecieve.EndTime = addMessageRecieveDto.EndTime;
            messageRecieve.CreateDate = DateTime.Now;
            messageRecieve.Valid = true;
            await dalMessageRecieve.AddAsync(messageRecieve,true);
            MessageRecieveDto messageRecieveDto = new MessageRecieveDto();
            messageRecieveDto.Id = messageRecieve.Id;
            messageRecieveDto.IsReceive = messageRecieve.IsReceive;
            messageRecieveDto.StartTime = messageRecieve.StartTime;
            messageRecieveDto.EndTime = messageRecieve.EndTime;
            return messageRecieveDto;
        }

        public async Task<MessageRecieveDto> GetInfo(int hospitalId,int hospitalEmployeeId)
        {
            var record= await dalMessageRecieve.GetAll().Where(e => e.HospitalId == hospitalId && e.HospitalEmployeeId == hospitalEmployeeId).Select(e=>new MessageRecieveDto { 
                Id=e.Id,
                IsReceive=e.IsReceive,
                StartTime=e.StartTime,
                EndTime=e.EndTime
            }).FirstOrDefaultAsync();
            if (record == null)
            {
                AddMessageRecieveDto addMessageRecieveDto = new AddMessageRecieveDto();
                addMessageRecieveDto.HospitalId = hospitalId;
                addMessageRecieveDto.HospitalEmployeeId = hospitalEmployeeId;
                addMessageRecieveDto.IsReceive = true;
                addMessageRecieveDto.StartTime = "00:00";
                addMessageRecieveDto.EndTime = "23:59";
                var messageRecieveDto = await AddInfo(addMessageRecieveDto);
                return messageRecieveDto;
            }
            else {
                return record;
            }
        }

        public async Task UpdateInfo(UpdateMessageRecieveDto updateMessageRecieveDto)
        {
            var record = dalMessageRecieve.GetAll().Where(e => e.Id == updateMessageRecieveDto.Id).FirstOrDefault();
            if (record == null)
            {
                throw new Exception("编号错误");
            }
            record.IsReceive = updateMessageRecieveDto.IsReceive;
            record.StartTime = updateMessageRecieveDto.StartTime;
            record.EndTime= updateMessageRecieveDto.EndTime;
            record.UpdateDate = DateTime.Now;
            await dalMessageRecieve.UpdateAsync(record,true);
        }
    }
}
