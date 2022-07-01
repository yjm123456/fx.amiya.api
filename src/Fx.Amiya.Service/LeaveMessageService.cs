using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.LeaveMessage;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Infrastructure;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Fx.Common;

namespace Fx.Amiya.Service
{
    public class LeaveMessageService : ILeaveMessageService
    {
        private IDalLeaveMessage dalLeaveMessage;
        private IUnitOfWork unitOfWork;
        private ILogger<LeaveMessageService> logger;
        public LeaveMessageService(IDalLeaveMessage dalLeaveMessage,
            IUnitOfWork unitOfWork,
            ILogger<LeaveMessageService> logger)
        {
            this.dalLeaveMessage = dalLeaveMessage;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public async Task<FxPageInfo<LeaveMessageUserDto>> GetListWithPageAsync(int pageNum, int pageSize)
        {

            var leaveUser = from d in dalLeaveMessage.GetAll()
                            where d.Type == (byte)LeaveMessageType.LeaveMessage
                            group d by new { d.UserId, d.UserInfo.Avatar, d.UserInfo.NickName } into g
                            orderby g.Max(e => e.Date) descending
                            select new LeaveMessageUserDto
                            {
                                UserId = g.Key.UserId,
                                Avatar = g.Key.Avatar,
                                NickName = g.Key.NickName,
                            };


            var leaveUserList = await leaveUser.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

            List<string> userIds = new List<string>();
            foreach (var item in leaveUserList)
            {
                userIds.Add(item.UserId);
            }

            var leaveMessage = from d in dalLeaveMessage.GetAll()
                               where userIds.Contains(d.UserId)
                               select new LeaveMessageDto
                               {
                                   Id = d.Id,
                                   UserId = d.UserId,
                                   Date = d.Date,
                                   Content = d.Content,
                                   MsgType = d.MsgType,
                                   MsgId = d.MsgId,
                                   Type = d.Type,
                                   TypeText = d.Type == (byte)LeaveMessageType.LeaveMessage ? "留言" : "回复",
                                   IsReply = d.IsReply,
                                   EmployeeId = d.EmployeeId,
                                   EmployeeName = d.AmiyaEmployee.Name
                               };


            List<LeaveMessageDto> leaveMessageDtos = await leaveMessage.ToListAsync();

            foreach (var item in leaveUserList)
            {
                var leaveMessageDate = leaveMessageDtos.Where(e => e.UserId == item.UserId).GroupBy(e => e.Date.Date).Select(g => g.First()).ToList();

                item.LeaveMessageDateList = (from d in leaveMessageDate
                                             orderby d.Date
                                             select new LeaveMessageDateDto
                                             {
                                                 Date = d.Date,
                                                 LeaveMessageList = (from m in leaveMessageDtos.ToList()
                                                                     where m.Date.Date == d.Date.Date
                                                                     && m.UserId == item.UserId
                                                                     select new LeaveMessageDto
                                                                     {
                                                                         Id = m.Id,
                                                                         UserId = m.UserId,
                                                                         Date = m.Date,
                                                                         Content = m.Content,
                                                                         MsgId = m.MsgId,
                                                                         MsgType = m.MsgType,
                                                                         Type = m.Type,
                                                                         TypeText = m.TypeText,
                                                                         EmployeeId = m.EmployeeId,
                                                                         EmployeeName = m.EmployeeName,
                                                                         IsReply = m.IsReply,

                                                                     }).ToList()
                                             }).ToList();
            }

            FxPageInfo<LeaveMessageUserDto> pageInfo = new FxPageInfo<LeaveMessageUserDto>();
            pageInfo.TotalCount = await leaveUser.CountAsync();
            pageInfo.List = leaveUserList;

            return pageInfo;
        }


    }
}
