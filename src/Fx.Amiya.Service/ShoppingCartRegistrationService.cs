﻿using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ShoppingCartRegistration;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Infrastructure.DataAccess;
using jos_sdk_net.Util;

namespace Fx.Amiya.Service
{
    public class ShoppingCartRegistrationService : IShoppingCartRegistrationService
    {
        private IDalShoppingCartRegistration dalShoppingCartRegistration;
        private IContentPlatformService _contentPlatformService;
        private ILiveAnchorWeChatInfoService _liveAnchorWeChatInfoService;
        private ILiveAnchorService _liveAnchorService;
        private IUnitOfWork unitOfWork;
        private IAmiyaEmployeeService _amiyaEmployeeService;
        private IDalAmiyaEmployee dalAmiyaEmployee;
        public ShoppingCartRegistrationService(IDalShoppingCartRegistration dalShoppingCartRegistration,
            IContentPlatformService contentPlatformService,
            IAmiyaEmployeeService amiyaEmployeeService,
            IUnitOfWork unitOfWork,
            ILiveAnchorService liveAnchorService,
             ILiveAnchorWeChatInfoService liveAnchorWeChatInfoService,
            IDalAmiyaEmployee dalAmiyaEmployee)
        {
            this.dalShoppingCartRegistration = dalShoppingCartRegistration;
            _contentPlatformService = contentPlatformService;
            _liveAnchorService = liveAnchorService;
            this.unitOfWork = unitOfWork;
            _liveAnchorWeChatInfoService = liveAnchorWeChatInfoService;
            _amiyaEmployeeService = amiyaEmployeeService;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
        }



