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
        private IDalHospitalInfo _dalHospitalInfo;
        public ContentPlatFormOrderDealInfoService(IDalContentPlatFormOrderDealInfo dalContentPlatFormOrderDealInfo,
            IAmiyaEmployeeService amiyaEmployeeService,
            IContentPlatFormCustomerPictureService contentPlatFormCustomerPictureService,
            IDalBindCustomerService dalBindCustomerService,
            IDalAmiyaEmployee dalAmiyaEmployee,
            IHospitalInfoService hospitalInfoService, ILiveAnchorMonthlyTargetService liveAnchorMonthlyTargetService, IDalHospitalInfo dalHospitalInfo)
        {
            this.dalContentPlatFormOrderDealInfo = dalContentPlatFormOrderDealInfo;
            _hospitalInfoService = hospitalInfoService;
            _amiyaEmployeeService = amiyaEmployeeService;
            _contentPlatFormCustomerPictureService = contentPlatFormCustomerPictureService;
            _dalBindCustomerService = dalBindCustomerService;
            _dalAmiyaEmployee = dalAmiyaEmployee;
            _liveAnchorMonthlyTargetService = liveAnchorMonthlyTargetService;
            _dalHospitalInfo = dalHospitalInfo;
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
                //财务录入数据只有管理员研发与财务能看到
                if (employee.AmiyaPositionInfo.Id != 1 && employee.AmiyaPositionInfo.Id != 13 && employee.AmiyaPositionInfo.Id != 16)
                {

                    dealInfo = from d in dealInfo
                               where d.CreateBy != 61 && d.CreateBy != 80
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
                //财务录入数据只有管理员研发与财务能看到
                if (employee.AmiyaPositionInfo.Id != 1 && employee.AmiyaPositionInfo.Id != 13 && employee.AmiyaPositionInfo.Id != 16)
                {

                    dealInfo = from d in dealInfo
                               where d.CreateBy != 61 && d.CreateBy != 80
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
        /// <summary>
        /// 获取总业绩
        /// </summary>
        /// <param name="IsOldCustomer">新老客</param>
        /// <returns></returns>
        public async Task<decimal> GetPerformance(bool? IsOldCustomer)
        {
            var performance = await dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.IsToHospital == true && (IsOldCustomer == null || e.IsOldCustomer == IsOldCustomer)).SumAsync(e => e.Price);
            return performance;
        }
        /// <summary>
        /// 新客上门人数
        /// </summary>
        /// <returns></returns>
        public async Task<decimal> GetNewCustomerToHospitalCount()
        {
            var count = await dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.IsToHospital == true&&e.IsOldCustomer==false).CountAsync();
            return count;
        }
        /// <summary>
        /// 新客成交人数
        /// </summary>
        /// <returns></returns>
        public async Task<decimal> GetNewCustomerDealCount()
        {
            var count = await dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.IsDeal == true&&e.IsOldCustomer==false).CountAsync();
            return count;
        }

        #region【业绩板块】


        /// <summary>
        /// 根据主播获取啊美雅业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isOldCustomer">新客/老客</param>
        /// <param name="LiveAnchorIds">各个平台主播id集合</param>
        /// <returns></returns>
        public async Task<List<ContentPlatFormOrderDealInfoDto>> GetPerformanceByYearAndMonth(int year, int month, bool? isOldCustomer, List<int> LiveAnchorIds)
        {

            //筛选结束的月份
            DateTime endDate = new DateTime(year, month, 1).AddMonths(1);
            //选定的月份
            DateTime currentDate = new DateTime(year, month, 1);
            return await dalContentPlatFormOrderDealInfo.GetAll().Include(x => x.ContentPlatFormOrder).ThenInclude(x => x.LiveAnchor)
                .Where(o => o.CreateDate >= currentDate && o.CreateDate < endDate && o.IsDeal == true)
                .Where(o => isOldCustomer == null || o.IsOldCustomer == isOldCustomer)
                .Where(o => LiveAnchorIds.Count == 0 || LiveAnchorIds.Contains(o.ContentPlatFormOrder.LiveAnchor.Id))
                .Select(
                  ContentPlatFOrmOrderDealInfo =>
                       new ContentPlatFormOrderDealInfoDto
                       {
                           Price = ContentPlatFOrmOrderDealInfo.Price,
                           IsOldCustomer = ContentPlatFOrmOrderDealInfo.IsOldCustomer
                       }
                ).ToListAsync();
        }

        /// <summary>
        /// 获取派单成交业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isOldSend">历史/当月派单,true为历史派单当月成交，false为当月派单当月成交</param>
        /// <param name="LiveAnchorIds">各个平台主播id集合</param>
        /// <returns></returns>
        public async Task<List<ContentPlatFormOrderDealInfoDto>> GetSendAndDealPerformanceByYearAndMonth(int year, int month, bool? isOldSend, List<int> liveAnchorIds)
        {
            //筛选结束的月份
            DateTime endDate = new DateTime(year, month, 1).AddMonths(1);
            //选定的月份
            DateTime currentDate = new DateTime(year, month, 1);
            var result = await dalContentPlatFormOrderDealInfo.GetAll().Include(x => x.ContentPlatFormOrder).ThenInclude(x => x.LiveAnchor)
                .Where(o => o.CreateDate >= currentDate && o.CreateDate < endDate && o.IsDeal == true)
                .Where(o => liveAnchorIds.Count == 0 || liveAnchorIds.Contains(o.ContentPlatFormOrder.LiveAnchor.Id))
                .ToListAsync();
            if (isOldSend == true)
            {
                result = result.Where(x => x.ContentPlatFormOrder.SendDate.HasValue && x.ContentPlatFormOrder.SendDate.Value.Month != x.CreateDate.Month).ToList();
            }
            if (isOldSend == false)
            {
                result = result.Where(x => x.ContentPlatFormOrder.SendDate.HasValue && x.ContentPlatFormOrder.SendDate.Value.Month == x.CreateDate.Month).ToList();
            }
            var returnInfo = result.Select(
                  d =>
                       new ContentPlatFormOrderDealInfoDto
                       {
                           Id = d.Id,
                           ContentPlatFormOrderId = d.ContentPlatFormOrderId,
                           CreateDate = d.CreateDate,
                           SendDate = d.ContentPlatFormOrder.SendDate,
                           CustomerNickName = d.ContentPlatFormOrder.CustomerName,
                           Phone = ServiceClass.GetIncompletePhone(d.ContentPlatFormOrder.Phone),
                           IsOldCustomer = d.IsOldCustomer,
                           ToHospitalTypeText = ServiceClass.GerContentPlatFormOrderToHospitalTypeText(d.ToHospitalType),
                           AddOrderPrice = d.ContentPlatFormOrder.AddOrderPrice,
                           Price = d.Price,
                       }
                ).ToList();

            return returnInfo;
        }


        /// <summary>
        /// 获取当日上门成交业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isOldSend"></param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        public async Task<List<ContentPlatFormOrderDealInfoDto>> GetTodaySendPerformanceAsync(int liveAnchorId, DateTime recordDate)
        {
            //筛选结束的月份
            DateTime endDate = recordDate.Date.AddDays(1);
            //选定的月份
            DateTime currentDate = recordDate.Date;
            var result = await dalContentPlatFormOrderDealInfo.GetAll().Include(x => x.ContentPlatFormOrder)
                .Where(o => o.IsToHospital == true && o.ToHospitalDate.HasValue == true && o.ToHospitalDate >= currentDate && o.ToHospitalDate < endDate)
                .Where(o => o.ContentPlatFormOrder.LiveAnchorId == liveAnchorId)
                .ToListAsync();
            var returnInfo = result.Select(
                  d =>
                       new ContentPlatFormOrderDealInfoDto
                       {
                           IsToHospital = d.IsToHospital,
                           IsDeal = d.IsDeal,
                           IsOldCustomer = d.IsOldCustomer,
                           ToHospitalType = d.ToHospitalType,
                           Price = d.Price,
                       }
                ).ToList();

            return returnInfo;
        }

        /// <summary>
        /// 新/老客业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isCustomer"></param>
        /// <param name="LiveAnchorIds">各个平台主播id集合</param>
        /// <returns></returns>
        public async Task<List<PerformanceInfoByDateDto>> GetPerformanceBrokenLineAsync(int year, int month, bool? isCustomer, List<int> LiveAnchorIds)
        {
            //开始月份
            DateTime startTime = new DateTime(year, 1, 1);
            //筛选结束的月份
            DateTime endDate = new DateTime(year, month, 1).AddMonths(1);
            var orderinfo = await dalContentPlatFormOrderDealInfo.GetAll()
                .Where(o => o.IsDeal == true && o.CreateDate >= startTime && o.CreateDate < endDate)
                .Where(o => isCustomer == null || o.IsOldCustomer == isCustomer)
                .Where(o => LiveAnchorIds.Count == 0 || LiveAnchorIds.Contains(o.ContentPlatFormOrder.LiveAnchor.Id)).ToListAsync();

            var list = orderinfo.Select(x => new PerformanceInfoDateDto { Date = x.CreateDate, PerfomancePrice = x.Price }).ToList();
            var returnResult = list.GroupBy(x => x.Date.Month).Select(x => new PerformanceInfoByDateDto { Date = x.Key.ToString(), PerfomancePrice = x.Sum(z => z.PerfomancePrice) }).ToList();
            return returnResult;
        }

        /// <summary>
        /// 成交情况折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isOldSend"></param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetHistoryAndThisMonthOrderPerformance(int year, int month, bool? isOldSend, List<int> liveAnchorIds)
        {
            //开始月份
            DateTime startTime = new DateTime(year, 1, 1);
            //筛选结束的月份
            DateTime endDate = new DateTime(year, month, 1).AddMonths(1);
            var orderinfo = await dalContentPlatFormOrderDealInfo.GetAll().Include(x => x.ContentPlatFormOrder).ThenInclude(x => x.LiveAnchor)
                .Where(o => o.IsDeal == true && o.CreateDate >= startTime && o.CreateDate < endDate)
                .Where(o => liveAnchorIds.Count == 0 || liveAnchorIds.Contains(o.ContentPlatFormOrder.LiveAnchor.Id))
                .ToListAsync();

            if (isOldSend == true)
            {
                orderinfo = orderinfo.Where(x => x.ContentPlatFormOrder.SendDate.HasValue && x.ContentPlatFormOrder.SendDate.Value.Month != x.CreateDate.Month).ToList();
            }
            if (isOldSend == false)
            {
                orderinfo = orderinfo.Where(x => x.ContentPlatFormOrder.SendDate.HasValue && x.ContentPlatFormOrder.SendDate.Value.Month == x.CreateDate.Month).ToList();
            }

            return orderinfo.GroupBy(x => x.CreateDate.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Sum(z => z.Price) }).ToList();
        }


        /// <summary>
        /// 根据主播获取分组独立/协助业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isAssist">是否协助</param>
        /// <param name="LiveAnchorIds">各个平台主播id集合</param>
        /// <param name="amiyaEmployeeId">主播独立业绩获取时传入主播客服id</param>
        /// <returns></returns>
        public async Task<List<ContentPlatFormOrderDealInfoDto>> GetIndependentOrAssistPerformanceByYearAndMonth(int year, int month, bool? isAssist, List<int> LiveAnchorIds, int amiyaEmployeeId)
        {
            int consultationType = 0;
            if (isAssist == true)
            {
                consultationType = (int)ContentPlateFormOrderConsultationType.Collaboration;
            }
            else if (isAssist == false)
            {
                consultationType = (int)ContentPlateFormOrderConsultationType.IndependentFollowUp;
            }

            //筛选结束的月份
            DateTime endDate = new DateTime(year, month, 1).AddMonths(1);
            //选定的月份
            DateTime currentDate = new DateTime(year, month, 1);
            return await dalContentPlatFormOrderDealInfo.GetAll().Include(x => x.ContentPlatFormOrder).ThenInclude(x => x.LiveAnchor)
                .Where(o => o.CreateDate >= currentDate && o.CreateDate < endDate && o.IsDeal == true)
                .Where(o => isAssist == null || o.ContentPlatFormOrder.ConsultationType == consultationType)
                .Where(o => amiyaEmployeeId == 0 || o.CreateBy == amiyaEmployeeId)
                .Where(o => LiveAnchorIds.Count == 0 || LiveAnchorIds.Contains(o.ContentPlatFormOrder.LiveAnchor.Id))
                .Select(
                  ContentPlatFOrmOrderDealInfo =>
                       new ContentPlatFormOrderDealInfoDto
                       {
                           Price = ContentPlatFOrmOrderDealInfo.Price,
                           ConsultationTypeText = ServiceClass.GetContentPlateFormOrderConsultationTypeText(ContentPlatFOrmOrderDealInfo.ContentPlatFormOrder.ConsultationType)
                       }
                ).ToListAsync();
        }

        /// <summary>
        /// 新/老客客单价折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isOldCustomer"></param>
        /// <param name="LiveAnchorIds">各个平台主播id集合</param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetGuestUnitPricePerformanceBrokenLineAsync(int year, int month, bool? isOldCustomer, List<int> LiveAnchorIds)
        {
            //开始月份
            DateTime startTime = new DateTime(year, 1, 1);
            //筛选结束的月份
            DateTime endDate = new DateTime(year, month, 1).AddMonths(1);
            var orderinfo = await dalContentPlatFormOrderDealInfo.GetAll()
                .Where(o => o.IsDeal == true && o.CreateDate >= startTime && o.CreateDate < endDate)
                .Where(o => isOldCustomer == null || o.IsOldCustomer == isOldCustomer)
                .Where(o => LiveAnchorIds.Count == 0 || LiveAnchorIds.Contains(o.ContentPlatFormOrder.LiveAnchor.Id)).ToListAsync();

            var list = orderinfo.Select(x => new PerformanceInfoDateDto { Date = x.CreateDate, PerfomancePrice = x.Price }).ToList();
            var returnResult = list.GroupBy(x => x.Date.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Sum(z => z.PerfomancePrice) / x.Count() }).ToList();
            return returnResult;
        }

        /// <summary>
        /// 获取独立/协助业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isOldSend"></param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetIndependenceOrAssistAsync(int year, int month, bool? isAssist, List<int> LiveAnchorIds, int amiyaEmployeeId)
        {
            int consultationType = 0;
            if (isAssist == true)
            {
                consultationType = (int)ContentPlateFormOrderConsultationType.Collaboration;
            }
            else if (isAssist == false)
            {
                consultationType = (int)ContentPlateFormOrderConsultationType.IndependentFollowUp;
            }
            //开始月份
            DateTime startTime = new DateTime(year, 1, 1);
            //筛选结束的月份
            DateTime endDate = new DateTime(year, month, 1).AddMonths(1);
            var orderinfo = await dalContentPlatFormOrderDealInfo.GetAll().Include(x => x.ContentPlatFormOrder).ThenInclude(x => x.LiveAnchor)
               .Where(o => o.CreateDate >= startTime && o.CreateDate < endDate && o.IsDeal == true)
                .Where(o => isAssist == null || o.ContentPlatFormOrder.ConsultationType == consultationType)
                .Where(o => amiyaEmployeeId == 0 || o.CreateBy == amiyaEmployeeId)
                .Where(o => LiveAnchorIds.Count == 0 || LiveAnchorIds.Contains(o.ContentPlatFormOrder.LiveAnchor.Id))
                .ToListAsync();


            return orderinfo.GroupBy(x => x.CreateDate.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Sum(z => z.Price) }).ToList();
        }


        #endregion
        #region 全国机构top10运营数据

        /// <summary>
        /// 总业绩
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContentPlateformOrderDealInfoHospitalPerformanceDto>> GetTopTenHospitalTotalPerformance()
        {
            var performanceList = (from d in _dalHospitalInfo.GetAll()
                                   from h in dalContentPlatFormOrderDealInfo.GetAll().Where(c => c.IsDeal == true && c.LastDealHospitalId != null)
                                   where d.Id == h.LastDealHospitalId
                                   group h by d.Name into g
                                   orderby g.Sum(item => item.Price) descending
                                   select new ContentPlateformOrderDealInfoHospitalPerformanceDto
                                   {
                                       HospitalName = g.Key,
                                       Performance = g.Sum(item => item.Price)
                                   });
            return performanceList.Skip(0).Take(10).ToList();
        }
        /// <summary>
        /// 新客业绩
        /// </summary>
        /// <returns></returns>

        public async Task<List<ContentPlateformOrderDealInfoHospitalPerformanceDto>> GetTopTenNewCustomerPerformance()
        {
            var performanceList = (from d in _dalHospitalInfo.GetAll()
                                   from h in dalContentPlatFormOrderDealInfo.GetAll().Where(c => c.IsDeal == true && c.LastDealHospitalId != null && c.IsOldCustomer == false)
                                   where d.Id == h.LastDealHospitalId
                                   group h by d.Name into g
                                   orderby g.Sum(item => item.Price) descending
                                   select new ContentPlateformOrderDealInfoHospitalPerformanceDto
                                   {
                                       HospitalName = g.Key,
                                       Performance = g.Sum(item => item.Price)
                                   });
            return performanceList.Skip(0).Take(10).ToList();
        }
        /// <summary>
        /// 老客业绩
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContentPlateformOrderDealInfoHospitalPerformanceDto>> GetTopTenOldCustomerPerformance()
        {
            var performanceList = (from d in _dalHospitalInfo.GetAll()
                                   from h in dalContentPlatFormOrderDealInfo.GetAll().Where(c => c.IsDeal == true && c.LastDealHospitalId != null && c.IsOldCustomer == true)
                                   where d.Id == h.LastDealHospitalId
                                   group h by d.Name into g
                                   orderby g.Sum(item => item.Price) descending
                                   select new ContentPlateformOrderDealInfoHospitalPerformanceDto
                                   {
                                       HospitalName = g.Key,
                                       Performance = g.Sum(item => item.Price)
                                   });
            return performanceList.Skip(0).Take(10).ToList();
        }
        /// <summary>
        /// 新客上门人数占比
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContentPlateformOrderDealInfoHospitalPerformanceDto>> GetTopTenNewCustomerToHospitalPformance()
        {
            var performanceList = (from d in _dalHospitalInfo.GetAll()
                                   from h in dalContentPlatFormOrderDealInfo.GetAll().Where(c => c.LastDealHospitalId != null && c.IsOldCustomer == false&& c.IsToHospital==true)
                                   where d.Id == h.LastDealHospitalId
                                   group h by d.Name into g
                                   orderby g.Count() descending
                                   select new ContentPlateformOrderDealInfoHospitalPerformanceDto
                                   {
                                       HospitalName = g.Key,
                                       Performance = g.Count()
                                   });
            return performanceList.Skip(0).Take(10).ToList();

        }
        /// <summary>
        /// 新客成交人数占比
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContentPlateformOrderDealInfoHospitalPerformanceDto>> GetTopTenNewCustomerDealPerformance()
        {
            var performanceList = (from d in _dalHospitalInfo.GetAll()
                                   from h in dalContentPlatFormOrderDealInfo.GetAll().Where(c => c.LastDealHospitalId != null && c.IsOldCustomer == false)
                                   where d.Id == h.LastDealHospitalId
                                   group h by d.Name into g
                                   orderby g.Count() descending
                                   select new ContentPlateformOrderDealInfoHospitalPerformanceDto
                                   {
                                       HospitalName = g.Key,
                                       Performance = g.Count()
                                   });
            return performanceList.Skip(0).Take(10).ToList();
        }



        #endregion
        #region 全国城市top10运营数据

        /// <summary>
        /// 获取总业绩业绩前10的城市业绩数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContentPlateformOrderDealInfoCityPerformanceDto>> GetTopTenCityTotalPerformance()
        {
            var performanceList = from d in _dalHospitalInfo.GetAll()
                                   from h in dalContentPlatFormOrderDealInfo.GetAll().Where(c => c.IsDeal == true && c.LastDealHospitalId != null)
                                   where d.Id == h.LastDealHospitalId
                                   group h by d.CooperativeHospitalCity.Name into g
                                   orderby g.Sum(item => item.Price) descending
                                   select new ContentPlateformOrderDealInfoCityPerformanceDto
                                   {
                                       CityName = g.Key,
                                       Performance = g.Sum(item => item.Price)
                                   };
            return await performanceList.Skip(0).Take(10).ToListAsync();
        }
        /// <summary>
        /// 获取新客业绩前10的城市业绩数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContentPlateformOrderDealInfoCityPerformanceDto>> GetTopTenCityNewCustomerPerformance()
        {
            var performanceList = from d in _dalHospitalInfo.GetAll()
                                  from h in dalContentPlatFormOrderDealInfo.GetAll().Where(c => c.IsDeal == true && c.LastDealHospitalId != null&&c.IsOldCustomer==false)
                                  where d.Id == h.LastDealHospitalId
                                  group h by d.CooperativeHospitalCity.Name into g
                                  orderby g.Sum(item => item.Price) descending
                                  select new ContentPlateformOrderDealInfoCityPerformanceDto
                                  {
                                      CityName = g.Key,
                                      Performance = g.Sum(item => item.Price)
                                  };
            return await performanceList.Skip(0).Take(10).ToListAsync();
        }
        /// <summary>
        /// 获取老客业绩前10的城市业绩数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContentPlateformOrderDealInfoCityPerformanceDto>> GetTopTenCityOldCustomerPerformance()
        {
            var performanceList = from d in _dalHospitalInfo.GetAll()
                                  from h in dalContentPlatFormOrderDealInfo.GetAll().Where(c => c.IsDeal == true && c.LastDealHospitalId != null && c.IsOldCustomer == true)
                                  where d.Id == h.LastDealHospitalId
                                  group h by d.CooperativeHospitalCity.Name into g
                                  orderby g.Sum(item => item.Price) descending
                                  select new ContentPlateformOrderDealInfoCityPerformanceDto
                                  {
                                      CityName = g.Key,
                                      Performance = g.Sum(item => item.Price)
                                  };
            return await performanceList.Skip(0).Take(10).ToListAsync();
        }
        /// <summary>
        /// 获取新客上门前10的城市业绩数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContentPlateformOrderDealInfoCityPerformanceDto>> GetTopTenCityNewCustomerToHospitalPformance()
        {
            var performanceList = from d in _dalHospitalInfo.GetAll()
                                  from h in dalContentPlatFormOrderDealInfo.GetAll().Where(c => c.LastDealHospitalId != null && c.IsOldCustomer == false&&c.IsToHospital==true)
                                  where d.Id == h.LastDealHospitalId
                                  group h by d.CooperativeHospitalCity.Name into g
                                  orderby g.Count() descending
                                  select new ContentPlateformOrderDealInfoCityPerformanceDto
                                  {
                                      CityName = g.Key,
                                      Performance = g.Count()
                                  };
            return await performanceList.Skip(0).Take(10).ToListAsync();
        }
        /// <summary>
        /// 获取新客成交人数前10的城市业绩数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContentPlateformOrderDealInfoCityPerformanceDto>> GetTopTenCityNewCustomerDealPerformance()
        {
            var performanceList = from d in _dalHospitalInfo.GetAll()
                                  from h in dalContentPlatFormOrderDealInfo.GetAll().Where(c => c.LastDealHospitalId != null && c.IsOldCustomer == false && c.IsToHospital == true)
                                  where d.Id == h.LastDealHospitalId
                                  group h by d.CooperativeHospitalCity.Name into g
                                  orderby g.Count() descending
                                  select new ContentPlateformOrderDealInfoCityPerformanceDto
                                  {
                                      CityName = g.Key,
                                      Performance = g.Count()
                                  };
            return await performanceList.Skip(0).Take(10).ToListAsync();
        }
        #endregion
    }
}
