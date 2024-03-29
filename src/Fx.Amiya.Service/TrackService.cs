using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Amiya.Dto.Track;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.WxAppConfig;
using Newtonsoft.Json;
using Fx.Infrastructure.Utils;
using Fx.Infrastructure.DataAccess;
using Microsoft.Extensions.Logging;
using Fx.Common;
using Fx.Amiya.Dto.AssistantHomePage.Result;
using Fx.Amiya.Dto.AssistantHomePage.Input;
using Fx.Amiya.Dto;

namespace Fx.Amiya.Service
{
    public class TrackService : ITrackService
    {
        private IDalTrackType dalTrackType;
        private IDalTrackTool dalTrackTool;
        private IDalTrackRecord dalTrackRecord;
        private ITrackTypeThemeModelService trackTypeThemeModelService;
        private IDalConfig dalConfig;
        private IDalWaitTrackCustomer dalWaitTrackCustomer;
        private IUnitOfWork unitOfWork;
        public TrackService(IDalTrackType dalTrackType,
            IDalTrackTool dalTrackTool,
            ITrackTypeThemeModelService trackTypeThemeModelService,
            IDalTrackRecord dalTrackRecord,
            IDalConfig dalConfig,
            IDalWaitTrackCustomer dalWaitTrackCustomer,
            IUnitOfWork unitOfWork)
        {
            this.dalTrackType = dalTrackType;
            this.trackTypeThemeModelService = trackTypeThemeModelService;
            this.dalTrackTool = dalTrackTool;
            this.dalTrackRecord = dalTrackRecord;
            this.dalConfig = dalConfig;
            this.dalWaitTrackCustomer = dalWaitTrackCustomer;
            this.unitOfWork = unitOfWork;
        }

        #region 回访类型

        /// <summary>
        /// 获取回访类型列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<TrackTypeDto>> GetTrackTypeListWithPageAsync(bool? valid, int pageNum, int pageSize)
        {
            var trackType = from d in dalTrackType.GetAll()
                            where (valid.HasValue ? d.Valid == valid : d.Valid == true)
                            select new TrackTypeDto
                            {
                                Id = d.Id,
                                Name = d.Name,
                                Valid = d.Valid,
                                HasModel = d.HasModel,
                                IsOldCustomer = d.IsOldCustomer
                            };
            FxPageInfo<TrackTypeDto> trackTypePageInfo = new FxPageInfo<TrackTypeDto>();
            trackTypePageInfo.TotalCount = await trackType.CountAsync();
            trackTypePageInfo.List = await trackType.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return trackTypePageInfo;
        }



        /// <summary>
        /// 获取有效的回访类型列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<TrackTypeDto>> GetTrackTypeListAsync(bool? isOldCustomer)
        {
            var trackType = from d in dalTrackType.GetAll()
                            where d.Valid && (!isOldCustomer.HasValue || d.IsOldCustomer == isOldCustomer)
                            select new TrackTypeDto
                            {
                                Id = d.Id,
                                Name = d.Name,
                                Valid = d.Valid,
                                HasModel = d.HasModel
                            };

            return await trackType.ToListAsync();
        }


        /// <summary>
        /// 添加回访类型
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddTrackTypeAsync(AddTrackTypeDto addDto)
        {
            try
            {
                var type = await dalTrackType.GetAll().SingleOrDefaultAsync(e => e.Name == addDto.Name);
                if (type != null)
                    throw new Exception("添加失败，已存在该回访类型");

                TrackType trackType = new TrackType();
                trackType.Name = addDto.Name;
                trackType.HasModel = addDto.HasModel;
                trackType.IsOldCustomer = addDto.IsOldCustomer;
                trackType.Valid = true;
                await dalTrackType.AddAsync(trackType, true);
                if (addDto.HasModel == true)
                {
                    await trackTypeThemeModelService.AddAsync(addDto.TrackTypeThemeModelDto);
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message.ToString());
            }
        }

