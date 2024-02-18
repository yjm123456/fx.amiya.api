using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Infrastructure.DataAccess;
using Fx.Amiya.Dto.MessageNotice.Result;
using Fx.Amiya.Dto.MessageNotice.Input;
using Fx.Amiya.Dto;

namespace Fx.Amiya.Service
{
    public class MessageNoticeService : IMessageNoticeService
    {
        private IDalMessageNotice dalMessageNoticeService;
        private IInventoryListService inventoryListService;
        private IUnitOfWork unitOfWork;
        private IAmiyaOutWareHouseService amiyaOutWareHouseService;
        private IAmiyaInWareHouseService amiyaInWareHouseService;
        private IDalTagDetailInfo dalTagDetailInfo;
        public MessageNoticeService(IDalMessageNotice dalMessageNoticeService,
            IInventoryListService inventoryListService,
            IAmiyaInWareHouseService inWareHouseService,
            IAmiyaOutWareHouseService amiyaOutWareHouseService,
            IUnitOfWork unitofWork, IDalTagDetailInfo dalTagDetailInfo)
        {
            this.dalMessageNoticeService = dalMessageNoticeService;
            this.inventoryListService = inventoryListService;
            this.amiyaOutWareHouseService = amiyaOutWareHouseService;
            this.amiyaInWareHouseService = inWareHouseService;
            this.unitOfWork = unitofWork;
            this.dalTagDetailInfo = dalTagDetailInfo;
        }



        public async Task<List<MessageNoticeDto>> GetListAsync(QueryMessageNoticeDto query)
        {
            try
            {
                var messageNoticeService = from d in dalMessageNoticeService.GetAll().Include(x => x.AmiyaEmployeeInfo)
                                           where (!query.AcceptBy.HasValue || d.AcceptBy == query.AcceptBy.Value)
                                           && (!query.NoticeType.HasValue || d.NoticeType == query.NoticeType.Value)
                                           && (!query.StartDate.HasValue || d.CreateDate >= query.StartDate.Value)
                                           && (!query.EndDate.HasValue || d.CreateDate <= query.EndDate.Value.AddDays(1).AddMilliseconds(-1))
                                           && (d.Valid == true)
                                           select new MessageNoticeDto
                                           {
                                               Id = d.Id,
                                               AcceptBy = d.AcceptBy,
                                               CreateDate = d.CreateDate,
                                               UpdateDate = d.UpdateDate,
                                               DeleteDate = d.DeleteDate,
                                               Valid = d.Valid,
                                               IsRead = d.IsRead,
                                               NoticeType = d.NoticeType,
                                               OrderId = d.NoticeType == (int)MessageNoticeMessageTextEnum.OrderNotice ? d.NoticeContent.Substring(5, 16) : "",
                                               NoticeTypeText = ServiceClass.GetNoticeTypeText(d.NoticeType),
                                               NoticeContent = d.NoticeContent,
                                               AcceptByEmpName = d.AmiyaEmployeeInfo.Name,
                                           };
                List<MessageNoticeDto> messageNoticeServicePageInfo = new List<MessageNoticeDto>();
                messageNoticeServicePageInfo = await messageNoticeService.OrderByDescending(x => x.CreateDate).ToListAsync();
                return messageNoticeServicePageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<List<MessageNoticeDto>> GetBannerListAsync(QueryMessageNoticeDto query)
        {
            try
            {
                var messageNoticeService = from d in dalMessageNoticeService.GetAll().Include(x => x.AmiyaEmployeeInfo)
                                           where (!query.NoticeType.HasValue || d.NoticeType == query.NoticeType.Value)
                                           && (!query.StartDate.HasValue || d.CreateDate >= query.StartDate.Value)
                                           && (!query.EndDate.HasValue || d.CreateDate <= query.EndDate.Value.AddDays(1).AddMilliseconds(-1))
                                           && (d.Valid == true)
                                           select new MessageNoticeDto
                                           {
                                               Id = d.Id,
                                               NoticeTypeText = ServiceClass.GetNoticeTypeText(d.NoticeType),
                                               NoticeContent = d.NoticeContent,
                                               CreateDate = d.CreateDate
                                           };
                List<MessageNoticeDto> messageNoticeServicePageInfo = new List<MessageNoticeDto>();
                messageNoticeServicePageInfo = await messageNoticeService.OrderByDescending(x => x.CreateDate).ToListAsync();
                return messageNoticeServicePageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<int> GetMyUnReadAsync(int employeeId)
        {
            try
            {
                var messageNoticeService = from d in dalMessageNoticeService.GetAll().Include(x => x.AmiyaEmployeeInfo)
                                           where (d.AcceptBy == employeeId && d.IsRead == false)
                                           && (d.Valid == true)
                                           select d;
                int result = await messageNoticeService.CountAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }




        public async Task AddAsync(AddMessageNoticeDto addDto)
        {
            try
            {
                MessageNotice messageNoticeService = new MessageNotice();
                messageNoticeService.Id = Guid.NewGuid().ToString();
                messageNoticeService.AcceptBy = addDto.AcceptBy;
                messageNoticeService.NoticeType = addDto.NoticeType;
                messageNoticeService.NoticeContent = addDto.NoticeContent;
                messageNoticeService.IsRead = false;
                messageNoticeService.Valid = true;
                messageNoticeService.CreateDate = DateTime.Now;

                await dalMessageNoticeService.AddAsync(messageNoticeService, true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task UpdateToReadAsync(UpdateMessageNoticeToReadDto updateDto)
        {
            try
            {
                var messageNoticeService = await dalMessageNoticeService.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (messageNoticeService == null)
                    throw new Exception("客户预约日程编号错误！");
                if (messageNoticeService.AcceptBy == updateDto.EmployeeId)
                {
                    messageNoticeService.IsRead = true;
                    messageNoticeService.UpdateDate = DateTime.Now;
                    await dalMessageNoticeService.UpdateAsync(messageNoticeService, true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<BaseIdAndNameDto> GetMessageNoticeTypeList()
        {
            var appointmentTypes = Enum.GetValues(typeof(MessageNoticeMessageTextEnum));
            List<BaseIdAndNameDto> appointmentTypeList = new List<BaseIdAndNameDto>();
            foreach (var item in appointmentTypes)
            {
                BaseIdAndNameDto appointmentType = new BaseIdAndNameDto();
                appointmentType.Id = Convert.ToInt32(item).ToString();
                appointmentType.Name = ServiceClass.GetNoticeTypeText(Convert.ToByte(item));
                appointmentTypeList.Add(appointmentType);
            }
            return appointmentTypeList;
        }
    }
}
