﻿using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.CustomerInfo;
using Fx.Amiya.Dto.FinancialBoard;
using Fx.Amiya.Dto.HospitalBindCustomerService;
using Fx.Amiya.Dto.HospitalBoard;
using Fx.Amiya.Dto.HospitalCustomerInfo;
using Fx.Amiya.Dto.OrderCheckPicture;
using Fx.Amiya.Dto.OrderRemark;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.Dto.ReconciliationDocuments;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.Dto.UpdateCreateBillAndCompany;
using Fx.Amiya.Dto.WxAppConfig;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Common.Extensions;
using Fx.Common.Utils;
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
    public class ContentPlateFormOrderService : IContentPlateFormOrderService
    {

        private IDalContentPlatformOrder _dalContentPlatformOrder;
        private IOrderRemarkService orderRemarkService;
        private IDalBindCustomerService _dalBindCustomerService;
        private IHospitalBindCustomerService hospitalBindCustomerService;
        private IAmiyaGoodsDemandService amiyaGoodsDemandService;
        private IRecommandDocumentSettleService recommandDocumentSettleService;
        private ILiveAnchorWeChatInfoService liveAnchorWeChatInfoService;
        private IBindCustomerServiceService bindCustomerServiceService;
        private IHospitalCustomerInfoService hospitalCustomerInfoService;
        private IOrderCheckPictureService _orderCheckPictureService;
        private IContentPlatformOrderSendService _contentPlatformOrderSend;
        private IDalAmiyaEmployee _dalAmiyaEmployee;
        private ILiveAnchorService _liveAnchorService;
        private IShoppingCartRegistrationService _shoppingCartRegistration;
        private IAmiyaEmployeeService _amiyaEmployeeService;
        private IContentPlatformService _contentPlatformService;
        private IAmiyaHospitalDepartmentService _departmentService;
        private IHospitalInfoService _hospitalInfoService;
        private IContentPlatFormCustomerPictureService _contentPlatFormCustomerPictureService;
        private IEmployeeBindLiveAnchorService employeeBindLiveAnchorService;
        private IUnitOfWork unitOfWork;
        private IContentPlatFormOrderDealInfoService _contentPlatFormOrderDalService;
        private IDalConfig _dalConfig;
        private IWxAppConfigService _wxAppConfigService;
        private IDalLiveAnchor dalLiveAnchor;
        private IDalContentPlatFormOrderDealInfo dalContentPlatFormOrderDealInfo;
        private IDalCompanyBaseInfo dalCompanyBaseInfo;
        private IDalAmiyaHospitalDepartment dalAmiyaHospitalDepartment;
        private IDalHospitalInfo dalHospitalInfo;
        private ICustomerAppointmentScheduleService customerAppointmentScheduleService;
        private IDalContentPlatformOrderSend dalContentPlatformOrderSend;

        public ContentPlateFormOrderService(
           IDalContentPlatformOrder dalContentPlatformOrder,
           IDalAmiyaEmployee dalAmiyaEmployee,
           IRecommandDocumentSettleService recommandDocumentSettleService,
           ILiveAnchorWeChatInfoService liveAnchorWeChatInfoService,
            ILiveAnchorService liveAnchorService,
            IOrderRemarkService orderRemarkService,
            IEmployeeBindLiveAnchorService employeeBindLiveAnchorService,
            IHospitalCustomerInfoService hospitalCustomerInfoService,
            IHospitalInfoService hospitalInfoService,
            IHospitalBindCustomerService hospitalBindCustomerService,
            IShoppingCartRegistrationService shoppingCartRegistration,
            IBindCustomerServiceService bindCustomerServiceService,
            IContentPlatformService contentPlatformService,
            IUnitOfWork unitOfWork,
            IAmiyaGoodsDemandService amiyaGoodsDemandService,
            IAmiyaEmployeeService amiyaEmployeeService,
            IOrderCheckPictureService orderCheckPictureService,
            IContentPlatformOrderSendService contentPlatformOrderSend,
            IContentPlatFormCustomerPictureService contentPlatFormCustomerPictureService,
            IAmiyaHospitalDepartmentService departmentService,
            IContentPlatFormOrderDealInfoService contentPlatFormOrderDalService,
             IDalBindCustomerService dalBindCustomerService,
             IDalConfig dalConfig,
             IWxAppConfigService wxAppConfigService, IDalLiveAnchor dalLiveAnchor, IDalContentPlatFormOrderDealInfo dalContentPlatFormOrderDealInfo, IDalCompanyBaseInfo dalCompanyBaseInfo, IDalAmiyaHospitalDepartment dalAmiyaHospitalDepartment, IDalHospitalInfo dalHospitalInfo, ICustomerAppointmentScheduleService customerAppointmentScheduleService, IDalContentPlatformOrderSend dalContentPlatformOrderSend)
        {
            _dalContentPlatformOrder = dalContentPlatformOrder;
            this.unitOfWork = unitOfWork;
            this.liveAnchorWeChatInfoService = liveAnchorWeChatInfoService;
            this.hospitalBindCustomerService = hospitalBindCustomerService;
            _shoppingCartRegistration = shoppingCartRegistration;
            this.hospitalCustomerInfoService = hospitalCustomerInfoService;
            this.bindCustomerServiceService = bindCustomerServiceService;
            _dalBindCustomerService = dalBindCustomerService;
            this.orderRemarkService = orderRemarkService;
            _departmentService = departmentService;
            this.recommandDocumentSettleService = recommandDocumentSettleService;
            this.amiyaGoodsDemandService = amiyaGoodsDemandService;
            this.employeeBindLiveAnchorService = employeeBindLiveAnchorService;
            _liveAnchorService = liveAnchorService;
            _contentPlatformService = contentPlatformService;
            _amiyaEmployeeService = amiyaEmployeeService;
            _dalConfig = dalConfig;
            _contentPlatformOrderSend = contentPlatformOrderSend;
            _orderCheckPictureService = orderCheckPictureService;
            _hospitalInfoService = hospitalInfoService;
            _dalAmiyaEmployee = dalAmiyaEmployee;
            _wxAppConfigService = wxAppConfigService;
            _contentPlatFormCustomerPictureService = contentPlatFormCustomerPictureService;
            _contentPlatFormOrderDalService = contentPlatFormOrderDalService;
            this.dalLiveAnchor = dalLiveAnchor;
            this.dalContentPlatFormOrderDealInfo = dalContentPlatFormOrderDealInfo;
            this.dalCompanyBaseInfo = dalCompanyBaseInfo;
            this.dalAmiyaHospitalDepartment = dalAmiyaHospitalDepartment;
            this.dalHospitalInfo = dalHospitalInfo;
            this.customerAppointmentScheduleService = customerAppointmentScheduleService;
            this.dalContentPlatformOrderSend = dalContentPlatformOrderSend;
        }

        /// <summary>
        /// 录单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task AddContentPlateFormOrderAsync(ContentPlateFormOrderAddDto input)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var contentPlatForm = await _contentPlatformService.GetByIdAsync(input.ContentPlateFormId);
                //验证手机号是否有归属
                if (string.IsNullOrEmpty(input.Phone))
                {
                    throw new Exception("该订单没有手机号，不能绑定客服");
                }
                var bind = await _dalBindCustomerService.GetAll()
                  .Include(e => e.CustomerServiceAmiyaEmployee)
                  .FirstOrDefaultAsync(e => e.BuyerPhone == input.Phone);
                if (bind != null)
                {
                    if (bind.CustomerServiceId != input.EmployeeId)
                    {
                        var employee = await _dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == input.EmployeeId);
                        if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                        {
                            throw new Exception("该客户已绑定给" + bind.CustomerServiceAmiyaEmployee.Name + ",请联系对应人员进行操作！");
                        }
                    }
                    else
                    {
                        bind.NewConsumptionDate = DateTime.Now;
                        bind.NewConsumptionContentPlatform = (int)OrderFrom.ContentPlatFormOrder;
                        bind.NewContentPlatForm = contentPlatForm.ContentPlatformName;
                        bind.NewLiveAnchor = dalLiveAnchor.GetAll().Where(e => e.Id == input.LiveAnchorId).FirstOrDefault().Name;
                        bind.NewWechatNo = input.LiveAnchorWeChatNo;
                        await _dalBindCustomerService.UpdateAsync(bind, true);
                    }
                }
                else
                {

                    BindCustomerService bindCustomerService = new BindCustomerService();
                    bindCustomerService.CustomerServiceId = input.EmployeeId;
                    bindCustomerService.BuyerPhone = input.Phone;
                    bindCustomerService.UserId = null;
                    bindCustomerService.CreateBy = input.EmployeeId;
                    bindCustomerService.CreateDate = DateTime.Now;
                    var goodsInfo = await amiyaGoodsDemandService.GetByIdAsync(input.GoodsId);
                    bindCustomerService.FirstProjectDemand = "(" + goodsInfo.HospitalDepartmentName + ")" + goodsInfo.ProjectNname;
                    bindCustomerService.FirstConsumptionDate = DateTime.Now;
                    bindCustomerService.NewConsumptionDate = DateTime.Now;
                    bindCustomerService.NewConsumptionContentPlatform = (int)OrderFrom.ContentPlatFormOrder;
                    bindCustomerService.NewContentPlatForm = contentPlatForm.ContentPlatformName;
                    var liveAnchor = dalLiveAnchor.GetAll().Where(e => e.Id == input.LiveAnchorId).FirstOrDefault();
                    if (liveAnchor != null)
                    {
                        bindCustomerService.NewLiveAnchor = liveAnchor.Name;
                    }
                    bindCustomerService.NewWechatNo = input.LiveAnchorWeChatNo;
                    bindCustomerService.AllPrice = 0;
                    bindCustomerService.AllOrderCount = 0;
                    await _dalBindCustomerService.AddAsync(bindCustomerService, true);
                }

                ContentPlatformOrder order = new ContentPlatformOrder();
                order.Id = input.Id;
                order.OrderType = input.OrderType;
                order.ContentPlateformId = input.ContentPlateFormId;
                order.LiveAnchorId = input.LiveAnchorId;
                order.LiveAnchorWeChatNo = input.LiveAnchorWeChatNo;
                order.CreateDate = input.CreateDate;
                order.GoodsId = input.GoodsId;
                order.ConsultationType = input.ConsultationType;
                order.CustomerName = input.CustomerName;
                order.AddOrderPrice = input.AddOrderPrice;
                order.BelongMonth = input.BelongMonth;
                order.OrderSource = input.OrderSource;
                order.UnSendReason = input.UnSendReason;
                order.ConsultationEmpId = input.ConsultationEmpId;
                order.IsSupportOrder = input.IsSupportOrder;
                order.SupportEmpId = input.SupportEmpId;
                order.AcceptConsulting = input.AcceptConsulting;
                order.HospitalDepartmentId = input.HospitalDepartmentId;
                order.Phone = input.Phone;
                order.AppointmentDate = input.AppointmentDate;
                order.AppointmentHospitalId = input.AppointmentHospitalId;
                order.OrderStatus = input.OrderStatus;
                order.DepositAmount = input.DepositAmount;
                order.DealAmount = 0;
                order.DealPictureUrl = "";
                order.RepeatOrderPictureUrl = "";
                order.UnDealReason = "";
                order.LateProjectStage = input.LateProjectStage;
                order.ConsultingContent = input.ConsultingContent;
                order.Remark = input.Remark;
                order.CheckBy = 0;
                order.CheckPrice = 0.00M;
                order.CheckState = 0;
                order.SettlePrice = 0.00M;
                order.BelongEmpId = input.EmployeeId;
                order.IsRepeatProfundityOrder = false;
                await _dalContentPlatformOrder.AddAsync(order, true);

                foreach (var z in input.CustomerPictures)
                {
                    AddContentPlatFormCustomerPictureDto addPicture = new AddContentPlatFormCustomerPictureDto();
                    addPicture.ContentPlatFormOrderId = order.Id;
                    addPicture.CustomerPicture = z;
                    addPicture.Description = "顾客照片";
                    await _contentPlatFormCustomerPictureService.AddAsync(addPicture);
                }

                //小黄车更新录单触达
                await _shoppingCartRegistration.UpdateCreateOrderAsync(input.Phone);

                //订单备注新增数据
                if (!string.IsNullOrEmpty(order.Remark))
                {

                    AddOrderRemarkDto addOrderRemarkDto = new AddOrderRemarkDto();
                    addOrderRemarkDto.OrderId = order.Id;
                    addOrderRemarkDto.Remark = order.Remark;
                    addOrderRemarkDto.CreateBy = order.BelongEmpId.Value;
                    addOrderRemarkDto.BelongAuthorize = (int)AuthorizeStatusEnum.InternalAuthorize;
                    await orderRemarkService.AddAsync(addOrderRemarkDto);
                }

                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception(err.Message.ToString());
            }
        }

        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="writeOffStartDate"></param>
        /// <param name="writeOffEndDate"></param>
        /// <param name="keyword"></param>
        /// <param name="statusCode"></param>
        /// <param name="appType"></param>
        /// <param name="consultationType">面诊状态</param>
        /// <param name="employeeId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<ContentPlatFormOrderInfoDto>> GetOrderListWithPageAsync(int? liveAnchorId, DateTime? startDate, DateTime? endDate, int? belongMonth, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, int? appointmentHospital, int? consultationType, string hospitalDepartmentId, string keyword, int? orderStatus, string contentPlateFormId, int? belongEmpId, int employeeId, int orderSource, int pageNum, int pageSize)
        {
            try
            {
                List<int> liveAnchorIds = new List<int>();
                if (liveAnchorId.HasValue)
                {
                    liveAnchorIds.Add(liveAnchorId.Value);
                }
                else
                {
                    var empInfo = await _amiyaEmployeeService.GetByIdAsync(employeeId);
                    if (empInfo.PositionId == 19 || empInfo.PositionId == 30)
                    //if (empInfo.PositionId == 19)
                    {
                        var bindLiveAnchorInfo = await employeeBindLiveAnchorService.GetByEmpIdAsync(employeeId);
                        foreach (var x in bindLiveAnchorInfo)
                        {
                            liveAnchorIds.Add(x.LiveAnchorId);
                        }
                    }
                }
                var orders = from d in _dalContentPlatformOrder.GetAll()
                             where (string.IsNullOrWhiteSpace(keyword) || d.Id.Contains(keyword) || d.ConsultingContent.Contains(keyword) || d.CustomerName.Contains(keyword) || d.AcceptConsulting.Contains(keyword) || d.Remark.Contains(keyword) || d.LiveAnchorWeChatNo.Contains(keyword)
                             || d.Phone.Contains(keyword))
                             && (orderStatus == null || d.OrderStatus == orderStatus)
                             && (!appointmentHospital.HasValue || d.AppointmentHospitalId == appointmentHospital)
                             && (!belongMonth.HasValue || d.BelongMonth == belongMonth)
                             && (!minAddOrderPrice.HasValue || d.AddOrderPrice >= minAddOrderPrice)
                             && (!maxAddOrderPrice.HasValue || d.AddOrderPrice <= maxAddOrderPrice)
                             && (!consultationType.HasValue || d.ConsultationType == consultationType)
                             && (!belongEmpId.HasValue || d.BelongEmpId == belongEmpId)
                             && (orderSource == -1 || d.OrderSource == orderSource)
                             && (string.IsNullOrWhiteSpace(hospitalDepartmentId) || d.HospitalDepartmentId == hospitalDepartmentId)
                             && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorId.Value))
                             && (string.IsNullOrEmpty(contentPlateFormId) || d.ContentPlateformId == contentPlateFormId)
                             select d;

                if (startDate != null && endDate != null)
                {
                    DateTime startrq = ((DateTime)startDate);
                    DateTime endrq = ((DateTime)endDate).AddDays(1);
                    orders = from d in orders
                             where d.CreateDate >= startrq && d.CreateDate < endrq
                             select d;
                }

                var employee = await _dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                //普通客服角色过滤其他订单信息只展示自己录单信息
                if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                {
                    orders = from d in orders
                             where _dalBindCustomerService.GetAll().Count(e => e.CustomerServiceId == employeeId && e.BuyerPhone == d.Phone) > 0 || d.SupportEmpId == employeeId || d.BelongEmpId == employeeId
                             where (d.IsSupportOrder == false || d.SupportEmpId == employeeId)
                             select d;
                }
                var config = await _wxAppConfigService.GetWxAppCallCenterConfigAsync();
                var order = from d in orders
                            select new ContentPlatFormOrderInfoDto
                            {
                                Id = d.Id,
                                OrderType = d.OrderType,
                                OrderTypeText = d.OrderType != 0 ? ServiceClass.GetContentPlateFormOrderTypeText((byte)d.OrderType) : "",
                                ContentPlateformId = d.ContentPlateformId,
                                ContentPlatformName = d.Contentplatform.ContentPlatformName,
                                LiveAnchorId = d.LiveAnchorId,
                                LiveAnchorName = d.LiveAnchor.HostAccountName,
                                ConsultationTypeText = ServiceClass.GetContentPlateFormOrderConsultationTypeText(d.ConsultationType),
                                LiveAnchorWeChatNo = d.LiveAnchorWeChatNo,
                                CreateDate = d.CreateDate,
                                BelongMonth = d.BelongMonth,
                                AddOrderPrice = d.AddOrderPrice,
                                CustomerName = ServiceClass.GetIncompleteCustomerName(d.CustomerName),
                                Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                AppointmentDate = d.AppointmentDate,
                                AppointmentHospitalId = d.AppointmentHospitalId,
                                AppointmentHospitalName = d.HospitalInfo.Name,
                                GoodsId = d.GoodsId,
                                IsSupportOrder = d.IsSupportOrder,
                                SupportEmpId = d.SupportEmpId,
                                ConsultationType = d.ConsultationType,
                                GoodsName = d.AmiyaGoodsDemand.ProjectNname,
                                GoodsDepartmentId = d.HospitalDepartmentId,
                                ThumbPictureUrl = d.AmiyaGoodsDemand.ThumbPictureUrl,
                                ConsultingContent = d.ConsultingContent,
                                OrderStatus = d.OrderStatus,
                                OrderStatusText = d.OrderStatus != 0 ? ServiceClass.GetContentPlateFormOrderStatusText((byte)d.OrderStatus) : "",
                                DepositAmount = d.DepositAmount,
                                DealAmount = d.DealAmount,
                                DealDate = d.DealDate,
                                UnDealReason = d.UnDealReason,
                                LateProjectStage = d.LateProjectStage,
                                Remark = d.Remark,
                                IsToHospital = d.IsToHospital,
                                ToHospitalDate = d.ToHospitalDate,
                                LastDealHospitalId = d.LastDealHospitalId,
                                BelongEmpId = d.BelongEmpId,
                                UnSendReason = d.UnSendReason,
                                OrderSource = d.OrderSource,
                                OrderSourceText = ServiceClass.GerContentPlatFormOrderSourceText(d.OrderSource.Value),
                                AcceptConsulting = d.AcceptConsulting,
                                CheckStateText = d.CheckState.HasValue ? ServiceClass.GetCheckTypeText(d.CheckState.Value) : "未审核",
                                CheckState = d.CheckState,
                                CheckDate = d.CheckDate,
                                CheckBy = d.CheckBy,
                                CheckPrice = d.CheckPrice,
                                CheckRemark = d.CheckRemark,
                                OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                                SettlePrice = d.SettlePrice,
                                ReturnBackPrice = d.ReturnBackPrice,
                                IsReturnBackPrice = d.IsReturnBackPrice,
                                ReturnBackDate = d.ReturnBackDate,
                                IsRepeatProfundityOrder = d.IsRepeatProfundityOrder
                            };


                FxPageInfo<ContentPlatFormOrderInfoDto> orderPageInfo = new FxPageInfo<ContentPlatFormOrderInfoDto>();
                orderPageInfo.TotalCount = await order.CountAsync();
                orderPageInfo.List = await order.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                foreach (var x in orderPageInfo.List)
                {
                    if (x.BelongEmpId != 0)
                    {
                        var empInfo = await _dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == x.BelongEmpId);
                        x.BelongEmpName = empInfo.Name.ToString();
                    }
                    if (x.SupportEmpId != 0)
                    {
                        var empInfo = await _dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == x.SupportEmpId);
                        x.SupportEmpName = empInfo.Name.ToString();
                    }
                    if (!string.IsNullOrEmpty(x.GoodsDepartmentId))
                    {
                        var departmentInfo = await _departmentService.GetByIdAsync(x.GoodsDepartmentId);
                        x.DepartmentName = departmentInfo.DepartmentName;
                    }
                    if (!string.IsNullOrEmpty(x.LiveAnchorWeChatNo))
                    {
                        var wechatNoInfo = await liveAnchorWeChatInfoService.GetByIdAsync(x.LiveAnchorWeChatNo);
                        if (wechatNoInfo.Id != null)
                        {
                            x.LiveAnchorWeChatNo = wechatNoInfo.WeChatNo;
                        }
                    }
                    //if (x.CheckBy.HasValue && x.CheckBy != 0)
                    //{
                    //    var empInfo = await _dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == x.CheckBy);
                    //    x.CheckByName = empInfo.Name.ToString();
                    //}
                    //if (x.LastDealHospitalId.HasValue && x.LastDealHospitalId != 0)
                    //{
                    //    var hospitalInfo = await _hospitalInfoService.GetBaseByIdAsync(x.LastDealHospitalId.Value);
                    //    x.LastDealHospital = hospitalInfo.Name;
                    //}

                    //if (x.OrderStatus != (int)ContentPlateFormOrderStatus.HaveOrder)
                    //{
                    //    var sendOrderInfoList = await _contentPlatformOrderSend.GetSendOrderInfoByOrderId(x.Id);
                    //    var sendOrderInfo = sendOrderInfoList.OrderByDescending(z => z.SendDate).FirstOrDefault();
                    //    if (sendOrderInfo != null)
                    //    {
                    //        x.SendDate = sendOrderInfo.SendDate;
                    //        var empInfo = await _dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == sendOrderInfo.Sender);
                    //        x.Sender = empInfo.Name;
                    //    }
                    //}
                }
                return orderPageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 获取未派单订单列表
        /// </summary>
        /// <param name="liveAnchorId">归属主播id</param>
        /// <param name="keyword">关键词</param>
        /// <param name="contentPlateFormId">内容平台</param>
        /// <param name="employeeId">员工id（-1查询所有）</param>
        /// <param name="orderStatus">订单状态</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<UnSendContentPlatFormOrderInfoDto>> GetUnSendOrderListWithPageAsync(int? liveAnchorId, string keyword, DateTime? startDate, DateTime? endDate, int? consultationEmpId, int employeeId, int statusCode, string contentPlatFormId, int orderSource, int pageNum, int pageSize)
        {
            var config = await GetCallCenterConfig();

            var orders = from o in _dalContentPlatformOrder.GetAll()
                         where o.OrderStatus == Convert.ToInt16(ContentPlateFormOrderStatus.HaveOrder) || o.OrderStatus == Convert.ToInt16(ContentPlateFormOrderStatus.RepeatOrder)
                         select o;

            if (statusCode != 0)
            {
                orders = from o in orders
                         where o.OrderStatus == statusCode
                         select o;
            }
            if (!string.IsNullOrEmpty(contentPlatFormId))
            {
                orders = from o in orders

                         where o.ContentPlateformId == contentPlatFormId
                         select o;
            }
            if (startDate.HasValue && endDate.HasValue)
            {
                DateTime startrq = startDate.Value;
                DateTime endrq = ((DateTime)endDate).AddDays(1);
                orders = from o in orders
                         where o.CreateDate >= startrq && o.CreateDate <= endrq
                         select o;
            }
            var employee = await _amiyaEmployeeService.GetByIdAsync(employeeId);
            if (employee.IsCustomerService && !employee.IsDirector)
            {
                orders = from d in orders
                         where _dalBindCustomerService.GetAll().Count(e => e.CustomerServiceId == employeeId && e.BuyerPhone == d.Phone) > 0 || d.SupportEmpId == employeeId || d.BelongEmpId == employeeId
                         where (d.IsSupportOrder == false || d.SupportEmpId == employeeId)
                         select d;
            }
            var unSendOrder = from o in orders
                              join b in _dalBindCustomerService.GetAll() on o.Phone equals b.BuyerPhone
                              where o.ContentPlatformOrderSendList.Count(e => e.ContentPlatformOrderId == o.Id) == 0
                              && (keyword == null || o.Id == keyword || o.Phone == keyword || o.AmiyaGoodsDemand.ProjectNname.Contains(keyword) || o.HospitalInfo.Name.Contains(keyword))
                              && (orderSource == -1 || o.OrderSource == orderSource)
                              && (!liveAnchorId.HasValue || o.LiveAnchorId == liveAnchorId.Value)
                              orderby b.CreateDate descending
                              select new UnSendContentPlatFormOrderInfoDto
                              {
                                  OrderId = o.Id,
                                  ContentPlatFormName = o.Contentplatform.ContentPlatformName,
                                  LiveAnchorName = o.LiveAnchor.HostAccountName,
                                  GoodsName = o.AmiyaGoodsDemand.ProjectNname,
                                  ThumbPictureUrl = o.AmiyaGoodsDemand.ThumbPictureUrl,
                                  ConsultingContent = o.ConsultingContent,
                                  CreateDate = o.CreateDate,
                                  CustomerName = ServiceClass.GetIncompleteCustomerName(o.CustomerName),
                                  Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(o.Phone) : o.Phone,
                                  EncryptPhone = ServiceClass.Encrypt(o.Phone, config.PhoneEncryptKey),
                                  DealAmount = o.DealAmount,
                                  DepositAmount = o.DepositAmount.HasValue ? o.DepositAmount : 0,
                                  OrderTypeText = ServiceClass.GetContentPlateFormOrderTypeText(Convert.ToByte(o.OrderType)),
                                  OrderStatusText = ServiceClass.GetContentPlateFormOrderStatusText(Convert.ToByte(o.OrderStatus)),
                                  AppointmentHospital = o.HospitalInfo.Name,
                                  AppointmentDate = o.AppointmentDate.HasValue ? o.AppointmentDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "未确认时间",
                                  Remark = o.Remark,
                                  ConsultationType = o.ConsultationType,
                                  ConsultationTypeText = ServiceClass.GetContentPlateFormOrderConsultationTypeText(o.ConsultationType),
                                  LateProjectStage = o.LateProjectStage,
                                  UnSendReason = o.UnSendReason,
                                  OrderSourceText = ServiceClass.GerContentPlatFormOrderSourceText(o.OrderSource.Value)
                              };

            FxPageInfo<UnSendContentPlatFormOrderInfoDto> pageInfo = new FxPageInfo<UnSendContentPlatFormOrderInfoDto>();
            pageInfo.TotalCount = await unSendOrder.CountAsync();
            pageInfo.List = await unSendOrder.OrderByDescending(z => z.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return pageInfo;
        }


        /// <summary>
        /// 获取内容平台订单已派单七/十五/三十日信息列表
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public async Task<List<ContentPlatFormOrderInfoDto>> GetSendOrderByDateList(int days)
        {
            List<ContentPlatFormOrderInfoDto> result = new List<ContentPlatFormOrderInfoDto>();
            var orders = _dalContentPlatformOrder.GetAll();
            DateTime startrq = DateTime.Now.Date.AddDays(-days);
            DateTime endrq = DateTime.Now.Date.AddDays(-days + 1);
            orders = from d in orders
                     where (d.OrderStatus == (int)ContentPlateFormOrderStatus.SendOrder || d.OrderStatus == (int)ContentPlateFormOrderStatus.ConfirmOrder)
                     where (d.SendDate.Value >= startrq && d.SendDate.Value < endrq)
                     select d;
            var contentPlatformOrders = from d in orders
                                        select new ContentPlatFormOrderInfoDto
                                        {
                                            Id = d.Id,
                                            IsSupportOrder = d.IsSupportOrder,
                                            BelongEmpId = d.BelongEmpId,
                                            SupportEmpId = d.SupportEmpId,

                                        };
            result = contentPlatformOrders.ToList();
            return result;
        }



        /// <summary>
        /// 获取内容平台订单已成交三十/四十五/六十/九十日信息列表
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public async Task<List<ContentPlatFormOrderInfoDto>> GetOrderDealByDateList(int days)
        {
            List<ContentPlatFormOrderInfoDto> result = new List<ContentPlatFormOrderInfoDto>();
            var orders = _dalContentPlatformOrder.GetAll();
            DateTime startrq = DateTime.Now.Date.AddDays(-days);
            DateTime endrq = DateTime.Now.Date.AddDays(-days + 1);
            orders = from d in orders
                     where (d.IsOldCustomer == false)
                     where (d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete)
                     where (d.DealDate.Value >= startrq && d.DealDate.Value < endrq)
                     select d;
            var contentPlatformOrders = from d in orders
                                        select new ContentPlatFormOrderInfoDto
                                        {
                                            Id = d.Id,
                                            IsSupportOrder = d.IsSupportOrder,
                                            BelongEmpId = d.BelongEmpId,
                                            SupportEmpId = d.SupportEmpId,

                                        };
            result = contentPlatformOrders.ToList();
            return result;
        }

        /// <summary>
        /// 获取未派单订单报表
        /// </summary>
        /// <param name="liveAnchorId">归属主播id</param>
        /// <param name="keyword">关键词</param>
        /// <param name="contentPlateFormId">内容平台</param>
        /// <param name="employeeId">员工id（-1查询所有）</param>
        /// <param name="orderStatus">订单状态</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<UnSendContentPlatFormOrderInfoDto>> GetUnSendOrderReportListAsync(int? liveAnchorId, DateTime? startDate, DateTime? endDate, int employeeId, int statusCode, string contentPlatFormId, bool isHidePhone)
        {

            var orders = from o in _dalContentPlatformOrder.GetAll()
                         where o.OrderStatus == Convert.ToInt16(ContentPlateFormOrderStatus.HaveOrder) || o.OrderStatus == Convert.ToInt16(ContentPlateFormOrderStatus.RepeatOrder)
                         select o;

            if (statusCode != 0)
            {
                orders = from o in orders
                         where o.OrderStatus == statusCode
                         select o;
            }
            if (!string.IsNullOrEmpty(contentPlatFormId))
            {
                orders = from o in orders

                         where o.ContentPlateformId == contentPlatFormId
                         select o;
            }
            if (startDate.HasValue && endDate.HasValue)
            {
                DateTime startrq = startDate.Value;
                DateTime endrq = ((DateTime)endDate).AddDays(1);
                orders = from o in orders
                         where o.CreateDate >= startrq && o.CreateDate <= endrq
                         select o;
            }
            var unSendOrder = from o in orders
                              where o.ContentPlatformOrderSendList.Count(e => e.ContentPlatformOrderId == o.Id) == 0
                              && (employeeId == -1 || o.BelongEmpId == employeeId)
                              && (!liveAnchorId.HasValue || o.LiveAnchorId == liveAnchorId.Value)
                              orderby o.CreateDate descending
                              select new UnSendContentPlatFormOrderInfoDto
                              {
                                  OrderId = o.Id,
                                  ContentPlatFormName = o.Contentplatform.ContentPlatformName,
                                  LiveAnchorName = o.LiveAnchor.HostAccountName,
                                  GoodsName = o.AmiyaGoodsDemand.ProjectNname,
                                  ThumbPictureUrl = o.AmiyaGoodsDemand.ThumbPictureUrl,
                                  ConsultingContent = o.ConsultingContent,
                                  CreateDate = o.CreateDate,
                                  CustomerName = o.CustomerName,
                                  Phone = isHidePhone == true ? ServiceClass.GetIncompletePhone(o.Phone) : o.Phone,
                                  DealAmount = o.DealAmount,
                                  DepositAmount = o.DepositAmount.HasValue ? o.DepositAmount : 0,
                                  OrderTypeText = ServiceClass.GetContentPlateFormOrderTypeText(Convert.ToByte(o.OrderType)),
                                  OrderStatusText = ServiceClass.GetContentPlateFormOrderStatusText(Convert.ToByte(o.OrderStatus)),
                                  AppointmentHospital = o.HospitalInfo.Name,
                                  Remark = o.Remark,
                                  LateProjectStage = o.LateProjectStage,
                                  BelongEmpId = o.BelongEmpId.Value
                              };

            List<UnSendContentPlatFormOrderInfoDto> pageInfo = new List<UnSendContentPlatFormOrderInfoDto>();
            pageInfo = await unSendOrder.OrderByDescending(z => z.CreateDate).ToListAsync();
            foreach (var x in pageInfo)
            {
                if (x.BelongEmpId != 0)
                {
                    var empInfo = await _dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == x.BelongEmpId);
                    if (empInfo.Id != 0)
                    {
                        x.BelongEmpName = empInfo.Name;
                    }
                }
            }
            return pageInfo;
        }

        /// <summary>
        /// 派单
        /// </summary>
        /// <param name="addDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task SendOrderAsync(AddContentPlatFormSendOrderInfoDto addDto)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var orderInfo = await this.GetByOrderIdAsync(addDto.OrderId);
                var phone = orderInfo.Phone;
                var hasOrder = await this.GetOrderListByPhoneAsync(phone);
                List<string> OrderIds = new List<string>();
                foreach (var x in hasOrder)
                {
                    OrderIds.Add(x.Id);
                }
                //var sendInfo = await _contentPlatformOrderSend.GetSendOrderInfoByOrderId(OrderIds);
                //var IsHasThisHospital = sendInfo.Where(x => x.HospitalId == addDto.HospitalId).ToList();
                //if (IsHasThisHospital.Count != 0)
                //{
                //    throw new Exception("该客户已有订单派单到此医院，请重新选择派单医院！");
                //}
                await _contentPlatformOrderSend.AddAsync(addDto);
                var contentPlatFormOrder = await this.GetByOrderIdAsync(addDto.OrderId);
                //修改订单状态
                await this.UpdateStateAndRepeateOrderPicAsync(addDto.OrderId, addDto.SendBy, contentPlatFormOrder.BelongEmpId, addDto.EmployeeId);

                //当派单为新医院时更新医院接单人数据
                //await hospitalBindCustomerService.UpdateBindCustomerToZeroAsync(contentPlatFormOrder.Phone);

                //小黄车更新派单触达
                await _shoppingCartRegistration.UpdateSendOrderAsync(orderInfo.Phone);


                //获取医院客户列表
                var customer = await hospitalCustomerInfoService.GetByHospitalIdAndPhoneAsync(addDto.HospitalId, orderInfo.Phone);
                //操作医院客户表
                if (!string.IsNullOrEmpty(customer.Id))
                {
                    UpdateSendHospitalCustomerInfoDto updateSendHospitalCustomerInfoDto = new UpdateSendHospitalCustomerInfoDto();
                    updateSendHospitalCustomerInfoDto.Id = customer.Id;
                    updateSendHospitalCustomerInfoDto.NewGoodsDemand = orderInfo.GoodsName;
                    updateSendHospitalCustomerInfoDto.hospitalId = addDto.HospitalId;
                    updateSendHospitalCustomerInfoDto.SendAmount += 1;
                    await hospitalCustomerInfoService.InsertSendAmountAsync(updateSendHospitalCustomerInfoDto);
                }
                else
                {
                    AddSendHospitalCustomerInfoDto addSendHospitalCustomerInfoDto = new AddSendHospitalCustomerInfoDto();
                    addSendHospitalCustomerInfoDto.NewGoodsDemand = orderInfo.GoodsName;
                    addSendHospitalCustomerInfoDto.SendAmount = 1;
                    addSendHospitalCustomerInfoDto.CustomerPhone = orderInfo.Phone;
                    addSendHospitalCustomerInfoDto.hospitalId = addDto.HospitalId;
                    addSendHospitalCustomerInfoDto.DealAmount = 0;
                    await hospitalCustomerInfoService.AddAsync(addSendHospitalCustomerInfoDto);

                }
                //完成视频预约到诊
                await customerAppointmentScheduleService.UpdateAppointmentCompleteStatusAsync(phone, (int)AppointmentType.VideoAppointment);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }


        /// <summary>
        /// 修改派单
        /// </summary>
        /// <param name="updateDto"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateContentPlatFormSendOrderInfoDto updateDto, int employeeId)
        {
            try
            {
                unitOfWork.BeginTransaction();

                await _contentPlatformOrderSend.UpdateOrderSend(updateDto, employeeId);
                //修改订单状态
                var send = await _contentPlatformOrderSend.GetSimpleByIdAsync(updateDto.Id);
                var contentPlatFormOrder = await this.GetByOrderIdAsync(updateDto.OrderId);
                //重置机构接单人
                // await hospitalBindCustomerService.UpdateBindCustomerToZeroAsync(contentPlatFormOrder.Phone);
                await this.UpdateStateAndRepeateOrderPicAsync(updateDto.OrderId, send.SendBy, contentPlatFormOrder.BelongEmpId, employeeId);

                var customer = await hospitalCustomerInfoService.GetByHospitalIdAndPhoneAsync(updateDto.HospitalId, contentPlatFormOrder.Phone);
                //操作医院客户表
                if (!string.IsNullOrEmpty(customer.Id))
                {
                    UpdateSendHospitalCustomerInfoDto updateSendHospitalCustomerInfoDto = new UpdateSendHospitalCustomerInfoDto();
                    updateSendHospitalCustomerInfoDto.Id = customer.Id;
                    updateSendHospitalCustomerInfoDto.NewGoodsDemand = contentPlatFormOrder.GoodsName;
                    updateSendHospitalCustomerInfoDto.hospitalId = updateDto.HospitalId;
                    updateSendHospitalCustomerInfoDto.SendAmount += 1;
                    await hospitalCustomerInfoService.InsertSendAmountAsync(updateSendHospitalCustomerInfoDto);
                }
                else
                {
                    AddSendHospitalCustomerInfoDto addSendHospitalCustomerInfoDto = new AddSendHospitalCustomerInfoDto();
                    addSendHospitalCustomerInfoDto.NewGoodsDemand = contentPlatFormOrder.GoodsName;
                    addSendHospitalCustomerInfoDto.SendAmount = 1;
                    addSendHospitalCustomerInfoDto.CustomerPhone = contentPlatFormOrder.Phone;
                    addSendHospitalCustomerInfoDto.hospitalId = updateDto.HospitalId;
                    addSendHospitalCustomerInfoDto.DealAmount = 0;
                    await hospitalCustomerInfoService.AddAsync(addSendHospitalCustomerInfoDto);

                }
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }

        /// <summary>
        /// 判断是否派单决定删除录单订单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteOrderAsync(string id)
        {
            var sendOrderInfo = await _contentPlatformOrderSend.GetSendOrderInfoByOrderId(id);
            if (sendOrderInfo.Count > 0)
            {
                throw new Exception("该订单已派单，无法删除！");
            }
            await this.DeleteAsync(id);
        }

        /// <summary>
        /// 医院接单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task HospitalConfirmOrderAsync(string orderId, int hospitalempId, int hospitalId, string netWorkConsulationName, string sceneConsulationName)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var order = await _dalContentPlatformOrder.GetAll().Include(x => x.ContentPlatformOrderSendList).Where(x => x.Id == orderId).FirstOrDefaultAsync();
                if (order == null)
                {
                    throw new Exception("未找到该订单的相关信息！");
                }
                order.OrderStatus = Convert.ToInt16(ContentPlateFormOrderStatus.ConfirmOrder);
                order.UpdateDate = DateTime.Now;
                order.NetWorkConsulationName = netWorkConsulationName;
                order.SceneConsulationName = sceneConsulationName;
                await _dalContentPlatformOrder.UpdateAsync(order, true);
                AddHospitalBindCustomerServiceDto addHospitalBindCustomerServiceDto = new AddHospitalBindCustomerServiceDto();
                addHospitalBindCustomerServiceDto.HospitalEmployeeId = hospitalempId;
                var goodsInfo = await amiyaGoodsDemandService.GetByIdAsync(order.GoodsId);
                addHospitalBindCustomerServiceDto.FirstProjectDemand = "(" + goodsInfo.HospitalDepartmentName + ")" + goodsInfo.ProjectNname;
                addHospitalBindCustomerServiceDto.CustomerPhone = order.Phone;
                var contentPlatForm = await _contentPlatformService.GetByIdAsync(order.ContentPlateformId);
                addHospitalBindCustomerServiceDto.NewContentPlatformName = contentPlatForm.ContentPlatformName;
                addHospitalBindCustomerServiceDto.hospitalId = hospitalId;
                await hospitalBindCustomerService.AddAsync(addHospitalBindCustomerServiceDto);


                //获取医院客户列表并更新查重时间
                var sendCount = order.ContentPlatformOrderSendList.Where(x => x.HospitalId == hospitalId).Count();
                if (sendCount == 0)
                {
                    throw new Exception("该顾客未派单到当前医院，请确认后重试！");
                }
                var customer = await hospitalCustomerInfoService.GetByHospitalIdAndPhoneAsync(hospitalId, order.Phone);
                UpdateSendHospitalCustomerInfoDto updateSendHospitalCustomerInfoDto = new UpdateSendHospitalCustomerInfoDto();
                updateSendHospitalCustomerInfoDto.Id = customer.Id;
                await hospitalCustomerInfoService.UpdateConfirmOrderDateAsync(updateSendHospitalCustomerInfoDto);
                unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }



        /// <summary>
        /// 修改订单归属客服
        /// </summary>
        /// <param name="updateListDto"></param>
        /// <returns></returns>
        public async Task UpdateOrderBelongEmpIdAsync(UpdateBelongEmpInfoOrderDto input)
        {
            try
            {
                unitOfWork.BeginTransaction();
                foreach (var x in input.OrderId)
                {
                    var orderInfo = await _dalContentPlatformOrder.GetAll().SingleOrDefaultAsync(e => e.Id == x);
                    if (orderInfo == null)
                    { throw new Exception("未找到该订单，归属客服失败！"); }
                    orderInfo.BelongEmpId = input.BelongEmpId;
                    await _dalContentPlatformOrder.UpdateAsync(orderInfo, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception e)
            {
                unitOfWork.RollBack();
                throw e;
            }
        }

        /// <summary>
        /// 获取已成交订单列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="liveAnchorId">主播ID</param>
        /// <param name="checkState"></param>
        /// <param name="consultationEmpId">面诊人员</param>
        /// <param name="writeOffStartDate"></param>
        /// <param name="writeOffEndDate"></param>
        /// <param name="keyword"></param>
        /// <param name="statusCode"></param>
        /// <param name="appType"></param>
        /// <param name="toHospitalType">到院类型,为空查询所有</param>
        /// <param name="employeeId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<ContentPlatFormOrderInfoDto>> GetOrderDealListWithPageAsync(int? liveAnchorId, DateTime? startDate, DateTime? endDate, int? belongMonth, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, int? consultationEmpId, int? checkState, bool? ReturnBackPriceState, string keyword, string contentPlateFormId, int? hospitalId, int? toHospitalType, int employeeId, int pageNum, int pageSize)
        {
            try
            {
                var orders = from d in _dalContentPlatformOrder.GetAll()
                             where (string.IsNullOrWhiteSpace(keyword) || d.Id.Contains(keyword) || d.ConsultingContent.Contains(keyword)
                             || d.Phone.Contains(keyword))
                             && (!liveAnchorId.HasValue || d.LiveAnchorId == liveAnchorId.Value)
                             && (!hospitalId.HasValue || d.AppointmentHospitalId == hospitalId)
                             && (!toHospitalType.HasValue || d.ToHospitalType == toHospitalType.Value)
                             && (!belongMonth.HasValue || d.BelongMonth == belongMonth.Value)
                             && (!minAddOrderPrice.HasValue || d.AddOrderPrice >= minAddOrderPrice.Value)
                             && (!maxAddOrderPrice.HasValue || d.AddOrderPrice == maxAddOrderPrice.Value)
                             && (!checkState.HasValue || d.CheckState == checkState)
                             && (!ReturnBackPriceState.HasValue || d.IsReturnBackPrice == ReturnBackPriceState)
                             && (!consultationEmpId.HasValue || d.ConsultationEmpId == consultationEmpId)
                             && (string.IsNullOrEmpty(contentPlateFormId) || d.ContentPlateformId == contentPlateFormId)
                             && (d.OrderStatus == Convert.ToInt32(ContentPlateFormOrderStatus.OrderComplete))
                             select d;

                if (startDate != null && endDate != null)
                {
                    DateTime startrq = ((DateTime)startDate);
                    DateTime endrq = ((DateTime)endDate).AddDays(1);
                    orders = from d in orders
                             where d.DealDate >= startrq && d.DealDate < endrq
                             select d;
                }

                var employee = await _dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                {
                    orders = from d in orders
                             where _dalBindCustomerService.GetAll().Count(e => e.CustomerServiceId == employeeId && e.BuyerPhone == d.Phone) > 0 || d.SupportEmpId == employeeId || d.BelongEmpId == employeeId
                             where (d.IsSupportOrder == false || d.SupportEmpId == employeeId)
                             select d;
                }

                var config = await _wxAppConfigService.GetWxAppCallCenterConfigAsync();
                var order = from d in orders
                            select new ContentPlatFormOrderInfoDto
                            {
                                Id = d.Id,
                                OrderType = d.OrderType,
                                OrderTypeText = d.OrderType != 0 ? ServiceClass.GetContentPlateFormOrderTypeText((byte)d.OrderType) : "",
                                ContentPlateformId = d.ContentPlateformId,
                                ContentPlatformName = d.Contentplatform.ContentPlatformName,
                                LiveAnchorId = d.LiveAnchorId,
                                LiveAnchorName = d.LiveAnchor.HostAccountName,
                                LiveAnchorWeChatNo = d.LiveAnchorWeChatNo,
                                CreateDate = d.CreateDate,
                                CustomerName = d.CustomerName,
                                BelongMonth = d.BelongMonth,
                                AddOrderPrice = d.AddOrderPrice,
                                IsOldCustomer = d.IsOldCustomer,
                                IsAcompanying = d.IsAcompanying,
                                Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                AppointmentDate = d.AppointmentDate,
                                ToHospitalType = d.ToHospitalType,
                                ToHospitalTypeText = ServiceClass.GerContentPlatFormOrderToHospitalTypeText(d.ToHospitalType),
                                ToHospitalDate = d.ToHospitalDate,
                                AppointmentHospitalId = d.AppointmentHospitalId,
                                AppointmentHospitalName = d.HospitalInfo.Name,
                                GoodsId = d.GoodsId,
                                GoodsName = d.AmiyaGoodsDemand.ProjectNname,
                                ThumbPictureUrl = d.AmiyaGoodsDemand.ThumbPictureUrl,
                                ConsultingContent = d.ConsultingContent,
                                ConsultationType = d.ConsultationType,
                                ConsultationTypeText = ServiceClass.GetContentPlateFormOrderConsultationTypeText(d.ConsultationType),
                                OrderStatus = d.OrderStatus,
                                OrderStatusText = d.OrderStatus != 0 ? ServiceClass.GetContentPlateFormOrderStatusText((byte)d.OrderStatus) : "",
                                DepositAmount = d.DepositAmount,
                                DealAmount = d.DealAmount,
                                DealDate = d.DealDate,
                                UnDealReason = d.UnDealReason,
                                LateProjectStage = d.LateProjectStage,
                                Remark = d.Remark,
                                CheckState = d.CheckState,
                                CheckStateText = ServiceClass.GetCheckTypeText(d.CheckState.Value),
                                CheckPrice = d.CheckPrice,
                                CheckDate = d.CheckDate,
                                CheckRemark = d.CheckRemark,
                                SettlePrice = d.SettlePrice,
                                BelongEmpId = d.BelongEmpId,
                                OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                                IsReturnBackPrice = d.IsReturnBackPrice,
                                ReturnBackDate = d.ReturnBackDate,
                                ReturnBackPrice = d.ReturnBackPrice,
                                CommissionRatio = d.CommissionRatio,
                                CustomerServiceSettlePrice = d.CustomerServiceSettlePrice
                            };


                FxPageInfo<ContentPlatFormOrderInfoDto> orderPageInfo = new FxPageInfo<ContentPlatFormOrderInfoDto>();
                orderPageInfo.TotalCount = await order.CountAsync();
                orderPageInfo.List = await order.OrderByDescending(e => e.DealDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                foreach (var x in orderPageInfo.List)
                {
                    if (x.BelongEmpId.HasValue && x.BelongEmpId > 0)
                    {
                        var empInfo = await _dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == x.BelongEmpId);
                        x.BelongEmpName = empInfo.Name.ToString();
                    }
                    if (!string.IsNullOrEmpty(x.LiveAnchorWeChatNo))
                    {
                        var wechatInfo = await liveAnchorWeChatInfoService.GetByIdAsync(x.LiveAnchorWeChatNo);
                        if (wechatInfo.Id != null)
                        {
                            x.LiveAnchorWeChatNo = wechatInfo.WeChatNo.ToString();
                        }
                    }
                }
                return orderPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取内容平台订单成交报表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="checkState"></param>
        /// <param name="employeeId"></param>
        /// <param name="hidePhone"></param>
        /// <returns></returns>
        public async Task<List<ContentPlatFormOrderInfoDto>> GetOrderDealAsync(DateTime? startDate, DateTime? endDate, int? belongMonth, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, int? dealHospitalId, int? checkState, int? liveAnchorId, bool hidePhone)
        {
            try
            {
                var orders = from d in _dalContentPlatformOrder.GetAll()
                             where (!checkState.HasValue || d.CheckState == checkState)
                             && (d.OrderStatus == Convert.ToInt32(ContentPlateFormOrderStatus.OrderComplete))
                             && (!liveAnchorId.HasValue || d.LiveAnchorId == liveAnchorId)
                             && (!dealHospitalId.HasValue || d.LastDealHospitalId == dealHospitalId)
                             && (!belongMonth.HasValue || d.BelongMonth == belongMonth)
                             && (!minAddOrderPrice.HasValue || d.AddOrderPrice >= minAddOrderPrice)
                             && (!maxAddOrderPrice.HasValue || d.AddOrderPrice <= maxAddOrderPrice)
                             select d;

                if (startDate != null && endDate != null)
                {
                    DateTime startrq = ((DateTime)startDate);
                    DateTime endrq = ((DateTime)endDate).AddDays(1);
                    orders = from d in orders
                             where d.DealDate >= startrq && d.DealDate < endrq
                             select d;
                }

                var order = from d in orders
                            select new ContentPlatFormOrderInfoDto
                            {
                                Id = d.Id,
                                OrderType = d.OrderType,
                                OrderTypeText = d.OrderType != 0 ? ServiceClass.GetContentPlateFormOrderTypeText((byte)d.OrderType) : "",
                                ContentPlateformId = d.ContentPlateformId,
                                ContentPlatformName = d.Contentplatform.ContentPlatformName,
                                LiveAnchorId = d.LiveAnchorId,
                                LiveAnchorName = d.LiveAnchor.HostAccountName,
                                LiveAnchorWeChatNo = d.LiveAnchorWeChatNo,
                                CreateDate = d.CreateDate,
                                CustomerName = d.CustomerName,
                                IsAcompanying = d.IsAcompanying,
                                Phone = hidePhone == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                AppointmentHospitalId = d.AppointmentHospitalId,
                                IsOldCustomer = d.IsOldCustomer,
                                AppointmentHospitalName = d.HospitalInfo.Name,
                                BelongMonth = d.BelongMonth,
                                AddOrderPrice = d.AddOrderPrice,
                                GoodsId = d.GoodsId,
                                GoodsName = d.AmiyaGoodsDemand.ProjectNname,
                                ConsultingContent = d.ConsultingContent,
                                ConsultationTypeText = ServiceClass.GetContentPlateFormOrderConsultationTypeText(d.ConsultationType),
                                OrderStatus = d.OrderStatus,
                                OrderStatusText = d.OrderStatus != 0 ? ServiceClass.GetContentPlateFormOrderStatusText((byte)d.OrderStatus) : "",
                                DepositAmount = d.DepositAmount,
                                DealAmount = d.DealAmount,
                                DealDate = d.DealDate,
                                UnDealReason = d.UnDealReason,
                                LateProjectStage = d.LateProjectStage,
                                LastDealHospitalId = d.LastDealHospitalId,
                                Remark = d.Remark,
                                CheckState = d.CheckState.HasValue ? d.CheckState : 0,
                                CheckStateText = ServiceClass.GetCheckTypeText(d.CheckState.Value),
                                CheckPrice = d.CheckPrice.HasValue ? d.CheckPrice : 0.00M,
                                SettlePrice = d.SettlePrice.HasValue ? d.SettlePrice : 0.00M,
                                CheckBy = d.CheckBy.HasValue ? d.CheckBy : 0,
                                CheckDate = d.CheckDate,
                                BelongEmpId = d.BelongEmpId,
                                IsReturnBackPrice = d.IsReturnBackPrice,
                                ReturnBackDate = d.ReturnBackDate,
                                ReturnBackPrice = d.ReturnBackPrice,
                                OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                                CommissionRatio = d.CommissionRatio,
                            };
                var x = await order.ToListAsync();
                foreach (var k in x)
                {

                    if (k.CheckBy.HasValue && k.CheckBy != 0)
                    {
                        var checkEmpInfo = _dalAmiyaEmployee.GetAll().FirstOrDefaultAsync(z => z.Id == k.CheckBy);
                        if (checkEmpInfo.Result != null)
                        {
                            k.CheckByName = checkEmpInfo.Result.Name;
                        }
                        else
                        {
                            k.CheckByName = "";
                        }
                    }
                    if (k.BelongEmpId.HasValue && k.BelongEmpId != 0)
                    {
                        var belongEmpInfo = _dalAmiyaEmployee.GetAll().FirstOrDefaultAsync(z => z.Id == k.BelongEmpId);
                        if (belongEmpInfo.Result != null)
                        {
                            k.BelongEmpName = belongEmpInfo.Result.Name;
                        }
                        else
                        {
                            k.BelongEmpName = "";
                        }
                    }
                    if (k.LastDealHospitalId.HasValue && k.LastDealHospitalId != 0)
                    {
                        var hospitalInfo = await _hospitalInfoService.GetBaseByIdAsync(k.LastDealHospitalId.Value);
                        if (hospitalInfo != null)
                        {
                            k.LastDealHospital = hospitalInfo.Name;
                        }
                        else
                        {
                            k.LastDealHospital = "";
                        }
                    }
                    if (!string.IsNullOrEmpty(k.LiveAnchorWeChatNo))
                    {
                        var wechatInfo = await liveAnchorWeChatInfoService.GetByIdAsync(k.LiveAnchorWeChatNo);
                        if (wechatInfo.Id != null)
                        {
                            k.LiveAnchorWeChatNo = wechatInfo.WeChatNo.ToString();
                        }
                    }
                }
                var result = x;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 导出订单列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="writeOffStartDate"></param>
        /// <param name="writeOffEndDate"></param>
        /// <param name="keyword"></param>
        /// <param name="statusCode"></param>
        /// <param name="appType"></param>
        /// <param name="employeeId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<ContentPlatFormOrderInfoDto>> ExportOrderListWithPageAsync(DateTime? startDate, DateTime? endDate, int? consultationEmpId, int? appointmentHospital, int? belongEmpId, int? liveAnchorId, string keyword, string hospitalDepartmentId, int? orderStatus, int orderSource, string contentPlateFormId, int employeeId, bool IsHidePhone)
        {
            try
            {
                var orders = from d in _dalContentPlatformOrder.GetAll().Include(x => x.ContentPlatformOrderSendList).ThenInclude(x => x.AmiyaEmployee)
                             where (string.IsNullOrWhiteSpace(keyword) || d.Id.Contains(keyword) || d.ConsultingContent.Contains(keyword)
                            || d.Phone.Contains(keyword))
                            && (orderStatus == null || d.OrderStatus == orderStatus)
                            && (!appointmentHospital.HasValue || d.AppointmentHospitalId == appointmentHospital)
                            && (!belongEmpId.HasValue || d.BelongEmpId == belongEmpId)
                            && (orderSource == -1 || d.OrderSource == orderSource)
                            && (string.IsNullOrWhiteSpace(hospitalDepartmentId) || d.HospitalDepartmentId == hospitalDepartmentId)
                            && (!liveAnchorId.HasValue || d.LiveAnchorId == liveAnchorId)
                            && (string.IsNullOrEmpty(contentPlateFormId) || d.ContentPlateformId == contentPlateFormId)
                             select d;

                if (startDate != null && endDate != null)
                {
                    DateTime startrq = ((DateTime)startDate);
                    DateTime endrq = ((DateTime)endDate).AddDays(1);
                    orders = from d in orders
                             where d.CreateDate >= startrq && d.CreateDate < endrq
                             select d;
                }

                var employee = await _dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                {
                    orders = from d in orders
                             where _dalBindCustomerService.GetAll().Count(e => e.CustomerServiceId == employeeId && e.BuyerPhone == d.Phone) > 0
                             select d;
                }

                var config = await _wxAppConfigService.GetWxAppCallCenterConfigAsync();
                if (IsHidePhone == false)
                {
                    config.HidePhoneNumber = false;

                }
                var order = from d in orders
                            select new ContentPlatFormOrderInfoDto
                            {
                                Id = d.Id,
                                OrderType = d.OrderType,
                                OrderTypeText = d.OrderType != 0 ? ServiceClass.GetContentPlateFormOrderTypeText((byte)d.OrderType) : "",
                                ContentPlateformId = d.ContentPlateformId,
                                ContentPlatformName = d.Contentplatform.ContentPlatformName,
                                LiveAnchorId = d.LiveAnchorId,
                                LiveAnchorName = d.LiveAnchor.HostAccountName,
                                CreateDate = d.CreateDate,
                                BelongMonth = d.BelongMonth,
                                AddOrderPrice = d.AddOrderPrice,
                                CustomerName = d.CustomerName,
                                Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                AppointmentDate = d.AppointmentDate,
                                AppointmentHospitalId = d.AppointmentHospitalId,
                                LiveAnchorWeChatNo = d.LiveAnchorWeChatNo,
                                IsOldCustomer = d.IsOldCustomer,
                                AppointmentHospitalName = d.HospitalInfo.Name,
                                IsToHospital = d.IsToHospital,
                                ToHospitalDate = d.ToHospitalDate,
                                ConsultationTypeText = ServiceClass.GetContentPlateFormOrderConsultationTypeText(d.ConsultationType),
                                LastDealHospitalId = d.LastDealHospitalId,
                                GoodsId = d.GoodsId,
                                GoodsDepartmentId = d.HospitalDepartmentId,
                                GoodsName = d.AmiyaGoodsDemand.ProjectNname,
                                ThumbPictureUrl = d.AmiyaGoodsDemand.ThumbPictureUrl,
                                ConsultingContent = d.ConsultingContent,
                                OrderStatus = d.OrderStatus,
                                OrderStatusText = d.OrderStatus != 0 ? ServiceClass.GetContentPlateFormOrderStatusText((byte)d.OrderStatus) : "",
                                DepositAmount = d.DepositAmount,
                                DealAmount = d.DealAmount,
                                UnDealReason = d.UnDealReason,
                                LateProjectStage = d.LateProjectStage,
                                OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                                Remark = d.Remark,
                                DealDate = d.DealDate,
                                OrderSourceText = ServiceClass.GerContentPlatFormOrderSourceText(d.OrderSource.Value),
                                UnSendReason = d.UnSendReason,
                                AcceptConsulting = d.AcceptConsulting,
                                CheckStateText = d.CheckState.HasValue ? ServiceClass.GetCheckTypeText(d.CheckState.Value) : "未审核",
                                CheckState = d.CheckState,
                                CheckDate = d.CheckDate,
                                CheckBy = d.CheckBy,
                                CheckPrice = d.CheckPrice,
                                CheckRemark = d.CheckRemark,
                                SettlePrice = d.SettlePrice,
                                BelongEmpId = d.BelongEmpId,
                                IsReturnBackPrice = d.IsReturnBackPrice,
                                ReturnBackPrice = d.ReturnBackPrice,
                                ReturnBackDate = d.ReturnBackDate,
                                SendDate = d.ContentPlatformOrderSendList.OrderByDescending(x => x.SendDate).FirstOrDefault().SendDate,
                                Sender = d.ContentPlatformOrderSendList.OrderByDescending(x => x.SendDate).FirstOrDefault().AmiyaEmployee.Name,
                                SendHospital = d.ContentPlatformOrderSendList.OrderByDescending(x => x.SendDate).FirstOrDefault().HospitalInfo.Name,
                                IsRepeatProfundityOrder = d.IsRepeatProfundityOrder
                            };
                var result = await order.OrderByDescending(e => e.CreateDate).ToListAsync();
                foreach (var x in result)
                {
                    if (x.BelongEmpId != 0)
                    {
                        var empInfo = await _dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == x.BelongEmpId);
                        x.BelongEmpName = empInfo.Name.ToString();
                    }
                    //if (x.CheckBy != 0)
                    //{
                    //    var empInfo = await _dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == x.CheckBy);
                    //    x.CheckByName = empInfo.Name.ToString();
                    //}
                    if (!string.IsNullOrEmpty(x.LiveAnchorWeChatNo))
                    {
                        var wechatInfo = await liveAnchorWeChatInfoService.GetByIdAsync(x.LiveAnchorWeChatNo);
                        if (wechatInfo.Id != null)
                        {
                            x.LiveAnchorWeChatNo = wechatInfo.WeChatNo.ToString();
                        }
                    }
                    if (!string.IsNullOrEmpty(x.GoodsDepartmentId))
                    {
                        var departmentInfo = await _departmentService.GetByIdAsync(x.GoodsDepartmentId);
                        x.DepartmentName = departmentInfo.DepartmentName;
                    }
                    if (x.LastDealHospitalId.HasValue)
                    {
                        var hospitalInfo = await _hospitalInfoService.GetBaseByIdAsync(x.LastDealHospitalId.Value);
                        x.LastDealHospital = hospitalInfo.Name;
                    }
                    //if (x.OrderStatus != (int)ContentPlateFormOrderStatus.HaveOrder)
                    //{
                    //    var sendOrderInfoList = await _contentPlatformOrderSend.GetSendOrderInfoByOrderId(x.Id);
                    //    var sendOrderInfo = sendOrderInfoList.OrderByDescending(z => z.SendDate).FirstOrDefault();
                    //    if (sendOrderInfo != null)
                    //    {
                    //        x.SendDate = sendOrderInfo.SendDate;
                    //        var empInfo = await _dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == sendOrderInfo.Sender);
                    //        x.Sender = empInfo.Name;
                    //    }
                    //}
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据编号获取要修改的内容平台订单信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ContentPlateFormOrderUpdateDto> GetByOrderIdAsync(string orderId)
        {
            var config = await _wxAppConfigService.GetWxAppCallCenterConfigAsync();
            var order = await _dalContentPlatformOrder.GetAll().Include(x => x.ContentPlatformOrderSendList).Where(x => x.Id == orderId).FirstOrDefaultAsync();
            if (order == null)
            {
                return new ContentPlateFormOrderUpdateDto();
            }
            ContentPlateFormOrderUpdateDto result = new ContentPlateFormOrderUpdateDto();
            result.Id = order.Id;
            result.OrderType = order.OrderType;
            result.ContentPlateFormId = order.ContentPlateformId;
            result.LiveAnchorId = order.LiveAnchorId == null ? 0 : order.LiveAnchorId.Value;
            if (result.LiveAnchorId != 0)
            {
                var empInfo = await _liveAnchorService.GetByIdAsync(result.LiveAnchorId);
                result.LiveAnchorName = empInfo.Name;
            }
            result.GoodsId = order.GoodsId;
            result.HospitalDepartmentId = order.HospitalDepartmentId;
            result.CustomerName = order.CustomerName;
            result.Phone = order.Phone;
            result.EncryptPhone = ServiceClass.Encrypt(order.Phone, config.PhoneEncryptKey);
            var bindCustomerServiceInfo = await bindCustomerServiceService.GetEmployeeDetailsByPhoneAsync(order.Phone);
            result.UserId = bindCustomerServiceInfo.UserId;
            result.CreateDate = order.CreateDate;
            result.LiveAnchorBaseWechatId = order.LiveAnchorWeChatNo;
            if (!string.IsNullOrEmpty(order.LiveAnchorWeChatNo))
            {
                var wechatInfo = await liveAnchorWeChatInfoService.GetByIdAsync(order.LiveAnchorWeChatNo);
                if (wechatInfo.Id != null)
                {
                    result.LiveAnchorWeChatNo = wechatInfo.WeChatNo;
                }

            }
            result.IsOldCustomer = order.IsOldCustomer;
            result.IsAcompanying = order.IsAcompanying;
            result.ConsultationTypeText = ServiceClass.GetContentPlateFormOrderConsultationTypeText(order.ConsultationType);
            result.ConsultationType = order.ConsultationType;
            result.CommissionRatio = order.CommissionRatio;
            result.BelongMonth = order.BelongMonth;
            result.IsSupportOrder = order.IsSupportOrder;
            result.SupportEmpId = order.SupportEmpId;
            if (result.SupportEmpId != 0)
            {
                var empInfo = await _amiyaEmployeeService.GetByIdAsync(result.SupportEmpId);
                result.SupportEmpName = empInfo.Name;
            }
            result.AddOrderPrice = order.AddOrderPrice;
            result.UnSendReason = order.UnSendReason;
            result.OrderTypeText = ServiceClass.GetContentPlateFormOrderTypeText((byte)order.OrderType);
            result.UpdateDate = order.UpdateDate;
            result.AppointmentDate = order.AppointmentDate;
            result.AppointmentHospitalId = order.AppointmentHospitalId == null ? 0 : order.AppointmentHospitalId.Value;
            result.DepositAmount = order.DepositAmount;
            result.ConsultingContent = order.ConsultingContent;
            result.Remark = order.Remark;
            result.ConsultationEmpId = order.ConsultationEmpId == null ? 0 : order.ConsultationEmpId.Value;
            if (result.ConsultationEmpId != 0)
            {
                var empInfo = await _amiyaEmployeeService.GetByIdAsync(result.ConsultationEmpId);
                result.ConsultationEmpName = empInfo.Name;
            }
            result.LateProjectStage = order.LateProjectStage;
            result.DealPerformanceType = order.DealPerformanceType;
            result.DealPerformanceTypeText = ServiceClass.GetContentPlateFormOrderDealPerformanceType(result.DealPerformanceType);
            result.CheckState = order.CheckState;
            result.CheckStateText = ServiceClass.GetCheckTypeText(result.CheckState.Value);
            result.CheckPrice = order.CheckPrice;
            result.IsToHospital = order.IsToHospital;
            result.ToHospitalType = order.ToHospitalType;
            result.ToHospitalTypeText = ServiceClass.GerContentPlatFormOrderToHospitalTypeText(result.ToHospitalType);
            result.UnDealPictureUrl = order.UnDealPictureUrl;
            result.DealPictureUrl = order.DealPictureUrl;
            result.ToHospitalDate = order.ToHospitalDate;
            result.IsReturnBackPrice = order.IsReturnBackPrice;
            if (result.IsReturnBackPrice == true)
            {
                result.ReturnBackPrice = order.ReturnBackPrice;
                result.ReturnBackDate = order.ReturnBackDate;
            }
            result.CheckBy = order.CheckBy;
            if (result.CheckBy.HasValue)
            {
                var empInfo = await _amiyaEmployeeService.GetByIdAsync(result.CheckBy.Value);
                result.CheckByName = empInfo.Name;
                result.CheckDate = order.CheckDate;


            }
            result.DealDate = order.DealDate;
            result.OrderStatus = order.OrderStatus;
            result.OrderStatusText = ServiceClass.GetContentPlateFormOrderStatusText((byte)order.OrderStatus);
            result.DealAmount = order.DealAmount;
            result.BelongEmpId = order.BelongEmpId;
            if (result.BelongEmpId.HasValue)
            {
                var empInfo = await _amiyaEmployeeService.GetByIdAsync(result.BelongEmpId.Value);
                result.BelongEmpName = empInfo.Name;
            }
            result.SettlePrice = order.SettlePrice;
            result.OrderSource = order.OrderSource;
            result.SceneConsulationName = order.SceneConsulationName;
            result.NetWorkConsulationName = order.NetWorkConsulationName;
            if (order.ContentPlatformOrderSendList != null)
            {
                var sendHospital = order.ContentPlatformOrderSendList.OrderByDescending(x => x.SendDate).FirstOrDefault();
                if (sendHospital != null)
                {
                    result.SendBy = sendHospital.Sender;
                    var hospitalInfo = await _hospitalInfoService.GetBaseByIdAsync(sendHospital.HospitalId);
                    result.SendHospitalName = hospitalInfo.Name;
                    result.SendHospitaPicture = hospitalInfo.ThumbPicUrl;
                    var empInfo = await _amiyaEmployeeService.GetByIdAsync(result.SendBy.Value);
                    result.SendByName = empInfo.Name;
                    result.SendDate = sendHospital.SendDate;
                }
            }
            if (result.OrderSource.HasValue)
            {
                result.OrderSourceText = ServiceClass.GerContentPlatFormOrderSourceText(order.OrderSource.Value);
            }
            if (result.AppointmentHospitalId != 0)
            {
                var hospitalInfo = await _hospitalInfoService.GetBaseByIdAsync(result.AppointmentHospitalId);
                result.AppointmentHospitalName = hospitalInfo.Name;
            }
            var goodsInfo = await amiyaGoodsDemandService.GetByIdAsync(order.GoodsId);
            result.GoodsName = goodsInfo.ProjectNname;
            result.ThumbPicture = goodsInfo.ThumbPictureUrl;
            result.HospitalDepartmentName = goodsInfo.HospitalDepartmentName;
            result.UnSendReason = order.UnSendReason;
            result.AcceptConsulting = order.AcceptConsulting;
            result.LastDealHospitalId = order.LastDealHospitalId;
            result.OtherContentPlatFormOrderId = order.OtherContentPlatFormOrderId;
            if (result.LastDealHospitalId.HasValue && result.LastDealHospitalId != 0)
            {
                var hospitalInfo = await _hospitalInfoService.GetBaseByIdAsync(result.LastDealHospitalId.Value);
                result.LastDealHospitalName = hospitalInfo.Name;
            }
            var contentPlatFormInfo = await _contentPlatformService.GetByIdAsync(order.ContentPlateformId);
            result.ContentPlateFormName = contentPlatFormInfo.ContentPlatformName;
            result.IsRepeatProfundityOrder = order.IsRepeatProfundityOrder;
            result.IsCreateBill = order.IsCreateBill;
            result.CreateBillCompany = dalCompanyBaseInfo.GetAll().Where(e => e.Id == order.BelongCompany).SingleOrDefault()?.Name;
            result.CustomerServiceSettlePrice = order.CustomerServiceSettlePrice;
            return result;
        }

        /// <summary>
        /// 根据编号获取重单截图
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<string> SelectRepeateOrderPicAsync(string orderId)
        {
            var order = await _dalContentPlatformOrder.GetAll().Where(x => x.Id == orderId).FirstOrDefaultAsync();
            return order.RepeatOrderPictureUrl;
        }



        /// <summary>
        /// 根据加密手机号获取简易的订单列表
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<ContentPlatFormOrderInfoSimpleDto>> GetListByEncryptPhoneAsync(string encryptPhone, int pageNum, int pageSize)
        {
            try
            {
                var config = await GetCallCenterConfig();
                string phone = ServiceClass.Decrypto(encryptPhone, config.PhoneEncryptKey);

                var order = from d in _dalContentPlatformOrder.GetAll()
                            where d.Phone == phone
                            select new ContentPlatFormOrderInfoSimpleDto
                            {
                                Id = d.Id,
                                OrderTypeText = ServiceClass.GetContentPlateFormOrderTypeText((byte)d.OrderType),
                                ContentPlatformName = d.Contentplatform.ContentPlatformName,
                                ConsultingContent = d.ConsultingContent,
                                LateProjectStage = d.LateProjectStage,
                                CreateDate = d.CreateDate,
                                LiveAnchorName = d.LiveAnchor.HostAccountName,
                                GoodsName = d.AmiyaGoodsDemand.ProjectNname,
                                DepositAmount = d.DepositAmount,
                                DealAmount = d.DealAmount,
                                UnDealReason = d.UnDealReason,
                                AppointmentDate = d.AppointmentDate.HasValue ? d.AppointmentDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "未确认时间",
                                AppointmentHospitalName = d.HospitalInfo.Name,
                                OrderStatusText = ServiceClass.GetContentPlateFormOrderStatusText((byte)d.OrderStatus),
                                Remark = d.Remark,
                            };
                FxPageInfo<ContentPlatFormOrderInfoSimpleDto> orderPageInfo = new FxPageInfo<ContentPlatFormOrderInfoSimpleDto>();
                orderPageInfo.TotalCount = await order.CountAsync();
                orderPageInfo.List = await order.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                return orderPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据手机号获取简易的订单列表
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public async Task<List<ContentPlatFormOrderInfoSimpleDto>> GetOrderListByPhoneAsync(string phone)
        {
            try
            {

                var order = from d in _dalContentPlatformOrder.GetAll()
                            where d.Phone == phone
                            select new ContentPlatFormOrderInfoSimpleDto
                            {
                                Id = d.Id,
                                OrderTypeText = ServiceClass.GetContentPlateFormOrderTypeText((byte)d.OrderType),
                                ContentPlatformName = d.Contentplatform.ContentPlatformName,
                                ConsultingContent = d.ConsultingContent,
                                LateProjectStage = d.LateProjectStage,
                                CreateDate = d.CreateDate,
                                LiveAnchorName = d.LiveAnchor.HostAccountName,
                                GoodsName = d.AmiyaGoodsDemand.ProjectNname,
                                DepositAmount = d.DepositAmount,
                                DealAmount = d.DealAmount,
                                HospitalDepartmentId = d.HospitalDepartmentId,
                                UnDealReason = d.UnDealReason,
                                AppointmentDate = d.AppointmentDate.HasValue ? d.AppointmentDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "未确认时间",
                                AppointmentHospitalName = d.HospitalInfo.Name,
                                OrderStatus = d.OrderStatus,
                                OrderStatusText = ServiceClass.GetContentPlateFormOrderStatusText((byte)d.OrderStatus),
                                Remark = d.Remark,
                            };
                List<ContentPlatFormOrderInfoSimpleDto> orderPageInfo = new List<ContentPlatFormOrderInfoSimpleDto>();
                orderPageInfo = await order.OrderByDescending(e => e.CreateDate).ToListAsync();
                return orderPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据和医院id手机号获取简易的订单列表
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public async Task<ContentPlatFormOrderInfoSimpleDto> GetOrderListByPhoneAndHospitalIdAsync(string phone, int sendHospitalId)
        {
            try
            {

                var order = from d in _dalContentPlatformOrder.GetAll().Include(x => x.ContentPlatformOrderSendList)
                            where d.Phone == phone
                            && (d.OrderStatus != (int)ContentPlateFormOrderStatus.HaveOrder)
                            && (d.ContentPlatformOrderSendList.Select(x => x.HospitalId).Contains(sendHospitalId))
                            select new ContentPlatFormOrderInfoSimpleDto
                            {
                                Id = d.Id,
                                OrderTypeText = ServiceClass.GetContentPlateFormOrderTypeText((byte)d.OrderType),
                                ContentPlatformName = d.Contentplatform.ContentPlatformName,
                                ConsultingContent = d.ConsultingContent,
                                LateProjectStage = d.LateProjectStage,
                                CreateDate = d.CreateDate,
                                LiveAnchorName = d.LiveAnchor.HostAccountName,
                                GoodsName = d.AmiyaGoodsDemand.ProjectNname,
                                DepositAmount = d.DepositAmount,
                                DealAmount = d.DealAmount,
                                HospitalDepartmentId = d.HospitalDepartmentId,
                                UnDealReason = d.UnDealReason,
                                AppointmentDate = d.AppointmentDate.HasValue ? d.AppointmentDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "未确认时间",
                                AppointmentHospitalName = d.HospitalInfo.Name,
                                OrderStatus = d.OrderStatus,
                                OrderStatusText = ServiceClass.GetContentPlateFormOrderStatusText((byte)d.OrderStatus),
                                Remark = d.Remark,
                            };
                var result = await order.OrderByDescending(e => e.CreateDate).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 编辑录单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateContentPlateFormOrderAsync(ContentPlateFormOrderUpdateDto input)
        {
            unitOfWork.BeginTransaction();
            try
            {

                //验证手机号是否有归属
                if (string.IsNullOrEmpty(input.Phone))
                {
                    throw new Exception("该订单没有手机号，不能绑定客服");
                }

                var bind = await _dalBindCustomerService.GetAll()
                  .Include(e => e.CustomerServiceAmiyaEmployee)
                  .SingleOrDefaultAsync(e => e.BuyerPhone == input.Phone);
                if (bind != null)
                {
                    var employee = await _dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == input.EmployeeId);
                    if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector && input.EmployeeId != bind.CustomerServiceId)
                    {
                        throw new Exception("该客户已绑定给" + bind.CustomerServiceAmiyaEmployee.Name + ",请联系对应人员进行编辑！");
                    }
                    //更新绑定客服列表bind_customer_info表的消费平台与主播微信数据
                    bind.NewConsumptionDate = DateTime.Now;
                    bind.NewConsumptionContentPlatform = (int)OrderFrom.ContentPlatFormOrder;
                    bind.NewContentPlatForm = input.ContentPlateFormName;
                    var liveAnchor = dalLiveAnchor.GetAll().Where(e => e.Id == input.LiveAnchorId).FirstOrDefault();
                    if (liveAnchor != null)
                    {
                        bind.NewLiveAnchor = liveAnchor.Name;
                    }
                    bind.NewWechatNo = input.LiveAnchorWeChatNo;
                    await _dalBindCustomerService.UpdateAsync(bind, true);
                }
                else
                {
                    //添加绑定客服
                    BindCustomerService bindCustomerService = new BindCustomerService();
                    bindCustomerService.CustomerServiceId = input.EmployeeId;
                    bindCustomerService.BuyerPhone = input.Phone;
                    bindCustomerService.UserId = null;
                    bindCustomerService.CreateBy = input.EmployeeId;
                    bindCustomerService.CreateDate = DateTime.Now;
                    var goodsInfo = await amiyaGoodsDemandService.GetByIdAsync(input.GoodsId);
                    bindCustomerService.FirstProjectDemand = "(" + goodsInfo.HospitalDepartmentName + ")" + goodsInfo.ProjectNname;
                    bindCustomerService.FirstConsumptionDate = DateTime.Now;
                    bindCustomerService.NewConsumptionDate = DateTime.Now;
                    bindCustomerService.NewConsumptionContentPlatform = (int)OrderFrom.ContentPlatFormOrder;
                    bindCustomerService.NewContentPlatForm = input.ContentPlateFormName;
                    bindCustomerService.NewLiveAnchor = dalLiveAnchor.GetAll().Where(e => e.Id == input.LiveAnchorId).FirstOrDefault().Name;
                    bindCustomerService.NewWechatNo = input.LiveAnchorWeChatNo;
                    bindCustomerService.AllPrice = 0;
                    bindCustomerService.AllOrderCount = 0;
                    await _dalBindCustomerService.AddAsync(bindCustomerService, true);
                }
                var order = await _dalContentPlatformOrder.GetAll().Where(x => x.Id == input.Id).SingleOrDefaultAsync();
                if (order == null)
                {
                    throw new Exception("未找到该订单的相关信息！");
                }
                order.OrderType = input.OrderType;
                order.ContentPlateformId = input.ContentPlateFormId;
                order.LiveAnchorWeChatNo = input.LiveAnchorWeChatNo;
                order.LiveAnchorId = input.LiveAnchorId;
                order.ConsultationType = input.ConsultationType;
                order.GoodsId = input.GoodsId;
                order.CustomerName = input.CustomerName;
                order.Phone = input.Phone;
                order.BelongMonth = input.BelongMonth;
                order.AddOrderPrice = input.AddOrderPrice;
                order.AppointmentDate = input.AppointmentDate;
                order.AppointmentHospitalId = input.AppointmentHospitalId;
                order.HospitalDepartmentId = input.HospitalDepartmentId;
                order.DepositAmount = input.DepositAmount;
                order.ConsultationEmpId = input.ConsultationEmpId;
                order.ConsultingContent = input.ConsultingContent;
                order.UpdateDate = DateTime.Now;
                order.Remark = input.Remark;
                order.LateProjectStage = input.LateProjectStage;
                order.OrderSource = input.OrderSource;
                order.AcceptConsulting = input.AcceptConsulting;
                order.UnSendReason = input.UnSendReason;

                await _contentPlatFormCustomerPictureService.DeleteByContentPlatFormOrderIdAsync(order.Id);
                foreach (var z in input.CustomerPictures)
                {
                    AddContentPlatFormCustomerPictureDto addPicture = new AddContentPlatFormCustomerPictureDto();
                    addPicture.ContentPlatFormOrderId = order.Id;
                    addPicture.CustomerPicture = z;
                    addPicture.Description = "顾客照片";
                    await _contentPlatFormCustomerPictureService.AddAsync(addPicture);
                }
                await _dalContentPlatformOrder.UpdateAsync(order, true);

                //订单备注新增数据
                if (!string.IsNullOrEmpty(order.Remark))
                {

                    AddOrderRemarkDto addOrderRemarkDto = new AddOrderRemarkDto();
                    addOrderRemarkDto.OrderId = order.Id;
                    addOrderRemarkDto.Remark = order.Remark;
                    addOrderRemarkDto.CreateBy = order.BelongEmpId.Value;
                    addOrderRemarkDto.BelongAuthorize = (int)AuthorizeStatusEnum.InternalAuthorize;
                    await orderRemarkService.AddAsync(addOrderRemarkDto);
                }
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception(err.Message.ToString());

            }
        }

        /// <summary>
        /// 审核订单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CheckContentPlateFormOrderAsync(ContentPlateFormOrderCheckDto input)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var order = await _dalContentPlatformOrder.GetAll().Where(x => x.Id == input.Id).SingleOrDefaultAsync();
                if (order == null)
                {
                    throw new Exception("未找到该订单的相关信息！");
                }
                var dealInfo = await _contentPlatFormOrderDalService.GetByOrderIdAsync(input.Id);
                dealInfo = dealInfo.Where(x => x.IsDeal == true).ToList();
                var checkInfo = dealInfo.Where(x => x.CheckState == (int)CheckType.CheckedSuccess).Count();
                if (checkInfo + 1 == dealInfo.Count && input.CheckState == (int)CheckType.CheckedSuccess)
                {
                    order.CheckState = (int)CheckType.CheckedSuccess;
                }
                else
                {
                    order.CheckState = (int)CheckType.Checking;
                }
                order.CheckBy = input.employeeId;
                order.CheckPrice += input.CheckPrice;
                order.SettlePrice += input.SettlePrice;
                if (order.CustomerServiceSettlePrice.HasValue)
                {
                    order.CustomerServiceSettlePrice += input.CustomerServiceSettlePrice.Value;
                }
                else
                {
                    order.CustomerServiceSettlePrice = input.CustomerServiceSettlePrice.Value;

                }
                order.CheckRemark = input.CheckRemark;
                order.CheckDate = DateTime.Now;
                await _dalContentPlatformOrder.UpdateAsync(order, true);

                foreach (var x in input.CheckPicture)
                {
                    AddOrderCheckPictureDto addCheckPic = new AddOrderCheckPictureDto();
                    addCheckPic.OrderFrom = (int)OrderFrom.ContentPlatFormOrder;
                    addCheckPic.OrderId = input.OrderDealInfoId;
                    addCheckPic.PictureUrl = x;
                    await _orderCheckPictureService.AddAsync(addCheckPic);
                }

                //修改成交情况审核信息
                var dealInfoUpdate = dealInfo.Where(x => x.Id == input.OrderDealInfoId).FirstOrDefault();
                UpdateContentPlatFormOrderDealInfoDto dealInfoCheck = new UpdateContentPlatFormOrderDealInfoDto();
                dealInfoCheck.Id = input.OrderDealInfoId;
                dealInfoCheck.CheckBy = input.employeeId;
                dealInfoCheck.CheckRemark = input.CheckRemark;
                //dealInfoCheck.CheckState = input.CheckState;
                //若审核金额等于交易金额，则审核通过，若不等于则审核中
                if (input.CheckState == (int)CheckType.CheckedSuccess)
                {
                    if (input.CheckPrice == dealInfoUpdate.Price)
                    {

                        dealInfoCheck.CheckState = (int)CheckType.CheckedSuccess;
                        dealInfoCheck.CheckPrice = input.CheckPrice;
                        dealInfoCheck.SettlePrice = input.SettlePrice;
                        dealInfoCheck.CustomerServiceSettlePrice = input.CustomerServiceSettlePrice;
                    }
                    else
                    {
                        if (dealInfoUpdate.CheckPrice + input.CheckPrice == dealInfoUpdate.Price)
                        {
                            dealInfoCheck.CheckState = (int)CheckType.CheckedSuccess;
                            dealInfoCheck.CheckPrice = dealInfoUpdate.Price;
                            dealInfoCheck.SettlePrice = input.SettlePrice + dealInfoUpdate.SettlePrice;
                            dealInfoCheck.CustomerServiceSettlePrice = input.CustomerServiceSettlePrice + dealInfoUpdate.CustomerServiceSettlePrice;
                        }
                        else
                        {
                            dealInfoCheck.CheckState = (int)CheckType.Checking;
                            if (dealInfoUpdate.CheckPrice.HasValue)
                            {
                                dealInfoCheck.CheckPrice = input.CheckPrice + dealInfoUpdate.CheckPrice.Value;
                            }
                            else
                            {
                                dealInfoCheck.CheckPrice = input.CheckPrice;
                            }
                            if (dealInfoUpdate.SettlePrice.HasValue)
                            {
                                dealInfoCheck.SettlePrice = input.SettlePrice + dealInfoUpdate.SettlePrice;
                                dealInfoCheck.CustomerServiceSettlePrice = input.CustomerServiceSettlePrice + dealInfoUpdate.CustomerServiceSettlePrice;
                            }
                            else
                            {
                                dealInfoCheck.SettlePrice = input.SettlePrice;
                                dealInfoCheck.CustomerServiceSettlePrice = input.CustomerServiceSettlePrice;
                            }
                        }
                    }
                }
                if (input.CheckState == (int)CheckType.CheckNotPassed)
                {
                    dealInfoCheck.CheckState = (int)CheckType.CheckNotPassed;
                    dealInfoCheck.CheckPrice = 0.00M;
                    dealInfoCheck.SettlePrice = 0.00M;
                    dealInfoCheck.CustomerServiceSettlePrice = 0.00M;
                }
                if (dealInfoUpdate.InformationPrice.HasValue)
                {

                    dealInfoCheck.InformationPrice = input.InformationPrice + dealInfoUpdate.InformationPrice.Value;
                }
                else
                {
                    dealInfoCheck.InformationPrice = input.InformationPrice;
                }
                if (dealInfoUpdate.SystemUpdatePrice.HasValue)
                {
                    dealInfoCheck.SystemUpdatePrice = input.SystemUpdatePrice + dealInfoUpdate.SystemUpdatePrice.Value;
                }
                else
                {
                    dealInfoCheck.SystemUpdatePrice = input.SystemUpdatePrice;
                }
                dealInfoCheck.ReconciliationDocumentsId = input.ReconciliationDocumentsId;
                await _contentPlatFormOrderDalService.CheckAsync(dealInfoCheck);

                //对账单审核记录表插入数据
                AddRecommandDocumentSettleDto addRecommandDocumentSettleDto = new AddRecommandDocumentSettleDto();
                addRecommandDocumentSettleDto.RecommandDocumentId = input.ReconciliationDocumentsId;
                addRecommandDocumentSettleDto.OrderId = input.Id;
                addRecommandDocumentSettleDto.DealInfoId = input.OrderDealInfoId;
                addRecommandDocumentSettleDto.OrderFrom = (int)OrderFrom.ContentPlatFormOrder;
                addRecommandDocumentSettleDto.ReturnBackPrice = input.SettlePrice;
                addRecommandDocumentSettleDto.CustomerServiceSettlePrice = input.CustomerServiceSettlePrice.HasValue ? input.CustomerServiceSettlePrice.Value : 0.00M;
                addRecommandDocumentSettleDto.BelongLiveAnchorAccount = order.LiveAnchorId;
                addRecommandDocumentSettleDto.BelongEmpId = order.BelongEmpId;
                addRecommandDocumentSettleDto.CreateEmpId = dealInfoUpdate.CreateBy;
                addRecommandDocumentSettleDto.RecolicationPrice = input.CheckPrice;
                addRecommandDocumentSettleDto.CreateBy = input.employeeId;
                addRecommandDocumentSettleDto.AccountType = false;
                addRecommandDocumentSettleDto.AccountPrice = input.SettlePrice;
                addRecommandDocumentSettleDto.OrderPrice = dealInfoUpdate.Price;
                addRecommandDocumentSettleDto.IsOldCustomer = dealInfoUpdate.IsOldCustomer;
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
        /// 订单回款（旧版本）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task ReturnBackOrderAsync(ReturnBackOrderDto input)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var order = await _dalContentPlatformOrder.GetAll().Where(x => x.Id == input.OrderId).SingleOrDefaultAsync();
                if (order == null)
                {
                    throw new Exception("未找到该订单的相关信息！");
                }
                var dealInfo = await _contentPlatFormOrderDalService.GetByOrderIdAsync(input.OrderDealId);
                var checkInfo = dealInfo.Where(x => x.IsReturnBackPrice == true).Count();
                if (checkInfo == dealInfo.Count)
                {
                    order.IsReturnBackPrice = true;
                }
                else
                {
                    order.IsReturnBackPrice = false;
                }
                if (order.ReturnBackPrice == null)
                {
                    order.ReturnBackPrice = input.ReturnBackPrice;
                }
                else
                {
                    order.ReturnBackPrice += input.ReturnBackPrice;
                }
                order.ReturnBackDate = input.ReturnBackDate;
                await _dalContentPlatformOrder.UpdateAsync(order, true);

                //修改成交情况回款信息
                var dealInfoUpdate = dealInfo.Where(x => x.Id == input.OrderDealId);
                UpdateContentPlatFormOrderDealInfoDto dealInfoCheck = new UpdateContentPlatFormOrderDealInfoDto();
                dealInfoCheck.Id = input.OrderDealId;
                dealInfoCheck.ReturnBackDate = input.ReturnBackDate;
                dealInfoCheck.ReturnBackPrice = input.ReturnBackPrice;
                await _contentPlatFormOrderDalService.SettleAsync(dealInfoCheck);

                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
            }
        }

        /// <summary>
        /// 订单只计算回款
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task ReturnBackOrderOnlyAsync(ReturnBackOrderDto input)
        {
            try
            {
                var order = await _dalContentPlatformOrder.GetAll().Where(x => x.Id == input.OrderId).SingleOrDefaultAsync();
                if (order == null)
                {
                    throw new Exception("未找到该订单的相关信息，回款失败！");
                }
                order.IsReturnBackPrice = true;
                if (order.ReturnBackPrice == null)
                {
                    order.ReturnBackPrice = input.ReturnBackPrice;
                }
                else
                {

                    order.ReturnBackPrice += input.ReturnBackPrice;
                }
                order.ReturnBackDate = input.ReturnBackDate;
                await _dalContentPlatformOrder.UpdateAsync(order, true);

            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        ///  派单后修改订单状态并删除重单截图（针对派单/重单再派单/未成交再派单）
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="sendBy"></param>
        /// <returns></returns>
        public async Task UpdateStateAndRepeateOrderPicAsync(string orderId, int sendBy, int? belongEmpId, int employee)
        {
            var order = await _dalContentPlatformOrder.GetAll().Where(x => x.Id == orderId).SingleOrDefaultAsync();
            if (order == null)
            {
                throw new Exception("未找到该订单的相关信息！");
            }
            //验证手机号是否有归属
            if (string.IsNullOrEmpty(order.Phone))
            {
                throw new Exception("该订单没有手机号，不能绑定客服");
            }

            var contentPlatForm = await _contentPlatformService.GetByIdAsync(order.ContentPlateformId);
            var bind = await _dalBindCustomerService.GetAll()
              .Include(e => e.CustomerServiceAmiyaEmployee)
              .SingleOrDefaultAsync(e => e.BuyerPhone == order.Phone);
            //if (bind != null)
            //{
            //    //获取当前登陆账户是否为管理员
            //    var positionInfo = await _dalAmiyaEmployee.GetAll().Where(z => z.Id == employee).FirstOrDefaultAsync();
            //    var IsDirector = positionInfo.AmiyaPositionInfo.IsDirector;
            //    if (!IsDirector)
            //    {
            //        if (bind.CustomerServiceId != sendBy)
            //            throw new Exception("该客户已绑定给" + bind.CustomerServiceAmiyaEmployee.Name + ",请联系对应人员进行编辑！");
            //    }
            //}
            //else
            //{
            //    //添加绑定客服
            //    BindCustomerService bindCustomerService = new BindCustomerService();
            //    bindCustomerService.CustomerServiceId = belongEmpId.HasValue ? belongEmpId.Value : employee;
            //    bindCustomerService.BuyerPhone = order.Phone;
            //    bindCustomerService.UserId = null;
            //    bindCustomerService.CreateBy = employee;
            //    bindCustomerService.CreateDate = DateTime.Now;
            //    await _dalBindCustomerService.AddAsync(bindCustomerService, true);
            //}

            //所有人都可以派单，不受绑定限制
            if (bind == null)
            {
                //添加绑定客服
                BindCustomerService bindCustomerService = new BindCustomerService();
                bindCustomerService.CustomerServiceId = belongEmpId.HasValue ? belongEmpId.Value : employee;
                bindCustomerService.BuyerPhone = order.Phone;
                bindCustomerService.UserId = null;
                bindCustomerService.CreateBy = employee;
                bindCustomerService.CreateDate = DateTime.Now;
                var goodsInfo = await amiyaGoodsDemandService.GetByIdAsync(order.GoodsId);
                bindCustomerService.FirstProjectDemand = "(" + goodsInfo.HospitalDepartmentName + ")" + goodsInfo.ProjectNname;
                bindCustomerService.FirstConsumptionDate = order.CreateDate;
                bindCustomerService.NewConsumptionDate = order.CreateDate;
                bindCustomerService.NewConsumptionContentPlatform = (int)OrderFrom.ContentPlatFormOrder;
                bindCustomerService.NewContentPlatForm = contentPlatForm.ContentPlatformName;
                bindCustomerService.AllPrice = order.DepositAmount;
                bindCustomerService.AllOrderCount = 1;
                await _dalBindCustomerService.AddAsync(bindCustomerService, true);
            }
            order.IsRepeatProfundityOrder = false;
            order.RepeatOrderPictureUrl = "";
            order.OrderStatus = Convert.ToInt16(ContentPlateFormOrderStatus.SendOrder);
            order.SendDate = DateTime.Now;
            await _dalContentPlatformOrder.UpdateAsync(order, true);
        }


        /// <summary>
        /// 删除录单订单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            var orderInfo = await _dalContentPlatformOrder.GetAll()
                .SingleOrDefaultAsync(e => e.Id == id);
            await _dalContentPlatformOrder.DeleteAsync(orderInfo, true);
        }

        /// <summary>
        /// 完成订单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task FinishContentPlateFormOrderAsync(ContentPlateFormOrderFinishDto input)
        {
            unitOfWork.BeginTransaction();
            try
            {

                //验证唯一标识
                if (!string.IsNullOrEmpty(input.OtherContentPlatFormOrderId))
                {
                    var contentPlatFormOrderId = await _contentPlatFormOrderDalService.GetByOtherAppOrderIdAsync(input.OtherContentPlatFormOrderId);
                    if (!string.IsNullOrEmpty(contentPlatFormOrderId.Id))
                    {
                        return;
                    }
                }
                if (input.IsFinish == true)
                {
                    if (input.ConsumptionType == (int)ConsumptionType.OTHER) throw new Exception("成交订单不能选择其他消费类型！");
                }
                if (input.IsFinish == false || input.ToHospitalType == (int)ContentPlateFormOrderToHospitalType.REFUND)
                {
                    input.ConsumptionType = (int)ConsumptionType.OTHER;
                }
                if (input.ToHospitalType == (int)ContentPlateFormOrderToHospitalType.REFUND && input.IsFinish == true)
                {
                    input.ConsumptionType = (int)ConsumptionType.Refund;
                }
                var order = await _dalContentPlatformOrder.GetAll().Include(x => x.LiveAnchor).Include(x => x.Contentplatform).Include(x => x.ContentPlatformOrderSendList).Where(x => x.Id == input.Id).SingleOrDefaultAsync();
                var isoldCustomer = false;
                var orderIsOldCustomer = false;
                //取该订单的第一次成交业绩时间
                var orderDealInfoList = await _contentPlatFormOrderDalService.GetByOrderIdAsync(input.Id);
                var dealCount = orderDealInfoList.OrderBy(x => x.DealDate).Where(x => x.IsDeal == true && x.ToHospitalType != (int)ContentPlateFormOrderToHospitalType.REFUND && x.ConsumptionType != (int)ConsumptionType.Deposit && x.ConsumptionType != (int)ConsumptionType.Refund && x.Price > 0).FirstOrDefault();
                AddContentPlatFormOrderDealInfoDto orderDealDto = new AddContentPlatFormOrderDealInfoDto();

                if (dealCount != null)
                {
                    var dealinfo = await _contentPlatFormOrderDalService.GetByOrderIdAsync(input.Id);
                    var realDealCount = dealinfo.Where(x => x.IsDeal == true && x.Price > 0 && x.ToHospitalType != (int)ContentPlateFormOrderToHospitalType.REFUND && x.ConsumptionType != (int)ConsumptionType.Deposit && x.ConsultationType != (int)ConsumptionType.Refund).Count();
                    if (realDealCount > 1)
                    {
                        orderIsOldCustomer = true;
                    }
                    if (dealCount.DealDate > input.DealDate)
                    {
                        //成交且为成交消费,更新最近一次成交消费和区间内的定金消费和退款消费为老客消费,主订单修改为老客订单
                        if (input.ConsumptionType == (int)ConsumptionType.Deal && input.IsFinish == true)
                        {
                            await _contentPlatFormOrderDalService.UpdateIsOldCustomerAsync(dealCount.Id, true);
                            orderIsOldCustomer = true;
                        }
                    }
                    else
                    {
                        if (input.ConsumptionType == (int)ConsumptionType.Deal && input.DealAmount > 0 && input.IsFinish == true && realDealCount == 1)
                        {
                            orderIsOldCustomer = true;
                        }
                        isoldCustomer = orderIsOldCustomer;
                    }

                }
                bool isRepeateOrder = false;
                if (order != null)
                {
                    //如果到院完成到院接诊预约
                    if (input.IsToHospital)
                    {
                        await customerAppointmentScheduleService.UpdateAppointmentCompleteStatusAsync(order.Phone, (int)AppointmentType.ToHospitalAppointment);
                    }
                    if (input.IsFinish == true)
                    {
                        var price = order.DepositAmount.HasValue ? order.DepositAmount.Value : 0.00M;
                        await bindCustomerServiceService.UpdateConsumePriceAsync(order.Phone, price + input.DealAmount.Value, (int)OrderFrom.ContentPlatFormOrder, order.LiveAnchor.Name, order.LiveAnchorWeChatNo, order.Contentplatform.ContentPlatformName, 1);
                        //await customerBaseInfoService.UpdateState(1, input.CustomerName, order.Phone);
                        order.OrderStatus = Convert.ToInt16(ContentPlateFormOrderStatus.OrderComplete);
                        order.DealAmount += input.DealAmount;
                        order.LateProjectStage = input.LastProjectStage;
                        order.ToHospitalDate = input.ToHospitalDate;
                        order.DealPictureUrl = input.DealPictureUrl;
                        order.IsToHospital = true;
                        order.ToHospitalDate = input.ToHospitalDate;
                        order.CommissionRatio = input.CommissionRatio;
                        order.UnDealReason = "";
                        order.UnDealPictureUrl = "";
                        order.DealDate = input.DealDate;
                        order.DealPerformanceType = input.DealPerformanceType;
                    }
                    else
                    {
                        order.OrderStatus = Convert.ToInt16(ContentPlateFormOrderStatus.WithoutCompleteOrder);
                        order.UnDealReason = input.UnDealReason;
                        order.UnDealPictureUrl = input.UnDealPictureUrl;
                        order.IsToHospital = input.IsToHospital;
                        order.ToHospitalDate = input.ToHospitalDate;
                        order.LateProjectStage = "";
                        order.DealPictureUrl = "";
                    }
                    order.LastDealHospitalId = input.LastDealHospitalId;
                    order.IsOldCustomer = orderIsOldCustomer;
                    order.IsAcompanying = input.IsAcompanying;
                    order.ToHospitalType = input.ToHospitalType;
                    order.OtherContentPlatFormOrderId = input.OtherContentPlatFormOrderId;
                    order.UpdateDate = DateTime.Now;
                    if (order.CheckState == (int)CheckType.CheckedSuccess)
                    {
                        order.CheckState = (int)CheckType.Checking;
                    }
                    isRepeateOrder = order.IsRepeatProfundityOrder;
                    await _dalContentPlatformOrder.UpdateAsync(order, true);


                    //获取医院客户列表
                    var customer = await hospitalCustomerInfoService.GetByHospitalIdAndPhoneAsync(order.ContentPlatformOrderSendList.OrderByDescending(x => x.SendDate).FirstOrDefault().HospitalId, order.Phone);
                    //操作医院客户表
                    if (!string.IsNullOrEmpty(customer.Id))
                    {
                        UpdateSendHospitalCustomerInfoDto updateSendHospitalCustomerInfoDto = new UpdateSendHospitalCustomerInfoDto();
                        updateSendHospitalCustomerInfoDto.Id = customer.Id;
                        updateSendHospitalCustomerInfoDto.DealAmount += 1;
                        await hospitalCustomerInfoService.InsertDealAmountAsync(updateSendHospitalCustomerInfoDto);
                    }
                }
                else
                {
                    input.LastProjectStage = "医院成交同步，未找到该顾客订单，顾客手机号：" + input.LastProjectStage;
                }
                //添加订单成交情况
                orderDealDto.ContentPlatFormOrderId = input.Id;
                orderDealDto.CreateDate = DateTime.Now;
                orderDealDto.IsDeal = input.IsFinish;
                orderDealDto.OtherAppOrderId = input.OtherContentPlatFormOrderId;
                orderDealDto.ToHospitalType = input.ToHospitalType;
                orderDealDto.IsOldCustomer = isoldCustomer;
                orderDealDto.LastDealHospitalId = input.LastDealHospitalId;
                orderDealDto.IsAcompanying = input.IsAcompanying;
                orderDealDto.IsRepeatProfundityOrder = isRepeateOrder;
                if (input.IsFinish == true)
                {
                    orderDealDto.IsToHospital = true;
                    orderDealDto.ToHospitalDate = input.ToHospitalDate;
                    orderDealDto.DealPicture = input.DealPictureUrl;
                    orderDealDto.DealDate = input.DealDate;
                    orderDealDto.Price = input.DealAmount.Value;
                    orderDealDto.CommissionRatio = input.CommissionRatio;
                    orderDealDto.Remark = input.LastProjectStage;
                    orderDealDto.DealPerformanceType = input.DealPerformanceType;
                    orderDealDto.ConsumptionType = input.ConsumptionType;
                }
                else
                {
                    orderDealDto.IsToHospital = input.IsToHospital;
                    orderDealDto.ToHospitalDate = input.ToHospitalDate;
                    orderDealDto.DealPicture = input.UnDealPictureUrl;
                    orderDealDto.Remark = input.UnDealReason;
                    orderDealDto.Price = 0.00M;
                    orderDealDto.ConsumptionType = input.ConsumptionType;
                }
                orderDealDto.CreateBy = input.EmpId;
                orderDealDto.InvitationDocuments = input.InvitationDocuments;
                orderDealDto.AddContentPlatFormOrderDealDetailsDtoList = input.AddContentPlatFormOrderDealDetailsDtoList;
                await _contentPlatFormOrderDalService.AddAsync(orderDealDto);

                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception(err.Message.ToString());
            }
        }

        /// <summary>
        /// 修改完成订单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateFinishContentPlateFormOrderAsync(UpdateContentPlateFormOrderFinishDto input)
        {
            unitOfWork.BeginTransaction();
            try
            {
                if (input.IsFinish == true)
                {
                    if (input.ConsumptionType == (int)ConsumptionType.OTHER) throw new Exception("成交订单不能选择其他消费类型！");
                }
                if (input.IsFinish == false)
                {
                    input.ConsumptionType = (int)ConsumptionType.OTHER;
                }
                if (input.ToHospitalType == (int)ContentPlateFormOrderToHospitalType.REFUND && input.IsFinish == true)
                {
                    input.ConsumptionType = (int)ConsumptionType.Refund;
                }
                var order = await _dalContentPlatformOrder.GetAll().Include(x => x.LiveAnchor).Include(x => x.Contentplatform).Where(x => x.Id == input.Id).SingleOrDefaultAsync();
                var isoldCustomer = false;
                var orderIsOldCustomer = false;
                if (order.CheckState == (int)CheckType.CheckedSuccess)
                {
                    throw new Exception("该订单已审核，无法编辑！");
                }
                var orderDealInfoList = await _contentPlatFormOrderDalService.GetByOrderIdAsync(input.Id);
                //最近一次非定金成交且id和当前要修改的id不同
                var dealCount = orderDealInfoList.OrderBy(x => x.DealDate).Where(x => x.IsDeal == true && x.Price > 0 && x.Id != input.DealId && x.ToHospitalType != (int)ContentPlateFormOrderToHospitalType.REFUND && x.ConsumptionType != (int)ConsumptionType.Deposit && x.ConsultationType != (int)ConsumptionType.Refund).FirstOrDefault();

                //如果有
                if (dealCount != null)
                {
                    var dealinfo = await _contentPlatFormOrderDalService.GetByOrderIdAsync(input.Id);
                    var realDealCount = dealinfo.Where(x => x.IsDeal == true && x.Id != input.DealId && x.ToHospitalType != (int)ContentPlateFormOrderToHospitalType.REFUND && x.ConsumptionType != (int)ConsumptionType.Deposit && x.ConsumptionType != (int)ConsumptionType.Refund).Count();
                    if (realDealCount > 1)
                    {
                        orderIsOldCustomer = true;
                    }
                    if (dealCount.DealDate > input.DealDate)
                    {
                        //修改后成交且为成交消费,最近一次消费改为老客业绩
                        if (input.ConsumptionType == (int)ConsumptionType.Deal && input.IsFinish == true)
                        {
                            await _contentPlatFormOrderDalService.UpdateIsOldCustomerAsync(dealCount.Id, true);
                            orderIsOldCustomer = true;
                        }
                        //修改后未成交且为成交消费,最近一次消费改为新客业绩
                        if (input.ConsumptionType == (int)ConsumptionType.Deal && input.IsFinish == false)
                        {
                            await _contentPlatFormOrderDalService.UpdateIsOldCustomerAsync(dealCount.Id, false);

                        }

                        //成交且为退款,定金,其他消费 将最近一次的成交消费更改为新客消费
                        if (input.ConsumptionType == (int)ConsumptionType.Refund || input.ConsumptionType == (int)ConsumptionType.OTHER || input.ConsumptionType == (int)ConsumptionType.Deposit)
                        {
                            await _contentPlatFormOrderDalService.UpdateIsOldCustomerAsync(dealCount.Id, false);
                        }
                    }
                    else
                    {
                        if (input.ConsumptionType == (int)ConsumptionType.Deal && input.DealAmount > 0 && input.IsFinish == true && realDealCount == 1)
                        {
                            orderIsOldCustomer = true;
                        }
                        isoldCustomer = orderIsOldCustomer;
                    }
                }
                var orderDealInfo = await _contentPlatFormOrderDalService.GetByIdAsync(input.DealId);
                order.DealAmount -= orderDealInfo.Price;

                if (order == null)
                {
                    throw new Exception("未找到该订单的相关信息！");
                }
                if (input.IsFinish == true)
                {
                    var dealPriceDetails = input.DealAmount.Value - orderDealInfo.Price;
                    var price = order.DepositAmount.HasValue ? order.DepositAmount.Value : 0.00M;
                    await bindCustomerServiceService.UpdateConsumePriceAsync(order.Phone, price + dealPriceDetails, (int)OrderFrom.ContentPlatFormOrder, order.LiveAnchor.Name, order.LiveAnchorWeChatNo, order.Contentplatform.ContentPlatformName, 0);
                    order.OrderStatus = Convert.ToInt16(ContentPlateFormOrderStatus.OrderComplete);
                    order.DealAmount += input.DealAmount;
                    order.LateProjectStage = input.LastProjectStage;
                    order.ToHospitalDate = input.ToHospitalDate;
                    order.DealPictureUrl = input.DealPictureUrl;
                    order.IsToHospital = true;
                    order.DealPerformanceType = input.DealPerformanceType;
                    order.CommissionRatio = input.CommissionRatio;
                    order.ToHospitalDate = input.ToHospitalDate;
                    order.UnDealReason = "";
                    order.UnDealPictureUrl = "";
                    order.DealDate = input.DealDate;


                }
                else
                {
                    order.OrderStatus = Convert.ToInt16(ContentPlateFormOrderStatus.WithoutCompleteOrder);
                    order.UnDealReason = input.UnDealReason;
                    order.UnDealPictureUrl = input.UnDealPictureUrl;
                    order.IsToHospital = input.IsToHospital;
                    order.ToHospitalDate = input.ToHospitalDate;
                    order.LateProjectStage = "";
                    order.DealPictureUrl = "";
                }
                if (order.CheckState == (int)CheckType.CheckedSuccess)
                {
                    order.CheckState = (int)CheckType.Checking;
                }
                order.LastDealHospitalId = input.LastDealHospitalId;
                order.IsOldCustomer = orderIsOldCustomer;
                order.IsAcompanying = input.IsAcompanying;
                order.OtherContentPlatFormOrderId = input.OtherContentPlatFormOrderId;
                order.UpdateDate = DateTime.Now;
                order.ToHospitalType = input.ToHospitalType;
                await _dalContentPlatformOrder.UpdateAsync(order, true);

                //修改订单成交情况
                UpdateContentPlatFormOrderDealInfoDto orderDealDto = new UpdateContentPlatFormOrderDealInfoDto();
                orderDealDto.Id = input.DealId;
                orderDealDto.ContentPlatFormOrderId = input.Id;
                orderDealDto.IsOldCustomer = isoldCustomer;
                orderDealDto.IsAcompanying = input.IsAcompanying;
                orderDealDto.IsDeal = input.IsFinish;
                orderDealDto.OtherAppOrderId = input.OtherContentPlatFormOrderId;
                orderDealDto.LastDealHospitalId = input.LastDealHospitalId;
                orderDealDto.ToHospitalType = input.ToHospitalType;
                if (input.IsFinish == true)
                {
                    orderDealDto.DealPerformanceType = input.DealPerformanceType;
                    orderDealDto.IsToHospital = true;
                    orderDealDto.ToHospitalDate = input.ToHospitalDate;
                    orderDealDto.CommissionRatio = input.CommissionRatio;
                    orderDealDto.DealPicture = input.DealPictureUrl;
                    orderDealDto.Price = input.DealAmount.Value;
                    orderDealDto.Remark = input.LastProjectStage;
                    orderDealDto.DealDate = input.DealDate;
                    orderDealDto.ConsumptionType = input.ConsumptionType;
                }
                else
                {
                    orderDealDto.IsToHospital = input.IsToHospital;
                    orderDealDto.ToHospitalDate = input.ToHospitalDate;
                    orderDealDto.DealPicture = input.UnDealPictureUrl;
                    orderDealDto.Remark = input.UnDealReason;
                    orderDealDto.Price = 0.00M;
                    orderDealDto.ConsumptionType = input.ConsumptionType;
                }
                orderDealDto.InvitationDocuments = input.InvitationDocuments;
                orderDealDto.UpdateBy = input.UpdateBy;
                orderDealDto.AddContentPlatFormOrderDealDetailsDtoList = input.AddContentPlatFormOrderDealDetailsDtoList;
                await _contentPlatFormOrderDalService.UpdateAsync(orderDealDto);

                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception(err.Message.ToString());
            }
        }
        /// <summary>
        /// 啊美雅端关闭重单可深度
        /// </summary>
        /// <returns></returns>
        public async Task UpdateContentPalteformRepeaterOrderStatusAsync(string contentPlateFormId)
        {
            var contentPalteFormOrder = await _dalContentPlatformOrder.GetAll().Where(e => e.Id == contentPlateFormId).SingleOrDefaultAsync();
            if (contentPalteFormOrder == null) throw new Exception("订单编号错误");
            if (!contentPalteFormOrder.IsRepeatProfundityOrder) throw new Exception("该订单已标记为重单不可深度状态,请勿重复操作");
            contentPalteFormOrder.IsRepeatProfundityOrder = false;
            await _dalContentPlatformOrder.UpdateAsync(contentPalteFormOrder, true);
        }

        /// <summary>
        /// 更新订单和成交信息开票和开票公司信息
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        public async Task UpdateCreateBillAndBelongCompany(UpdateCreateBillAndCompanyDto update)
        {
            var dealInfo = dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.Id == update.OrderDetailInfoId).SingleOrDefault();
            if (dealInfo == null) throw new Exception("成交编号错误");
            dealInfo.IsCreateBill = update.IsCreateBill;
            dealInfo.BelongCompany = update.CreateBillCompanyId;
            await dalContentPlatFormOrderDealInfo.UpdateAsync(dealInfo, true);
            if (update.IsCreateBill)
            {
                var order = _dalContentPlatformOrder.GetAll().Where(e => e.Id == update.OrderId).SingleOrDefault();
                if (order == null) throw new Exception("订单编号错误");
                order.IsCreateBill = update.IsCreateBill;
                order.BelongCompany = update.CreateBillCompanyId;
                await _dalContentPlatformOrder.UpdateAsync(order, true);
            }
            else
            {
                var createBillCount = dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.ContentPlatFormOrderId == update.OrderId && e.IsCreateBill == true).Count();
                if (createBillCount <= 0)
                {
                    var order = _dalContentPlatformOrder.GetAll().Where(e => e.Id == update.OrderId).SingleOrDefault();
                    if (order == null) throw new Exception("订单编号错误");
                    order.IsCreateBill = false;
                    order.BelongCompany = "";
                    await _dalContentPlatformOrder.UpdateAsync(order, true);
                }

            }


        }

        /// <summary>
        /// 医院重单打回
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task RepeateContentPlateFormOrderAsync(ContentPlateFormOrderRepeateDto input, int hospitalEmployeeId, int hospitalId)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var order = await _dalContentPlatformOrder.GetAll().Where(x => x.Id == input.OrderId).SingleOrDefaultAsync();
                if (order == null)
                {
                    throw new Exception("未找到该订单的相关信息！");
                }
                if (input.IsProfundity)
                {
                    //重单可深度
                    order.OrderStatus = Convert.ToInt16(ContentPlateFormOrderStatus.RepeatOrderProfundity);
                    order.IsRepeatProfundityOrder = true;
                    order.NetWorkConsulationName = input.NetWorkConsulationName;
                    order.SceneConsulationName = input.SceneConsulationName;
                    //绑定
                    AddHospitalBindCustomerServiceDto addHospitalBindCustomerServiceDto = new AddHospitalBindCustomerServiceDto();
                    addHospitalBindCustomerServiceDto.HospitalEmployeeId = hospitalEmployeeId;
                    var goodsInfo = await amiyaGoodsDemandService.GetByIdAsync(order.GoodsId);
                    addHospitalBindCustomerServiceDto.FirstProjectDemand = "(" + goodsInfo.HospitalDepartmentName + ")" + goodsInfo.ProjectNname;
                    addHospitalBindCustomerServiceDto.CustomerPhone = order.Phone;
                    var contentPlatForm = await _contentPlatformService.GetByIdAsync(order.ContentPlateformId);
                    addHospitalBindCustomerServiceDto.NewContentPlatformName = contentPlatForm.ContentPlatformName;
                    addHospitalBindCustomerServiceDto.hospitalId = hospitalId;
                    await hospitalBindCustomerService.AddAsync(addHospitalBindCustomerServiceDto);
                }
                else
                {
                    order.OrderStatus = Convert.ToInt16(ContentPlateFormOrderStatus.RepeatOrder);
                }

                order.ToHospitalDate = input.ToHospitalDate;
                order.IsToHospital = true;
                order.UpdateDate = DateTime.Now;
                order.ToHospitalDate = input.ToHospitalDate;
                order.RepeatOrderPictureUrl = input.RepeatePictureUrl;

                //获取医院客户列表并更新查重时间
                var sendInfo = await _contentPlatformOrderSend.GetByIdAsync(input.Id);
                var customer = await hospitalCustomerInfoService.GetByHospitalIdAndPhoneAsync(sendInfo.HospitalId, order.Phone);
                UpdateSendHospitalCustomerInfoDto updateSendHospitalCustomerInfoDto = new UpdateSendHospitalCustomerInfoDto();
                updateSendHospitalCustomerInfoDto.Id = customer.Id;
                await hospitalCustomerInfoService.UpdateConfirmOrderDateAsync(updateSendHospitalCustomerInfoDto);
                await _dalContentPlatformOrder.UpdateAsync(order, true);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message.ToString());
            }



        }


        /// <summary>
        /// 获取已绑定客服的内容平台订单列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="customerServiceId"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="liveAnchorWechatNoId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<BindCustomerServiceContentPlatformOrderDto>> GetBindCustomerServieContentPlatformOrdersAsync(int? customerServiceId, int? liveAnchorId, DateTime? startDate, DateTime? endDate, string keyword, string liveAnchorWechatNoId, int pageNum, int pageSize)
        {
            var config = await _wxAppConfigService.GetWxAppCallCenterConfigAsync();
            var orders = from d in _dalContentPlatformOrder.GetAll()
                         join c in _dalBindCustomerService.GetAll() on d.Phone equals c.BuyerPhone
                         where (string.IsNullOrWhiteSpace(keyword) || d.Id == keyword || d.Phone == keyword || d.CustomerName.Contains(keyword))
                         && (customerServiceId == null || c.CustomerServiceId == customerServiceId)
                         && (liveAnchorId == null || d.LiveAnchorId == liveAnchorId)
                         && (string.IsNullOrWhiteSpace(liveAnchorWechatNoId) || d.LiveAnchorWeChatNo == liveAnchorWechatNoId)
                         && (startDate == null && endDate == null || d.CreateDate >= startDate.Value && d.CreateDate < endDate.Value.AddDays(1))
                         select new BindCustomerServiceContentPlatformOrderDto
                         {
                             Id = d.Id,
                             OrderType = d.OrderType,
                             OrderTypeText = ServiceClass.GetContentPlateFormOrderTypeText((byte)d.OrderType),
                             ContentPlatformId = d.ContentPlateformId,
                             ContentPlatformName = d.Contentplatform.ContentPlatformName,
                             LiveAnchorId = d.LiveAnchorId,
                             LiveAnchorName = d.LiveAnchor.HostAccountName,
                             CreateDate = d.CreateDate,
                             UpdateDate = d.UpdateDate,
                             GoodsId = d.GoodsId,
                             LiveAnchorWeChatNo = d.LiveAnchorWeChatNo,
                             GoodsName = d.AmiyaGoodsDemand.ProjectNname,
                             ThumbPictureUrl = d.AmiyaGoodsDemand.ThumbPictureUrl,
                             CustomerName = d.CustomerName,
                             AppointmentDate = d.AppointmentDate,
                             AppointmentHospitalId = d.AppointmentHospitalId,
                             AppointmentHospitalName = d.HospitalInfo.Name,
                             OrderStatus = d.OrderStatus,
                             OrderStatusText = ServiceClass.GetContentPlateFormOrderStatusText((byte)d.OrderStatus),
                             Remark = d.Remark,
                             EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                             Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                             CustomerServiceId = c.CustomerServiceId,
                             CustomerServiceName = c.CustomerServiceAmiyaEmployee.Name,

                         };
            FxPageInfo<BindCustomerServiceContentPlatformOrderDto> pageInfo = new FxPageInfo<BindCustomerServiceContentPlatformOrderDto>();
            pageInfo.TotalCount = await orders.CountAsync();
            pageInfo.List = await orders.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            foreach (var x in pageInfo.List)
            {
                if (!string.IsNullOrEmpty(x.LiveAnchorWeChatNo))
                {
                    var wechatNoInfo = await liveAnchorWeChatInfoService.GetByIdAsync(x.LiveAnchorWeChatNo);
                    if (wechatNoInfo.Id != null)
                    {
                        x.LiveAnchorWeChatNo = wechatNoInfo.WeChatNo;
                    }
                }
            }
            return pageInfo;
        }




        private async Task<CallCenterConfigDto> GetCallCenterConfig()
        {
            var config = await _dalConfig.GetAll().SingleOrDefaultAsync();
            return JsonConvert.DeserializeObject<WxAppConfigDto>(config.ConfigJson).CallCenterConfig;
        }

        #region 财务看板


        #endregion

        #region 【报表相关】
        public async Task<List<SendContentPlatformOrderDto>> GetSendOrderReportList(int? liveAnchorId, int employeeId, int belongEmpId, int? orderStatus
     , string contentPlatFormId, DateTime? startDate, DateTime? endDate, bool isHidePhone)
        {
            var orders = _dalContentPlatformOrder.GetAll()
                       .Where(e => belongEmpId == -1 || e.BelongEmpId == belongEmpId)
                       .Where(e => !liveAnchorId.HasValue || e.LiveAnchorId == liveAnchorId.Value)
                       .Where(e => e.OrderStatus != (int)ContentPlateFormOrderStatus.HaveOrder)
                       .Where(e => string.IsNullOrWhiteSpace(contentPlatFormId) || e.ContentPlateformId == contentPlatFormId);
            if (startDate != null && endDate != null)
            {
                DateTime startrq = ((DateTime)startDate).Date;
                DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
                orders = from d in orders
                         where (d.ContentPlatformOrderSendList.OrderByDescending(x => x.SendDate).FirstOrDefault().SendDate >= startrq && d.ContentPlatformOrderSendList.OrderByDescending(x => x.SendDate).FirstOrDefault().SendDate < endrq)
                         select d;
            }

            var contentPlatformOrders = from d in orders
                                        select new SendContentPlatformOrderDto
                                        {
                                            OrderId = d.Id,
                                            ContentPlatFormName = d.Contentplatform.ContentPlatformName,
                                            LiveAnchorName = d.LiveAnchor.HostAccountName,
                                            CustomerName = d.CustomerName,
                                            Phone = isHidePhone == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                            AppointmentHospital = d.HospitalInfo.Name,
                                            SendHospitalId = d.ContentPlatformOrderSendList.OrderByDescending(x => x.SendDate).FirstOrDefault().HospitalId,
                                            AppointmentDate = d.AppointmentDate.HasValue ? d.AppointmentDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "未确认时间",
                                            GoodsName = d.AmiyaGoodsDemand.ProjectNname,
                                            ThumbPictureUrl = d.AmiyaGoodsDemand.ThumbPictureUrl,
                                            LateProjectStage = d.LateProjectStage,
                                            ConsultingContent = d.ConsultingContent,
                                            OrderTypeText = ServiceClass.GetContentPlateFormOrderTypeText((byte)d.OrderType),
                                            OrderStatusText = ServiceClass.GetContentPlateFormOrderStatusText((byte)d.OrderStatus),
                                            DepositAmount = d.DepositAmount,
                                            DealAmount = d.DealAmount,
                                            DealPictureUrl = d.DealPictureUrl,
                                            IsToHospital = d.IsToHospital,
                                            UnDealReason = d.UnDealReason,
                                            Sender = d.ContentPlatformOrderSendList.OrderByDescending(x => x.SendDate).FirstOrDefault().Sender,
                                            SenderName = d.ContentPlatformOrderSendList.OrderByDescending(x => x.SendDate).FirstOrDefault().AmiyaEmployee.Name,
                                            SendDate = d.ContentPlatformOrderSendList.OrderByDescending(x => x.SendDate).FirstOrDefault().SendDate,
                                            SendOrderRemark = d.Remark,
                                            DealDate = d.DealDate,
                                            OrderRemark = d.Remark,
                                            HospitalRemark = d.ContentPlatformOrderSendList.OrderByDescending(x => x.SendDate).FirstOrDefault().HospitalRemark,
                                            UnDealPictureUrl = d.UnDealPictureUrl,
                                            BelongEmpId = d.BelongEmpId.Value
                                        };

            List<SendContentPlatformOrderDto> pageInfo = new List<SendContentPlatformOrderDto>();
            pageInfo = await contentPlatformOrders.OrderByDescending(x => x.SendDate).ToListAsync();
            foreach (var x in pageInfo)
            {
                var empInfo = await _amiyaEmployeeService.GetByIdAsync(x.Sender);
                x.SenderName = empInfo.Name;

                x.SendHospital = _hospitalInfoService.GetByIdAsync(x.SendHospitalId).Result.Name;
                if (x.BelongEmpId != 0)
                {
                    var empInfo2 = await _amiyaEmployeeService.GetByIdAsync(x.BelongEmpId);
                    if (empInfo.Id != 0)
                    {
                        x.BelongEmpName = empInfo.Name;
                    }
                }
            }
            return pageInfo;
        }
        #endregion

        #region 枚举展示
        public List<ContentPlateFormOrderTypeDto> GetOrderTypeList()
        {
            var orderTypes = Enum.GetValues(typeof(ContentPlateFormOrderType));
            List<ContentPlateFormOrderTypeDto> orderTypeList = new List<ContentPlateFormOrderTypeDto>();
            foreach (var item in orderTypes)
            {
                ContentPlateFormOrderTypeDto orderType = new ContentPlateFormOrderTypeDto();
                orderType.OrderType = Convert.ToByte(item);
                orderType.OrderTypeText = ServiceClass.GetContentPlateFormOrderTypeText(Convert.ToByte(item));
                orderTypeList.Add(orderType);
            }
            return orderTypeList;
        }

        public List<ContentPlateFormOrderTypeDto> GetOrderToHospitalTypeList()
        {
            var orderTypes = Enum.GetValues(typeof(ContentPlateFormOrderToHospitalType));
            List<ContentPlateFormOrderTypeDto> orderTypeList = new List<ContentPlateFormOrderTypeDto>();
            foreach (var item in orderTypes)
            {
                ContentPlateFormOrderTypeDto orderType = new ContentPlateFormOrderTypeDto();
                orderType.OrderType = Convert.ToByte(item);
                orderType.OrderTypeText = ServiceClass.GerContentPlatFormOrderToHospitalTypeText(Convert.ToByte(item));
                orderTypeList.Add(orderType);
            }
            return orderTypeList;
        }

        public List<ContentPlateFormOrderStatusDto> GetOrderStatusList()
        {
            var orderStatusResult = Enum.GetValues(typeof(ContentPlateFormOrderStatus));
            List<ContentPlateFormOrderStatusDto> orderTypeList = new List<ContentPlateFormOrderStatusDto>();
            foreach (var item in orderStatusResult)
            {
                ContentPlateFormOrderStatusDto orderStatus = new ContentPlateFormOrderStatusDto();
                orderStatus.OrderStatus = Convert.ToByte(item);
                orderStatus.OrderStatusText = ServiceClass.GetContentPlateFormOrderStatusText(Convert.ToByte(item));
                orderTypeList.Add(orderStatus);
            }
            return orderTypeList;
        }

        public List<ContentPlateFormOrderSourceDto> GetOrderSourceList()
        {
            var orderSources = Enum.GetValues(typeof(ContentPlateFormOrderSource));
            List<ContentPlateFormOrderSourceDto> orderTypeList = new List<ContentPlateFormOrderSourceDto>();
            foreach (var item in orderSources)
            {
                ContentPlateFormOrderSourceDto orderType = new ContentPlateFormOrderSourceDto();
                orderType.OrderSource = Convert.ToByte(item);
                orderType.OrderSourceText = ServiceClass.GerContentPlatFormOrderSourceText(Convert.ToByte(item));
                orderTypeList.Add(orderType);
            }
            return orderTypeList;
        }

        public List<ContentPlateFormOrderTypeDto> GetOrderConsultationTypeList()
        {
            var orderTypes = Enum.GetValues(typeof(ContentPlateFormOrderConsultationType));
            List<ContentPlateFormOrderTypeDto> orderTypeList = new List<ContentPlateFormOrderTypeDto>();
            foreach (var item in orderTypes)
            {
                ContentPlateFormOrderTypeDto orderType = new ContentPlateFormOrderTypeDto();
                orderType.OrderType = Convert.ToByte(item);
                orderType.OrderTypeText = ServiceClass.GetContentPlateFormOrderConsultationTypeText(Convert.ToByte(item));
                orderTypeList.Add(orderType);
            }
            return orderTypeList;
        }

        #endregion

        #region 【数据中心板块】



        /// <summary>
        /// 获取时间段内未派单数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<OrderOperationConditionDto>> GetOrderUnSendDataAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);

            var orders = from o in _dalContentPlatformOrder.GetAll()
                         where o.OrderStatus == Convert.ToInt16(ContentPlateFormOrderStatus.HaveOrder)
                         && o.CreateDate >= startrq && o.CreateDate < endrq
                         select o;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.CreateDate.Date).Select(x => new OrderOperationConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderNum = x.ToList().Count }).ToList();
        }

        /// <summary>
        /// 获取时间段内到院数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<OrderOperationConditionDto>> GetOrderToHospitalDataAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
            var orders = from d in _dalContentPlatformOrder.GetAll()
                         where d.IsToHospital == true && d.ToHospitalDate.Value >= startrq && d.ToHospitalDate.Value < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.ToHospitalDate.Value.Date).Select(x => new OrderOperationConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderNum = x.ToList().Count }).ToList();
        }

        /// <summary>
        /// 获取时间段内客户消费金额
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<OrderPriceConditionDto>> GetOrderDealPriceAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);

            var orders = from o in _dalContentPlatformOrder.GetAll()
                         where o.OrderStatus == Convert.ToInt16(ContentPlateFormOrderStatus.OrderComplete)
                         && o.DealDate >= startrq && o.DealDate < endrq
                         select o;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.DealDate).Select(x => new OrderPriceConditionDto { Date = x.Key.Value.ToString("yyyy-MM-dd"), OrderPrice = x.Sum(z => z.DepositAmount.Value) + x.Sum(z => z.DealAmount.Value) }).ToList();
        }

        /// <summary>
        /// 获取时间段内派单医院成交订单
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<HospitalOrderNumAndPriceDto>> GetOrderSendAndDealDataAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
            var orders = from d in _dalContentPlatformOrder.GetAll()
                         where d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete && d.DealDate.Value >= startrq && d.DealDate.Value < endrq
                         select d;
            var sendOrder = from d in orders
                            select new HospitalOrderNumAndPriceDto
                            {
                                Price = d.DepositAmount.Value + d.DealAmount.Value,
                                HospitalName = d.LastDealHospitalId.ToString(),
                                OrderNum = 1
                            };
            var result = sendOrder.ToList();
            List<HospitalOrderNumAndPriceDto> returnInfo = new List<HospitalOrderNumAndPriceDto>();

            foreach (var x in result)
            {
                if (!string.IsNullOrEmpty(x.HospitalName))
                {
                    HospitalOrderNumAndPriceDto returnResult = new HospitalOrderNumAndPriceDto();
                    var hospitalInfo = await _hospitalInfoService.GetBaseByIdAsync(Convert.ToInt32(x.HospitalName));
                    returnResult.HospitalName = hospitalInfo.Name;
                    returnResult.Price = x.Price;
                    returnResult.OrderNum = x.OrderNum;
                    returnInfo.Add(returnResult);
                }
            }
            return returnInfo;
        }
        /// <summary>
        /// 获取时间段内成交数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<OrderOperationConditionDto>> GetOrderDealDataAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
            var orders = from d in _dalContentPlatformOrder.GetAll()
                         where d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete && d.DealDate.Value >= startrq && d.DealDate.Value < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.DealDate.Value.Date).Select(x => new OrderOperationConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderNum = x.ToList().Count }).ToList();
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
            var orders = from d in _dalContentPlatformOrder.GetAll()
                         where d.CheckState == (int)CheckType.CheckedSuccess && d.CheckDate.Value >= startrq && d.CheckDate.Value < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.CheckDate.Value.Date).Select(x => new OrderPriceConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderPrice = x.Sum(z => z.CheckPrice.Value) }).ToList();
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
            var orders = from d in _dalContentPlatformOrder.GetAll()
                         where d.IsReturnBackPrice == true && d.ReturnBackDate.Value >= startrq && d.ReturnBackDate.Value < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.ReturnBackDate.Value.Date).Select(x => new OrderPriceConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderPrice = x.Sum(z => z.ReturnBackPrice.Value) }).ToList();
        }

        /// <summary>
        /// 获取时间段内咨询达人业绩
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<HospitalOrderNumAndPriceDto>> GetLiveAnchorPerformanceInfoAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
            var orders = from d in _dalContentPlatformOrder.GetAll()
                         where (d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete) && d.DealDate >= startrq && d.DealDate < endrq
                         select d;
            var a = orders.ToList();
            var sendOrder = from d in orders
                            select new HospitalOrderNumAndPriceDto
                            {
                                Price = d.DepositAmount.Value + d.DealAmount.Value,
                                HospitalName = d.LiveAnchorId.ToString(),
                                OrderNum = 1
                            };
            var result = sendOrder.ToList();
            List<HospitalOrderNumAndPriceDto> returnInfo = new List<HospitalOrderNumAndPriceDto>();

            foreach (var x in result)
            {
                if (!string.IsNullOrEmpty(x.HospitalName))
                {
                    HospitalOrderNumAndPriceDto returnResult = new HospitalOrderNumAndPriceDto();
                    var liveanchorInfo = await _liveAnchorService.GetByIdAsync(Convert.ToInt32(x.HospitalName));
                    returnResult.HospitalName = liveanchorInfo.Name;
                    returnResult.Price = x.Price;
                    returnResult.OrderNum = x.OrderNum;
                    returnInfo.Add(returnResult);
                }
            }
            return returnInfo;
        }

        /// <summary>
        /// 根据客服id获取简单的客服数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="belongCustomerServiceIds"></param>
        /// <returns></returns>
        public async Task<CustomerServiceSimplePerformanceDto> GetCustomerServiceSimpleByCustomerServiceIdAsync(DateTime? startDate, DateTime? endDate, int belongCustomerServiceId)
        {
            var dealData = _dalContentPlatformOrder.GetAll().Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => belongCustomerServiceId == 0 || belongCustomerServiceId == e.BelongEmpId.Value);
            var dealResult = await dealData
                .SelectMany(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.IsToHospital == true)
                .GroupBy(e => e.ContentPlatFormOrder.BelongEmpId)
                .Select(e => new CustomerServiceSimplePerformanceDto
                {
                    CustomerServiceId = e.Key.Value,
                    TotaPrice = DecimalExtension.ChangePriceToTenThousand(e.Sum(e => e.Price)),
                    NewCustomerPrice = DecimalExtension.ChangePriceToTenThousand(e.Sum(e => e.IsOldCustomer ? 0m : e.Price)),
                    OldCustomerPrice = DecimalExtension.ChangePriceToTenThousand(e.Sum(e => e.IsOldCustomer ? e.Price : 0m)),
                    NewCustomerNum = e.Sum(x => x.ToHospitalType == (int)ContentPlateFormOrderToHospitalType.FIRST_SEEK_ADVICE ? 1 : 0),
                    DealNum = e.Sum(e => e.IsDeal == true ? 1 : 0),
                    SequentCustomerNum = e.Sum(x => ((x.ToHospitalType == (int)ContentPlateFormOrderToHospitalType.AGAIN_SEEK_ADVICE || x.ToHospitalType == (int)ContentPlateFormOrderToHospitalType.AGAIN_CONSUMPTION) && x.IsDeal == true) ? 1 : 0),
                    OldCustomerNum = e.Sum(x => x.IsOldCustomer == true && x.IsDeal == true ? 1 : 0),
                }).FirstOrDefaultAsync();

            if (dealResult == null)
            {
                dealResult = new CustomerServiceSimplePerformanceDto();
            }

            var supportData = _dalContentPlatformOrder.GetAll().Include(e => e.ContentPlatformOrderDealInfoList)
            .Where(e => belongCustomerServiceId == e.SupportEmpId)
            .SelectMany(k => k.ContentPlatformOrderDealInfoList)
            .Where(u => u.CreateDate >= startDate && u.CreateDate < endDate && u.IsDeal == true);
            dealResult.SupportPrice = DecimalExtension.ChangePriceToTenThousand(supportData.Sum(x => x.Price));
            dealResult.TotaPrice += dealResult.SupportPrice;
            string belongLiveAnchorId = "";
            var empInfo = await _amiyaEmployeeService.GetByIdAsync(belongCustomerServiceId);
            dealResult.CustomerServiceName = empInfo.Name;
            dealResult.NewOrOldCustomerRate = DecimalExtension.CalculateAccounted(dealResult.NewCustomerPrice, dealResult.OldCustomerPrice);
            var sendInfo = dealData.Where(x => x.OrderStatus != (int)ContentPlateFormOrderStatus.HaveOrder && x.OrderStatus != (int)ContentPlateFormOrderStatus.RepeatOrder && x.BelongEmpId == belongCustomerServiceId && x.SendDate >= startDate && x.SendDate < endDate).ToList();
            var thisMonthVisitInfo = sendInfo.Where(x => x.IsToHospital == true).ToList();
            var distinctSendInfo = dealData.Where(x => x.OrderStatus != (int)ContentPlateFormOrderStatus.HaveOrder && x.BelongEmpId == belongCustomerServiceId && x.OrderStatus != (int)ContentPlateFormOrderStatus.RepeatOrder && x.SendDate >= startDate && x.SendDate < endDate).GroupBy(x => x.Phone).Select(k => k.Key.First()).ToList();
            var visitInfo = dealData.Where(x => x.IsToHospital == true && x.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault().CreateDate >= startDate && x.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault().CreateDate < endDate && x.IsOldCustomer == false && x.BelongEmpId == belongCustomerServiceId).ToList();
            dealResult.VisitRate = DecimalExtension.CalculateTargetComplete(visitInfo.Count(), distinctSendInfo.Count());
            dealResult.ThisMonthSendThisMonthVisitNumRatio = DecimalExtension.CalculateTargetComplete(thisMonthVisitInfo.Count(), distinctSendInfo.Count());
            belongLiveAnchorId = empInfo.LiveAnchorBaseId;
            if (empInfo.IsCustomerService == true)
            {
                //根据主播分组排名
                // var employeeInfos = await _amiyaEmployeeService.GetByLiveAnchorBaseIdAsync(belongLiveAnchorId);
                //var amiyaEmployeeIds = employeeInfos.Select(x => x.Id).ToList();
                //全部排名
                var amiyaEmployeeIds = new List<int>();

                var rankResult = await this.GetCustomerServiceBelongBoardDataByCustomerServiceIdAsync(startDate, endDate, amiyaEmployeeIds);
                List<CustomerServiceRankDto> CustomerServiceRankDtoList = new List<CustomerServiceRankDto>();
                int rank = 1;
                bool hasRank = false;
                foreach (var x in rankResult)
                {
                    CustomerServiceRankDto customerServiceRankDto = new CustomerServiceRankDto();
                    customerServiceRankDto.TotalAchievement = DecimalExtension.ChangePriceToTenThousand(x.TotalServicePrice);
                    if (customerServiceRankDto.TotalAchievement <= 0.00M)
                    {
                        continue;
                    }
                    customerServiceRankDto.RankId = rank;
                    customerServiceRankDto.CustomerServiceId = x.CustomerServiceId;
                    customerServiceRankDto.CustomerServiceName = x.CustomerServiceName;

                    if (hasRank == false)
                    {
                        if (belongCustomerServiceId == x.CustomerServiceId)
                        {
                            dealResult.Rank = rank.ToString();
                            hasRank = true;
                        }
                        else
                        {
                            dealResult.Rank = "#";
                        }
                    }
                    CustomerServiceRankDtoList.Add(customerServiceRankDto);

                    rank++;
                }
                dealResult.CustomerServiceRankDtoList = CustomerServiceRankDtoList;
            }
            return dealResult;
        }

        /// <summary>
        /// 根据客服id获取客服业绩信息
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="customerServiceId"></param>
        /// <returns></returns>
        public async Task<List<CustomerServiceDetailsPerformanceDto>> GetCustomerServiceBelongBoardDataByCustomerServiceIdAsync(DateTime? startDate, DateTime? endDate, List<int> belongCustomerServiceIds)
        {
            var dealData = _dalContentPlatformOrder.GetAll().Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => belongCustomerServiceIds.Count == 0 || belongCustomerServiceIds.Contains(e.BelongEmpId.Value));
            var dealResult = dealData
                .SelectMany(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.IsDeal == true)
                .GroupBy(e => e.ContentPlatFormOrder.BelongEmpId)
                .Select(e => new CustomerServiceDetailsPerformanceDto
                {
                    CustomerServiceId = e.Key.Value,
                    DealPrice = e.Sum(e => e.CheckPrice ?? 0m),
                    TotalServicePrice = e.Sum(e => e.Price),
                    NewCustomerPrice = e.Sum(e => e.IsOldCustomer ? 0m : e.Price),
                    NewCustomerServicePrice = e.Sum(e => e.IsOldCustomer ? 0m : e.SettlePrice ?? 0m),
                    OldCustomerPrice = e.Sum(e => e.IsOldCustomer ? e.Price : 0m),
                    OldCustomerServicePrice = e.Sum(e => e.IsOldCustomer ? e.SettlePrice ?? 0m : 0m),
                    AcompanyingPerformance = e.Sum(x => x.IsAcompanying ? x.Price : 0m),
                    NotAcompanyingPerformance = e.Sum(x => x.IsAcompanying ? 0m : x.Price),

                }).ToList();

            foreach (var z in dealResult)
            {
                var supportData = _dalContentPlatformOrder.GetAll().Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.IsSupportOrder == true && e.SupportEmpId == z.CustomerServiceId)
                .SelectMany(k => k.ContentPlatformOrderDealInfoList)
                .Where(u => u.CreateDate >= startDate && u.CreateDate < endDate && u.IsDeal == true);
                var supp = await supportData.ToListAsync();
                z.SupportPrice = supportData.Sum(x => x.Price);
                z.TotalServicePrice += z.SupportPrice;
                z.CustomerServiceName = await _dalAmiyaEmployee.GetAll().Where(e => e.Id == Convert.ToInt32(z.CustomerServiceId)).Select(e => e.Name).FirstOrDefaultAsync();
                var sendInfo = dealData.Where(x => x.OrderStatus != (int)ContentPlateFormOrderStatus.HaveOrder && x.OrderStatus != (int)ContentPlateFormOrderStatus.RepeatOrder && x.BelongEmpId == z.CustomerServiceId && x.SendDate >= startDate && x.SendDate < endDate).ToList();
                var thisMonthVisitInfo = sendInfo.Where(x => x.IsToHospital == true).ToList();
                //根据手机号去重派单数据
                var distinctSendInfo = dealData.Where(x => x.OrderStatus != (int)ContentPlateFormOrderStatus.HaveOrder && x.BelongEmpId == z.CustomerServiceId && x.OrderStatus != (int)ContentPlateFormOrderStatus.RepeatOrder && x.SendDate >= startDate && x.SendDate < endDate).GroupBy(x => x.Phone).Select(k => k.Key.First()).ToList();
                var visitInfo = dealData.Where(x => x.IsToHospital == true && x.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault().CreateDate >= startDate && x.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault().CreateDate < endDate && x.IsOldCustomer == false && x.BelongEmpId == z.CustomerServiceId).ToList();

                var dealInfo = dealData.Where(x => x.OrderStatus != (int)ContentPlateFormOrderStatus.HaveOrder && x.OrderStatus != (int)ContentPlateFormOrderStatus.RepeatOrder)
                    .SelectMany(x => x.ContentPlatformOrderDealInfoList).Include(x => x.ContentPlatFormOrder)
                    .Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.IsDeal == true)
                    .ToList();

                z.VideoPerformance = dealInfo.Where(x => x.ContentPlatFormOrder.ConsultationType == (int)ContentPlateFormOrderConsultationType.Collaboration).Sum(k => k.Price);
                z.PicturePerformance = dealInfo.Where(x => x.ContentPlatFormOrder.ConsultationType == (int)ContentPlateFormOrderConsultationType.IndependentFollowUp).Sum(k => k.Price);

                z.ZeroPerformance = dealInfo.Where(x => x.ContentPlatFormOrder.AddOrderPrice == 0).Sum(k => k.Price);
                z.HavingPricePerformance = dealInfo.Where(x => x.ContentPlatFormOrder.AddOrderPrice > 0).Sum(k => k.Price);
                z.HavingPricePerformance += dealInfo.Where(x => x.ContentPlatFormOrder.AddOrderPrice < 0).Sum(k => k.Price);

                z.HistorySendThisMonthDealPerformance = dealInfo.Where(c => c.ContentPlatFormOrder.SendDate.HasValue && c.ContentPlatFormOrder.SendDate < startDate).Sum(x => x.Price);
                z.ThisMonthSendThisMonthDealPerformance = dealInfo.Where(c => c.ContentPlatFormOrder.SendDate.HasValue && c.ContentPlatFormOrder.SendDate >= startDate && c.ContentPlatFormOrder.SendDate < endDate).Sum(x => x.Price);
                z.ThisMonthSendThisMonthVisitNumRatio = DecimalExtension.CalculateTargetComplete(thisMonthVisitInfo.Count(), distinctSendInfo.Count());
                z.VisitNumRatio = DecimalExtension.CalculateTargetComplete(visitInfo.Count(), distinctSendInfo.Count());
                z.VideoAndPictureCompare = DecimalExtension.CalculateAccounted(z.VideoPerformance, z.PicturePerformance);
                z.IsAcompanyingCompare = DecimalExtension.CalculateAccounted(z.AcompanyingPerformance, z.NotAcompanyingPerformance);
                z.ZeroAndHavingPriceCompare = DecimalExtension.CalculateAccounted(z.ZeroPerformance, z.HavingPricePerformance);
                z.HistoryAndThisMonthCompare = DecimalExtension.CalculateAccounted(z.ThisMonthSendThisMonthDealPerformance, z.HistorySendThisMonthDealPerformance);
            }
            return dealResult.OrderByDescending(x => x.TotalServicePrice).ToList();
        }

        /// <summary>
        /// 获取时间段内达人助理业绩
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<HospitalOrderNumAndPriceDto>> GetConsultationPerformanceInfoAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
            var orders = from d in _dalContentPlatformOrder.GetAll()
                         where (d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete) && d.DealDate >= startrq && d.DealDate < endrq
                         select d;
            var sendOrder = from d in orders
                            select new HospitalOrderNumAndPriceDto
                            {
                                Price = d.DepositAmount.Value + d.DealAmount.Value,
                                HospitalName = d.ConsultationEmpId.ToString(),
                                OrderNum = 1
                            };
            var result = sendOrder.ToList();
            List<HospitalOrderNumAndPriceDto> returnInfo = new List<HospitalOrderNumAndPriceDto>();

            foreach (var x in result)
            {
                //获取面诊员数据
                if (!string.IsNullOrEmpty(x.HospitalName) && x.HospitalName != "0")
                {
                    HospitalOrderNumAndPriceDto returnResult = new HospitalOrderNumAndPriceDto();
                    var empInfo = await _amiyaEmployeeService.GetByIdAsync(Convert.ToInt32(x.HospitalName));
                    returnResult.HospitalName = empInfo.Name;
                    returnResult.Price = x.Price;
                    returnResult.OrderNum = x.OrderNum;
                    returnInfo.Add(returnResult);
                }
            }
            return returnInfo;
        }

        /// <summary>
        /// 获取时间段内派单客服业绩
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<HospitalOrderNumAndPriceDto>> GetCustomerServicePerformanceInfoAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
            var orders = from d in _dalContentPlatformOrder.GetAll()
                         where (d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete) && d.DealDate >= startrq && d.DealDate < endrq
                         select d;
            var sendOrder = from d in orders
                            select new HospitalOrderNumAndPriceDto
                            {
                                Price = d.DepositAmount.Value + d.DealAmount.Value,
                                HospitalName = d.ContentPlatformOrderSendList.OrderByDescending(k => k.SendDate).First().Sender.ToString(),
                                OrderNum = 1
                            };
            var result = sendOrder.ToList();
            List<HospitalOrderNumAndPriceDto> returnInfo = new List<HospitalOrderNumAndPriceDto>();

            foreach (var x in result)
            {
                if (!string.IsNullOrEmpty(x.HospitalName))
                {
                    HospitalOrderNumAndPriceDto returnResult = new HospitalOrderNumAndPriceDto();
                    var empInfo = await _dalAmiyaEmployee.GetAll().FirstOrDefaultAsync(e => e.Id == Convert.ToInt32(x.HospitalName));
                    returnResult.HospitalName = empInfo.Name;
                    returnResult.Price = x.Price;
                    returnResult.OrderNum = x.OrderNum;
                    returnInfo.Add(returnResult);
                }
            }
            return returnInfo;
        }
        #endregion



        #region 【业绩数据】

        /// <summary>
        /// 获取我的排名
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="belongCustomerServiceId"></param>
        /// <returns></returns>
        public async Task<string> GetMyRankAsync(DateTime? startDate, DateTime? endDate, int belongCustomerServiceId)
        {
            string returnResult = "";
            var empInfo = await _amiyaEmployeeService.GetByIdAsync(belongCustomerServiceId);
            List<int> empLoyeeIds = new List<int>();
            var employeeInfos = await _amiyaEmployeeService.GetByLiveAnchorBaseIdAsync(empInfo.LiveAnchorBaseId);
            var amiyaEmployeeIds = employeeInfos.Select(x => x.Id).ToList();
            var rankResult = await this.GetCustomerServiceBelongBoardDataByCustomerServiceIdAsync(startDate, endDate, empLoyeeIds);
            var res = rankResult.FindIndex(x => x.CustomerServiceId == belongCustomerServiceId) + 1;
            if (res == 0)
            {
                returnResult = "#";
            }
            else
            {
                returnResult = res.ToString();
            }
            return returnResult;
        }
        /// <summary>
        ///  根据条件获取照片/视频面诊业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isVideo"></param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        public async Task<List<ContentPlatFormOrderInfoSimpleDto>> GetPictureOrVideoPerformanceByLiveAnchorAsync(int year, int month, bool isVideo, List<int> liveAnchorIds)
        {
            try
            {
                //开始月份
                DateTime currentDate = new DateTime(year, month, 1);
                //结束月份
                DateTime endDate = new DateTime(year, month, 1).AddMonths(1);
                //decimal? Price = 99.00M;
                int consolationType = 0;
                if (isVideo == true)
                {
                    consolationType = (int)ContentPlateFormOrderConsultationType.Collaboration;
                }
                else
                {
                    consolationType = (int)ContentPlateFormOrderConsultationType.IndependentFollowUp;
                }
                var order = from d in _dalContentPlatformOrder.GetAll()
                            where (liveAnchorIds.Contains(d.LiveAnchorId.Value) && d.ConsultationType == consolationType && d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete)
                            where (d.DealDate.HasValue == true && d.DealAmount.HasValue && d.DealDate.Value >= currentDate && d.DealDate.Value < endDate)
                            select new ContentPlatFormOrderInfoSimpleDto
                            {
                                Id = d.Id,
                                OrderTypeText = ServiceClass.GetContentPlateFormOrderTypeText((byte)d.OrderType),
                                ContentPlatformName = d.Contentplatform.ContentPlatformName,
                                ConsultingContent = d.ConsultingContent,
                                LateProjectStage = d.LateProjectStage,
                                CreateDate = d.CreateDate,
                                LiveAnchorName = d.LiveAnchor.HostAccountName,
                                GoodsName = d.AmiyaGoodsDemand.ProjectNname,
                                DepositAmount = d.DepositAmount,
                                DealAmount = d.DealAmount,
                                UnDealReason = d.UnDealReason,
                                AppointmentDate = d.AppointmentDate.HasValue ? d.AppointmentDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "未确认时间",
                                AppointmentHospitalName = d.HospitalInfo.Name,
                                OrderStatusText = ServiceClass.GetContentPlateFormOrderStatusText((byte)d.OrderStatus),
                                Remark = d.Remark,
                            };
                return await order.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        ///  根据条件获取派单成交业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isDeal">是否成交</param>
        /// <param name="isToHospital">是否上门</param>
        /// <param name="isOldCustomer">新/老客业绩</param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        public async Task<List<ContentPlatFormOrderInfoDto>> GetSendOrDealPerformanceByLiveAnchorAsync(List<int> liveAnchorIds)
        {
            try
            {
                var order = await _dalContentPlatformOrder.GetAll().Where(d => liveAnchorIds.Contains(d.LiveAnchorId.Value) && d.OrderStatus != (int)ContentPlateFormOrderStatus.HaveOrder).ToListAsync();
                var result = from d in order
                             select new ContentPlatFormOrderInfoDto
                             {

                                 Id = d.Id,
                                 SendDate = d.SendDate,
                                 ToHospitalDate = d.ToHospitalDate,
                                 IsToHospital = d.IsToHospital,
                                 IsOldCustomer = d.IsOldCustomer,
                                 OrderStatus = d.OrderStatus,
                                 DealDate = d.DealDate,
                                 CreateDate = d.CreateDate,
                             };
                var resultInfo = result.ToList();
                return resultInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 获取派单成交数据
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns></returns>
        public async Task<OrderSendAndDealNumDto> GetOrderSendAndDealDataByMonthAsync(DateTime startDate, DateTime endDate, bool? isEffectiveCustomerData, string contentPlatFormId)
        {
            OrderSendAndDealNumDto orderData = new OrderSendAndDealNumDto();
            orderData.SendOrderNum = await _dalContentPlatformOrder.GetAll()
             .Where(o => o.SendDate >= startDate && o.SendDate < endDate)
             .Where(e => e.OrderStatus != (int)ContentPlateFormOrderStatus.RepeatOrder && e.IsOldCustomer == false)
             .Where(o => string.IsNullOrEmpty(contentPlatFormId) || o.ContentPlateformId == contentPlatFormId)
             .Where(o => isEffectiveCustomerData == true ? o.AddOrderPrice > 0 : o.AddOrderPrice == 0)
                .Select(e => e.Phone)
                .Distinct()
                .CountAsync();



            var visitCount = await _dalContentPlatformOrder.GetAll()
             .Where(o => o.ToHospitalDate >= startDate && o.ToHospitalDate < endDate)
             .Where(e => e.OrderStatus != (int)ContentPlateFormOrderStatus.RepeatOrder && e.IsToHospital == true && e.IsOldCustomer == false)
             .Where(o => string.IsNullOrEmpty(contentPlatFormId) || o.ContentPlateformId == contentPlatFormId)
             .Where(o => isEffectiveCustomerData == true ? o.AddOrderPrice > 0 : o.AddOrderPrice == 0)
                .ToListAsync();

            orderData.VisitNum = visitCount
                .Select(e => e.Phone)
                .Distinct()
                .Count();

            orderData.DealNum = visitCount.Where(x => x.DealDate >= startDate && x.DealDate < endDate && x.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete).Select(e => e.Phone)
                .Distinct()
                .Count();


            orderData.DealPrice = visitCount.Where(x => x.DealDate >= startDate && x.DealDate < endDate && x.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete)
                .Sum(x => x.DealAmount);

            return orderData;
        }

        /// <summary>
        /// 获取老客复购数据
        /// </summary>
        /// <param name="date">时间</param>
        /// <returns></returns>
        public async Task<OldCustomerDealNumDto> GetOldCustomerBuyAgainByMonthAsync(DateTime date, bool isEffectiveCustomerData, string contentPlatFormId)
        {
            DateTime startDate = Convert.ToDateTime("2000-01-01");
            var dealDate = await _dalContentPlatformOrder.GetAll().Include(x => x.ContentPlatformOrderDealInfoList)
             .Where(o => string.IsNullOrEmpty(contentPlatFormId) || o.ContentPlateformId == contentPlatFormId)
             .Where(o => isEffectiveCustomerData == true ? o.AddOrderPrice > 0 : o.AddOrderPrice == 0)
                .Where(e => e.IsToHospital == true && e.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete && e.DealDate.Value >= startDate && e.DealDate.Value < date).ToListAsync();
            OldCustomerDealNumDto orderData = new OldCustomerDealNumDto();
            orderData.TotalDealCustomer = dealDate
                .Select(e => e.Phone)
                .Distinct()
                .Count();

            orderData.SecondDealCustomer = dealDate.Where(x => x.ContentPlatformOrderDealInfoList.Where(x => x.IsDeal == true).Count() == 2).Select(e => e.Phone)
                .Distinct()
                .Count();

            orderData.ThirdDealCustomer = dealDate.Where(x => x.ContentPlatformOrderDealInfoList.Where(x => x.IsDeal == true).Count() == 3).Select(e => e.Phone)
                .Distinct()
                .Count();
            orderData.FourthOrMoreDealCustomer = dealDate.Where(x => x.ContentPlatformOrderDealInfoList.Where(x => x.IsDeal == true).Count() >= 4).Select(e => e.Phone)
                .Distinct()
                .Count();

            return orderData;
        }

        /// <summary>
        /// 获取总订单数
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isSend"></param>
        /// <param name="isDeal"></param>
        /// <param name="isToHospital"></param>
        /// <param name="isOldCustomer"></param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        public async Task<List<ContentPlatFormOrderInfoSimpleDto>> GetAddOrderPerformanceByLiveAnchorAsync(int year, int month, List<int> liveAnchorIds)
        {
            try
            {
                //开始月份
                DateTime currentDate = new DateTime(year, month, 1);
                //结束月份
                DateTime endDate = new DateTime(year, month, 1).AddMonths(1);
                var order = await _dalContentPlatformOrder.GetAll().ToListAsync();
                order = order.Where(d => liveAnchorIds.Contains(d.LiveAnchorId.Value))
                           .Where(d => d.CreateDate >= currentDate && d.CreateDate < endDate).ToList();
                var result = from d in order
                             select new ContentPlatFormOrderInfoSimpleDto
                             {
                                 Id = d.Id,
                             };
                var resultInfo = result.ToList();
                return resultInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取照片/视频面诊业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isVideo"></param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetPictureOrVideoPerformanceByLiveAnchorBrokenLineAsync(int year, int month, bool isVideo, List<int> liveAnchorIds)
        {
            try
            {  //开始月份
                DateTime startTime = new DateTime(year, 1, 1);
                //筛选结束的月份
                DateTime endDate = new DateTime(year, month, 1).AddMonths(1);
                int consolationType = 0;
                if (isVideo == true)
                {
                    consolationType = (int)ContentPlateFormOrderConsultationType.Collaboration;
                }
                else
                {
                    consolationType = (int)ContentPlateFormOrderConsultationType.IndependentFollowUp;
                }
                var orderinfo = await _dalContentPlatformOrder.GetAll()
                   .Where(d => d.DealDate.HasValue == true && d.DealAmount.HasValue && d.DealDate.Value >= startTime && d.DealDate.Value < endDate)
                    .Where(d => liveAnchorIds.Contains(d.LiveAnchorId.Value) && d.ConsultationType == consolationType && d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete)
                    .ToListAsync();


                return orderinfo.GroupBy(x => x.DealDate.Value.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Sum(z => z.DealAmount.Value) }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取派单成交业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isSend"></param>
        /// <param name="isDeal"></param>
        /// <param name="isToHospital"></param>
        /// <param name="isOldCustomer"></param>
        /// <param name="liveAnchorIds"></param>
        /// <returns></returns>
        public async Task<List<ContentPlatFormOrderInfoDto>> GetSendOrDealPerformanceByLiveAnchorBrokenLineAsync(bool? isSend, bool? isDeal, bool? isToHospital, bool? isOldCustomer, List<int> liveAnchorIds)
        {
            try
            {
                var order = await _dalContentPlatformOrder.GetAll().Where(d => liveAnchorIds.Contains(d.LiveAnchorId.Value) && d.OrderStatus != (int)ContentPlateFormOrderStatus.HaveOrder).ToListAsync();
                var result = from d in order
                             select new ContentPlatFormOrderInfoDto
                             {

                                 Id = d.Id,
                                 SendDate = d.SendDate,
                                 ToHospitalDate = d.ToHospitalDate,
                                 IsToHospital = d.IsToHospital,
                                 IsOldCustomer = d.IsOldCustomer,
                                 OrderStatus = d.OrderStatus,
                                 DealDate = d.DealDate,
                                 CreateDate = d.CreateDate,
                             };

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 财务看板主播业绩
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="liveAnchorId">主播id</param>
        /// <returns></returns>
        public async Task<List<LiveAnchorBoardDataDto>> GetLiveAnchorPriceByLiveAnchorIdAsync(DateTime? startDate, DateTime? endDate, List<int> liveAnchorIds)
        {
            startDate = startDate == null ? DateTime.Now.Date : startDate;
            endDate = startDate == null ? DateTime.Now.AddDays(1).Date : endDate;
            var dataList = _dalContentPlatformOrder.GetAll().Where(e => e.CheckDate >= startDate && e.CheckDate < endDate && e.CheckState == 2)
                .Where(e => liveAnchorIds.Count == 0 || liveAnchorIds.Contains(e.LiveAnchorId.HasValue ? e.LiveAnchorId.Value : 0))
                .GroupBy(e => new { e.LiveAnchorId, e.BelongCompany })
                .Select(e => new LiveAnchorBoardDataDto
                {
                    CompanyName = e.Key.BelongCompany,
                    LiveAnchorName = e.Key.LiveAnchorId.ToString(),
                    DealPrice = e.Sum(item => item.CheckPrice) ?? 0m,
                    TotalServicePrice = e.Sum(item => item.SettlePrice) ?? 0m,
                    NewCustomerPrice = e.Sum(item => item.IsOldCustomer == false ? item.CheckPrice : 0) ?? 0m,
                    OldCustomerPrice = e.Sum(item => item.IsOldCustomer == true ? item.CheckPrice : 0) ?? 0m,
                    NewCustomerServicePrice = e.Sum(item => item.IsOldCustomer == false ? item.SettlePrice : 0) ?? 0m,
                    OldCustomerServicePrice = e.Sum(item => item.IsOldCustomer == true ? item.SettlePrice : 0) ?? 0m,
                }).ToList();
            foreach (var item in dataList)
            {
                item.LiveAnchorName = dalLiveAnchor.GetAll().Where(e => e.Id == Convert.ToInt32(item.LiveAnchorName)).Select(e => e.Name).SingleOrDefault() ?? "未知(订单没有主播归属信息)";
                item.CompanyName = dalCompanyBaseInfo.GetAll().Where(e => e.Id == item.CompanyName).Select(e => e.Name).SingleOrDefault() ?? "未知(已对账未开票)";
            }
            return dataList;

        }




        #endregion
        #region 机构看板

        /// <summary>
        /// 获取机构订单看板所需的数据
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns></returns>
        public async Task<OrderBaseDto> GetOrderDataByMonthAsync(DateTime startDate, DateTime endDate, int hospitalId, int type)
        {
            var sendCount = dalContentPlatformOrderSend.GetAll()
                .Include(e => e.ContentPlatformOrder)
                .ThenInclude(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.HospitalId == hospitalId && e.ContentPlatformOrder.OrderStatus != (int)ContentPlateFormOrderStatus.RepeatOrder)
                .Select(e => new { Phone = e.ContentPlatformOrder.Phone, OrderStatus = e.ContentPlatformOrder.OrderStatus })
                .ToList();
            OrderBaseDto orderData = new OrderBaseDto();
            orderData.SendOrderCount = sendCount.Select(e => e.Phone).Distinct().Count();

            orderData.ProcessedOrderCount = sendCount.Where(x => x.OrderStatus > (int)ContentPlateFormOrderStatus.SendOrder).Select(e => e.Phone).Distinct().Count();

            orderData.UntreatedOrderCount = sendCount.Where(x => x.OrderStatus == (int)ContentPlateFormOrderStatus.SendOrder).Select(e => e.Phone).Distinct().Count();

            orderData.SendOrderNotToHospitalCount = sendCount.Where(x => x.OrderStatus == (int)ContentPlateFormOrderStatus.ConfirmOrder || x.OrderStatus == (int)ContentPlateFormOrderStatus.SendOrder).Count();

            orderData.ToHospitalNoDealCount = _dalContentPlatformOrder.GetAll()
                .Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.LastDealHospitalId == hospitalId && e.ContentPlatformOrderDealInfoList.Where(e => e.IsDeal == true).Count() <= 0)
                .Select(e => e.Phone)
                .Distinct()
                .Count();

            orderData.DealNoRepurchaseCount = _dalContentPlatformOrder.GetAll()
                .Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.LastDealHospitalId == hospitalId && e.IsOldCustomer == false)
                .Select(e => e.Phone)
                .Distinct()
                .Count();




            return orderData;
        }
        /// <summary>
        /// 获取医院看板订单累计数据
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<OrderBaseDto> GetAccumulateOrderDataAsync(int hospitalId)
        {
            var accumulateSendCount = dalContentPlatformOrderSend.GetAll()
                .Include(e => e.ContentPlatformOrder)
                .ThenInclude(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.HospitalId == hospitalId && e.ContentPlatformOrder.OrderStatus != (int)ContentPlateFormOrderStatus.RepeatOrder)
                .Select(e => new { Phone = e.ContentPlatformOrder.Phone, OrderStatus = e.ContentPlatformOrder.OrderStatus })
                .ToList();
            OrderBaseDto orderData = new OrderBaseDto();
            orderData.AccumulateSendOrderCount = accumulateSendCount
                .Select(e => e.Phone)
                .Distinct()
                .Count();

            orderData.AccumulateProcessedOrderCount = accumulateSendCount
                .Where(x => x.OrderStatus > (int)ContentPlateFormOrderStatus.SendOrder).Select(e => e.Phone)
                .Distinct()
                .Count();

            orderData.AccumulateUntreatedOrderCount = accumulateSendCount
                .Where(x => x.OrderStatus == (int)ContentPlateFormOrderStatus.SendOrder)
                .Select(e => e.Phone)
                .Distinct()
                .Count();

            orderData.AccumulateSendOrderNotToHospitalCount = accumulateSendCount
                .Where(x => x.OrderStatus == (int)ContentPlateFormOrderStatus.ConfirmOrder || x.OrderStatus == (int)ContentPlateFormOrderStatus.SendOrder)
                .Select(e => e.Phone)
                .Count();

            orderData.AccumulateToHospitalNoDealCount = _dalContentPlatformOrder.GetAll()
                .Where(e => e.LastDealHospitalId == hospitalId && e.ContentPlatformOrderDealInfoList.Where(e => e.IsDeal == true).Count() <= 0)
                .Select(e => e.Phone)
                .Distinct()
                .Count();

            orderData.AccumulateDealNoRepurchaseCount = _dalContentPlatformOrder.GetAll()
                .Where(e => e.LastDealHospitalId == hospitalId && e.IsOldCustomer == false)
                .Select(e => e.Phone)
                .Distinct()
                .Count();
            return orderData;
        }
        /// <summary>
        /// 获取机构端运营看板数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<OperaBaseDto> GetOperateDataByMonthAsync(DateTime startDate, DateTime endDate, int hospitalId, int type)
        {

            //派单量
            var sendCount = dalContentPlatformOrderSend.GetAll()
                .Include(e => e.ContentPlatformOrder)
                .Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.HospitalId == hospitalId && e.ContentPlatformOrder.OrderStatus != (int)ContentPlateFormOrderStatus.RepeatOrder)
                .Select(e => e.ContentPlatformOrder.Phone).ToList()
                .Distinct()
                .Count();


            //当月新客上门人数
            var newCustomerToHospitalCount = type == (int)HospitalBoardDataType.ThisMonth ? dalContentPlatformOrderSend.GetAll()
                .Include(e => e.ContentPlatformOrder)
                .Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.HospitalId == hospitalId && e.ContentPlatformOrder.OrderStatus != (int)ContentPlateFormOrderStatus.RepeatOrder && e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.IsOldCustomer == false).Count() > 0)
                .Select(e => e.ContentPlatformOrder.Phone).Distinct().Count()
                : dalContentPlatFormOrderDealInfo.GetAll()
                .Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.LastDealHospitalId == hospitalId && e.IsToHospital == true && e.IsOldCustomer == false)
                .Select(e => e.ContentPlatFormOrder.Phone)
                .Distinct()
                .Count();

            //累计新客上门人数
            //var totalNewCustomerToHospitalCount = 

            //当月新客成交量
            var newCustomerDealCount = type == (int)HospitalBoardDataType.ThisMonth ? dalContentPlatformOrderSend.GetAll().Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.HospitalId == hospitalId)
                .Include(e => e.ContentPlatformOrder)
                .ThenInclude(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.IsDeal == true && e.IsOldCustomer == false).Count() > 0)
                .Select(e => e.ContentPlatformOrder.Phone)
                .Distinct()
                .Count()
                : dalContentPlatFormOrderDealInfo.GetAll()
                .Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.LastDealHospitalId == hospitalId && e.IsDeal == true && e.IsOldCustomer == false)
                .Select(e => e.ContentPlatFormOrder.Phone)
                .Distinct()
                .Count(); ;

            //累计新客成交量
            //var totalnewCustomerDealCount = 

            //当月老客成交量
            var oldCustomerDealCount = type == (int)HospitalBoardDataType.ThisMonth ? dalContentPlatformOrderSend.GetAll().Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.HospitalId == hospitalId)
                .Include(e => e.ContentPlatformOrder)
                .ThenInclude(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.ContentPlatformOrder.IsOldCustomer == true && e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.IsDeal == true && e.IsOldCustomer == true).Count() > 0)
                .Select(e => e.ContentPlatformOrder.Phone)
                .Distinct()
                .Count()
                : dalContentPlatFormOrderDealInfo.GetAll()
                .Where(e => e.CreateDate >= startDate && e.LastDealHospitalId == hospitalId && e.CreateDate < endDate && e.IsDeal == true && e.IsOldCustomer == true)
                .Select(e => e.ContentPlatFormOrder.Phone)
                .Distinct()
                .Count(); ;

            //累计老客成交量
            //var totalOldCustomerDealCount = 

            //当月老客上门人数
            var oldCustomerToHospitalCount = type == (int)HospitalBoardDataType.ThisMonth ? dalContentPlatformOrderSend.GetAll()
                .Include(e => e.ContentPlatformOrder)
                .Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.HospitalId == hospitalId && e.ContentPlatformOrder.OrderStatus != (int)ContentPlateFormOrderStatus.RepeatOrder && e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(e => e.IsOldCustomer == true && e.CreateDate >= startDate && e.CreateDate < endDate).Count() > 0)
                .Select(e => e.ContentPlatformOrder.Phone)
                .Distinct()
                .Count() : dalContentPlatFormOrderDealInfo.GetAll()
                .Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.LastDealHospitalId == hospitalId && e.IsToHospital == true && e.IsOldCustomer == true && e.ContentPlatFormOrderId != null)
                .Select(e => e.ContentPlatFormOrder.Phone)
                .Distinct()
                .Count();

            //累计老客上门人数
            /*var totalOldCustomerToHospitalCount = dalContentPlatFormOrderDealInfo.GetAll()
                .Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.LastDealHospitalId == hospitalId && e.IsToHospital == true && e.IsOldCustomer == true)
                .Select(e => e.ContentPlatFormOrder.Phone)
                .Distinct()
                .Count();*/

            //总计人数
            var endSelectDate = startDate.Date;
            var totalCustomerCount = _dalContentPlatformOrder.GetAll()
                .Where(e => e.LastDealHospitalId == hospitalId && e.CreateDate < endSelectDate && e.ContentPlatformOrderDealInfoList.Where(e => e.CreateDate < endSelectDate && e.IsDeal == true).Count() > 0)
                .Select(e => e.Phone)
                .Distinct()
                .Count();

            //当月老客订单数
            var startSelectDate = startDate.Date;

            //老客总数
            var lastMonthCustomer = dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.LastDealHospitalId == hospitalId && e.CreateDate >= startDate && e.CreateDate < endDate && e.IsDeal == true && e.IsOldCustomer == true && e.ContentPlatFormOrderId != null).Select(e => e.ContentPlatFormOrder.Phone).Distinct().ToList();
            var lastNewMonthCustomer = dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.LastDealHospitalId == hospitalId && e.CreateDate >= startDate && e.CreateDate < endDate && e.IsDeal == true && e.IsOldCustomer == false && (e.ConsumptionType == (int)ConsumptionType.Deal || e.ConsumptionType == null) && e.ContentPlatFormOrderId != null).Select(e => e.ContentPlatFormOrder.Phone).Distinct().ToList();
            var c = lastMonthCustomer.Intersect(lastNewMonthCustomer).Count();
            var count = lastMonthCustomer.Count() - c;


            OperaBaseDto operateBaseDataDto = new OperaBaseDto();
            operateBaseDataDto.NewCustomerToHospitalCount = newCustomerToHospitalCount;
            operateBaseDataDto.NewCustomerDealCount = newCustomerDealCount;
            operateBaseDataDto.OldCustomerDealCount = oldCustomerDealCount;
            /* operateBaseDataDto.AccumulateNewCustomerToHospitalCount = totalNewCustomerToHospitalCount;
             operateBaseDataDto.AccumulateNewCustomerDealCount = totalnewCustomerDealCount;
             operateBaseDataDto.AccumulateOldCustomerDealCount = totalOldCustomerDealCount;*/
            operateBaseDataDto.NewCustomerToHospitalRatio = DecimalExtension.CalculateTargetComplete(operateBaseDataDto.NewCustomerToHospitalCount, sendCount);
            operateBaseDataDto.NewCustomerDealRation = DecimalExtension.CalculateTargetComplete(operateBaseDataDto.NewCustomerDealCount, operateBaseDataDto.NewCustomerToHospitalCount);
            operateBaseDataDto.OldCustomerRepurchaseRatio = DecimalExtension.CalculateTargetComplete(count, totalCustomerCount);
            /*operateBaseDataDto.AccumulateNewCustomerToHospitalRatio = DecimalExtension.CalculateTargetComplete(totalNewCustomerToHospitalCount, sendCount).Value;
            operateBaseDataDto.AccumulateNewCustomerDealRation = DecimalExtension.CalculateTargetComplete(totalnewCustomerDealCount, totalNewCustomerToHospitalCount).Value;*/
            return operateBaseDataDto;
        }

        /// <summary>
        /// 获取机构端成交看板数据
        /// </summary>
        /// <param name="startDate"></param>sendCount.Where(e=>e.ContentPlatformOrder.IsOldCustomer==false).Count()
        /// <param name="endDate"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<DealPerformanceDataDto> GetDealDataAsync(DateTime startDate, DateTime endDate, int hospitalId)
        {
            var performanceList = dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.IsDeal == true && e.LastDealHospitalId == hospitalId && e.ContentPlatFormOrderId != null).Select(e => new
            {
                Price = e.Price,
                IsOldCustomer = e.IsOldCustomer
            }).ToList();
            DealPerformanceDataDto dealPerformanceDataDto = new DealPerformanceDataDto();
            dealPerformanceDataDto.TotalPerformance = performanceList.Sum(e => e.Price);
            dealPerformanceDataDto.NewCustomerPerformance = performanceList.Where(e => e.IsOldCustomer == false).Sum(e => e.Price);
            dealPerformanceDataDto.OldCustomerPerformance = performanceList.Where(e => e.IsOldCustomer == true).Sum(e => e.Price);
            return dealPerformanceDataDto;
        }
        /// <summary>
        /// 获取机构端成交看板科室排名数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<OperateDepartmentRankDto>> GetDealDepartmentDataAsync(DateTime startDate, DateTime endDate, int hospitalId, int type)
        {
            var sendCount = dalContentPlatformOrderSend.GetAll()
                .Include(e => e.ContentPlatformOrder)
                .Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.HospitalId == hospitalId && e.ContentPlatformOrder.OrderStatus != (int)ContentPlateFormOrderStatus.RepeatOrder)
                .Select(e => new { Phone = e.ContentPlatformOrder.Phone, HospitalDepartmentId = e.ContentPlatformOrder.HospitalDepartmentId }).ToList()
                .GroupBy(e => e.HospitalDepartmentId)
                .Select(e => new { HospitalDepartmentId = e.Key, SendCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();


            //当月上门人数
            var toHospitalCount = type == (int)HospitalBoardDataType.ThisMonth ? dalContentPlatformOrderSend.GetAll()
                .Include(e => e.ContentPlatformOrder)
                .Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.HospitalId == hospitalId && e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(x => x.CreateDate >= startDate && x.CreateDate < endDate).Count() > 0)
                .Select(e => new { Phone = e.ContentPlatformOrder.Phone, HospitalDepartmentId = e.ContentPlatformOrder.HospitalDepartmentId }).ToList()
                .GroupBy(e => e.HospitalDepartmentId)
                .Select(e => new { HospitalDepartmentId = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList()
                : _dalContentPlatformOrder.GetAll().Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.IsToHospital == true && e.LastDealHospitalId == hospitalId && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault().CreateDate >= startDate && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault().CreateDate < endDate)
                .Select(e => new { HospitalDepartmentId = e.HospitalDepartmentId, Phone = e.Phone }).ToList()
                .GroupBy(e => e.HospitalDepartmentId)
                .Select(e => new { HospitalDepartmentId = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();
            //当月新客上门人数
            var newCustomerToHospitalCount = type == (int)HospitalBoardDataType.ThisMonth ? dalContentPlatformOrderSend.GetAll()
                .Include(e => e.ContentPlatformOrder)
                .Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.HospitalId == hospitalId && e.ContentPlatformOrder.IsToHospital == true && e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(x => x.CreateDate >= startDate && x.CreateDate < endDate && x.IsOldCustomer == false).Count() > 0)
                .Select(e => new { Phone = e.ContentPlatformOrder.Phone, HospitalDepartmentId = e.ContentPlatformOrder.HospitalDepartmentId }).ToList()
                .GroupBy(e => e.HospitalDepartmentId)
                .Select(e => new { HospitalDepartmentId = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList()
                : _dalContentPlatformOrder.GetAll().Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.IsToHospital == true && e.LastDealHospitalId == hospitalId && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault(e => e.IsOldCustomer == false).CreateDate >= startDate && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault(e => e.IsOldCustomer == false).CreateDate < endDate)
                .Select(e => new { HospitalDepartmentId = e.HospitalDepartmentId, Phone = e.Phone }).ToList()
                .GroupBy(e => e.HospitalDepartmentId)
                .Select(e => new { HospitalDepartmentId = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();

            //累计上门人数
            //var totalToHospitalCount = 

            //累计新客上门人数
            /*var totalNewCustomerToHospitalCount = _dalContentPlatformOrder.GetAll().Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.IsToHospital == true && e.LastDealHospitalId == hospitalId && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault(e => e.IsOldCustomer == false).CreateDate >= startDate && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault(e => e.IsOldCustomer == false).CreateDate < endDate)
                .Select(e => new { HospitalDepartmentId = e.HospitalDepartmentId, Phone = e.Phone }).ToList()
                .GroupBy(e => e.HospitalDepartmentId)
                .Select(e => new { HospitalDepartmentId = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList(); ;*/


            //当月新客成交人数
            var newCustomerDealCount = type == (int)HospitalBoardDataType.ThisMonth ? dalContentPlatformOrderSend.GetAll().Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.HospitalId == hospitalId)
                .Include(e => e.ContentPlatformOrder)
                .ThenInclude(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.IsDeal == true && e.IsOldCustomer == false).Count() > 0)
                .Select(e => new { HospitalDepartmentId = e.ContentPlatformOrder.HospitalDepartmentId, Phone = e.ContentPlatformOrder.Phone }).ToList()
                .GroupBy(e => e.HospitalDepartmentId).Select(e => new
                {
                    HospitalDepartmentId = e.Key,
                    DealCount = e.Select(e => e.Phone).Distinct().Count(),
                })
                : _dalContentPlatformOrder.GetAll()
                .Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.IsToHospital == true && e.LastDealHospitalId == hospitalId && e.ContentPlatformOrderDealInfoList.Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.IsOldCustomer == false && e.IsDeal == true).Count() > 0)
                .Select(e => new { HospitalDepartmentId = e.HospitalDepartmentId, Phone = e.Phone }).ToList()
                .GroupBy(e => e.HospitalDepartmentId)
                .Select(e => new { HospitalDepartmentId = e.Key, DealCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();
            //累计新客成交人数
            /*var totalNewCustomerDealCount = _dalContentPlatformOrder.GetAll()
                .Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.IsToHospital == true && e.LastDealHospitalId == hospitalId && e.ContentPlatformOrderDealInfoList.Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.IsOldCustomer == false && e.IsDeal == true).Count() > 0)
                .Select(e => new { HospitalDepartmentId = e.HospitalDepartmentId, Phone = e.Phone }).ToList()
                .GroupBy(e => e.HospitalDepartmentId)
                .Select(e => new { HospitalDepartmentId = e.Key, DealCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();*/

            var dealInfo = dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.LastDealHospitalId == hospitalId && e.ContentPlatFormOrderId != null).GroupBy(e => e.ContentPlatFormOrder.HospitalDepartmentId).Select(e => new
            {
                DepartMentName = dalAmiyaHospitalDepartment.GetAll().Where(d => d.Id == e.Key).FirstOrDefault().DepartmentName,
                HospitalDepartmentId = e.Key,
                OldCustomerCount = e.Sum(e => e.IsOldCustomer == true && e.IsDeal == true ? 1 : 0),
                NewCustomerCount = e.Sum(e => e.IsOldCustomer == false && e.IsDeal == true ? 1 : 0),
                Performance = e.Sum(e => e.Price),
                NewCustomerPerformance = e.Sum(e => (e.IsOldCustomer == false && e.IsDeal == true) ? e.Price : 0m),
                OldCustomerPerformance = e.Sum(e => e.IsOldCustomer == true && e.IsDeal == true ? e.Price : 0m),
            }).OrderByDescending(e => e.Performance).ToList();
            List<OperateDepartmentRankDto> rankList = new List<OperateDepartmentRankDto>();
            int index = 1;
            foreach (var item in dealInfo)
            {
                OperateDepartmentRankDto operateDepartmentRankDto = new OperateDepartmentRankDto();
                operateDepartmentRankDto.Rank = index;
                operateDepartmentRankDto.DepartMentName = item.DepartMentName;
                operateDepartmentRankDto.ToHospitalRatio = DecimalExtension.CalculateTargetComplete(toHospitalCount.Where(e => e.HospitalDepartmentId == item.HospitalDepartmentId).FirstOrDefault()?.ToHospitalCount ?? 0m, sendCount.Where(e => e.HospitalDepartmentId == item.HospitalDepartmentId).FirstOrDefault()?.SendCount ?? 0m);
                operateDepartmentRankDto.DealRation = DecimalExtension.CalculateTargetComplete(newCustomerDealCount.Where(e => e.HospitalDepartmentId == item.HospitalDepartmentId).FirstOrDefault()?.DealCount ?? 0m, newCustomerToHospitalCount.Where(e => e.HospitalDepartmentId == item.HospitalDepartmentId).FirstOrDefault()?.ToHospitalCount ?? 0m);
                /*operateDepartmentRankDto.AccumulateToHospitalRatio = DecimalExtension.CalculateTargetComplete(totalToHospitalCount.Where(e => e.HospitalDepartmentId == item.HospitalDepartmentId).FirstOrDefault()?.ToHospitalCount ?? 0m, sendCount.Where(e => e.HospitalDepartmentId == item.HospitalDepartmentId).FirstOrDefault()?.SendCount ?? 0m);
                operateDepartmentRankDto.AccumulateDealRation = DecimalExtension.CalculateTargetComplete(totalNewCustomerDealCount.Where(e => e.HospitalDepartmentId == item.HospitalDepartmentId).FirstOrDefault()?.DealCount ?? 0m, totalNewCustomerToHospitalCount.Where(e => e.HospitalDepartmentId == item.HospitalDepartmentId).FirstOrDefault()?.ToHospitalCount ?? 0m);*/
                operateDepartmentRankDto.NewCustomerUnitPrice = Division(item.NewCustomerPerformance, item.NewCustomerCount);
                operateDepartmentRankDto.OldCustomerUnitPrice = Division(item.OldCustomerPerformance, item.OldCustomerCount);
                operateDepartmentRankDto.Performance = item.Performance;
                operateDepartmentRankDto.PerformanceRatio = DecimalExtension.CalculateTargetComplete(item.Performance, dealInfo.Sum(e => e.Performance));
                index++;
                rankList.Add(operateDepartmentRankDto);

            }
            return rankList;
        }
        /// <summary>
        /// 获取机构端成交看板咨询师排名数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<OperateConsultantRankDataDto>> GetDealConsultantDataAsync(DateTime startDate, DateTime endDate, int hospitalId, int type)
        {

            var sendCount = dalContentPlatformOrderSend.GetAll()
                .Include(e => e.ContentPlatformOrder)
                .Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.HospitalId == hospitalId && e.ContentPlatformOrder.OrderStatus != (int)ContentPlateFormOrderStatus.RepeatOrder)
                .Select(e => new { Phone = e.ContentPlatformOrder.Phone, NetWorkConsulationName = e.ContentPlatformOrder.NetWorkConsulationName }).ToList()
                .GroupBy(e => e.NetWorkConsulationName)
                .Select(e => new { NetWorkConsulationName = e.Key, SendCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();


            //当月上门人数
            var toHospitalCount = type == (int)HospitalBoardDataType.ThisMonth ? dalContentPlatformOrderSend.GetAll()
                .Include(e => e.ContentPlatformOrder)
                .Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.HospitalId == hospitalId && e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(e => e.CreateDate >= startDate && e.CreateDate < endDate).Count() > 0)
                .Select(e => new { Phone = e.ContentPlatformOrder.Phone, NetWorkConsulationName = e.ContentPlatformOrder.NetWorkConsulationName }).ToList()
                .GroupBy(e => e.NetWorkConsulationName)
                .Select(e => new { NetWorkConsulationName = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList()
                : _dalContentPlatformOrder.GetAll().Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.IsToHospital == true && e.LastDealHospitalId == hospitalId && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault().CreateDate >= startDate && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault().CreateDate < endDate)
                .Select(e => new { NetWorkConsulationName = e.NetWorkConsulationName, Phone = e.Phone }).ToList()
                .GroupBy(e => e.NetWorkConsulationName)
                .Select(e => new { NetWorkConsulationName = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();
            //当月新客上门人数
            var newCustomerToHospitalCount = type == (int)HospitalBoardDataType.ThisMonth ? dalContentPlatformOrderSend.GetAll()
                .Include(e => e.ContentPlatformOrder)
                .Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.HospitalId == hospitalId && e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(x => x.CreateDate >= startDate && x.CreateDate < endDate && x.IsOldCustomer == false).Count() > 0)
                .Select(e => new { Phone = e.ContentPlatformOrder.Phone, NetWorkConsulationName = e.ContentPlatformOrder.NetWorkConsulationName }).ToList()
                .GroupBy(e => e.NetWorkConsulationName)
                .Select(e => new { NetWorkConsulationName = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList()
                : _dalContentPlatformOrder.GetAll().Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.IsToHospital == true && e.LastDealHospitalId == hospitalId && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault(e => e.IsOldCustomer == false).CreateDate >= startDate && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault(e => e.IsOldCustomer == false).CreateDate < endDate)
                .Select(e => new { NetWorkConsulationName = e.NetWorkConsulationName, Phone = e.Phone }).ToList()
                .GroupBy(e => e.NetWorkConsulationName)
                .Select(e => new { NetWorkConsulationName = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();

            //累计上门人数
            /*var totalToHospitalCount = _dalContentPlatformOrder.GetAll().Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.IsToHospital == true && e.LastDealHospitalId == hospitalId && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault().CreateDate >= startDate && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault().CreateDate < endDate)
                .Select(e => new { NetWorkConsulationName = e.NetWorkConsulationName, Phone = e.Phone }).ToList()
                .GroupBy(e => e.NetWorkConsulationName)
                .Select(e => new { NetWorkConsulationName = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();*/

            //累计新客上门人数
            /*var totalNewCustomerToHospitalCount = _dalContentPlatformOrder.GetAll().Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.IsToHospital == true && e.LastDealHospitalId == hospitalId && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault(e => e.IsOldCustomer == false).CreateDate >= startDate && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault(e => e.IsOldCustomer == false).CreateDate < endDate)
                .Select(e => new { NetWorkConsulationName = e.NetWorkConsulationName, Phone = e.Phone }).ToList()
                .GroupBy(e => e.NetWorkConsulationName)
                .Select(e => new { NetWorkConsulationName = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList(); ;*/


            //当月新客成交人数
            var newCustomerDealCount = type == (int)HospitalBoardDataType.ThisMonth ? dalContentPlatformOrderSend.GetAll().Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.HospitalId == hospitalId)
                .Include(e => e.ContentPlatformOrder)
                .ThenInclude(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.IsDeal == true && e.IsOldCustomer == false).Count() > 0)
                .Select(e => new { NetWorkConsulationName = e.ContentPlatformOrder.NetWorkConsulationName, Phone = e.ContentPlatformOrder.Phone }).ToList()
                .GroupBy(e => e.NetWorkConsulationName).Select(e => new
                {
                    NetWorkConsulationName = e.Key,
                    DealCount = e.Select(e => e.Phone).Distinct().Count(),
                })
                : _dalContentPlatformOrder.GetAll()
                .Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.IsToHospital == true && e.LastDealHospitalId == hospitalId && e.ContentPlatformOrderDealInfoList.Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.IsOldCustomer == false && e.IsDeal == true).Count() > 0)
                .Select(e => new { NetWorkConsulationName = e.NetWorkConsulationName, Phone = e.Phone }).ToList()
                .GroupBy(e => e.NetWorkConsulationName)
                .Select(e => new { NetWorkConsulationName = e.Key, DealCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();
            //累计新客成交人数
            /*var totalNewCustomerDealCount = _dalContentPlatformOrder.GetAll()
                .Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.IsToHospital == true && e.LastDealHospitalId == hospitalId && e.ContentPlatformOrderDealInfoList.Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.IsOldCustomer == false && e.IsDeal == true).Count() > 0)
                .Select(e => new { NetWorkConsulationName = e.NetWorkConsulationName, Phone = e.Phone }).ToList()
                .GroupBy(e => e.NetWorkConsulationName)
                .Select(e => new { NetWorkConsulationName = e.Key, DealCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();*/

            var dealInfo = dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.LastDealHospitalId == hospitalId && e.ContentPlatFormOrderId != null).GroupBy(e => e.ContentPlatFormOrder.NetWorkConsulationName).Select(e => new
            {
                Name = e.Key,
                OldCustomerCount = e.Sum(e => e.IsOldCustomer == true && e.IsDeal == true ? 1 : 0),
                NewCustomerCount = e.Sum(e => e.IsOldCustomer == false && e.IsDeal == true ? 1 : 0),
                Performance = e.Sum(e => e.Price),
                NewCustomerPerformance = e.Sum(e => (e.IsOldCustomer == false && e.IsDeal == true) ? e.Price : 0m),
                OldCustomerPerformance = e.Sum(e => e.IsOldCustomer == true && e.IsDeal == true ? e.Price : 0m),
            }).OrderByDescending(e => e.Performance).ToList();


            List<OperateConsultantRankDataDto> rankList = new List<OperateConsultantRankDataDto>();
            int index = 1;
            foreach (var item in dealInfo)
            {
                OperateConsultantRankDataDto operateDepartmentRankDto = new OperateConsultantRankDataDto();
                operateDepartmentRankDto.Rank = index;
                operateDepartmentRankDto.Name = item.Name;
                operateDepartmentRankDto.ToHospitalRatio = DecimalExtension.CalculateTargetComplete(toHospitalCount.Where(e => e.NetWorkConsulationName == item.Name).FirstOrDefault()?.ToHospitalCount ?? 0m, sendCount.Where(e => e.NetWorkConsulationName == item.Name).FirstOrDefault()?.SendCount ?? 0m);
                //operateDepartmentRankDto.AccumulateToHospitalRatio = DecimalExtension.CalculateTargetComplete(totalToHospitalCount.Where(e => e.NetWorkConsulationName == item.Name).FirstOrDefault()?.ToHospitalCount ?? 0m, sendCount.Where(e => e.NetWorkConsulationName == item.Name).FirstOrDefault()?.SendCount ?? 0m);
                operateDepartmentRankDto.DealRation = DecimalExtension.CalculateTargetComplete(newCustomerDealCount.Where(e => e.NetWorkConsulationName == item.Name).FirstOrDefault()?.DealCount ?? 0m, newCustomerToHospitalCount.Where(e => e.NetWorkConsulationName == item.Name).FirstOrDefault()?.ToHospitalCount ?? 0m);
                //operateDepartmentRankDto.AccumulateDealRation = DecimalExtension.CalculateTargetComplete(totalNewCustomerDealCount.Where(e => e.NetWorkConsulationName == item.Name).FirstOrDefault()?.DealCount ?? 0m, totalNewCustomerToHospitalCount.Where(e => e.NetWorkConsulationName == item.Name).FirstOrDefault()?.ToHospitalCount ?? 0m);
                operateDepartmentRankDto.NewCustomerUnitPrice = Division(item.NewCustomerPerformance, item.NewCustomerCount);
                operateDepartmentRankDto.OldCustomerUnitPrice = Division(item.OldCustomerPerformance, item.OldCustomerCount);
                operateDepartmentRankDto.Performance = item.Performance;
                operateDepartmentRankDto.PerformanceRatio = DecimalExtension.CalculateTargetComplete(item.Performance, dealInfo.Sum(e => e.Performance));
                index++;
                rankList.Add(operateDepartmentRankDto);
            }
            return rankList;

        }
        /// <summary>
        /// 获取机构端成交看板接诊排名数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<OperateConsultantRankDataDto>> GetDealSceneConsultantDataAsync(DateTime startDate, DateTime endDate, int hospitalId, int type)
        {

            var sendCount = dalContentPlatformOrderSend.GetAll()
                .Include(e => e.ContentPlatformOrder)
                .Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.HospitalId == hospitalId && e.ContentPlatformOrder.OrderStatus != (int)ContentPlateFormOrderStatus.RepeatOrder)
                .Select(e => new { Phone = e.ContentPlatformOrder.Phone, SceneConsulationName = e.ContentPlatformOrder.SceneConsulationName }).ToList()
                .GroupBy(e => e.SceneConsulationName)
                .Select(e => new { SceneConsulationName = e.Key, SendCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();


            //当月上门人数
            var toHospitalCount = type == (int)HospitalBoardDataType.ThisMonth ? dalContentPlatformOrderSend.GetAll()
                .Include(e => e.ContentPlatformOrder)
                .Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.HospitalId == hospitalId && e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(e => e.CreateDate >= startDate && e.CreateDate < endDate).Count() > 0)
                .Select(e => new { Phone = e.ContentPlatformOrder.Phone, SceneConsulationName = e.ContentPlatformOrder.SceneConsulationName }).ToList()
                .GroupBy(e => e.SceneConsulationName)
                .Select(e => new { SceneConsulationName = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList()
                : _dalContentPlatformOrder.GetAll().Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.IsToHospital == true && e.LastDealHospitalId == hospitalId && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault().CreateDate >= startDate && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault().CreateDate < endDate)
                .Select(e => new { SceneConsulationName = e.SceneConsulationName, Phone = e.Phone }).ToList()
                .GroupBy(e => e.SceneConsulationName)
                .Select(e => new { SceneConsulationName = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();
            //当月新客上门人数
            var newCustomerToHospitalCount = type == (int)HospitalBoardDataType.ThisMonth ? dalContentPlatformOrderSend.GetAll()
                .Include(e => e.ContentPlatformOrder)
                .Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.HospitalId == hospitalId && e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(x => x.CreateDate >= startDate && x.CreateDate < endDate && x.IsOldCustomer == false).Count() > 0)
                .Select(e => new { Phone = e.ContentPlatformOrder.Phone, SceneConsulationName = e.ContentPlatformOrder.SceneConsulationName }).ToList()
                .GroupBy(e => e.SceneConsulationName)
                .Select(e => new { SceneConsulationName = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList()
                : _dalContentPlatformOrder.GetAll().Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.IsToHospital == true && e.LastDealHospitalId == hospitalId && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault(e => e.IsOldCustomer == false).CreateDate >= startDate && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault(e => e.IsOldCustomer == false).CreateDate < endDate)
                .Select(e => new { SceneConsulationName = e.SceneConsulationName, Phone = e.Phone }).ToList()
                .GroupBy(e => e.SceneConsulationName)
                .Select(e => new { SceneConsulationName = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();

            //累计上门人数
            /*var totalToHospitalCount = _dalContentPlatformOrder.GetAll().Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.IsToHospital == true && e.LastDealHospitalId == hospitalId && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault().CreateDate >= startDate && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault().CreateDate < endDate)
                .Select(e => new { SceneConsulationName = e.SceneConsulationName, Phone = e.Phone }).ToList()
                .GroupBy(e => e.SceneConsulationName)
                .Select(e => new { SceneConsulationName = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();*/

            //累计新客上门人数
            /*var totalNewCustomerToHospitalCount = _dalContentPlatformOrder.GetAll().Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.IsToHospital == true && e.LastDealHospitalId == hospitalId && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault(e => e.IsOldCustomer == false).CreateDate >= startDate && e.ContentPlatformOrderDealInfoList.OrderByDescending(k => k.CreateDate).FirstOrDefault(e => e.IsOldCustomer == false).CreateDate < endDate)
                .Select(e => new { SceneConsulationName = e.SceneConsulationName, Phone = e.Phone }).ToList()
                .GroupBy(e => e.SceneConsulationName)
                .Select(e => new { SceneConsulationName = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList(); ;*/


            //当月新客成交人数
            var newCustomerDealCount = type == (int)HospitalBoardDataType.ThisMonth ? dalContentPlatformOrderSend.GetAll().Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.HospitalId == hospitalId)
                .Include(e => e.ContentPlatformOrder)
                .ThenInclude(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.IsDeal == true && e.IsOldCustomer == false).Count() > 0)
                .Select(e => new { SceneConsulationName = e.ContentPlatformOrder.SceneConsulationName, Phone = e.ContentPlatformOrder.Phone }).ToList()
                .GroupBy(e => e.SceneConsulationName).Select(e => new
                {
                    SceneConsulationName = e.Key,
                    DealCount = e.Select(e => e.Phone).Distinct().Count(),
                })
                : _dalContentPlatformOrder.GetAll()
                .Include(e => e.ContentPlatformOrderDealInfoList)
                .Where(e => e.IsToHospital == true && e.LastDealHospitalId == hospitalId && e.ContentPlatformOrderDealInfoList.Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.IsOldCustomer == false && e.IsDeal == true).Count() > 0)
                .Select(e => new { SceneConsulationName = e.SceneConsulationName, Phone = e.Phone }).ToList()
                .GroupBy(e => e.SceneConsulationName)
                .Select(e => new { SceneConsulationName = e.Key, DealCount = e.Select(e => e.Phone).Distinct().Count() }).ToList(); ;
            //累计新客成交人数
            //var totalNewCustomerDealCount = 

            var dealInfo = dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.LastDealHospitalId == hospitalId && e.ContentPlatFormOrderId != null).GroupBy(e => e.ContentPlatFormOrder.SceneConsulationName).Select(e => new
            {
                Name = e.Key,
                OldCustomerCount = e.Sum(e => e.IsOldCustomer == true && e.IsDeal == true ? 1 : 0),
                NewCustomerCount = e.Sum(e => e.IsOldCustomer == false && e.IsDeal == true ? 1 : 0),
                Performance = e.Sum(e => e.Price),
                NewCustomerPerformance = e.Sum(e => (e.IsOldCustomer == false && e.IsDeal == true) ? e.Price : 0m),
                OldCustomerPerformance = e.Sum(e => e.IsOldCustomer == true && e.IsDeal == true ? e.Price : 0m),
            }).OrderByDescending(e => e.Performance).ToList();


            List<OperateConsultantRankDataDto> rankList = new List<OperateConsultantRankDataDto>();
            int index = 1;
            foreach (var item in dealInfo)
            {
                OperateConsultantRankDataDto operateDepartmentRankDto = new OperateConsultantRankDataDto();
                operateDepartmentRankDto.Rank = index;
                operateDepartmentRankDto.Name = item.Name;
                operateDepartmentRankDto.ToHospitalRatio = DecimalExtension.CalculateTargetComplete(toHospitalCount.Where(e => e.SceneConsulationName == item.Name).FirstOrDefault()?.ToHospitalCount ?? 0m, sendCount.Where(e => e.SceneConsulationName == item.Name).FirstOrDefault()?.SendCount ?? 0m);
                //operateDepartmentRankDto.AccumulateToHospitalRatio = DecimalExtension.CalculateTargetComplete(totalToHospitalCount.Where(e => e.SceneConsulationName == item.Name).FirstOrDefault()?.ToHospitalCount ?? 0m, sendCount.Where(e => e.SceneConsulationName == item.Name).FirstOrDefault()?.SendCount ?? 0m);
                operateDepartmentRankDto.DealRation = DecimalExtension.CalculateTargetComplete(newCustomerDealCount.Where(e => e.SceneConsulationName == item.Name).FirstOrDefault()?.DealCount ?? 0m, newCustomerToHospitalCount.Where(e => e.SceneConsulationName == item.Name).FirstOrDefault()?.ToHospitalCount ?? 0m);
                //operateDepartmentRankDto.AccumulateDealRation = DecimalExtension.CalculateTargetComplete(totalNewCustomerDealCount.Where(e => e.SceneConsulationName == item.Name).FirstOrDefault()?.DealCount ?? 0m, totalNewCustomerToHospitalCount.Where(e => e.SceneConsulationName == item.Name).FirstOrDefault()?.ToHospitalCount ?? 0m);
                operateDepartmentRankDto.NewCustomerUnitPrice = Division(item.NewCustomerPerformance, item.NewCustomerCount);
                operateDepartmentRankDto.OldCustomerUnitPrice = Division(item.OldCustomerPerformance, item.OldCustomerCount);
                operateDepartmentRankDto.Performance = item.Performance;
                operateDepartmentRankDto.PerformanceRatio = DecimalExtension.CalculateTargetComplete(item.Performance, dealInfo.Sum(e => e.Performance));
                index++;
                rankList.Add(operateDepartmentRankDto);
            }
            return rankList;

        }
        /// <summary>
        /// 获取机构排名
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<RankDataDto>> GetRankDataAsync(DateTime startDate, DateTime endDate, int type)
        {
            var sendCount = dalContentPlatformOrderSend.GetAll()
                .Include(e => e.ContentPlatformOrder)
                .Where(e => e.SendDate >= startDate && e.SendDate < endDate)
                .Select(e => new { HospitalId = e.HospitalId, Phone = e.ContentPlatformOrder.Phone })
                .ToList()
                .GroupBy(e => e.HospitalId).Select(e => new { HospitalId = e.Key, SendCount = e.Select(e => e.Phone).Distinct().Count() })
                .ToList();

            //总计人数
            var endSelectDate = startDate.Date;
            var totalCustomerCount = _dalContentPlatformOrder.GetAll()
                .Where(e => e.CreateDate < endSelectDate && e.ContentPlatformOrderDealInfoList.Where(e => e.CreateDate < endSelectDate && e.IsDeal == true && e.ContentPlatFormOrderId != null).Count() > 0)
                .Select(e => new { HospitalId = e.LastDealHospitalId, Phone = e.Phone })
                .ToList()
                .GroupBy(e => e.HospitalId)
                .Select(e => new { HospitalId = e.Key, Count = e.Select(e => e.Phone).Distinct().Count() });

            //当月老客订单数
            var startSelectDate = startDate.Date;
            List<dynamic> oldCustomerCountList = new List<dynamic>();
            foreach (var item in totalCustomerCount)
            {
                var lastMonthOldCustomer = dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.LastDealHospitalId == item.HospitalId && e.CreateDate >= startDate && e.CreateDate < endDate && e.IsDeal == true && e.IsOldCustomer == true).Select(e => e.ContentPlatFormOrder.Phone).Distinct().ToList();
                var lastMonthNewCustomer = dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.LastDealHospitalId == item.HospitalId && e.CreateDate >= startDate && e.CreateDate < endDate && e.IsDeal == true && e.IsOldCustomer == false && (e.ConsumptionType == (int)ConsumptionType.Deal || e.ConsumptionType == null)).Select(e => e.ContentPlatFormOrder.Phone).Distinct().ToList();
                var c = lastMonthOldCustomer.Intersect(lastMonthNewCustomer).Count();
                var count = lastMonthOldCustomer.Count() - c;
                oldCustomerCountList.Add(new { HospitalId = item.HospitalId, Count = count });
            }

            var dealData = await dalContentPlatFormOrderDealInfo.GetAll().Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.LastDealHospitalId != null && e.ContentPlatFormOrderId != null).GroupBy(e => e.LastDealHospitalId).Select(
                e => new
                {
                    Name = dalHospitalInfo.GetAll().Where(h => h.Id == e.Key).FirstOrDefault() == null ? "" : dalHospitalInfo.GetAll().Where(h => h.Id == e.Key).FirstOrDefault().Name,
                    HospitalId = e.Key,
                    NewCustomerPerformance = e.Sum(e => e.IsDeal == true && e.IsOldCustomer == false ? e.Price : 0m),
                    NewCustomerCount = e.Sum(e => e.IsDeal == true && e.IsOldCustomer == false ? 1 : 0)
                }
                ).ToListAsync();


            if (type == (int)HospitalBoardDataType.ThisMonth)
            {
                //当月数据
                var toHospitalCount = dalContentPlatformOrderSend.GetAll()
                .Include(e => e.ContentPlatformOrder)
                .Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.ContentPlatFormOrderId != null).Count() > 0)
                .Select(e => new { Phone = e.ContentPlatformOrder.Phone, HospitalId = e.HospitalId }).ToList()
                .GroupBy(e => e.HospitalId)
                .Select(e => new { HospitalId = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();

                var newCustomerToHospitalCount = dalContentPlatformOrderSend.GetAll()
                .Include(e => e.ContentPlatformOrder)
                .Where(e => e.SendDate >= startDate && e.SendDate < endDate && e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(x => x.CreateDate >= startDate && x.CreateDate < endDate && x.IsOldCustomer == false && x.IsToHospital == true && x.ContentPlatFormOrderId != null).Count() > 0)
                .Select(e => new { Phone = e.ContentPlatformOrder.Phone, HospitalId = e.HospitalId }).ToList()
                .GroupBy(e => e.HospitalId)
                .Select(e => new { HospitalId = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();

                //当月新客成交人数
                var newCustomerDealCount = dalContentPlatformOrderSend.GetAll().Where(e => e.SendDate >= startDate && e.SendDate < endDate)
                    .Include(e => e.ContentPlatformOrder)
                    .ThenInclude(e => e.ContentPlatformOrderDealInfoList)
                    .Where(e => e.ContentPlatformOrder.ContentPlatformOrderDealInfoList.Where(e => e.IsDeal == true && e.IsOldCustomer == false && e.CreateDate >= startDate && e.CreateDate < endDate && e.ContentPlatFormOrderId != null).Count() > 0)
                    .Select(e => new { HospitalId = e.HospitalId, Phone = e.ContentPlatformOrder.Phone }).ToList()
                    .GroupBy(e => e.HospitalId).Select(e => new
                    {
                        HospitalId = e.Key,
                        DealCount = e.Select(e => e.Phone).Distinct().Count(),
                    });
                List<RankDataDto> rankList = new List<RankDataDto>();
                foreach (var item in dealData)
                {
                    RankDataDto rankDataDto = new RankDataDto();
                    rankDataDto.Name = item.Name;
                    rankDataDto.ToHospitalRatio = DecimalExtension.CalculateTargetComplete(toHospitalCount.Where(e => e.HospitalId == item.HospitalId).FirstOrDefault()?.ToHospitalCount ?? 0m, sendCount.Where(e => e.HospitalId == item.HospitalId).FirstOrDefault()?.SendCount ?? 0m);
                    rankDataDto.DealRatio = DecimalExtension.CalculateTargetComplete(newCustomerDealCount.Where(e => e.HospitalId == item.HospitalId).FirstOrDefault()?.DealCount ?? 0m, newCustomerToHospitalCount.Where(e => e.HospitalId == item.HospitalId).FirstOrDefault()?.ToHospitalCount ?? 0m);
                    rankDataDto.RepurchaseRatio = DecimalExtension.CalculateTargetComplete(oldCustomerCountList.Where(e => e.HospitalId == item.HospitalId).FirstOrDefault()?.Count ?? 0m, totalCustomerCount.Where(e => e.HospitalId == item.HospitalId).FirstOrDefault()?.Count ?? 0m);
                    rankDataDto.NewCustomerUnitPrice = Division(item.NewCustomerPerformance, item.NewCustomerCount);
                    rankDataDto.HospitalId = item.HospitalId.Value;
                    rankList.Add(rankDataDto);

                }
                var list = rankList.OrderByDescending(e => e.ToHospitalRatio * 0.5m + e.DealRatio * 0.2m + e.RepurchaseRatio * 0.3m).ToList();
                var index = 1;
                foreach (var item in list)
                {
                    item.Rank = index;
                    index++;
                }
                return list;
            }
            else
            {
                //累计数据

                //累计上门人数
                var toHospitalCount = _dalContentPlatformOrder.GetAll().Include(e => e.ContentPlatformOrderDealInfoList)
                    .Where(e => e.LastDealHospitalId != null && e.ContentPlatformOrderDealInfoList.Where(x => x.ContentPlatFormOrderId != null).OrderByDescending(k => k.CreateDate).FirstOrDefault().CreateDate >= startDate && e.ContentPlatformOrderDealInfoList.Where(x => x.ContentPlatFormOrderId != null).OrderByDescending(k => k.CreateDate).FirstOrDefault().CreateDate < endDate)
                    .Select(e => new { HospitalId = e.LastDealHospitalId, Phone = e.Phone }).ToList()
                    .GroupBy(e => e.HospitalId)
                    .Select(e => new { HospitalId = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();

                //累计新客上门人数
                var newCustomerToHospitalCount = _dalContentPlatformOrder.GetAll().Include(e => e.ContentPlatformOrderDealInfoList)
                    .Where(e => e.LastDealHospitalId != null && e.ContentPlatformOrderDealInfoList.Where(x => x.ContentPlatFormOrderId != null).OrderByDescending(k => k.CreateDate).FirstOrDefault(e => e.IsOldCustomer == false).CreateDate >= startDate && e.ContentPlatformOrderDealInfoList.Where(x => x.ContentPlatFormOrderId != null).OrderByDescending(k => k.CreateDate).FirstOrDefault(e => e.IsOldCustomer == false).CreateDate < endDate)
                    .Select(e => new { HospitalId = e.LastDealHospitalId, Phone = e.Phone }).ToList()
                    .GroupBy(e => e.HospitalId)
                    .Select(e => new { HospitalId = e.Key, ToHospitalCount = e.Select(e => e.Phone).Distinct().Count() }).ToList(); ;


                //累计新客成交人数
                var newCustomerDealCount = _dalContentPlatformOrder.GetAll()
                    .Include(e => e.ContentPlatformOrderDealInfoList)
                    .Where(e => e.LastDealHospitalId != null && e.ContentPlatformOrderDealInfoList.Where(e => e.CreateDate >= startDate && e.CreateDate < endDate && e.IsOldCustomer == false && e.IsDeal == true && e.ContentPlatFormOrderId != null).Count() > 0)
                    .Select(e => new { HospitalId = e.LastDealHospitalId, Phone = e.Phone }).ToList()
                    .GroupBy(e => e.HospitalId)
                    .Select(e => new { HospitalId = e.Key, DealCount = e.Select(e => e.Phone).Distinct().Count() }).ToList();
                List<RankDataDto> rankList = new List<RankDataDto>();
                foreach (var item in dealData)
                {
                    RankDataDto rankDataDto = new RankDataDto();
                    rankDataDto.Name = item.Name;
                    rankDataDto.ToHospitalRatio = DecimalExtension.CalculateTargetComplete(toHospitalCount.Where(e => e.HospitalId == item.HospitalId).FirstOrDefault()?.ToHospitalCount ?? 0m, sendCount.Where(e => e.HospitalId == item.HospitalId).FirstOrDefault()?.SendCount ?? 0m);
                    //rankDataDto.AccumulateToHospitalRatio = DecimalExtension.CalculateTargetComplete(totalToHospitalCount.Where(e => e.HospitalId == item.HospitalId).FirstOrDefault()?.ToHospitalCount ?? 0m, sendCount.Where(e => e.HospitalId == item.HospitalId).FirstOrDefault()?.SendCount ?? 0m);
                    rankDataDto.DealRatio = DecimalExtension.CalculateTargetComplete(newCustomerDealCount.Where(e => e.HospitalId == item.HospitalId).FirstOrDefault()?.DealCount ?? 0m, newCustomerToHospitalCount.Where(e => e.HospitalId == item.HospitalId).FirstOrDefault()?.ToHospitalCount ?? 0m);
                    //rankDataDto.AccumulateDealRatio = DecimalExtension.CalculateTargetComplete(totalNewCustomerDealCount.Where(e => e.HospitalId == item.HospitalId).FirstOrDefault()?.DealCount ?? 0m, totalNewCustomerToHospitalCount.Where(e => e.HospitalId == item.HospitalId).FirstOrDefault()?.ToHospitalCount ?? 0m);
                    rankDataDto.RepurchaseRatio = DecimalExtension.CalculateTargetComplete(oldCustomerCountList.Where(e => e.HospitalId == item.HospitalId).FirstOrDefault()?.Count ?? 0m, totalCustomerCount.Where(e => e.HospitalId == item.HospitalId).FirstOrDefault()?.Count ?? 0m);
                    rankDataDto.NewCustomerUnitPrice = Division(item.NewCustomerPerformance, item.NewCustomerCount);
                    rankDataDto.HospitalId = item.HospitalId.Value;
                    rankList.Add(rankDataDto);

                }
                var list = rankList.OrderByDescending(e => e.ToHospitalRatio * 0.5m + e.DealRatio * 0.2m + e.RepurchaseRatio * 0.3m).ToList();
                var index = 1;
                foreach (var item in list)
                {
                    item.Rank = index;
                    index++;
                }
                return list;
            }
        }
        /// <summary>
        /// 计算客单价
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public decimal? Division(decimal? a, int? b)
        {
            if (a == 0m || b == 0M || a.HasValue == false || b.HasValue == false)
                return 0;
            return Math.Round(a.Value / b.Value, 2);
        }


        #endregion

    }
}
