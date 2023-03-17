using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.OperationLog;
using Fx.Amiya.Dto.OperationLog;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 操作日志
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class OperationLogController : ControllerBase
    {
        private readonly IOperationLogService operatonLogService;

        public OperationLogController(IOperationLogService operatonLogService)
        {
            this.operatonLogService = operatonLogService;
        }


        /// <summary>
        /// 获取操作日志记录
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<OperationLogInfoVo>>> GetListByPage([FromQuery]SearchVo search) {
            OperationLogSearchDto searchDto = new OperationLogSearchDto();
            searchDto.StartDate = search.StartDate;
            searchDto.EndDate = search.EndDate;
            searchDto.RouteAddress = search.RouteAddress;
            searchDto.Parameters = search.Parameters;
            searchDto.RequestType = search.RequestType;
            searchDto.Code = search.Code;
            searchDto.PageNum = search.PageNum;
            searchDto.PageSize = search.PageSize;
            var result=await operatonLogService.GetListByPageAsync(searchDto);
            FxPageInfo<OperationLogInfoVo> fxPageInfo = new FxPageInfo<OperationLogInfoVo>();
            fxPageInfo.TotalCount = result.TotalCount;
            fxPageInfo.List = result.List.Select(e => new OperationLogInfoVo
            {
                RouteAddress = e.RouteAddress,
                RequestTypeText = e.RequestTypeText,
                Code = e.Code,
                Parameters = e.Parameters,
                Message = e.Message,
                OperaterName = e.OperaterName,
                CreateDate = e.CreateDate
            }).ToList();
            return ResultData<FxPageInfo<OperationLogInfoVo>>.Success().AddData("log", fxPageInfo);
        }
        /// <summary>
        /// 获取请求类型名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("nameList")]
        public async Task<ResultData<List<BaseIdAndNameVo<int>>>> GetRequestTypeNameListAsync() {
            var nameList= operatonLogService.GetRequestTypeNameList();
            var result= nameList.Select(e=>new BaseIdAndNameVo<int> { 
                Id=e.Key,
                Name=e.Value
            }).ToList();
            return ResultData<List<BaseIdAndNameVo<int>>>.Success().AddData("nameList", result);
            
        }
    }
}
