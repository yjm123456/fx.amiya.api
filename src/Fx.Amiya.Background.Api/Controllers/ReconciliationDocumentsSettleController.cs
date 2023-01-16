
using Fx.Amiya.Background.Api.Vo.ReconciliationDocuments;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 财务对账单（仿美呗版）板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ReconciliationDocumentsSettleController : ControllerBase
    {
        private IRecommandDocumentSettleService reconciliationDocumentsSettleService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="reconciliationDocumentsSettleService"></param>
        public ReconciliationDocumentsSettleController(IRecommandDocumentSettleService reconciliationDocumentsSettleService)
        {
            this.reconciliationDocumentsSettleService = reconciliationDocumentsSettleService;
        }



        /// <summary>
        /// 分页获取对账单审核记录
        /// </summary>
        /// <param name="startDate">开始时间（可空）</param>
        /// <param name="endDate">结束时间（可空）</param>
        /// <param name="isSettle">是否回款（可空）</param>
        /// <param name="accountType">对账单类型（可空）</param>
        /// <param name="keyword">关键词（对账单编号，订单号，成交编号；支持模糊查询）</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<FxPageInfo<ReconciliationDocumentsSettleVo>>> GetListAsync(DateTime? startDate, DateTime? endDate, bool? isSettle, bool? accountType, string keyword, int pageNum, int pageSize)
        {
            try
            {
                var q = await reconciliationDocumentsSettleService.GetListByPageAsync(startDate, endDate, isSettle, accountType, keyword, pageNum, pageSize);

                var reconciliationDocumentsSettle = from d in q.List
                                                    select new ReconciliationDocumentsSettleVo
                                                    {
                                                        RecommandDocumentId = d.RecommandDocumentId,
                                                        OrderId = d.OrderId,
                                                        DealInfoId = d.DealInfoId,
                                                        OrderFromText = d.OrderFromText,
                                                        ReturnBackPrice = d.ReturnBackPrice,
                                                        CreateDate = d.CreateDate,
                                                        IsSettle = d.IsSettle,
                                                        SettleDate = d.SettleDate,
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
        /// <param name="startDate">开始时间（不可空）</param>
        /// <param name="endDate">结束时间（不可空）</param>
        /// <param name="isSettle">是否回款（可空）</param>
        /// <param name="accountType">对账单类型（可空）</param>
        /// <param name="keyword">关键词（对账单编号，订单号，成交编号；支持模糊查询）</param>
        /// <returns></returns>

        [HttpGet("ExportReconciliationDocumentsDetails")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> InternalxportReconciliationDocumentsSettle(DateTime? startDate, DateTime? endDate, bool? isSettle, bool? accountType, string keyword)
        {
            if (!startDate.HasValue && !endDate.HasValue)
            { throw new Exception("请选择时间进行查询"); }
            if (startDate.HasValue && endDate.HasValue)
            {
                if ((endDate.Value - startDate.Value).TotalDays > 31)
                {
                    throw new Exception("开始时间与结束时间不能超过一个月，请重新选择后再进行查询！");
                }
            }
            var res = new List<ReconciliationDocumentsSettleVo>();
            var q = await reconciliationDocumentsSettleService.ExportListByPageAsync(startDate, endDate, isSettle, accountType, keyword);

            var reconciliationDocumentsSettle = from d in q
                                                select new ReconciliationDocumentsSettleVo
                                                {
                                                    RecommandDocumentId = d.RecommandDocumentId,
                                                    OrderId = d.OrderId,
                                                    DealInfoId = d.DealInfoId,
                                                    OrderFromText = d.OrderFromText,
                                                    ReturnBackPrice = d.ReturnBackPrice,
                                                    CreateDate = d.CreateDate,
                                                    IsSettle = d.IsSettle,
                                                    SettleDate = d.SettleDate,
                                                    CreateByEmpName = d.CreateByEmpName,
                                                    AccountTypeText = d.AccountTypeText,
                                                    AccountPrice = d.AccountPrice,
                                                    BelongEmpName = d.BelongEmpName,
                                                    BelongLiveAnchor = d.BelongLiveAnchor
                                                };

            res = reconciliationDocumentsSettle.ToList();
            var stream = ExportExcelHelper.ExportExcel(res);
            var result = File(stream, "application/vnd.ms-excel", $"" + startDate.Value.ToString("yyyy年MM月dd日") + "-" + endDate.Value.ToString("yyyy年MM月dd日") + "对账单审核记录.xls");
            return result;
        }

    }
}
