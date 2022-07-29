using Fx.Amiya.DbModels.Model;
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
        private IDalBindCustomerService _dalBindCustomerService;
        private ILiveAnchorService _liveAnchorService;
        private IUnitOfWork unitOfWork;
        private IAmiyaEmployeeService _amiyaEmployeeService;
        private IDalAmiyaEmployee dalAmiyaEmployee;
        public ShoppingCartRegistrationService(IDalShoppingCartRegistration dalShoppingCartRegistration,
            IContentPlatformService contentPlatformService,
            IAmiyaEmployeeService amiyaEmployeeService,
            IUnitOfWork unitOfWork,
            ILiveAnchorService liveAnchorService,
             IDalBindCustomerService dalBindCustomerService,
            IDalAmiyaEmployee dalAmiyaEmployee)
        {
            this.dalShoppingCartRegistration = dalShoppingCartRegistration;
            _contentPlatformService = contentPlatformService;
            _liveAnchorService = liveAnchorService;
            this.unitOfWork = unitOfWork;
            _dalBindCustomerService = dalBindCustomerService;
            _amiyaEmployeeService = amiyaEmployeeService;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
        }



        public async Task<FxPageInfo<ShoppingCartRegistrationDto>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, int? LiveAnchorId, int? employeeId, bool? isAddWechat, bool? isWriteOff, bool? isConsultation, bool? isReturnBackPrice, string keyword, string contentPlatFormId, int pageNum, int pageSize,decimal? minPrice,decimal? maxPrice,int? admissionId)
        {
            try
            {
                var shoppingCartRegistration = from d in dalShoppingCartRegistration.GetAll()
                                               where (keyword == null || d.Phone.Contains(keyword) || d.CustomerNickName.Contains(keyword) || d.LiveAnchorWechatNo.Contains(keyword))
                                               && ((!startDate.HasValue && !endDate.HasValue) || d.RecordDate >= startDate.Value.Date && d.RecordDate < endDate.Value.AddDays(1).Date)
                                               && (string.IsNullOrEmpty(contentPlatFormId) || d.ContentPlatFormId == contentPlatFormId)
                                               && (!isAddWechat.HasValue || d.IsAddWeChat == isAddWechat)
                                               && (!isWriteOff.HasValue || d.IsWriteOff == isWriteOff)
                                               && (!isConsultation.HasValue || d.IsConsultation == isConsultation)
                                               && (!isReturnBackPrice.HasValue || d.IsReturnBackPrice == isReturnBackPrice)
                                               && (!LiveAnchorId.HasValue || d.LiveAnchorId == LiveAnchorId)
                                               && (admissionId == null || d.AdmissionId == admissionId)
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
                                                   AdmissionId = d.AdmissionId,
                                                   IsBadReview=d.IsBadReview,
                                                   
                                               };
                if (minPrice != null)
                {
                    shoppingCartRegistration.Where(s => s.Price >= minPrice);
                    if (maxPrice != null)
                    {
                        shoppingCartRegistration.Where(s => s.Price <= maxPrice);
                    }
                }
                else {
                    if (maxPrice!=null) {
                        shoppingCartRegistration.Where(s=>s.Price<=maxPrice);
                    }
                }
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
                    var admissionInfo = await _amiyaEmployeeService.GetByIdAsync(x.AdmissionId);
                    x.AdmissionName =admissionInfo.Name;
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
                shoppingCartRegistration.AdmissionId = addDto.AdmissionId;
                shoppingCartRegistration.IsBadReview = addDto.IsBadReview;
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
                shoppingCartRegistrationDto.CreateDate = shoppingCartRegistration.CreateDate;
                shoppingCartRegistrationDto.IsReContent = shoppingCartRegistration.IsReContent;
                shoppingCartRegistrationDto.ReContent = shoppingCartRegistration.ReContent;
                shoppingCartRegistrationDto.RefundDate = shoppingCartRegistration.RefundDate;
                shoppingCartRegistrationDto.RefundReason = shoppingCartRegistration.RefundReason;
                shoppingCartRegistrationDto.BadReviewDate = shoppingCartRegistration.BadReviewDate;
                shoppingCartRegistrationDto.BadReviewContent = shoppingCartRegistration.BadReviewContent;
                shoppingCartRegistrationDto.BadReviewReason = shoppingCartRegistration.BadReviewReason;
                shoppingCartRegistrationDto.AdmissionId = shoppingCartRegistration.AdmissionId;
                shoppingCartRegistrationDto.IsBadReview = shoppingCartRegistration.IsBadReview;
                var emp = dalAmiyaEmployee.GetAll().SingleOrDefault(e=>e.Id==shoppingCartRegistrationDto.AdmissionId);
                shoppingCartRegistrationDto.AdmissionName = emp.Name;
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
                var shoppingCartRegistration = await dalShoppingCartRegistration.GetAll().SingleOrDefaultAsync(e => e.Id == phone);
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
                shoppingCartRegistrationDto.AdmissionId = shoppingCartRegistration.AdmissionId;
                shoppingCartRegistrationDto.IsBadReview = shoppingCartRegistration.IsBadReview;
                var emp = dalAmiyaEmployee.GetAll().SingleOrDefault(e => e.Id == shoppingCartRegistrationDto.AdmissionId);
                shoppingCartRegistrationDto.AdmissionName = emp.Name;
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
                shoppingCartRegistration.ReContent=updateDto.ReContent;
                shoppingCartRegistration.RefundDate = updateDto.RefundDate;
                shoppingCartRegistration.RefundReason = updateDto.RefundReason;
                shoppingCartRegistration.BadReviewDate = updateDto.BadReviewDate;
                shoppingCartRegistration.BadReviewContent = updateDto.BadReviewContent;
                shoppingCartRegistration.BadReviewReason=updateDto.BadReviewReason;
                shoppingCartRegistration.AdmissionId = updateDto.AdmissionId;
                shoppingCartRegistration.IsBadReview = updateDto.IsBadReview;
                await dalShoppingCartRegistration.UpdateAsync(shoppingCartRegistration, true);
                // unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                // unitOfWork.RollBack();
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

        #region 【报表相关】
        public async Task<List<ShoppingCartRegistrationDto>> GetShoppingCartRegistrationReportAsync(DateTime? startDate, DateTime? endDate, int? LiveAnchorId, int? employeeId, bool? isAddWechat, bool? isWriteOff, bool? isConsultation, bool? isReturnBackPrice, string keyword, string contentPlatFormId, bool isHidePhone)
        {
            try
            {
                var shoppingCartRegistration = from d in dalShoppingCartRegistration.GetAll()
                                               where (keyword == null || d.Phone.Contains(keyword) || d.CustomerNickName.Contains(keyword))
                                               && ((!startDate.HasValue && !endDate.HasValue) || d.RecordDate >= startDate.Value.Date && d.RecordDate < endDate.Value.AddDays(1).Date)
                                               && (string.IsNullOrEmpty(contentPlatFormId) || d.ContentPlatFormId == contentPlatFormId)
                                               && (!LiveAnchorId.HasValue || d.LiveAnchorId == LiveAnchorId) && (!isAddWechat.HasValue || d.IsAddWeChat == isAddWechat)
                                               && (!isWriteOff.HasValue || d.IsWriteOff == isWriteOff)
                                               && (!isConsultation.HasValue || d.IsConsultation == isConsultation)
                                               && (!isReturnBackPrice.HasValue || d.IsReturnBackPrice == isReturnBackPrice)
                                               select new ShoppingCartRegistrationDto
                                               {
                                                   Id = d.Id,
                                                   RecordDate = d.RecordDate,
                                                   ContentPlatFormId = d.ContentPlatFormId,
                                                   LiveAnchorId = d.LiveAnchorId,
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
                                                   CreateDate = d.CreateDate,
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
                foreach (var x in shoppingCartRegistrationPageInfo)
                {
                    var contentPlatFormInfo = await _contentPlatformService.GetByIdAsync(x.ContentPlatFormId);
                    x.ContentPlatFormName = contentPlatFormInfo.ContentPlatformName;
                    var liveAnchorInfo = await _liveAnchorService.GetByIdAsync(x.LiveAnchorId);
                    x.LiveAnchorName = liveAnchorInfo.Name;
                    var empInfo = await _amiyaEmployeeService.GetByIdAsync(x.CreateBy);
                    x.CreateByName = empInfo.Name;
                    if (x.ConsultationType == 1)
                    {
                        x.ConsultationTypeText = "视频";
                    }
                    if (x.ConsultationType == 2)
                    {
                        x.ConsultationTypeText = "图片";
                    }
                    if (x.ConsultationType == 3)
                    {
                        x.ConsultationTypeText = "私信";
                    }
                    if (x.ConsultationType == 4)
                    {
                        x.ConsultationTypeText = "其他";
                    }
                    if (x.ConsultationType == 5)
                    {
                        x.ConsultationTypeText = "短视频";
                    }
                    if (x.ConsultationType == 6)
                    {
                        x.ConsultationTypeText = "其他";
                    }
                }
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
