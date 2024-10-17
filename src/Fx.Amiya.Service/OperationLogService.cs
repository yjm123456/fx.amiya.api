using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.OperationLog;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class OperationLogService : IOperationLogService
    {
        private readonly IDalOpertionLog dalOpertionLog;
        private readonly IDalAmiyaEmployee dalAmiyaEmployee;
        private readonly IConfiguration configuration;

        public OperationLogService(IDalOpertionLog dalOpertionLog, IDalAmiyaEmployee dalAmiyaEmployee, IConfiguration configuration)
        {
            this.dalOpertionLog = dalOpertionLog;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
            this.configuration = configuration;
        }

        public async Task AddOperationLogAsync(OperationAddDto operationAdd)
        {
            OperationLog operationLog = new OperationLog();
            operationLog.Id = Guid.NewGuid().ToString().Replace("-", "");
            operationLog.RouteAddress = operationAdd.RouteAddress;
            operationLog.RequestType = operationAdd.RequestType;
            var parameters = operationAdd.Parameters;
            //字符串大于5000字节后截取
            if (!string.IsNullOrEmpty(parameters) && parameters.Length > 5000)
            {
                parameters = parameters.Substring(0, 4999);
            }
            operationLog.Parameters = parameters;
            operationLog.Code = operationAdd.Code;
            var message = operationAdd.Message;
            //字符串大于5000字节后截取
            if (!string.IsNullOrEmpty(message) && message.Length > 5000)
            {
                message = message.Substring(0, 4999);
            }
            operationLog.Message = message;
            operationLog.OperationBy = operationAdd.OperationBy;
            operationLog.CreateDate = DateTime.Now;
            operationLog.Valid = true;
            operationLog.Sounrce = operationAdd.Source;
            string context = configuration.GetConnectionString("MySqlConnectionString");
            MySqlConnection addOrderInfo = new MySqlConnection(context);
            addOrderInfo.Open();
            string addSql = $"INSERT INTO `tbl_system_operation_log` (`id`, `route_address`, `request_type`, `code`, `parameters`, `message`, `create_date`,`operation_by`, `valid`) VALUES('{operationLog.Id}', '{operationLog.RouteAddress}', '{operationLog.RequestType}', '{operationLog.Code}', '{operationLog.Parameters}', '{operationLog.Message}', '{operationLog.CreateDate}',{operationLog.OperationBy} ,1);";
            MySqlCommand addCmd = new MySqlCommand(addSql, addOrderInfo);
            addCmd.ExecuteNonQuery();
            addOrderInfo.Close();
            

            //await dalOpertionLog.AddAsync(operationLog, true);

        }

        public async Task<FxPageInfo<OperationLogInfoDto>> GetListByPageAsync(OperationLogSearchDto searchDto)
        {
            var startDate = searchDto.StartDate == null ? DateTime.Now.Date : searchDto.StartDate.Value.Date;
            var endDate = searchDto.EndDate == null ? DateTime.Now.Date.AddDays(1).Date : searchDto.EndDate.Value.AddDays(1).Date;
            var result = dalOpertionLog.GetAll()
                .Where(e => e.CreateDate >= startDate && e.CreateDate < endDate)
                .Where(e => string.IsNullOrEmpty(searchDto.RouteAddress) || e.RouteAddress.Contains(searchDto.RouteAddress))
                .Where(e => string.IsNullOrEmpty(searchDto.Parameters) || e.Parameters.Contains(searchDto.Parameters))
                .Where(e => !searchDto.RequestType.HasValue || e.RequestType == searchDto.RequestType)
                .Where(e => !searchDto.Code.HasValue || e.Code == searchDto.Code)
                .Where(e => !searchDto.Source.HasValue || e.Sounrce == searchDto.Source)
                .OrderByDescending(e => e.CreateDate);
            FxPageInfo<OperationLogInfoDto> fxPageInfo = new FxPageInfo<OperationLogInfoDto>();
            fxPageInfo.TotalCount = result.Count();
            fxPageInfo.List = result.Skip((searchDto.PageNum - 1) * searchDto.PageSize).Take(searchDto.PageSize)
            .Select(e => new OperationLogInfoDto
            {
                RouteAddress = e.RouteAddress,
                RequestTypeText = ServiceClass.GetRequestTypeText(e.RequestType),
                SourceText = ServiceClass.GetRequestSourceText(e.Sounrce.Value),
                Code = e.Code,
                Parameters = e.Parameters,
                Message = e.Message,
                OperaterName = e.OperationBy == null ? "游客访问" : dalAmiyaEmployee.GetAll().Where(a => a.Id == e.OperationBy).SingleOrDefault().Name,
                CreateDate = e.CreateDate
            }).ToList();
            return fxPageInfo;
        }

        public List<BaseKeyValueDto<int>> GetRequestTypeNameList()
        {
            var showDirectionTypes = Enum.GetValues(typeof(RequestType));
            List<BaseKeyValueDto<int>> requestTypeList = new List<BaseKeyValueDto<int>>();
            foreach (var item in showDirectionTypes)
            {
                BaseKeyValueDto<int> requestType = new BaseKeyValueDto<int>();
                requestType.Key = Convert.ToInt32(item);
                requestType.Value = ServiceClass.GetRequestTypeText(Convert.ToInt32(item));
                requestTypeList.Add(requestType);
            }
            return requestTypeList;
        }
        public List<BaseKeyValueDto<int>> GetRequestSourceNameList()
        {
            var showDirectionTypes = Enum.GetValues(typeof(RequestSource));
            List<BaseKeyValueDto<int>> requestTypeList = new List<BaseKeyValueDto<int>>();
            foreach (var item in showDirectionTypes)
            {
                BaseKeyValueDto<int> requestType = new BaseKeyValueDto<int>();
                requestType.Key = Convert.ToInt32(item);
                requestType.Value = ServiceClass.GetRequestSourceText(Convert.ToInt32(item));
                requestTypeList.Add(requestType);
            }
            return requestTypeList;
        }
    }
}