        public async Task<TrackTypeDto> GetbyIdAsync(int Id)
        {
            var model = await dalTrackType.GetAll().SingleOrDefaultAsync(e => e.Id == Id);
            if (model.Id == 0)
            { throw new Exception("未找到对应编号的回访类型！"); }
            TrackTypeDto result = new TrackTypeDto();
            result.Id = model.Id;
            result.Name = model.Name;
            result.Valid = model.Valid;
            result.HasModel = model.HasModel;
            result.IsOldCustomer = model.IsOldCustomer;
            var trackTypeThemeModel = await trackTypeThemeModelService.GetListAsync(Id);
            result.TrackTypeThemeModelDto = trackTypeThemeModel;
            return result;
        }


        /// <summary>
        /// 修改回访类型
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateTrackTypeAsync(UpdateTrackTypeDto updateDto)
        {
            var trackType = await dalTrackType.GetAll().Include(e => e.TrackRecordList).SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            if (trackType == null)
                throw new Exception("回访类型编号错误");

            var count = await dalTrackType.GetAll().CountAsync(e => e.Name == updateDto.Name && e.Id != updateDto.Id && e.Valid);
            if (count > 0)
                throw new Exception("修改失败，已存在该回访类型");
            trackType.Name = updateDto.Name;
            trackType.Valid = updateDto.Valid;
            trackType.HasModel = updateDto.HasModel;
            trackType.IsOldCustomer = updateDto.IsOldCustomer;
            await dalTrackType.UpdateAsync(trackType, true);
            if (trackType.HasModel == true)
            {
                await trackTypeThemeModelService.AddAsync(updateDto.AddTrackTypeThemeModelDto);
            }
        }



        /// <summary>
        /// 删除回访类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteTrackTypeAsync(int id)
        {
            var trackType = await dalTrackType.GetAll().Include(e => e.TrackRecordList).SingleOrDefaultAsync(e => e.Id == id);
            if (trackType == null)
                throw new Exception("回访类型编号错误");
            trackType.Valid = false;
            await dalTrackType.UpdateAsync(trackType, true);
        }


        #endregion

        #region 回访工具

        /// <summary>
        /// 获取回访工具列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<TrackToolDto>> GetTrackToolListWithPageAsync(bool? valid, int pageNum, int pageSize)
        {
            var trackTool = from d in dalTrackTool.GetAll()
                            where (valid.HasValue ? d.Valid == valid : d.Valid == true)
                            select new TrackToolDto
                            {
                                Id = d.Id,
                                Name = d.Name,
                                Valid = d.Valid
                            };

            FxPageInfo<TrackToolDto> trackToolPageInfo = new FxPageInfo<TrackToolDto>();
            trackToolPageInfo.TotalCount = await trackTool.CountAsync();
            trackToolPageInfo.List = await trackTool.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return trackToolPageInfo;
        }


        /// <summary>
        /// 获取有效的回访工具列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<TrackToolDto>> GetTrackToolListAsync()
        {
            var trackTool = from d in dalTrackTool.GetAll()
                            where d.Valid
                            select new TrackToolDto
                            {
                                Id = d.Id,
                                Name = d.Name,
                                Valid = d.Valid
                            };


            return await trackTool.ToListAsync();
        }


        /// <summary>
        /// 添加回访工具
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddTrackToolAsync(AddTrackToolDto addDto)
        {
            var tool = await dalTrackTool.GetAll().SingleOrDefaultAsync(e => e.Name == addDto.Name);
            if (tool != null)
                throw new Exception("添加失败，已存在该回访工具");

            TrackTool trackTool = new TrackTool();
            trackTool.Name = addDto.Name;
            trackTool.Valid = true;
            await dalTrackTool.AddAsync(trackTool, true);
        }


