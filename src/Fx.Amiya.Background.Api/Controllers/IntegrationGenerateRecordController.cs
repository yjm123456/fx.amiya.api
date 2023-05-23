using Fx.Amiya.Background.Api.Vo.CustomerConsumptionCredentials.Input;
using Fx.Amiya.Background.Api.Vo.IntegrationGenerateRecord;
using Fx.Amiya.Background.Api.Vo.IntegrationGenerateRecord.Result;
using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Dto.Integration;
using Fx.Amiya.Dto.OperationLog;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 积分发放记录
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class IntegrationGenerateRecordController : ControllerBase
    {
        private readonly IIntegrationGenerateRecordService integrationGenerateRecordService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IIntegrationAccount integrationAccountService;
        private readonly IOperationLogService operationLogService;

        public IntegrationGenerateRecordController(IIntegrationGenerateRecordService integrationGenerateRecordService, IHttpContextAccessor httpContextAccessor, IIntegrationAccount integrationAccountService, IOperationLogService operationLogService)
        {
            this.integrationGenerateRecordService = integrationGenerateRecordService;
            this.httpContextAccessor = httpContextAccessor;
            this.integrationAccountService = integrationAccountService;
            this.operationLogService = operationLogService;
        }
        /// <summary>
        /// 积分列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<IntegrationGenerateRecordListVo>>> List(string keyword,DateTime? startDate,DateTime? endDate,int pageNum,int pageSize) {
            FxPageInfo<IntegrationGenerateRecordListVo> fxPageInfo = new FxPageInfo<IntegrationGenerateRecordListVo>();
            var record= await integrationGenerateRecordService.GetAllIntegrationgenerationRecordAsync(keyword,startDate,endDate,pageNum,pageSize);
            fxPageInfo.TotalCount = record.TotalCount;
            fxPageInfo.List = record.List.Select(e => new IntegrationGenerateRecordListVo
            {
                Id=e.Id,
                CustomerId=e.CustomerId,
                Phone=e.Phone,
                CreateDate=e.CreateDate,
                TypeText=e.TypeText,
                Quantity=e.Quantity,
                OrderId=e.OrderId,
                ConsumptionAmount=e.ConsumptionAmount,
                Percent=e.Percent,
                StockQuantity=e.StockQuantity,
                AccountBalance=e.AccountBalance,
                HandleBy=string.IsNullOrEmpty(e.HandleBy)? "系统发放" : e.HandleBy
            }).ToList();
            return ResultData<FxPageInfo<IntegrationGenerateRecordListVo>>.Success().AddData("recordList", fxPageInfo);
        }
        /// <summary>
        /// 根据条件导出积分发放信息
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns></returns>
        [HttpGet("exportRecordList")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> ExportRecordListAsync([FromQuery] QueryExportRecordList query)
        {
            OperationAddDto operationAddDto = new OperationAddDto();
            operationAddDto.Code = 0;
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                operationAddDto.OperationBy = employeeId;
                var record = await integrationGenerateRecordService.ExportIntegrationgenerationRecordAsync(query.Keyword, query.StartDate, query.EndDate);
                
                var exportRecord = record.Select(e => new IntegrationGenerateRecordExportVo
                {
                    Phone = e.Phone,
                    CreateDate = e.CreateDate,
                    TypeText = e.TypeText,
                    Quantity = e.Quantity,
                    OrderId = e.OrderId,
                    ConsumptionAmount = e.ConsumptionAmount,
                    Percent = e.Percent,
                    StockQuantity = e.StockQuantity,
                    AccountBalance = e.AccountBalance,
                    HandleBy = string.IsNullOrEmpty(e.HandleBy) ? "系统发放" : e.HandleBy
                }).ToList();
                var stream = ExportExcelHelper.ExportExcel(exportRecord);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "发票.xls");
                return result;
            }
            catch (Exception err)
            {
                operationAddDto.Code = -1;
                operationAddDto.Message = err.Message.ToString();
                throw new Exception(err.Message.ToString());
            }
            finally
            {
                
                operationAddDto.Parameters = JsonConvert.SerializeObject(query);
                operationAddDto.RequestType = (int)RequestType.Export;
                operationAddDto.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationAddDto);
            }
        }
        /// <summary>
        /// 修改积分
        /// </summary>
        /// <returns></returns>
        [HttpPost("editIntegrationGenerateRecord")]
        public async Task<ResultData> EditIntegrationGenerateRecord(EditIntegrationgenerationVo edit) {
           var balance=await  integrationAccountService.GetIntegrationBalanceByCustomerIDAsync(edit.CustomerId);
            if (balance < edit.Quantity) throw new Exception($"当前用户的积分余额为{balance},扣除积分数量不能大于账户积分余额！");
            UseIntegrationDto useIntegrationDto = new UseIntegrationDto();
            useIntegrationDto.CustomerId = edit.CustomerId;
            useIntegrationDto.OrderId = "";
            useIntegrationDto.Date = DateTime.Now;
            useIntegrationDto.UseQuantity = (decimal)edit.Quantity;
            useIntegrationDto.Type = 1;
            await integrationAccountService.UseByGoodsConsumption(useIntegrationDto);
            return ResultData.Success();
        }

    }
}
