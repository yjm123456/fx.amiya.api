﻿using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.CustomerHospitalConsume;
using Fx.Amiya.Dto.WxAppConfig;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
using Fx.Amiya.Dto.OrderCheckPicture;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.Dto.OrderReport;
using jos_sdk_net.Util;
using Fx.Amiya.Dto.ReconciliationDocuments;
using Fx.Amiya.Dto.UpdateCreateBillAndCompany;
using Fx.Amiya.Dto.FinancialBoard;

namespace Fx.Amiya.Service
{
    public class CustomerHospitalConsumeService : ICustomerHospitalConsumeService
    {
        private IDalCustomerHospitalConsume dalCustomerHospitalConsume;
        private IDalConfig dalConfig;
        private ICompanyBaseInfoService companyBaseInfoService;
        private IRecommandDocumentSettleService recommandDocumentSettleService;
        private IDalAmiyaEmployee dalAmiyaEmployee;
        private IDalBindCustomerService _dalBindCustomerService;
        private IBindCustomerServiceService bindCustomerServiceService;

        private IOrderCheckPictureService _orderCheckPictureService;
        private IUnitOfWork unitOfWork;
        private ILiveAnchorService liveAnchorService;
        private IDalCustomerBaseInfo dalCustomerBaseInfo;
        private IDalRecommandDocumentSettle dalRecommandDocumentSettle;
        private IDalLiveAnchor dalLiveAnchor;
        private IDalCompanyBaseInfo dalCompanyBaseInfo;
        public CustomerHospitalConsumeService(IDalCustomerHospitalConsume dalCustomerHospitalConsume,
            IDalConfig dalConfig,
            IDalAmiyaEmployee dalAmiyaEmployee,
            ICompanyBaseInfoService companyBaseInfoService,
            IRecommandDocumentSettleService recommandDocumentSettleService,
            IUnitOfWork unitOfWork,
            IBindCustomerServiceService bindCustomerServiceService,
            ILiveAnchorService liveAnchorService,
            IDalBindCustomerService dalBindCustomerService,
            IOrderCheckPictureService orderCheckPictureService,
            IDalCustomerBaseInfo dalCustomerBaseInfo, IDalRecommandDocumentSettle dalRecommandDocumentSettle, IDalLiveAnchor dalLiveAnchor, IDalCompanyBaseInfo dalCompanyBaseInfo)
        {
            this.dalCustomerHospitalConsume = dalCustomerHospitalConsume;
            this.dalConfig = dalConfig;
            this.unitOfWork = unitOfWork;
            this.bindCustomerServiceService = bindCustomerServiceService;
            _orderCheckPictureService = orderCheckPictureService;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
            this.companyBaseInfoService = companyBaseInfoService;
            _dalBindCustomerService = dalBindCustomerService;
            this.recommandDocumentSettleService = recommandDocumentSettleService;
            this.liveAnchorService = liveAnchorService;
            this.dalCustomerBaseInfo = dalCustomerBaseInfo;
            this.dalRecommandDocumentSettle = dalRecommandDocumentSettle;
            this.dalLiveAnchor = dalLiveAnchor;
            this.dalCompanyBaseInfo = dalCompanyBaseInfo;
        }

