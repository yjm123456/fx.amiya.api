using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using jos_sdk_net.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class ContentPlatFormOrderDealInfoService : IContentPlatFormOrderDealInfoService
    {
        private IDalContentPlatFormOrderDealInfo dalContentPlatFormOrderDealInfo;
        private IContentPlatFormCustomerPictureService _contentPlatFormCustomerPictureService;
        private IHospitalInfoService _hospitalInfoService;
        private IDalBindCustomerService _dalBindCustomerService;
        private IAmiyaEmployeeService _amiyaEmployeeService;
        private IDalAmiyaEmployee _dalAmiyaEmployee;
        private ILiveAnchorMonthlyTargetService _liveAnchorMonthlyTargetService;

        public ContentPlatFormOrderDealInfoService(IDalContentPlatFormOrderDealInfo dalContentPlatFormOrderDealInfo,
            IAmiyaEmployeeService amiyaEmployeeService,
            IContentPlatFormCustomerPictureService contentPlatFormCustomerPictureService,
            IDalBindCustomerService dalBindCustomerService,
            IDalAmiyaEmployee dalAmiyaEmployee,
            IHospitalInfoService hospitalInfoService, ILiveAnchorMonthlyTargetService liveAnchorMonthlyTargetService)
        {
            this.dalContentPlatFormOrderDealInfo = dalContentPlatFormOrderDealInfo;
            _hospitalInfoService = hospitalInfoService;
            _amiyaEmployeeService = amiyaEmployeeService;
            _contentPlatFormCustomerPictureService = contentPlatFormCustomerPictureService;
            _dalBindCustomerService = dalBindCustomerService;
            _dalAmiyaEmployee = dalAmiyaEmployee;
            _liveAnchorMonthlyTargetService = liveAnchorMonthlyTargetService;
        }
        /// <summary>
        /// 获取成交情况列表
        /// </summary>
        /// <param name="startDate">登记开始日期</param>
        /// <param name="endDate">登记结束日期</param>
        /// <param name="sendStartDate">派单开始日期</param>
        /// <param name="sendEndDate">派单结束日期</param>
        /// <param name="consultationType">面诊状态（空查询所有）</param>
        /// <param name="isToHospital">是否到院（空查询所有）</param>
        /// <param name="tohospitalStartDate">到院开始时间</param>
        /// <param name="toHospitalEndDate">到院结束时间</param>
        /// <param name="toHospitalType">到院类型（空查询所有）</param>
        /// <param name="isDeal">是否成交（空查询所有）</param>
        /// <param name="lastDealHospitalId">最终成交医院id（空查询所有）</param>
        /// <param name="isAccompanying">是否陪诊（空查询所有）</param>
        /// <param name="minAddOrderPrice">最小下单金额（空查询所有）</param>
        /// <param name="maxAddOrderPrice">最大下单金额（空查询所有）</param>
        /// <param name="isOldCustomer">新老客业绩（空查询所有）</param>
        /// <param name="CheckState">审核状态（空查询所有）</param>
        /// <param name="isReturnBakcPrice">是否回款（空查询所有）</param>
        /// <param name="returnBackPriceStartDate">回款开始时间</param>
        /// <param name="returnBackPriceEndDate">回款结束时间</param>
        /// <param name="customerServiceId">跟进人员（空查询所有）</param>
        /// <param name="keyWord">关键字</param>
        /// <param name="employeeId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<ContentPlatFormOrderDealInfoDto>> GetOrderListWithPageAsync(DateTime? startDate, DateTime? endDate, DateTime? sendStartDate, DateTime? sendEndDate, int? consultationType, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, bool? isToHospital, DateTime? tohospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, bool? isDeal, int? lastDealHospitalId, bool? isAccompanying, bool? isOldCustomer, int? CheckState, bool? isReturnBakcPrice, DateTime? returnBackPriceStartDate, DateTime? returnBackPriceEndDate, int? customerServiceId, string keyWord, int employeeId, int pageNum, int pageSize)
        {
            try
            {
                var dealInfo = from d in dalContentPlatFormOrderDealInfo.GetAll().Include(x => x.ContentPlatFormOrder).ThenInclude(z => z.ContentPlatformOrderSendList) select d;

                var employee = await _dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                {
                    dealInfo = from d in dealInfo
                               where _dalBindCustomerService.GetAll().Count(e => e.CustomerServiceId == employeeId && e.BuyerPhone == d.ContentPlatFormOrder.Phone) > 0
                               select d;
                }
                if (startDate != null && endDate != null)
                {
                    DateTime startrq = ((DateTime)startDate).Date;
                    DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
                    dealInfo = from d in dealInfo
                               where (d.CreateDate >= startrq && d.CreateDate < endrq)
                               select d;
                }
                if (sendStartDate != null && sendEndDate != null)
                {
                    DateTime startrq = ((DateTime)sendStartDate).Date;
                    DateTime endrq = ((DateTime)sendEndDate).Date.AddDays(1);
                    dealInfo = from d in dealInfo
                               where (d.ContentPlatFormOrder.SendDate.HasValue)
                               && (d.ContentPlatFormOrder.SendDate >= startrq && d.ContentPlatFormOrder.SendDate < endrq)
                               select d;
                }
                if (isToHospital == true)
                {
                    if (!tohospitalStartDate.HasValue && !toHospitalEndDate.HasValue)
                    {
                        throw new Exception("到院时间为必填项，请完整填写到院的开始时间与结束时间！");
                    }
                    DateTime startrq = ((DateTime)tohospitalStartDate).Date;
                    DateTime endrq = ((DateTime)toHospitalEndDate).Date.AddDays(1);
                    dealInfo = from d in dealInfo
                               where (d.ToHospitalDate.HasValue)
                               && (d.ToHospitalDate.Value >= startrq && d.ToHospitalDate.Value < endrq)
                               && (d.IsToHospital == true)
                               select d;
                }
                if (isReturnBakcPrice == true)
                {
                    if (!returnBackPriceStartDate.HasValue && !returnBackPriceEndDate.HasValue)
                    {
                        throw new Exception("回款时间为必填项，请完整填写回款的开始时间与结束时间！");
                    }
                    DateTime startrq = ((DateTime)returnBackPriceStartDate).Date;
                    DateTime endrq = ((DateTime)returnBackPriceEndDate).Date.AddDays(1);
                    dealInfo = from d in dealInfo
                               where (d.ReturnBackDate.HasValue)
                               && (d.ReturnBackDate.Value >= startrq && d.ReturnBackDate.Value < endrq)
                               && (d.IsToHospital == true)
                               select d;
                }
                var ContentPlatFOrmOrderDealInfo = from d in dealInfo
                                                   where (string.IsNullOrEmpty(keyWord) || d.ContentPlatFormOrderId.Contains(keyWord) || d.ContentPlatFormOrder.Phone.Contains(keyWord) || d.Id.Contains(keyWord))
                                                   && (!isToHospital.HasValue || d.IsToHospital == isToHospital.Value)
                                                   && (!toHospitalType.HasValue || d.ToHospitalType == toHospitalType.Value)
                                                   && (!isDeal.HasValue || d.IsDeal == isDeal.Value)
                                                   && (!lastDealHospitalId.HasValue || d.LastDealHospitalId.Value == lastDealHospitalId.Value)
                                                   && (!isOldCustomer.HasValue || d.IsOldCustomer == isOldCustomer.Value)
                                                   && (!isAccompanying.HasValue || d.IsAcompanying == isAccompanying.Value)
                                                   && (!CheckState.HasValue || d.CheckState == CheckState.Value)
                                                   && (!isReturnBakcPrice.HasValue || d.IsReturnBackPrice == isReturnBakcPrice.Value)
                                                   && (!customerServiceId.HasValue || d.CreateBy == customerServiceId)
                                                   && (!consultationType.HasValue || d.ContentPlatFormOrder.ConsultationType == consultationType)
                                                   && (!minAddOrderPrice.HasValue || d.ContentPlatFormOrder.AddOrderPrice >= minAddOrderPrice)
                                                   && (!maxAddOrderPrice.HasValue || d.ContentPlatFormOrder.AddOrderPrice <= maxAddOrderPrice)
                                                   select new ContentPlatFormOrderDealInfoDto
                                                   {
                                                       Id = d.Id,
                                                       ContentPlatFormOrderId = d.ContentPlatFormOrderId,
                                                       CreateDate = d.CreateDate,
                                                       Phone = ServiceClass.GetIncompletePhone(d.ContentPlatFormOrder.Phone),
                                                       IsDeal = d.IsDeal,
                                                       IsOldCustomer = d.IsOldCustomer,
                                                       IsAcompanying = d.IsAcompanying,
                                                       ConsultationTypeText = ServiceClass.GetContentPlateFormOrderConsultationTypeText(d.ContentPlatFormOrder.ConsultationType),
                                                       CommissionRatio = d.CommissionRatio,
                                                       IsToHospital = d.IsToHospital,
                                                       AddOrderPrice = d.ContentPlatFormOrder.AddOrderPrice,
                                                       ToHospitalType = d.ToHospitalType,
                                                       ToHospitalTypeText = ServiceClass.GerContentPlatFormOrderToHospitalTypeText(d.ToHospitalType),
                                                       ToHospitalDate = d.ToHospitalDate,
                                                       LastDealHospitalId = d.LastDealHospitalId,
                                                       SendDate = d.ContentPlatFormOrder.SendDate,
                                                       DealPicture = d.DealPicture,
                                                       Remark = d.Remark,
                                                       Price = d.Price,
                                                       DealDate = d.DealDate,
                                                       OtherAppOrderId = d.OtherAppOrderId,
                                                       CheckState = d.CheckState,
                                                       CheckStateText = ServiceClass.GetCheckTypeText(d.CheckState.Value),
                                                       CheckPrice = d.CheckPrice,
                                                       CheckDate = d.CheckDate,
                                                       CheckBy = d.CheckBy,
                                                       SettlePrice = d.SettlePrice,
                                                       CheckRemark = d.CheckRemark,
                                                       IsReturnBackPrice = d.IsReturnBackPrice,
                                                       ReturnBackDate = d.ReturnBackDate,
                                                       ReturnBackPrice = d.ReturnBackPrice,
                                                       CreateBy = d.CreateBy,
                                                   };

                FxPageInfo<ContentPlatFormOrderDealInfoDto> ContentPlatFOrmOrderDealInfoPageInfo = new FxPageInfo<ContentPlatFormOrderDealInfoDto>();
                ContentPlatFOrmOrderDealInfoPageInfo.TotalCount = await ContentPlatFOrmOrderDealInfo.CountAsync();
                ContentPlatFOrmOrderDealInfoPageInfo.List = await ContentPlatFOrmOrderDealInfo.OrderByDescending(x => x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                foreach (var z in ContentPlatFOrmOrderDealInfoPageInfo.List)
                {
                    if (z.LastDealHospitalId.HasValue)
                    {
                        var dealHospital = await _hospitalInfoService.GetBaseByIdAsync(z.LastDealHospitalId.Value);
                        z.LastDealHospital = dealHospital.Name;
                    }
                    if (z.CheckBy.HasValue)
                    {
                        var empInfo = await _amiyaEmployeeService.GetByIdAsync(z.CheckBy.Value);
                        z.CheckByEmpName = empInfo.Name;
                    }
                    if (z.CreateBy == 0)
                    {
                        z.CreateByEmpName = "其他";
                    }
                    else
                    {
                        var empInfo = await _amiyaEmployeeService.GetByIdAsync(z.CreateBy);
                        z.CreateByEmpName = empInfo.Name;
                    }
                }
                return ContentPlatFOrmOrderDealInfoPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ContentPlatFormOrderDealInfoDto>> GetOrderDealInfoListReportAsync(DateTime? startDate, DateTime? endDate, DateTime? sendStartDate, DateTime? sendEndDate, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, int? consultationType, bool? isToHospital, DateTime? tohospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, bool? isDeal, int? lastDealHospitalId, bool? isAccompanying, bool? isOldCustomer, int? CheckState, bool? isReturnBakcPrice, DateTime? returnBackPriceStartDate, DateTime? returnBackPriceEndDate, int? customerServiceId, string keyWord, int employeeId, bool hidePhone)
        {
            try
            {
                var dealInfo = from d in dalContentPlatFormOrderDealInfo.GetAll().Include(x => x.ContentPlatFormOrder) select d;

                var employee = await _dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                {
                    dealInfo = from d in dealInfo
                               where _dalBindCustomerService.GetAll().Count(e => e.CustomerServiceId == employeeId && e.BuyerPhone == d.ContentPlatFormOrder.Phone) > 0
                               select d;
                }
                if (startDate != null && endDate != null)
                {
                    DateTime startrq = ((DateTime)startDate).Date;
                    DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
                    dealInfo = from d in dealInfo
                               where (d.CreateDate >= startrq && d.CreateDate < endrq)
                               select d;
                }
                if (sendStartDate != null && sendEndDate != null)
                {
                    DateTime startrq = ((DateTime)sendStartDate).Date;
                    DateTime endrq = ((DateTime)sendEndDate).Date.AddDays(1);
                    dealInfo = from d in dealInfo
                               where (d.ContentPlatFormOrder.SendDate >= startrq && d.ContentPlatFormOrder.SendDate < endrq)
                               select d;
                }
                if (isToHospital == true)
                {
                    if (!tohospitalStartDate.HasValue && !toHospitalEndDate.HasValue)
                    {
                        throw new Exception("到院时间为必填项，请完整填写到院的开始时间与结束时间！");
                    }
                    DateTime startrq = ((DateTime)tohospitalStartDate).Date;
                    DateTime endrq = ((DateTime)toHospitalEndDate).Date.AddDays(1);
                    dealInfo = from d in dealInfo
                               where (d.ToHospitalDate.HasValue)
                               && (d.ToHospitalDate.Value >= startrq && d.ToHospitalDate.Value < endrq)
                               && (d.IsToHospital == true)
                               select d;
                }
                if (isReturnBakcPrice == true)
                {
                    if (!returnBackPriceStartDate.HasValue && !returnBackPriceEndDate.HasValue)
                    {
                        throw new Exception("回款时间为必填项，请完整填写回款的开始时间与结束时间！");
                    }
                    DateTime startrq = ((DateTime)returnBackPriceStartDate).Date;
                    DateTime endrq = ((DateTime)returnBackPriceEndDate).Date.AddDays(1);
                    dealInfo = from d in dealInfo
                               where (d.ReturnBackDate.HasValue)
                               && (d.ReturnBackDate.Value >= startrq && d.ReturnBackDate.Value < endrq)
                               && (d.IsToHospital == true)
                               select d;
                }
                var ContentPlatFOrmOrderDealInfo = from d in dealInfo
                                                   where (string.IsNullOrEmpty(keyWord) || d.ContentPlatFormOrderId.Contains(keyWord) || d.ContentPlatFormOrder.Phone.Contains(keyWord) || d.Id.Contains(keyWord))
                                                   && (!isToHospital.HasValue || d.IsToHospital == isToHospital.Value)
                                                   && (!toHospitalType.HasValue || d.ToHospitalType == toHospitalType.Value)
                                                   && (!isDeal.HasValue || d.IsDeal == isDeal.Value)
                                                   && (!lastDealHospitalId.HasValue || d.LastDealHospitalId.Value == lastDealHospitalId.Value)
                                                   && (!isOldCustomer.HasValue || d.IsOldCustomer == isOldCustomer.Value)
                                                   && (!isAccompanying.HasValue || d.IsAcompanying == isAccompanying.Value)
                                                   && (!CheckState.HasValue || d.CheckState == CheckState.Value)
                                                   && (!isReturnBakcPrice.HasValue || d.IsReturnBackPrice == isReturnBakcPrice.Value)
                                                   && (!consultationType.HasValue || d.ContentPlatFormOrder.ConsultationType == consultationType.Value)
                                                   && (!customerServiceId.HasValue || d.ContentPlatFormOrder.BelongEmpId == customerServiceId)
                                                   && (!minAddOrderPrice.HasValue || d.ContentPlatFormOrder.AddOrderPrice >= minAddOrderPrice)
                                                   && (!maxAddOrderPrice.HasValue || d.ContentPlatFormOrder.AddOrderPrice <= maxAddOrderPrice)
                                                   select new ContentPlatFormOrderDealInfoDto
                                                   {
                                                       Id = d.Id,
                                                       ContentPlatFormOrderId = d.ContentPlatFormOrderId,
                                                       OrderCreateDate = d.ContentPlatFormOrder.CreateDate,
                                                       ContentPlatFormName = d.ContentPlatFormOrder.Contentplatform.ContentPlatformName,
                                                       LiveAnchorName = d.ContentPlatFormOrder.LiveAnchor.Name,
                                                       ConsultationType = d.ContentPlatFormOrder.ConsultationType,
                                                       ConsultationTypeText = ServiceClass.GetContentPlateFormOrderConsultationTypeText(d.ContentPlatFormOrder.ConsultationType),
                                                       GoodsName = d.ContentPlatFormOrder.AmiyaGoodsDemand.ProjectNname,
                                                       SendDate = d.ContentPlatFormOrder.SendDate,
                                                       CustomerNickName = d.ContentPlatFormOrder.CustomerName,
                                                       AddOrderPrice = d.ContentPlatFormOrder.AddOrderPrice,
                                                       CreateDate = d.CreateDate,
                                                       IsDeal = d.IsDeal,
                                                       IsOldCustomer = d.IsOldCustomer,
                                                       IsAcompanying = d.IsAcompanying,
                                                       Phone = hidePhone == true ? ServiceClass.GetIncompletePhone(d.ContentPlatFormOrder.Phone) : d.ContentPlatFormOrder.Phone,
                                                       CommissionRatio = d.CommissionRatio,
                                                       IsToHospital = d.IsToHospital,
                                                       ToHospitalType = d.ToHospitalType,
                                                       ToHospitalTypeText = ServiceClass.GerContentPlatFormOrderToHospitalTypeText(d.ToHospitalType),
                                                       ToHospitalDate = d.ToHospitalDate,
                                                       LastDealHospitalId = d.LastDealHospitalId,
                                                       Remark = d.Remark,
                                                       Price = d.Price,
                                                       DealDate = d.DealDate,
                                                       OtherAppOrderId = d.OtherAppOrderId,
                                                       CheckState = d.CheckState,
                                                       CheckStateText = ServiceClass.GetCheckTypeText(d.CheckState.Value),
                                                       CheckPrice = d.CheckPrice,
                                                       CheckDate = d.CheckDate,
                                                       CheckBy = d.CheckBy,
                                                       SettlePrice = d.SettlePrice,
                                                       CheckRemark = d.CheckRemark,
                                                       IsReturnBackPrice = d.IsReturnBackPrice,
                                                       ReturnBackDate = d.ReturnBackDate,
                                                       ReturnBackPrice = d.ReturnBackPrice,
                                                       CreateBy = d.ContentPlatFormOrder.BelongEmpId.HasValue ? d.ContentPlatFormOrder.BelongEmpId.Value : -1,
                                                   };

                List<ContentPlatFormOrderDealInfoDto> ContentPlatFOrmOrderDealInfoPageInfo = new List<ContentPlatFormOrderDealInfoDto>();
                ContentPlatFOrmOrderDealInfoPageInfo = await ContentPlatFOrmOrderDealInfo.OrderByDescending(x => x.CreateDate).ToListAsync();
                foreach (var z in ContentPlatFOrmOrderDealInfoPageInfo)
                {
                    if (z.LastDealHospitalId.HasValue && z.LastDealHospitalId != 0)
                    {
                        var dealHospital = await _hospitalInfoService.GetBaseByIdAsync(z.LastDealHospitalId.Value);
                        z.LastDealHospital = dealHospital.Name;
                    }
                    if (z.CheckBy.HasValue && z.CheckBy != 0)
                    {
                        var empInfo = await _amiyaEmployeeService.GetByIdAsync(z.CheckBy.Value);
                        z.CheckByEmpName = empInfo.Name;
                    }
                    if (z.CreateBy == 0)
                    {
                        z.CreateByEmpName = "医院";
                    }
                    else if (z.CreateBy == -1)
                    {
                        z.CreateByEmpName = "其他";
                    }
                    else
                    {
                        var empInfo = await _amiyaEmployeeService.GetByIdAsync(z.CreateBy);
                        z.CreateByEmpName = empInfo.Name;
                    }
                }
                return ContentPlatFOrmOrderDealInfoPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据订单号展示成交情况
        /// </summary>
        /// <param name="contentPlafFormOrderId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<ContentPlatFormOrderDealInfoDto>> GetListWithPageAsync(string contentPlafFormOrderId, int pageNum, int pageSize)
        {
            try
            {
                var ContentPlatFOrmOrderDealInfo = from d in dalContentPlatFormOrderDealInfo.GetAll()
                                                   where (string.IsNullOrEmpty(contentPlafFormOrderId) || d.ContentPlatFormOrderId == contentPlafFormOrderId)
                                                   select new ContentPlatFormOrderDealInfoDto
                                                   {
                                                       Id = d.Id,
                                                       ContentPlatFormOrderId = d.ContentPlatFormOrderId,
                                                       CreateDate = d.CreateDate,
                                                       IsDeal = d.IsDeal,
                                                       IsOldCustomer = d.IsOldCustomer,
                                                       IsAcompanying = d.IsAcompanying,
                                                       CommissionRatio = d.CommissionRatio,
                                                       IsToHospital = d.IsToHospital,
                                                       ToHospitalType = d.ToHospitalType,
                                                       ToHospitalTypeText = ServiceClass.GerContentPlatFormOrderToHospitalTypeText(d.ToHospitalType),
                                                       ToHospitalDate = d.ToHospitalDate,
                                                       LastDealHospitalId = d.LastDealHospitalId,
                                                       DealPicture = d.DealPicture,
                                                       Remark = d.Remark,
                                                       Price = d.Price,
                                                       DealDate = d.DealDate,
                                                       OtherAppOrderId = d.OtherAppOrderId,
                                                       CheckState = d.CheckState,
                                                       CheckStateText = ServiceClass.GetCheckTypeText(d.CheckState.Value),
                                                       CheckPrice = d.CheckPrice,
                                                       CheckDate = d.CheckDate,
                                                       CheckBy = d.CheckBy,
                                                       SettlePrice = d.SettlePrice,
                                                       CheckRemark = d.CheckRemark,
                                                       IsReturnBackPrice = d.IsReturnBackPrice,
                                                       ReturnBackDate = d.ReturnBackDate,
                                                       ReturnBackPrice = d.ReturnBackPrice,
                                                       CreateBy = d.CreateBy,
                                                   };

                FxPageInfo<ContentPlatFormOrderDealInfoDto> ContentPlatFOrmOrderDealInfoPageInfo = new FxPageInfo<ContentPlatFormOrderDealInfoDto>();
                ContentPlatFOrmOrderDealInfoPageInfo.TotalCount = await ContentPlatFOrmOrderDealInfo.CountAsync();
                ContentPlatFOrmOrderDealInfoPageInfo.List = await ContentPlatFOrmOrderDealInfo.OrderByDescending(x => x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                foreach (var z in ContentPlatFOrmOrderDealInfoPageInfo.List)
                {
                    if (z.LastDealHospitalId.HasValue)
                    {
                        var dealHospital = await _hospitalInfoService.GetBaseByIdAsync(z.LastDealHospitalId.Value);
                        z.LastDealHospital = dealHospital.Name;
                    }
                    if (z.CreateBy == 0)
                    {
                        z.CreateByEmpName = "医院添加";
                    }
                    else
                    {
                        var empInfo = await _amiyaEmployeeService.GetByIdAsync(z.CreateBy);
                        z.CreateByEmpName = empInfo.Name;
                    }
                }
                return ContentPlatFOrmOrderDealInfoPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task AddAsync(AddContentPlatFormOrderDealInfoDto addDto)
        {
            try
            {
                ContentPlatformOrderDealInfo ContentPlatFOrmOrderDealInfo = new ContentPlatformOrderDealInfo();
                ContentPlatFOrmOrderDealInfo.Id = CreateOrderIdHelper.GetNextNumber();
                ContentPlatFOrmOrderDealInfo.ContentPlatFormOrderId = addDto.ContentPlatFormOrderId;
                ContentPlatFOrmOrderDealInfo.CreateDate = addDto.CreateDate;
                ContentPlatFOrmOrderDealInfo.IsToHospital = addDto.IsToHospital;
                ContentPlatFOrmOrderDealInfo.ToHospitalType = addDto.ToHospitalType;
                ContentPlatFOrmOrderDealInfo.ToHospitalDate = addDto.ToHospitalDate;
                ContentPlatFOrmOrderDealInfo.LastDealHospitalId = addDto.LastDealHospitalId;
                ContentPlatFOrmOrderDealInfo.IsDeal = addDto.IsDeal;
                ContentPlatFOrmOrderDealInfo.DealPicture = addDto.DealPicture;
                ContentPlatFOrmOrderDealInfo.Remark = addDto.Remark;
                ContentPlatFOrmOrderDealInfo.Price = addDto.Price;
                ContentPlatFOrmOrderDealInfo.DealDate = addDto.DealDate;
                ContentPlatFOrmOrderDealInfo.OtherAppOrderId = addDto.OtherAppOrderId;
                ContentPlatFOrmOrderDealInfo.IsAcompanying = addDto.IsAcompanying;
                ContentPlatFOrmOrderDealInfo.IsOldCustomer = addDto.IsOldCustomer;
                ContentPlatFOrmOrderDealInfo.CreateBy = addDto.CreateBy;
                ContentPlatFOrmOrderDealInfo.CommissionRatio = addDto.CommissionRatio;
                ContentPlatFOrmOrderDealInfo.CheckBy = 0;
                ContentPlatFOrmOrderDealInfo.CheckPrice = 0.00M;
                ContentPlatFOrmOrderDealInfo.CheckState = 0;
                ContentPlatFOrmOrderDealInfo.SettlePrice = 0.00M;
                await dalContentPlatFormOrderDealInfo.AddAsync(ContentPlatFOrmOrderDealInfo, true);

                //添加邀约凭证图片
                if (addDto.InvitationDocuments != null)
                {
                    foreach (var z in addDto.InvitationDocuments)
                    {
                        AddContentPlatFormCustomerPictureDto addPicture = new AddContentPlatFormCustomerPictureDto();
                        addPicture.OrderDealId = ContentPlatFOrmOrderDealInfo.Id;
                        addPicture.ContentPlatFormOrderId = addDto.ContentPlatFormOrderId;
                        addPicture.CustomerPicture = z;
                        addPicture.Description = "邀约凭证";
                        await _contentPlatFormCustomerPictureService.AddAsync(addPicture);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<ContentPlatFormOrderDealInfoDto> GetByIdAsync(string id)
        {
            try
            {
                var ContentPlatFOrmOrderDealInfo = await dalContentPlatFormOrderDealInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (ContentPlatFOrmOrderDealInfo == null)
                {
                    throw new Exception("未找到该成交信息");
                }

                ContentPlatFormOrderDealInfoDto contentPlatFOrmOrderDealInfoDto = new ContentPlatFormOrderDealInfoDto();
                contentPlatFOrmOrderDealInfoDto.Id = ContentPlatFOrmOrderDealInfo.Id;
                contentPlatFOrmOrderDealInfoDto.ContentPlatFormOrderId = ContentPlatFOrmOrderDealInfo.ContentPlatFormOrderId;
                contentPlatFOrmOrderDealInfoDto.CreateDate = ContentPlatFOrmOrderDealInfo.CreateDate;
                contentPlatFOrmOrderDealInfoDto.IsToHospital = ContentPlatFOrmOrderDealInfo.IsToHospital;
                contentPlatFOrmOrderDealInfoDto.ToHospitalType = ContentPlatFOrmOrderDealInfo.ToHospitalType;
                contentPlatFOrmOrderDealInfoDto.ToHospitalDate = ContentPlatFOrmOrderDealInfo.ToHospitalDate;
                contentPlatFOrmOrderDealInfoDto.LastDealHospitalId = ContentPlatFOrmOrderDealInfo.LastDealHospitalId;
                contentPlatFOrmOrderDealInfoDto.IsDeal = ContentPlatFOrmOrderDealInfo.IsDeal;
                contentPlatFOrmOrderDealInfoDto.DealPicture = ContentPlatFOrmOrderDealInfo.DealPicture;
                contentPlatFOrmOrderDealInfoDto.Remark = ContentPlatFOrmOrderDealInfo.Remark;
                contentPlatFOrmOrderDealInfoDto.Price = ContentPlatFOrmOrderDealInfo.Price;
                contentPlatFOrmOrderDealInfoDto.DealDate = ContentPlatFOrmOrderDealInfo.DealDate;
                contentPlatFOrmOrderDealInfoDto.OtherAppOrderId = ContentPlatFOrmOrderDealInfo.OtherAppOrderId;
                contentPlatFOrmOrderDealInfoDto.IsAcompanying = ContentPlatFOrmOrderDealInfo.IsAcompanying;
                contentPlatFOrmOrderDealInfoDto.IsOldCustomer = ContentPlatFOrmOrderDealInfo.IsOldCustomer;
                contentPlatFOrmOrderDealInfoDto.CommissionRatio = ContentPlatFOrmOrderDealInfo.CommissionRatio;
                contentPlatFOrmOrderDealInfoDto.CheckState = ContentPlatFOrmOrderDealInfo.CheckState;
                contentPlatFOrmOrderDealInfoDto.CheckStateText = ServiceClass.GetCheckTypeText(ContentPlatFOrmOrderDealInfo.CheckState.Value);
                contentPlatFOrmOrderDealInfoDto.CheckPrice = ContentPlatFOrmOrderDealInfo.CheckPrice;
                contentPlatFOrmOrderDealInfoDto.CheckDate = ContentPlatFOrmOrderDealInfo.CheckDate;
                contentPlatFOrmOrderDealInfoDto.CheckBy = ContentPlatFOrmOrderDealInfo.CheckBy;
                contentPlatFOrmOrderDealInfoDto.SettlePrice = ContentPlatFOrmOrderDealInfo.SettlePrice;
                contentPlatFOrmOrderDealInfoDto.CheckRemark = ContentPlatFOrmOrderDealInfo.CheckRemark;
                contentPlatFOrmOrderDealInfoDto.IsReturnBackPrice = ContentPlatFOrmOrderDealInfo.IsReturnBackPrice;
                contentPlatFOrmOrderDealInfoDto.ReturnBackDate = ContentPlatFOrmOrderDealInfo.ReturnBackDate;
                contentPlatFOrmOrderDealInfoDto.ReturnBackPrice = ContentPlatFOrmOrderDealInfo.ReturnBackPrice;
                contentPlatFOrmOrderDealInfoDto.CreateBy = ContentPlatFOrmOrderDealInfo.CreateBy;
                var InvitationDocuments = await _contentPlatFormCustomerPictureService.GetListWithPageAsync(null, ContentPlatFOrmOrderDealInfo.Id, "邀约凭证", 1, 5);
                contentPlatFOrmOrderDealInfoDto.InvitationDocuments = new List<string>();
                foreach (var x in InvitationDocuments.List)
                {
                    contentPlatFOrmOrderDealInfoDto.InvitationDocuments.Add(x.CustomerPicture);
                }
                return contentPlatFOrmOrderDealInfoDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(UpdateContentPlatFormOrderDealInfoDto updateDto)
        {
            try
            {
                var ContentPlatFOrmOrderDealInfo = await dalContentPlatFormOrderDealInfo.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (ContentPlatFOrmOrderDealInfo == null)
                    throw new Exception("未找到该成交信息！");


                ContentPlatFOrmOrderDealInfo.Id = updateDto.Id;
                ContentPlatFOrmOrderDealInfo.ContentPlatFormOrderId = updateDto.ContentPlatFormOrderId;
                ContentPlatFOrmOrderDealInfo.IsToHospital = updateDto.IsToHospital;
                ContentPlatFOrmOrderDealInfo.ToHospitalType = updateDto.ToHospitalType;
                ContentPlatFOrmOrderDealInfo.ToHospitalDate = updateDto.ToHospitalDate;
                ContentPlatFOrmOrderDealInfo.LastDealHospitalId = updateDto.LastDealHospitalId;
                ContentPlatFOrmOrderDealInfo.IsDeal = updateDto.IsDeal;
                ContentPlatFOrmOrderDealInfo.DealPicture = updateDto.DealPicture;
                ContentPlatFOrmOrderDealInfo.Remark = updateDto.Remark;
                ContentPlatFOrmOrderDealInfo.Price = updateDto.Price;
                ContentPlatFOrmOrderDealInfo.DealDate = updateDto.DealDate;
                ContentPlatFOrmOrderDealInfo.OtherAppOrderId = updateDto.OtherAppOrderId;
                ContentPlatFOrmOrderDealInfo.IsAcompanying = updateDto.IsAcompanying;
                ContentPlatFOrmOrderDealInfo.IsOldCustomer = updateDto.IsOldCustomer;
                ContentPlatFOrmOrderDealInfo.CommissionRatio = updateDto.CommissionRatio;
                await dalContentPlatFormOrderDealInfo.UpdateAsync(ContentPlatFOrmOrderDealInfo, true);
                await _contentPlatFormCustomerPictureService.DeleteByContentPlatFormOrderDealIdAsync(updateDto.Id);
                //添加邀约凭证图片
                foreach (var z in updateDto.InvitationDocuments)
                {
                    AddContentPlatFormCustomerPictureDto addPicture = new AddContentPlatFormCustomerPictureDto();
                    addPicture.OrderDealId = ContentPlatFOrmOrderDealInfo.Id;
                    addPicture.ContentPlatFormOrderId = updateDto.ContentPlatFormOrderId;
                    addPicture.CustomerPicture = z;
                    addPicture.Description = "邀约凭证";
                    await _contentPlatFormCustomerPictureService.AddAsync(addPicture);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 审核成交情况
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task CheckAsync(UpdateContentPlatFormOrderDealInfoDto updateDto)
        {
            try
            {
                var ContentPlatFOrmOrderDealInfo = await dalContentPlatFormOrderDealInfo.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (ContentPlatFOrmOrderDealInfo == null)
                    throw new Exception("未找到该成交信息！");


                ContentPlatFOrmOrderDealInfo.Id = updateDto.Id;
                ContentPlatFOrmOrderDealInfo.CheckBy = updateDto.CheckBy;
                ContentPlatFOrmOrderDealInfo.CheckDate = DateTime.Now;
                ContentPlatFOrmOrderDealInfo.CheckPrice = updateDto.CheckPrice;
                ContentPlatFOrmOrderDealInfo.CheckRemark = updateDto.CheckRemark;
                ContentPlatFOrmOrderDealInfo.CheckState = updateDto.CheckState;
                ContentPlatFOrmOrderDealInfo.SettlePrice = updateDto.SettlePrice;
                await dalContentPlatFormOrderDealInfo.UpdateAsync(ContentPlatFOrmOrderDealInfo, true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 成交情况回款
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task SettleAsync(UpdateContentPlatFormOrderDealInfoDto updateDto)
        {
            try
            {
                var ContentPlatFOrmOrderDealInfo = await dalContentPlatFormOrderDealInfo.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (ContentPlatFOrmOrderDealInfo == null)
                    throw new Exception("未找到该成交信息！");


                ContentPlatFOrmOrderDealInfo.Id = updateDto.Id;
                ContentPlatFOrmOrderDealInfo.IsReturnBackPrice = true;
                ContentPlatFOrmOrderDealInfo.ReturnBackDate = updateDto.ReturnBackDate;
                ContentPlatFOrmOrderDealInfo.ReturnBackPrice = updateDto.ReturnBackPrice;
                await dalContentPlatFormOrderDealInfo.UpdateAsync(ContentPlatFOrmOrderDealInfo, true);

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
                var ContentPlatFOrmOrderDealInfo = await dalContentPlatFormOrderDealInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (ContentPlatFOrmOrderDealInfo == null)
                    throw new Exception("未找到该成交信息");

                await dalContentPlatFormOrderDealInfo.DeleteAsync(ContentPlatFOrmOrderDealInfo, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ContentPlatFormOrderDealInfoDto>> GetByOrderIdAsync(string orderId)
        {
            try
            {
                List<ContentPlatFormOrderDealInfoDto> returnList = new List<ContentPlatFormOrderDealInfoDto>();
                var selectResult = await dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.ContentPlatFormOrderId == orderId).ToListAsync();
                if (selectResult == null)
                {
                    return returnList;
                }
                foreach (var ContentPlatFOrmOrderDealInfo in selectResult)
                {
                    ContentPlatFormOrderDealInfoDto contentPlatFOrmOrderDealInfoDto = new ContentPlatFormOrderDealInfoDto();
                    contentPlatFOrmOrderDealInfoDto.Id = ContentPlatFOrmOrderDealInfo.Id;
                    contentPlatFOrmOrderDealInfoDto.ContentPlatFormOrderId = ContentPlatFOrmOrderDealInfo.ContentPlatFormOrderId;
                    contentPlatFOrmOrderDealInfoDto.CreateDate = ContentPlatFOrmOrderDealInfo.CreateDate;
                    contentPlatFOrmOrderDealInfoDto.IsToHospital = ContentPlatFOrmOrderDealInfo.IsToHospital;
                    contentPlatFOrmOrderDealInfoDto.ToHospitalType = ContentPlatFOrmOrderDealInfo.ToHospitalType;
                    contentPlatFOrmOrderDealInfoDto.ToHospitalDate = ContentPlatFOrmOrderDealInfo.ToHospitalDate;
                    contentPlatFOrmOrderDealInfoDto.LastDealHospitalId = ContentPlatFOrmOrderDealInfo.LastDealHospitalId;
                    contentPlatFOrmOrderDealInfoDto.IsDeal = ContentPlatFOrmOrderDealInfo.IsDeal;
                    contentPlatFOrmOrderDealInfoDto.DealPicture = ContentPlatFOrmOrderDealInfo.DealPicture;
                    contentPlatFOrmOrderDealInfoDto.Remark = ContentPlatFOrmOrderDealInfo.Remark;
                    contentPlatFOrmOrderDealInfoDto.Price = ContentPlatFOrmOrderDealInfo.Price;
                    contentPlatFOrmOrderDealInfoDto.DealDate = ContentPlatFOrmOrderDealInfo.DealDate;
                    contentPlatFOrmOrderDealInfoDto.OtherAppOrderId = ContentPlatFOrmOrderDealInfo.OtherAppOrderId;
                    contentPlatFOrmOrderDealInfoDto.IsAcompanying = ContentPlatFOrmOrderDealInfo.IsAcompanying;
                    contentPlatFOrmOrderDealInfoDto.IsOldCustomer = ContentPlatFOrmOrderDealInfo.IsOldCustomer;
                    contentPlatFOrmOrderDealInfoDto.CommissionRatio = ContentPlatFOrmOrderDealInfo.CommissionRatio;
                    contentPlatFOrmOrderDealInfoDto.CheckState = ContentPlatFOrmOrderDealInfo.CheckState;
                    contentPlatFOrmOrderDealInfoDto.CheckStateText = ServiceClass.GetCheckTypeText(ContentPlatFOrmOrderDealInfo.CheckState.Value);
                    contentPlatFOrmOrderDealInfoDto.CheckPrice = ContentPlatFOrmOrderDealInfo.CheckPrice;
                    contentPlatFOrmOrderDealInfoDto.CheckDate = ContentPlatFOrmOrderDealInfo.CheckDate;
                    contentPlatFOrmOrderDealInfoDto.CheckBy = ContentPlatFOrmOrderDealInfo.CheckBy;
                    contentPlatFOrmOrderDealInfoDto.SettlePrice = ContentPlatFOrmOrderDealInfo.SettlePrice;
                    contentPlatFOrmOrderDealInfoDto.CheckRemark = ContentPlatFOrmOrderDealInfo.CheckRemark;
                    contentPlatFOrmOrderDealInfoDto.IsReturnBackPrice = ContentPlatFOrmOrderDealInfo.IsReturnBackPrice;
                    contentPlatFOrmOrderDealInfoDto.ReturnBackDate = ContentPlatFOrmOrderDealInfo.ReturnBackDate;
                    contentPlatFOrmOrderDealInfoDto.ReturnBackPrice = ContentPlatFOrmOrderDealInfo.ReturnBackPrice;
                    contentPlatFOrmOrderDealInfoDto.CreateBy = ContentPlatFOrmOrderDealInfo.CreateBy;
                    returnList.Add(contentPlatFOrmOrderDealInfoDto);
                }
                return returnList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PerformanceInfoDto> GetOrderDetailInfoPerformance(int year, int month)
        {

            //查找当前月ip运营总业绩目标
            PerformanceDto totalPerformanceTarget = await _liveAnchorMonthlyTargetService.GetLiveAnchorMonthlyTargetTotalPerformance(year, month);
            //查找当前月IP运营带货总业绩目标
            PerformanceDto totalCommerceTarget = await _liveAnchorMonthlyTargetService.GetLiveAnchorMonthTargetTotalCommercePerformance(year, month);
            //查找当前月份老客业绩目标
            PerformanceDto oldCustomerTarget = await _liveAnchorMonthlyTargetService.GetLiveAnchorMonthOldPerformanceTarget(year,month);
            //查找当前月份新诊业绩目标
            PerformanceDto newCustomerTarget = await _liveAnchorMonthlyTargetService.GetLiveAnchorMonthNewPerformanceTarget(year,month);

            //总业绩目标 业绩目标+带货目标
            totalPerformanceTarget.PerformanceCount = totalPerformanceTarget.PerformanceCount + totalCommerceTarget.PerformanceCount;

            //获取当前选中月的已完成业绩
            PerformanceDto sumAlreadyCompletePerformance = await GetPerformanceByYearAndMonth(year, month, null);
            //获取当前选中月已完成的带货总业绩
            PerformanceDto sumAlreadyCompleteCommercePerformance = await _liveAnchorMonthlyTargetService.GetLiveAnchorMonthTargetAlreadyCompleteCommercePerformance(year, month);

            sumAlreadyCompletePerformance.PerformanceCount = sumAlreadyCompletePerformance.PerformanceCount + sumAlreadyCompleteCommercePerformance.PerformanceCount;

            //获取当前月份老客总业绩
            PerformanceDto sumOldPerformance = await GetPerformanceByYearAndMonth(year, month, true);
            //获取当前月份新客总业绩
            PerformanceDto sumNewPerformance = await GetPerformanceByYearAndMonth(year, month, false);
            //获取同比月份总业绩
            PerformanceDto TotalPerfomanceYearOnYear = await GetPerformanceByYearAndMonth(year - 1, month, null);
            //获取环比月份总业绩
            PerformanceDto TotalPerfomanceChainRatio = null;
            if (month == 1) {
                TotalPerfomanceChainRatio = await GetPerformanceByYearAndMonth(year-1, 12, null);
            } else {
                TotalPerfomanceChainRatio = await GetPerformanceByYearAndMonth(year, month - 1, null);
            }
             
            //获取同比月份新诊业绩
            PerformanceDto sumNewPerfomanceYearOnYear = await GetPerformanceByYearAndMonth(year - 1, month, false);
            //获取环比月份新诊业绩
            PerformanceDto sumNewPerfomanceChainRatio = null;
            if (month == 1) {
                sumNewPerfomanceChainRatio = await GetPerformanceByYearAndMonth(year-1, 12, false);
            } else {
                sumNewPerfomanceChainRatio = await GetPerformanceByYearAndMonth(year, month - 1, false);
            }
            //获取同比月份老客业绩
            PerformanceDto sumOldPerfomanceYearOnYear = await GetPerformanceByYearAndMonth(year - 1, month, true);
            //获取环比月份老客业绩
            PerformanceDto sumOldPerfomanceChainRatio = null;
            if (month==1) {
                sumOldPerfomanceChainRatio = await GetPerformanceByYearAndMonth(year-1, 12, true);
            } else {
                sumOldPerfomanceChainRatio = await GetPerformanceByYearAndMonth(year, month - 1, true);
            }

            
            //获取同比月份带货业绩
            PerformanceDto sumCommercePerfomanceYearOnYear = await _liveAnchorMonthlyTargetService.GetLiveAnchorMonthTargetAlreadyCompleteCommercePerformance(year - 1, month);

            TotalPerfomanceYearOnYear.PerformanceCount = TotalPerfomanceYearOnYear.PerformanceCount + sumCommercePerfomanceYearOnYear.PerformanceCount;

            //获取环比月份带货业绩
            PerformanceDto sumCommercePerfomanceChainRatio = null;
            if (month==1) {
                sumCommercePerfomanceChainRatio = await _liveAnchorMonthlyTargetService.GetLiveAnchorMonthTargetAlreadyCompleteCommercePerformance(year-1, 12);
            }
            else
            {
                sumCommercePerfomanceChainRatio = await _liveAnchorMonthlyTargetService.GetLiveAnchorMonthTargetAlreadyCompleteCommercePerformance(year, month - 1);
            }

            

            TotalPerfomanceChainRatio.PerformanceCount = TotalPerfomanceChainRatio.PerformanceCount + sumCommercePerfomanceChainRatio.PerformanceCount;

            //总业绩目标达成
            decimal? totalTargetComplete = totalPerformanceTarget.PerformanceCount == 0m ? null : Math.Round(sumAlreadyCompletePerformance.PerformanceCount / totalPerformanceTarget.PerformanceCount * 100, 2);
            //新诊目标达成
            decimal? newCustomerTargetComplete = newCustomerTarget.PerformanceCount == 0m ? null : Math.Round(sumNewPerformance.PerformanceCount / newCustomerTarget.PerformanceCount * 100, 2);
            //老客业绩目标达成
            decimal? oldCustomerTargetComplete = oldCustomerTarget.PerformanceCount == 0m ? null : Math.Round(sumOldPerformance.PerformanceCount / oldCustomerTarget.PerformanceCount * 100, 2);
            //带货业绩目标达成
            decimal? commerceTargetComplete = totalCommerceTarget.PerformanceCount == 0m ? null : Math.Round(sumAlreadyCompleteCommercePerformance.PerformanceCount / totalCommerceTarget.PerformanceCount * 100, 2);

            //业绩同比
            decimal? totalPerfomanceYearOnYearRatio = TotalPerfomanceYearOnYear.PerformanceCount == 0m ? null : Math.Round((sumAlreadyCompletePerformance.PerformanceCount - TotalPerfomanceYearOnYear.PerformanceCount) / TotalPerfomanceYearOnYear.PerformanceCount * 100, 2);
            //业绩环比
            decimal? totalPerfomanceChainRation = TotalPerfomanceChainRatio.PerformanceCount == 0m ? null : Math.Round((sumAlreadyCompletePerformance.PerformanceCount - TotalPerfomanceChainRatio.PerformanceCount) / TotalPerfomanceChainRatio.PerformanceCount * 100, 2);

            //老客业绩同比
            decimal? oldPerfomanceYearOnYearRation = sumOldPerfomanceYearOnYear.PerformanceCount == 0m ? null : Math.Round((sumOldPerformance.PerformanceCount - sumOldPerfomanceYearOnYear.PerformanceCount) / sumOldPerfomanceYearOnYear.PerformanceCount * 100, 2);
            //老客业绩环比
            decimal? oldPerfomanceChainRation = sumOldPerfomanceChainRatio.PerformanceCount == 0m ? null : Math.Round((sumOldPerformance.PerformanceCount - sumOldPerfomanceChainRatio.PerformanceCount) / sumOldPerfomanceChainRatio.PerformanceCount * 100, 2);

            //新诊业绩同比
            decimal? newPerfomanceYearOnYearRation = sumNewPerfomanceYearOnYear.PerformanceCount == 0 ? null : Math.Round((sumNewPerformance.PerformanceCount - sumNewPerfomanceYearOnYear.PerformanceCount) / sumNewPerfomanceYearOnYear.PerformanceCount * 100, 2);
            //新诊业绩环比
            decimal? newPerfomanceChainRation = sumNewPerfomanceChainRatio.PerformanceCount == 0m ? null : Math.Round((sumNewPerformance.PerformanceCount - sumNewPerfomanceChainRatio.PerformanceCount) / sumNewPerfomanceChainRatio.PerformanceCount * 100, 2);

            //带货业绩同比
            decimal? commercePerfomanceYearOnYearRatio = sumCommercePerfomanceYearOnYear.PerformanceCount == 0m ? null : Math.Round((sumAlreadyCompleteCommercePerformance.PerformanceCount - sumCommercePerfomanceYearOnYear.PerformanceCount) / sumCommercePerfomanceYearOnYear.PerformanceCount * 100, 2);
            //带货业绩环比
            decimal? commercePerfomanceChainRation = sumCommercePerfomanceChainRatio.PerformanceCount == 0m ? null : Math.Round((sumAlreadyCompleteCommercePerformance.PerformanceCount - sumCommercePerfomanceChainRatio.PerformanceCount) / sumCommercePerfomanceChainRatio.PerformanceCount * 100, 2);


            PerformanceInfoDto performanceInfoDto = new PerformanceInfoDto
            {
                TotalPerformance = sumAlreadyCompletePerformance.PerformanceCount,
                TotalPerformanceTargetComplete = totalTargetComplete,
                OldPerformanceTargetComplete = oldCustomerTargetComplete,
                NewPerformanceTargetComplete=newCustomerTargetComplete,
                CommercePerformanceTargetComplete= commerceTargetComplete,
                NewPerformance = sumNewPerformance.PerformanceCount,
                OldPerformance = sumOldPerformance.PerformanceCount,
                CommercePerformance = sumAlreadyCompleteCommercePerformance.PerformanceCount,
                TotalPerformanceYearOnYear = totalPerfomanceYearOnYearRatio,
                TotalPerformanceChainRatio = totalPerfomanceChainRation,
                OldPerformanceYearOnYear = oldPerfomanceYearOnYearRation,
                OldPerformanceChainRatio = oldPerfomanceChainRation,
                NewPerformanceYearOnYear = newPerfomanceYearOnYearRation,
                NewPerformanceChainRatio = newPerfomanceChainRation,
                CommercePerformanceYearOnYear = commercePerfomanceYearOnYearRatio,
                CommercePerformanceChainRatio = commercePerfomanceChainRation
            };
            List<PerformanceRatioDto> ratioDtos = new List<PerformanceRatioDto>();
            if (sumAlreadyCompletePerformance.PerformanceCount != 0m)
            {
                PerformanceRatioDto newRatio = new PerformanceRatioDto
                {
                    PerformanceText = "新诊业绩",
                    PerformancePrice = sumNewPerformance.PerformanceCount,
                    PerformanceRatio = Math.Round(sumNewPerformance.PerformanceCount / sumAlreadyCompletePerformance.PerformanceCount * 100, 2)
                };
                PerformanceRatioDto oldRatio = new PerformanceRatioDto
                {
                    PerformanceText = "老客业绩",
                    PerformancePrice = sumOldPerformance.PerformanceCount,
                    PerformanceRatio = Math.Round(sumOldPerformance.PerformanceCount / sumAlreadyCompletePerformance.PerformanceCount * 100, 2)
                };
                PerformanceRatioDto commerceRatio = new PerformanceRatioDto
                {
                    PerformanceText = "带货业绩",
                    PerformancePrice = sumAlreadyCompleteCommercePerformance.PerformanceCount,
                    PerformanceRatio = Math.Round(sumAlreadyCompleteCommercePerformance.PerformanceCount / sumAlreadyCompletePerformance.PerformanceCount * 100, 2)
                };
                ratioDtos.Add(newRatio);
                ratioDtos.Add(oldRatio);
                ratioDtos.Add(commerceRatio);
            }
            else {
                PerformanceRatioDto newRatio = new PerformanceRatioDto
                {
                    PerformanceText = "新诊业绩",
                    PerformancePrice = 0,
                    PerformanceRatio = 0
                };
                PerformanceRatioDto oldRatio = new PerformanceRatioDto
                {
                    PerformanceText = "老客业绩",
                    PerformancePrice = 0,
                    PerformanceRatio = 0
                };
                PerformanceRatioDto commerceRatio = new PerformanceRatioDto
                {
                    PerformanceText = "带货业绩",
                    PerformancePrice = 0,
                    PerformanceRatio = 0
                };
                ratioDtos.Add(newRatio);
                ratioDtos.Add(oldRatio);
                ratioDtos.Add(commerceRatio);
            }
            //各业绩占比
            performanceInfoDto.PerformanceRatios = ratioDtos;
            //老客业绩数据
            var old = await GetPerformance(year, month, true);

            List<PerformanceListInfo> oldPerfomanceList = new List<PerformanceListInfo>();

            for (int i = 0; i < month; i++)
            {
                PerformanceListInfo listInfo = new PerformanceListInfo();
                DateTime date = new DateTime(year, i + 1, 1);
                listInfo.date = date.Month.ToString();
                listInfo.Performance = 0.00m;
                oldPerfomanceList.Add(listInfo);
            }

            foreach (var oldPerfomance in old)
            {
                oldPerfomanceList.Find(x => x.date == oldPerfomance.Date.Month.ToString()).Performance = oldPerfomance.PerfomancePrice;
            }


            //新客业绩数据
            var newp = await GetPerformance(year, month, false);
            List<PerformanceListInfo> newPerfomanceList = new List<PerformanceListInfo>();
            for (int i = 0; i < month; i++)
            {
                PerformanceListInfo listInfo = new PerformanceListInfo();
                DateTime date = new DateTime(year, i + 1, 1);
                listInfo.date = date.Month.ToString();
                listInfo.Performance = 0.00m;
                newPerfomanceList.Add(listInfo);
            }
            foreach (var newPerfomance in newp)
            {
                newPerfomanceList.Find(x => x.date == newPerfomance.Date.Month.ToString()).Performance = newPerfomance.PerfomancePrice;
            }


            //带货业绩数据
            var comm = await _liveAnchorMonthlyTargetService.GetLiveAnchorCommercePerformance(year, month);
            List<PerformanceListInfo> commercePerfomanceList = new List<PerformanceListInfo>();
            for (int i = 0; i < month; i++)
            {
                PerformanceListInfo listInfo = new PerformanceListInfo();
                DateTime date = new DateTime(year, i + 1, 1);
                listInfo.date = date.Month.ToString();
                listInfo.Performance = 0.00m;
                commercePerfomanceList.Add(listInfo);
            }
            foreach (var commercePerfomance in comm)
            {
                commercePerfomanceList.Find(x => x.date == commercePerfomance.Date.Month.ToString()).Performance = commercePerfomance.PerfomancePrice;
            }
            performanceInfoDto.commercePerformanceList = commercePerfomanceList;
            performanceInfoDto.oldPerformanceList = oldPerfomanceList;
            performanceInfoDto.newPerformanceList = newPerfomanceList;
            return performanceInfoDto;
        }

        public async Task<PerformanceDto> GetPerformanceByYearAndMonth(int year, int month, bool? isOldCustomer)
        {
            //筛选结束的月份
            DateTime endDate = new DateTime(year, month, 1).AddMonths(1);
            //选定的月份
            DateTime currentDate = new DateTime(year, month, 1);
            var performance = dalContentPlatFormOrderDealInfo.GetAll().Where(o => o.CreateDate >= currentDate && o.CreateDate < endDate && o.IsDeal == true);
            if (isOldCustomer != null)
            {
                performance = performance.Where(o => o.IsOldCustomer == isOldCustomer);
            }
            var sum = await performance.SumAsync(o => o.Price);
            PerformanceDto dto = new PerformanceDto
            {
                PerformanceCount = sum
            };
            return dto;
        }

        public async Task<List<PerformanceInfoByDateDto>> GetPerformance(int year, int month, bool? isCustomer)
        {
            //开始月份
            DateTime startTime = new DateTime(year, 1, 1);
            //筛选结束的月份
            DateTime endDate = new DateTime(year, month, 1).AddMonths(1);
            //选定的月份
            DateTime currentDate = new DateTime(year, month, 1);
            var orderinfo = dalContentPlatFormOrderDealInfo.GetAll().Where(o => o.IsDeal == true && o.CreateDate >= startTime && o.CreateDate < endDate);
            if (isCustomer != null)
            {
                orderinfo = orderinfo.Where(o => o.IsOldCustomer == isCustomer);
            }
            return orderinfo.GroupBy(o => o.CreateDate.Month).Select(o => new PerformanceInfoByDateDto
            {
                Date = DateTime.Parse($"{year}-{o.Key}"),
                PerfomancePrice = o.Sum(o => o.Price)
            }).ToList(); ;
        }

    }
}
