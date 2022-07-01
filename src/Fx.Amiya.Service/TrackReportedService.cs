using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.TrackReported;
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
using jos_sdk_net.Util;
using Fx.Amiya.Dto.TmallOrder;

namespace Fx.Amiya.Service
{
    public class TrackReportedService : ITrackReportedService
    {
        private IDalTrackReported dalTrackReported;
        private IHospitalInfoService _hospitalInfoService;
        private ITrackService trackService;
        private ICustomerService customerService;
        private IWxAppConfigService _wxAppConfigService;
        private IUnitOfWork unitOfWork;
        private IAmiyaEmployeeService _amiyaEmployeeService;
        private IDalAmiyaEmployee dalAmiyaEmployee;
        public TrackReportedService(IDalTrackReported dalTrackReported,
            IHospitalInfoService hospitalInfoService,
            ITrackService trackService,
            IAmiyaEmployeeService amiyaEmployeeService,
            ICustomerService customerService,
            IWxAppConfigService wxAppConfigService,
            IUnitOfWork unitOfWork,
            IDalAmiyaEmployee dalAmiyaEmployee)
        {
            this.dalTrackReported = dalTrackReported;
            _hospitalInfoService = hospitalInfoService;
            this.trackService = trackService;
            this.customerService = customerService;
            this.unitOfWork = unitOfWork;
            _amiyaEmployeeService = amiyaEmployeeService;
            _wxAppConfigService = wxAppConfigService;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
        }



