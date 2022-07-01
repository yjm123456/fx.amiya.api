
using Fx.Amiya.Background.Api.Vo.CallRecord;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Infrastructure.DataAccess.Mongodb.Standard;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class CallRecordsController : ControllerBase
    {
        private IMongoRepository<CallRecordVo> repository;
        private IAmiyaEmployeeService amiyaEmployeeService;
        private IAmiyaPositionInfoService amiyaPositionInfoService;
        private IHttpContextAccessor httpContextAccessor;
        public CallRecordsController(IMongoRepository<CallRecordVo> repository,
               IAmiyaEmployeeService amiyaEmployeeService,
               IAmiyaPositionInfoService amiyaPositionInfoService,
               IHttpContextAccessor httpContextAccessor)
        {
            this.repository = repository;
            this.amiyaEmployeeService = amiyaEmployeeService;
            this.amiyaPositionInfoService = amiyaPositionInfoService;
            this.httpContextAccessor = httpContextAccessor;
        }


        [HttpGet("byEmployeeId")]
        public async Task<ResultData<IPageInfo<CallRecordVo>>> GetCallRecordsByEmployeeId(int? employeeId, DateTime startDate, DateTime endDate, int pageSize, int pageNum)
        {
            startDate = startDate.Date;
            endDate = endDate.Date.AddDays(1);
            var filterBuilder = Builders<CallRecordVo>.Filter;
            FilterDefinition<CallRecordVo> filter;
            if (employeeId != null)
            {
                filter= filterBuilder.And(filterBuilder.Eq("EmployeeID", employeeId)& filterBuilder.Gte("Date", startDate) & filterBuilder.Lt("Date", endDate));
            }
            else
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                employeeId = Convert.ToInt32(employee.Id);
                var position = await amiyaPositionInfoService.GetByIdAsync(Convert.ToInt32(employee.PositionId));
                if (employee.IsCustomerService && position.IsDirector == false)
                {
                    filter= filterBuilder.And(filterBuilder.Eq("EmployeeID", employeeId)& filterBuilder.Gte("Date", startDate) & filterBuilder.Lt("Date", endDate));
                }
                else
                {
                    filter = filterBuilder.And(filterBuilder.Gte("Date", startDate) & filterBuilder.Lt("Date", endDate));
                }
            }
         
           // var filter = filterBuilder.And(filterBuilder.Gte("Date", startDate) & filterBuilder.Lt("Date", endDate));

            var result = await repository.FindBySpecificationWithPageAsync(filter, pageNum, pageSize);
            return ResultData<IPageInfo<CallRecordVo>>.Success().AddData("callRecords", result);
        }


        [HttpGet("byUserId")]
        public async Task<ResultData<IPageInfo<CallRecordVo>>> GetCallRecordsByUserId(string userId, DateTime? startDate, DateTime? endDate, int pageSize, int pageNum)
        {
            //var filterBuilder = Builders<CallRecordVo>.Filter;
            //FilterDefinition<CallRecordVo> filter = filterBuilder.Empty;
            //if (startDate != null)
            //{
            //    startDate = ((DateTime)startDate).Date;
            //    endDate = ((DateTime)endDate).Date.AddDays(1);
            //    filter = filterBuilder.Gte("Date", startDate) & filterBuilder.Lt("Date", endDate) & filterBuilder.In("CallNumber",["",""]);

            //}
            //else
            //{
            //    filter = filterBuilder.Eq("CallNumber", "");
            //}
            //var result = await repository.FindBySpecificationWithPageAsync(filter, pageNum, pageSize);
            //return ResultData<IPageInfo<CallRecordVo>>.Success().AddData("callRecords", result);
            throw new NotImplementedException();
        }

        [HttpGet("byPoneNumber")]
        public async Task<ResultData<IPageInfo<CallRecordVo>>> GetCallRecordsByPhoneNumber(string phoneNumber, DateTime? startDate, DateTime? endDate, int pageSize, int pageNum)
        {
            var filterBuilder = Builders<CallRecordVo>.Filter;
            FilterDefinition<CallRecordVo> filter = filterBuilder.Empty;
            if (startDate != null)
            {
                startDate = ((DateTime)startDate).Date;
                endDate = ((DateTime)endDate).Date.AddDays(1);
                filter = filterBuilder.Gte("Date", startDate) & filterBuilder.Lt("Date", endDate) & filterBuilder.Eq("CallNumber", phoneNumber);

            }
            else
            {
                filter = filterBuilder.Eq("CallNumber", phoneNumber);
            }
            var result = await repository.FindBySpecificationWithPageAsync(filter, pageNum, pageSize);
            return ResultData<IPageInfo<CallRecordVo>>.Success().AddData("callRecords", result);
        }


        [HttpGet("voiceDataById/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetVoiceDataAsync(string id)
        {
            var result = await repository.FindOneAsync(Builders<CallRecordVo>.Filter.Eq("ID", id), "Voice");
            var voiceData = result.Voice.Data;
            MemoryStream ms = new MemoryStream(voiceData);

            return new FileStreamResult(ms, "audio/mp3");
        }

    }
}