        /// <summary>
        /// 修改回访工具
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateTrackToolAsync(UpdateTrackToolDto updateDto)
        {
            var trackTool = await dalTrackTool.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            if (trackTool == null)
                throw new Exception("回访工具编号错误");

            var count = await dalTrackTool.GetAll().CountAsync(e => e.Name == updateDto.Name && e.Id != updateDto.Id && e.Valid);
            if (count > 0)
                throw new Exception("修改失败，已存在该回访工具");

            trackTool.Name = updateDto.Name;
            trackTool.Valid = updateDto.Valid;
            await dalTrackTool.UpdateAsync(trackTool, true);
        }


        /// <summary>
        /// 删除回访工具
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteTrackToolAsync(int id)
        {
            var trackTool = await dalTrackTool.GetAll().Include(e => e.TrackRecordList).SingleOrDefaultAsync(e => e.Id == id);
            if (trackTool == null)
                throw new Exception("回访工具编号错误");
            trackTool.Valid = false;
            await dalTrackTool.UpdateAsync(trackTool, true);


        }


        #endregion





        #region 回访记录

        /// <summary>
        /// 获取回访记录（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="isOldCustomerTrack">新/老客回访</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<TrackRecordDto>> GetRecordListWithPageAsync(string keyword, DateTime? startDate, DateTime? endDate, int employeeId, bool? isOldCustomerTrack, int pageNum, int pageSize)
        {
            var q = from d in dalTrackRecord.GetAll()
                    where string.IsNullOrWhiteSpace(keyword) || d.Phone == keyword || d.TrackTheme == keyword
                    where (!isOldCustomerTrack.HasValue || d.IsOldCustomerTrack == isOldCustomerTrack.Value)
                    select d;
            if (startDate != null && endDate != null)
            {
                DateTime startrq = ((DateTime)startDate);
                DateTime endrq = ((DateTime)endDate).AddDays(1);
                q = from d in q
                    where d.TrackDate >= startrq.Date && d.TrackDate < endrq.Date
                    select d;
            }
            if (employeeId != -1)
            {
                q = from d in q
                    where d.EmployeeId == employeeId
                    select d;
            }



            var config = await GetCallCenterConfig();
            var trackRoceod = from d in q
                              select new TrackRecordDto
                              {
                                  Id = d.Id,
                                  Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                  EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                  TrackDate = d.TrackDate,
                                  TrackContent = d.TrackContent,
                                  TrackTheme = d.TrackThemeId != null ? d.TrackThemeInfo.Name : d.TrackTheme,
                                  TrackThemeId = d.TrackThemeId,
                                  TrackTypeId = d.TrackTypeId,
                                  TrackTypeName = d.TrackType.Name,
                                  TrackToolId = d.TrackToolId,
                                  TrackPlan = d.TrackPlan,
                                  TrackToolName = d.TrackTool.Name,
                                  EmployeeId = d.EmployeeId,
                                  EmployeeName = d.AmiyaEmployee.Name,
                                  Valid = d.Valid,
                                  CallRecordId = d.CallRecordId,
                                  TrackPicture1 = d.TrackPicture1,
                                  TrackPicture2 = d.TrackPicture2,
                                  TrackPicture3 = d.TrackPicture3,
                                  IsOldCustomerTrack = d.IsOldCustomerTrack,
                              };


            FxPageInfo<TrackRecordDto> trackRecordPageInfo = new FxPageInfo<TrackRecordDto>();
            trackRecordPageInfo.TotalCount = await trackRoceod.CountAsync();
            trackRecordPageInfo.List = await trackRoceod.OrderByDescending(e => e.TrackDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync(); ;
            return trackRecordPageInfo;
        }





        /// <summary>
        /// 根据加密电话号获取回访记录列表（分页）
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<TrackRecordDto>> GetRecordListByEncryptPhoneWithPageAsync(string encryptPhone, string shoppingCartRegistionId, int pageNum, int pageSize)
        {
            var config = await GetCallCenterConfig();
            string phone = ServiceClass.Decrypto(encryptPhone, config.PhoneEncryptKey);

            var trackRoceod = from d in dalTrackRecord.GetAll()
                              where d.Phone == phone
                              where (string.IsNullOrEmpty(shoppingCartRegistionId) || d.ShoppingCartRegistionId == shoppingCartRegistionId)
                              select new TrackRecordDto
                              {
                                  Id = d.Id,
                                  Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                  TrackDate = d.TrackDate,
                                  TrackContent = d.TrackContent,
                                  TrackTheme = d.TrackThemeId != null ? d.TrackThemeInfo.Name : d.TrackTheme,
                                  TrackPlan = d.TrackPlan,
                                  TrackThemeId = d.TrackThemeId,
                                  TrackTypeId = d.TrackTypeId,
                                  TrackTypeName = d.TrackType.Name,
                                  TrackToolId = d.TrackToolId,
                                  TrackToolName = d.TrackTool.Name,
                                  EmployeeId = d.EmployeeId,
                                  EmployeeName = d.AmiyaEmployee.Name,
                                  Valid = d.Valid,
                                  CallRecordId = d.CallRecordId,
                                  IsPlanTrack = d.WaitTrackCustomer != null ? true : false,
                                  PlanTrackTheme = d.WaitTrackCustomer.TrackThemeId != null ? d.WaitTrackCustomer.TrackThemeInfo.Name : d.WaitTrackCustomer.TrackTheme,
                                  TrackPicture1 = d.TrackPicture1,
                                  TrackPicture2 = d.TrackPicture2,
                                  TrackPicture3 = d.TrackPicture3,
                                  IsOldCustomerTrack = d.IsOldCustomerTrack,
                                  IsAddWechat = d.IsAddWechat,
                                  UnAddWechatReasonId = d.UnAddWechatReasonId,
                                  UnAddWechatReason = ServiceClass.UnAddWechatReasonText(d.UnAddWechatReasonId),
                              };

            FxPageInfo<TrackRecordDto> trackRecordPageInfo = new FxPageInfo<TrackRecordDto>();
            trackRecordPageInfo.TotalCount = await trackRoceod.CountAsync();
            trackRecordPageInfo.List = await trackRoceod.OrderByDescending(e => e.TrackDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return trackRecordPageInfo;
        }



        private async Task<CallCenterConfigDto> GetCallCenterConfig()
        {
            var config = await dalConfig.GetAll().SingleOrDefaultAsync();
            return JsonConvert.DeserializeObject<WxAppConfigDto>(config.ConfigJson).CallCenterConfig;
        }


        /// <summary>
        /// 添加回访记录
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<int> AddTrackRecordAsync(AddTrackRecordDto addDto, int employeeId)
        {
            try
            {
                unitOfWork.BeginTransaction();
                DateTime date = DateTime.Now;
                var config = await GetCallCenterConfig();
                string phone = ServiceClass.Decrypto(addDto.EncryptPhone, config.PhoneEncryptKey);

                var trackTool = await dalTrackTool.GetAll().SingleOrDefaultAsync(e => e.Id == addDto.TrackToolId);
                if (trackTool.Name.Contains("电话") && string.IsNullOrWhiteSpace(addDto.CallRecordId))
                    throw new Exception("回访工具是电话，通话记录编号不能为空");

                TrackRecord trackRecord = new TrackRecord();
                trackRecord.Phone = phone;
                trackRecord.TrackDate = date;
                trackRecord.TrackContent = addDto.TrackContent;
                trackRecord.TrackThemeId = addDto.TrackThemeId;
                trackRecord.TrackTypeId = addDto.TrackTypeId;
                trackRecord.TrackToolId = addDto.TrackToolId;
                trackRecord.TrackPlan = addDto.TrackPlan;
                trackRecord.EmployeeId = employeeId;
                trackRecord.Valid = addDto.Valid;
                trackRecord.CallRecordId = addDto.CallRecordId;
                trackRecord.TrackPicture1 = addDto.TrackPicture1;
                trackRecord.TrackPicture2 = addDto.TrackPicture2;
                trackRecord.TrackPicture3 = addDto.TrackPicture3;
                trackRecord.ShoppingCartRegistionId = addDto.ShoppingCartRegistionId;
                trackRecord.IsOldCustomerTrack = addDto.IsOldCustomerTrack;
                trackRecord.IsAddWechat = addDto.IsAddWechat;
                trackRecord.UnAddWechatReasonId = addDto.UnAddWechatReasonId;
                await dalTrackRecord.AddAsync(trackRecord, true);

                if (addDto.WaitTrackId != null)
                {
                    var waitTrack = await dalWaitTrackCustomer.GetAll().SingleOrDefaultAsync(e => e.Id == addDto.WaitTrackId);
                    if (waitTrack == null)
                        throw new Exception("待回访编号错误");
                    waitTrack.Status = true;
                    await dalWaitTrackCustomer.UpdateAsync(waitTrack, true);
                }
                if (addDto.AddWaitTrackCustomer != null)
                {
                    if (addDto.AddWaitTrackCustomer.Count > 0)
                    {
                        foreach (var x in addDto.AddWaitTrackCustomer)
                        {
                            if (x.PlanTrackDate.Date <= date.Date)
                                throw new Exception("下次回访日期必须大于今天");

                            WaitTrackCustomer waitTrackCustomer = new WaitTrackCustomer();
                            waitTrackCustomer.Phone = phone;
                            waitTrackCustomer.PlanTrackDate = x.PlanTrackDate;
                            waitTrackCustomer.TrackTypeId = x.TrackTypeId;
                            waitTrackCustomer.TrackPlan = x.TrackPlan;
                            waitTrackCustomer.TrackThemeId = x.TrackThemeId;
                            waitTrackCustomer.CreateDate = date;
                            waitTrackCustomer.Status = false;
                            waitTrackCustomer.CreateBy = employeeId;
                            if (x.OtherTrackEmployeeId != null)
                            {
                                waitTrackCustomer.PlanTrackEmployeeId = (int)x.OtherTrackEmployeeId;
                            }
                            else
                            {
                                waitTrackCustomer.PlanTrackEmployeeId = employeeId;
                            }

                            waitTrackCustomer.TrackRecordId = trackRecord.Id;
                            await dalWaitTrackCustomer.AddAsync(waitTrackCustomer, true);
                        }
                    }
                }


                unitOfWork.Commit();

                return trackRecord.Id;
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }

        }


        /// <summary>
        /// 获取待回访列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<WaitTrackCustomerDto>> GetWaitTrackListWithPageAsync(string keyword, DateTime? startDate, DateTime? endDate, int employeeId, int pageNum, int pageSize)
        {
            var q = from d in dalWaitTrackCustomer.GetAll()
                    where (string.IsNullOrWhiteSpace(keyword) || d.Phone.Contains(keyword) || d.TrackThemeInfo.Name.Contains(keyword) || d.TrackTheme.Contains(keyword))
                    && d.Status == false
                    select d;

            if (startDate != null && endDate != null)
            {
                DateTime startrq = ((DateTime)startDate);
                DateTime endrq = ((DateTime)endDate).AddDays(1);
                q = from d in q
                    where d.PlanTrackDate >= startrq.Date && d.PlanTrackDate < endrq.Date
                    select d;
            }
            if (employeeId != -1)
            {
                q = from d in q
                    where d.PlanTrackEmployeeId == employeeId
                    select d;
            }
            var config = await GetCallCenterConfig();
            var waitTrack = from d in q
                            select new WaitTrackCustomerDto
                            {
                                Id = d.Id,
                                Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                PlanTrackDate = d.PlanTrackDate,
                                TrackTypeId = d.TrackTypeId,
                                TrackTypeName = d.TrackType.Name,
                                TrackPlan = d.TrackPlan,
                                TrackThemeId = d.TrackThemeId,
                                TrackTheme = d.TrackThemeId != null ? d.TrackThemeInfo.Name : d.TrackTheme,
                                CreateDate = d.CreateDate,
                                CreateBy = d.CreateBy,
                                CreateName = d.CreateEmployee.Name,
                                Status = d.Status,
                                PlanTrackEmployeeId = d.PlanTrackEmployeeId,
                                PlanTrackEnmployeeName = d.PlanTrackEmployee.Name
                            };

            FxPageInfo<WaitTrackCustomerDto> waitTrackPageInfo = new FxPageInfo<WaitTrackCustomerDto>();
            waitTrackPageInfo.TotalCount = await waitTrack.CountAsync();
            waitTrackPageInfo.List = await waitTrack.OrderBy(e => e.PlanTrackDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return waitTrackPageInfo;
        }



        #endregion

        #region 助理首页

        /// <summary>
        /// 获取助理今日回访数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<TodayTrackDataDto>> GetTodayTrackDataAsync(QueryAssistantHomePageTrackDataDto query)
        {
            FxPageInfo<TodayTrackDataDto> fxPageInfo = new FxPageInfo<TodayTrackDataDto>();
            if (!query.Date.HasValue)
            {
                query.Date = DateTime.Now;
            }
            var startDate = query.Date.Value.Date;
            var endDate = query.Date.Value.AddDays(1).Date;
            var config = await GetCallCenterConfig();
            if (query.Type == 1)
            {
                var track = dalWaitTrackCustomer.GetAll().Where(e => e.Status == false).Include(e => e.PlanTrackEmployee).Where(e => e.PlanTrackDate >= startDate && e.PlanTrackDate < endDate);
                if (query.AssistantId.HasValue)
                {
                    track = track.Where(e => e.PlanTrackEmployeeId == query.AssistantId);
                }
                fxPageInfo.TotalCount = await track.CountAsync();
                fxPageInfo.List = track.Select(e => new TodayTrackDataDto
                {
                    Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(e.Phone) : e.Phone,
                    EncryptPhone = ServiceClass.Encrypt(e.Phone, config.PhoneEncryptKey),
                    Status = e.Status ? "已回访" : "未回访",
                    TrackAssistantName = e.PlanTrackEmployee.Name,
                    TrackPurpose = e.TrackPlan,
                    Remark = ""
                }).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToList();

            }
            else
            {
                var track = dalTrackRecord.GetAll().Include(e => e.AmiyaEmployee).Where(e => e.TrackDate >= startDate && e.TrackDate < endDate);
                if (query.AssistantId.HasValue)
                {
                    track = track.Where(e => e.EmployeeId == query.AssistantId);
                }
                fxPageInfo.TotalCount = await track.CountAsync();
                fxPageInfo.List = track.Select(e => new TodayTrackDataDto
                {
                    Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(e.Phone) : e.Phone,
                    EncryptPhone = ServiceClass.Encrypt(e.Phone, config.PhoneEncryptKey),
                    Status = "已回访",
                    TrackAssistantName = e.AmiyaEmployee.Name,
                    TrackPurpose = e.TrackPlan,
                    Remark = ""
                }).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToList();
            }
            return fxPageInfo;
        }



        #endregion

        /// <summary>
        /// 成交后录入待回访记录
        /// </summary>
        /// <param name="dealTrack"></param>
        /// <returns></returns>
        public async Task AddWaitTrackAfterDealAsync(DealAfterAddTrackDto dealTrack)
        {
            try
            {
                List<WaitTrackCustomer> waitTrackList = new List<WaitTrackCustomer>();
                WaitTrackCustomer oneDay = new WaitTrackCustomer();
                oneDay.Phone = dealTrack.Phone;
                oneDay.PlanTrackDate = dealTrack.CreateDate.AddDays(1);
                oneDay.TrackTypeId = 6;
                oneDay.TrackThemeId = 54;
                oneDay.CreateDate = DateTime.Now;
                oneDay.TrackPlan = "告知术后注意事项、以及恢复期可能发生的问题，并安抚";
                oneDay.CreateBy = dealTrack.EmployeeId;
                oneDay.Status = false;
                oneDay.PlanTrackEmployeeId = dealTrack.EmployeeId;
                waitTrackList.Add(oneDay);

                WaitTrackCustomer oneWeek = new WaitTrackCustomer();
                oneWeek.Phone = dealTrack.Phone;
                oneWeek.PlanTrackDate = dealTrack.CreateDate.AddDays(7);
                oneWeek.TrackTypeId = 6;
                oneWeek.TrackThemeId = 55;
                oneWeek.CreateDate = DateTime.Now;
                oneWeek.TrackPlan = "关心恢复的情况";
                oneWeek.CreateBy = dealTrack.EmployeeId;
                oneWeek.Status = false;
                oneWeek.PlanTrackEmployeeId = dealTrack.EmployeeId;
                waitTrackList.Add(oneWeek);


                WaitTrackCustomer halfMonth = new WaitTrackCustomer();
                halfMonth.Phone = dealTrack.Phone;
                halfMonth.PlanTrackDate = dealTrack.CreateDate.AddDays(15);
                halfMonth.TrackTypeId = 6;
                halfMonth.TrackThemeId = 56;
                halfMonth.CreateDate = DateTime.Now;
                halfMonth.TrackPlan = "关心目前的效果，告知1个月的时候会有吸收代谢的情况，看个人代谢的情况，建议一个月的时候加强效果";
                halfMonth.CreateBy = dealTrack.EmployeeId;
                halfMonth.Status = false;
                halfMonth.PlanTrackEmployeeId = dealTrack.EmployeeId;
                waitTrackList.Add(halfMonth);


                WaitTrackCustomer oneMonth = new WaitTrackCustomer();
                oneMonth.Phone = dealTrack.Phone;
                oneMonth.PlanTrackDate = dealTrack.CreateDate.AddMonths(1);
                oneMonth.TrackTypeId = 12;
                oneMonth.TrackThemeId = 57;
                oneMonth.CreateDate = DateTime.Now;
                oneMonth.TrackPlan = "关心吸收的情况，邀约补量，或下一步调整";
                oneMonth.CreateBy = dealTrack.EmployeeId;
                oneMonth.Status = false;
                oneMonth.PlanTrackEmployeeId = dealTrack.EmployeeId;
                waitTrackList.Add(oneMonth);


                WaitTrackCustomer threeMonth = new WaitTrackCustomer();
                threeMonth.Phone = dealTrack.Phone;
                threeMonth.PlanTrackDate = dealTrack.CreateDate.AddMonths(3);
                threeMonth.TrackTypeId = 12;
                threeMonth.TrackThemeId = 58;
                threeMonth.CreateDate = DateTime.Now;
                threeMonth.TrackPlan = "补量以及下一步的调整";
                threeMonth.CreateBy = dealTrack.EmployeeId;
                threeMonth.Status = false;
                threeMonth.PlanTrackEmployeeId = dealTrack.EmployeeId;
                waitTrackList.Add(threeMonth);

                await dalWaitTrackCustomer.AddCollectionAsync(waitTrackList, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// 获取未加V原因名称列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<BaseKeyValueDto<int>>> GetUnAddWechatReasonNameListAsync()
        {
            var unAddWechatReasonTexts = Enum.GetValues(typeof(UnAddWechatReason));

            List<BaseKeyValueDto<int>> unAddWechatReasonTextList = new List<BaseKeyValueDto<int>>();
            foreach (var item in unAddWechatReasonTexts)
            {
                BaseKeyValueDto<int> baseKeyValueDto = new BaseKeyValueDto<int>();
                baseKeyValueDto.Key = Convert.ToInt32(item);
                baseKeyValueDto.Value = ServiceClass.UnAddWechatReasonText(Convert.ToInt32(item));
                unAddWechatReasonTextList.Add(baseKeyValueDto);
            }
            return unAddWechatReasonTextList;
        }
    }
}
