﻿using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.OperationLog;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class OperatonLogService : IOperatonLogService
    {
        private readonly IDalOpertionLog dalOpertionLog;
        private readonly IDalAmiyaEmployee dalAmiyaEmployee;

        public OperatonLogService(IDalOpertionLog dalOpertionLog, IDalAmiyaEmployee dalAmiyaEmployee)
        {
            this.dalOpertionLog = dalOpertionLog;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
        }

        public async Task AddOperationLogAsync(OperationAddDto operationAdd)
        {
            OperationLog operationLog = new OperationLog();
            operationLog.Id = Guid.NewGuid().ToString().Replace("-", "");
            operationLog.RouteAddress = operationAdd.RouteAddress;
            operationLog.RequestType = operationAdd.RequestType;
            operationLog.Parameters = operationAdd.Parameters;
            operationLog.Code = operationLog.Code;
            operationLog.Message = operationLog.Message;
            operationLog.OperationBy = operationLog.OperationBy;
            operationLog.CreateDate = DateTime.Now;
            operationLog.Valid = true;
            await dalOpertionLog.AddAsync(operationLog, true);

        }

        public async Task<FxPageInfo<OperationLogInfoDto>> GetListByPageAsync(OperationLogSearchDto searchDto)
        {
            var startDate = searchDto.StartDate == null ? DateTime.Now.Date : searchDto.StartDate.Value.Date;
            var endDate = searchDto.EndDate == null ? DateTime.Now.Date.AddDays(1).Date : searchDto.EndDate.Value.AddDays(1).Date;
            var result =  dalOpertionLog.GetAll()
                .Where(e => e.CreateDate >= startDate && e.CreateDate < endDate)
                .Where(e => string.IsNullOrEmpty(searchDto.Keyword) || e.RouteAddress.Contains(searchDto.Keyword))
                .Where(e => !searchDto.RequestType.HasValue || e.RequestType == searchDto.RequestType)
                .Where(e => !searchDto.Code.HasValue || e.Code == searchDto.Code)
                .OrderByDescending(e=>e.CreateDate);
            FxPageInfo<OperationLogInfoDto> fxPageInfo = new FxPageInfo<OperationLogInfoDto>();
            fxPageInfo.TotalCount = result.Count();
            fxPageInfo.List = result.Skip((searchDto.PageNum - 1) * searchDto.PageSize).Take(searchDto.PageSize)
            .Select(e => new OperationLogInfoDto
            {
                RouteAddress = e.RouteAddress,
                RequestTypeText = ServiceClass.GetRequestTypeText(e.RequestType),
                Code=e.Code,
                Parameters=e.Parameters,
                Message=e.Message,
                OperaterName=e.OperationBy==null?"游客访问": dalAmiyaEmployee.GetAll().Where(a=>a.Id==e.OperationBy).SingleOrDefault().Name,
                CreateDate=e.CreateDate
            }).ToList();
            return fxPageInfo;
        }
    }
}