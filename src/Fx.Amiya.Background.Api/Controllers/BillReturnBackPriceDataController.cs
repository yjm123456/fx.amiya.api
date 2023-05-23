using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.Bill;
using Fx.Amiya.Background.Api.Vo.Bill.Input;
using Fx.Amiya.Dto.Bill;
using Fx.Amiya.Dto.OperationLog;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 发票回款记录表
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class BillReturnBackPriceDataController : ControllerBase
    {
        private IBillReturnBackPriceDataService billReturnBackPriceDataService;
        private IHttpContextAccessor _httpContextAccessor;
        private IOperationLogService operationLogService;

        public BillReturnBackPriceDataController(IHttpContextAccessor httpContextAccessor, IBillReturnBackPriceDataService billReturnBackPriceDataService, IOperationLogService operationLogService)
        {
            this.billReturnBackPriceDataService = billReturnBackPriceDataService;
            _httpContextAccessor = httpContextAccessor;
            this.operationLogService = operationLogService;
        }



        /// <summary>
        /// 根据条件获取发票回款记录信息
        /// </summary>
        /// <param name="startDate">回款时间（起）</param>
        /// <param name="endDate">回款时间（止）</param>
        /// <param name="keyWord">关键词（支持模糊搜索票据单，备注）</param>
        /// <param name="hospitalId">客户id</param>
        /// <param name="returnBackState">回款状态（未回款/回款中/已回款）</param>
        /// <param name="companyId">收款公司id</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<BillReturnBackPriceDataVo>>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, int? hospitalId, int? returnBackState, string companyId, string keyWord, int pageNum, int pageSize)
        {
            try
            {
                var q = await billReturnBackPriceDataService.GetListAsync(startDate, endDate, hospitalId, returnBackState, companyId, keyWord, pageNum, pageSize);
                var billReturnBackPriceData = from d in q.List
                                              select new BillReturnBackPriceDataVo
                                              {
                                                  BillId = d.BillId,
                                                  HospitalName = d.HospitalName,
                                                  BillPrice = d.BillPrice,
                                                  CompanyName = d.CompanyName,
                                                  OtherPrice = d.OtherPrice,
                                                  ReturnBackStateText = d.ReturnBackStateText,
                                                  ReturnBackPrice = d.ReturnBackPrice,
                                                  ReturnBackDate = d.ReturnBackDate,
                                                  CreateDate = d.CreateDate,
                                                  Remark = d.Remark,
                                                  CreateByEmployeeName = d.CreateByEmployeeName,
                                              };

                FxPageInfo<BillReturnBackPriceDataVo> pageInfo = new FxPageInfo<BillReturnBackPriceDataVo>();
                pageInfo.TotalCount = q.TotalCount;
                pageInfo.List = billReturnBackPriceData;

                return ResultData<FxPageInfo<BillReturnBackPriceDataVo>>.Success().AddData("billReturnBackPriceData", pageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<BillReturnBackPriceDataVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 根据条件导出发票回款记录信息
        /// </summary>
        /// <param name="startDate">回款时间（起）</param>
        /// <param name="endDate">回款时间（止）</param>
        /// <param name="keyWord">关键词（支持模糊搜索票据单，备注）</param>
        /// <param name="hospitalId">客户id</param>
        /// <param name="returnBackState">回款状态（未回款/回款中/已回款）</param>
        /// <param name="companyId">收款公司id</param>
        /// <returns></returns>
        [HttpGet("exportBillReturnBackPriceDataList")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> ExportBillReturnBackPriceDataListAsync([FromQuery] QueryExportbillReturnBackPriceDataListVo query)
        {
            OperationAddDto operationAddDto = new OperationAddDto();
            operationAddDto.Code = 0;
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                operationAddDto.OperationBy = employeeId;
                var q = await billReturnBackPriceDataService.ExportListAsync(query.StartDate, query.EndDate, query.HospitalId, query.ReturnBackState, query.CompanyId, query.KeyWord);
                var billReturnBackPriceData = from d in q
                                              select new BillReturnBackPriceDataVo
                                              {
                                                  BillId = d.BillId,
                                                  HospitalName = d.HospitalName,
                                                  BillPrice = d.BillPrice,
                                                  CompanyName = d.CompanyName,
                                                  OtherPrice = d.OtherPrice,
                                                  ReturnBackStateText = d.ReturnBackStateText,
                                                  ReturnBackPrice = d.ReturnBackPrice,
                                                  ReturnBackDate = d.ReturnBackDate,
                                                  CreateDate = d.CreateDate,
                                                  Remark = d.Remark,
                                                  CreateByEmployeeName = d.CreateByEmployeeName,
                                              };

                List<BillReturnBackPriceDataVo> pageInfo = new List<BillReturnBackPriceDataVo>();
                pageInfo = billReturnBackPriceData.ToList();
                var stream = ExportExcelHelper.ExportExcel(pageInfo);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "发票回款记录.xls");
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
                operationAddDto.RouteAddress = _httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationAddDto);
            }
        }

    }
}