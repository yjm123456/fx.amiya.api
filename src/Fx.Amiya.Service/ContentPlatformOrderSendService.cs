using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.AmiyaOperationsBoardService.Input;
using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.HospitalBoard;
using Fx.Amiya.Dto.OrderRemark;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.SendOrderInfo;
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
        private ICustomerBaseInfoService customerBaseInfoService;
        private IHospitalInfoService _hospitalInfoService;
        //private AmiyaHospitalDepartmentService amiyaDepartmentService;
        private IDalConfig _dalConfig;
        private ILiveAnchorWeChatInfoService liveAnchorWeChatInfoService;
        private IOrderRemarkService orderRemarkService;
        private IAmiyaEmployeeService _amiyaEmployeeService;
        private IWxAppConfigService _wxAppConfigService;
        private IDalHospitalCheckPhoneRecord _dalHospitalCheckPhoneRecord;
        private IDalHospitalInfo _dalHospitalInfo;
        private IDalContentPlatFormOrderDealInfo dalContentPlatFormOrderDealInfo;
        private IHospitalEmployeeService hospitalEmployeeService;
        public ContentPlatformOrderSendService(IDalContentPlatformOrderSend dalContentPlatformOrderSend,
            IHospitalInfoService hospitalInfoService,
            IDalBindCustomerService dalBindCustomerService,
            //AmiyaHospitalDepartmentService departmentService,
            IOrderRemarkService orderRemarkService,
           ILiveAnchorWeChatInfoService liveAnchorWeChatInfoService,
            ICustomerBaseInfoService customerBaseInfoService,
            IHospitalEmployeeService hospitalEmployeeService,
            IAmiyaEmployeeService amiyaEmployeeService,
            IDalConfig dalConfig,
            IWxAppConfigService wxAppConfigService,
            IDalHospitalCheckPhoneRecord dalHospitalCheckPhoneRecord, IDalHospitalInfo dalHospitalInfo, IDalContentPlatFormOrderDealInfo dalContentPlatFormOrderDealInfo)
        {
            _dalContentPlatformOrderSend = dalContentPlatformOrderSend;
            _dalConfig = dalConfig;
            _dalBindCustomerService = dalBindCustomerService;
            this.customerBaseInfoService = customerBaseInfoService;
            this.hospitalEmployeeService = hospitalEmployeeService;
            //this.amiyaDepartmentService = departmentService;
            this.liveAnchorWeChatInfoService = liveAnchorWeChatInfoService;
            _wxAppConfigService = wxAppConfigService;
            _dalHospitalCheckPhoneRecord = dalHospitalCheckPhoneRecord;
            _hospitalInfoService = hospitalInfoService;
            _amiyaEmployeeService = amiyaEmployeeService;
            this.orderRemarkService = orderRemarkService;
            _dalHospitalInfo = dalHospitalInfo;
            this.dalContentPlatFormOrderDealInfo = dalContentPlatFormOrderDealInfo;
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
                             IsSpecifyHospitalEmployee = d.IsSpecifyHospitalEmployee,
                             HospitalEmployeeId = d.HospitalEmployeeId,
                         };
            return orders.ToList();
        }

        /// <summary>
        /// 根据id获取派单参数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<ContentPlatformOrderSendOrderInfoDto> GetByIdAsync(int id)
        {
            try
            {
                var orderSend = await _dalContentPlatformOrderSend.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (orderSend == null)
                {
                    return new ContentPlatformOrderSendOrderInfoDto();
                }

                ContentPlatformOrderSendOrderInfoDto SendOrderDto = new ContentPlatformOrderSendOrderInfoDto();
                SendOrderDto.Id = orderSend.Id;
                SendOrderDto.ContentPlatFormOrderId = orderSend.ContentPlatformOrderId;
                SendOrderDto.HospitalId = orderSend.HospitalId;
                SendOrderDto.Sender = orderSend.Sender;
                SendOrderDto.SendDate = orderSend.SendDate;
                SendOrderDto.IsUnCertainDate = orderSend.IsUncertainDate;
                SendOrderDto.AppointmentDate = orderSend.AppointmentDate;
                SendOrderDto.Remark = orderSend.Remark;
                SendOrderDto.IsSpecifyHospitalEmployee = orderSend.IsSpecifyHospitalEmployee;
                SendOrderDto.HospitalEmployeeId = orderSend.HospitalEmployeeId;

                return SendOrderDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
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
                .Include(e => e.ContentPlatformOrder).ThenInclude(e => e.ContentPlatformOrderDealInfoList).SingleOrDefaultAsync(e => e.Id == id);
            if (sendOrderInfo == null)
                throw new Exception();
            ContentPlatFormSendOrderInfoSimpleDto sendOrderInfoDto = new ContentPlatFormSendOrderInfoSimpleDto();
            sendOrderInfoDto.Id = sendOrderInfo.Id;
            sendOrderInfoDto.HospitalId = sendOrderInfo.HospitalId;
            sendOrderInfoDto.IsUncertainDate = sendOrderInfo.IsUncertainDate;
            sendOrderInfoDto.AppointmentDate = sendOrderInfo.AppointmentDate;
            sendOrderInfoDto.Remark = sendOrderInfo.Remark;
            sendOrderInfoDto.SendBy = sendOrderInfo.Sender;
            sendOrderInfoDto.IsMainHospital = sendOrderInfo.IsMainHospital;
            sendOrderInfoDto.IsSpecifyHospitalEmployee = sendOrderInfo.IsSpecifyHospitalEmployee;
            sendOrderInfoDto.HospitalEmployeeId = sendOrderInfo.HospitalEmployeeId;
            sendOrderInfoDto.OtherHospitalId = new List<int>();
            if (sendOrderInfo.IsMainHospital)
            {
                sendOrderInfoDto.OtherHospitalId = _dalContentPlatformOrderSend.GetAll().Where(e => e.ContentPlatformOrderId == sendOrderInfo.ContentPlatformOrderId && e.IsMainHospital == false).Select(e => e.HospitalId).ToList();
            }
            sendOrderInfoDto.IsThenTime = sendOrderInfo.ContentPlatformOrder.DealDate.HasValue ? (DateTime.Now > sendOrderInfo.ContentPlatformOrder.DealDate.Value.AddDays(180) ? false : true) : false;
            sendOrderInfoDto.HasDealInfo = sendOrderInfo.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Count() > 0;
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

        ///// <summary>
        ///// 派单
        ///// </summary>
        ///// <param name="addDto"></param>
        ///// <returns></returns>
        //public async Task AddAsync(AddContentPlatFormSendOrderInfoDto addDto)
        //{
        //    ContentPlatformOrderSend sendOrderInfo = new ContentPlatformOrderSend();
        //    sendOrderInfo.ContentPlatformOrderId = addDto.OrderId;
        //    sendOrderInfo.HospitalId = addDto.HospitalId;
        //    sendOrderInfo.Sender = addDto.SendBy;
        //    sendOrderInfo.SendDate = DateTime.Now;
        //    sendOrderInfo.IsUncertainDate = addDto.IsUncertainDate;
        //    sendOrderInfo.Remark = addDto.Remark;
        //    if (!addDto.IsUncertainDate)
        //    {
        //        sendOrderInfo.AppointmentDate = addDto.AppointmentDate;
        //    }
        //    await _dalContentPlatformOrderSend.AddAsync(sendOrderInfo, true);
        //}
        /// <summary>
        /// 派单(多派)
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddMultiAsync(AddContentPlatFormSendOrderInfoDto addDto, bool isMain)
        {
            ContentPlatformOrderSend sendOrderInfo = new ContentPlatformOrderSend();
            sendOrderInfo.ContentPlatformOrderId = addDto.OrderId;
            sendOrderInfo.HospitalId = addDto.HospitalId;
            sendOrderInfo.Sender = addDto.SendBy;
            sendOrderInfo.SendDate = DateTime.Now;
            sendOrderInfo.IsUncertainDate = addDto.IsUncertainDate;
            sendOrderInfo.Remark = addDto.Remark;
            if (isMain)
            {
                sendOrderInfo.IsMainHospital = true;
                sendOrderInfo.IsSpecifyHospitalEmployee = addDto.IsSpecifyHospitalEmployee;
                sendOrderInfo.HospitalEmployeeId = addDto.HospitalEmployeeId;
            }
            else
            {
                sendOrderInfo.IsMainHospital = false;
            }
            if (!addDto.IsUncertainDate)
            {
                sendOrderInfo.AppointmentDate = addDto.AppointmentDate;
            }
            sendOrderInfo.OrderStatus = (int)ContentPlateFormOrderStatus.SendOrder;
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
        /// 修改派单(朗姿）
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task UpdateByLangZiAsync(UpdateContentPlatFormOrderSendByLangZiDto updateDto)
        {
            var sendOrderInfo = await _dalContentPlatformOrderSend.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
            if (sendOrderInfo == null)
                throw new Exception("派单编号错误");

            sendOrderInfo.HospitalRemark = updateDto.HospitalRemark;
            sendOrderInfo.IsRepeatProfundityOrder = updateDto.IsRepeatProfundityOrder;
            sendOrderInfo.OrderStatus = updateDto.OrderStatus;
            await _dalContentPlatformOrderSend.UpdateAsync(sendOrderInfo, true);
        }

        /// <summary>
        /// 新的修改派单(更新派单数据)
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task NewUpdateOrderSend(UpdateContentPlatFormSendOrderInfoDto updateDto, int employeeId)
        {
            var sendOrderInfo = await _dalContentPlatformOrderSend.GetAll().Include(e => e.ContentPlatformOrder).SingleOrDefaultAsync(e => e.Id == updateDto.Id);
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
        public async Task<FxPageInfo<ContentPlatFormOrderSendInfoDto>> GetListByHospitalIdAsync(int hospitalId, string keyword, int? OrderStatus, DateTime? startDate, DateTime? endDate, bool? IsToHospital, DateTime? toHospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, bool isSpecifyHospitalEmployee, int hospitalEmpId, int pageNum, int pageSize)
        {
            var q = from d in _dalContentPlatformOrderSend.GetAll().Include(x => x.ContentPlatformOrder)
                    where (d.HospitalId == hospitalId && d.IsSpecifyHospitalEmployee == isSpecifyHospitalEmployee)
                     && (string.IsNullOrEmpty(keyword) || d.ContentPlatformOrder.Id.Contains(keyword) || d.ContentPlatformOrder.Phone.Contains(keyword) || d.ContentPlatformOrder.CustomerName.Contains(keyword))
                       //&& (!IsToHospital.HasValue || d.ContentPlatformOrder.IsToHospital == IsToHospital)
                       //&& (!toHospitalType.HasValue || d.ContentPlatformOrder.ToHospitalType == toHospitalType.Value)
                       && (!OrderStatus.HasValue || d.OrderStatus == OrderStatus.Value)
                    select d;
            if (IsToHospital.HasValue)
            {
                q = q.Where(e => e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(c => c.LastDealHospitalId == e.HospitalId).OrderByDescending(e => e.CreateDate).Skip(0).Take(1).Any(e => e.IsToHospital == IsToHospital));
            }
            if (toHospitalType.HasValue)
            {
                q = q.Where(e => e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(c => c.LastDealHospitalId == e.HospitalId).OrderByDescending(e => e.CreateDate).Skip(0).Take(1).Any(e => e.ToHospitalType == toHospitalType));
            }
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
                q = q.Where(e => e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(c => c.LastDealHospitalId == e.HospitalId).OrderByDescending(e => e.CreateDate).Skip(0).Take(1).Any(e => e.ToHospitalDate >= startrq && e.ToHospitalDate < endrq));
                //q = from d in q
                //    where (d.ContentPlatformOrder.ToHospitalDate >= startrq && d.ContentPlatformOrder.ToHospitalDate < endrq)
                //    select d;
            }
            if (isSpecifyHospitalEmployee == true)
            {
                q = q.Where(e => e.HospitalEmployeeId == hospitalEmpId);
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
                                OrderStatusIntType = d.OrderStatus,
                                IsAcompanying = d.ContentPlatformOrder.IsAcompanying,
                                CustomerName = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.CustomerName : "****",
                                HospitalName = d.ContentPlatformOrder.HospitalInfo.Name,
                                SendDate = d.SendDate,
                                SendBy = d.AmiyaEmployee.Name,
                                AppointmentDate = d.AppointmentDate.HasValue ? d.AppointmentDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "未确定时间",
                                IsUncertainDate = d.IsUncertainDate,
                                OrderStatus = d.OrderStatus != 0 ? ServiceClass.GetContentPlateFormOrderStatusText((byte)d.OrderStatus) : "",
                                DepartmentId = d.ContentPlatformOrder.AmiyaGoodsDemand.HospitalDepartmentId,
                                GoodsName = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.AmiyaGoodsDemand.ProjectNname : "****",
                                ThumbPicUrl = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.AmiyaGoodsDemand.ThumbPictureUrl : "****",
                                Phone = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? (p != null ? d.ContentPlatformOrder.Phone : config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.ContentPlatformOrder.Phone) : d.ContentPlatformOrder.Phone) : ServiceClass.GetIncompletePhone(d.ContentPlatformOrder.Phone),
                                EncryptPhone = ServiceClass.Encrypt(d.ContentPlatformOrder.Phone, config.PhoneEncryptKey),
                                LiveAnchor = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.LiveAnchor.Name : "****",
                                DealPictureUrl = string.IsNullOrEmpty(d.ContentPlatformOrder.DealPictureUrl) ? "" : d.ContentPlatformOrder.DealPictureUrl,
                                RepeateOrderPictureUrl = string.IsNullOrEmpty(d.ContentPlatformOrder.RepeatOrderPictureUrl) ? "" : d.ContentPlatformOrder.RepeatOrderPictureUrl,
                                LateProjectStage = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? (string.IsNullOrEmpty(d.ContentPlatformOrder.LateProjectStage) ? "" : d.ContentPlatformOrder.LateProjectStage) : "****",
                                ConsultingContent = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? (d.IsMainHospital ? d.ContentPlatformOrder.ConsultingContent : d.ContentPlatformOrder.ConsultingContent2) : "****",
                                UnDealReason = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? (string.IsNullOrEmpty(d.ContentPlatformOrder.UnDealReason) ? "" : d.ContentPlatformOrder.UnDealReason) : "****",
                                DealAmount = d.ContentPlatformOrder.DealAmount.HasValue ? d.ContentPlatformOrder.DealAmount : 0.00M,
                                DepositAmount = d.ContentPlatformOrder.DepositAmount.HasValue ? d.ContentPlatformOrder.DepositAmount : 0.00M,
                                IsHospitalCheckPhone = p != null ? true : false,
                                OrderRemark = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? (string.IsNullOrEmpty(d.ContentPlatformOrder.Remark) ? "" : d.ContentPlatformOrder.Remark) : "****",
                                SendOrderRemark = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.Remark : "****",
                                HospitalRemark = d.HospitalRemark,
                                UnDealPictureUrl = d.ContentPlatformOrder.UnDealPictureUrl,
                                OrderSourceText = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? ServiceClass.GerContentPlatFormOrderSourceText(d.ContentPlatformOrder.OrderSource.Value) : "****",
                                CheckState = d.ContentPlatformOrder.CheckState,
                                DealDate = d.ContentPlatformOrder.DealDate,
                                IsToHospital = (d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete || d.OrderStatus == (int)ContentPlateFormOrderStatus.WithoutCompleteOrder) ? true : false,
                                ToHospitalDate = d.ContentPlatformOrder.ToHospitalDate,
                                ToHospitalType = d.ContentPlatformOrder.ToHospitalType,
                                ToHospitalTypeText = ServiceClass.GerContentPlatFormOrderToHospitalTypeText(d.ContentPlatformOrder.ToHospitalType),
                                IsRepeatProfundityOrder = d.IsRepeatProfundityOrder,
                                IsSupportOrder = d.ContentPlatformOrder.IsSupportOrder,
                                SupportEmpId = d.ContentPlatformOrder.SupportEmpId,
                                BelongEmpId = d.ContentPlatformOrder.BelongEmpId.HasValue ? d.ContentPlatformOrder.BelongEmpId.Value : 0,
                            };
            FxPageInfo<ContentPlatFormOrderSendInfoDto> sendOrderPageInfo = new FxPageInfo<ContentPlatFormOrderSendInfoDto>();
            sendOrderPageInfo.TotalCount = await sendOrder.CountAsync();
            sendOrderPageInfo.List = await sendOrder.OrderByDescending(e => e.SendDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            foreach (var x in sendOrderPageInfo.List)
            {
                var baseInfo = await customerBaseInfoService.GetByPhoneAsync(x.Phone);
                x.City = x.OrderStatusIntType > ((int)ContentPlateFormOrderStatus.SendOrder) && x.OrderStatusIntType != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? baseInfo.City : "****";
                x.WeChatNo = x.OrderStatusIntType > ((int)ContentPlateFormOrderStatus.SendOrder) && x.OrderStatusIntType != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? baseInfo.WechatNumber : "****";

                if (x.SupportEmpId != 0)
                {
                    var empInfo = await _amiyaEmployeeService.GetByIdAsync(x.SupportEmpId);
                    x.SupportEmpName = empInfo.Name;
                }
                if (x.BelongEmpId != 0)
                {
                    var empInfo = await _amiyaEmployeeService.GetByIdAsync(x.BelongEmpId);
                    x.BelongEmpName = empInfo.Name;
                }

                //var departmentInfo = await amiyaDepartmentService.GetByIdAsync(x.DepartmentId);
                x.DepartmentName = x.OrderStatusIntType > ((int)ContentPlateFormOrderStatus.SendOrder) && x.OrderStatusIntType != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? "" : "****";
                var orderRemark = await orderRemarkService.GetListWithPageAsync(x.OrderId, 1, 1);
                var remarkInfo = orderRemark.List.FirstOrDefault();
                if (remarkInfo != null)
                {

                    string date = "";
                    var createDate = remarkInfo.CreateDate.Date;
                    if (createDate == DateTime.Now.Date)
                    {
                        date = $"今天" + remarkInfo.CreateDate.ToString("hh:mm:ss");
                    }
                    else if (createDate == DateTime.Now.AddDays(-1).Date)
                    {
                        date = $"昨天" + remarkInfo.CreateDate.ToString("hh:mm:ss");
                    }
                    else
                    {
                        date = $"{remarkInfo.CreateDate.Year}/{remarkInfo.CreateDate.Month}/{remarkInfo.CreateDate.Day} " + remarkInfo.CreateDate.ToString("hh:mm:ss");
                    }
                    x.FirstlyRemark = date + " " + remarkInfo.Remark.ToString();

                }
            }
            return sendOrderPageInfo;
        }

        public async Task<FxPageInfo<ContentPlatFormOrderSendInfoDto>> GetFollowingListByHospitalIdAsync(int hospitalId, string keyword, DateTime? startDate, DateTime? endDate, bool? IsToHospital, DateTime? toHospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, bool isSpecifyHospitalEmployee, int hospitalEmpId, int pageNum, int pageSize)
        {
            var q = from d in _dalContentPlatformOrderSend.GetAll().Include(x => x.ContentPlatformOrder)
                    where (d.HospitalId == hospitalId && d.IsSpecifyHospitalEmployee == isSpecifyHospitalEmployee)
                     && (string.IsNullOrEmpty(keyword) || d.ContentPlatformOrder.Id.Contains(keyword) || d.ContentPlatformOrder.Phone.Contains(keyword) || d.ContentPlatformOrder.CustomerName.Contains(keyword))
                     && (d.OrderStatus == Convert.ToInt32(ContentPlateFormOrderStatus.ConfirmOrder) || d.OrderStatus == Convert.ToInt32(ContentPlateFormOrderStatus.RepeatOrderProfundity) || d.OrderStatus == Convert.ToInt32(ContentPlateFormOrderStatus.WithoutCompleteOrder))
                    select d;

            //&& (!IsToHospital.HasValue || d.ContentPlatformOrder.IsToHospital == IsToHospital)
            //         && (!toHospitalType.HasValue || d.ContentPlatformOrder.ToHospitalType == toHospitalType.Value)

            if (IsToHospital.HasValue)
            {
                q = q.Where(e => e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(c => c.LastDealHospitalId == e.HospitalId).OrderByDescending(e => e.CreateDate).Skip(0).Take(1).Any(e => e.IsToHospital == IsToHospital));


            }
            if (toHospitalType.HasValue)
            {
                q = q.Where(e => e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(c => c.LastDealHospitalId == e.HospitalId).OrderByDescending(e => e.CreateDate).Skip(0).Take(1).Any(e => e.ToHospitalType == toHospitalType));
            }

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
                q = q.Where(e => e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(c => c.LastDealHospitalId == e.HospitalId).OrderByDescending(e => e.CreateDate).Skip(0).Take(1).Any(e => e.ToHospitalDate >= startrq && e.ToHospitalDate < endrq));
                //q = from d in q
                //    where (d.ContentPlatformOrder.ToHospitalDate >= startrq && d.ContentPlatformOrder.ToHospitalDate < endrq)
                //    select d;
            }
            if (isSpecifyHospitalEmployee == true)
            {
                q = q.Where(e => e.HospitalEmployeeId == hospitalEmpId);
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
                                OrderStatusIntType = d.OrderStatus,
                                IsAcompanying = d.ContentPlatformOrder.IsAcompanying,
                                CustomerName = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.CustomerName : "****",
                                HospitalName = d.ContentPlatformOrder.HospitalInfo.Name,
                                SendDate = d.SendDate,
                                SendBy = d.AmiyaEmployee.Name,
                                DepartmentId = d.ContentPlatformOrder.HospitalDepartmentId,
                                AppointmentDate = d.AppointmentDate.HasValue ? d.AppointmentDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "未确定时间",
                                IsUncertainDate = d.IsUncertainDate,
                                OrderStatus = d.OrderStatus != 0 ? ServiceClass.GetContentPlateFormOrderStatusText((byte)d.OrderStatus) : "",
                                GoodsName = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.AmiyaGoodsDemand.ProjectNname : "****",
                                ThumbPicUrl = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.AmiyaGoodsDemand.ThumbPictureUrl : "****",
                                Phone = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? (p != null ? d.ContentPlatformOrder.Phone : config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.ContentPlatformOrder.Phone) : d.ContentPlatformOrder.Phone) : ServiceClass.GetIncompletePhone(d.ContentPlatformOrder.Phone),
                                EncryptPhone = ServiceClass.Encrypt(d.ContentPlatformOrder.Phone, config.PhoneEncryptKey),
                                LiveAnchor = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.LiveAnchor.Name : "****",
                                DealPictureUrl = string.IsNullOrEmpty(d.ContentPlatformOrder.DealPictureUrl) ? "" : d.ContentPlatformOrder.DealPictureUrl,
                                RepeateOrderPictureUrl = string.IsNullOrEmpty(d.ContentPlatformOrder.RepeatOrderPictureUrl) ? "" : d.ContentPlatformOrder.RepeatOrderPictureUrl,
                                LateProjectStage = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? (string.IsNullOrEmpty(d.ContentPlatformOrder.LateProjectStage) ? "" : d.ContentPlatformOrder.LateProjectStage) : "****",
                                ConsultingContent = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? (d.IsMainHospital ? d.ContentPlatformOrder.ConsultingContent : d.ContentPlatformOrder.ConsultingContent2) : "****",
                                UnDealReason = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? (string.IsNullOrEmpty(d.ContentPlatformOrder.UnDealReason) ? "" : d.ContentPlatformOrder.UnDealReason) : "****",
                                DealAmount = d.ContentPlatformOrder.DealAmount.HasValue ? d.ContentPlatformOrder.DealAmount : 0.00M,
                                DepositAmount = d.ContentPlatformOrder.DepositAmount.HasValue ? d.ContentPlatformOrder.DepositAmount : 0.00M,
                                IsHospitalCheckPhone = p != null ? true : false,
                                OrderRemark = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? (string.IsNullOrEmpty(d.ContentPlatformOrder.Remark) ? "" : d.ContentPlatformOrder.Remark) : "****",
                                SendOrderRemark = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.Remark : "****",
                                HospitalRemark = d.HospitalRemark,
                                UnDealPictureUrl = d.ContentPlatformOrder.UnDealPictureUrl,
                                OrderSourceText = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? ServiceClass.GerContentPlatFormOrderSourceText(d.ContentPlatformOrder.OrderSource.Value) : "****",
                                CheckState = d.ContentPlatformOrder.CheckState,
                                DealDate = d.ContentPlatformOrder.DealDate,
                                IsToHospital = (d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete || d.OrderStatus == (int)ContentPlateFormOrderStatus.WithoutCompleteOrder) ? true : false,
                                ToHospitalDate = d.ContentPlatformOrder.ToHospitalDate,
                                ToHospitalType = d.ContentPlatformOrder.ToHospitalType,
                                ToHospitalTypeText = ServiceClass.GerContentPlatFormOrderToHospitalTypeText(d.ContentPlatformOrder.ToHospitalType),
                                IsRepeatProfundityOrder = d.IsRepeatProfundityOrder
                            };
            FxPageInfo<ContentPlatFormOrderSendInfoDto> sendOrderPageInfo = new FxPageInfo<ContentPlatFormOrderSendInfoDto>();
            sendOrderPageInfo.TotalCount = await sendOrder.CountAsync();
            sendOrderPageInfo.List = await sendOrder.OrderByDescending(e => e.SendDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            foreach (var x in sendOrderPageInfo.List)
            {
                var baseInfo = await customerBaseInfoService.GetByPhoneAsync(x.Phone);
                x.City = x.OrderStatusIntType > ((int)ContentPlateFormOrderStatus.SendOrder) && x.OrderStatusIntType != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? baseInfo.City : "****";
                x.WeChatNo = x.OrderStatusIntType > ((int)ContentPlateFormOrderStatus.SendOrder) && x.OrderStatusIntType != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? baseInfo.WechatNumber : "****";

                //  var departmentInfo = await amiyaDepartmentService.GetByIdAsync(x.DepartmentId);
                x.DepartmentName = x.OrderStatusIntType > ((int)ContentPlateFormOrderStatus.SendOrder) && x.OrderStatusIntType != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? "" : "****";

                var orderRemark = await orderRemarkService.GetListWithPageAsync(x.OrderId, 1, 1);
                var remarkInfo = orderRemark.List.FirstOrDefault();
                if (remarkInfo != null)
                {
                    string date = "";
                    var createDate = remarkInfo.CreateDate.Date;
                    if (createDate == DateTime.Now.Date)
                    {
                        date = $"今天" + remarkInfo.CreateDate.ToString("hh:mm:ss");
                    }
                    else if (createDate == DateTime.Now.AddDays(-1).Date)
                    {
                        date = $"昨天" + remarkInfo.CreateDate.ToString("hh:mm:ss");
                    }
                    else
                    {
                        date = $"{remarkInfo.CreateDate.Year}/{remarkInfo.CreateDate.Month}/{remarkInfo.CreateDate.Day} " + remarkInfo.CreateDate.ToString("hh:mm:ss");
                    }
                    x.FirstlyRemark = date + " " + remarkInfo.Remark.ToString();

                }
            }
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
        public async Task<int> GetCountByHospitalIdAsync(int hospitalId, bool isSpecifyHospitalEmployee, int hospitalEmpId)
        {
            var q = from d in _dalContentPlatformOrderSend.GetAll()
                    where d.HospitalId == hospitalId
                    && d.OrderStatus == (int)ContentPlateFormOrderStatus.SendOrder && d.IsSpecifyHospitalEmployee == isSpecifyHospitalEmployee
                    select d;
            if (isSpecifyHospitalEmployee == true)
            {
                q = q.Where(x => x.HospitalEmployeeId == hospitalEmpId);
            }
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

            //if (sendOrderInfo.ContentPlatformOrder.OrderStatus == Convert.ToInt16(ContentPlateFormOrderStatus.OrderComplete))
            //    throw new Exception("该订单已交易完成，无法改派医院");
            //if (sendOrderInfo.ContentPlatformOrder.OrderStatus == Convert.ToInt16(ContentPlateFormOrderStatus.WithoutCompleteOrder))
            //    throw new Exception("该订单医院已经处理完毕，无法改派医院");

            sendOrderInfo.HospitalRemark = input.HospitalRemark;
            await _dalContentPlatformOrderSend.UpdateAsync(sendOrderInfo, true);


            //订单备注新增数据
            if (!string.IsNullOrEmpty(input.HospitalRemark))
            {

                AddOrderRemarkDto addOrderRemarkDto = new AddOrderRemarkDto();
                addOrderRemarkDto.OrderId = sendOrderInfo.ContentPlatformOrderId;
                addOrderRemarkDto.Remark = input.HospitalRemark;
                addOrderRemarkDto.CreateBy = input.UpdateBy;
                addOrderRemarkDto.BelongAuthorize = (int)AuthorizeStatusEnum.TenantAuhtorize;
                await orderRemarkService.AddAsync(addOrderRemarkDto);
            }
        }

        /// <summary>
        /// 获取内容平台订单已派单信息列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="loginEmployeeId">登陆员工id</param>
        /// <param name="belongChannel">归属部门</param>
        /// <param name="belongEmployeeId">归属客服</param>
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
        public async Task<FxPageInfo<SendContentPlatformOrderDto>> GetSendOrderList(List<int?> liveAnchorIds, int? consultationEmpId, int? sendBy, bool? isAcompanying, bool? isOldCustomer, decimal? commissionRatio, string keyword, int? belongChannel, int? belongMonth, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, int loginEmployeeId, int belongEmployeeId, int? orderStatus, string contentPlatFormId, DateTime? startDate, DateTime? endDate, int? hospitalId, bool? IsToHospital, DateTime? toHospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, int orderSource, int? hospitalEmpId, int pageNum, int pageSize, bool? isMainHospital)
        {

            var orders = _dalContentPlatformOrderSend.GetAll().Include(x => x.ContentPlatformOrder)
                       .Where(e => string.IsNullOrWhiteSpace(keyword) || e.ContentPlatformOrderId == keyword || e.ContentPlatformOrder.Phone.Contains(keyword) || e.ContentPlatformOrder.LiveAnchorWeChatNo.Contains(keyword))
                       .Where(e => hospitalId == 0 || e.HospitalId == hospitalId)
                       .Where(e => !isMainHospital.HasValue || e.IsMainHospital == isMainHospital)
                       .Where(e => orderSource == -1 || e.ContentPlatformOrder.OrderSource == orderSource)
                       .Where(e => !IsToHospital.HasValue || e.ContentPlatformOrder.IsToHospital == IsToHospital.Value)
                       .Where(e => !belongChannel.HasValue || e.ContentPlatformOrder.BelongChannel == belongChannel.Value)
                       .Where(e => !belongMonth.HasValue || e.ContentPlatformOrder.BelongMonth == belongMonth.Value)
                       .Where(e => !minAddOrderPrice.HasValue || e.ContentPlatformOrder.AddOrderPrice >= minAddOrderPrice.Value)
                       .Where(e => !maxAddOrderPrice.HasValue || e.ContentPlatformOrder.AddOrderPrice <= maxAddOrderPrice.Value)
                       .Where(e => !sendBy.HasValue || e.Sender == sendBy.Value)
                       .Where(e => !isAcompanying.HasValue || e.ContentPlatformOrder.IsAcompanying == isAcompanying.Value)
                       .Where(e => !isOldCustomer.HasValue || e.ContentPlatformOrder.IsOldCustomer == isOldCustomer.Value)
                       .Where(e => !commissionRatio.HasValue || e.ContentPlatformOrder.CommissionRatio == commissionRatio.Value)
                       .Where(e => !toHospitalType.HasValue || e.ContentPlatformOrder.ToHospitalType == toHospitalType.Value)
                       .Where(e => !consultationEmpId.HasValue || e.ContentPlatformOrder.ConsultationEmpId == consultationEmpId.Value)
                       .Where(e => !hospitalEmpId.HasValue || e.HospitalEmployeeId == hospitalEmpId.Value)
                       .Where(e => liveAnchorIds.Count <= 0 || liveAnchorIds.Contains(e.ContentPlatformOrder.LiveAnchorId))
                       .Where(e => belongEmployeeId == -1 || (e.ContentPlatformOrder.SupportEmpId == 0 ? e.ContentPlatformOrder.BelongEmpId == belongEmployeeId : e.ContentPlatformOrder.SupportEmpId == belongEmployeeId))
                       .Where(e => orderStatus == null || (orderStatus != null && orderStatus == (int)ContentPlateFormOrderStatus.RepeatOrderProfundity ? e.IsRepeatProfundityOrder == true : e.OrderStatus == orderStatus))
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

            var employee = await _amiyaEmployeeService.GetByIdAsync(loginEmployeeId);
            //普通客服角色过滤其他订单信息只展示自己录单信息
            if (employee.IsCustomerService && !employee.IsDirector)
            {
                orders = from d in orders
                         where _dalBindCustomerService.GetAll().Count(e => e.CustomerServiceId == loginEmployeeId && e.BuyerPhone == d.ContentPlatformOrder.Phone) > 0
                         || d.ContentPlatformOrder.SupportEmpId == loginEmployeeId
                         || d.ContentPlatformOrder.BelongEmpId == loginEmployeeId
                         || (d.ContentPlatformOrder.IsSupportOrder == false || d.ContentPlatformOrder.SupportEmpId == loginEmployeeId)
                         select d;

            }
            //else
            //{

            //    if (loginEmployeeId != -1)
            //    {
            //        orders = from d in orders
            //                 where d.ContentPlatformOrder.BelongEmpId == loginEmployeeId
            //                 select d;
            //    }
            //}
            var orderCount = await orders.CountAsync();
            var config = await _wxAppConfigService.GetWxAppCallCenterConfigAsync();
            var contentPlatformOrders = from d in orders
                                        select new SendContentPlatformOrderDto
                                        {
                                            Id = d.Id,
                                            OrderId = d.ContentPlatformOrderId,
                                            ContentPlatFormName = d.ContentPlatformOrder.Contentplatform.ContentPlatformName,
                                            LiveAnchorName = d.ContentPlatformOrder.LiveAnchor.HostAccountName,
                                            LiveAnchorWeChatNo = d.ContentPlatformOrder.LiveAnchorWeChatNo,
                                            BelongChannelText = ServiceClass.BelongChannelText(d.ContentPlatformOrder.BelongChannel),
                                            //IsOldCustomer = d.ContentPlatformOrder.IsOldCustomer == true ? "老客业绩" : "新客业绩",
                                            //IsAcompanying = d.ContentPlatformOrder.IsAcompanying,
                                            //CommissionRatio = d.ContentPlatformOrder.CommissionRatio,
                                            //BelongMonth = d.ContentPlatformOrder.BelongMonth,
                                            //AddOrderPrice = d.ContentPlatformOrder.AddOrderPrice,
                                            BelongEmpId = d.ContentPlatformOrder.BelongEmpId.HasValue ? d.ContentPlatformOrder.BelongEmpId.Value : 0,
                                            CustomerName = ServiceClass.GetIncompleteCustomerName(d.ContentPlatformOrder.CustomerName),
                                            Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(d.ContentPlatformOrder.Phone) : d.ContentPlatformOrder.Phone,
                                            EncryptPhone = ServiceClass.Encrypt(d.ContentPlatformOrder.Phone, config.PhoneEncryptKey),
                                            //AppointmentHospital = d.ContentPlatformOrder.HospitalInfo.Name,
                                            SendHospitalId = d.HospitalId,
                                            AppointmentDate = d.AppointmentDate.HasValue ? d.AppointmentDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "未确认时间",
                                            GoodsName = d.ContentPlatformOrder.AmiyaGoodsDemand.ProjectNname,
                                            ThumbPictureUrl = d.ContentPlatformOrder.AmiyaGoodsDemand.ThumbPictureUrl,
                                            //LateProjectStage = d.ContentPlatformOrder.LateProjectStage,
                                            ConsultingContent = d.ContentPlatformOrder.ConsultingContent,
                                            //OrderTypeText = ServiceClass.GetContentPlateFormOrderTypeText((byte)d.ContentPlatformOrder.OrderType),
                                            OrderStatusText = ServiceClass.GetContentPlateFormOrderStatusText((byte)d.OrderStatus),
                                            //DepositAmount = d.ContentPlatformOrder.DepositAmount,
                                            DealAmount = d.ContentPlatformOrder.DealAmount,
                                            //DealPictureUrl = d.ContentPlatformOrder.DealPictureUrl,
                                            IsToHospital = (d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete || d.OrderStatus == (int)ContentPlateFormOrderStatus.WithoutCompleteOrder) ? true : false,
                                            //ToHospitalTypeText = ServiceClass.GerContentPlatFormOrderToHospitalTypeText(d.ContentPlatformOrder.ToHospitalType),
                                            //UnDealReason = d.ContentPlatformOrder.UnDealReason,
                                            ConsultationType = d.ContentPlatformOrder.ConsulationType,
                                            ConsultationTypeText = ServiceClass.GetContentPlateFormOrderConsultationTypeText(d.ContentPlatformOrder.ConsulationType),
                                            Sender = d.Sender,
                                            SenderName = d.AmiyaEmployee.Name,
                                            //CheckState = d.ContentPlatformOrder.CheckState,
                                            SendDate = d.SendDate,
                                            //ToHospitalDate = d.ContentPlatformOrder.ToHospitalDate,
                                            //SendOrderRemark = d.Remark,
                                            //DealDate = d.ContentPlatformOrder.DealDate,
                                            OrderRemark = d.ContentPlatformOrder.Remark,
                                            IsSpecifyHospitalEmployee = d.IsSpecifyHospitalEmployee,
                                            HospitalEmployeeId = d.HospitalEmployeeId,
                                            HospitalRemark = d.HospitalRemark,
                                            //UnDealPictureUrl = d.ContentPlatformOrder.UnDealPictureUrl,
                                            //OtherContentPlatFormOrderId = d.ContentPlatformOrder.OtherContentPlatFormOrderId,
                                            OrderSourceText = ServiceClass.GerContentPlatFormOrderSourceText(d.ContentPlatformOrder.OrderSource.Value),
                                            AcceptConsulting = d.ContentPlatformOrder.AcceptConsulting,
                                            IsRepeatProfundityOrder = d.IsRepeatProfundityOrder,
                                            IsMainHospital = d.IsMainHospital,
                                            ConsultingContent2 = d.ContentPlatformOrder.ConsultingContent2
                                        };

            FxPageInfo<SendContentPlatformOrderDto> pageInfo = new FxPageInfo<SendContentPlatformOrderDto>();
            pageInfo.TotalCount = await contentPlatformOrders.CountAsync();
            pageInfo.List = await contentPlatformOrders.OrderByDescending(x => x.SendDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            foreach (var x in pageInfo.List)
            {
                x.IsHospitalCheckPhone = _dalHospitalCheckPhoneRecord.GetAll().Where(e => e.OrderId == x.OrderId && e.HospitalId == x.SendHospitalId).Any();
                x.SendHospital = _hospitalInfoService.GetByIdAsync(x.SendHospitalId).Result.Name;
                if (!string.IsNullOrEmpty(x.LiveAnchorWeChatNo))
                {
                    var wechatInfo = await liveAnchorWeChatInfoService.GetByIdAsync(x.LiveAnchorWeChatNo);
                    if (wechatInfo.Id != null)
                    {
                        x.LiveAnchorWeChatNo = wechatInfo.WeChatNo;
                    }

                }
                if (x.BelongEmpId != 0)
                {
                    var empInfo = await _amiyaEmployeeService.GetByIdAsync(x.BelongEmpId);
                    x.BelongEmpName = empInfo.Name.ToString();
                }
                if (x.HospitalEmployeeId != 0)
                {
                    var hospitalEmpInfo = await hospitalEmployeeService.GetByIdAsync(x.HospitalEmployeeId);
                    x.HospitalEmployeeName = hospitalEmpInfo.Name;
                }
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
            var orders = _dalContentPlatformOrderSend.GetAll().Include(x => x.HospitalInfo)
                       .Where(e => employeeId == -1 || e.Sender == employeeId)
                       .Where(e => belongEmpId == -1 || e.ContentPlatformOrder.BelongEmpId == belongEmpId)
                       .Where(e => !liveAnchorId.HasValue || e.ContentPlatformOrder.LiveAnchorId == liveAnchorId.Value)
                       .Where(e => !IsToHospital.HasValue || e.ContentPlatformOrder.IsToHospital == IsToHospital.Value)
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
                                            ConsultationTypeText = ServiceClass.GetContentPlateFormOrderConsultationTypeText(d.ContentPlatformOrder.ConsulationType),
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
                                            SendHospital = d.HospitalInfo.Name,
                                            BelongEmpId = d.ContentPlatformOrder.BelongEmpId.HasValue ? d.ContentPlatformOrder.BelongEmpId.Value : 0,
                                        };

            List<SendContentPlatformOrderDto> pageInfo = new List<SendContentPlatformOrderDto>();
            pageInfo = await contentPlatformOrders.ToListAsync();
            foreach (var x in pageInfo)
            {
                if (x.BelongEmpId != 0)
                {
                    x.BelongEmpName = _amiyaEmployeeService.GetByIdAsync(x.BelongEmpId).Result.Name;
                }
                if (!string.IsNullOrEmpty(x.LiveAnchorWeChatNo))
                {
                    var wechatInfo = await liveAnchorWeChatInfoService.GetByIdAsync(x.LiveAnchorWeChatNo);
                    if (wechatInfo != null)
                    {
                        x.LiveAnchorWeChatNo = wechatInfo.WeChatNo;
                    }
                }
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
        public async Task<List<SendContentPlatFormOrderReportDto>> GetContentPlatFormHospitalOrderReportAsync(DateTime? startDate, DateTime? endDate, int? orderStatus, int hospitalId, bool isHidePhone, bool isSpecifyHospitalEmployee, int hospitalEmpId)
        {

            var q = from d in _dalContentPlatformOrderSend.GetAll()
                    where d.HospitalId == hospitalId && d.IsSpecifyHospitalEmployee == isSpecifyHospitalEmployee
                    select d;

            if (startDate != null && endDate != null)
            {
                DateTime startrq = (DateTime)startDate;
                DateTime endrq = ((DateTime)endDate).Date.AddDays(1);

                q = from d in q
                    where (d.SendDate >= startrq && d.SendDate < endrq)
                    && (!orderStatus.HasValue || d.OrderStatus == orderStatus.Value)
                    select d;
            }
            if (isSpecifyHospitalEmployee == true)
            {
                q = q.Where(x => x.HospitalEmployeeId == hospitalEmpId);
            }
            var sendOrder = from d in q
                            select new SendContentPlatFormOrderReportDto
                            {
                                OrderId = d.ContentPlatformOrderId,
                                SendDate = d.SendDate,
                                EncryptPhone = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? (isHidePhone == true ? ServiceClass.GetIncompletePhone(d.ContentPlatformOrder.Phone) : d.ContentPlatformOrder.Phone) : ServiceClass.GetIncompletePhone(d.ContentPlatformOrder.Phone),
                                CustomerName = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.CustomerName : "****",
                                GoodsName = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.AmiyaGoodsDemand.ProjectNname : "****",
                                SendHospitalId = d.HospitalId,
                                ConsultingContent = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? (d.IsMainHospital ? d.ContentPlatformOrder.ConsultingContent : d.ContentPlatformOrder.ConsultingContent2) : "****",
                                AppointmentDate = d.IsUncertainDate == false ? d.AppointmentDate.Value.ToString("yyyy-MM-dd") : "未明确时间",
                                OrderStatusText = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? ServiceClass.GetContentPlateFormOrderStatusText((byte)d.OrderStatus) : "****",
                                DepositAmount = d.ContentPlatformOrder.DepositAmount,
                                DealAmount = d.ContentPlatformOrder.DealAmount,
                                UnDealReason = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.UnDealReason : "****",
                                LateProjectStage = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.LateProjectStage : "****",
                                OrderRemark = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.Remark : "****",
                                SendOrderRemark = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.Remark : "****",
                                SenderName = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.AmiyaEmployee.Name : "****",
                                HospitalRemark = d.HospitalRemark,
                                OrderSourceText = d.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? ServiceClass.GerContentPlatFormOrderSourceText(d.ContentPlatformOrder.OrderSource.Value) : "****"
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
        /// 获取时间段内已派单数据(分组)
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

        public async Task<List<OrderOperationConditionDto>> GetTodaySendOrderByLiveAnchorIdAsync(int liveAnchorId, DateTime recordDate)
        {
            DateTime startrq = recordDate.Date;
            DateTime endrq = recordDate.Date.AddDays(1);
            var orders = from d in _dalContentPlatformOrderSend.GetAll().Include(x => x.ContentPlatformOrder)
                         where d.SendDate >= startrq && d.SendDate < endrq && d.ContentPlatformOrder.LiveAnchorId == liveAnchorId
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.SendDate.Date).Select(x => new OrderOperationConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderNum = x.ToList().Count }).ToList();
        }

        /// <summary>
        /// 获取选取时间至今已派单数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public async Task<List<SendContentPlatformOrderDto>> GetTodayOrderSendDataAsync(DateTime startDate)
        {
            DateTime startrq = startDate;
            DateTime endrq = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
            var orders = from d in _dalContentPlatformOrderSend.GetAll().Include(x => x.HospitalInfo).ThenInclude(x => x.CooperativeHospitalCity)
                         where d.SendDate >= startrq && d.SendDate < endrq
                         select new SendContentPlatformOrderDto
                         {
                             OrderId = d.ContentPlatformOrderId,
                             SendHospitalId = d.HospitalId,
                             ThumbPictureUrl = d.HospitalInfo.ThumbPicUrl,
                             SendHospital = d.HospitalInfo.Name,
                             City = d.HospitalInfo.CooperativeHospitalCity.Name,
                             SendDate = d.SendDate,
                         };
            var result = orders.ToList();
            return result;
        }


        /// <summary>
        /// 获取选取时间内已派单数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public async Task<List<SendContentPlatformOrderDto>> GetTodayOrderSendDataAsync(QueryHospitalTransformDataDto query)
        {

            var orders = from d in _dalContentPlatformOrderSend.GetAll().Include(x => x.HospitalInfo).ThenInclude(x => x.CooperativeHospitalCity)
                         where d.SendDate >= query.StartDate && d.SendDate < query.EndDate && (query.LiveAnchorIds.Count == 0 || query.LiveAnchorIds.Contains(d.ContentPlatformOrder.LiveAnchor.LiveAnchorBaseId))
                         select new SendContentPlatformOrderDto
                         {
                             OrderId = d.ContentPlatformOrderId,
                             SendHospitalId = d.HospitalId,
                             ThumbPictureUrl = d.HospitalInfo.ThumbPicUrl,
                             SendHospital = d.HospitalInfo.Name,
                             City = d.HospitalInfo.CooperativeHospitalCity.Name,
                             SendDate = d.SendDate,
                         };
            var result = await orders.ToListAsync();
            return result;
        }

        /// <summary>
        /// 根据时间获取已到院数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public async Task<List<SendContentPlatformOrderDto>> GetOrderToHospitalDataByDateAsync(DateTime startDate)
        {

            DateTime startrq = startDate;
            DateTime endrq = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
            var orders = from d in _dalContentPlatformOrderSend.GetAll().Include(x => x.HospitalInfo).ThenInclude(x => x.CooperativeHospitalCity)
                         where d.ContentPlatformOrder.ToHospitalDate >= startrq && d.ContentPlatformOrder.ToHospitalDate < endrq
                         select new SendContentPlatformOrderDto
                         {
                             OrderId = d.ContentPlatformOrderId,
                             SendHospitalId = d.HospitalId,
                             ThumbPictureUrl = d.HospitalInfo.ThumbPicUrl,
                             SendHospital = d.HospitalInfo.Name,
                             City = d.HospitalInfo.CooperativeHospitalCity.Name,
                             SendDate = d.SendDate,
                         };
            var result = orders.ToList();
            return result;
        }


        /// <summary>
        /// 根据医院id与月份获取派单业绩
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public async Task<List<SendContentPlatformOrderDto>> GetSendDataByHospitalIdAndMonthAsync(int hospitalId, int year, int month)
        {
            DateTime startDate = Convert.ToDateTime(year + "-" + month + "-01");
            DateTime endDate = startDate.AddMonths(1);
            var orders = from d in _dalContentPlatformOrderSend.GetAll().Include(x => x.HospitalInfo).ThenInclude(x => x.CooperativeHospitalCity)
                         where d.SendDate >= startDate && d.SendDate < endDate && d.HospitalId == hospitalId
                         select new SendContentPlatformOrderDto
                         {
                             OrderId = d.ContentPlatformOrderId,
                             SendHospitalId = d.HospitalId,
                             SendHospital = d.HospitalInfo.Name,
                             City = d.HospitalInfo.CooperativeHospitalCity.Name,
                             SendDate = d.SendDate,
                         };
            var result = orders.ToList();
            return result;
        }
        /// <summary>
        /// 根据医院id与年份获取派单业绩
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public async Task<int> GetSendDataByHospitalIdAndYearAsync(int hospitalId, int year)
        {
            DateTime startDate = Convert.ToDateTime(year + "-01-01");
            DateTime endDate = startDate.AddYears(1);
            var orders = _dalContentPlatformOrderSend.GetAll().Where(d => d.SendDate >= startDate && d.SendDate < endDate && d.HospitalId == hospitalId);
            var result = orders.Count();
            return result;
        }
        /// <summary>
        /// 根据医院id与月份获取派单业绩
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public async Task<int> GetSendDataByHospitalIdAsync(int hospitalId)
        {
            var orders = _dalContentPlatformOrderSend.GetAll().Where(d => d.HospitalId == hospitalId);
            var result = orders.Count();
            return result;
        }

        private async Task<CallCenterConfigDto> GetCallCenterConfig()
        {
            var config = await _dalConfig.GetAll().SingleOrDefaultAsync();
            return JsonConvert.DeserializeObject<WxAppConfigDto>(config.ConfigJson).CallCenterConfig;
        }

        /// <summary>
        /// 获取总派单量
        /// </summary>
        /// <returns></returns>
        public async Task<decimal> GetTotalSendCount()
        {
            return await _dalContentPlatformOrderSend.GetAll().CountAsync();
        }

        /// <summary>
        /// 根据派单人获取总派单量
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTotalSendCountByEmployeeAsync(int employeeId, DateTime startDate, DateTime endDate)
        {
            return await _dalContentPlatformOrderSend.GetAll().Where(x => x.Sender == employeeId && x.SendDate > startDate && x.SendDate < endDate).CountAsync();
        }

        #region 全国机构运营数据
        /// <summary>
        /// 获取派单量前10的医院运营数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<SendOrderInfoPerformanceDto>> GetTopTenHospitalSendOrderPerformance()
        {
            var performanceList = from d in _dalHospitalInfo.GetAll()
                                  from h in _dalContentPlatformOrderSend.GetAll()
                                  where d.Id == h.HospitalId
                                  group h by d.Name into g
                                  orderby g.Count() descending
                                  select new SendOrderInfoPerformanceDto
                                  {
                                      HospitalName = g.Key,
                                      Performance = g.Count()
                                  };
            return await performanceList.Skip(0).Take(10).ToListAsync();
        }


        #endregion
        #region 全国城市运营数据
        public async Task<List<SendOrderInfoCityPerformanceDto>> GetTopTenCitySendOrderPerformance()
        {
            var performanceList = from d in _dalHospitalInfo.GetAll()
                                  from h in _dalContentPlatformOrderSend.GetAll()
                                  where d.Id == h.HospitalId
                                  group h by d.CooperativeHospitalCity.Name into g
                                  orderby g.Count() descending
                                  select new SendOrderInfoCityPerformanceDto
                                  {
                                      CityName = g.Key,
                                      Performance = g.Count()
                                  };
            return await performanceList.Skip(0).Take(10).ToListAsync();
        }

        public async Task<FxPageInfo<HospitalCurrentDayNotRepeatedSendOrderDto>> GetTodayNotRepeatSendOrderByHospitalIdAsync(int hospitalId, int orderStatus, DateTime startDate, DateTime enDate, int pageNum, int pageSize)
        {
            FxPageInfo<HospitalCurrentDayNotRepeatedSendOrderDto> fxPageInfo = new FxPageInfo<HospitalCurrentDayNotRepeatedSendOrderDto>();
            var sendOrderList = _dalContentPlatformOrderSend.GetAll().Where(e => e.HospitalId == hospitalId
            && e.ContentPlatformOrder.OrderStatus == orderStatus
            && e.SendDate >= startDate
            && e.SendDate < enDate).OrderByDescending(e => e.SendDate);
            var config = await GetCallCenterConfig();
            var sendOrder = from d in sendOrderList
                            join p in _dalHospitalCheckPhoneRecord.GetAll().Where(e => e.HospitalId == hospitalId && e.OrderPlatformType == (byte)CheckPhoneRecordOrderType.ContentPlatformOrder)
                            on d.ContentPlatformOrderId equals p.OrderId into pd
                            from p in pd.DefaultIfEmpty()
                            select new HospitalCurrentDayNotRepeatedSendOrderDto
                            {
                                Id = d.Id,
                                OrderId = d.ContentPlatformOrderId,
                                OrderStatus = d.ContentPlatformOrder.OrderStatus,
                                OrderStatusText = ServiceClass.GetContentPlateFormOrderStatusText((byte)d.ContentPlatformOrder.OrderStatus),
                                Item = d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? d.ContentPlatformOrder.AmiyaGoodsDemand.ProjectNname : "****",
                                UserInfo = d.ContentPlatformOrder.CustomerName + " - " + (d.ContentPlatformOrder.OrderStatus > ((int)ContentPlateFormOrderStatus.SendOrder) && d.ContentPlatformOrder.OrderStatus != ((int)ContentPlateFormOrderStatus.RepeatOrder) ? (p != null ? d.ContentPlatformOrder.Phone : config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.ContentPlatformOrder.Phone) : d.ContentPlatformOrder.Phone) : ServiceClass.GetIncompletePhone(d.ContentPlatformOrder.Phone)),
                                LastFollowContent = "****",
                                SendOrderDate = d.SendDate,
                                SendOrderLiveAnchorNAme = d.ContentPlatformOrder.LiveAnchor.Name,
                                SendOrderAssistantName = d.AmiyaEmployee.Name
                            };
            fxPageInfo.TotalCount = await sendOrder.CountAsync();
            fxPageInfo.List = sendOrder.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            return fxPageInfo;
        }










        #endregion
        /// <summary>
        /// 根据内容平台id获取派单列表
        /// </summary>
        /// <param name="contentplateformId"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<SimpleSendOrderInfoDto>> GetSendOrderInfoListByContentplateformIdAsync(QuerySendOrderInfoListDto query)
        {
            FxPageInfo<SimpleSendOrderInfoDto> pageInfo = new FxPageInfo<SimpleSendOrderInfoDto>();
            var res = _dalContentPlatformOrderSend.GetAll()
                      .Where(e => e.ContentPlatformOrderId == query.ContentPlatformId)
                      .Where(e => !query.IsMainHospital.HasValue || e.IsMainHospital == query.IsMainHospital)
                      .Include(e => e.ContentPlatformOrder)
                      .Include(e => e.HospitalInfo)
                      .Select(e => new SimpleSendOrderInfoDto
                      {
                          Id = e.Id,
                          HospitalName = e.HospitalInfo.Name,
                          HospitalId = e.HospitalId,
                          AppointmentDate = e.ContentPlatformOrder.AppointmentDate,
                          Remark = e.Remark,
                          HospitalRemark = e.HospitalRemark,
                          OrderStatus = ServiceClass.GetContentPlateFormOrderStatusText(Convert.ToByte(e.OrderStatus)),
                          SendBy = e.Sender,
                          IsMainHospital = e.IsMainHospital,
                          SendDate = e.SendDate,
                          SenderName = e.AmiyaEmployee.Name,
                          IsSpecifyHospitalEmployee = e.IsSpecifyHospitalEmployee,
                          HospitalEmployeeId = e.HospitalEmployeeId,
                      });
            pageInfo.TotalCount = await res.CountAsync();
            pageInfo.List = res.OrderByDescending(x => x.SendDate).Skip((query.PageNum.Value - 1) * query.PageSize.Value).Take(query.PageSize.Value).ToList();
            foreach (var x in pageInfo.List)
            {
                if (x.HospitalEmployeeId != 0)
                {
                    var hospitalEmpInfo = await hospitalEmployeeService.GetByIdAsync(x.HospitalEmployeeId);
                    x.HospitalEmployeeName = hospitalEmpInfo.Name;
                }
            }
            return pageInfo;

        }
        /// <summary>
        /// 修改派单订单状态
        /// </summary>
        /// <param name="sendOrderId"></param>
        /// <param name="OrderStatus"></param>
        /// <returns></returns>
        public async Task UpdateSendOrderStatusAsync(int sendOrderId, int orderStatus)
        {
            var sendOrder = await _dalContentPlatformOrderSend.GetAll().Where(e => e.Id == sendOrderId).FirstOrDefaultAsync();
            if (sendOrder == null)
                throw new Exception("派单编号错误");
            sendOrder.OrderStatus = orderStatus;
            if (sendOrder.OrderStatus == (int)ContentPlateFormOrderStatus.RepeatOrderProfundity)
                sendOrder.IsRepeatProfundityOrder = true;
            _dalContentPlatformOrderSend.Update(sendOrder, true);
        }
    }
}
