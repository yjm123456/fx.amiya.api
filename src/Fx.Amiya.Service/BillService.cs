﻿using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.Bill;
using Fx.Amiya.Dto.ReconciliationDocuments;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
using jos_sdk_net.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class BillService : IBillService
    {
        private readonly IDalBill dalBill;
        private readonly IUnitOfWork unitOfWork;
        private IReconciliationDocumentsService reconciliationDocumentsService;
        private IBillReturnBackPriceDataService billReturnBackPriceDataService;

        public BillService(IDalBill dalBill,
            IReconciliationDocumentsService reconciliationDocumentsService,
            IBillReturnBackPriceDataService billReturnBackPriceDataService,
            IUnitOfWork unitOfWork)
        {
            this.dalBill = dalBill;
            this.unitOfWork = unitOfWork;
            this.reconciliationDocumentsService = reconciliationDocumentsService;
            this.billReturnBackPriceDataService = billReturnBackPriceDataService;
        }




        /// <summary>
        /// 根据条件获取发票信息
        /// </summary>
        /// <param name="keyWord">关键词（可搜索费用备注，开票事由）</param>
        /// <param name="hospitalId">客户id</param>
        /// <param name="billType">票据类型（医美/其他）</param>
        /// <param name="returnBackState"></param>
        /// <param name="companyId">回款状态（未回款/回款中/已回款）</param>
        /// <param name="valid">是否作废（1正常，0作废）</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<BillDto>> GetListAsync(int? hospitalId, bool? valid, int? billType, int? returnBackState, string companyId, string keyWord, int pageNum, int pageSize)
        {

            var bills = from d in dalBill.GetAll().Include(x => x.AmiyaEmployee).Include(x => x.HospitalInfo).Include(x => x.CompanyBaseInfo)
                        where (string.IsNullOrWhiteSpace(keyWord) || d.OtherPriceRemark.Contains(keyWord) || d.CreateBillReason.Contains(keyWord))
                        && (!hospitalId.HasValue || d.HospitalId == hospitalId.Value)
                        && (string.IsNullOrEmpty(companyId) || d.CollectionCompanyId == companyId)
                        && (!billType.HasValue || d.BillType == billType.Value)
                        && (!returnBackState.HasValue || d.ReturnBackState == returnBackState.Value)
                        && (!valid.HasValue || d.Valid == valid.Value)
                        select new BillDto
                        {
                            Id = d.Id,
                            HospitalId = d.HospitalId,
                            HospitalName = d.HospitalInfo.Name,
                            BillPrice = d.BillPrice,
                            TaxRate = d.TaxRate,
                            TaxPrice = d.TaxPrice,
                            NotInTaxPrice = d.NotInTaxPrice,
                            OtherPrice = d.OtherPrice,
                            OtherPriceRemark = d.OtherPriceRemark,
                            CollectionCompanyId = d.CollectionCompanyId,
                            CollectionCompanyName = d.CompanyBaseInfo.Name,
                            BelongStartTime = d.BelongStartTime,
                            BelongEndTime = d.BelongEndTime,
                            BillType = d.BillType,
                            BillTypeText = ServiceClass.GetBillTypeText(d.BillType),
                            CreateBillReason = d.CreateBillReason,
                            ReturnBackState = d.ReturnBackState,
                            ReturnBackStateText = ServiceClass.GetBillReturnBackStateText(d.ReturnBackState),
                            ReturnBackPrice = d.ReturnBackPrice,
                            CreateDate = d.CreateDate,
                            CreateBy = d.CreateBy,
                            CreateByEmployeeName = d.AmiyaEmployee.Name,
                            UpdateDate = d.UpdateDate,
                            Valid = d.Valid,
                            ValidText = d.Valid == true ? "正常" : "作废",
                            DeleteDate = d.DeleteDate,
                        };
            FxPageInfo<BillDto> billPageInfo = new FxPageInfo<BillDto>();
            billPageInfo.TotalCount = await bills.CountAsync();
            billPageInfo.List = await bills.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return billPageInfo;
        }


        /// <summary>
        /// 添加发票
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddBillDto addDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                Bill bill = new Bill();
                bill.Id = CreateOrderIdHelper.GetBillNextNumber();
                bill.HospitalId = addDto.HospitalId;
                bill.BillPrice = addDto.BillPrice;
                bill.TaxRate = addDto.TaxRate;
                bill.TaxPrice = addDto.TaxPrice;
                bill.NotInTaxPrice = addDto.NotInTaxPrice;
                bill.OtherPrice = addDto.OtherPrice;
                bill.OtherPriceRemark = addDto.OtherPriceRemark;
                bill.CollectionCompanyId = addDto.CollectionCompanyId;
                bill.BelongStartTime = addDto.BelongStartTime;
                bill.BelongEndTime = addDto.BelongEndTime;
                bill.BillType = addDto.BillType;
                bill.CreateBillReason = addDto.CreateBillReason;
                bill.ReturnBackState = (int)BillReturnBackStateTextEnum.UnReturnBack;
                bill.CreateBy = addDto.CreateBy;
                bill.CreateDate = addDto.CreateDate;
                bill.Valid = true;
                await dalBill.AddAsync(bill, true);

                //调用对账单表更新是否开票接口
                ReconciliationDocumentsCreateBillDto reconciliationDocumentsCreateBillDto = new ReconciliationDocumentsCreateBillDto();
                reconciliationDocumentsCreateBillDto.BillId = bill.Id;
                reconciliationDocumentsCreateBillDto.ReconciliationDocumentsIdList = addDto.ReconciliationDocumentsIdList;
                reconciliationDocumentsCreateBillDto.IsCreateBill = true;
                await reconciliationDocumentsService.ReconciliationDocumentsCreateBillAsync(reconciliationDocumentsCreateBillDto);
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception(err.ToString());
            }
        }



        public async Task<BillDto> GetByIdAsync(string id)
        {
            var result = await dalBill.GetAll().Include(x => x.HospitalInfo).Include(x => x.AmiyaEmployee).Include(x => x.CompanyBaseInfo).Where(x => x.Id == id).FirstOrDefaultAsync();
            if (result == null)
            {
                return new BillDto();
            }

            BillDto returnResult = new BillDto();
            returnResult.Id = result.Id;
            returnResult.HospitalId = result.HospitalId;
            returnResult.HospitalName = result.HospitalInfo.Name;
            returnResult.BillPrice = result.BillPrice;
            returnResult.TaxRate = result.TaxRate;
            returnResult.TaxPrice = result.TaxPrice;
            returnResult.NotInTaxPrice = result.NotInTaxPrice;
            returnResult.OtherPrice = result.OtherPrice;
            returnResult.OtherPriceRemark = result.OtherPriceRemark;
            returnResult.CollectionCompanyId = result.CollectionCompanyId;
            returnResult.CollectionCompanyName = result.CompanyBaseInfo.Name;
            returnResult.BelongStartTime = result.BelongStartTime;
            returnResult.BelongEndTime = result.BelongEndTime;
            returnResult.BillType = result.BillType;
            returnResult.BillTypeText = ServiceClass.GetBillTypeText(result.BillType);
            returnResult.CreateBillReason = result.CreateBillReason;
            returnResult.ReturnBackState = result.ReturnBackState;
            returnResult.ReturnBackStateText = ServiceClass.GetBillReturnBackStateText(result.ReturnBackState);
            returnResult.CreateDate = result.CreateDate;
            returnResult.CreateBy = result.CreateBy;
            returnResult.CreateByEmployeeName = result.AmiyaEmployee.Name;
            returnResult.UpdateDate = result.UpdateDate;
            returnResult.Valid = result.Valid;
            returnResult.ValidText = result.Valid == true ? "正常" : "作废";
            returnResult.DeleteDate = result.DeleteDate;

            var reconciliationDocuments = await reconciliationDocumentsService.GetByBillIdListAsync(id);
            returnResult.ReconciliationDocumentsDtoList = reconciliationDocuments;

            return returnResult;
        }



        /// <summary>
        /// 修改发票
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateBillDto updateDto)
        {
            var result = await dalBill.GetAll().Where(x => x.Id == updateDto.Id).FirstOrDefaultAsync();
            if (result == null)
                throw new Exception("未找到发票信息");
            result.HospitalId = updateDto.HospitalId;
            result.BillPrice = updateDto.BillPrice;
            result.TaxRate = updateDto.TaxRate;
            result.TaxPrice = updateDto.TaxPrice;
            result.NotInTaxPrice = updateDto.NotInTaxPrice;
            result.OtherPrice = updateDto.OtherPrice;
            result.OtherPriceRemark = updateDto.OtherPriceRemark;
            result.CollectionCompanyId = updateDto.CollectionCompanyId;
            result.BelongStartTime = updateDto.BelongStartTime;
            result.BelongEndTime = updateDto.BelongEndTime;
            result.BillType = updateDto.BillType;
            result.CreateBillReason = updateDto.CreateBillReason;
            result.UpdateDate = DateTime.Now;
            await dalBill.UpdateAsync(result, true);
        }

        /// <summary>
        /// 作废发票
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            unitOfWork.BeginTransaction();
            try
            {

                var result = await dalBill.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                await dalBill.DeleteAsync(result, true);
                //调用对账单表更新是否开票接口
                ReconciliationDocumentsCreateBillDto reconciliationDocumentsCreateBillDto = new ReconciliationDocumentsCreateBillDto();
                reconciliationDocumentsCreateBillDto.BillId = "";
                var reconciliationDocuments = await reconciliationDocumentsService.GetByBillIdListAsync(id);
                reconciliationDocumentsCreateBillDto.ReconciliationDocumentsIdList = reconciliationDocuments.Select(x => x.Id).ToList();
                reconciliationDocumentsCreateBillDto.IsCreateBill = false;
                await reconciliationDocumentsService.ReconciliationDocumentsCreateBillAsync(reconciliationDocumentsCreateBillDto);
                unitOfWork.Commit();
            }
            catch (Exception er)
            {
                unitOfWork.RollBack();
                throw new Exception(er.Message.ToString());
            }
        }

        /// <summary>
        /// 发票回款
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task ReturnBakcPriceAsync(BillReturnBackPriceDto updateDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var result = await dalBill.GetAll().Where(x => x.Id == updateDto.Id).FirstOrDefaultAsync();
                result.ReturnBackState = (int)BillReturnBackStateTextEnum.ReturnBacking;
                if (result == null)
                    throw new Exception("未找到发票信息");
                if (result.ReturnBackPrice.HasValue)
                {
                    result.ReturnBackPrice += updateDto.ReturnBackPrice;
                    decimal billTotalPrice = result.BillPrice;
                    if (result.OtherPrice.HasValue)
                    {
                        billTotalPrice += result.OtherPrice.Value;
                    }
                    if (result.ReturnBackPrice == billTotalPrice)
                    {
                        result.ReturnBackState = (int)BillReturnBackStateTextEnum.ReturnBackSuccessful;

                        //调用对账单表回款业务（todo;）
                        ReconciliationDocumentsReturnBackPriceDto reconciliationDocumentsReturnBackPriceDto = new ReconciliationDocumentsReturnBackPriceDto();
                        reconciliationDocumentsReturnBackPriceDto.ReturnBackDate = updateDto.ReturnBackDate;
                        var reconciliationDocuments = await reconciliationDocumentsService.GetByBillIdListAsync(updateDto.Id);
                        reconciliationDocumentsReturnBackPriceDto.ReconciliationDocumentsIdList = reconciliationDocuments.Select(x => x.Id).ToList();
                        await reconciliationDocumentsService.TagReconciliationStateAsync(reconciliationDocumentsReturnBackPriceDto);
                    }
                    if (result.ReturnBackPrice > billTotalPrice)
                    {
                        throw new Exception("当前回款金额与已回款金额累计（" + result.ReturnBackPrice + "元）不能大于发票金额与其他费用的总和（" + billTotalPrice + "）！");
                    }
                }
                else
                {
                    result.ReturnBackPrice = updateDto.ReturnBackPrice;
                }
                result.UpdateDate = DateTime.Now;
                await dalBill.UpdateAsync(result, true);

                //回款记录表插入数据(todo;)
                AddBillReturnBackPriceDataDto addBillReturnBackPriceDataDto = new AddBillReturnBackPriceDataDto();
                addBillReturnBackPriceDataDto.HospitalId = result.HospitalId;
                addBillReturnBackPriceDataDto.CompanyId = result.CollectionCompanyId;
                addBillReturnBackPriceDataDto.BillId = result.Id;
                addBillReturnBackPriceDataDto.BillPrice = result.BillPrice;
                addBillReturnBackPriceDataDto.OtherPrice = result.OtherPrice;
                addBillReturnBackPriceDataDto.ReturnBackPrice = updateDto.ReturnBackPrice;
                addBillReturnBackPriceDataDto.ReturnBackDate = updateDto.ReturnBackDate;
                addBillReturnBackPriceDataDto.ReturnBackState = result.ReturnBackState;
                addBillReturnBackPriceDataDto.CreateBy = updateDto.CreateBy;
                addBillReturnBackPriceDataDto.Remark = updateDto.Remark;
                await billReturnBackPriceDataService.AddAsync(addBillReturnBackPriceDataDto);
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception(err.Message.ToString());
            }
        }

        #region [枚举下拉框]

        /// <summary>
        /// 票据类型列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<BaseKeyValueDto>> GetBillTypeListAsync()
        {
            var billTypes = Enum.GetValues(typeof(BillTypeTextEnum));

            List<BaseKeyValueDto> billTypeList = new List<BaseKeyValueDto>();
            foreach (var item in billTypes)
            {
                BaseKeyValueDto baseKeyValueDto = new BaseKeyValueDto();
                baseKeyValueDto.Key = Convert.ToInt32(item).ToString();
                baseKeyValueDto.Value = ServiceClass.GetBillTypeText(Convert.ToInt32(item));
                billTypeList.Add(baseKeyValueDto);
            }
            return billTypeList;
        }
        /// <summary>
        /// 票据回款状态列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<BaseKeyValueDto>> GetBillReturnBackStateTextListAsync()
        {
            var billReturnBackStateTexts = Enum.GetValues(typeof(BillReturnBackStateTextEnum));

            List<BaseKeyValueDto> billReturnBackStateTextList = new List<BaseKeyValueDto>();
            foreach (var item in billReturnBackStateTexts)
            {
                BaseKeyValueDto baseKeyValueDto = new BaseKeyValueDto();
                baseKeyValueDto.Key = Convert.ToInt32(item).ToString();
                baseKeyValueDto.Value = ServiceClass.GetBillReturnBackStateText(Convert.ToInt32(item));
                billReturnBackStateTextList.Add(baseKeyValueDto);
            }
            return billReturnBackStateTextList;
        }

        #endregion
    }
}