        public async Task AddAsync(AddCustomerHospitalConsumeDto addDto, int hospitalId)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var config = await GetCallCenterConfig();
                string phone = ServiceClass.Decrypto(addDto.Phone, config.PhoneEncryptKey);
                CustomerHospitalConsume customerHospitalConsume = new CustomerHospitalConsume();
                customerHospitalConsume.HospitalId = hospitalId;
                customerHospitalConsume.Phone = phone;
                customerHospitalConsume.ConsumeId = CreateOrderIdHelper.GetNextNumber();
                customerHospitalConsume.LiveAnchorId = 0;
                customerHospitalConsume.ItemName = addDto.ItemName;
                customerHospitalConsume.Price = addDto.Price;
                customerHospitalConsume.CreateDate = DateTime.Now;
                customerHospitalConsume.ConsumeType = addDto.ConsumeType;
                customerHospitalConsume.Channel = addDto.Channel;
                customerHospitalConsume.AddedBy = 0;
                customerHospitalConsume.NickName = addDto.NickName;
                customerHospitalConsume.IsAddedOrder = addDto.IsAddedOrder;
                customerHospitalConsume.OrderId = addDto.OrderId;
                customerHospitalConsume.WriteOffDate = addDto.WriteOffDate;
                customerHospitalConsume.IsCconsultationCard = false;
                customerHospitalConsume.BuyAgainType = addDto.BuyAgainType;
                customerHospitalConsume.IsSelfLiving = false;
                customerHospitalConsume.BuyAgainTime = addDto.BuyAgainTime;
                customerHospitalConsume.HasBuyagainEvidence = addDto.HasBuyagainEvidence;
                customerHospitalConsume.BuyagainEvidencePic = addDto.BuyagainEvidencePic;
                customerHospitalConsume.IsCheckToHospital = true;
                customerHospitalConsume.CheckToHospitalPic = addDto.CheckToHospitalPic;
                customerHospitalConsume.PersonTime = addDto.PersonTime;
                customerHospitalConsume.IsReceiveAdditionalPurchase = false;
                customerHospitalConsume.Remark = addDto.Remark;
                customerHospitalConsume.IsConfirmOrder = true;
                await dalCustomerHospitalConsume.AddAsync(customerHospitalConsume, true);
                var bind = await _dalBindCustomerService.GetAll()
                  .Include(e => e.CustomerServiceAmiyaEmployee)
                  .FirstOrDefaultAsync(e => e.BuyerPhone == phone);
                bind.NewConsumptionDate = DateTime.Now;
                bind.NewConsumptionContentPlatform = (int)OrderFrom.BuyAgainOrder;
                bind.NewContentPlatForm = ServiceClass.GerConsumeChannelText(addDto.Channel);
                var liveAnchor = dalLiveAnchor.GetAll().Where(e => e.Id == addDto.LiveAnchorId).FirstOrDefault();
                if (liveAnchor != null)
                {
                    bind.NewLiveAnchor = liveAnchor.Name;
                }
                bind.AllPrice += addDto.Price;
                bind.AllOrderCount += 1;
                await _dalBindCustomerService.UpdateAsync(bind, true);
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception(err.Message.ToString());
            }
        }

        public async Task CustomerManageAddAsync(AddCustomerHospitalConsumeDto addDto, int hospitalId)
        {
            var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == addDto.EmployeeId);
            if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
            {
                var bindCustomerServiceInfo = _dalBindCustomerService.GetAll().FirstOrDefaultAsync(x => x.BuyerPhone == addDto.Phone && x.CustomerServiceId == addDto.EmployeeId);
                if (bindCustomerServiceInfo.Result == null)
                {
                    throw new Exception("该手机号客户已绑定给其他客服人员或者未产生订单情况，请确认后再进行消费记录追踪！");
                }
            }
            CustomerHospitalConsume customerHospitalConsume = new CustomerHospitalConsume();
            customerHospitalConsume.HospitalId = hospitalId;
            customerHospitalConsume.ConsumeId = CreateOrderIdHelper.GetNextNumber();
            customerHospitalConsume.Phone = addDto.Phone;
            customerHospitalConsume.ItemName = addDto.ItemName;
            customerHospitalConsume.LiveAnchorId = addDto.LiveAnchorId;
            customerHospitalConsume.Price = addDto.Price;
            customerHospitalConsume.CreateDate = DateTime.Now;
            customerHospitalConsume.ConsumeType = addDto.ConsumeType;
            customerHospitalConsume.AddedBy = addDto.EmployeeId.Value;
            customerHospitalConsume.OtherContentPlatFormOrderId = addDto.OtherContentPlatFormOrderId;
            customerHospitalConsume.NickName = addDto.NickName;
            customerHospitalConsume.IsAddedOrder = addDto.IsAddedOrder;
            customerHospitalConsume.OrderId = addDto.OrderId;
            customerHospitalConsume.WriteOffDate = addDto.WriteOffDate;
            customerHospitalConsume.IsCconsultationCard = addDto.IsCconsultationCard;
            customerHospitalConsume.BuyAgainType = addDto.BuyAgainType;
            customerHospitalConsume.IsSelfLiving = addDto.IsSelfLiving;
            customerHospitalConsume.BuyAgainTime = addDto.BuyAgainTime;
            customerHospitalConsume.HasBuyagainEvidence = addDto.HasBuyagainEvidence;
            customerHospitalConsume.BuyagainEvidencePic = addDto.BuyagainEvidencePic;
            customerHospitalConsume.IsCheckToHospital = addDto.IsCheckToHospital;
            customerHospitalConsume.CheckToHospitalPic = addDto.CheckToHospitalPic;
            customerHospitalConsume.Channel = addDto.Channel;
            customerHospitalConsume.PersonTime = addDto.PersonTime;
            customerHospitalConsume.Remark = addDto.Remark;
            customerHospitalConsume.IsReceiveAdditionalPurchase = addDto.IsReceiveAdditionalPurchase;
            customerHospitalConsume.IsConfirmOrder = false;
            await dalCustomerHospitalConsume.AddAsync(customerHospitalConsume, true);
            //var bind = await _dalBindCustomerService.GetAll()
            //      .Include(e => e.CustomerServiceAmiyaEmployee)
            //      .FirstOrDefaultAsync(e => e.BuyerPhone == addDto.Phone);
            //bind.NewConsumptionDate = DateTime.Now;
            //bind.NewConsumptionContentPlatform = (int)OrderFrom.BuyAgainOrder;
            //bind.NewContentPlatForm = ServiceClass.GerConsumeChannelText(addDto.Channel);
            //var liveAnchor = dalLiveAnchor.GetAll().Where(e => e.Id == addDto.LiveAnchorId).FirstOrDefault();
            //if (liveAnchor != null)
            //{
            //    bind.NewLiveAnchor = liveAnchor.Name;
            //}
            //bind.AllPrice += addDto.Price;
            //bind.AllOrderCount += 1;
            //await _dalBindCustomerService.UpdateAsync(bind, true);
        }

        public async Task CustomerManageImportAsync(List<ImportCustomerHospitalConsumeDto> importAddDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                foreach (var importDto in importAddDto)
                {
                    CustomerHospitalConsume customerHospitalConsume = new CustomerHospitalConsume();
                    customerHospitalConsume.CreateDate = importDto.CreateDate.Value;
                    customerHospitalConsume.HospitalId = importDto.HospitalId;
                    customerHospitalConsume.ItemName = "导入文件（无项目）";
                    customerHospitalConsume.Price = importDto.Price;
                    customerHospitalConsume.Phone = importDto.Phone;
                    customerHospitalConsume.NickName = importDto.NickName;
                    customerHospitalConsume.PersonTime = importDto.PersonTime;
                    customerHospitalConsume.OrderId = importDto.OrderId;
                    customerHospitalConsume.IsAddedOrder = importDto.IsAddedOrder;
                    customerHospitalConsume.WriteOffDate = importDto.WriteOffDate;
                    customerHospitalConsume.IsCconsultationCard = false;
                    customerHospitalConsume.IsSelfLiving = importDto.IsSelfLiving;
                    customerHospitalConsume.BuyAgainTime = importDto.BuyAgainTime;
                    customerHospitalConsume.ConsumeType = importDto.ConsumeType;
                    customerHospitalConsume.AddedBy = importDto.EmployeeId.Value;
                    customerHospitalConsume.BuyAgainType = importDto.BuyAgainType;
                    customerHospitalConsume.HasBuyagainEvidence = false;
                    customerHospitalConsume.BuyagainEvidencePic = "";
                    customerHospitalConsume.IsCheckToHospital = false;
                    customerHospitalConsume.CheckToHospitalPic = "";
                    customerHospitalConsume.IsReceiveAdditionalPurchase = false;
                    customerHospitalConsume.CheckBuyAgainPrice = importDto.CheckBuyAgainPrice;
                    customerHospitalConsume.CheckSettlePrice = importDto.CheckSettlePrice;
                    customerHospitalConsume.CheckDate = importDto.CheckDate;
                    customerHospitalConsume.CheckState = importDto.CheckState;
                    customerHospitalConsume.CheckBy = importDto.EmployeeId.Value;
                    customerHospitalConsume.Remark = importDto.Remark;
                    await dalCustomerHospitalConsume.AddAsync(customerHospitalConsume, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw err;
            }
        }

        public async Task CustomerManageUpdateAsync(CustomerManageUpdateconsumeDto updateDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == updateDto.EmployeeId);
                if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                {
                    var bindCustomerServiceInfo = _dalBindCustomerService.GetAll().FirstOrDefaultAsync(x => x.BuyerPhone == updateDto.Phone && x.CustomerServiceId == updateDto.EmployeeId);
                    if (bindCustomerServiceInfo.Result == null)
                    {
                        throw new Exception("该手机号客户已绑定给其他客服人员或者未产生订单情况，请确认后再进行消费记录追踪修改！");
                    }
                }
                var result = dalCustomerHospitalConsume.GetAll().Where(x => x.Id == updateDto.Id).FirstOrDefaultAsync().Result;
                var dealPriceDetails = updateDto.Price - result.Price;
                result.HospitalId = updateDto.HospitalId;
                result.Phone = updateDto.Phone;
                result.ItemName = updateDto.ItemName;
                result.Price = updateDto.Price;
                result.LiveAnchorId = updateDto.LiveAnchorId;
                result.ConsumeType = updateDto.ConsumeType;
                result.NickName = updateDto.NickName;
                result.IsAddedOrder = updateDto.IsAddedOrder;
                result.OtherContentPlatFormOrderId = updateDto.OtherContentPlatFormOrderId;
                result.OrderId = updateDto.OrderId;
                result.WriteOffDate = updateDto.WriteOffDate;
                result.IsCconsultationCard = updateDto.IsCconsultationCard;
                result.BuyAgainType = updateDto.BuyAgainType;
                result.IsSelfLiving = updateDto.IsSelfLiving;
                result.BuyAgainTime = updateDto.BuyAgainTime;
                result.Channel = updateDto.Channel;
                result.HasBuyagainEvidence = updateDto.HasBuyagainEvidence;
                result.BuyagainEvidencePic = updateDto.BuyagainEvidencePic;
                result.IsCheckToHospital = updateDto.IsCheckToHospital;
                result.CheckToHospitalPic = updateDto.CheckToHospitalPic;
                result.PersonTime = updateDto.PersonTime;
                result.IsReceiveAdditionalPurchase = updateDto.IsReceiveAdditionalPurchase;
                result.Remark = updateDto.Remark;
                await dalCustomerHospitalConsume.UpdateAsync(result, true);
                //var liveAnchor = dalLiveAnchor.GetAll().Where(e => e.Id == updateDto.LiveAnchorId).FirstOrDefault();
                //if (liveAnchor==null) {
                //    await bindCustomerServiceService.UpdateConsumePriceAsync(result.Phone, dealPriceDetails, (int)OrderFrom.BuyAgainOrder, 0);

                //} else {
                //    await bindCustomerServiceService.UpdateConsumePriceAndLiveAnchorAsync(result.Phone, dealPriceDetails, (int)OrderFrom.BuyAgainOrder, 0, liveAnchor.Name);
                //}     
                unitOfWork.Commit();
            }
            catch (Exception er)
            {
                unitOfWork.RollBack();
                throw er;
            }
        }
        public async Task CustomerServiceCheckAsync(int Id)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var result = dalCustomerHospitalConsume.GetAll().Where(x => x.Id == Id).FirstOrDefaultAsync().Result;
                result.IsConfirmOrder = true;
                await dalCustomerHospitalConsume.UpdateAsync(result, true);
                var bind = await _dalBindCustomerService.GetAll()
                .Include(e => e.CustomerServiceAmiyaEmployee)
                .FirstOrDefaultAsync(e => e.BuyerPhone == result.Phone);
                if (bind == null)
                { throw new Exception("该手机号的顾客未在啊美雅系统中产生任何消费，无法升单，请先在下单平台/内容平台录单！"); }
                bind.NewConsumptionDate = DateTime.Now;
                bind.NewConsumptionContentPlatform = (int)OrderFrom.BuyAgainOrder;
                bind.NewContentPlatForm = ServiceClass.GerConsumeChannelText(result.Channel.Value);
                var liveanchorId = result.LiveAnchorId;
                if (liveanchorId != 0)
                {
                    var liveAnchor = await liveAnchorService.GetByIdAsync(liveanchorId);
                    bind.NewLiveAnchor = liveAnchor.Name;
                }
                bind.NewContentPlatForm = result.Channel.HasValue ? ServiceClass.GerConsumeChannelText(result.Channel.Value) : "消费追踪";
                bind.AllPrice += result.Price;
                bind.AllOrderCount += 1;
                await _dalBindCustomerService.UpdateAsync(bind, true);
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception(err.Message.ToString());
            }

        }
        public async Task CustomerManageCheckAsync(CustomerManageCheckconsumeDto updateDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var result = dalCustomerHospitalConsume.GetAll().Where(x => x.Id == updateDto.Id).FirstOrDefaultAsync().Result;

                if (result.IsConfirmOrder == false)
                {
                    throw new Exception("该订单暂未确认，无法审核！");
                }
                result.CheckState = updateDto.CheckState;
                //若审核金额等于交易金额，则审核通过，若不等于则审核中
                if (updateDto.CheckState == (int)CheckType.CheckedSuccess)
                {
                    if (updateDto.CheckBuyAgainPrice == result.Price)
                    {

                        result.CheckState = (int)CheckType.CheckedSuccess;
                        result.CheckSettlePrice = updateDto.CheckSettlePrice;
                        result.CheckBuyAgainPrice = updateDto.CheckBuyAgainPrice;
                    }
                    else
                    {
                        if (result.CheckBuyAgainPrice + updateDto.CheckBuyAgainPrice == result.Price)
                        {
                            result.CheckState = (int)CheckType.CheckedSuccess;
                            result.CheckSettlePrice += updateDto.CheckSettlePrice;
                            result.CheckBuyAgainPrice = result.Price;
                        }
                        else
                        {
                            result.CheckState = (int)CheckType.Checking;
                            if (result.CheckBuyAgainPrice.HasValue)
                            {
                                result.CheckBuyAgainPrice += updateDto.CheckBuyAgainPrice;
                            }
                            else
                            {
                                result.CheckBuyAgainPrice = updateDto.CheckBuyAgainPrice;
                            }
                            if (result.CheckSettlePrice.HasValue)
                            {
                                result.CheckSettlePrice += updateDto.CheckSettlePrice;
                            }
                            else
                            {
                                result.CheckSettlePrice = updateDto.CheckSettlePrice;
                            }
                        }
                    }
                }
                result.CheckBy = updateDto.CheckEmpId;
                result.CheckDate = DateTime.Now;
                result.CheckRemark = updateDto.CheckRemark;
                result.ReconciliationDocumentsId = updateDto.ReconciliationDocumentsId;
                await dalCustomerHospitalConsume.UpdateAsync(result, true);

                foreach (var x in updateDto.CheckPicture)
                {
                    AddOrderCheckPictureDto addCheckPic = new AddOrderCheckPictureDto();
                    addCheckPic.OrderFrom = (int)OrderFrom.BuyAgainOrder;
                    addCheckPic.OrderId = result.ConsumeId;
                    addCheckPic.PictureUrl = x;
                    await _orderCheckPictureService.AddAsync(addCheckPic);
                }
                //对账单回款表插入数据
                AddRecommandDocumentSettleDto addRecommandDocumentSettleDto = new AddRecommandDocumentSettleDto();
                addRecommandDocumentSettleDto.RecommandDocumentId = updateDto.ReconciliationDocumentsId;
                addRecommandDocumentSettleDto.OrderId = updateDto.Id.ToString();
                addRecommandDocumentSettleDto.DealInfoId = result.ConsumeId;
                addRecommandDocumentSettleDto.OrderFrom = (int)OrderFrom.BuyAgainOrder;
                addRecommandDocumentSettleDto.ReturnBackPrice = updateDto.CheckSettlePrice;
                addRecommandDocumentSettleDto.BelongLiveAnchorAccount = result.LiveAnchorId;
                addRecommandDocumentSettleDto.BelongEmpId = result.AddedBy;
                addRecommandDocumentSettleDto.RecolicationPrice = updateDto.CheckBuyAgainPrice;
                addRecommandDocumentSettleDto.CreateBy = updateDto.CheckEmpId;
                addRecommandDocumentSettleDto.CreateEmpId = result.AddedBy;
                addRecommandDocumentSettleDto.AccountType = false;
                addRecommandDocumentSettleDto.AccountPrice = updateDto.CheckSettlePrice;
                addRecommandDocumentSettleDto.OrderPrice = result.Price;
                addRecommandDocumentSettleDto.IsOldCustomer = true;
                await recommandDocumentSettleService.AddAsync(addRecommandDocumentSettleDto);
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw err;
            }
        }

        /// <summary>
        /// 订单回款
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task ReturnBackOrderAsync(ReturnBackOrderDto input)
        {
            try
            {
                var order = await dalCustomerHospitalConsume.GetAll().Where(x => x.ConsumeId == input.OrderId).FirstOrDefaultAsync();
                if (order == null)
                {
                    throw new Exception("未找到该订单的相关信息！");
                }
                if (order.IsConfirmOrder == false)
                {
                    throw new Exception("该订单暂未确认，无法回款！");
                }
                if (order.CheckState != (int)CheckType.CheckedSuccess)
                {
                    throw new Exception("请先审核该订单后进行回款！");
                }
                order.IsReturnBackPrice = true;
                order.ReturnBackPrice = input.ReturnBackPrice;
                order.ReturnBackDate = input.ReturnBackDate;
                await dalCustomerHospitalConsume.UpdateAsync(order, true);

            }
            catch (Exception err)
            {
                throw new Exception("操作失败！");
            }
        }

        /// <summary>
        /// 根据对账单id批量回款
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task ReturnBackOrderByReconciliationDocumentsIdsAsync(ReturnBackOrderDto input)
        {
            try
            {
                var order = await dalCustomerHospitalConsume.GetAll().Where(x => x.Id == Convert.ToInt32(input.OrderId)).FirstOrDefaultAsync();

                if (order.IsConfirmOrder == true && order.CheckState == (int)CheckType.CheckedSuccess)
                {
                    order.IsReturnBackPrice = true;
                    if (order.ReturnBackPrice.HasValue)
                    {
                        order.ReturnBackPrice += input.ReturnBackPrice;
                    }
                    else
                    {
                        order.ReturnBackPrice = input.ReturnBackPrice;
                    }
                    order.ReturnBackDate = input.ReturnBackDate;
                    await dalCustomerHospitalConsume.UpdateAsync(order, true);
                }

            }
            catch (Exception err)
            {
                throw new Exception("操作失败！");
            }
        }

        public async Task<CustomerHospitalConsumeDto> GetByIdAsync(int Id)
        {
            var selectResult = dalCustomerHospitalConsume.GetAll().Include(e => e.HospitalInfo).Where(x => x.Id == Id).FirstOrDefaultAsync().Result;
            CustomerHospitalConsumeDto result = new CustomerHospitalConsumeDto();
            result.Id = selectResult.Id;
            result.ConsumeId = selectResult.ConsumeId;
            result.Channel = selectResult.Channel;
            result.HospitalId = selectResult.HospitalId;
            result.HospitalName = selectResult.HospitalInfo.Name;
            result.Phone = selectResult.Phone;
            result.LiveAnchorId = selectResult.LiveAnchorId;
            if (selectResult.LiveAnchorId != 0)
            {
                var liveanchor = await liveAnchorService.GetByIdAsync(selectResult.LiveAnchorId);
                result.LiveAnchorName = liveanchor.Name;

            }
            result.ItemName = selectResult.ItemName;
            result.Price = selectResult.Price;
            result.CheckDate = selectResult.CheckDate;
            result.CheckBy = selectResult.CheckBy;
            if (selectResult.CheckBy != 0)
            {
                var checkEmpInfo = dalAmiyaEmployee.GetAll().FirstOrDefaultAsync(z => z.Id == selectResult.CheckBy);
                result.CheckByEmpName = checkEmpInfo.Result.Name;
            }
            result.CheckState = ServiceClass.GetCheckTypeText(selectResult.CheckState);
            result.ConsumeType = selectResult.ConsumeType;
            result.CheckSettlePrice = selectResult.CheckSettlePrice;
            result.NickName = selectResult.NickName;
            result.IsAddedOrder = selectResult.IsAddedOrder;
            result.OrderId = selectResult.OrderId;
            result.IsReturnBackPrice = selectResult.IsReturnBackPrice;
            result.ReturnBackDate = selectResult.ReturnBackDate;
            result.CheckBuyAgainPrice = selectResult.CheckBuyAgainPrice;
            result.CreateDate = selectResult.CreateDate;
            result.ReturnBackPrice = selectResult.ReturnBackPrice;
            result.WriteOffDate = selectResult.WriteOffDate;
            result.IsCconsultationCard = selectResult.IsCconsultationCard;
            result.BuyAgainType = selectResult.BuyAgainType;
            result.BuyAgainTypeText = ServiceClass.GetBuyAgainTypeText(selectResult.BuyAgainType);
            result.ChannelText = ServiceClass.GerConsumeChannelText(selectResult.Channel.Value);
            result.IsSelfLiving = selectResult.IsSelfLiving;
            result.BuyAgainTime = selectResult.BuyAgainTime;
            result.HasBuyagainEvidence = selectResult.HasBuyagainEvidence;
            result.BuyagainEvidencePic = selectResult.BuyagainEvidencePic;
            result.OtherContentPlatFormOrderId = selectResult.OtherContentPlatFormOrderId;
            result.IsCheckToHospital = selectResult.IsCheckToHospital;
            result.CheckToHospitalPic = selectResult.CheckToHospitalPic;
            result.PersonTime = selectResult.PersonTime;
            result.Remark = selectResult.Remark;
            result.IsConfirmOrder = selectResult.IsConfirmOrder;
            result.IsReceiveAdditionalPurchase = selectResult.IsReceiveAdditionalPurchase;
            result.IsCreateBill = selectResult.IsCreateBill;
            result.BelongCompanyName= dalCompanyBaseInfo.GetAll().Where(e => e.Id == selectResult.BelongCompany).SingleOrDefault()?.Name;
            return result;
        }

        public async Task<CustomerHospitalConsumeDto> GetByConsumeIdAsync(string consumeId)
        {
            var selectResult = dalCustomerHospitalConsume.GetAll().Where(x => x.ConsumeId == consumeId).FirstOrDefaultAsync().Result;
            if (selectResult == null)
            { return new CustomerHospitalConsumeDto(); }
            CustomerHospitalConsumeDto result = new CustomerHospitalConsumeDto();
            result.Id = selectResult.Id;
            result.ConsumeId = selectResult.ConsumeId;
            result.Channel = selectResult.Channel;
            result.HospitalId = selectResult.HospitalId;
            result.Phone = selectResult.Phone;
            result.LiveAnchorId = selectResult.LiveAnchorId;
            result.ItemName = selectResult.ItemName;
            result.Price = selectResult.Price;
            result.ConsumeType = selectResult.ConsumeType;
            result.CheckSettlePrice = selectResult.CheckSettlePrice;
            result.NickName = selectResult.NickName;
            result.IsAddedOrder = selectResult.IsAddedOrder;
            result.OrderId = selectResult.OrderId;
            result.WriteOffDate = selectResult.WriteOffDate;
            result.IsCconsultationCard = selectResult.IsCconsultationCard;
            result.BuyAgainType = selectResult.BuyAgainType;
            result.IsSelfLiving = selectResult.IsSelfLiving;
            result.BuyAgainTime = selectResult.BuyAgainTime;
            result.HasBuyagainEvidence = selectResult.HasBuyagainEvidence;
            result.BuyagainEvidencePic = selectResult.BuyagainEvidencePic;
            result.OtherContentPlatFormOrderId = selectResult.OtherContentPlatFormOrderId;
            result.IsCheckToHospital = selectResult.IsCheckToHospital;
            result.CheckToHospitalPic = selectResult.CheckToHospitalPic;
            result.PersonTime = selectResult.PersonTime;
            result.Remark = selectResult.Remark;
            result.IsConfirmOrder = selectResult.IsConfirmOrder;
            result.IsReceiveAdditionalPurchase = selectResult.IsReceiveAdditionalPurchase;
            return result;
        }

        public async Task CustomerManageDeleteAsync(int Id, int enployeeId)
        {
            unitOfWork.BeginTransaction();
            try
            {

                var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == enployeeId);
                var result = dalCustomerHospitalConsume.GetAll().Where(x => x.Id == Id).FirstOrDefaultAsync().Result;
                if (result.CheckState == (int)CheckType.CheckedSuccess)
                {
                    throw new Exception("该订单已审核，无法删除！");
                }
                if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                {
                    var bindCustomerServiceInfo = _dalBindCustomerService.GetAll().FirstOrDefaultAsync(x => x.BuyerPhone == result.Phone && x.CustomerServiceId == enployeeId);
                    if (bindCustomerServiceInfo.Result == null)
                    {
                        throw new Exception("该手机号客户已绑定给其他客服人员或者未产生订单情况，请确认后再进行消费记录追踪删除！");
                    }
                }
                await dalCustomerHospitalConsume.DeleteAsync(result, true);
                await bindCustomerServiceService.ReduceConsumePriceAsync(result.Phone, result.Price, (int)OrderFrom.BuyAgainOrder);
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw err;
            }
        }

        /// <summary>
        /// 根据加密电话获取客户消费追踪列表
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<CustomerHospitalConsumeDto>> GetListByEncryptPhoneAsync(string encryptPhone, int? hospitalId, int pageNum, int pageSize)
        {
            var config = await GetCallCenterConfig();
            string phone = ServiceClass.Decrypto(encryptPhone, config.PhoneEncryptKey);

            var customerHospitalConsumes = from d in dalCustomerHospitalConsume.GetAll()
                                           where d.Phone == phone
                                           && (hospitalId == null || d.HospitalId == hospitalId)
                                           select new CustomerHospitalConsumeDto
                                           {
                                               Id = d.Id,
                                               HospitalId = d.HospitalId,
                                               HospitalName = d.HospitalInfo.Name,
                                               EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                               Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                               ItemName = d.ItemName,
                                               Channel = d.Channel,
                                               ConsumeId = d.ConsumeId,
                                               ChannelType = ServiceClass.GerConsumeChannelText(d.Channel.Value),
                                               Price = d.Price,
                                               CreateDate = d.CreateDate,
                                               ConsumeType = d.ConsumeType,
                                               ConsumeTypeText = ServiceClass.GerConsumeTypeText(d.ConsumeType),
                                               NickName = d.NickName,
                                               IsAddedOrder = d.IsAddedOrder,
                                               OrderId = d.OrderId,
                                               WriteOffDate = d.WriteOffDate.Value,
                                               IsCconsultationCard = d.IsCconsultationCard,
                                               BuyAgainType = d.BuyAgainType,
                                               BuyAgainTypeText = ServiceClass.GetBuyAgainTypeText(d.BuyAgainType),
                                               IsSelfLiving = d.IsSelfLiving,
                                               BuyAgainTime = d.BuyAgainTime.Value,
                                               HasBuyagainEvidence = d.HasBuyagainEvidence,
                                               BuyagainEvidencePic = d.BuyagainEvidencePic,
                                               IsCheckToHospital = d.IsCheckToHospital,
                                               CheckToHospitalPic = d.CheckToHospitalPic,
                                               PersonTime = d.PersonTime,
                                               IsReceiveAdditionalPurchase = d.IsReceiveAdditionalPurchase,
                                           };
            FxPageInfo<CustomerHospitalConsumeDto> pageInfo = new FxPageInfo<CustomerHospitalConsumeDto>();
            pageInfo.TotalCount = await customerHospitalConsumes.CountAsync();
            pageInfo.List = await customerHospitalConsumes.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return pageInfo;
        }

        public async Task<List<CustomerHospitalConsumeDto>> GetListByPhoneAsync(string phone)
        {

            var config = await GetCallCenterConfig();
            var customerHospitalConsumes = from d in dalCustomerHospitalConsume.GetAll()
                                           where d.Phone == phone
                                           select new CustomerHospitalConsumeDto
                                           {
                                               Id = d.Id,
                                               HospitalId = d.HospitalId,
                                               HospitalName = d.HospitalInfo.Name,
                                               Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                               ItemName = d.ItemName,
                                               Channel = d.Channel,
                                               ChannelType = ServiceClass.GerConsumeChannelText(d.Channel.Value),
                                               Price = d.Price,
                                               CreateDate = d.CreateDate,
                                               ConsumeType = d.ConsumeType,
                                               ConsumeTypeText = ServiceClass.GerConsumeTypeText(d.ConsumeType),
                                               NickName = d.NickName,
                                               IsAddedOrder = d.IsAddedOrder,
                                               OrderId = d.OrderId,
                                               WriteOffDate = d.WriteOffDate.Value,
                                               IsCconsultationCard = d.IsCconsultationCard,
                                               BuyAgainType = d.BuyAgainType,
                                               BuyAgainTypeText = ServiceClass.GetBuyAgainTypeText(d.BuyAgainType),
                                               IsSelfLiving = d.IsSelfLiving,
                                               BuyAgainTime = d.BuyAgainTime.Value,
                                               HasBuyagainEvidence = d.HasBuyagainEvidence,
                                               BuyagainEvidencePic = d.BuyagainEvidencePic,
                                               IsCheckToHospital = d.IsCheckToHospital,
                                               CheckToHospitalPic = d.CheckToHospitalPic,
                                               PersonTime = d.PersonTime,
                                               IsReceiveAdditionalPurchase = d.IsReceiveAdditionalPurchase,
                                           };
            List<CustomerHospitalConsumeDto> pageInfo = new List<CustomerHospitalConsumeDto>();
            pageInfo = await customerHospitalConsumes.ToListAsync();
            return pageInfo;
        }


        /// <summary>
        /// 获取客户消费追踪列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="channel">渠道（0：医院，1：天猫，2抖音，3抖音代运营）</param>
        /// <param name="keyword"></param>
        /// <param name="consumeType">消费类型：0=当天其他消费，1=再消费</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<CustomerHospitalConsumeDto>> GetListAsync(int? hospitalId, int? channel, int? liveAnchorId, int? buyAgainType, int? employeeId, bool? isConfirmOrder, DateTime? consumeStartDate, DateTime? consumeEndDate, string keyword, int? consumeType, DateTime? startDate, DateTime? endDate, int checkState, int? addedBy, int pageNum, int pageSize, bool? dataFrom)
        {

            var config = await GetCallCenterConfig();
            if (dataFrom.HasValue&& dataFrom.Value == true)
            {
                config.HidePhoneNumber = false;
            }
            var customerHospitalConsumes = from d in dalCustomerHospitalConsume.GetAll()
                                           where (hospitalId == null || d.HospitalId == hospitalId)
                                           && (channel == null || d.Channel == channel)
                                           && (!isConfirmOrder.HasValue || d.IsConfirmOrder == isConfirmOrder.Value)
                                           && (liveAnchorId == null || d.LiveAnchorId == liveAnchorId)
                                           && (string.IsNullOrWhiteSpace(keyword) || d.Phone.Contains(keyword) || d.ItemName.Contains(keyword) || d.ConsumeId.Contains(keyword))
                                           && (consumeType == null || d.ConsumeType == consumeType)
                                           && (addedBy == -1 || d.AddedBy == addedBy)
                                           && (checkState == -1 || d.CheckState == checkState)
                                           && (buyAgainType == null || d.BuyAgainType == buyAgainType)
                                           && (!startDate.HasValue || d.CreateDate >= startDate.Value.Date)
                                           && (!endDate.HasValue || d.CreateDate < endDate.Value.AddDays(1).Date)
                                           && (!consumeStartDate.HasValue || d.BuyAgainTime >= consumeStartDate.Value.Date)
                                           && (!consumeEndDate.HasValue || d.BuyAgainTime < consumeEndDate.Value.AddDays(1).Date)
                                           join cb in dalCustomerBaseInfo.GetAll() on d.Phone equals cb.Phone into dcb
                                           from cb in dcb.DefaultIfEmpty()
                                           select new CustomerHospitalConsumeDto
                                           {
                                               Id = d.Id,
                                               HospitalId = d.HospitalId,
                                               HospitalName = d.HospitalInfo.Name,
                                               EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                               Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                               Name = cb.Name,
                                               Channel = d.Channel,
                                               ChannelType = ServiceClass.GerConsumeChannelText(d.Channel.Value),
                                               // Age = cb.Age,
                                               IsReturnBackPrice = d.IsReturnBackPrice,
                                               IsConfirmOrder = d.IsConfirmOrder,
                                               ReturnBackPrice = d.ReturnBackPrice,
                                               ReturnBackDate = d.ReturnBackDate,
                                               LiveAnchorId = d.LiveAnchorId,
                                               ConsumeId = d.ConsumeId,
                                               Sex = cb.Sex,
                                               ItemName = d.ItemName,
                                               Price = d.Price,
                                               CreateDate = d.CreateDate,
                                               ConsumeType = d.ConsumeType,
                                               AddedBy = d.AddedBy,
                                               ConsumeTypeText = ServiceClass.GerConsumeTypeText(d.ConsumeType),
                                               NickName = d.NickName,
                                               IsAddedOrder = d.IsAddedOrder,
                                               OrderId = d.OrderId,
                                               WriteOffDate = d.WriteOffDate.Value,
                                               IsCconsultationCard = d.IsCconsultationCard,
                                               BuyAgainType = d.BuyAgainType,
                                               BuyAgainTypeText = ServiceClass.GetBuyAgainTypeText(d.BuyAgainType),
                                               IsSelfLiving = d.IsSelfLiving,
                                               BuyAgainTime = d.BuyAgainTime.Value,
                                               HasBuyagainEvidence = d.HasBuyagainEvidence,
                                               BuyagainEvidencePic = d.BuyagainEvidencePic,
                                               IsCheckToHospital = d.IsCheckToHospital,
                                               CheckToHospitalPic = d.CheckToHospitalPic,
                                               PersonTime = d.PersonTime,
                                               IsReceiveAdditionalPurchase = d.IsReceiveAdditionalPurchase,
                                               CheckBuyAgainPrice = d.CheckBuyAgainPrice,
                                               CheckSettlePrice = d.CheckSettlePrice,
                                               CheckDate = d.CheckDate,
                                               CheckBy = d.CheckBy,
                                               CheckState = ServiceClass.GetCheckTypeText(d.CheckState),
                                               Remark = d.Remark,
                                               CheckRemark = d.CheckRemark,
                                               OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                                               ReconciliationDocumentsId = d.ReconciliationDocumentsId,
                                           };

            var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
            if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
            {
                customerHospitalConsumes = from d in customerHospitalConsumes
                                           where d.AddedBy == employeeId
                                           select d;
            }
            FxPageInfo<CustomerHospitalConsumeDto> pageInfo = new FxPageInfo<CustomerHospitalConsumeDto>();
            pageInfo.TotalCount = await customerHospitalConsumes.CountAsync();
            pageInfo.List = await customerHospitalConsumes.OrderByDescending(z => z.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            foreach (var x in pageInfo.List)
            {
                var employeeInfo = dalAmiyaEmployee.GetAll().FirstOrDefaultAsync(z => z.Id == x.AddedBy);
                if (employeeInfo.Result != null)
                {
                    x.EmpolyeeName = employeeInfo.Result.Name;
                }
                else
                {
                    x.EmpolyeeName = "医院添加";
                }
                var checkEmpInfo = dalAmiyaEmployee.GetAll().FirstOrDefaultAsync(z => z.Id == x.CheckBy);
                if (checkEmpInfo.Result != null)
                {
                    x.CheckByEmpName = checkEmpInfo.Result.Name;
                }
                else
                {
                    x.CheckByEmpName = "";
                }
                if (x.LiveAnchorId != 0)
                {
                    var liveanchor = await liveAnchorService.GetByIdAsync(x.LiveAnchorId);
                    x.LiveAnchorName = liveanchor.Name;

                }
            }
            return pageInfo;
        }

        /// <summary>
        /// 根据对账单编号获取升单信息
        /// </summary>
        /// <param name="reconciliationDocumentsId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<CustomerHospitalConsumeDto>> GetByReconciliationDocumentsIdListAsync(string reconciliationDocumentsId, int pageNum, int pageSize)
        {
            var orderIdList = dalRecommandDocumentSettle.GetAll().Where(e => e.RecommandDocumentId == reconciliationDocumentsId && e.OrderFrom == (int)OrderFrom.BuyAgainOrder).Select(e => e.OrderId).ToList();
            var config = await GetCallCenterConfig();
            var customerHospitalConsumes = from d in dalCustomerHospitalConsume.GetAll()
                                           where (orderIdList.Contains(d.Id.ToString()))
                                           join cb in dalCustomerBaseInfo.GetAll() on d.Phone equals cb.Phone into dcb
                                           from cb in dcb.DefaultIfEmpty()
                                           select new CustomerHospitalConsumeDto
                                           {
                                               Id = d.Id,
                                               HospitalId = d.HospitalId,
                                               HospitalName = d.HospitalInfo.Name,
                                               EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                               Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                               Name = cb.Name,
                                               Channel = d.Channel,
                                               ChannelType = ServiceClass.GerConsumeChannelText(d.Channel.Value),
                                               // Age = cb.Age,
                                               IsReturnBackPrice = d.IsReturnBackPrice,
                                               IsConfirmOrder = d.IsConfirmOrder,
                                               ReturnBackPrice = d.ReturnBackPrice,
                                               ReturnBackDate = d.ReturnBackDate,
                                               LiveAnchorId = d.LiveAnchorId,
                                               ConsumeId = d.ConsumeId,
                                               Sex = cb.Sex,
                                               ItemName = d.ItemName,
                                               Price = d.Price,
                                               CreateDate = d.CreateDate,
                                               ConsumeType = d.ConsumeType,
                                               AddedBy = d.AddedBy,
                                               ConsumeTypeText = ServiceClass.GerConsumeTypeText(d.ConsumeType),
                                               NickName = d.NickName,
                                               IsAddedOrder = d.IsAddedOrder,
                                               OrderId = d.OrderId,
                                               WriteOffDate = d.WriteOffDate.Value,
                                               IsCconsultationCard = d.IsCconsultationCard,
                                               BuyAgainType = d.BuyAgainType,
                                               BuyAgainTypeText = ServiceClass.GetBuyAgainTypeText(d.BuyAgainType),
                                               IsSelfLiving = d.IsSelfLiving,
                                               BuyAgainTime = d.BuyAgainTime.Value,
                                               HasBuyagainEvidence = d.HasBuyagainEvidence,
                                               BuyagainEvidencePic = d.BuyagainEvidencePic,
                                               IsCheckToHospital = d.IsCheckToHospital,
                                               CheckToHospitalPic = d.CheckToHospitalPic,
                                               PersonTime = d.PersonTime,
                                               IsReceiveAdditionalPurchase = d.IsReceiveAdditionalPurchase,
                                               CheckBuyAgainPrice = d.CheckBuyAgainPrice,
                                               CheckSettlePrice = d.CheckSettlePrice,
                                               CheckDate = d.CheckDate,
                                               CheckBy = d.CheckBy,
                                               CheckState = ServiceClass.GetCheckTypeText(d.CheckState),
                                               Remark = d.Remark,
                                               CheckRemark = d.CheckRemark,
                                               OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                                               ReconciliationDocumentsId = d.ReconciliationDocumentsId,
                                           };
            FxPageInfo<CustomerHospitalConsumeDto> pageInfo = new FxPageInfo<CustomerHospitalConsumeDto>();
            pageInfo.TotalCount = await customerHospitalConsumes.CountAsync();
            pageInfo.List = await customerHospitalConsumes.OrderByDescending(z => z.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            foreach (var x in pageInfo.List)
            {
                var employeeInfo = dalAmiyaEmployee.GetAll().FirstOrDefaultAsync(z => z.Id == x.AddedBy);
                if (employeeInfo.Result != null)
                {
                    x.EmpolyeeName = employeeInfo.Result.Name;
                }
                else
                {
                    x.EmpolyeeName = "医院添加";
                }
                var checkEmpInfo = dalAmiyaEmployee.GetAll().FirstOrDefaultAsync(z => z.Id == x.CheckBy);
                if (checkEmpInfo.Result != null)
                {
                    x.CheckByEmpName = checkEmpInfo.Result.Name;
                }
                else
                {
                    x.CheckByEmpName = "";
                }
                if (x.LiveAnchorId != 0)
                {
                    var liveanchor = await liveAnchorService.GetByIdAsync(x.LiveAnchorId);
                    x.LiveAnchorName = liveanchor.Name;

                }
            }
            return pageInfo;
        }


        /// <summary>
        /// 根据手机号获取客户消费追踪列表
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<CustomerHospitalConsumeDto>> GetListByPhoneAsync(string phone, int pageNum, int pageSize)
        {

            var config = await GetCallCenterConfig();
            var customerHospitalConsumes = from d in dalCustomerHospitalConsume.GetAll()
                                           where (d.Phone == phone)
                                           join cb in dalCustomerBaseInfo.GetAll() on d.Phone equals cb.Phone into dcb
                                           from cb in dcb.DefaultIfEmpty()
                                           select new CustomerHospitalConsumeDto
                                           {
                                               Id = d.Id,
                                               HospitalId = d.HospitalId,
                                               HospitalName = d.HospitalInfo.Name,
                                               EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                               Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                               Name = cb.Name,
                                               Channel = d.Channel,
                                               ChannelType = ServiceClass.GerConsumeChannelText(d.Channel.Value),
                                               // Age = cb.Age,
                                               IsReturnBackPrice = d.IsReturnBackPrice,
                                               IsConfirmOrder = d.IsConfirmOrder,
                                               ReturnBackPrice = d.ReturnBackPrice,
                                               ReturnBackDate = d.ReturnBackDate,
                                               LiveAnchorId = d.LiveAnchorId,
                                               ConsumeId = d.ConsumeId,
                                               Sex = cb.Sex,
                                               ItemName = d.ItemName,
                                               Price = d.Price,
                                               CreateDate = d.CreateDate,
                                               ConsumeType = d.ConsumeType,
                                               AddedBy = d.AddedBy,
                                               ConsumeTypeText = ServiceClass.GerConsumeTypeText(d.ConsumeType),
                                               NickName = d.NickName,
                                               IsAddedOrder = d.IsAddedOrder,
                                               OrderId = d.OrderId,
                                               WriteOffDate = d.WriteOffDate.Value,
                                               IsCconsultationCard = d.IsCconsultationCard,
                                               BuyAgainType = d.BuyAgainType,
                                               BuyAgainTypeText = ServiceClass.GetBuyAgainTypeText(d.BuyAgainType),
                                               IsSelfLiving = d.IsSelfLiving,
                                               BuyAgainTime = d.BuyAgainTime.Value,
                                               HasBuyagainEvidence = d.HasBuyagainEvidence,
                                               BuyagainEvidencePic = d.BuyagainEvidencePic,
                                               IsCheckToHospital = d.IsCheckToHospital,
                                               CheckToHospitalPic = d.CheckToHospitalPic,
                                               PersonTime = d.PersonTime,
                                               IsReceiveAdditionalPurchase = d.IsReceiveAdditionalPurchase,
                                               CheckBuyAgainPrice = d.CheckBuyAgainPrice,
                                               CheckSettlePrice = d.CheckSettlePrice,
                                               CheckDate = d.CheckDate,
                                               CheckBy = d.CheckBy,
                                               CheckState = ServiceClass.GetCheckTypeText(d.CheckState),
                                               Remark = d.Remark,
                                               CheckRemark = d.CheckRemark,
                                               OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                                               ReconciliationDocumentsId = d.ReconciliationDocumentsId,
                                           };
            FxPageInfo<CustomerHospitalConsumeDto> pageInfo = new FxPageInfo<CustomerHospitalConsumeDto>();
            pageInfo.TotalCount = await customerHospitalConsumes.CountAsync();
            pageInfo.List = await customerHospitalConsumes.OrderByDescending(z => z.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            foreach (var x in pageInfo.List)
            {
                var employeeInfo = dalAmiyaEmployee.GetAll().FirstOrDefaultAsync(z => z.Id == x.AddedBy);
                if (employeeInfo.Result != null)
                {
                    x.EmpolyeeName = employeeInfo.Result.Name;
                }
                else
                {
                    x.EmpolyeeName = "医院添加";
                }
                var checkEmpInfo = dalAmiyaEmployee.GetAll().FirstOrDefaultAsync(z => z.Id == x.CheckBy);
                if (checkEmpInfo.Result != null)
                {
                    x.CheckByEmpName = checkEmpInfo.Result.Name;
                }
                else
                {
                    x.CheckByEmpName = "";
                }
                if (x.LiveAnchorId != 0)
                {
                    var liveanchor = await liveAnchorService.GetByIdAsync(x.LiveAnchorId);
                    x.LiveAnchorName = liveanchor.Name;

                }
            }
            return pageInfo;
        }

        public List<BuyAgainTypeDto> GetBuyAgainTypeList()
        {
            var buyAgainTypes = Enum.GetValues(typeof(BuyAgainType));
            List<BuyAgainTypeDto> buyAgainTypeList = new List<BuyAgainTypeDto>();
            foreach (var item in buyAgainTypes)
            {
                BuyAgainTypeDto orderAppType = new BuyAgainTypeDto();
                orderAppType.Type = Convert.ToByte(item);
                orderAppType.TypeText = ServiceClass.GetBuyAgainTypeText(Convert.ToByte(item));
                buyAgainTypeList.Add(orderAppType);
            }
            return buyAgainTypeList;
        }

        public List<ChannelTypeDto> GetChannelTypeList()
        {
            var channelTypes = Enum.GetValues(typeof(ChannelType));
            List<ChannelTypeDto> channelTypeList = new List<ChannelTypeDto>();
            foreach (var item in channelTypes)
            {
                ChannelTypeDto channelType = new ChannelTypeDto();
                channelType.Type = Convert.ToByte(item);
                channelType.TypeText = ServiceClass.GerConsumeChannelText(Convert.ToByte(item));
                channelTypeList.Add(channelType);
            }
            return channelTypeList;
        }


        private async Task<CallCenterConfigDto> GetCallCenterConfig()
        {
            var config = await dalConfig.GetAll().SingleOrDefaultAsync();
            return JsonConvert.DeserializeObject<WxAppConfigDto>(config.ConfigJson).CallCenterConfig;
        }




        #region 报表相关

        public async Task<List<CustomerHospitalConsumeDto>> GetCustomerHospitalConsuleReportAsync(int? channel, DateTime? checkDateStart, DateTime? checkDateEnd, int? CheckState, int? hospitalId, bool? isCreateBill, string belongCompanyId, string customerName, DateTime startDate, DateTime endDate, bool IsHidePhone)
        {
            var config = await GetCallCenterConfig();
            if (IsHidePhone == false)
            {
                config.EnablePhoneEncrypt = false;
            }
            var customerHospitalConsumes = from d in dalCustomerHospitalConsume.GetAll()
                                           where (string.IsNullOrWhiteSpace(customerName) || d.NickName.Contains(customerName))
                                           && (channel == null || d.Channel == channel)
                                           && d.CreateDate >= startDate.Date && d.CreateDate < endDate.AddDays(1).Date
                                           && (!checkDateStart.HasValue || d.CheckDate >= checkDateStart.Value.Date)
                                           && (!checkDateEnd.HasValue || d.CheckDate < checkDateEnd.Value.AddDays(1).Date)
                                           && (!hospitalId.HasValue || d.HospitalId == hospitalId)
                                           && (!CheckState.HasValue || d.CheckState == CheckState)
                                           && (!isCreateBill.HasValue || d.IsCreateBill == isCreateBill)
                                           && (string.IsNullOrEmpty(belongCompanyId) || d.BelongCompany == belongCompanyId)
                                           join cb in dalCustomerBaseInfo.GetAll() on d.Phone equals cb.Phone into dcb
                                           from cb in dcb.DefaultIfEmpty()
                                           select new CustomerHospitalConsumeDto
                                           {
                                               Id = d.Id,
                                               HospitalId = d.HospitalId,
                                               HospitalName = d.HospitalInfo.Name,
                                               EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                               Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                               Name = cb.Name,
                                               Channel = d.Channel,
                                               ChannelType = ServiceClass.GerConsumeChannelText(d.Channel.Value),
                                               LiveAnchorId = d.LiveAnchorId,
                                               // Age = cb.Age,
                                               Sex = cb.Sex,
                                               ItemName = d.ItemName,
                                               ConsumeId = d.ConsumeId,
                                               Price = d.Price,
                                               CreateDate = d.CreateDate,
                                               ConsumeType = d.ConsumeType,
                                               AddedBy = d.AddedBy,
                                               ConsumeTypeText = ServiceClass.GerConsumeTypeText(d.ConsumeType),
                                               NickName = d.NickName,
                                               IsAddedOrder = d.IsAddedOrder,
                                               IsCreateBill = d.IsCreateBill,
                                               BelongCompanyId = d.BelongCompany,
                                               OrderId = d.OrderId,
                                               OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                                               WriteOffDate = d.WriteOffDate.Value,
                                               IsCconsultationCard = d.IsCconsultationCard,
                                               BuyAgainType = d.BuyAgainType,
                                               BuyAgainTypeText = ServiceClass.GetBuyAgainTypeText(d.BuyAgainType),
                                               IsSelfLiving = d.IsSelfLiving,
                                               BuyAgainTime = d.BuyAgainTime.Value,
                                               HasBuyagainEvidence = d.HasBuyagainEvidence,
                                               BuyagainEvidencePic = d.BuyagainEvidencePic,
                                               IsCheckToHospital = d.IsCheckToHospital,
                                               CheckToHospitalPic = d.CheckToHospitalPic,
                                               PersonTime = d.PersonTime,
                                               IsReceiveAdditionalPurchase = d.IsReceiveAdditionalPurchase,
                                               CheckBuyAgainPrice = d.CheckBuyAgainPrice,
                                               CheckSettlePrice = d.CheckSettlePrice,
                                               CheckDate = d.CheckDate,
                                               CheckBy = d.CheckBy,
                                               CheckState = ServiceClass.GetCheckTypeText(d.CheckState),
                                               Remark = d.Remark,
                                               CheckRemark = d.CheckRemark,
                                               IsReturnBackPrice = d.IsReturnBackPrice,
                                               ReturnBackDate = d.ReturnBackDate,
                                               ReturnBackPrice = d.ReturnBackPrice,
                                           };

            List<CustomerHospitalConsumeDto> pageInfo = new List<CustomerHospitalConsumeDto>();
            pageInfo = await customerHospitalConsumes.OrderByDescending(z => z.CreateDate).ToListAsync();
            foreach (var x in pageInfo)
            {
                var employeeInfo = dalAmiyaEmployee.GetAll().FirstOrDefaultAsync(z => z.Id == x.AddedBy);
                if (employeeInfo.Result != null)
                {
                    x.EmpolyeeName = employeeInfo.Result.Name;
                }
                else
                {
                    x.EmpolyeeName = "医院添加";
                }
                var checkEmpInfo = dalAmiyaEmployee.GetAll().FirstOrDefaultAsync(z => z.Id == x.CheckBy);
                if (checkEmpInfo.Result != null)
                {
                    x.CheckByEmpName = checkEmpInfo.Result.Name;
                }
                else
                {
                    x.CheckByEmpName = "";
                }
                if (x.LiveAnchorId != 0)
                {
                    var liveanchor = await liveAnchorService.GetByIdAsync(x.LiveAnchorId);
                    x.LiveAnchorName = liveanchor.Name;
                }
                if (x.IsCreateBill == true)
                {
                    var belongCompanyInfo = await companyBaseInfoService.GetByIdAsync(x.BelongCompanyId);
                    x.BelongCompanyName = belongCompanyInfo.Name;
                }
            }
            return pageInfo;
        }

        #endregion

        #region 【数据中心板块】
        /// <summary>
        /// 获取时间段内已成交金额数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<OrderPriceConditionDto>> GetOrderDealPriceDataAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
            var orders = from d in dalCustomerHospitalConsume.GetAll()
                         where d.CreateDate >= startrq && d.CreateDate < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.CreateDate.Date).Select(x => new OrderPriceConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderPrice = x.Sum(z => z.Price) }).ToList();
        }

        /// <summary>
        /// 获取时间段内升单到院人数
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<OrderOperationConditionDto>> GetOrderToHospitalDataAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
            var orders = from d in dalCustomerHospitalConsume.GetAll()
                         where d.CreateDate >= startrq && d.CreateDate < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.CreateDate.Date).Select(x => new OrderOperationConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderNum = x.ToList().Count }).ToList();
        }

        /// <summary>
        /// 获取时间段内已成交金额与人数数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<HospitalOrderNumAndPriceDto>> GetOrderDealPriceAndNumDataAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
            var orders = from d in dalCustomerHospitalConsume.GetAll()
                         where d.CreateDate >= startrq && d.CreateDate < endrq
                         select d;
            var customerHospitalConsume = from d in orders
                                          select new HospitalOrderNumAndPriceDto
                                          {
                                              Price = d.Price,
                                              HospitalName = d.HospitalInfo.Name.ToString(),
                                              OrderNum = 1
                                          };
            return customerHospitalConsume.ToList();
        }


        /// <summary>
        /// 获取时间段内对账业绩
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<OrderPriceConditionDto>> GetCheckForPerformanceDataAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
            var orders = from d in dalCustomerHospitalConsume.GetAll()
                         where d.CheckState == (int)CheckType.CheckedSuccess && d.CheckDate.Value >= startrq && d.CheckDate.Value < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.CheckDate.Value.Date).Select(x => new OrderPriceConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderPrice = x.Sum(z => z.CheckBuyAgainPrice.Value) }).ToList();
        }

        /// <summary>
        /// 获取时间段内回款业绩
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<OrderPriceConditionDto>> GetReturnBackPriceDataAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
            var orders = from d in dalCustomerHospitalConsume.GetAll()
                         where d.IsReturnBackPrice == true && d.ReturnBackDate.Value >= startrq && d.ReturnBackDate.Value < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.ReturnBackDate.Value.Date).Select(x => new OrderPriceConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderPrice = x.Sum(z => z.ReturnBackPrice.Value) }).ToList();
        }
        #endregion


        #region 【对账板块】
        /// <summary>
        /// 获取时间段内未对账机构列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<UnCheckHospitalOrderDto>> GetUnCheckHospitalOrderAsync(DateTime? startDate, DateTime? endDate, int? hospitalId)
        {
            DateTime startrq = new DateTime();
            DateTime endrq = new DateTime();
            if (startDate.HasValue)
            {
                startrq = ((DateTime)startDate);
            }
            if (endDate.HasValue)
            {
                endrq = ((DateTime)endDate).Date.AddDays(1);
            }
            var orders = from d in dalCustomerHospitalConsume.GetAll()
                         where (!startDate.HasValue || d.CreateDate >= startrq)
                         && (!endDate.HasValue || d.CreateDate <= endrq)
                         && (d.CheckState == (int)CheckType.NotChecked)
                         && (!hospitalId.HasValue || d.HospitalId == hospitalId)
                         && (d.IsConfirmOrder == true)
                         && (!hospitalId.HasValue || d.HospitalId == hospitalId)
                         select d;
            var orderList = await orders.ToListAsync();
            return orderList.GroupBy(x => x.HospitalId).Select(x => new UnCheckHospitalOrderDto { HospitalId = x.Key, TotalUnCheckPrice = x.Sum(z => z.Price), TotalUnCheckOrderCount = x.Count() }).ToList();
        }
        #endregion

        #region 财务看板

        /// <summary>
        /// 财务看板主播业绩
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="liveAnchorId">主播id</param>
        /// <returns></returns>
        public async Task<List<LiveAnchorBoardDataDto>> GetLiveAnchorPriceByLiveAnchorIdAsync(DateTime? startDate, DateTime? endDate, List<int> liveAnchorIds)
        {
            startDate = startDate == null ? DateTime.Now.Date : startDate.Value.Date;
            endDate = endDate == null ? DateTime.Now.AddDays(1).Date : endDate.Value.AddDays(1).Date;
            var dataList = dalCustomerHospitalConsume.GetAll().Where(e => e.CheckDate >= startDate && e.CheckDate < endDate && e.CheckState == 2)
                .Where(e => liveAnchorIds.Count==0 || liveAnchorIds.Contains(e.LiveAnchorId))
                .GroupBy(e => new { e.LiveAnchorId, e.BelongCompany })
                .Select(e => new LiveAnchorBoardDataDto
                {
                    CompanyName = e.Key.BelongCompany,
                    LiveAnchorName = e.Key.LiveAnchorId.ToString(),
                    DealPrice = e.Sum(item => item.CheckBuyAgainPrice) ?? 0m,
                    TotalServicePrice = e.Sum(item => item.CheckSettlePrice) ?? 0m,
                    NewCustomerPrice = 0m,
                    OldCustomerPrice = e.Sum(item => item.CheckBuyAgainPrice) ?? 0m,
                    NewCustomerServicePrice = 0m,
                    OldCustomerServicePrice = e.Sum(item => item.CheckSettlePrice) ?? 0m,
                }).ToList();
            foreach (var item in dataList)
            {
                item.LiveAnchorName = dalLiveAnchor.GetAll().Where(e => e.Id == Convert.ToInt32(item.LiveAnchorName)).Select(e => e.Name).SingleOrDefault() ?? "未知(订单没有主播归属信息)";
                item.CompanyName = dalCompanyBaseInfo.GetAll().Where(e => e.Id == item.CompanyName).Select(e => e.Name).SingleOrDefault() ?? "未知(已对账未开票)";
            }
            return dataList;
        }
        /// <summary>
        /// 根据客服id获取财务看板客服业绩信息
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="customerServiceId"></param>
        /// <returns></returns>
        public async Task<List<CustomerServiceBoardDataDto>> GetCustomerServiceBoardDataByCustomerServiceIdAsync(DateTime? startDate, DateTime? endDate, int? customerServiceId)
        {
            startDate = startDate == null ? DateTime.Now.Date : startDate.Value.Date;
            endDate = endDate == null ? DateTime.Now.AddDays(1).Date : endDate.Value.AddDays(1).Date;
            var dealData =await dalCustomerHospitalConsume.GetAll()
                .Where(e => e.CheckDate >= startDate && e.CheckDate < endDate  && e.CheckState == 2)
                .Where(e=>!customerServiceId.HasValue||e.AddedBy==customerServiceId)
                .GroupBy(e => e.AddedBy)
                .Select(e => new CustomerServiceBoardDataDto
                {
                    CustomerServiceName = Convert.ToString(e.Key),
                    DealPrice = e.Sum(item => item.CheckBuyAgainPrice) ?? 0m,
                    TotalServicePrice = e.Sum(item => item.CheckSettlePrice) ?? 0m,
                    NewCustomerPrice = 0m,
                    NewCustomerServicePrice = 0m,
                    OldCustomerPrice = e.Sum(item => item.CheckBuyAgainPrice ?? 0m),
                    OldCustomerServicePrice = e.Sum(item => item.CheckSettlePrice ?? 0m)
                }).ToListAsync();
            //if (dealData != null)
            //    dealData.CustomerServiceName = await dalAmiyaEmployee.GetAll().Where(e => e.Id == Convert.ToInt32(customerServiceId)).Select(e => e.Name).FirstOrDefaultAsync() ?? "未知";
            return dealData;
        }

        #endregion

        public List<CheckStateTypeDto> GetCheckStateType()
        {
            var checkStateTypes = Enum.GetValues(typeof(CheckType));
            List<CheckStateTypeDto> orderAppTypeList = new List<CheckStateTypeDto>();
            foreach (var item in checkStateTypes)
            {
                CheckStateTypeDto orderAppType = new CheckStateTypeDto();
                orderAppType.Id = Convert.ToByte(item);
                orderAppType.Name = ServiceClass.GetCheckTypeText(Convert.ToByte(item));
                orderAppTypeList.Add(orderAppType);
            }
            return orderAppTypeList;
        }
        /// <summary>
        /// 更新订单和成交信息开票和开票公司信息
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        public async Task UpdateCreateBillAndBelongCompany(UpdateCreateBillAndCompanyDto update)
        {
            var order = dalCustomerHospitalConsume.GetAll().Where(e => e.Id == Convert.ToInt32(update.OrderId)).SingleOrDefault();
            if (order == null) throw new Exception("升单编号不存在");
            order.IsCreateBill = update.IsCreateBill;
            order.BelongCompany = update.CreateBillCompanyId;
            await dalCustomerHospitalConsume.UpdateAsync(order, true);
        }
    }
}