        public async Task<FxPageInfo<ShoppingCartRegistrationDto>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, int? LiveAnchorId, bool? isCreateOrder, bool? isSendOrder, int? employeeId, bool? isAddWechat, bool? isWriteOff, bool? isConsultation, bool? isReturnBackPrice, string keyword, string contentPlatFormId, int pageNum, int pageSize, decimal? minPrice, decimal? maxPrice, int? admissionId, DateTime? startRefundTime, DateTime? endRefundTime, DateTime? startBadReviewTime, DateTime? endBadReviewTime, int? emergencyLevel, bool? isBadReview)
        {
            try
            {
                var shoppingCartRegistration = from d in dalShoppingCartRegistration.GetAll()
                                               where (keyword == null || d.Phone.Contains(keyword) || d.CustomerNickName.Contains(keyword) || d.LiveAnchorWechatNo.Contains(keyword))
                                               && ((!startDate.HasValue && !endDate.HasValue) || d.RecordDate >= startDate.Value.Date && d.RecordDate < endDate.Value.AddDays(1).Date)
                                               && (string.IsNullOrEmpty(contentPlatFormId) || d.ContentPlatFormId == contentPlatFormId)
                                               && (!isAddWechat.HasValue || d.IsAddWeChat == isAddWechat)
                                               && (!isWriteOff.HasValue || d.IsWriteOff == isWriteOff)
                                               && (!isSendOrder.HasValue || d.IsSendOrder == isSendOrder)
                                               && (!isCreateOrder.HasValue || d.IsCreateOrder == isCreateOrder)
                                               && (!isConsultation.HasValue || d.IsConsultation == isConsultation)
                                               && (!isReturnBackPrice.HasValue || d.IsReturnBackPrice == isReturnBackPrice)
                                               && (!admissionId.HasValue || d.CreateBy == admissionId)
                                               && (!minPrice.HasValue || d.Price >= minPrice)
                                               && (!maxPrice.HasValue || d.Price <= maxPrice)
                                               && (!LiveAnchorId.HasValue || d.LiveAnchorId == LiveAnchorId)
                                               && (!startRefundTime.HasValue || d.RefundDate >= startRefundTime.Value.Date)
                                               && (!endRefundTime.HasValue || d.RefundDate <= endRefundTime.Value.AddDays(1).Date)
                                               &&(!startBadReviewTime.HasValue || d.BadReviewDate>=startBadReviewTime.Value.Date)
                                               &&(!endBadReviewTime.HasValue || d.BadReviewDate<=endBadReviewTime.Value.AddDays(1).Date)              
                                               && (!emergencyLevel.HasValue || d.EmergencyLevel == emergencyLevel)
                                               && (!isBadReview.HasValue || d.IsBadReview==isBadReview)
                                     
                                               select new ShoppingCartRegistrationDto
                                               {
                                                   Id = d.Id,
                                                   RecordDate = d.RecordDate,
                                                   ContentPlatFormId = d.ContentPlatFormId,
                                                   LiveAnchorId = d.LiveAnchorId,
                                                   LiveAnchorWechatNo = d.LiveAnchorWechatNo,
                                                   CustomerNickName = d.CustomerNickName,
                                                   Phone = d.Phone,
                                                   Price = d.Price,
                                                   ConsultationType = d.ConsultationType,
                                                   IsWriteOff = d.IsWriteOff,
                                                   IsCreateOrder = d.IsCreateOrder,
                                                   IsSendOrder = d.IsSendOrder,
                                                   IsConsultation = d.IsConsultation,
                                                   IsAddWeChat = d.IsAddWeChat,
                                                   IsReturnBackPrice = d.IsReturnBackPrice,
                                                   Remark = d.Remark,
                                                   CreateBy = d.CreateBy,
                                                   CreateDate = d.CreateDate,
                                                   IsReContent = d.IsReContent,
                                                   ReContent = d.ReContent,
                                                   RefundDate = d.RefundDate,
                                                   RefundReason = d.RefundReason,
                                                   BadReviewDate = d.BadReviewDate,
                                                   BadReviewContent = d.BadReviewContent,
                                                   BadReviewReason = d.BadReviewReason,
                                                   IsBadReview = d.IsBadReview,
                                                   EmergencyLevel=d.EmergencyLevel

                                               };
                var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                {
                    shoppingCartRegistration = from d in shoppingCartRegistration
                                               where d.CreateBy == employeeId
                                               select d;
                }
                FxPageInfo<ShoppingCartRegistrationDto> shoppingCartRegistrationPageInfo = new FxPageInfo<ShoppingCartRegistrationDto>();
                shoppingCartRegistrationPageInfo.TotalCount = await shoppingCartRegistration.CountAsync();
                shoppingCartRegistrationPageInfo.List = await shoppingCartRegistration.OrderByDescending(x => x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                foreach (var x in shoppingCartRegistrationPageInfo.List)
                {
                    var contentPlatFormInfo = await _contentPlatformService.GetByIdAsync(x.ContentPlatFormId);
                    x.ContentPlatFormName = contentPlatFormInfo.ContentPlatformName;
                    var liveAnchorInfo = await _liveAnchorService.GetByIdAsync(x.LiveAnchorId);
                    x.LiveAnchorName = liveAnchorInfo.Name;
                    var empInfo = await _amiyaEmployeeService.GetByIdAsync(x.CreateBy);
                    x.CreateByName = empInfo.Name;
                }
                return shoppingCartRegistrationPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(AddShoppingCartRegistrationDto addDto)
        {
            //unitOfWork.BeginTransaction();


            try
            {
                //if (!string.IsNullOrEmpty(addDto.Phone))
                //{
                //    var bind = await _dalBindCustomerService.GetAll()
                //  .Include(e => e.CustomerServiceAmiyaEmployee)
                //  .SingleOrDefaultAsync(e => e.BuyerPhone == addDto.Phone);
                //    if (bind != null)
                //    {
                //        if (bind.CustomerServiceId != addDto.CreateBy)
                //        {
                //            var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == addDto.CreateBy);
                //            if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                //            {
                //                throw new Exception("该客户已绑定给" + bind.CustomerServiceAmiyaEmployee.Name + ",请联系对应人员进行操作！");
                //            }
                //        }

                //    }
                //    else
                //    {
                //        //添加绑定客服
                //        BindCustomerService bindCustomerService = new BindCustomerService();
                //        bindCustomerService.CustomerServiceId = addDto.CreateBy;
                //        bindCustomerService.BuyerPhone = addDto.Phone;
                //        bindCustomerService.UserId = null;
                //        bindCustomerService.CreateBy = addDto.CreateBy;
                //        bindCustomerService.CreateDate = DateTime.Now;
                //        await _dalBindCustomerService.AddAsync(bindCustomerService, true);
                //    }
                //}

                ShoppingCartRegistration shoppingCartRegistration = new ShoppingCartRegistration();
                shoppingCartRegistration.Id = CreateOrderIdHelper.GetNextNumber();
                shoppingCartRegistration.RecordDate = addDto.RecordDate;
                shoppingCartRegistration.ContentPlatFormId = addDto.ContentPlatFormId;
                shoppingCartRegistration.LiveAnchorId = addDto.LiveAnchorId;
                shoppingCartRegistration.LiveAnchorWechatNo = addDto.LiveAnchorWechatNo;
                shoppingCartRegistration.CustomerNickName = addDto.CustomerNickName;
                shoppingCartRegistration.Phone = addDto.Phone;
                shoppingCartRegistration.IsAddWeChat = addDto.IsAddWeChat;
                shoppingCartRegistration.Price = addDto.Price;
                shoppingCartRegistration.ConsultationType = addDto.ConsultationType;
                shoppingCartRegistration.IsWriteOff = addDto.IsWriteOff;
                shoppingCartRegistration.IsConsultation = addDto.IsConsultation;
                shoppingCartRegistration.IsReturnBackPrice = addDto.IsReturnBackPrice;
                shoppingCartRegistration.Remark = addDto.Remark;
                shoppingCartRegistration.CreateBy = addDto.CreateBy;
                shoppingCartRegistration.CreateDate = DateTime.Now;
                shoppingCartRegistration.BadReviewContent = addDto.BadReviewContent;
                shoppingCartRegistration.BadReviewDate = addDto.BadReviewDate;
                shoppingCartRegistration.BadReviewReason = addDto.BadReviewReason;
                shoppingCartRegistration.IsReContent = addDto.IsReContent;
                shoppingCartRegistration.ReContent = addDto.ReContent;
                shoppingCartRegistration.RefundDate = addDto.RefundDate;
                shoppingCartRegistration.RefundReason = addDto.RefundReason;
                shoppingCartRegistration.IsBadReview = addDto.IsBadReview;
                shoppingCartRegistration.IsCreateOrder = false;
                shoppingCartRegistration.IsSendOrder = false;
                shoppingCartRegistration.EmergencyLevel = addDto.EmergencyLevel;
                await dalShoppingCartRegistration.AddAsync(shoppingCartRegistration, true);

                //unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                //unitOfWork.RollBack();
                throw ex;
            }
        }

        public async Task<ShoppingCartRegistrationDto> GetByIdAsync(string id)
        {
            try
            {
                var shoppingCartRegistration = await dalShoppingCartRegistration.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (shoppingCartRegistration == null)
                {
                    return new ShoppingCartRegistrationDto();
                }

                ShoppingCartRegistrationDto shoppingCartRegistrationDto = new ShoppingCartRegistrationDto();
                shoppingCartRegistrationDto.Id = shoppingCartRegistration.Id;
                shoppingCartRegistrationDto.RecordDate = shoppingCartRegistration.RecordDate;
                shoppingCartRegistrationDto.ContentPlatFormId = shoppingCartRegistration.ContentPlatFormId;
                shoppingCartRegistrationDto.LiveAnchorId = shoppingCartRegistration.LiveAnchorId;
                shoppingCartRegistrationDto.LiveAnchorWechatNo = shoppingCartRegistration.LiveAnchorWechatNo;
                //var wechatInfo = await _liveAnchorWeChatInfoService.GetValidAsync();
                //var wechatResult = wechatInfo.FirstOrDefault(x => x.LiveAnchorId == shoppingCartRegistration.LiveAnchorId && x.WeChatNo == shoppingCartRegistration.LiveAnchorWechatNo);
                //shoppingCartRegistrationDto.LiveAnchorWeChatId = wechatResult.Id;
                shoppingCartRegistrationDto.CustomerNickName = shoppingCartRegistration.CustomerNickName;
                shoppingCartRegistrationDto.Phone = shoppingCartRegistration.Phone;
                shoppingCartRegistrationDto.Price = shoppingCartRegistration.Price;
                shoppingCartRegistrationDto.IsAddWeChat = shoppingCartRegistration.IsAddWeChat;
                shoppingCartRegistrationDto.ConsultationType = shoppingCartRegistration.ConsultationType;
                shoppingCartRegistrationDto.IsWriteOff = shoppingCartRegistration.IsWriteOff;
                shoppingCartRegistrationDto.IsConsultation = shoppingCartRegistration.IsConsultation;
                shoppingCartRegistrationDto.IsReturnBackPrice = shoppingCartRegistration.IsReturnBackPrice;
                shoppingCartRegistrationDto.Remark = shoppingCartRegistration.Remark;
                shoppingCartRegistrationDto.CreateBy = shoppingCartRegistration.CreateBy;
                shoppingCartRegistrationDto.IsCreateOrder = shoppingCartRegistration.IsCreateOrder;
                shoppingCartRegistrationDto.IsSendOrder = shoppingCartRegistration.IsSendOrder;
                shoppingCartRegistrationDto.CreateDate = shoppingCartRegistration.CreateDate;
                shoppingCartRegistrationDto.IsReContent = shoppingCartRegistration.IsReContent;
                shoppingCartRegistrationDto.ReContent = shoppingCartRegistration.ReContent;
                shoppingCartRegistrationDto.RefundDate = shoppingCartRegistration.RefundDate;
                shoppingCartRegistrationDto.RefundReason = shoppingCartRegistration.RefundReason;
                shoppingCartRegistrationDto.BadReviewDate = shoppingCartRegistration.BadReviewDate;
                shoppingCartRegistrationDto.BadReviewContent = shoppingCartRegistration.BadReviewContent;
                shoppingCartRegistrationDto.BadReviewReason = shoppingCartRegistration.BadReviewReason;
                shoppingCartRegistrationDto.IsBadReview = shoppingCartRegistration.IsBadReview;
                shoppingCartRegistrationDto.EmergencyLevel = shoppingCartRegistration.EmergencyLevel;
               
                return shoppingCartRegistrationDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ShoppingCartRegistrationDto> GetByPhoneAsync(string phone)
        {
            try
            {
                var shoppingCartRegistration = await dalShoppingCartRegistration.GetAll().FirstOrDefaultAsync(e => e.Phone == phone);
                if (shoppingCartRegistration == null)
                {
                    return new ShoppingCartRegistrationDto();
                }

                ShoppingCartRegistrationDto shoppingCartRegistrationDto = new ShoppingCartRegistrationDto();
                shoppingCartRegistrationDto.Id = shoppingCartRegistration.Id;
                shoppingCartRegistrationDto.RecordDate = shoppingCartRegistration.RecordDate;
                shoppingCartRegistrationDto.ContentPlatFormId = shoppingCartRegistration.ContentPlatFormId;
                shoppingCartRegistrationDto.LiveAnchorId = shoppingCartRegistration.LiveAnchorId;
                shoppingCartRegistrationDto.LiveAnchorWechatNo = shoppingCartRegistration.LiveAnchorWechatNo;
                shoppingCartRegistrationDto.CustomerNickName = shoppingCartRegistration.CustomerNickName;
                shoppingCartRegistrationDto.Phone = shoppingCartRegistration.Phone;
                shoppingCartRegistrationDto.Price = shoppingCartRegistration.Price;
                shoppingCartRegistrationDto.IsCreateOrder = shoppingCartRegistration.IsCreateOrder;
                shoppingCartRegistrationDto.IsSendOrder = shoppingCartRegistration.IsSendOrder;
                shoppingCartRegistrationDto.IsAddWeChat = shoppingCartRegistration.IsAddWeChat;
                shoppingCartRegistrationDto.ConsultationType = shoppingCartRegistration.ConsultationType;
                shoppingCartRegistrationDto.IsWriteOff = shoppingCartRegistration.IsWriteOff;
                shoppingCartRegistrationDto.IsConsultation = shoppingCartRegistration.IsConsultation;
                shoppingCartRegistrationDto.IsReturnBackPrice = shoppingCartRegistration.IsReturnBackPrice;
                shoppingCartRegistrationDto.Remark = shoppingCartRegistration.Remark;
                shoppingCartRegistrationDto.CreateBy = shoppingCartRegistration.CreateBy;
                shoppingCartRegistrationDto.CreateDate = shoppingCartRegistration.CreateDate;
                shoppingCartRegistrationDto.IsReContent = shoppingCartRegistration.IsReContent;
                shoppingCartRegistrationDto.ReContent = shoppingCartRegistration.ReContent;
                shoppingCartRegistrationDto.RefundDate = shoppingCartRegistration.RefundDate;
                shoppingCartRegistrationDto.RefundReason = shoppingCartRegistration.RefundReason;
                shoppingCartRegistrationDto.BadReviewDate = shoppingCartRegistration.BadReviewDate;
                shoppingCartRegistrationDto.BadReviewContent = shoppingCartRegistration.BadReviewContent;
                shoppingCartRegistrationDto.BadReviewReason = shoppingCartRegistration.BadReviewReason;
                shoppingCartRegistrationDto.IsBadReview = shoppingCartRegistration.IsBadReview;
                return shoppingCartRegistrationDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(UpdateShoppingCartRegistrationDto updateDto)
        {
            //   unitOfWork.BeginTransaction();
            try
            {
                var shoppingCartRegistration = await dalShoppingCartRegistration.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (shoppingCartRegistration == null)
                    throw new Exception("小黄车登记编号错误！");
                //if (!string.IsNullOrEmpty(updateDto.Phone))
                //{
                //    var bind = await _dalBindCustomerService.GetAll()
                //  .Include(e => e.CustomerServiceAmiyaEmployee)
                //  .SingleOrDefaultAsync(e => e.BuyerPhone == updateDto.Phone);
                //    if (bind != null)
                //    {
                //        if (bind.CustomerServiceId != shoppingCartRegistration.CreateBy)
                //        {
                //            var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == shoppingCartRegistration.CreateBy);
                //            if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                //            {
                //                throw new Exception("该客户已绑定给" + bind.CustomerServiceAmiyaEmployee.Name + ",请联系对应人员进行操作！");
                //            }
                //        }

                //    }
                //    else
                //    {
                //        //添加绑定客服
                //        BindCustomerService bindCustomerService = new BindCustomerService();
                //        bindCustomerService.CustomerServiceId = shoppingCartRegistration.CreateBy;
                //        bindCustomerService.BuyerPhone = updateDto.Phone;
                //        bindCustomerService.UserId = null;
                //        bindCustomerService.CreateBy = shoppingCartRegistration.CreateBy;
                //        bindCustomerService.CreateDate = DateTime.Now;
                //        await _dalBindCustomerService.AddAsync(bindCustomerService, true);
                //    }
                //}
                shoppingCartRegistration.RecordDate = updateDto.RecordDate;
                shoppingCartRegistration.ContentPlatFormId = updateDto.ContentPlatFormId;
                shoppingCartRegistration.LiveAnchorId = updateDto.LiveAnchorId;
                shoppingCartRegistration.LiveAnchorWechatNo = updateDto.LiveAnchorWechatNo;
                shoppingCartRegistration.CustomerNickName = updateDto.CustomerNickName;
                shoppingCartRegistration.Phone = updateDto.Phone;
                shoppingCartRegistration.Price = updateDto.Price;
                shoppingCartRegistration.IsAddWeChat = updateDto.IsAddWeChat;
                shoppingCartRegistration.ConsultationType = updateDto.ConsultationType;
                shoppingCartRegistration.IsWriteOff = updateDto.IsWriteOff;
                shoppingCartRegistration.IsConsultation = updateDto.IsConsultation;
                shoppingCartRegistration.IsReturnBackPrice = updateDto.IsReturnBackPrice;
                shoppingCartRegistration.Remark = updateDto.Remark;
                shoppingCartRegistration.IsReContent = updateDto.IsReContent;
                shoppingCartRegistration.ReContent = updateDto.ReContent;
                shoppingCartRegistration.RefundDate = updateDto.RefundDate;
                shoppingCartRegistration.RefundReason = updateDto.RefundReason;
                shoppingCartRegistration.BadReviewDate = updateDto.BadReviewDate;
                shoppingCartRegistration.BadReviewContent = updateDto.BadReviewContent;
                shoppingCartRegistration.BadReviewReason = updateDto.BadReviewReason;
                shoppingCartRegistration.IsBadReview = updateDto.IsBadReview;
                shoppingCartRegistration.CreateBy = updateDto.CreateBy;
                shoppingCartRegistration.EmergencyLevel = updateDto.EmergencyLevel;
                await dalShoppingCartRegistration.UpdateAsync(shoppingCartRegistration, true);
                // unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                // unitOfWork.RollBack();
                throw ex;
            }
        }

        /// <summary>
        /// 录单触达
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public async Task UpdateCreateOrderAsync(string phone)
        {
            //   unitOfWork.BeginTransaction();
            try
            {
                var shoppingCartRegistration = await dalShoppingCartRegistration.GetAll().Where(e => e.Phone == phone).ToListAsync();
                if(shoppingCartRegistration.Count>0)
                {
                   foreach(var x in shoppingCartRegistration) { 
                        x.IsCreateOrder = true;
                        x.IsAddWeChat = true;
                        x.IsWriteOff = true;
                        x.IsConsultation = true;
                        await dalShoppingCartRegistration.UpdateAsync(x, true);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 派单触达
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public async Task UpdateSendOrderAsync(string phone)
        {
            //   unitOfWork.BeginTransaction();
            try
            {
                var shoppingCartRegistration = await dalShoppingCartRegistration.GetAll().Where(e => e.Phone == phone).ToListAsync();
                if (shoppingCartRegistration.Count > 0)
                {
                    foreach (var x in shoppingCartRegistration)
                    {
                        x.IsSendOrder = true;
                        await dalShoppingCartRegistration.UpdateAsync(x, true);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var shoppingCartRegistration = await dalShoppingCartRegistration.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (shoppingCartRegistration == null)
                    throw new Exception("小黄车登记编号错误");

                await dalShoppingCartRegistration.DeleteAsync(shoppingCartRegistration, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<EmergencyLevelDto> GetEmergencyLevelList()
        {
            var emergencyLevels = Enum.GetValues(typeof(EmergencyLevel));
            List<EmergencyLevelDto> emergencyLevelList = new List<EmergencyLevelDto>();
            foreach (var item in emergencyLevels)
            {
                EmergencyLevelDto emergencyLevelDto = new EmergencyLevelDto();
                emergencyLevelDto.EmergencyLevel = Convert.ToInt32(item);
                emergencyLevelDto.EmergencyText = ServiceClass.GetShopCartRegisterEmergencyLevelText(emergencyLevelDto.EmergencyLevel);
                emergencyLevelList.Add(emergencyLevelDto);
            }
            return emergencyLevelList;
        }

        #region 【报表相关】
        public async Task<List<ShoppingCartRegistrationDto>> GetShoppingCartRegistrationReportAsync(DateTime? startDate, DateTime? endDate, int? emergencyLevel, int? LiveAnchorId, bool? isCreateOrder, bool? isSendOrder, int? employeeId, bool? isAddWechat, bool? isWriteOff, bool? isConsultation, bool? isReturnBackPrice, string keyword, string contentPlatFormId, bool isHidePhone)
        {
            try
            {
                var shoppingCartRegistration = from d in dalShoppingCartRegistration.GetAll().Include(x => x.Contentplatform).Include(x => x.LiveAnchor).Include(x => x.AmiyaEmployee)
                                               where (keyword == null || d.Phone.Contains(keyword) || d.CustomerNickName.Contains(keyword))
                                               && ((!startDate.HasValue && !endDate.HasValue) || d.RecordDate >= startDate.Value.Date && d.RecordDate < endDate.Value.AddDays(1).Date)
                                               && (string.IsNullOrEmpty(contentPlatFormId) || d.ContentPlatFormId == contentPlatFormId)
                                               && (!LiveAnchorId.HasValue || d.LiveAnchorId == LiveAnchorId) && (!isAddWechat.HasValue || d.IsAddWeChat == isAddWechat)
                                               && (!isWriteOff.HasValue || d.IsWriteOff == isWriteOff)
                                               && (!emergencyLevel.HasValue || d.EmergencyLevel == emergencyLevel)
                                               && (!isConsultation.HasValue || d.IsConsultation == isConsultation)
                                               && (!isSendOrder.HasValue || d.IsSendOrder == isSendOrder)
                                               && (!isCreateOrder.HasValue || d.IsCreateOrder == isCreateOrder)
                                               && (!isReturnBackPrice.HasValue || d.IsReturnBackPrice == isReturnBackPrice)
                                               select new ShoppingCartRegistrationDto
                                               {
                                                   Id = d.Id,
                                                   RecordDate = d.RecordDate,
                                                   ContentPlatFormId = d.ContentPlatFormId,
                                                   ContentPlatFormName = d.Contentplatform.ContentPlatformName,
                                                   LiveAnchorId = d.LiveAnchorId,
                                                   EmergencyLevel=d.EmergencyLevel,
                                                   LiveAnchorName = d.LiveAnchor.Name,
                                                   IsCreateOrder = d.IsCreateOrder,
                                                   IsSendOrder = d.IsSendOrder,
                                                   LiveAnchorWechatNo = d.LiveAnchorWechatNo,
                                                   CustomerNickName = d.CustomerNickName,
                                                   Phone = isHidePhone == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                                   Price = d.Price,
                                                   ConsultationType = d.ConsultationType,
                                                   IsWriteOff = d.IsWriteOff,
                                                   IsAddWeChat = d.IsAddWeChat,
                                                   IsConsultation = d.IsConsultation,
                                                   IsReturnBackPrice = d.IsReturnBackPrice,
                                                   Remark = d.Remark,
                                                   CreateBy = d.CreateBy,
                                                   CreateByName=d.AmiyaEmployee.Name,
                                                   CreateDate = d.CreateDate,
                                                   ConsultationTypeText=ServiceClass.GetConsulationTypeText(d.ConsultationType)
                                               };
                var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                {
                    shoppingCartRegistration = from d in shoppingCartRegistration
                                               where d.CreateBy == employeeId
                                               select d;
                }
                List<ShoppingCartRegistrationDto> shoppingCartRegistrationPageInfo = new List<ShoppingCartRegistrationDto>();
                shoppingCartRegistrationPageInfo = await shoppingCartRegistration.OrderByDescending(x => x.RecordDate).ToListAsync();
                return shoppingCartRegistrationPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      

        #endregion
    }
}
