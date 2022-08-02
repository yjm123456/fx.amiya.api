using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.WxAppConfig;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class ContentPlatformOrderSendService : IContentPlatformOrderSendService
    {
        private IDalContentPlatformOrderSend _dalContentPlatformOrderSend;
        private IDalBindCustomerService _dalBindCustomerService;
        private IHospitalInfoService _hospitalInfoService;
        private IDalConfig _dalConfig;
        private IAmiyaEmployeeService _amiyaEmployeeService;
        private IWxAppConfigService _wxAppConfigService;
        private IDalHospitalCheckPhoneRecord _dalHospitalCheckPhoneRecord;
        public ContentPlatformOrderSendService(IDalContentPlatformOrderSend dalContentPlatformOrderSend,
            IHospitalInfoService hospitalInfoService,
            IDalBindCustomerService dalBindCustomerService,
            IAmiyaEmployeeService amiyaEmployeeService,
            IDalConfig dalConfig,
            IWxAppConfigService wxAppConfigService,
            IDalHospitalCheckPhoneRecord dalHospitalCheckPhoneRecord)
        {
            _dalContentPlatformOrderSend = dalContentPlatformOrderSend;
            _dalConfig = dalConfig;
            _dalBindCustomerService = dalBindCustomerService;
            _wxAppConfigService = wxAppConfigService;
            _dalHospitalCheckPhoneRecord = dalHospitalCheckPhoneRecord;
            _hospitalInfoService = hospitalInfoService;
            _amiyaEmployeeService = amiyaEmployeeService;
        }

        /// <summary>
        /// 根据订单号获取简易的派单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<List<ContentPlatformOrderSendOrderInfoDto>> GetSendOrderInfoByOrderId(string orderId)
        {
            var config = await GetCallCenterConfig();
            var orders = from d in _dalContentPlatformOrderSend.GetAll()
                         where d.ContentPlatformOrderId == orderId
                         select new ContentPlatformOrderSendOrderInfoDto
                         {
                             Id = d.Id,
                             ContentPlatFormOrderId = d.ContentPlatformOrderId,
                             HospitalId = d.HospitalId,
                             Sender = d.Sender,
                             SendDate = d.SendDate,
                             IsUnCertainDate = d.IsUncertainDate,
                             AppointmentDate = d.AppointmentDate,
                             Remark = d.Remark,
                         };
            return orders.ToList();
        }
        /// <summary>
        /// 根据订单号集合获取简易的派单信息
        /// </summary>
        /// <param name="orderIds"></param>
        /// <returns></returns>
        public async Task<List<ContentPlatformOrderSendOrderInfoDto>> GetSendOrderInfoByOrderId(List<string> orderIds)
        {
            var config = await GetCallCenterConfig();
            var orders = from d in _dalContentPlatformOrderSend.GetAll()
                         where orderIds.Contains(d.ContentPlatformOrderId)
                         select new ContentPlatformOrderSendOrderInfoDto
                         {
                             Id = d.Id,
                             ContentPlatFormOrderId = d.ContentPlatformOrderId,
                             HospitalId = d.HospitalId,
                             Sender = d.Sender,
                             SendDate = d.SendDate,
                             IsUnCertainDate = d.IsUncertainDate,
                             AppointmentDate = d.AppointmentDate,
                             Remark = d.Remark,
                         };
            return orders.ToList();
        }


        /// <summary>
        /// 根据编号获取简单的派单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ContentPlatFormSendOrderInfoSimpleDto> GetSimpleByIdAsync(int id)
        {
            var sendOrderInfo = await _dalContentPlatformOrderSend.GetAll()
                .Include(e => e.ContentPlatformOrder).SingleOrDefaultAsync(e => e.Id == id);
            if (sendOrderInfo == null)
                throw new Exception();
            ContentPlatFormSendOrderInfoSimpleDto sendOrderInfoDto = new ContentPlatFormSendOrderInfoSimpleDto();
            sendOrderInfoDto.Id = sendOrderInfo.Id;
            sendOrderInfoDto.HospitalId = sendOrderInfo.HospitalId;
            sendOrderInfoDto.IsUncertainDate = sendOrderInfo.IsUncertainDate;
            sendOrderInfoDto.AppointmentDate = sendOrderInfo.AppointmentDate;
            sendOrderInfoDto.Remark = sendOrderInfo.Remark;
            sendOrderInfoDto.SendBy = sendOrderInfo.Sender;
            return sendOrderInfoDto;
        }



        /// <summary>
        /// 获取今日派单列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<TodaySendOrderInfoDto>> GetTodaySendOrderAsync()
        {
            var q = from d in _dalContentPlatformOrderSend.GetAll()
                    select d;

            DateTime startrq = DateTime.Now.Date;
            DateTime endrq = DateTime.Now.Date.AddDays(1);

            q = from d in q
                where d.SendDate >= startrq.Date && d.SendDate < endrq.Date
                select d;
            var sendOrder = from d in q
                            select new TodaySendOrderInfoDto
                            {
                                OrderId = d.ContentPlatformOrderId,
                                SendHospitalId = d.HospitalId,
                                GoodsName = d.ContentPlatformOrder.AmiyaGoodsDemand.ProjectNname,
                                ActualPayment = ((d.ContentPlatformOrder.DealAmount.HasValue) ? d.ContentPlatformOrder.DealAmount.Value : 0) + ((d.ContentPlatformOrder.DepositAmount.HasValue) ? d.ContentPlatformOrder.DepositAmount.Value : 0),
                            };
            return sendOrder.ToList();
        }

        /// <summary>
        /// 派单
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddAsync(AddContentPlatFormSendOrderInfoDto addDto)
        {
            ContentPlatformOrderSend sendOrderInfo = new ContentPlatformOrderSend();
            sendOrderInfo.ContentPlatformOrderId = addDto.OrderId;
            sendOrderInfo.HospitalId = addDto.HospitalId;
            sendOrderInfo.Sender = addDto.SendBy;
            sendOrderInfo.SendDate = DateTime.Now;
            sendOrderInfo.IsUncertainDate = addDto.IsUncertainDate;
            sendOrderInfo.Remark = addDto.Remark;
            if (!addDto.IsUncertainDate)
            {
                sendOrderInfo.AppointmentDate = addDto.AppointmentDate;
            }
            await _dalContentPlatformOrderSend.AddAsync(sendOrderInfo, true);
        }

        /// <summary>
        /// 修改派单
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task UpdateOrderSend(UpdateContentPlatFormSendOrderInfoDto updateDto, int employeeId)
        {

            var sendOrderInfo = await _dalContentPlatformOrderSend.GetAll().Include(e => e.ContentPlatformOrder).SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            if (sendOrderInfo == null)
                throw new Exception("派单编号错误");

            if (sendOrderInfo.ContentPlatformOrder.OrderStatus == Convert.ToInt16(ContentPlateFormOrderStatus.OrderComplete))
                throw new Exception("该订单已交易完成，无法改派医院");
            if (sendOrderInfo.ContentPlatformOrder.OrderStatus == Convert.ToInt16(ContentPlateFormOrderStatus.WithoutCompleteOrder))
                throw new Exception("该订单医院已经处理完毕，无法改派医院");

            sendOrderInfo.HospitalId = updateDto.HospitalId;
            sendOrderInfo.Sender = employeeId;
            sendOrderInfo.SendDate = DateTime.Now;
            sendOrderInfo.IsUncertainDate = updateDto.IsUncertainDate;
            sendOrderInfo.Remark = updateDto.Remark;
            if (updateDto.IsUncertainDate == true)
            {
                sendOrderInfo.AppointmentDate = null;
            }
            else
            {
                sendOrderInfo.AppointmentDate = updateDto.AppointmentDate;
            }


            await _dalContentPlatformOrderSend.UpdateAsync(sendOrderInfo, true);
        }

        /// <summary>
        /// 根据医院编号获取派单列表 
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="keyword"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<ContentPlatFormOrderSendInfoDto>> GetListByHospitalIdAsync(int hospitalId, string keyword, DateTime? startDate, DateTime? endDate, bool? IsToHospital, DateTime? toHospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, int pageNum, int pageSize)
        {
            var q = from d in _dalContentPlatformOrderSend.GetAll()
                    where (d.HospitalId == hospitalId)
                     && (string.IsNullOrEmpty(keyword) || d.ContentPlatformOrder.Id.Contains(keyword) || d.ContentPlatformOrder.Phone.Contains(keyword) || d.ContentPlatformOrder.CustomerName.Contains(keyword))
                     && (!IsToHospital.HasValue || d.ContentPlatformOrder.IsToHospital == IsToHospital)
                     && (!toHospitalType.HasValue || d.ContentPlatformOrder.ToHospitalType == toHospitalType.Value)
                    select d;

            if (startDate != null && endDate != null)
            {
                DateTime startrq = ((DateTime)startDate);
                DateTime endrq = ((DateTime)endDate).AddDays(1);

                q = from d in q
                    where (d.SendDate >= startrq.Date && d.SendDate < endrq.Date)
                    select d;
            }
            if (toHospitalStartDate != null && toHospitalEndDate != null)
            {
                DateTime startrq = ((DateTime)toHospitalStartDate).Date;
                DateTime endrq = ((DateTime)toHospitalEndDate).Date.AddDays(1);
                q = from d in q
                    where (d.ContentPlatformOrder.ToHospitalDate >= startrq && d.ContentPlatformOrder.ToHospitalDate < endrq)
                    select d;
            }
            var config = await GetCallCenterConfig();
            var sendOrder = from d in q
                            join p in _dalHospitalCheckPhoneRecord.GetAll().Where(e => e.HospitalId == hospitalId && e.OrderPlatformType == (byte)CheckPhoneRecordOrderType.ContentPlatformOrder)
                            on d.ContentPlatformOrderId equals p.OrderId into pd
                            from p in pd.DefaultIfEmpty()
                            select new ContentPlatFormOrderSendInfoDto
                            {
                                Id = d.Id,
                                OrderId = d.ContentPlatformOrderId,
                                IsAcompanying = d.ContentPlatformOrder.IsAcompanying,
                                CustomerName = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.CustomerName : "****",
                                HospitalName = d.ContentPlatformOrder.HospitalInfo.Name,
                                SendDate = d.SendDate,
                                AppointmentDate = d.AppointmentDate.HasValue ? d.AppointmentDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "未确定时间",
                                IsUncertainDate = d.IsUncertainDate,
                                OrderStatus = d.ContentPlatformOrder.OrderStatus != 0 ? ServiceClass.GetContentPlateFormOrderStatusText((byte)d.ContentPlatformOrder.OrderStatus) : "",
                                GoodsName = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.AmiyaGoodsDemand.ProjectNname : "****",
                                ThumbPicUrl = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.AmiyaGoodsDemand.ThumbPictureUrl : "****",
                                Phone = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? (p != null ? d.ContentPlatformOrder.Phone : config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.ContentPlatformOrder.Phone) : d.ContentPlatformOrder.Phone) : ServiceClass.GetIncompletePhone(d.ContentPlatformOrder.Phone),
                                EncryptPhone = ServiceClass.Encrypt(d.ContentPlatformOrder.Phone, config.PhoneEncryptKey),
                                LiveAnchor = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.LiveAnchor.Name : "****",
                                DealPictureUrl = string.IsNullOrEmpty(d.ContentPlatformOrder.DealPictureUrl) ? "" : d.ContentPlatformOrder.DealPictureUrl,
                                RepeateOrderPictureUrl = string.IsNullOrEmpty(d.ContentPlatformOrder.RepeatOrderPictureUrl) ? "" : d.ContentPlatformOrder.RepeatOrderPictureUrl,
                                LateProjectStage = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? (string.IsNullOrEmpty(d.ContentPlatformOrder.LateProjectStage) ? "" : d.ContentPlatformOrder.LateProjectStage) : "****",
                                ConsultingContent = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.ConsultingContent : "****",
                                UnDealReason = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? (string.IsNullOrEmpty(d.ContentPlatformOrder.UnDealReason) ? "" : d.ContentPlatformOrder.UnDealReason) : "****",
                                DealAmount = d.ContentPlatformOrder.DealAmount.HasValue ? d.ContentPlatformOrder.DealAmount : 0.00M,
                                DepositAmount = d.ContentPlatformOrder.DepositAmount.HasValue ? d.ContentPlatformOrder.DepositAmount : 0.00M,
                                IsHospitalCheckPhone = p != null ? true : false,
                                OrderRemark = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? (string.IsNullOrEmpty(d.ContentPlatformOrder.Remark) ? "" : d.ContentPlatformOrder.Remark) : "****",
                                SendOrderRemark = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.Remark : "****",
                                HospitalRemark = d.HospitalRemark,
                                UnDealPictureUrl = d.ContentPlatformOrder.UnDealPictureUrl,
                                OrderSourceText = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? ServiceClass.GerContentPlatFormOrderSourceText(d.ContentPlatformOrder.OrderSource.Value) : "****",
                               
                                CheckState = d.ContentPlatformOrder.CheckState,
                                DealDate = d.ContentPlatformOrder.DealDate,
                                IsToHospital = d.ContentPlatformOrder.IsToHospital,
                                ToHospitalDate = d.ContentPlatformOrder.ToHospitalDate,
                                ToHospitalType = d.ContentPlatformOrder.ToHospitalType,
                                ToHospitalTypeText = ServiceClass.GerContentPlatFormOrderToHospitalTypeText(d.ContentPlatformOrder.ToHospitalType)
                            };
            FxPageInfo<ContentPlatFormOrderSendInfoDto> sendOrderPageInfo = new FxPageInfo<ContentPlatFormOrderSendInfoDto>();
            sendOrderPageInfo.TotalCount = await sendOrder.CountAsync();
            sendOrderPageInfo.List = await sendOrder.OrderByDescending(e => e.SendDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return sendOrderPageInfo;
        }



        /// <summary>
        /// 根据医院编号获取未处理内容平台派单条数
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="keyword"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<int> GetCountByHospitalIdAsync(int hospitalId)
        {
            var q = from d in _dalContentPlatformOrderSend.GetAll()
                    where d.HospitalId == hospitalId
                    && d.ContentPlatformOrder.OrderStatus == (int)ContentPlateFormOrderStatus.SendOrder
                    select d;
            return await q.CountAsync();
        }


        /// <summary>
        /// 获取各个医院的订单量
        /// </summary>
        /// <returns></returns>
        public async Task<List<TodayHospitalOrderNumDto>> GetTodayHospitalOrderNumAsync()
        {
            var q = from d in _dalContentPlatformOrderSend.GetAll()
                    select d;

            DateTime startrq = DateTime.Now.Date;
            DateTime endrq = DateTime.Now.Date.AddDays(1);

            q = from d in q
                where (d.SendDate >= startrq.Date && d.SendDate < endrq.Date)
                select d;
            var config = await GetCallCenterConfig();
            var sendOrder = from d in q
                            select new TodaySendOrderInfoDto
                            {
                                OrderId = d.ContentPlatformOrderId,
                                SendHospitalId = d.HospitalId,
                            };
            var result = sendOrder.ToList().GroupBy(x => x.SendHospitalId).Select(x => new TodayHospitalOrderNumDto { HospitalName = _hospitalInfoService.GetBaseByIdAsync(Convert.ToInt16(x.Key)).Result.Name, OrderNum = x.ToList().Count }).ToList();
            return result.OrderByDescending(x => x.OrderNum).ToList();
        }




        /// <summary>
        /// 修改医院备注
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateOrderHospitalRemarkAsync(ContentPlatFormOrderRemarkDto input)
        {

            var sendOrderInfo = await _dalContentPlatformOrderSend.GetAll().Include(e => e.ContentPlatformOrder).SingleOrDefaultAsync(e => e.Id == input.SendOrderId);
            if (sendOrderInfo == null)
                throw new Exception("派单编号错误");

            if (sendOrderInfo.ContentPlatformOrder.OrderStatus == Convert.ToInt16(ContentPlateFormOrderStatus.OrderComplete))
                throw new Exception("该订单已交易完成，无法改派医院");
            if (sendOrderInfo.ContentPlatformOrder.OrderStatus == Convert.ToInt16(ContentPlateFormOrderStatus.WithoutCompleteOrder))
                throw new Exception("该订单医院已经处理完毕，无法改派医院");

            sendOrderInfo.HospitalRemark = input.HospitalRemark;
            await _dalContentPlatformOrderSend.UpdateAsync(sendOrderInfo, true);
        }

        /// <summary>
        /// 获取内容平台订单已派单信息列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="employeeId"></param>
        /// <param name="liveAnchorId">归属主播ID</param>
        /// <param name="orderStatus"></param>
        /// <param name="contentPlatFormId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="toHospitalStartDate">到院时间起</param>
        /// <param name="toHospitalEndDate">到院时间止</param>        
        /// <param name="toHospitalType">到院类型</param>        
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<SendContentPlatformOrderDto>> GetSendOrderList(int? liveAnchorId, int? consultationEmpId, int? sendBy,bool? isAcompanying,bool? isOldCustomer,decimal? commissionRatio, string keyword, int? belongMonth, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, int employeeId, int? orderStatus, string contentPlatFormId, DateTime? startDate, DateTime? endDate, int? hospitalId, bool? IsToHospital, DateTime? toHospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, int orderSource, int pageNum, int pageSize)
        {
            var orders = _dalContentPlatformOrderSend.GetAll()
                       .Where(e => string.IsNullOrWhiteSpace(keyword) || e.ContentPlatformOrderId == keyword || e.ContentPlatformOrder.Phone.Contains(keyword) || e.ContentPlatformOrder.LiveAnchorWeChatNo.Contains(keyword))
                       .Where(e => hospitalId == 0 || e.HospitalId == hospitalId)
                       .Where(e => employeeId == -1 || e.ContentPlatformOrder.BelongEmpId == employeeId)
                       .Where(e => orderSource == -1 || e.ContentPlatformOrder.OrderSource == orderSource)
                       .Where(e => !IsToHospital.HasValue || e.ContentPlatformOrder.IsToHospital == IsToHospital.Value)
                       .Where(e => !belongMonth.HasValue || e.ContentPlatformOrder.BelongMonth == belongMonth.Value)
                       .Where(e => !minAddOrderPrice.HasValue || e.ContentPlatformOrder.AddOrderPrice >= minAddOrderPrice.Value)
                       .Where(e => !maxAddOrderPrice.HasValue || e.ContentPlatformOrder.AddOrderPrice <= maxAddOrderPrice.Value)
                       .Where(e => !sendBy.HasValue || e.Sender == sendBy.Value)
                       .Where(e => !isAcompanying.HasValue || e.ContentPlatformOrder.IsAcompanying == isAcompanying.Value)
                       .Where(e => !isOldCustomer.HasValue || e.ContentPlatformOrder.IsOldCustomer == isOldCustomer.Value)
                       .Where(e => !commissionRatio.HasValue || e.ContentPlatformOrder.CommissionRatio == commissionRatio.Value)
                       .Where(e => !toHospitalType.HasValue || e.ContentPlatformOrder.ToHospitalType == toHospitalType.Value)
                       .Where(e => !consultationEmpId.HasValue || e.ContentPlatformOrder.ConsultationEmpId == consultationEmpId.Value)
                       .Where(e => !liveAnchorId.HasValue || e.ContentPlatformOrder.LiveAnchorId == liveAnchorId.Value)
                       .Where(e => orderStatus == null || e.ContentPlatformOrder.OrderStatus == orderStatus)
                       .Where(e => string.IsNullOrWhiteSpace(contentPlatFormId) || e.ContentPlatformOrder.ContentPlateformId == contentPlatFormId);
            if (startDate != null && endDate != null)
            {
                DateTime startrq = ((DateTime)startDate).Date;
                DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
                orders = from d in orders
                         where (d.SendDate >= startrq && d.SendDate < endrq)
                         select d;
            }
            if (toHospitalStartDate != null && toHospitalEndDate != null)
            {
                DateTime startrq = ((DateTime)toHospitalStartDate).Date;
                DateTime endrq = ((DateTime)toHospitalEndDate).Date.AddDays(1);
                orders = from d in orders
                         where (d.ContentPlatformOrder.ToHospitalDate >= startrq && d.ContentPlatformOrder.ToHospitalDate < endrq)
                         select d;
            }
            var orderCount = await orders.CountAsync();
            var config = await _wxAppConfigService.GetWxAppCallCenterConfigAsync();
            var contentPlatformOrders = from d in orders
                                        join p in _dalHospitalCheckPhoneRecord.GetAll() on d.ContentPlatformOrderId equals p.OrderId into pd
                                        from p in pd.DefaultIfEmpty()
                                        select new SendContentPlatformOrderDto
                                        {
                                            Id = d.Id,
                                            OrderId = d.ContentPlatformOrderId,
                                            ContentPlatFormName = d.ContentPlatformOrder.Contentplatform.ContentPlatformName,
                                            LiveAnchorName = d.ContentPlatformOrder.LiveAnchor.HostAccountName,
                                            LiveAnchorWeChatNo = d.ContentPlatformOrder.LiveAnchorWeChatNo,
                                            IsOldCustomer = d.ContentPlatformOrder.IsOldCustomer == true ? "老客业绩" : "新客业绩",
                                            IsAcompanying = d.ContentPlatformOrder.IsAcompanying,
                                            CommissionRatio = d.ContentPlatformOrder.CommissionRatio,
                                            CustomerName = d.ContentPlatformOrder.CustomerName,
                                            Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(d.ContentPlatformOrder.Phone) : d.ContentPlatformOrder.Phone,
                                            EncryptPhone = ServiceClass.Encrypt(d.ContentPlatformOrder.Phone, config.PhoneEncryptKey),
                                            IsHospitalCheckPhone = p.HospitalId == d.HospitalId && p.OrderPlatformType == (byte)CheckPhoneRecordOrderType.ContentPlatformOrder,
                                            AppointmentHospital = d.ContentPlatformOrder.HospitalInfo.Name,
                                            SendHospitalId = d.HospitalId,
                                            AppointmentDate = d.AppointmentDate.HasValue ? d.AppointmentDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "未确认时间",
                                            GoodsName = d.ContentPlatformOrder.AmiyaGoodsDemand.ProjectNname,
                                            ThumbPictureUrl = d.ContentPlatformOrder.AmiyaGoodsDemand.ThumbPictureUrl,
                                            LateProjectStage = d.ContentPlatformOrder.LateProjectStage,
                                            ConsultingContent = d.ContentPlatformOrder.ConsultingContent,
                                            OrderTypeText = ServiceClass.GetContentPlateFormOrderTypeText((byte)d.ContentPlatformOrder.OrderType),
                                            OrderStatusText = ServiceClass.GetContentPlateFormOrderStatusText((byte)d.ContentPlatformOrder.OrderStatus),
                                            DepositAmount = d.ContentPlatformOrder.DepositAmount,
                                            DealAmount = d.ContentPlatformOrder.DealAmount,
                                            DealPictureUrl = d.ContentPlatformOrder.DealPictureUrl,
                                            IsToHospital = d.ContentPlatformOrder.IsToHospital,
                                            ToHospitalTypeText = ServiceClass.GerContentPlatFormOrderToHospitalTypeText(d.ContentPlatformOrder.ToHospitalType),
                                            UnDealReason = d.ContentPlatformOrder.UnDealReason,
                                            ConsultationType=d.ContentPlatformOrder.ConsultationType,
                                            ConsultationTypeText=ServiceClass.GetContentPlateFormOrderConsultationTypeText(d.ContentPlatformOrder.ConsultationType),
                                            Sender = d.Sender,
                                            SenderName = d.AmiyaEmployee.Name,
                                            CheckState = d.ContentPlatformOrder.CheckState,
                                            SendDate = d.SendDate,
                                            ToHospitalDate = d.ContentPlatformOrder.ToHospitalDate,
                                            SendOrderRemark = d.Remark,
                                            DealDate = d.ContentPlatformOrder.DealDate,
                                            OrderRemark = d.ContentPlatformOrder.Remark,
                                            HospitalRemark = d.HospitalRemark,
                                            UnDealPictureUrl = d.ContentPlatformOrder.UnDealPictureUrl,
                                            OtherContentPlatFormOrderId = d.ContentPlatformOrder.OtherContentPlatFormOrderId,
                                            OrderSourceText = ServiceClass.GerContentPlatFormOrderSourceText(d.ContentPlatformOrder.OrderSource.Value),
                                            AcceptConsulting = d.ContentPlatformOrder.AcceptConsulting
                                        };

            FxPageInfo<SendContentPlatformOrderDto> pageInfo = new FxPageInfo<SendContentPlatformOrderDto>();
            pageInfo.TotalCount = await contentPlatformOrders.CountAsync();
            pageInfo.List = await contentPlatformOrders.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            foreach (var x in pageInfo.List)
            {
                x.SendHospital = _hospitalInfoService.GetByIdAsync(x.SendHospitalId).Result.Name;
            }
            return pageInfo;
        }


        /// <summary>
        /// 内容平台已派单报表
        /// </summary>
        /// <param name="liveAnchorId"></param>
        /// <param name="employeeId"></param>
        /// <param name="belongEmpId"></param>
        /// <param name="orderStatus"></param>
        /// <param name="contentPlatFormId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="isHidePhone"></param>
        /// <param name="IsToHospital">是否到院， 空查询全部</param>
        /// <param name="toHospitalType">到院类型，为空查询所有</param>
        /// <param name="toHospitalStartDate">到院时间起</param>
        /// <param name="toHospitalEndDate">到院时间止</param>        
        /// <returns></returns>
        public async Task<List<SendContentPlatformOrderDto>> GetSendOrderReportList(int? liveAnchorId, int? belongMonth, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, int? hospitalId, int employeeId, int belongEmpId, int? orderStatus, bool? isAcompanying, bool? isOldCustomer, decimal? commissionRatio, string contentPlatFormId, bool? IsToHospital, DateTime? toHospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, DateTime? startDate, DateTime? endDate, bool isHidePhone)
        {
            var orders = _dalContentPlatformOrderSend.GetAll()
                       .Where(e => employeeId == -1 || e.Sender == employeeId)
                       .Where(e => belongEmpId == -1 || e.ContentPlatformOrder.BelongEmpId == belongEmpId)
                       .Where(e => !liveAnchorId.HasValue || e.ContentPlatformOrder.LiveAnchorId == liveAnchorId.Value)
                       .Where(e => !IsToHospital.HasValue|| e.ContentPlatformOrder.IsToHospital == IsToHospital.Value)
                       .Where(e => !isAcompanying.HasValue || e.ContentPlatformOrder.IsAcompanying == isAcompanying.Value)
                       .Where(e => !isOldCustomer.HasValue || e.ContentPlatformOrder.IsOldCustomer == isOldCustomer.Value)
                       .Where(e => !commissionRatio.HasValue || e.ContentPlatformOrder.CommissionRatio == commissionRatio.Value)
                       .Where(e => !toHospitalType.HasValue || e.ContentPlatformOrder.ToHospitalType == toHospitalType.Value)
                       .Where(e => !belongMonth.HasValue || e.ContentPlatformOrder.BelongMonth == belongMonth.Value)
                       .Where(e => !minAddOrderPrice.HasValue || e.ContentPlatformOrder.AddOrderPrice >= minAddOrderPrice.Value)
                       .Where(e => !maxAddOrderPrice.HasValue || e.ContentPlatformOrder.AddOrderPrice <= maxAddOrderPrice.Value)
                       .Where(e => !hospitalId.HasValue || e.HospitalId == hospitalId.Value)
                       .Where(e => orderStatus == null || e.ContentPlatformOrder.OrderStatus == orderStatus)
                       .Where(e => string.IsNullOrWhiteSpace(contentPlatFormId) || e.ContentPlatformOrder.ContentPlateformId == contentPlatFormId);
            if (startDate != null && endDate != null)
            {
                DateTime startrq = ((DateTime)startDate).Date;
                DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
                orders = from d in orders
                         where (d.SendDate >= startrq && d.SendDate < endrq)
                         select d;
            }
            if (toHospitalStartDate != null && toHospitalEndDate != null)
            {
                DateTime startrq = ((DateTime)toHospitalStartDate).Date;
                DateTime endrq = ((DateTime)toHospitalEndDate).Date.AddDays(1);
                orders = from d in orders
                         where (d.ContentPlatformOrder.ToHospitalDate >= startrq && d.ContentPlatformOrder.ToHospitalDate < endrq)
                         select d;
            }
            var contentPlatformOrders = from d in orders
                                        select new SendContentPlatformOrderDto
                                        {
                                            OrderId = d.ContentPlatformOrderId,
                                            ContentPlatFormName = d.ContentPlatformOrder.Contentplatform.ContentPlatformName,
                                            LiveAnchorName = d.ContentPlatformOrder.LiveAnchor.HostAccountName,
                                            LiveAnchorWeChatNo = d.ContentPlatformOrder.LiveAnchorWeChatNo,
                                            IsOldCustomer = d.ContentPlatformOrder.IsOldCustomer == true ? "老客业绩" : "新客业绩",
                                            ConsultationTypeText=ServiceClass.GetContentPlateFormOrderConsultationTypeText(d.ContentPlatformOrder.ConsultationType),
                                            IsAcompanying = d.ContentPlatformOrder.IsAcompanying,
                                            CommissionRatio = d.ContentPlatformOrder.CommissionRatio,
                                            CustomerName = d.ContentPlatformOrder.CustomerName,
                                            Phone = isHidePhone == true ? ServiceClass.GetIncompletePhone(d.ContentPlatformOrder.Phone) : d.ContentPlatformOrder.Phone,
                                            SendHospitalId = d.HospitalId,
                                            GoodsName = d.ContentPlatformOrder.AmiyaGoodsDemand.ProjectNname,
                                            OrderStatusText = ServiceClass.GetContentPlateFormOrderStatusText((byte)d.ContentPlatformOrder.OrderStatus),
                                            DepositAmount = d.ContentPlatformOrder.DepositAmount,
                                            DealAmount = d.ContentPlatformOrder.DealAmount,
                                            SenderName = d.AmiyaEmployee.Name,
                                            SendDate = d.SendDate,
                                            IsToHospital = d.ContentPlatformOrder.IsToHospital,
                                            ToHospitalTypeText = ServiceClass.GerContentPlatFormOrderToHospitalTypeText(d.ContentPlatformOrder.ToHospitalType),
                                            ToHospitalDate = d.ContentPlatformOrder.ToHospitalDate,
                                            SendOrderRemark = d.Remark,
                                            OtherContentPlatFormOrderId = d.ContentPlatformOrder.OtherContentPlatFormOrderId,

                                        };

            List<SendContentPlatformOrderDto> pageInfo = new List<SendContentPlatformOrderDto>();
            pageInfo = await contentPlatformOrders.ToListAsync();
            foreach (var x in pageInfo)
            {
                x.SendHospital = _hospitalInfoService.GetByIdAsync(x.SendHospitalId).Result.Name;
            }
            return pageInfo;
        }


        #region 报表相关
        /// <summary>
        /// 获医院订单报表
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="hospitalId">医院id</param>
        /// <param name="hospitalName">医院名称</param>
        /// <returns></returns>
        public async Task<List<SendContentPlatFormOrderReportDto>> GetContentPlatFormHospitalOrderReportAsync(DateTime? startDate, DateTime? endDate, int hospitalId, bool isHidePhone)
        {

            var q = from d in _dalContentPlatformOrderSend.GetAll()
                    where d.HospitalId == hospitalId
                    select d;

            if (startDate != null && endDate != null)
            {
                DateTime startrq = (DateTime)startDate;
                DateTime endrq = ((DateTime)endDate).Date.AddDays(1);

                q = from d in q
                    where (d.SendDate >= startrq && d.SendDate < endrq)
                    select d;
            }

            var sendOrder = from d in q
                            select new SendContentPlatFormOrderReportDto
                            {
                                OrderId = d.ContentPlatformOrderId,
                                SendDate = d.SendDate,
                                EncryptPhone = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? (isHidePhone == true ? ServiceClass.GetIncompletePhone(d.ContentPlatformOrder.Phone) : d.ContentPlatformOrder.Phone) : ServiceClass.GetIncompletePhone(d.ContentPlatformOrder.Phone),
                                CustomerName = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.CustomerName : "****",
                                GoodsName = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.AmiyaGoodsDemand.ProjectNname : "****",
                                SendHospitalId = d.HospitalId,
                                ConsultingContent = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.ConsultingContent : "****",
                                AppointmentDate = d.IsUncertainDate == false ? d.AppointmentDate.Value.ToString("yyyy-MM-dd") : "未明确时间",
                                OrderStatusText = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? ServiceClass.GetContentPlateFormOrderStatusText((byte)d.ContentPlatformOrder.OrderStatus) : "****",
                                DepositAmount = d.ContentPlatformOrder.DepositAmount,
                                DealAmount = d.ContentPlatformOrder.DealAmount,
                                UnDealReason = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.UnDealReason : "****",
                                LateProjectStage = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.LateProjectStage : "****",
                                OrderRemark = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.Remark : "****",
                                SendOrderRemark = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.Remark : "****",
                                SenderName = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.AmiyaEmployee.Name : "****",
                                HospitalRemark = d.HospitalRemark,
                                OrderSourceText = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? ServiceClass.GerContentPlatFormOrderSourceText(d.ContentPlatformOrder.OrderSource.Value) : "****"
                            };

            var result = sendOrder.ToList();
            foreach (var x in result)
            {
                x.SendHospital = _hospitalInfoService.GetByIdAsync(x.SendHospitalId).Result.Name;
            }
            return result.OrderByDescending(z => z.SendHospital).ThenByDescending(z => z.SendDate).ToList();
        }
        #endregion

        /// <summary>
        /// 获取时间段内已派单数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<OrderOperationConditionDto>> GetOrderSendDataAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
            var orders = from d in _dalContentPlatformOrderSend.GetAll()
                         where d.SendDate >= startrq && d.SendDate < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.SendDate.Date).Select(x => new OrderOperationConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderNum = x.ToList().Count }).ToList();
        }

        private async Task<CallCenterConfigDto> GetCallCenterConfig()
        {
            var config = await _dalConfig.GetAll().SingleOrDefaultAsync();
            return JsonConvert.DeserializeObject<WxAppConfigDto>(config.ConfigJson).CallCenterConfig;
        }

    }
}
