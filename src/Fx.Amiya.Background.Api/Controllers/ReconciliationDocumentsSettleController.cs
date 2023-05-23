
using Fx.Amiya.Background.Api.Vo.ReconciliationDocuments;
using Fx.Amiya.Background.Api.Vo.ReconciliationDocuments.Input;
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
    /// 【新】财务对账单板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ReconciliationDocumentsSettleController : ControllerBase
    {
        private IBillService billService;
        private IOperationLogService operationLogService;
        private IHttpContextAccessor httpContextAccessor;
        //private IRecommandDocumentSettleService reconciliationDocumentsSettleService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="billService"></param>
        public ReconciliationDocumentsSettleController(IBillService billService, IOperationLogService operationLogService, IHttpContextAccessor httpContextAccessor)
        {
            //this.reconciliationDocumentsSettleService = reconciliationDocumentsSettleService;
            this.billService = billService;
            this.operationLogService = operationLogService;
            this.httpContextAccessor = httpContextAccessor;
        }



        /// <summary>
        /// 分页获取对账单审核记录
        /// </summary>
        /// <param name="startDate">开始时间（可空）</param>
        /// <param name="endDate">结束时间（可空）</param>
        /// <param name="isSettle">是否回款（可空）</param>
        /// <param name="accountType">对账单类型（可空）</param>
        /// <param name="chooseHospitalId">选中医院id（0查询）维多连天美之外的</param>
        /// <param name="keyword">关键词（对账单编号，订单号，成交编号；支持模糊查询）</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<FxPageInfo<ReconciliationDocumentsSettleVo>>> GetListAsync(DateTime? startDate, DateTime? endDate, bool? isSettle, bool? accountType, int chooseHospitalId, string keyword, int pageNum, int pageSize)
        {
            try
            {
                var q = await billService.GetSettleListByPageAsync(startDate, endDate, isSettle, accountType, chooseHospitalId, keyword, pageNum, pageSize);

                var reconciliationDocumentsSettle = from d in q.List
                                                    select new ReconciliationDocumentsSettleVo
                                                    {
                                                        RecommandDocumentId = d.RecommandDocumentId,
                                                        HospitalName = d.HospitalName,
                                                        OrderId = d.OrderId,
                                                        DealInfoId = d.DealInfoId,
                                                        IsCerateBill = d.IsCerateBill == true ? "是" : "否",
                                                        BelongCompany = d.BelongCompany,
                                                        BelongCompany2 = d.BelongCompany2,
                                                        DealDate = d.DealDate,
                                                        GoodsName = d.GoodsName,
                                                        Phone = d.Phone,
                                                        OrderFromText = d.OrderFromText,
                                                        OrderPrice = d.OrderPrice,
                                                        IsOldCustomerText = d.IsOldCustomerText,
                                                        InformationPrice = d.InformationPrice,
                                                        SystemUpdatePrice = d.SystemUpdatePrice,
                                                        ReturnBackPrice = d.ReturnBackPrice,
                                                        CreateDate = d.CreateDate,
                                                        IsSettle = d.IsSettle == true ? "是" : "否",
                                                        SettleDate = d.SettleDate,
                                                        RecolicationPrice = d.RecolicationPrice,
                                                        CreateEmpName = d.CreateEmpName,
                                                        CreateByEmpName = d.CreateByEmpName,
                                                        AccountTypeText = d.AccountTypeText,
                                                        AccountPrice = d.AccountPrice,
                                                        BelongEmpName = d.BelongEmpName,
                                                        BelongLiveAnchor = d.BelongLiveAnchor
                                                    };

                FxPageInfo<ReconciliationDocumentsSettleVo> reconciliationDocumentsSettleResult = new FxPageInfo<ReconciliationDocumentsSettleVo>();
                reconciliationDocumentsSettleResult.List = reconciliationDocumentsSettle.ToList();
                reconciliationDocumentsSettleResult.TotalCount = q.TotalCount;
                reconciliationDocumentsSettleResult.PageSize = pageSize;
                reconciliationDocumentsSettleResult.CurrentPageIndex = pageNum;
                return ResultData<FxPageInfo<ReconciliationDocumentsSettleVo>>.Success().AddData("reconciliationDocumentsSettleInfo", reconciliationDocumentsSettleResult);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<ReconciliationDocumentsSettleVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 导出对账单审核记录
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>

        [HttpGet("ExportReconciliationDocumentsDetails")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> InternalxportReconciliationDocumentsSettle([FromQuery] QueryExportReconciliationDocumentsDetailsVo query)
        {
            OperationAddDto operationAddDto = new OperationAddDto();
            operationAddDto.Code = 0;
            try
            {
                var isHidePhone = true;
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }
                operationAddDto.OperationBy = employeeId;
                if (!query.StartDate.HasValue && !query.EndDate.HasValue)
                { throw new Exception("请选择时间进行查询"); }
                if (query.StartDate.HasValue && query.EndDate.HasValue)
                {
                    if ((query.EndDate.Value - query.StartDate.Value).TotalDays > 31)
                    {
                        throw new Exception("开始时间与结束时间不能超过一个月，请重新选择后再进行查询！");
                    }
                }
                var res = new List<ReconciliationDocumentsSettleVo>();
                var q = await billService.ExportSettleListByPageAsync(query.StartDate, query.EndDate, query.IsSettle, query.AccountType, query.ChooseHospitalId, query.Keyword, isHidePhone);

                var reconciliationDocumentsSettle = from d in q
                                                    select new ReconciliationDocumentsSettleVo
                                                    {
                                                        RecommandDocumentId = d.RecommandDocumentId,
                                                        HospitalName = d.HospitalName,
                                                        OrderId = d.OrderId,
                                                        IsCerateBill = d.IsCerateBill == true ? "是" : "否",
                                                        BelongCompany = d.BelongCompany,
                                                        BelongCompany2 = d.BelongCompany2,
                                                        DealInfoId = d.DealInfoId,
                                                        DealDate = d.DealDate,
                                                        GoodsName = d.GoodsName,
                                                        Phone = d.Phone,
                                                        OrderFromText = d.OrderFromText,
                                                        OrderPrice = d.OrderPrice,
                                                        IsOldCustomerText = d.IsOldCustomerText,
                                                        InformationPrice = d.InformationPrice,
                                                        SystemUpdatePrice = d.SystemUpdatePrice,
                                                        ReturnBackPrice = d.ReturnBackPrice,
                                                        CreateDate = d.CreateDate,
                                                        IsSettle = d.IsSettle == true ? "是" : "否",
                                                        SettleDate = d.SettleDate,
                                                        RecolicationPrice = d.RecolicationPrice,
                                                        CreateEmpName = d.CreateEmpName,
                                                        CreateByEmpName = d.CreateByEmpName,
                                                        AccountTypeText = d.AccountTypeText,
                                                        AccountPrice = d.AccountPrice,
                                                        BelongEmpName = d.BelongEmpName,
                                                        BelongLiveAnchor = d.BelongLiveAnchor
                                                    };

                res = reconciliationDocumentsSettle.ToList();
                var stream = ExportExcelHelper.ExportExcel(res);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "对账单审核记录.xls");
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

    }
}
