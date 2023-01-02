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
        private readonly IUnitOfWork _unitOfWork;
        private IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        private IOrderService orderService;
        private ICustomerHospitalConsumeService customerHospitalConsumeService;

        public ReconciliationDocumentsService(IDalReconciliationDocuments dalReconciliationDocuments,
            IContentPlateFormOrderService contentPlateFormOrderService,
            IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService,
            IOrderService orderService,
            ICustomerHospitalConsumeService customerHospitalConsumeService,
            IUnitOfWork unitOfWork)
        {
            this.dalReconciliationDocuments = dalReconciliationDocuments;
            _unitOfWork = unitOfWork;
            this.orderService = orderService;
            this.customerHospitalConsumeService = customerHospitalConsumeService;
            this.contentPlateFormOrderService = contentPlateFormOrderService;
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
        }



        public async Task<FxPageInfo<ReconciliationDocumentsDto>> GetListWithPageAsync(decimal? returnBackPricePercent, int? reconciliationState, DateTime? startDate, DateTime? endDate, DateTime? startDealDate, DateTime? endDealDate, string keyword,int hospitalId, int pageNum, int pageSize)
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
                                             && (!reconciliationState.HasValue || d.ReconciliationState == reconciliationState.Value)
                                             && (d.HospitalId == hospitalId)
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
                                                  Valid = d.Valid,
                                              };

                FxPageInfo<ReconciliationDocumentsDto> reconciliationDocumentsPageInfo = new FxPageInfo<ReconciliationDocumentsDto>();
                reconciliationDocumentsPageInfo.TotalCount = await reconciliationDocuments.CountAsync();
                reconciliationDocumentsPageInfo.List = await reconciliationDocuments.OrderByDescending(x => x.DealDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

                return reconciliationDocumentsPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
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
                }

                _unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                throw ex;
            }
        }

        public async Task<ReconciliationDocumentsDto> GetByIdAsync(string id)
        {
            try
            {
                var reconciliationDocuments = await dalReconciliationDocuments.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (reconciliationDocuments == null)
                {
                    throw new Exception("对账编号错误！");
                }

                ReconciliationDocumentsDto reconciliationDocumentsDto = new ReconciliationDocumentsDto();
                reconciliationDocumentsDto.Id = reconciliationDocuments.Id;
                reconciliationDocumentsDto.HospitalId = reconciliationDocuments.HospitalId;
                reconciliationDocumentsDto.CustomerName = reconciliationDocuments.CustomerName;
                reconciliationDocumentsDto.CustomerPhone = reconciliationDocuments.CustomerPhone;
                reconciliationDocumentsDto.DealGoods = reconciliationDocuments.DealGoods;
                reconciliationDocumentsDto.DealDate = reconciliationDocuments.DealDate;
                reconciliationDocumentsDto.TotalDealPrice = reconciliationDocuments.TotalDealPrice;
                reconciliationDocumentsDto.ReturnBackPricePercent = reconciliationDocuments.ReturnBackPricePercent;
                reconciliationDocumentsDto.SystemUpdatePricePercent = reconciliationDocuments.SystemUpdatePricePercent;
                reconciliationDocumentsDto.Remark = reconciliationDocuments.Remark;
                reconciliationDocumentsDto.ReconciliationState = reconciliationDocuments.ReconciliationState;
                reconciliationDocumentsDto.CreateBy = reconciliationDocuments.CreateBy;
                return reconciliationDocumentsDto;
            }
            catch (Exception ex)
            {

                throw ex;
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
                throw ex;
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
                throw ex;
            }
        }


        /// <summary>
        /// 回款完成
        /// </summary>
        /// <param name="reconciliationDocumentsReturnBackPriceDto"></param>
        /// <returns></returns>
        public async Task TagReconciliationStateAsync(ReconciliationDocumentsReturnBackPriceDto reconciliationDocumentsReturnBackPriceDto)
        {
            _unitOfWork.BeginTransaction();
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
                #region 下单平台订单回款
                ReturnBackOrderDto tmallOrderReturnBackOrderDto = new ReturnBackOrderDto();
                tmallOrderReturnBackOrderDto.ReconciliationDocumentsIdList = reconciliationDocumentsReturnBackPriceDto.ReconciliationDocumentsIdList;
                tmallOrderReturnBackOrderDto.ReturnBackDate = reconciliationDocumentsReturnBackPriceDto.ReturnBackDate;
                await orderService.ReturnBackOrderByReconciliationDocumentsIdsAsync(tmallOrderReturnBackOrderDto);
                #endregion

                #region 内容平台订单回款

                var orderInfo = await contentPlatFormOrderDealInfoService.SettleListAsync(reconciliationDocumentsReturnBackPriceDto);
                foreach (var x in orderInfo)
                {
                    ReturnBackOrderDto returnBackOrderDto = new ReturnBackOrderDto();
                    returnBackOrderDto.OrderId = x.OrderId;
                    returnBackOrderDto.ReturnBackDate = reconciliationDocumentsReturnBackPriceDto.ReturnBackDate;
                    returnBackOrderDto.ReturnBackPrice = x.ReturnBackPrice;
                    await contentPlateFormOrderService.ReturnBackOrderOnlyAsync(returnBackOrderDto);
                }
                #endregion

                #region 升单回款

                ReturnBackOrderDto customerHospitalConsumeReturnBackOrderDto = new ReturnBackOrderDto();
                customerHospitalConsumeReturnBackOrderDto.ReturnBackDate = reconciliationDocumentsReturnBackPriceDto.ReturnBackDate;
                customerHospitalConsumeReturnBackOrderDto.ReconciliationDocumentsIdList = reconciliationDocumentsReturnBackPriceDto.ReconciliationDocumentsIdList;
                await customerHospitalConsumeService.ReturnBackOrderByReconciliationDocumentsIdsAsync(customerHospitalConsumeReturnBackOrderDto);
                #endregion
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                throw ex;
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
                throw ex;
            }
        }
    }
}
