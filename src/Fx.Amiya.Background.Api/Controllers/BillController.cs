using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.Bill;
using Fx.Amiya.Background.Api.Vo.Bill.Input;
using Fx.Amiya.Background.Api.Vo.ReconciliationDocuments;
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
    /// 发票
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private IBillService billService;
        private IHttpContextAccessor _httpContextAccessor;
        private IOperationLogService operationLogService;

        public BillController(IHttpContextAccessor httpContextAccessor, IBillService billService, IOperationLogService operationLogService)
        {
            this.billService = billService;
            _httpContextAccessor = httpContextAccessor;
            this.operationLogService = operationLogService;
        }



        /// <summary>
        /// 根据条件获取发票信息
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="keyWord">关键词（可搜索费用备注，开票事由）</param>
        /// <param name="hospitalId">客户id</param>
        /// <param name="billType">票据类型（医美/其他）</param>
        /// <param name="returnBackState"></param>
        /// <param name="companyId">回款状态（未回款/回款中/已回款）</param>
        /// <param name="valid">是否作废（1正常，0作废）</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<BillVo>>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, int? hospitalId, bool? valid, int? billType, int? returnBackState, string companyId, string keyWord, int pageNum, int pageSize)
        {
            try
            {
                var q = await billService.GetListAsync(startDate, endDate, hospitalId, valid, billType, returnBackState, companyId, keyWord, pageNum, pageSize);
                var bill = from d in q.List
                           select new BillVo
                           {
                               Id = d.Id,
                               HospitalId = d.HospitalId,
                               HospitalName = d.HospitalName,
                               BillPrice = d.BillPrice,
                               TaxRate = d.TaxRate,
                               TaxPrice = Math.Round(d.TaxPrice, 2),
                               NotInTaxPrice = Math.Round(d.NotInTaxPrice, 2),
                               OtherPrice = d.OtherPrice,
                               OtherPriceRemark = d.OtherPriceRemark,
                               CollectionCompanyId = d.CollectionCompanyId,
                               CollectionCompanyName = d.CollectionCompanyName,
                               BelongStartTime = d.BelongStartTime,
                               BelongEndTime = d.BelongEndTime,
                               BillType = d.BillType,
                               BillTypeText = d.BillTypeText,
                               CreateBillReason = d.CreateBillReason,
                               ReturnBackState = d.ReturnBackState,
                               ReturnBackStateText = d.ReturnBackStateText,
                               ReturnBackPrice = d.ReturnBackPrice,
                               CreateDate = d.CreateDate,
                               CreateBy = d.CreateBy,
                               CreateByEmployeeName = d.CreateByEmployeeName,
                               UpdateDate = d.UpdateDate,
                               Valid = d.Valid,
                               ValidText = d.ValidText,
                               DeleteDate = d.DeleteDate,
                               ReturnBackPriceDate = d.ReturnBackPriceDate
                           };

                FxPageInfo<BillVo> tagPageInfo = new FxPageInfo<BillVo>();
                tagPageInfo.TotalCount = q.TotalCount;
                tagPageInfo.List = bill;

                return ResultData<FxPageInfo<BillVo>>.Success().AddData("bill", tagPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<BillVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 根据条件导出发票信息
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="keyWord">关键词（可搜索费用备注，开票事由）</param>
        /// <param name="hospitalId">客户id</param>
        /// <param name="billType">票据类型（医美/其他）</param>
        /// <param name="returnBackState"></param>
        /// <param name="companyId">回款状态（未回款/回款中/已回款）</param>
        /// <param name="valid">是否作废（1正常，0作废）</param>
        /// <returns></returns>
        [HttpGet("exportBillList")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> ExportBillListAsync([FromQuery] QueryExportBillListVo query)
        {
            OperationAddDto operationAddDto = new OperationAddDto();
            operationAddDto.Code = 0;
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                operationAddDto.OperationBy = employeeId;
                var q = await billService.ExportBillListAsync(query.StartDate, query.EndDate, query.HospitalId, query.Valid, query.BillType, query.ReturnBackState, query.CompanyId, query.KeyWord);
                var bill = from d in q
                           select new ExportBillVo
                           {
                               Id = d.Id,
                               HospitalName = d.HospitalName,
                               BillPrice = d.BillPrice,
                               TaxRate = d.TaxRate,
                               TaxPrice = Math.Round(d.TaxPrice, 2),
                               NotInTaxPrice = Math.Round(d.NotInTaxPrice, 2),
                               OtherPrice = d.OtherPrice,
                               OtherPriceRemark = d.OtherPriceRemark,
                               CollectionCompanyName = d.CollectionCompanyName,
                               BelongDate = d.BelongStartTime.ToString("yyyy-MM-dd") + "  -  " + d.BelongEndTime.ToString("yyyy-MM-dd"),
                               BillTypeText = d.BillTypeText,
                               CreateBillReason = d.CreateBillReason,
                               ReturnBackStateText = d.ReturnBackStateText,
                               ReturnBackPrice = d.ReturnBackPrice,
                               CreateDate = d.CreateDate,
                               CreateByEmployeeName = d.CreateByEmployeeName,
                               ValidText = d.ValidText,
                               ReturnBackPriceDate = d.ReturnBackPriceDate
                           };
                var exportOrder = bill.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportOrder);
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
                operationAddDto.Message = "";
                operationAddDto.Parameters = JsonConvert.SerializeObject(query);
                operationAddDto.RequestType = (int)RequestType.Export;
                operationAddDto.RouteAddress = _httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationAddDto);
            }
        }




        /// <summary>
        /// 添加发票
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAsync(AddBillVo addVo)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                AddBillDto addDto = new AddBillDto();
                addDto.HospitalId = addVo.HospitalId;
                addDto.DealPrice = addVo.DealPrice;
                addDto.InformationPrice = addVo.InformationPrice;
                addDto.SystemUpdatePrice = addVo.SystemUpdatePrice;
                addDto.BillPrice = addVo.BillPrice;
                addDto.TaxRate = addVo.TaxRate;
                addDto.TaxPrice = addVo.TaxPrice;
                addDto.NotInTaxPrice = addVo.NotInTaxPrice;
                addDto.OtherPrice = addVo.OtherPrice;
                addDto.CreateDate = addVo.CreateDate;
                addDto.OtherPriceRemark = addVo.OtherPriceRemark;
                addDto.CollectionCompanyId = addVo.CollectionCompanyId;
                addDto.BelongStartTime = addVo.BelongStartTime;
                addDto.BelongEndTime = addVo.BelongEndTime;
                addDto.BillType = addVo.BillType;
                addDto.CreateBillReason = addVo.CreateBillReason;
                addDto.CreateBy = employeeId;
                addDto.ReconciliationDocumentsIdList = addVo.ReconciliationDocumentsIdList;
                await billService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据发票编号获取发票信息
        /// </summary>
        /// <param name="id">发票编号</param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<BillVo>> GetByIdAsync(string id)
        {
            try
            {
                var bill = await billService.GetByIdAsync(id);
                BillVo billVo = new BillVo();
                billVo.Id = bill.Id;
                billVo.HospitalId = bill.HospitalId;
                billVo.HospitalName = bill.HospitalName;
                billVo.BillPrice = bill.BillPrice;
                billVo.TaxRate = bill.TaxRate;
                billVo.TaxPrice = bill.TaxPrice;
                billVo.NotInTaxPrice = bill.NotInTaxPrice;
                billVo.OtherPrice = bill.OtherPrice;
                billVo.OtherPriceRemark = bill.OtherPriceRemark;
                billVo.CollectionCompanyId = bill.CollectionCompanyId;
                billVo.CollectionCompanyName = bill.CollectionCompanyName;
                billVo.BelongStartTime = bill.BelongStartTime;
                billVo.BelongEndTime = bill.BelongEndTime;
                billVo.BillType = bill.BillType;
                billVo.BillTypeText = bill.BillTypeText;
                billVo.CreateBillReason = bill.CreateBillReason;
                billVo.ReturnBackState = bill.ReturnBackState;
                billVo.ReturnBackStateText = bill.ReturnBackStateText;
                billVo.CreateDate = bill.CreateDate;
                billVo.CreateBy = bill.CreateBy;
                billVo.CreateByEmployeeName = bill.CreateByEmployeeName;
                billVo.UpdateDate = bill.UpdateDate;
                billVo.Valid = bill.Valid;
                billVo.ValidText = bill.ValidText;
                billVo.DeleteDate = bill.DeleteDate;
                List<ReconciliationDocumentsVo> reconciliationDocumentsVos = new List<ReconciliationDocumentsVo>();
                foreach (var x in bill.ReconciliationDocumentsDtoList)
                {
                    ReconciliationDocumentsVo reconciliationDocumentsVo = new ReconciliationDocumentsVo();
                    reconciliationDocumentsVo.Id = x.Id;
                    reconciliationDocumentsVo.HospitalId = x.HospitalId;
                    reconciliationDocumentsVo.HospitalName = x.HospitalName;
                    reconciliationDocumentsVo.CustomerName = x.CustomerName;
                    reconciliationDocumentsVo.CustomerPhone = x.CustomerPhone;
                    reconciliationDocumentsVo.DealGoods = x.DealGoods;
                    reconciliationDocumentsVo.DealDate = x.DealDate;
                    reconciliationDocumentsVo.TotalDealPrice = x.TotalDealPrice;
                    reconciliationDocumentsVo.ReturnBackPricePercent = x.ReturnBackPricePercent;
                    reconciliationDocumentsVo.ReturnBackPrice = x.ReturnBackPrice;
                    reconciliationDocumentsVo.SystemUpdatePricePercent = x.SystemUpdatePricePercent;
                    reconciliationDocumentsVo.SystemUpdatePrice = x.SystemUpdatePrice;
                    reconciliationDocumentsVo.ReturnBackTotalPrice = x.TotalReconciliationDocumentsPrice;
                    reconciliationDocumentsVo.Remark = x.Remark;
                    reconciliationDocumentsVo.ReconciliationState = x.ReconciliationState;
                    reconciliationDocumentsVo.CreateBy = x.CreateBy;
                    reconciliationDocumentsVos.Add(reconciliationDocumentsVo);
                }
                billVo.reconciliationDocumentList = reconciliationDocumentsVos;
                return ResultData<BillVo>.Success().AddData("bill", billVo);
            }
            catch (Exception ex)
            {
                return ResultData<BillVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改发票信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateBillVo updateVo)
        {
            try
            {
                UpdateBillDto updateDto = new UpdateBillDto();
                updateDto.Id = updateVo.Id;
                updateDto.HospitalId = updateVo.HospitalId;
                updateDto.BillPrice = updateVo.BillPrice;
                updateDto.TaxRate = updateVo.TaxRate;
                updateDto.TaxPrice = updateVo.TaxPrice;
                updateDto.NotInTaxPrice = updateVo.NotInTaxPrice;
                updateDto.OtherPrice = updateVo.OtherPrice;
                updateDto.OtherPriceRemark = updateVo.OtherPriceRemark;
                updateDto.CollectionCompanyId = updateVo.CollectionCompanyId;
                updateDto.BelongStartTime = updateVo.BelongStartTime;
                updateDto.BelongEndTime = updateVo.BelongEndTime;
                updateDto.BillType = updateVo.BillType;
                updateDto.CreateBillDate = updateVo.CreateBillDate;
                updateDto.CreateBillReason = updateVo.CreateBillReason;

                await billService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 作废发票
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await billService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 发票回款
        /// </summary>
        /// <param name="billReturnBackPriceVo"></param>
        /// <returns></returns>
        [HttpPut("returnBakcPriceAsync")]
        [FxInternalAuthorize]
        public async Task<ResultData> ReturnBakcPriceAsync(AddBillReturnBackPriceVo billReturnBackPriceVo)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                BillReturnBackPriceDto billReturnBackPriceDto = new BillReturnBackPriceDto();
                billReturnBackPriceDto.ReturnBackDate = billReturnBackPriceVo.ReturnBackDate;
                billReturnBackPriceDto.Id = billReturnBackPriceVo.Id;
                billReturnBackPriceDto.ReturnBackPrice = billReturnBackPriceVo.ReturnBackPrice;
                billReturnBackPriceDto.CreateBy = employeeId;
                billReturnBackPriceDto.Remark = billReturnBackPriceVo.Remark;
                await billService.ReturnBakcPriceAsync(billReturnBackPriceDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 发票类型下拉框
        /// </summary>
        /// <returns></returns>
        [HttpGet("billTypeList")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetBillTypeAsync()
        {
            var billTypeList = from d in await billService.GetBillTypeListAsync()
                               select new BaseIdAndNameVo
                               {
                                   Id = d.Key,
                                   Name = d.Value
                               };
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("billTypeList", billTypeList.ToList());
        }

        /// <summary>
        /// 票据回款状态下拉框
        /// </summary>
        /// <returns></returns>
        [HttpGet("billReturnBackStateList")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetBillReturnBackStateAsync()
        {
            var billTypeList = from d in await billService.GetBillReturnBackStateTextListAsync()
                               select new BaseIdAndNameVo
                               {
                                   Id = d.Key,
                                   Name = d.Value
                               };
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("billReturnBackStateList", billTypeList.ToList());
        }

    }
}