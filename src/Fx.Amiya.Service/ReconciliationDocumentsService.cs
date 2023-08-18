using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.GoodsDemand;
using Fx.Amiya.Dto.HospitalInfo;
using Fx.Amiya.Dto.ReconciliationDocuments;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
using Fx.Infrastructure.DataAccess.EFCore;
using jos_sdk_net.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class ReconciliationDocumentsService : IReconciliationDocumentsService
    {
        private IDalReconciliationDocuments dalReconciliationDocuments;
        private IContentPlateFormOrderService contentPlateFormOrderService;
        private IRecommandDocumentSettleService recommandDocumentSettleService;
        private readonly IUnitOfWork _unitOfWork;
        private IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        private IOrderService orderService;
        private IUnCheckOrderService unCheckOrderService;
        private ICustomerHospitalConsumeService customerHospitalConsumeService;
        private IAmiyaEmployeeService amiyaEmployeeService;
        private ILiveAnchorService liveAnchorService;

        public ReconciliationDocumentsService(IDalReconciliationDocuments dalReconciliationDocuments,
            IContentPlateFormOrderService contentPlateFormOrderService,
            IUnCheckOrderService unCheckOrderService,
            IRecommandDocumentSettleService recommandDocumentSettleService,
            IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService,
            IOrderService orderService,
            ILiveAnchorService liveAnchorService,
            IAmiyaEmployeeService amiyaEmployeeService,
            ICustomerHospitalConsumeService customerHospitalConsumeService,
            IUnitOfWork unitOfWork)
        {
            this.dalReconciliationDocuments = dalReconciliationDocuments;
            _unitOfWork = unitOfWork;
            this.amiyaEmployeeService = amiyaEmployeeService;
            this.liveAnchorService = liveAnchorService;
            this.orderService = orderService;
            this.recommandDocumentSettleService = recommandDocumentSettleService;
            this.customerHospitalConsumeService = customerHospitalConsumeService;
            this.contentPlateFormOrderService = contentPlateFormOrderService;
            this.unCheckOrderService = unCheckOrderService;
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
        }



        public async Task<FxPageInfo<ReconciliationDocumentsDto>> GetListWithPageAsync(decimal? returnBackPricePercent, int? reconciliationState, DateTime? startDate, DateTime? endDate, DateTime? startDealDate, DateTime? endDealDate, string keyword, int? hospitalId, bool? isCreateBill, int pageNum, int pageSize)
        {
            try
            {
                DateTime startrq = new DateTime();
                DateTime endrq = new DateTime();
                DateTime startDealrq = new DateTime();
                DateTime endDealrq = new DateTime();
                if (startDate != null && endDate != null)
                {
                    startrq = ((DateTime)startDate);
                    endrq = ((DateTime)endDate).AddDays(1);

                }
                if (startDealDate != null && endDealDate != null)
                {
                    startDealrq = ((DateTime)startDealDate);
                    endDealrq = ((DateTime)endDealDate).AddDays(1);
                }
                var reconciliationDocuments = from d in dalReconciliationDocuments.GetAll().Include(x => x.HospitalEmployee).Include(x => x.HospitalInfo)
                                              where (string.IsNullOrWhiteSpace(keyword) || d.CustomerName.Contains(keyword) || d.CustomerPhone.Contains(keyword) || d.Id.Contains(keyword))
                                             && (!startDealDate.HasValue && !endDealDate.HasValue || d.DealDate >= startDealrq && d.DealDate <= endDealrq)
                                             && (!returnBackPricePercent.HasValue || d.ReturnBackPricePercent == returnBackPricePercent.Value)
                                             && (reconciliationState.HasValue ? d.ReconciliationState == reconciliationState.Value : (d.ReconciliationState == (int)ReconciliationDocumentsStateEnum.Successful || d.ReconciliationState == (int)ReconciliationDocumentsStateEnum.ReturnBackPriceSuccessful))
                                             && (!hospitalId.HasValue || d.HospitalId == hospitalId)
                                             && (!isCreateBill.HasValue || d.IsCreateBill == isCreateBill)
                                             && (!startDate.HasValue && !endDate.HasValue || d.CreateDate >= startrq.Date && d.CreateDate < endrq.Date)
                                             && d.Valid
                                              select new ReconciliationDocumentsDto
                                              {
                                                  Id = d.Id,
                                                  HospitalId = d.HospitalId,
                                                  HospitalName = d.HospitalInfo.Name,
                                                  CustomerName = d.CustomerName,
                                                  CustomerPhone = d.CustomerPhone,
                                                  DealGoods = d.DealGoods,
                                                  DealDate = d.DealDate,
                                                  TotalDealPrice = d.TotalDealPrice,
                                                  ReturnBackPricePercent = d.ReturnBackPricePercent,
                                                  SystemUpdatePricePercent = d.SystemUpdatePricePercent,
                                                  QuestionReason = d.QuestionReason,
                                                  Remark = d.Remark,
                                                  ReconciliationState = d.ReconciliationState,
                                                  ReconciliationStateText = ServiceClass.ReconciliationDocumentsStateText(d.ReconciliationState),
                                                  CreateBy = d.CreateBy,
                                                  CreateByName = d.HospitalEmployee.Name,
                                                  CreateDate = d.CreateDate,
                                                  UpdateDate = d.UpdateDate,
                                                  DeleteDate = d.DeleteDate,
                                                  IsCreateBill = d.IsCreateBill,
                                                  BillId = d.BillId,
                                                  Valid = d.Valid,
                                              };

                FxPageInfo<ReconciliationDocumentsDto> reconciliationDocumentsPageInfo = new FxPageInfo<ReconciliationDocumentsDto>();
                reconciliationDocumentsPageInfo.TotalCount = await reconciliationDocuments.CountAsync();
                reconciliationDocumentsPageInfo.List = await reconciliationDocuments.OrderByDescending(x => x.DealDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

                return reconciliationDocumentsPageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task<List<ReconciliationDocumentsDto>> ExportListWithPageAsync(decimal? returnBackPricePercent, int? reconciliationState, DateTime? startDate, DateTime? endDate, DateTime? startDealDate, DateTime? endDealDate, string keyword, int? hospitalId, bool? isCreateBill)
        {
            try
            {
                DateTime startrq = new DateTime();
                DateTime endrq = new DateTime();
                DateTime startDealrq = new DateTime();
                DateTime endDealrq = new DateTime();
                if (startDate != null && endDate != null)
                {
                    startrq = ((DateTime)startDate);
                    endrq = ((DateTime)endDate).AddDays(1);

                }
                if (startDealDate != null && endDealDate != null)
                {
                    startDealrq = ((DateTime)startDealDate);
                    endDealrq = ((DateTime)endDealDate).AddDays(1);
                }
                var reconciliationDocuments = from d in dalReconciliationDocuments.GetAll().Include(x => x.HospitalEmployee).Include(x => x.HospitalInfo)
                                              where (string.IsNullOrWhiteSpace(keyword) || d.CustomerName.Contains(keyword) || d.CustomerPhone.Contains(keyword))
                                             && (!startDealDate.HasValue && !endDealDate.HasValue || d.DealDate >= startDealrq && d.DealDate <= endDealrq)
                                             && (!returnBackPricePercent.HasValue || d.ReturnBackPricePercent == returnBackPricePercent.Value)
                                             && (reconciliationState.HasValue ? d.ReconciliationState == reconciliationState.Value : (d.ReconciliationState == (int)ReconciliationDocumentsStateEnum.Successful || d.ReconciliationState == (int)ReconciliationDocumentsStateEnum.ReturnBackPriceSuccessful))
                                             && (!isCreateBill.HasValue || d.IsCreateBill == isCreateBill)
                                             && (!hospitalId.HasValue || d.HospitalId == hospitalId)
                                             && (!startDate.HasValue && !endDate.HasValue || d.CreateDate >= startrq.Date && d.CreateDate < endrq.Date)
                                             && d.Valid
                                              select new ReconciliationDocumentsDto
                                              {
                                                  Id = d.Id,
                                                  HospitalId = d.HospitalId,
                                                  HospitalName = d.HospitalInfo.Name,
                                                  CustomerName = d.CustomerName,
                                                  CustomerPhone = d.CustomerPhone,
                                                  DealGoods = d.DealGoods,
                                                  DealDate = d.DealDate,
                                                  TotalDealPrice = d.TotalDealPrice,
                                                  ReturnBackPricePercent = d.ReturnBackPricePercent,
                                                  SystemUpdatePricePercent = d.SystemUpdatePricePercent,
                                                  QuestionReason = d.QuestionReason,
                                                  Remark = d.Remark,
                                                  ReconciliationState = d.ReconciliationState,
                                                  ReconciliationStateText = ServiceClass.ReconciliationDocumentsStateText(d.ReconciliationState),
                                                  CreateBy = d.CreateBy,
                                                  CreateByName = d.HospitalEmployee.Name,
                                                  CreateDate = d.CreateDate,
                                                  UpdateDate = d.UpdateDate,
                                                  DeleteDate = d.DeleteDate,
                                                  IsCreateBill = d.IsCreateBill,
                                                  BillId = d.BillId,
                                                  Valid = d.Valid,
                                              };

                List<ReconciliationDocumentsDto> reconciliationDocumentsPageInfo = new List<ReconciliationDocumentsDto>();
                reconciliationDocumentsPageInfo = await reconciliationDocuments.OrderByDescending(x => x.DealDate).ToListAsync();

                return reconciliationDocumentsPageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task AddAsync(List<AddReconciliationDocumentsDto> addDtoList)
        {
            _unitOfWork.BeginTransaction();


            try
            {
                foreach (var addDto in addDtoList)
                {

                    ReconciliationDocuments reconciliationDocuments = new ReconciliationDocuments();
                    reconciliationDocuments.Id = CreateOrderIdHelper.GetNextNumber();
                    reconciliationDocuments.HospitalId = addDto.HospitalId;
                    reconciliationDocuments.CustomerName = addDto.CustomerName;
                    reconciliationDocuments.CustomerPhone = addDto.CustomerPhone;
                    reconciliationDocuments.DealGoods = addDto.DealGoods;
                    reconciliationDocuments.DealDate = addDto.DealDate;
                    reconciliationDocuments.TotalDealPrice = addDto.TotalDealPrice;
                    reconciliationDocuments.ReturnBackPricePercent = addDto.ReturnBackPricePercent;
                    reconciliationDocuments.SystemUpdatePricePercent = addDto.SystemUpdatePricePercent;
                    reconciliationDocuments.Remark = addDto.Remark;
                    reconciliationDocuments.ReconciliationState = addDto.ReconciliationState;
                    reconciliationDocuments.CreateBy = addDto.CreateBy;
                    reconciliationDocuments.CreateDate = DateTime.Now;
                    reconciliationDocuments.Valid = true;
                    await dalReconciliationDocuments.AddAsync(reconciliationDocuments, true);

                    var unCheckOrderInfoList = await unCheckOrderService.GetByPhoneAsync(addDto.CustomerPhone, addDto.HospitalId);
                    if (unCheckOrderInfoList.Count > 0)
                    {
                        await unCheckOrderService.UpdateIsSubmitByIdListAsync(unCheckOrderInfoList.Select(z => z.Id).ToList());
                    }
                }

                _unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<ReconciliationDocumentsDto> GetByIdAsync(string id)
        {
            try
            {
                var reconciliationDocuments = await dalReconciliationDocuments.GetAll().Include(x => x.HospitalInfo).SingleOrDefaultAsync(e => e.Id == id);
                if (reconciliationDocuments == null)
                {
                    return new ReconciliationDocumentsDto();
                }

                ReconciliationDocumentsDto reconciliationDocumentsDto = new ReconciliationDocumentsDto();
                reconciliationDocumentsDto.Id = reconciliationDocuments.Id;
                reconciliationDocumentsDto.HospitalId = reconciliationDocuments.HospitalId;
                reconciliationDocumentsDto.HospitalName = reconciliationDocuments.HospitalInfo.Name;
                reconciliationDocumentsDto.CustomerName = reconciliationDocuments.CustomerName;
                reconciliationDocumentsDto.CustomerPhone = reconciliationDocuments.CustomerPhone;
                reconciliationDocumentsDto.DealGoods = reconciliationDocuments.DealGoods;
                reconciliationDocumentsDto.DealDate = reconciliationDocuments.DealDate;
                reconciliationDocumentsDto.TotalDealPrice = reconciliationDocuments.TotalDealPrice;
                reconciliationDocumentsDto.ReturnBackPricePercent = reconciliationDocuments.ReturnBackPricePercent;
                reconciliationDocumentsDto.ReturnBackPrice = Math.Round(reconciliationDocuments.TotalDealPrice.Value * reconciliationDocuments.ReturnBackPricePercent.Value / 100, 2);
                reconciliationDocumentsDto.SystemUpdatePricePercent = reconciliationDocuments.SystemUpdatePricePercent;
                reconciliationDocumentsDto.SystemUpdatePrice = Math.Round(reconciliationDocuments.TotalDealPrice.Value * reconciliationDocuments.SystemUpdatePricePercent.Value / 100, 2);
                reconciliationDocumentsDto.TotalReconciliationDocumentsPrice = Math.Round(reconciliationDocumentsDto.ReturnBackPrice.Value + reconciliationDocumentsDto.SystemUpdatePrice.Value);
                reconciliationDocumentsDto.Remark = reconciliationDocuments.Remark;
                reconciliationDocumentsDto.ReconciliationState = reconciliationDocuments.ReconciliationState;
                reconciliationDocumentsDto.IsCreateBill = reconciliationDocuments.IsCreateBill;
                reconciliationDocumentsDto.BillId = reconciliationDocuments.BillId;
                reconciliationDocumentsDto.BillId2 = reconciliationDocuments.BillId2;

                reconciliationDocumentsDto.CreateBy = reconciliationDocuments.CreateBy;
                return reconciliationDocumentsDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task<List<ReconciliationDocumentsDto>> GetByBillIdListAsync(string billId)
        {
            try
            {
                var reconciliationDocumentIdList = await dalReconciliationDocuments.GetAll().Include(x => x.HospitalInfo).Where(x => x.BillId == billId || x.BillId2 == billId).ToListAsync();
                List<ReconciliationDocumentsDto> reconciliationDocumentsDtos = new List<ReconciliationDocumentsDto>();
                foreach (var x in reconciliationDocumentIdList)
                {
                    ReconciliationDocumentsDto reconciliationDocumentsDto = new ReconciliationDocumentsDto();
                    reconciliationDocumentsDto.Id = x.Id;
                    reconciliationDocumentsDto.HospitalId = x.HospitalId;
                    reconciliationDocumentsDto.HospitalName = x.HospitalInfo.Name;
                    reconciliationDocumentsDto.CustomerName = x.CustomerName;
                    reconciliationDocumentsDto.CustomerPhone = x.CustomerPhone;
                    reconciliationDocumentsDto.DealGoods = x.DealGoods;
                    reconciliationDocumentsDto.DealDate = x.DealDate;
                    reconciliationDocumentsDto.TotalDealPrice = x.TotalDealPrice;
                    reconciliationDocumentsDto.ReturnBackPricePercent = x.ReturnBackPricePercent;
                    reconciliationDocumentsDto.ReturnBackPrice = Math.Round(x.TotalDealPrice.Value * x.ReturnBackPricePercent.Value / 100, 2, MidpointRounding.AwayFromZero);
                    reconciliationDocumentsDto.SystemUpdatePricePercent = x.SystemUpdatePricePercent;
                    reconciliationDocumentsDto.SystemUpdatePrice = Math.Round(x.TotalDealPrice.Value * x.SystemUpdatePricePercent.Value / 100, 2, MidpointRounding.AwayFromZero);
                    reconciliationDocumentsDto.TotalReconciliationDocumentsPrice = Math.Round(reconciliationDocumentsDto.ReturnBackPrice.Value + reconciliationDocumentsDto.SystemUpdatePrice.Value, 2, MidpointRounding.AwayFromZero);
                    reconciliationDocumentsDto.Remark = x.Remark;
                    reconciliationDocumentsDto.ReconciliationState = x.ReconciliationState;
                    reconciliationDocumentsDto.CreateBy = x.CreateBy;
                    reconciliationDocumentsDtos.Add(reconciliationDocumentsDto);
                }
                return reconciliationDocumentsDtos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task<decimal> GetTotalCheckPriceAsync(string id)
        {
            try
            {
                List<string> idList = new List<string>();
                idList.Add(id);
                var reconciliationDocuments = await recommandDocumentSettleService.GetRecommandDocumentSettleAsync(idList, null);
                if (reconciliationDocuments.Count > 0)
                {
                    return reconciliationDocuments.Sum(x => x.ReturnBackPrice);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task UpdateAsync(UpdateReconciliationDocumentsDto updateDto)
        {
            try
            {
                var reconciliationDocuments = await dalReconciliationDocuments.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (reconciliationDocuments == null)
                    throw new Exception("对账编号错误！");

                reconciliationDocuments.HospitalId = updateDto.HospitalId;
                reconciliationDocuments.CustomerName = updateDto.CustomerName;
                reconciliationDocuments.CustomerPhone = updateDto.CustomerPhone;
                reconciliationDocuments.DealGoods = updateDto.DealGoods;
                reconciliationDocuments.DealDate = updateDto.DealDate;
                reconciliationDocuments.TotalDealPrice = updateDto.TotalDealPrice;
                reconciliationDocuments.ReturnBackPricePercent = updateDto.ReturnBackPricePercent;
                reconciliationDocuments.SystemUpdatePricePercent = updateDto.SystemUpdatePricePercent;
                reconciliationDocuments.Remark = updateDto.Remark;
                reconciliationDocuments.UpdateDate = DateTime.Now;
                reconciliationDocuments.CreateBy = updateDto.CreateBy;
                await dalReconciliationDocuments.UpdateAsync(reconciliationDocuments, true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 标记对账单状态（1:待确认,2:问题账单,3:对账完成）
        /// </summary>
        /// <param name="idList"></param>
        /// <param name="reconciliationState"></param>
        /// <param name="questionReason">当标记为问题账单时必填</param>
        /// <returns></returns>
        public async Task TagReconciliationStateAsync(List<string> idList, int reconciliationState, string questionReason)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                foreach (var id in idList)
                {

                    var reconciliationDocuments = await dalReconciliationDocuments.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                    if (reconciliationDocuments == null)
                        throw new Exception("对账编号错误！");

                    reconciliationDocuments.ReconciliationState = reconciliationState;
                    if (reconciliationState == (int)ReconciliationDocumentsStateEnum.QuestionDocument)
                    {
                        reconciliationDocuments.QuestionReason = questionReason;
                    }
                    reconciliationDocuments.UpdateDate = DateTime.Now;
                    await dalReconciliationDocuments.UpdateAsync(reconciliationDocuments, true);
                }
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 批量开票完成/作废发票
        /// </summary>
        /// <param name="reconciliationDocumentsReturnBackPriceDto"></param>
        /// <returns></returns>
        public async Task ReconciliationDocumentsCreateBillAsync(ReconciliationDocumentsCreateBillDto reconciliationDocumentsCreateBillDto)
        {
            try
            {
                foreach (var x in reconciliationDocumentsCreateBillDto.ReconciliationDocumentsIdList)
                {

                    var reconciliationDocuments = await dalReconciliationDocuments.GetAll().Where(e => e.Id == x).FirstOrDefaultAsync();
                    if (reconciliationDocumentsCreateBillDto.IsCreateBill == true)
                    {
                        if (reconciliationDocuments.IsCreateBill == true)
                        {
                            throw new Exception("您选中的对账单存在已开票数据，请认真核对后重试！");
                        }
                    }
                    reconciliationDocuments.IsCreateBill = reconciliationDocumentsCreateBillDto.IsCreateBill;
                    reconciliationDocuments.BillId = reconciliationDocumentsCreateBillDto.BillId;
                    reconciliationDocuments.BillId2 = reconciliationDocumentsCreateBillDto.BillId2;
                    await dalReconciliationDocuments.UpdateAsync(reconciliationDocuments, true);
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }



        /// <summary>
        /// 回款完成
        /// </summary>
        /// <param name="reconciliationDocumentsReturnBackPriceDto"></param>
        /// <returns></returns>
        public async Task TagReconciliationStateAsync(ReconciliationDocumentsReturnBackPriceDto reconciliationDocumentsReturnBackPriceDto)
        {
            //_unitOfWork.BeginTransaction();
            try
            {

                var reconciliationDocuments = await dalReconciliationDocuments.GetAll().Where(e => reconciliationDocumentsReturnBackPriceDto.ReconciliationDocumentsIdList.Contains(e.Id)).ToListAsync();
                if (reconciliationDocuments.Count > 0)
                {
                    foreach (var x in reconciliationDocuments)
                    {

                        x.ReconciliationState = (int)ReconciliationDocumentsStateEnum.ReturnBackPriceSuccessful;
                        x.UpdateDate = DateTime.Now;
                        await dalReconciliationDocuments.UpdateAsync(x, true);
                    }
                }
                //查询对账单回款记录表
                var settleInfo = await recommandDocumentSettleService.GetRecommandDocumentSettleAsync(reconciliationDocumentsReturnBackPriceDto.ReconciliationDocumentsIdList, false);
                foreach (var k in settleInfo)
                {
                    if (k.OrderFrom == (int)OrderFrom.ThirdPartyOrder)
                    {
                        //已完成
                        #region 下单平台订单回款
                        ReturnBackOrderDto tmallOrderReturnBackOrderDto = new ReturnBackOrderDto();
                        tmallOrderReturnBackOrderDto.OrderId = k.OrderId;
                        tmallOrderReturnBackOrderDto.ReturnBackPrice = k.ReturnBackPrice;
                        tmallOrderReturnBackOrderDto.ReturnBackDate = reconciliationDocumentsReturnBackPriceDto.ReturnBackDate;
                        await orderService.ReturnBackOrderByReconciliationDocumentsIdsAsync(tmallOrderReturnBackOrderDto);
                        #endregion
                    }

                    if (k.OrderFrom == (int)OrderFrom.ContentPlatFormOrder)
                    {
                        #region 内容平台订单回款

                        ReturnBackOrderDto contentPlatFormReturnBackOrderDto = new ReturnBackOrderDto();
                        contentPlatFormReturnBackOrderDto.OrderDealId = k.DealInfoId;
                        contentPlatFormReturnBackOrderDto.ReturnBackPrice = k.ReturnBackPrice;
                        contentPlatFormReturnBackOrderDto.ReturnBackDate = reconciliationDocumentsReturnBackPriceDto.ReturnBackDate;
                        //成交情况回款
                        await contentPlatFormOrderDealInfoService.SettleListAsync(contentPlatFormReturnBackOrderDto);
                        //订单累计回款
                        ReturnBackOrderDto returnBackOrderDto = new ReturnBackOrderDto();
                        returnBackOrderDto.OrderId = k.OrderId;
                        returnBackOrderDto.ReturnBackDate = reconciliationDocumentsReturnBackPriceDto.ReturnBackDate;
                        returnBackOrderDto.ReturnBackPrice = k.ReturnBackPrice;
                        await contentPlateFormOrderService.ReturnBackOrderOnlyAsync(returnBackOrderDto);
                        #endregion
                    }
                    if (k.OrderFrom == (int)OrderFrom.BuyAgainOrder)
                    {
                        #region 升单回款
                        ReturnBackOrderDto customerHospitalConsumeReturnBackOrderDto = new ReturnBackOrderDto();
                        customerHospitalConsumeReturnBackOrderDto.OrderId = k.OrderId;
                        customerHospitalConsumeReturnBackOrderDto.ReturnBackPrice = k.ReturnBackPrice;
                        customerHospitalConsumeReturnBackOrderDto.ReturnBackDate = reconciliationDocumentsReturnBackPriceDto.ReturnBackDate;
                        await customerHospitalConsumeService.ReturnBackOrderByReconciliationDocumentsIdsAsync(customerHospitalConsumeReturnBackOrderDto);
                        #endregion

                    }

                    //对账单审核记录表更新“已回款”
                    await recommandDocumentSettleService.UpdateIsRerturnBackAsync(k.Id, reconciliationDocumentsReturnBackPriceDto.ReturnBackDate);
                }

                //_unitOfWork.Commit();

            }

            catch (Exception ex)
            {
                //_unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task DeleteAsync(List<string> idList)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                foreach (var id in idList)
                {
                    var reconciliationDocuments = await dalReconciliationDocuments.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                    if (reconciliationDocuments == null)
                        throw new Exception("对账编号错误!");

                    reconciliationDocuments.Valid = false;
                    reconciliationDocuments.DealDate = DateTime.Now;
                    await dalReconciliationDocuments.UpdateAsync(reconciliationDocuments, true);
                }
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }
        }
        /// <summary>
        /// 根据对账单id列表获取对账详情列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<RecommandDocumentSettleDto>> GetRecommandDocumentSettleListAsync(List<string> ids)
        {
            return await recommandDocumentSettleService.GetRecommandDocumentSettleAsync(ids, null);
        }
        //#region [对账单审核记录操作]

        ///// <summary>
        ///// 导出审核记录数据
        ///// </summary>
        ///// <param name="isSettle"></param>
        ///// <param name="accountType"></param>
        ///// <param name="keyword"></param>
        ///// <param name="pageNum"></param>
        ///// <param name="pageSize"></param>
        ///// <returns></returns>
        //public async Task<List<RecommandDocumentSettleDto>> ExportSettleListByPageAsync(DateTime? startDate, DateTime? endDate, bool? isSettle, bool? accountType, string keyword, bool isHidePhone)
        //{
        //    if (endDate.HasValue)
        //    {
        //        endDate = endDate.Value.Date.AddDays(1);
        //    }
        //    var record = await recommandDocumentSettleService.GetAllAsync(startDate, endDate, isSettle, accountType, keyword);
        //    List<RecommandDocumentSettleDto> resultInfo = new List<RecommandDocumentSettleDto>();
        //    resultInfo = record.ToList();
        //    foreach (var x in resultInfo)
        //    {
        //        if (x.BelongEmpId.HasValue)
        //        {
        //            var empInfo = await amiyaEmployeeService.GetByIdAsync(x.BelongEmpId.Value);
        //            x.BelongEmpName = empInfo.Name;
        //        }
        //        if (x.CreateEmpId.HasValue)
        //        {
        //            if (x.CreateEmpId.Value == 0)
        //            {
        //                x.CreateEmpName = "医院创建";
        //            }
        //            else
        //            {
        //                var empInfo = await amiyaEmployeeService.GetByIdAsync(x.CreateEmpId.Value);
        //                x.CreateEmpName = empInfo.Name;
        //            }
        //        }
        //        if (x.BelongLiveAnchorAccount.HasValue)
        //        {
        //            var liveAnchor = await liveAnchorService.GetByIdAsync(x.BelongLiveAnchorAccount.Value);
        //            x.BelongLiveAnchor = liveAnchor.Name;
        //        }
        //        if (!string.IsNullOrEmpty(x.RecommandDocumentId) && x.RecommandDocumentId != "string")
        //        {
        //            var reconciliationDocumentsInfo = await this.GetByIdAsync(x.RecommandDocumentId);
        //            x.HospitalName = reconciliationDocumentsInfo.HospitalName;
        //            x.InformationPrice = Math.Round(x.RecolicationPrice.Value * reconciliationDocumentsInfo.ReturnBackPricePercent.Value / 100, 2, MidpointRounding.AwayFromZero);
        //            x.SystemUpdatePrice = Math.Round(x.RecolicationPrice.Value * reconciliationDocumentsInfo.SystemUpdatePricePercent.Value / 100, 2, MidpointRounding.AwayFromZero);
        //        }
        //        switch (x.OrderFrom)
        //        {
        //            case (int)OrderFrom.ContentPlatFormOrder:

        //                var dealInfo = await contentPlatFormOrderDealInfoService.GetByIdAsync(x.DealInfoId);
        //                x.DealDate = dealInfo.DealDate;
        //                var contentPlatFormOrderInfo = await contentPlateFormOrderService.GetByOrderIdAsync(x.OrderId);
        //                x.GoodsName = contentPlatFormOrderInfo.GoodsName;
        //                x.Phone = contentPlatFormOrderInfo.Phone;
        //                break;
        //            case (int)OrderFrom.BuyAgainOrder:
        //                var customerHospitalConsume = await customerHospitalConsumeService.GetByConsumeIdAsync(x.DealInfoId);
        //                x.DealDate = customerHospitalConsume.WriteOffDate;
        //                x.GoodsName = customerHospitalConsume.ItemName;
        //                x.Phone = customerHospitalConsume.Phone;
        //                break;
        //            case (int)OrderFrom.ThirdPartyOrder:
        //                var tmallOrder = await orderService.GetByIdInCRMAsync(x.OrderId);
        //                x.DealDate = tmallOrder.WriteOffDate;
        //                x.GoodsName = tmallOrder.GoodsName;
        //                x.Phone = tmallOrder.Phone;
        //                break;
        //        }
        //    }
        //    return resultInfo.OrderByDescending(x => x.CreateDate).ToList();
        //}


        //#endregion
    }
}
