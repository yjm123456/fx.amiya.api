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

namespace Fx.Amiya.Service
{
    public class TrackService : ITrackService
    {
        private IDalTrackType dalTrackType;
        private IDalTrackTool dalTrackTool;
        private IDalTrackRecord dalTrackRecord;
        private IDalConfig dalConfig;
        private IDalWaitTrackCustomer dalWaitTrackCustomer;
        private IDalBindCustomerService dalBindCustomerService;
        private IUnitOfWork unitOfWork;
        private IDalAmiyaEmployee dalAmiyaEmployee;
        public TrackService(IDalTrackType dalTrackType,
            IDalTrackTool dalTrackTool,
            IDalTrackRecord dalTrackRecord,
            IDalConfig dalConfig,
            IDalWaitTrackCustomer dalWaitTrackCustomer,
            IUnitOfWork unitOfWork,
            IDalBindCustomerService dalBindCustomerService,
            IDalAmiyaEmployee dalAmiyaEmployee)
        {
            this.dalTrackType = dalTrackType;
            this.dalTrackTool = dalTrackTool;
            this.dalTrackRecord = dalTrackRecord;
            this.dalConfig = dalConfig;
            this.dalWaitTrackCustomer = dalWaitTrackCustomer;
            this.unitOfWork = unitOfWork;
            this.dalBindCustomerService = dalBindCustomerService;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
        }

        #region 回访类型

        /// <summary>
        /// 获取回访类型列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<TrackTypeDto>> GetTrackTypeListWithPageAsync(int pageNum, int pageSize)
        {
            var trackType = from d in dalTrackType.GetAll()
                            select new TrackTypeDto
                            {
                                Id = d.Id,
                                Name = d.Name,
                                Valid = d.Valid
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
        public async Task<List<TrackTypeDto>> GetTrackTypeListAsync()
        {
            var trackType = from d in dalTrackType.GetAll()
                            where d.Valid
                            select new TrackTypeDto
                            {
                                Id = d.Id,
                                Name = d.Name,
                                Valid = d.Valid
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
            var type = await dalTrackType.GetAll().SingleOrDefaultAsync(e => e.Name == addDto.Name);
            if (type != null)
                throw new Exception("添加失败，已存在该回访类型");

            TrackType trackType = new TrackType();
            trackType.Name = addDto.Name;
            trackType.Valid = true;
            await dalTrackType.AddAsync(trackType, true);
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
            await dalTrackType.UpdateAsync(trackType, true);
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
            if (trackType.TrackRecordList.Count() > 0)
                throw new Exception("删除失败，已有回访用到该回访类型");

            await dalTrackType.DeleteAsync(trackType, true);
        }


        #endregion

        #region 回访工具

        /// <summary>
        /// 获取回访工具列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<TrackToolDto>> GetTrackToolListWithPageAsync(int pageNum, int pageSize)
        {
            var trackTool = from d in dalTrackTool.GetAll()
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
            if (trackTool.TrackRecordList.Count() > 0)
                throw new Exception("删除失败，已有回访用到该工具");
            await dalTrackTool.DeleteAsync(trackTool, true);

        }


        #endregion





        #region 回访记录

        /// <summary>
        /// 获取回访记录（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<TrackRecordDto>> GetRecordListWithPageAsync(string keyword, DateTime? startDate, DateTime? endDate, int employeeId, int pageNum, int pageSize)
        {
            var q = from d in dalTrackRecord.GetAll()
                    where string.IsNullOrWhiteSpace(keyword) || d.Phone == keyword || d.TrackTheme == keyword
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
                                  CallRecordId = d.CallRecordId
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
        public async Task<FxPageInfo<TrackRecordDto>> GetRecordListByEncryptPhoneWithPageAsync(string encryptPhone, int pageNum, int pageSize)
        {
            var config = await GetCallCenterConfig();
            string phone = ServiceClass.Decrypto(encryptPhone, config.PhoneEncryptKey);

            var trackRoceod = from d in dalTrackRecord.GetAll()
                              where d.Phone == phone
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
                                  PlanTrackTheme = d.WaitTrackCustomer.TrackThemeId != null ? d.WaitTrackCustomer.TrackThemeInfo.Name : d.WaitTrackCustomer.TrackTheme
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
                throw ex;
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
    }
}