        public async Task<FxPageInfo<TrackReportedDto>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, int? sendHospitalId, int? employeeId, int? sendStatus, string keyword, int pageNum, int pageSize)
        {
            try
            {
                var trackReported = from d in dalTrackReported.GetAll()
                                    where (keyword == null || d.Phone.Contains(keyword) || d.SendContent.Contains(keyword))
                                    && ((!startDate.HasValue && !endDate.HasValue) || d.SendDate >= startDate.Value.Date && d.SendDate < endDate.Value.AddDays(1).Date)
                                    && (!sendHospitalId.HasValue || d.SendHospitalId == sendHospitalId)
                                    && (!sendStatus.HasValue || d.SendStatus == sendStatus)
                                    select new TrackReportedDto
                                    {
                                        Id = d.Id,
                                        Phone = d.Phone,
                                        SendStatus = d.SendStatus,
                                        SendStatusText = ServiceClass.GerSendStatusText(d.SendStatus),
                                        SendContent = d.SendContent,
                                        SendHospitalId = d.SendHospitalId,
                                        HospitalContent = d.HospitalContent,
                                        SendDate = d.SendDate,
                                        SendBy = d.SendBy,
                                        TrackRecordId = d.TrackRecordId,
                                    };
                var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                {
                    trackReported = from d in trackReported
                                    where d.SendBy == employeeId
                                    select d;
                }
                FxPageInfo<TrackReportedDto> trackReportedPageInfo = new FxPageInfo<TrackReportedDto>();
                trackReportedPageInfo.TotalCount = await trackReported.CountAsync();
                trackReportedPageInfo.List = await trackReported.OrderByDescending(x => x.SendDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                foreach (var x in trackReportedPageInfo.List)
                {
                    var hospitalInfo = await _hospitalInfoService.GetByIdAsync(x.SendHospitalId);
                    x.SendHospital = hospitalInfo.Name;
                    var empInfo = await _amiyaEmployeeService.GetByIdAsync(x.SendBy);
                    x.SendByName = empInfo.Name;
                }
                return trackReportedPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<FxPageInfo<TrackReportedDto>> GetHospitalUnTrackListWithPageAsync(DateTime? startDate, DateTime? endDate, int? sendHospitalId, string keyword, int pageNum, int pageSize)
        {
            try
            {
                var config = await _wxAppConfigService.GetCallCenterConfig();
                var trackReported = from d in dalTrackReported.GetAll()
                                    where (keyword == null || d.Phone.Contains(keyword) || d.SendContent.Contains(keyword))
                                    && ((!startDate.HasValue && !endDate.HasValue) || d.SendDate >= startDate.Value.Date && d.SendDate < endDate.Value.AddDays(1).Date)
                                    && (!sendHospitalId.HasValue || d.SendHospitalId == sendHospitalId)
                                    && (d.SendStatus == (int)SendStatus.Sended)
                                    select new TrackReportedDto
                                    {
                                        Id = d.Id,
                                        Phone = d.Phone,
                                        EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                        SendStatus = d.SendStatus,
                                        SendStatusText = ServiceClass.GerSendStatusText(d.SendStatus),
                                        SendContent = d.SendContent,
                                        SendHospitalId = d.SendHospitalId,
                                        HospitalContent = d.HospitalContent,
                                        SendDate = d.SendDate,
                                        SendBy = d.SendBy,
                                        TrackRecordId = d.TrackRecordId,
                                    };
                FxPageInfo<TrackReportedDto> trackReportedPageInfo = new FxPageInfo<TrackReportedDto>();
                trackReportedPageInfo.TotalCount = await trackReported.CountAsync();
                trackReportedPageInfo.List = await trackReported.OrderByDescending(x => x.SendDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                foreach (var x in trackReportedPageInfo.List)
                {
                    var hospitalInfo = await _hospitalInfoService.GetByIdAsync(x.SendHospitalId);
                    x.SendHospital = hospitalInfo.Name;
                    var empInfo = await _amiyaEmployeeService.GetByIdAsync(x.SendBy);
                    x.SendByName = empInfo.Name;
                }
                return trackReportedPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<FxPageInfo<TrackReportedDto>> GetHospitalDealedListWithPageAsync(DateTime? startDate, DateTime? endDate, int? sendStatus, int? sendHospitalId, string keyword, int pageNum, int pageSize)
        {
            try
            {
                var trackReported = from d in dalTrackReported.GetAll()
                                    where
                                    ((!startDate.HasValue && !endDate.HasValue) || d.SendDate >= startDate.Value.Date && d.SendDate < endDate.Value.AddDays(1).Date)
                                    && (!sendHospitalId.HasValue || d.SendHospitalId == sendHospitalId)
                                    select d;
                if (sendStatus.HasValue)
                {
                    trackReported = from d in trackReported
                                    where d.SendStatus == sendStatus
                                    select d;
                }
                else
                {
                    trackReported = from d in trackReported
                                    where d.SendStatus == (int)SendStatus.FollowUpFailed || d.SendStatus == (int)SendStatus.FollowUpFinished
                                    select d;
                }
                var result = from d in trackReported
                             where (keyword == null || d.Phone.Contains(keyword) || d.SendContent.Contains(keyword))
                             select new TrackReportedDto
                             {
                                 Id = d.Id,
                                 Phone = d.Phone,
                                 SendStatus = d.SendStatus,
                                 SendStatusText = ServiceClass.GerSendStatusText(d.SendStatus),
                                 SendContent = d.SendContent,
                                 SendHospitalId = d.SendHospitalId,
                                 HospitalContent = d.HospitalContent,
                                 SendDate = d.SendDate,
                                 SendBy = d.SendBy,
                                 TrackRecordId = d.TrackRecordId,
                             };
                FxPageInfo<TrackReportedDto> trackReportedPageInfo = new FxPageInfo<TrackReportedDto>();
                trackReportedPageInfo.TotalCount = await trackReported.CountAsync();
                trackReportedPageInfo.List = await result.OrderByDescending(x => x.SendDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                foreach (var x in trackReportedPageInfo.List)
                {
                    var hospitalInfo = await _hospitalInfoService.GetByIdAsync(x.SendHospitalId);
                    x.SendHospital = hospitalInfo.Name;
                    var empInfo = await _amiyaEmployeeService.GetByIdAsync(x.SendBy);
                    x.SendByName = empInfo.Name;
                }
                return trackReportedPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(AddTrackReportedDto addDto)
        {
            try
            {
                TrackReported trackReported = new TrackReported();
                trackReported.Id = CreateOrderIdHelper.GetNextNumber();
                trackReported.Phone = addDto.Phone;
                trackReported.SendStatus = (int)SendStatus.Sended;
                trackReported.SendContent = addDto.SendContent;
                trackReported.SendHospitalId = addDto.SendHospitalId;
                trackReported.SendDate = DateTime.Now;
                trackReported.SendBy = addDto.SendBy;
                var hospitalCustomerInfo = await customerService.GetCustomerListByHospitalIdAsync(addDto.SendHospitalId, addDto.Phone, 1, 1);
                if (hospitalCustomerInfo.TotalCount == 0)
                {
                    throw new Exception("该客户不是医院顾客，无法提报到医院，请重新选择提报医院！");
                }
                await dalTrackReported.AddAsync(trackReported, true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TrackReportedDto> GetByIdAsync(string id)
        {
            try
            {
                var trackReported = await dalTrackReported.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (trackReported == null)
                {
                    return new TrackReportedDto();
                }

                TrackReportedDto trackReportedDto = new TrackReportedDto();
                trackReportedDto.Id = trackReported.Id;
                trackReportedDto.Phone = trackReported.Phone;
                trackReportedDto.SendStatus = (int)SendStatus.UnSend;
                trackReportedDto.SendContent = trackReported.SendContent;
                trackReportedDto.SendHospitalId = trackReported.SendHospitalId;
                trackReportedDto.HospitalContent = trackReported.HospitalContent;
                trackReportedDto.TrackRecordId = trackReported.TrackRecordId;

                return trackReportedDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(UpdateTrackReportedDto updateDto)
        {
            try
            {
                var trackReported = await dalTrackReported.GetAll().FirstOrDefaultAsync(e => e.Id == updateDto.Id);
                if (trackReported == null)
                    throw new Exception("追踪回访提报编号错误！");
                trackReported.Phone = updateDto.Phone;
                trackReported.SendContent = updateDto.SendContent;
                trackReported.SendHospitalId = updateDto.SendHospitalId;
                if (trackReported.SendHospitalId != updateDto.SendHospitalId)
                { trackReported.SendStatus = (int)SendStatus.Sended; }
                await dalTrackReported.UpdateAsync(trackReported, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var trackReported = await dalTrackReported.GetAll().FirstOrDefaultAsync(e => e.Id == id);

                if (trackReported == null)
                    throw new Exception("追踪回访提报编号错误");

                await dalTrackReported.DeleteAsync(trackReported, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task HospitalConfirTrackRecordAsync(HospitalConfirmTrackRecordedDto addDto)
        {
            try
            {
                var trackReported = await dalTrackReported.GetAll().FirstOrDefaultAsync(e => e.Id == addDto.Id);
                if (trackReported == null)
                    throw new Exception("追踪回访提报编号错误！");
                if (addDto.IsTrackedResult == true)
                {
                    int trackId = await trackService.AddTrackRecordAsync(addDto.addTrackRecord, trackReported.SendBy);
                    trackReported.SendStatus = (int)SendStatus.FollowUpFinished;
                    trackReported.HospitalContent = addDto.addTrackRecord.TrackContent;
                    trackReported.TrackRecordId = trackId;
                }
                else
                {
                    trackReported.SendStatus = (int)SendStatus.FollowUpFailed;
                    trackReported.HospitalContent = addDto.HospitalContent;
                }
                await dalTrackReported.UpdateAsync(trackReported, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<OrderAppTypeDto> GetSendStatusTextList()
        {
            var sendStatus = Enum.GetValues(typeof(SendStatus));
            List<OrderAppTypeDto> orderAppTypeList = new List<OrderAppTypeDto>();
            foreach (var item in sendStatus)
            {
                OrderAppTypeDto orderAppType = new OrderAppTypeDto();
                orderAppType.OrderType = Convert.ToByte(item);
                orderAppType.AppTypeText = ServiceClass.GerSendStatusText(Convert.ToByte(item));
                orderAppTypeList.Add(orderAppType);
            }
            return orderAppTypeList;
        }
    }
}
