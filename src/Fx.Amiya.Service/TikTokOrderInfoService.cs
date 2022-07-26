using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ExpressManage;
using Fx.Amiya.Dto.OrderAppInfo;
using Fx.Amiya.Dto.OrderCheckPicture;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.OrderWriteOffIno;
using Fx.Amiya.Dto.TikTokOrder;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Common.Utils;
using Fx.Infrastructure.DataAccess;
using Fx.Sms.Core;
using jos_sdk_net.Util;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class TikTokOrderInfoService : ITikTokOrderInfoService
    {
        private readonly IDalTikTokOrderInfo dalTikTokOrderInfo;
        private readonly IFxSmsBasedTemplateSender _smsSender;
        private readonly IDalBindCustomerService dalBindCustomerService;
        private readonly ISendOrderInfoService _sendOrderInfoService;
        private readonly IDalAmiyaEmployee dalAmiyaEmployee;
        private readonly IWxAppConfigService _wxAppConfigService;
        private readonly ILiveAnchorService liveAnchorService;
        private IContentPlatformService contentPlatFormService;
        private IUnitOfWork unitOfWork;
        private IDalOrderTrade dalOrderTrade;
        private IAmiyaGoodsDemandService _amiyaGoodsDemandService;
        private ICustomerService customerService;
        private IMemberCard memberCardService;
        private IMemberRankInfo memberRankInfoService;
        private IIntegrationAccount integrationAccountService;
        private IBindCustomerServiceService _bindCustomerServiceService;
        private IOrderCheckPictureService _orderCheckPictureService;
        private IDalCustomerInfo dalCustomerInfo;
        private IDalReceiveGift dalReceiveGift;
        private IGoodsInfo _goodsInfoService;
        private IDalContentPlatformOrder _dalContentPlatFormOrder;
        private IHospitalInfoService _hospitalInfoService;
        private IDalSendGoodsRecord dalSendGoodsRecord;
        private IOrderWriteOffInfoService _orderWriteOffInfoService;
        private IExpressManageService _expressManageService;

        public TikTokOrderInfoService(IDalTikTokOrderInfo dalTikTokOrderInfo, IFxSmsBasedTemplateSender smsSender, IDalBindCustomerService dalBindCustomerService, ISendOrderInfoService sendOrderInfoService, IDalAmiyaEmployee dalAmiyaEmployee, IDalOrderInfo dalOrderInfo, IWxAppConfigService wxAppConfigService, ILiveAnchorService liveAnchorService, IContentPlatformService contentPlatFormService, IUnitOfWork unitOfWork, IDalOrderTrade dalOrderTrade, IAmiyaGoodsDemandService amiyaGoodsDemandService, ICustomerService customerService, IMemberCard memberCardService, IMemberRankInfo memberRankInfoService, IIntegrationAccount integrationAccountService, IBindCustomerServiceService bindCustomerServiceService, IOrderCheckPictureService orderCheckPictureService, IDalCustomerInfo dalCustomerInfo, IDalReceiveGift dalReceiveGift, IGoodsInfo goodsInfoService, IDalContentPlatformOrder dalContentPlatFormOrder, IHospitalInfoService hospitalInfoService, IDalSendGoodsRecord dalSendGoodsRecord, IOrderWriteOffInfoService orderWriteOffInfoService, IExpressManageService expressManageService)
        {
            this.dalTikTokOrderInfo = dalTikTokOrderInfo;
            _smsSender = smsSender;
            this.dalBindCustomerService = dalBindCustomerService;
            _sendOrderInfoService = sendOrderInfoService;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
            _wxAppConfigService = wxAppConfigService;
            this.liveAnchorService = liveAnchorService;
            this.contentPlatFormService = contentPlatFormService;
            this.unitOfWork = unitOfWork;
            this.dalOrderTrade = dalOrderTrade;
            _amiyaGoodsDemandService = amiyaGoodsDemandService;
            this.customerService = customerService;
            this.memberCardService = memberCardService;
            this.memberRankInfoService = memberRankInfoService;
            this.integrationAccountService = integrationAccountService;
            _bindCustomerServiceService = bindCustomerServiceService;
            _orderCheckPictureService = orderCheckPictureService;
            this.dalCustomerInfo = dalCustomerInfo;
            this.dalReceiveGift = dalReceiveGift;
            _goodsInfoService = goodsInfoService;
            _dalContentPlatFormOrder = dalContentPlatFormOrder;
            _hospitalInfoService = hospitalInfoService;
            this.dalSendGoodsRecord = dalSendGoodsRecord;
            _orderWriteOffInfoService = orderWriteOffInfoService;
            _expressManageService = expressManageService;
        }

        public async Task<string> AddAmiyaOrderAsync(TikTokOrderTradeAddDto orderTradeAddDto)
        {
            try
            {
                unitOfWork.BeginTransaction();

                OrderTrade orderTrade = new OrderTrade();
                orderTrade.TradeId = Guid.NewGuid().ToString("N");
                orderTrade.CustomerId = orderTradeAddDto.CustomerId;
                orderTrade.CreateDate = orderTradeAddDto.CreateDate;
                if (orderTradeAddDto.OrderInfoAddList.Count(e => e.OrderType == (byte)OrderType.MaterialOrder) > 0)
                    orderTrade.AddressId = orderTradeAddDto.AddressId;
                orderTrade.TotalAmount = orderTradeAddDto.OrderInfoAddList.Sum(e => e.ActualPayment);
                orderTrade.TotalIntegration = orderTradeAddDto.OrderInfoAddList.Sum(e => e.IntegrationQuantity);
                orderTrade.Remark = orderTradeAddDto.Remark;
                orderTrade.IsAdminAdd = orderTradeAddDto.IsAdminAdd;
                orderTrade.StatusCode = OrderStatusCode.WAIT_BUYER_PAY;
                await dalOrderTrade.AddAsync(orderTrade, true);

                foreach (var item in orderTradeAddDto.OrderInfoAddList)
                {
                    item.TradeId = orderTrade.TradeId;
                }
                await AddAsync(orderTradeAddDto.OrderInfoAddList);

                unitOfWork.Commit();
                return orderTrade.TradeId;
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }

        public async Task AddAsync(List<TikTokOrderAddDto> orderList)
        {
            try
            {
                //var noticeConfigResult = from notice in dalNoticeConfig.GetAll() where notice.Name == "EMailNoticeConfig" select notice;
                //var noticeRes = noticeConfigResult.FirstOrDefault();
                var emailConfig = false;
                //订单号集合
                string goodsName = "";
                Dictionary<string, string> orderPhoneDict = new Dictionary<string, string>();
                byte appType = 0;
                List<TikTokOrderInfo> orderInfoList = new List<TikTokOrderInfo>();
                foreach (var orderItem in orderList)
                {
                    appType = orderItem.AppType;
                    var orderInfos = from d in dalTikTokOrderInfo.GetAll()
                                     where d.Id == orderItem.Id
                                     select d;
                    var orderInfo = orderInfos.FirstOrDefault();
                    if (orderInfo != null)
                    {
                        if (orderInfo.StatusCode == orderItem.StatusCode)
                        {
                            continue;
                        }
                        if (orderItem.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS || orderItem.StatusCode == OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS)
                        {
                            goodsName += orderItem.GoodsName + ",";
                            orderPhoneDict.Add(orderItem.Id, orderItem.Phone);
                            //组织邮件信息
                            if (emailConfig == true)
                            {
                                BuildSendMailInfo(appType, orderItem.Id, goodsName, orderItem.Phone);
                            }
                        }
                        orderInfo.StatusCode = orderItem.StatusCode;
                        orderInfo.UpdateDate = orderItem.UpdateDate;
                        orderInfo.ActualPayment = orderItem.ActualPayment;
                        orderInfo.AccountReceivable = orderItem.AccountReceivable;
                        orderInfo.OrderType = orderItem.OrderType;
                        orderInfo.AppointmentHospital = orderItem.AppointmentHospital;
                        orderInfo.ThumbPicUrl = orderItem.ThumbPicUrl;
                        if (orderItem.StatusCode == OrderStatusCode.TRADE_FINISHED)
                        {
                            orderInfo.WriteOffDate = orderItem.WriteOffDate;
                            //验证是否派过单
                            var sendOrderInfo = await _sendOrderInfoService.GetSendOrderInfoByOrderId(orderInfo.Id);
                            if (sendOrderInfo.Count != 0)
                            {
                                orderInfo.FinalConsumptionHospital = sendOrderInfo.First().HospitalName;
                            }
                            else
                            {
                                orderInfo.FinalConsumptionHospital = orderItem.AppointmentHospital;
                            }
                        }
                        await dalTikTokOrderInfo.UpdateAsync(orderInfo, true);
                    }
                    else
                    {
                        TikTokOrderInfo order = new TikTokOrderInfo();
                        order.Id = orderItem.Id;
                        order.GoodsId = orderItem.GoodsId;
                        order.GoodsName = orderItem.GoodsName;
                        order.Phone = orderItem.Phone;
                        order.AppointmentHospital = orderItem.AppointmentHospital;
                        order.StatusCode = orderItem.StatusCode;
                        if (orderItem.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS || orderItem.StatusCode == OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS)
                        {
                            goodsName += orderItem.GoodsName + ",";
                            if (!string.IsNullOrEmpty(order.Phone))
                            {
                                orderPhoneDict.Add(orderItem.Id, orderItem.Phone);
                            }
                            //组织邮件信息
                            if (emailConfig == true)
                            {
                                BuildSendMailInfo(appType, orderItem.Id, goodsName, orderItem.Phone);
                            }

                        }
                        order.ActualPayment = orderItem.ActualPayment;
                        order.AccountReceivable = orderItem.AccountReceivable;
                        order.CreateDate = orderItem.CreateDate;
                        order.UpdateDate = orderItem.UpdateDate;
                        order.ThumbPicUrl = orderItem.ThumbPicUrl;
                        order.BuyerNick = orderItem.BuyerNick;
                        order.CheckState = (int)CheckType.NotChecked;
                        order.AppType = orderItem.AppType;
                        order.IsAppointment = orderItem.IsAppointment;
                        order.OrderType = orderItem.OrderType;
                        order.OrderNature = orderItem.OrderNature.HasValue ? orderItem.OrderNature.Value : (byte)0;
                        order.Description = orderItem.Description;
                        order.Standard = orderItem.Standard;
                        order.Parts = orderItem.Part;
                        order.Quantity = orderItem.Quantity;
                        order.IntegrationQuantity = orderItem.IntegrationQuantity;
                        order.ExchangeType = orderItem.ExchangeType;
                        order.TradeId = orderItem.TradeId;
                        order.WriteOffCode = "";
                        order.AlreadyWriteOffAmount = 0;
                        order.BelongEmpId = orderItem.BelongEmpId;
                        order.TikTokUserInfoId = orderItem.TikTokUserId;
                        //order.TikTokUserInfoId=orderItem.
                        orderInfoList.Add(order);
                    }
                }
                await dalTikTokOrderInfo.AddCollectionAsync(orderInfoList, true);
                //发送短信通知
                SendPhoneInfo(orderPhoneDict, appType);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task AddOrderAsync(List<OrderInfoAddDto> orderList)
        {
            throw new NotImplementedException();
        }

        public Task<WxPayRequestInfo> BuildPayRequest(WxPackageInfo packageInfo)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 审核订单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CheckOrderAsync(ContentPlateFormOrderCheckDto input)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var order = await dalTikTokOrderInfo.GetAll().Where(x => x.Id == input.Id).SingleOrDefaultAsync();
                if (order == null)
                {
                    throw new Exception("未找到该订单的相关信息！");
                }
                order.CheckState = input.CheckState;
                order.CheckBy = input.employeeId;
                order.CheckPrice = input.CheckPrice;
                order.SettlePrice = input.SettlePrice;
                order.CheckRemark = input.CheckRemark;
                order.CheckDate = DateTime.Now;
                await dalTikTokOrderInfo.UpdateAsync(order, true);

                foreach (var x in input.CheckPicture)
                {
                    AddOrderCheckPictureDto addCheckPic = new AddOrderCheckPictureDto();
                    addCheckPic.OrderFrom = (int)OrderFrom.ThirdPartyOrder;
                    addCheckPic.OrderId = input.Id;
                    addCheckPic.PictureUrl = x;
                    await _orderCheckPictureService.AddAsync(addCheckPic);
                }
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
            }
        }

        public bool CheckVxPackage(WxPackageInfo package, out string errmsg)
        {
            throw new NotImplementedException();
        }

        public bool CheckVxSetParams(out string errmsg)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删除录单订单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            var sendOrderInfo = await _sendOrderInfoService.GetSendOrderInfoByOrderId(id);
            if (sendOrderInfo.Count > 0)
            {
                throw new Exception("该订单已派单，无法删除！");
            }
            var orderInfo = await dalTikTokOrderInfo.GetAll()
                .SingleOrDefaultAsync(e => e.Id == id);
            await dalTikTokOrderInfo.DeleteAsync(orderInfo, true);
        }

        public Task<List<OrderTradeDto>> ExportMiniProgramMaterialOrderTradeList(DateTime startDate, DateTime endDate, int employeeId, bool? isSendGoods, string keyword)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TikTokOrderDto>> ExportOrderListAsync(DateTime? startDate, DateTime? endDate, DateTime? writeOffStartDate, DateTime? writeOffEndDate, string keyword, string statusCode, byte? appType, byte? orderNature, int employeeId, bool isHidePhone)
        {
            try
            {
                var orders = from d in dalTikTokOrderInfo.GetAll()
                             where (string.IsNullOrWhiteSpace(keyword) || d.Id.Contains(keyword) || d.GoodsName.Contains(keyword)
                             || d.Phone == keyword || d.AppointmentHospital.Contains(keyword))
                             && (string.IsNullOrWhiteSpace(statusCode) || d.StatusCode == statusCode.Trim())
                             && (appType == null || d.AppType == appType)
                             && (orderNature == null || d.OrderNature == orderNature)
                             select d;

                if (startDate != null && endDate != null)
                {
                    DateTime startrq = ((DateTime)startDate);
                    DateTime endrq = ((DateTime)endDate).AddDays(1);
                    orders = from d in orders
                             where d.CreateDate >= startrq && d.CreateDate < endrq
                             select d;
                }
                if (writeOffStartDate != null && writeOffEndDate != null)
                {
                    DateTime startrqWriteOff = ((DateTime)writeOffStartDate);
                    DateTime endrqWriteOff = ((DateTime)writeOffEndDate).AddDays(1);
                    orders = from d in orders
                             where d.WriteOffDate >= startrqWriteOff && d.WriteOffDate < endrqWriteOff
                             select d;
                }
                var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                {
                    orders = from d in orders
                             where dalBindCustomerService.GetAll().Count(e => e.CustomerServiceId == employeeId && e.BuyerPhone == d.Phone) > 0
                             select d;
                }

                var order = from d in orders
                            select new TikTokOrderDto
                            {
                                Id = d.Id,
                                GoodsId = d.GoodsId,
                                GoodsName = d.GoodsName,
                                BuyerNick = d.BuyerNick,
                                ThumbPicUrl = d.ThumbPicUrl,
                                Phone = isHidePhone == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                //EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                AppointmentHospital = d.AppointmentHospital,
                                IsAppointment = d.IsAppointment,
                                StatusCode = d.StatusCode,
                                StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                                ActualPayment = d.ActualPayment,
                                CreateDate = d.CreateDate,
                                WriteOffDate = d.WriteOffDate,
                                AppType = d.AppType,
                                AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                                OrderType = d.OrderType,
                                OrderTypeText = d.OrderType != null ? ServiceClass.GetOrderTypeText((byte)d.OrderType) : "",
                                Quantity = d.Quantity,
                                IntegrationQuantity = d.IntegrationQuantity,
                                ExchangeType = d.ExchangeType,
                                ExchangeTypeText = ServiceClass.GetExchangeTypeText((byte)d.ExchangeType),
                                TradeId = d.TradeId,
                            };


                List<TikTokOrderDto> orderPageInfo = new List<TikTokOrderDto>();
                orderPageInfo = await order.OrderByDescending(e => e.CreateDate).ToListAsync();
                foreach (var x in orderPageInfo)
                {
                    var sendOrderInfo = await _sendOrderInfoService.GetSendOrderInfoByOrderId(x.Id);
                    if (sendOrderInfo.Count != 0)
                    {
                        x.SendOrderHospital = sendOrderInfo.First().HospitalName;
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
        /// 完成订单
        /// </summary>
        /// <param name="updateListDto"></param>
        /// <returns></returns>
        public async Task FinishOrderAsync(string orderId)
        {
            try
            {
                var orderInfo = await dalTikTokOrderInfo.GetAll().FirstOrDefaultAsync(e => e.Id == orderId);
                if (orderInfo == null)
                { throw new Exception("未找到该订单，完成订单失败！"); }
                orderInfo.StatusCode = OrderStatusCode.TRADE_FINISHED;
                if (!orderInfo.WriteOffDate.HasValue)
                { throw new Exception("该订单暂无核销时间，无法分配医院！请先在下单平台订单列表中校对订单或者在派单列表中完成订单后操作，若无法校对订单，请联系管理员"); }
                orderInfo.UpdateDate = DateTime.Now;
                await dalTikTokOrderInfo.UpdateAsync(orderInfo, true);

                await _bindCustomerServiceService.UpdateConsumePriceAsync(orderInfo.Phone, orderInfo.ActualPayment.Value, (int)OrderFrom.ThirdPartyOrder);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 根据客户编号获取已购买订单列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="ExchangeType"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<OrderInfoSimpleDto>> GetAlreadyBuyOrderListAsync(string customerId, int ExchangeType, int pageNum, int pageSize)
        {
            List<OrderInfoSimpleDto> orderInfoSimpleResult = new List<OrderInfoSimpleDto>();
            var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == customerId);
            var order = from d in dalTikTokOrderInfo.GetAll()
                        where d.Phone == customer.Phone
                        && d.CreateDate >= Convert.ToDateTime("2021-06-01")
                        //过滤掉定金订单和咨询订单
                        && d.StatusCode != "BARGAIN_MONEY" && d.StatusCode != "SEEK_ADVICE"
                        select new OrderInfo

                        {
                            Id = d.Id,
                            ThumbPicUrl = d.ThumbPicUrl,
                            GoodsName = d.GoodsName,
                            ActualPayment = d.ActualPayment,
                            ExchangeType = d.ExchangeType,
                            AppointmentHospital = d.AppointmentHospital,
                            CreateDate = d.CreateDate,
                            UpdateDate = d.UpdateDate,
                            GoodsId = d.GoodsId,
                            IntegrationQuantity = d.IntegrationQuantity,
                            Quantity = d.Quantity,
                            StatusCode = d.StatusCode,
                            AppType = d.AppType,
                            TradeId = d.TradeId
                        };
            if (ExchangeType == 0)
            {
                var result = from d in order
                             where d.ExchangeType == ExchangeType
                             && d.StatusCode != "BARGAIN_MONEY"
                             && d.StatusCode != "SEEK_ADVICE"
                             select new OrderInfoSimpleDto
                             {
                                 Id = d.Id,
                                 ThumbPicUrl = d.ThumbPicUrl,
                                 GoodsName = d.GoodsName,
                                 ActualPayment = d.ActualPayment,
                                 AppointmentHospital = d.AppointmentHospital,
                                 CreateDate = d.CreateDate.Value,
                                 UpdateDate = d.UpdateDate.Value,
                                 GoodsId = d.GoodsId,
                                 IntegrationQuantity = (d.IntegrationQuantity.HasValue) ? d.IntegrationQuantity : 0,
                                 Quantity = (d.Quantity.HasValue) ? d.Quantity.Value : 0,
                                 SingleIntegrationQuantity = (d.Quantity.HasValue) ? (d.IntegrationQuantity.Value / d.Quantity.Value) : d.IntegrationQuantity.Value,
                                 GoodsCategory = _goodsInfoService.GetByIdAsync(d.GoodsId).Result.CategoryName.ToString(),
                                 appType = d.AppType,
                                 StatusCodeInfo = d.StatusCode,
                                 StatusCode = ServiceClass.GetMiniGoodsOrderStatusText(d.StatusCode),
                                 TradeId = d.TradeId
                             };
                orderInfoSimpleResult = await result.ToListAsync();
            }
            else
            {
                var result = from d in order
                             where d.ExchangeType != 0
                             select new OrderInfoSimpleDto
                             {
                                 Id = d.Id,
                                 ThumbPicUrl = d.ThumbPicUrl,
                                 GoodsName = d.GoodsName,
                                 ActualPayment = d.ActualPayment,
                                 AppointmentHospital = d.AppointmentHospital,
                                 CreateDate = d.CreateDate.Value,
                                 GoodsId = d.GoodsId,
                                 IntegrationQuantity = d.IntegrationQuantity,
                                 Quantity = d.Quantity.Value,
                                 SinglePrice = (d.Quantity.HasValue) ? (d.ActualPayment.Value / d.Quantity.Value) : d.ActualPayment.Value,
                                 appType = d.AppType,
                                 StatusCodeInfo = d.StatusCode,
                                 StatusCode = ServiceClass.GetMiniOrderStatusText(d.StatusCode),
                                 TradeId = d.TradeId
                             };
                orderInfoSimpleResult = await result.ToListAsync();
            }
            var orderAlreadyBuyList = orderInfoSimpleResult.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            FxPageInfo<OrderInfoSimpleDto> OrderAlreadyBuyInfoList = new FxPageInfo<OrderInfoSimpleDto>();
            OrderAlreadyBuyInfoList.TotalCount = orderInfoSimpleResult.Count;
            OrderAlreadyBuyInfoList.List = orderAlreadyBuyList;
            return OrderAlreadyBuyInfoList;
        }

        public async Task<FxPageInfo<BindCustomerServiceOrderDto>> GetBindCustomerServieOrderListAsync(string keyword, int? customerServiceId, byte? appType, string statusCode, decimal? minPayment, decimal? maxPayment, int pageNum, int pageSize)
        {
            List<string> phoneList = new List<string>();
            var bindCustomerService = await dalBindCustomerService.GetAll()
                .Where(e => (customerServiceId == null || e.CustomerServiceId == customerServiceId)).ToListAsync();

            foreach (var item in bindCustomerService)
            {
                phoneList.Add(item.BuyerPhone);
            }

            var config = await _wxAppConfigService.GetCallCenterConfig();
            var orders = from d in dalTikTokOrderInfo.GetAll()
                         where phoneList.Contains(d.Phone)
                          && (keyword == null || d.GoodsName.Contains(keyword) || d.Phone == keyword || d.Id == keyword)
                         && (appType == null || d.AppType == appType)
                         && (string.IsNullOrWhiteSpace(statusCode) || d.StatusCode == statusCode.Trim())
                         select d;

            if (minPayment != null && maxPayment != null)
            {
                orders = from d in orders
                         where d.ActualPayment >= minPayment && d.ActualPayment <= maxPayment
                         select d;
            }

            var orderInfos = from d in orders
                             select new BindCustomerServiceOrderDto
                             {
                                 Id = d.Id,
                                 GoodsId = d.GoodsId,
                                 GoodsName = d.GoodsName,
                                 Phone = d.Phone,
                                 EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                 AppointmentHospital = d.AppointmentHospital,
                                 IsAppointment = d.IsAppointment,
                                 StatusCode = d.StatusCode,
                                 StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                                 ActualPayment = d.ActualPayment,
                                 ThumbPicUrl = d.ThumbPicUrl,
                                 AppType = d.AppType,
                                 AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                                 Quantity = d.Quantity,
                                 IntegrationQuantity = d.IntegrationQuantity,
                                 ExchangeType = d.ExchangeType,
                                 ExchangeTypeText = ServiceClass.GetExchangeTypeText((byte)d.ExchangeType),
                                 TradeId = d.TradeId,
                             };

            FxPageInfo<BindCustomerServiceOrderDto> orderPageInfo = new FxPageInfo<BindCustomerServiceOrderDto>();
            orderPageInfo.TotalCount = await orderInfos.CountAsync();
            orderPageInfo.List = await orderInfos.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();


            foreach (var item in orderPageInfo.List)
            {
                var employee = await dalAmiyaEmployee.GetAll().ToListAsync();
                item.CustomerServiceId = bindCustomerService.FirstOrDefault(e => e.BuyerPhone == item.Phone).CustomerServiceId;
                item.CustomerServiceName = employee.SingleOrDefault(t => t.Id == bindCustomerService.FirstOrDefault(e => e.BuyerPhone == item.Phone).CustomerServiceId).Name;
                item.Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(item.Phone) : item.Phone;
            }
            return orderPageInfo;
        }
        /// <summary>
        /// 根据订单编号获取订单信息(小程序用)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TikTokOrderDto> GetByIdAsync(string id)
        {
            var config = await _wxAppConfigService.GetCallCenterConfig();
            var order = await dalTikTokOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);
            if (order == null)
                throw new Exception("订单编号错误");
            if (order.StatusCode == "SEEK_ADVICE")
                throw new Exception("该订单为咨询订单，无法展示！");
            if (order.StatusCode == "BARGAIN_MONEY")
                throw new Exception("该订单为定金订单，无法展示！");

            TikTokOrderDto orderInfo = new TikTokOrderDto();
            orderInfo.Id = order.Id;
            orderInfo.GoodsName = order.GoodsName;
            orderInfo.GoodsId = order.GoodsId;
            orderInfo.ThumbPicUrl = order.ThumbPicUrl;
            orderInfo.BuyerNick = order.BuyerNick;
            orderInfo.Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(order.Phone) : order.Phone;
            orderInfo.EncryptPhone = ServiceClass.Encrypt(order.Phone, config.PhoneEncryptKey);
            orderInfo.AppointmentHospital = order.AppointmentHospital;
            orderInfo.IsAppointment = order.IsAppointment;
            orderInfo.StatusCode = order.StatusCode;
            orderInfo.StatusText = ServiceClass.GetOrderStatusText(order.StatusCode);
            orderInfo.ActualPayment = order.ActualPayment;
            orderInfo.CreateDate = order.CreateDate;
            orderInfo.UpdateDate = order.UpdateDate;
            orderInfo.OrderType = order.OrderType;
            orderInfo.AppType = order.AppType;
            orderInfo.AppTypeText = ServiceClass.GetAppTypeText(order.AppType);
            orderInfo.Quantity = order.Quantity;
            orderInfo.IntegrationQuantity = order.IntegrationQuantity;
            orderInfo.ExchangeType = order.ExchangeType;
            orderInfo.WriteOffCode = order.WriteOffCode;
            orderInfo.TradeId = order.TradeId;
            return orderInfo;
        }
        /// <summary>
        /// 根据订单编号获取订单信息(crm系统用)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TikTokOrderDto> GetByIdInCRMAsync(string id)
        {
            var config = await _wxAppConfigService.GetCallCenterConfig();
            var order = await dalTikTokOrderInfo.GetAll().Include(x => x.SendOrderInfoList).SingleOrDefaultAsync(e => e.Id == id);
            if (order == null)
                throw new Exception("订单编号错误");

            TikTokOrderDto orderInfo = new TikTokOrderDto();
            orderInfo.Id = order.Id;
            orderInfo.GoodsName = order.GoodsName;
            orderInfo.GoodsId = order.GoodsId;
            orderInfo.ThumbPicUrl = order.ThumbPicUrl;
            orderInfo.BuyerNick = order.BuyerNick;
            orderInfo.Phone = order.Phone;
            orderInfo.EncryptPhone = ServiceClass.Encrypt(order.Phone, config.PhoneEncryptKey);
            orderInfo.AppointmentHospital = order.AppointmentHospital;
            orderInfo.IsAppointment = order.IsAppointment;
            orderInfo.StatusCode = order.StatusCode;
            orderInfo.StatusText = ServiceClass.GetOrderStatusText(order.StatusCode);
            orderInfo.ActualPayment = order.ActualPayment;
            orderInfo.CreateDate = order.CreateDate;
            orderInfo.UpdateDate = order.UpdateDate;
            orderInfo.OrderType = order.OrderType;
            orderInfo.OrderTypeText = ServiceClass.GetOrderTypeText(order.OrderType);
            orderInfo.Description = order.Description;
            orderInfo.OrderNature = order.OrderNature;
            orderInfo.OrderNatureText = ServiceClass.GetOrderNatureText(Convert.ToByte(order.OrderNature));
            orderInfo.AppType = order.AppType;
            orderInfo.AppTypeText = ServiceClass.GetAppTypeText(order.AppType);
            orderInfo.ExchangeType = order.ExchangeType;
            orderInfo.ExchangeTypeText = order.ExchangeType.HasValue ? ServiceClass.GetExchangeTypeText((byte)order.ExchangeType) : "三方支付";
            orderInfo.CheckState = ServiceClass.GetCheckTypeText(order.CheckState.Value);
            orderInfo.IsReturnBackPrice = order.IsReturnBackPrice;
            if (order.CheckState == (int)CheckType.CheckedSuccess)
            {
                orderInfo.CheckDate = order.CheckDate;
                orderInfo.CheckPrice = order.CheckPrice.Value;
                orderInfo.SettlePrice = order.SettlePrice.Value;
                var empInfo = await dalAmiyaEmployee.GetAll().Where(x => x.Id == order.CheckBy.Value).FirstOrDefaultAsync();
                orderInfo.CheckByEmpName = empInfo.Name;
                orderInfo.CheckRemark = order.CheckRemark;
            }
            if (order.IsReturnBackPrice == true)
            {
                orderInfo.ReturnBackPrice = order.ReturnBackPrice;
                orderInfo.ReturnBackDate = order.ReturnBackDate;
            }
            orderInfo.Quantity = order.Quantity;
            orderInfo.IntegrationQuantity = order.IntegrationQuantity;
            orderInfo.WriteOffCode = order.WriteOffCode;
            orderInfo.WriteOffDate = order.WriteOffDate;
            orderInfo.AccountReceivable = order.AccountReceivable;
            orderInfo.FinalConsumptionHospital = order.FinalConsumptionHospital;
            if (order.BelongEmpId != 0)
            {
                orderInfo.BelongEmpId = order.BelongEmpId;
                var empInfo = await dalAmiyaEmployee.GetAll().Where(x => x.Id == order.BelongEmpId).FirstOrDefaultAsync();
                orderInfo.BelongEmpName = empInfo.Name;
            }
            if (order.LiveAnchorId != 0)
            {
                orderInfo.LiveAnchorId = order.LiveAnchorId;
                var liveAnchorInfo = await liveAnchorService.GetByIdAsync(order.LiveAnchorId);
                orderInfo.LiveAnchorName = liveAnchorInfo.Name;
                orderInfo.ContentPlatFormId = liveAnchorInfo.ContentPlateFormId;
                var contentPlatFormInfo = await contentPlatFormService.GetByIdAsync(liveAnchorInfo.ContentPlateFormId);
                orderInfo.LiveAnchorPlatForm = contentPlatFormInfo.ContentPlatformName;
            }
            if (order.SendOrderInfoList != null)
            {
                var sendHospital = order.SendOrderInfoList.OrderByDescending(x => x.SendDate).FirstOrDefault();
                if (sendHospital != null)
                {
                    var hospitalInfo = await _hospitalInfoService.GetBaseByIdAsync(sendHospital.HospitalId);
                    orderInfo.SendOrderHospital = hospitalInfo.Name;
                    orderInfo.SendOrderHospitalId = sendHospital.HospitalId;
                }
            }
            orderInfo.TradeId = order.TradeId;
            return orderInfo;
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
            var orders = from d in dalTikTokOrderInfo.GetAll()
                         where d.CheckState == (int)CheckType.CheckedSuccess && d.CheckDate.Value >= startrq && d.CheckDate.Value < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.CheckDate.Value.Date).Select(x => new OrderPriceConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderPrice = x.Sum(z => z.CheckPrice.Value) }).ToList();
        }

        public async Task<List<OrderWriteOffDto>> GetCustomerOrderReceivableAsync(DateTime? startDate, DateTime? endDate, int? CheckState, bool? ReturnBackPriceState, string customerName, bool isHidePhone)
        {
            var orders = from d in dalTikTokOrderInfo.GetAll()
                         where (d.StatusCode == "TRADE_FINISHED") && d.OrderType == 0
                         select d;

            if (startDate != null && endDate != null)
            {
                DateTime startrqWriteOff = ((DateTime)startDate);
                DateTime endrqWriteOff = ((DateTime)endDate).Date.AddDays(1);
                orders = from d in orders
                         where d.WriteOffDate >= startrqWriteOff && d.WriteOffDate < endrqWriteOff
                         select d;
            }
            if (!string.IsNullOrEmpty(customerName))
            {
                orders = from d in orders
                         where d.BuyerNick.Contains(customerName)
                         select d;
            }
            if (CheckState.HasValue)
            {
                orders = from d in orders
                         where d.CheckState == CheckState.Value
                         select d;
            }
            if (ReturnBackPriceState.HasValue)
            {
                orders = from d in orders
                         where d.IsReturnBackPrice == ReturnBackPriceState.Value
                         select d;
            }
            var order = from d in orders
                        select new OrderWriteOffDto
                        {
                            Id = d.Id,
                            GoodsName = d.GoodsName,
                            NickName = d.BuyerNick,
                            EncryptPhone = isHidePhone == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                            AppointmentHospital = d.AppointmentHospital,
                            StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                            ActualPayment = d.ActualPayment,
                            AccountReceivable = d.AccountReceivable,
                            CreateDate = d.CreateDate,
                            WriteOffDate = d.WriteOffDate,
                            AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                            Quantity = d.Quantity,
                            FinalConsumptionHospital = d.FinalConsumptionHospital,
                            BelongEmpId = d.BelongEmpId,
                            CheckStateText = ServiceClass.GetCheckTypeText(d.CheckState.Value),
                            CheckPrice = d.CheckPrice,
                            CheckDate = d.CheckDate,
                            CheckBy = d.CheckBy,
                            CheckRemark = d.CheckRemark,
                            SettlePrice = d.SettlePrice,
                            IsReturnBackPrice = d.IsReturnBackPrice,
                            ReturnBackPrice = d.ReturnBackPrice,
                            ReturnBackDate = d.ReturnBackDate
                        };

            List<OrderWriteOffDto> orderPageInfo = new List<OrderWriteOffDto>();
            orderPageInfo = await order.ToListAsync();
            foreach (var x in orderPageInfo)
            {
                var sendOrderInfo = await _sendOrderInfoService.GetSendOrderInfoByOrderId(x.Id);
                if (sendOrderInfo.Count != 0)
                {
                    x.SendOrderHospital = sendOrderInfo.First().HospitalName;
                    x.SendOrderPrice = sendOrderInfo.First().PurchaseSinglePrice * sendOrderInfo.First().PurchaseNum;
                    x.SendEmployeeName = sendOrderInfo.First().SendName;
                }
                if (x.BelongEmpId != 0)
                {
                    var customerService = await dalAmiyaEmployee.GetAll().FirstOrDefaultAsync(e => e.Id == x.BelongEmpId);
                    x.BenlongEmpName = customerService.Name.ToString();
                }
                if (x.CheckBy.HasValue && x.CheckBy != 0)
                {
                    var checkBy = await dalAmiyaEmployee.GetAll().FirstOrDefaultAsync(e => e.Id == x.CheckBy.Value);
                    x.CheckByEmpName = checkBy.Name.ToString();
                }
            }
            return orderPageInfo.OrderByDescending(z => z.NickName).ThenByDescending(z => z.WriteOffDate).ToList();
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
            var orders = from d in dalTikTokOrderInfo.GetAll()
                         where d.SendOrderInfoList.Count > 0
                         && d.OrderType == (byte)OrderType.VirtualOrder
                         && d.SendOrderInfoList.Max(x => x.SendDate) >= startrq
                         && d.SendOrderInfoList.Max(x => x.SendDate) < endrq
                         select d;
            var sendOrder = from d in orders
                            select new HospitalOrderNumAndPriceDto
                            {
                                Price = d.ActualPayment.Value,
                                HospitalName = d.SendOrderInfoList.First().SendBy.ToString(),
                                OrderNum = 1
                            };
            var result = sendOrder.ToList();
            List<HospitalOrderNumAndPriceDto> returnInfo = new List<HospitalOrderNumAndPriceDto>();

            foreach (var x in result)
            {
                if (!string.IsNullOrEmpty(x.HospitalName))
                {
                    HospitalOrderNumAndPriceDto returnResult = new HospitalOrderNumAndPriceDto();
                    var empInfo = await dalAmiyaEmployee.GetAll().FirstOrDefaultAsync(e => e.Id == Convert.ToInt32(x.HospitalName));
                    returnResult.HospitalName = empInfo.Name;
                    returnResult.Price = x.Price;
                    returnResult.OrderNum = x.OrderNum;
                    returnInfo.Add(returnResult);
                }
            }
            return returnInfo;
        }
        /// <summary>
        /// 获取所有已核销客户注册过小程序的订单
        /// </summary>
        /// <returns></returns>
        public async Task<List<CustomerOrderDto>> GetCustomerTradeFinishOrderListAsync()
        {
            var orders = from d in dalTikTokOrderInfo.GetAll()
                         join c in dalCustomerInfo.GetAll() on d.Phone equals c.Phone
                         where d.ActualPayment >= 1 && d.StatusCode == OrderStatusCode.TRADE_FINISHED
                         select new CustomerOrderDto
                         {
                             Id = d.Id,
                             Phone = d.Phone,
                             ActualPayment = (decimal)d.ActualPayment,
                             CustomerId = c.Id
                         };
            return await orders.ToListAsync();
        }
        /// <summary>
        /// 根据手机号，快递单号，物流公司id获取快递信息
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="num">快递单号</param>
        /// <param name="expressId">物流公司id</param>
        /// <returns></returns>
        public async Task<OrderExpressInfoDto> GetExpressInfo(string phone, string num, string expressId)
        {
            OrderExpressInfoDto result = new OrderExpressInfoDto();
            var expressInfo = _expressManageService.GetByIdAsync(expressId);
            if (expressInfo == null)
            {
                throw new Exception("未找到该物流公司信息！");
            }
            //请求快递公司地址
            string url = "https://poll.kuaidi100.com/poll/query.do";
            ExpressDetail queryTrackParam = new ExpressDetail();
            if (expressInfo.Result.ExpressCode == "shunfeng")
            {
                if (string.IsNullOrEmpty(phone))
                {
                    throw new Exception("顺丰快递查询必须填写手机号！");
                }
                queryTrackParam = new ExpressDetail()
                {
                    com = expressInfo.Result.ExpressCode,
                    num = num,
                    phone = phone
                };
            }
            else
            {
                queryTrackParam = new ExpressDetail()
                {
                    com = expressInfo.Result.ExpressCode,
                    num = num,
                };
            }
            ExpressRequestDto query = new ExpressRequestDto()
            {
                customer = "39C07E8E21A36F50B268DECD2EAE03A3",
                sign = MD5Helper.Get32MD5One(JsonConvert.SerializeObject(queryTrackParam) + "WfffjvGX8933" + "39C07E8E21A36F50B268DECD2EAE03A3"),
                param = JsonConvert.SerializeObject(queryTrackParam)
            };
            var requestParam = KuaiDi100Utils.ObjectToMap(query);
            if (requestParam == null)
            {
                return null;
            }

            var kuaidi100Response = KuaiDi100Utils.doPostForm(url, requestParam);
            result = JsonConvert.DeserializeObject<OrderExpressInfoDto>(kuaidi100Response);
            if (result.message != "ok")
            {
                throw new Exception(result.message.ToString());
            }
            result.ExpressName = expressInfo.Result.ExpressName;
            result.ExpressNo = num;
            return result;
        }
        /// <summary>
        /// 获取最新订单状态改变时间
        /// </summary>
        /// <returns></returns>
        public async Task<DateTime?> GetLatelyStatusChangeDateAsync(int employeeId)
        {
            DateTime date = DateTime.Now;

            var orders = from d in dalTikTokOrderInfo.GetAll()
                         where ((DateTime)d.CreateDate).Date != date.Date && ((DateTime)d.UpdateDate).Date == date.Date
                         select d;
            if (employeeId != -1)
            {
                var bindCustomerService = await dalBindCustomerService.GetAll().Where(e => e.CustomerServiceId == employeeId).ToListAsync();
                List<string> phoneList = new List<string>();
                foreach (var item in bindCustomerService)
                {
                    phoneList.Add(item.BuyerPhone);
                }
                orders = from d in orders
                         where phoneList.Contains(d.Phone)
                         select d;
            }


            var order = await orders.OrderByDescending(e => e.UpdateDate).FirstOrDefaultAsync();
            return order?.UpdateDate;
        }

        public Task<FxPageInfo<TikTokOrderDto>> GetListByEncryptPhoneAsync(string encryptPhone, int pageNum, int pageSize)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据交易编号获取订单列表
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        public async Task<List<TikTokOrderDto>> GetListByTradeIdAsync(int employeeId, string tradeId)
        {
            bool hidePhone = false;
            var config = await _wxAppConfigService.GetCallCenterConfig();
            if (config.HidePhoneNumber)
            {
                var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee.IsCustomerService && employee.AmiyaPositionInfo.IsDirector == false)
                {
                    hidePhone = true;
                }
            }

            var orders = from d in dalTikTokOrderInfo.GetAll()
                         where d.TradeId == tradeId
                         select new TikTokOrderDto
                         {
                             Id = d.Id,
                             GoodsId = d.GoodsId,
                             GoodsName = d.GoodsName,
                             ThumbPicUrl = d.ThumbPicUrl,
                             Phone = hidePhone == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                             EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                             AppointmentHospital = d.AppointmentHospital,
                             IsAppointment = d.IsAppointment,
                             StatusCode = d.StatusCode,
                             StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                             ActualPayment = d.ActualPayment,
                             CreateDate = d.CreateDate,
                             AppType = d.AppType,
                             AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                             OrderType = d.OrderType,
                             OrderTypeText = d.OrderType != null ? ServiceClass.GetOrderTypeText((byte)d.OrderType) : "",
                             Quantity = d.Quantity,
                             IntegrationQuantity = d.IntegrationQuantity,
                             ExchangeType = d.ExchangeType,
                             ExchangeTypeText = ServiceClass.GetExchangeTypeText((byte)d.ExchangeType),
                             TradeId = d.TradeId,
                         };
            return await orders.ToListAsync();
        }

        public Task<FxPageInfo<OrderTradeDto>> GetMiniProgramMaterialOrderTradeList(DateTime startDate, DateTime endDate, int employeeId, bool? isSendGoods, string keyword, int pageNum, int pageSize)
        {
            throw new NotImplementedException();
        }

        public List<OrderAppTypeDto> GetOrderAppTypeList()
        {
            var orderAppTypes = Enum.GetValues(typeof(AppType));
            List<OrderAppTypeDto> orderAppTypeList = new List<OrderAppTypeDto>();
            foreach (var item in orderAppTypes)
            {
                OrderAppTypeDto orderAppType = new OrderAppTypeDto();
                orderAppType.OrderType = Convert.ToByte(item);
                orderAppType.AppTypeText = ServiceClass.GetAppTypeText(Convert.ToByte(item));
                orderAppTypeList.Add(orderAppType);
            }
            return orderAppTypeList;
        }

        public async Task<List<BuyOrderReportDto>> GetOrderBuyAsync(DateTime? startDate, DateTime? endDate, int belongEmpId, bool isHidePhone)
        {
            var orders = from d in dalTikTokOrderInfo.GetAll()
                         where (d.StatusCode == "WAIT_BUYER_CONFIRM_GOODS" || d.StatusCode == "WAIT_SELLER_SEND_GOODS" || d.StatusCode == "BARGAIN_MONEY")
                         && d.OrderType == 0
                         && (belongEmpId == 0 || d.BelongEmpId == belongEmpId)
                         select d;

            if (startDate != null && endDate != null)
            {
                DateTime startbuyOrderDate = ((DateTime)startDate);
                DateTime endbuyOrderDate = ((DateTime)endDate).Date.AddDays(1);
                orders = from d in orders
                         where d.CreateDate >= startbuyOrderDate && d.CreateDate < endbuyOrderDate
                         select d;
            }
            var order = from d in orders
                        select new BuyOrderReportDto
                        {
                            Id = d.Id,
                            GoodsName = d.GoodsName,
                            Phone = isHidePhone == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                            NickName = d.BuyerNick,
                            AppointmentHospital = d.AppointmentHospital,
                            StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                            ActualPayment = d.ActualPayment,
                            UpdateDate = d.UpdateDate,
                            CreateDate = d.CreateDate,
                            AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                            Quantity = d.Quantity,
                            BelongEmpId = d.BelongEmpId,
                        };

            List<BuyOrderReportDto> orderPageInfo = new List<BuyOrderReportDto>();
            orderPageInfo = await order.OrderByDescending(e => e.CreateDate).ToListAsync();
            foreach (var x in orderPageInfo)
            {
                if (x.BelongEmpId != 0)
                {
                    var customerService = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == x.BelongEmpId);
                    x.BelongEmpName = customerService.Name.ToString();
                }
            }
            return orderPageInfo;
        }

        public async Task<FxPageInfo<TikTokOrderDto>> GetOrderByEmployeeIdAsync(int employeeId, string statusCode, string keyword, int pageNum, int pageSize)
        {
            var orders = from d in dalTikTokOrderInfo.GetAll()
                         where (string.IsNullOrWhiteSpace(statusCode) || d.StatusCode == statusCode)
                         && (string.IsNullOrWhiteSpace(keyword) || d.GoodsName.Contains(keyword) || d.Id.Contains(keyword)
                         || d.Phone == keyword || d.AppointmentHospital.Contains(keyword))
                         select d;
            if (employeeId != -1)
            {
                var bindCustomerService = await dalBindCustomerService.GetAll().Where(e => e.CustomerServiceId == employeeId).ToListAsync();
                List<string> phoneList = new List<string>();
                foreach (var item in bindCustomerService)
                {
                    phoneList.Add(item.BuyerPhone);
                }
                orders = from d in orders
                         where phoneList.Contains(d.Phone)
                         select d;
            }
            var config = await _wxAppConfigService.GetCallCenterConfig();
            var orderInfo = from d in orders
                            select new TikTokOrderDto
                            {
                                Id = d.Id,
                                GoodsName = d.GoodsName,
                                GoodsId = d.GoodsId,
                                ThumbPicUrl = d.ThumbPicUrl,
                                Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                AppointmentHospital = d.AppointmentHospital,
                                IsAppointment = d.IsAppointment,
                                StatusCode = d.StatusCode,
                                StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                                ActualPayment = d.ActualPayment,
                                CreateDate = d.CreateDate,
                                UpdateDate = d.UpdateDate,
                                AppType = d.AppType,
                                AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                                Quantity = d.Quantity,
                                IntegrationQuantity = d.IntegrationQuantity,
                                ExchangeType = d.ExchangeType,
                                ExchangeTypeText = ServiceClass.GetExchangeTypeText((byte)d.ExchangeType),
                                TradeId = d.TradeId,
                            };
            FxPageInfo<TikTokOrderDto> orderPageInfo = new FxPageInfo<TikTokOrderDto>();
            orderPageInfo.TotalCount = await orderInfo.CountAsync();
            orderPageInfo.List = await orderInfo.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return orderPageInfo;
        }
        /// <summary>
        /// 根据订单编号获取客户订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<CustomerOrderDto> GetOrderByIdAsync(string orderId)
        {
            var order = from d in dalTikTokOrderInfo.GetAll()
                        join c in dalCustomerInfo.GetAll() on d.Phone equals c.Phone
                        where d.Id == orderId
                        select new CustomerOrderDto
                        {
                            Id = d.Id,
                            Phone = d.Phone,
                            ActualPayment = (decimal)d.ActualPayment,
                            CustomerId = c.Id
                        };
            if (await order.CountAsync() == 0)
                return null;
            return await order.SingleOrDefaultAsync();
        }

        public async Task<List<BuyOrderReportDto>> GetOrderCloseAsync(DateTime? startDate, DateTime? endDate, bool isHidePhone)
        {
            var orders = from d in dalTikTokOrderInfo.GetAll()
                         where d.StatusCode == "TRADE_CLOSED" && d.OrderType == 0
                         select d;

            if (startDate != null && endDate != null)
            {
                DateTime startrqWriteOff = ((DateTime)startDate);
                DateTime endrqWriteOff = ((DateTime)endDate).Date.AddDays(1);
                orders = from d in orders
                         where d.CreateDate >= startrqWriteOff && d.CreateDate < endrqWriteOff
                         select d;
            }
            var order = from d in orders
                        select new BuyOrderReportDto
                        {
                            Id = d.Id,
                            GoodsName = d.GoodsName,
                            Phone = isHidePhone == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                            NickName = d.BuyerNick,
                            AppointmentHospital = d.AppointmentHospital,
                            StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                            ActualPayment = d.ActualPayment,
                            UpdateDate = d.UpdateDate,
                            CreateDate = d.CreateDate,
                            AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                            Quantity = d.Quantity,
                        };

            List<BuyOrderReportDto> orderPageInfo = new List<BuyOrderReportDto>();
            orderPageInfo = await order.OrderByDescending(e => e.CreateDate).ToListAsync();
            return orderPageInfo;
        }
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
            var orders = from d in dalTikTokOrderInfo.GetAll()
                         where d.StatusCode == "TRADE_FINISHED" && d.WriteOffDate.Value >= startrq && d.WriteOffDate.Value < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.WriteOffDate.Value.Date).Select(x => new OrderPriceConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderPrice = x.Sum(z => z.ActualPayment.Value) }).ToList();
        }

        public async Task<OrderExpressInfoDto> GetOrderExpressInfoAsync(string tradeId)
        {
            var sendGoodsRecordInfoList = await dalSendGoodsRecord.GetAll().ToListAsync();
            var sendGoodsRecordInfo = sendGoodsRecordInfoList.Where(x => x.TradeId == tradeId).FirstOrDefault();
            if (sendGoodsRecordInfo == null)
            {
                throw new Exception("未找到该交易编号！");
            }
            var orderList = from d in dalTikTokOrderInfo.GetAll()
                            where d.TradeId == tradeId
                            select d.Phone;
            var phone = orderList.FirstOrDefault();
            if (phone == null)
            {
                throw new Exception("未找到该订单编号！");
            }
            var result = await GetExpressInfo(phone, sendGoodsRecordInfo.CourierNumber, sendGoodsRecordInfo.ExpressId);
            return result;
        }

        public async Task<FxPageInfo<TikTokOrderDto>> GetOrderFinishListWithPageAsync(DateTime? writeOffStartDate, DateTime? writeOffEndDate, int? CheckState, bool? ReturnBackPriceState, string keyword, byte? appType, byte? orderNature, int employeeId, int pageNum, int pageSize)
        {
            try
            {
                var orders = from d in dalTikTokOrderInfo.GetAll()
                             where (string.IsNullOrWhiteSpace(keyword) || d.Id.Contains(keyword) || d.GoodsName.Contains(keyword)
                             || d.Phone == keyword || d.AppointmentHospital.Contains(keyword))
                             && d.StatusCode == OrderStatusCode.TRADE_FINISHED
                             && (!CheckState.HasValue || d.CheckState == CheckState.Value)
                             && (!ReturnBackPriceState.HasValue || d.IsReturnBackPrice == ReturnBackPriceState.Value)
                             && (appType == null || d.AppType == appType)
                             && (orderNature == null || d.OrderNature == orderNature)
                             select d;

                if (writeOffStartDate != null && writeOffEndDate != null)
                {
                    DateTime startrqWriteOff = ((DateTime)writeOffStartDate);
                    DateTime endrqWriteOff = ((DateTime)writeOffEndDate).AddDays(1);
                    orders = from d in orders
                             where d.WriteOffDate >= startrqWriteOff && d.WriteOffDate < endrqWriteOff
                             select d;
                }
                //获取绑定的员工
                var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                {
                    //获取已经绑定过客服的订单
                    orders = from d in orders
                             where dalBindCustomerService.GetAll().Count(e => e.CustomerServiceId == employeeId && e.BuyerPhone == d.Phone) > 0
                             select d;
                }

                var config = await _wxAppConfigService.GetCallCenterConfig();
                var order = from d in orders
                            select new TikTokOrderDto
                            {
                                Id = d.Id,
                                GoodsId = d.GoodsId,
                                GoodsName = d.GoodsName,
                                BuyerNick = d.BuyerNick,
                                ThumbPicUrl = d.ThumbPicUrl,
                                Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                AppointmentHospital = d.AppointmentHospital,
                                IsAppointment = d.IsAppointment,
                                StatusCode = d.StatusCode,
                                StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                                ActualPayment = d.ActualPayment,
                                CreateDate = d.CreateDate,
                                WriteOffDate = d.WriteOffDate,
                                AppType = d.AppType,
                                AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                                OrderType = d.OrderType,
                                OrderTypeText = d.OrderType != null ? ServiceClass.GetOrderTypeText((byte)d.OrderType) : "",
                                OrderNature = d.OrderNature,
                                OrderNatureText = d.OrderNature != null ? ServiceClass.GetOrderNatureText((byte)d.OrderNature) : "",
                                Quantity = d.Quantity,
                                IntegrationQuantity = d.IntegrationQuantity,
                                ExchangeType = d.ExchangeType,
                                ExchangeTypeText = ServiceClass.GetExchangeTypeText((byte)d.ExchangeType),
                                TradeId = d.TradeId,
                                FinalConsumptionHospital = d.FinalConsumptionHospital,
                                LiveAnchorId = d.LiveAnchorId,
                                CheckState = ServiceClass.GetCheckTypeText(d.CheckState.Value),
                                CheckPrice = d.CheckPrice,
                                CheckDate = d.CheckDate,
                                CheckBy = d.CheckBy,
                                CheckRemark = d.CheckRemark,
                                SendOrderHospital = d.SendOrderInfoList == null ? "" : d.SendOrderInfoList.OrderByDescending(k => k.SendDate).First().HospitalInfo.Name,
                                SettlePrice = d.SettlePrice,
                                IsReturnBackPrice = d.IsReturnBackPrice,
                                ReturnBackPrice = d.ReturnBackPrice,
                                ReturnBackDate = d.ReturnBackDate,
                                TikTokUserId = d.TikTokUserInfoId
                            };


                FxPageInfo<TikTokOrderDto> orderPageInfo = new FxPageInfo<TikTokOrderDto>();
                orderPageInfo.TotalCount = await order.CountAsync();
                orderPageInfo.List = await order.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                foreach (var x in orderPageInfo.List)
                {
                    if (x.LiveAnchorId != 0)
                    {
                        var liveanchor = await liveAnchorService.GetByIdAsync(x.LiveAnchorId);
                        x.LiveAnchorName = liveanchor.Name;
                        if (!string.IsNullOrEmpty(liveanchor.ContentPlateFormId))
                        {
                            x.ContentPlatFormId = liveanchor.ContentPlateFormId;
                            var contentplatFormInfo = await contentPlatFormService.GetByIdAsync(liveanchor.ContentPlateFormId);
                            x.LiveAnchorPlatForm = contentplatFormInfo.ContentPlatformName;
                        }
                    }
                    if (x.CheckBy.HasValue && x.CheckBy != 0)
                    {
                        var checkBy = await dalAmiyaEmployee.GetAll().FirstOrDefaultAsync(e => e.Id == x.CheckBy.Value);
                        x.CheckByEmpName = checkBy.Name.ToString();
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
        /// 根据核销码获取订单信息
        /// </summary>
        /// <param name="WriteOffCode"></param>
        /// <returns></returns>
        public async Task<List<TikTokOrderDto>> GetOrderInfoByWriteOffCode(string WriteOffCode)
        {
            var config = await _wxAppConfigService.GetCallCenterConfig();
            var orders = from d in dalTikTokOrderInfo.GetAll()
                         where d.WriteOffCode == WriteOffCode
                         select new TikTokOrderDto
                         {
                             Id = d.Id,
                             GoodsId = d.GoodsId,
                             GoodsName = d.GoodsName,
                             ThumbPicUrl = d.ThumbPicUrl,
                             Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                             EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                             AppointmentHospital = d.AppointmentHospital,
                             IsAppointment = d.IsAppointment,
                             StatusCode = d.StatusCode,
                             StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                             ActualPayment = d.ActualPayment,
                             CreateDate = d.CreateDate,
                             AppType = d.AppType,
                             AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                             OrderType = d.OrderType,
                             OrderTypeText = d.OrderType != null ? ServiceClass.GetOrderTypeText((byte)d.OrderType) : "",
                             Quantity = d.Quantity,
                             IntegrationQuantity = d.IntegrationQuantity,
                             ExchangeType = d.ExchangeType,
                             TradeId = d.TradeId,
                             AlreadyWriteOffAmount = d.AlreadyWriteOffAmount
                         };
            return await orders.ToListAsync();
        }
        /// <summary>
        /// 根据交易编号获取订单列表
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        public async Task<List<TikTokOrderDto>> GetOrderListByTradeIdAsync(string tradeId)
        {
            var config = await _wxAppConfigService.GetCallCenterConfig();
            var orders = from d in dalTikTokOrderInfo.GetAll()
                         where d.TradeId == tradeId
                         select new TikTokOrderDto
                         {
                             Id = d.Id,
                             GoodsId = d.GoodsId,
                             GoodsName = d.GoodsName,
                             ThumbPicUrl = d.ThumbPicUrl,
                             Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                             EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                             AppointmentHospital = d.AppointmentHospital,
                             IsAppointment = d.IsAppointment,
                             StatusCode = d.StatusCode,
                             StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                             ActualPayment = d.ActualPayment,
                             CreateDate = d.CreateDate,
                             AppType = d.AppType,
                             AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                             OrderType = d.OrderType,
                             OrderTypeText = d.OrderType != null ? ServiceClass.GetOrderTypeText((byte)d.OrderType) : "",
                             Quantity = d.Quantity,
                             IntegrationQuantity = d.IntegrationQuantity,
                             ExchangeType = d.ExchangeType,
                             TradeId = d.TradeId
                         };
            return await orders.ToListAsync();
        }
        /// <summary>
        /// 根据客户编号获取tiktok订单列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="statusCode"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<OrderTradeForWxDto>> GetOrderListForAllTikTokByCustomerId(string customerId, string statusCode, int pageNum, int pageSize)
        {
            var orders = from d in dalOrderTrade.GetAll()
                          .Include(e => e.TikTokOrderInfoList)
                         where d.CustomerId == customerId
                         && (string.IsNullOrWhiteSpace(statusCode) || d.StatusCode == statusCode)
                         orderby d.CreateDate
                         select new OrderTradeForWxDto
                         {
                             TradeId = d.TradeId,
                             CustomerId = d.CustomerId,
                             CreateDate = d.CreateDate,
                             AddressId = d.AddressId,
                             TotalAmount = d.TotalAmount,
                             TotalIntegration = d.TotalIntegration,
                             Remark = d.Remark,
                             StatusCode = d.StatusCode,
                             StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                             TikTokOrderInfoList = (from o in d.TikTokOrderInfoList
                                              select new TikTokOrderDto
                                              {
                                                  Id = o.Id,
                                                  GoodsName = o.GoodsName,
                                                  GoodsId = o.GoodsId,
                                                  ThumbPicUrl = o.ThumbPicUrl,
                                                  ActualPayment = o.ActualPayment,
                                                  CreateDate = o.CreateDate,
                                                  UpdateDate = o.UpdateDate,
                                                  OrderType = o.OrderType,
                                                  OrderTypeText = ServiceClass.GetOrderTypeText((byte)o.OrderType),
                                                  Quantity = o.Quantity,
                                                  IntegrationQuantity = o.IntegrationQuantity,
                                                  ExchangeType = o.ExchangeType,
                                                  ExchangeTypeText = ServiceClass.GetExchangeTypeText((byte)o.ExchangeType),
                                                  TradeId = o.TradeId,
                                                  AppType = o.AppType,
                                                  AppTypeText = ServiceClass.GetAppTypeText((byte)o.AppType)
                                              }).ToList()
                         };
            FxPageInfo<OrderTradeForWxDto> orderTradePageInfo = new FxPageInfo<OrderTradeForWxDto>();
            orderTradePageInfo.TotalCount = await orders.CountAsync();
            orderTradePageInfo.List = await orders.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return orderTradePageInfo;
        }       

        public async Task<FxPageInfo<TikTokOrderDto>> GetOrderListWithPageAsync(DateTime? startDate, DateTime? endDate, DateTime? writeOffStartDate, DateTime? writeOffEndDate, int? belongEmpId, string keyword, string statusCode, byte? appType, byte? orderNature, int employeeId, int pageNum, int pageSize)
        {
            try
            {
                var orders = from d in dalTikTokOrderInfo.GetAll()
                             where (string.IsNullOrWhiteSpace(keyword) || d.Id.Contains(keyword) || d.GoodsName.Contains(keyword)
                             || d.Phone == keyword || d.AppointmentHospital.Contains(keyword))
                             && (string.IsNullOrWhiteSpace(statusCode) || d.StatusCode == statusCode.Trim())
                             && (appType == null || d.AppType == appType)
                             && (!belongEmpId.HasValue || d.BelongEmpId == belongEmpId)
                             && (orderNature == null || d.OrderNature == orderNature)
                             select d;

                if (startDate != null && endDate != null)
                {
                    DateTime startrq = ((DateTime)startDate);
                    DateTime endrq = ((DateTime)endDate).AddDays(1);
                    orders = from d in orders
                             where d.CreateDate >= startrq && d.CreateDate < endrq
                             select d;
                }
                if (writeOffStartDate != null && writeOffEndDate != null)
                {
                    DateTime startrqWriteOff = ((DateTime)writeOffStartDate);
                    DateTime endrqWriteOff = ((DateTime)writeOffEndDate).AddDays(1);
                    orders = from d in orders
                             where d.WriteOffDate >= startrqWriteOff && d.WriteOffDate < endrqWriteOff
                             select d;
                }
                var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                {
                    orders = from d in orders
                             where dalBindCustomerService.GetAll().Count(e => e.CustomerServiceId == employeeId && e.BuyerPhone == d.Phone) > 0
                             select d;
                }

                var config = await _wxAppConfigService.GetCallCenterConfig();
                var order = from d in orders
                            select new TikTokOrderDto
                            {
                                Id = d.Id,
                                GoodsId = d.GoodsId,
                                GoodsName = d.GoodsName,
                                BuyerNick = d.BuyerNick,
                                BelongEmpId = d.BelongEmpId,
                                ThumbPicUrl = d.ThumbPicUrl,
                                Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                AppointmentHospital = d.AppointmentHospital,
                                IsAppointment = d.IsAppointment,
                                StatusCode = d.StatusCode,
                                StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                                ActualPayment = d.ActualPayment,
                                CreateDate = d.CreateDate,
                                WriteOffDate = d.WriteOffDate,
                                AppType = d.AppType,
                                AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                                OrderType = d.OrderType,
                                Description = d.Description,
                                OrderTypeText = d.OrderType != null ? ServiceClass.GetOrderTypeText((byte)d.OrderType) : "",
                                OrderNature = d.OrderNature,
                                OrderNatureText = d.OrderNature != null ? ServiceClass.GetOrderNatureText((byte)d.OrderNature) : "",
                                Quantity = d.Quantity,
                                IntegrationQuantity = d.IntegrationQuantity,
                                ExchangeType = d.ExchangeType,
                                ExchangeTypeText = ServiceClass.GetExchangeTypeText((byte)d.ExchangeType),
                                TradeId = d.TradeId,
                                FinalConsumptionHospital = d.FinalConsumptionHospital,
                                LiveAnchorId = d.LiveAnchorId,
                            };


                FxPageInfo<TikTokOrderDto> orderPageInfo = new FxPageInfo<TikTokOrderDto>();
                orderPageInfo.TotalCount = await order.CountAsync();
                orderPageInfo.List = await order.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                foreach (var x in orderPageInfo.List)
                {
                    if (x.LiveAnchorId != 0)
                    {
                        var liveanchor = await liveAnchorService.GetByIdAsync(x.LiveAnchorId);
                        x.LiveAnchorName = liveanchor.Name;
                        if (!string.IsNullOrEmpty(liveanchor.ContentPlateFormId))
                        {
                            x.ContentPlatFormId = liveanchor.ContentPlateFormId;
                            var contentplatFormInfo = await contentPlatFormService.GetByIdAsync(liveanchor.ContentPlateFormId);
                            x.LiveAnchorPlatForm = contentplatFormInfo.ContentPlatformName;
                        }
                    }
                    if (x.BelongEmpId != 0)
                    {
                        var customerService = await dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == x.BelongEmpId);
                        x.BelongEmpName = customerService.Name;
                    }
                }
                return orderPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderNatureDto> GetOrderNatureList()
        {
            var orderAppTypes = Enum.GetValues(typeof(OrderNatureType));
            List<OrderNatureDto> orderAppTypeList = new List<OrderNatureDto>();
            foreach (var item in orderAppTypes)
            {
                OrderNatureDto orderAppType = new OrderNatureDto();
                orderAppType.OrderNature = Convert.ToByte(item);
                orderAppType.OrderNatureText = ServiceClass.GetOrderNatureText(Convert.ToByte(item));
                orderAppTypeList.Add(orderAppType);
            }
            return orderAppTypeList;
        }

        public async Task<List<OrderOperationConditionDto>> GetOrderOperationConditionAsync(DateTime? startDate, DateTime? endDate)
        {
            var orders = from d in dalTikTokOrderInfo.GetAll()
                         select d;

            if (startDate != null && endDate != null)
            {
                DateTime startrq = ((DateTime)startDate);
                DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
                orders = from d in orders
                         where d.CreateDate >= startrq && d.CreateDate < endrq
                         select d;
            }
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.CreateDate.Value.Date).Select(x => new OrderOperationConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderNum = x.ToList().Count }).ToList();
        }
        /// <summary>
        /// 获取各订单状态的订单数量
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrderStatusDataDto>> GetOrderStatusDataAsync(int employeeId)
        {
            IQueryable<OrderStatusDataDto> orderStatusData;
            if (employeeId != -1)
            {
                var bindCustomerService = await dalBindCustomerService.GetAll().Where(e => e.CustomerServiceId == employeeId).ToListAsync();
                List<string> phoneList = new List<string>();
                foreach (var item in bindCustomerService)
                {
                    phoneList.Add(item.BuyerPhone);
                }
                orderStatusData = from d in dalTikTokOrderInfo.GetAll()
                                  where phoneList.Contains(d.Phone)
                                  group d by d.StatusCode into g
                                  select new OrderStatusDataDto
                                  {
                                      StatusText = ServiceClass.GetOrderStatusText(g.Key),
                                      Quantity = g.Count()
                                  };
            }
            else
            {
                orderStatusData = from d in dalTikTokOrderInfo.GetAll()
                                  group d by d.StatusCode into g
                                  select new OrderStatusDataDto
                                  {
                                      StatusText = ServiceClass.GetOrderStatusText(g.Key),
                                      Quantity = g.Count()
                                  };
            }


            return await orderStatusData.ToListAsync();
        }
        /// <summary>
        /// 获取时间段内到院订单数
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<OrderOperationConditionDto>> GetOrderToHospitalDataAsync(DateTime startDate, DateTime endDate)
        {
            DateTime startrq = ((DateTime)startDate);
            DateTime endrq = ((DateTime)endDate).Date.AddDays(1);
            var orders = from d in dalTikTokOrderInfo.GetAll()
                         where d.StatusCode == "TRADE_FINISHED" && d.WriteOffDate.Value >= startrq && d.WriteOffDate.Value < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.WriteOffDate.Value.Date).Select(x => new OrderOperationConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderNum = x.ToList().Count }).ToList();
        }

        public async Task<OrderTradeForWxDto> GetOrderTradeByTradeIdAsync(string tradeId)
        {
            var orderTrade = await dalOrderTrade.GetAll().Include(e => e.OrderInfoList).SingleOrDefaultAsync(e => e.TradeId == tradeId);
            if (orderTrade == null)
                throw new Exception("交易编号错误");

            OrderTradeForWxDto orderTradeDto = new OrderTradeForWxDto();
            orderTradeDto.TradeId = orderTrade.TradeId;
            orderTradeDto.CustomerId = orderTrade.CustomerId;
            orderTradeDto.CreateDate = orderTrade.CreateDate;
            orderTradeDto.UpdateDate = orderTrade.UpdateDate;
            orderTradeDto.AddressId = orderTrade.AddressId;
            orderTradeDto.TotalAmount = orderTrade.TotalAmount;
            orderTradeDto.TotalIntegration = orderTrade.TotalIntegration;
            orderTradeDto.Remark = orderTrade.Remark;
            orderTradeDto.StatusCode = orderTrade.StatusCode;
            orderTradeDto.StatusText = ServiceClass.GetOrderStatusText(orderTrade.StatusCode);
            orderTradeDto.TikTokOrderInfoList = (from o in orderTrade.TikTokOrderInfoList
                                           select new TikTokOrderDto
                                           {
                                               Id = o.Id,
                                               GoodsName = o.GoodsName,
                                               GoodsId = o.GoodsId,
                                               ThumbPicUrl = o.ThumbPicUrl,
                                               Phone = o.Phone,
                                               ActualPayment = o.ActualPayment,
                                               CreateDate = o.CreateDate,
                                               UpdateDate = o.UpdateDate,
                                               AppType = o.AppType,
                                               AppTypeText = ServiceClass.GetAppTypeText(o.AppType),
                                               OrderType = o.OrderType,
                                               OrderTypeText = ServiceClass.GetOrderTypeText((byte)o.OrderType),
                                               Quantity = o.Quantity,
                                               IntegrationQuantity = o.IntegrationQuantity,
                                               ExchangeType = o.ExchangeType,
                                               ExchangeTypeText = ServiceClass.GetExchangeTypeText((byte)o.ExchangeType),
                                               TradeId = o.TradeId,
                                           }).ToList();
            return orderTradeDto;
        }

        public async Task<List<OrderWriteOffDto>> GetOrderWriteOffAsync(DateTime? startDate, DateTime? endDate, bool isHidePhone)
        {
            var orders = from d in dalTikTokOrderInfo.GetAll()
                         where d.StatusCode == "TRADE_FINISHED" && d.OrderType == 0
                         select d;

            if (startDate != null && endDate != null)
            {
                DateTime startrqWriteOff = ((DateTime)startDate);
                DateTime endrqWriteOff = ((DateTime)endDate).Date.AddDays(1);
                orders = from d in orders
                         where d.WriteOffDate >= startrqWriteOff && d.WriteOffDate < endrqWriteOff
                         select d;
            }
            var order = from d in orders
                        select new OrderWriteOffDto
                        {
                            Id = d.Id,
                            GoodsName = d.GoodsName,
                            NickName = d.BuyerNick,
                            EncryptPhone = isHidePhone == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                            AppointmentHospital = d.AppointmentHospital,
                            StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                            ActualPayment = d.ActualPayment,
                            AccountReceivable = d.AccountReceivable,
                            CreateDate = d.CreateDate,
                            WriteOffDate = d.WriteOffDate,
                            AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                            Quantity = d.Quantity,
                        };

            List<OrderWriteOffDto> orderPageInfo = new List<OrderWriteOffDto>();
            orderPageInfo = await order.OrderByDescending(e => e.WriteOffDate).ToListAsync();
            foreach (var x in orderPageInfo)
            {
                var sendOrderInfo = await _sendOrderInfoService.GetSendOrderInfoByOrderId(x.Id);
                if (sendOrderInfo.Count != 0)
                {
                    x.SendOrderHospital = sendOrderInfo.First().HospitalName;
                }
            }
            return orderPageInfo;
        }
        /// <summary>
        /// 获取核销好礼接口数据订单
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<OrderInfoSimpleDto>> GetReceiveGiftOrderListByCustomerIdAsync(string customerId, int pageNum, int pageSize)
        {
            var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == customerId);
            List<OrderInfoSimpleDto> orderInfoSimpleResult = new List<OrderInfoSimpleDto>();
            int orderReceiveGiftCount = 0;
            var order = from d in dalTikTokOrderInfo.GetAll().OrderByDescending(x => x.CreateDate)
                        where d.Phone == customer.Phone
                        && d.StatusCode == OrderStatusCode.TRADE_FINISHED
                        && d.ActualPayment > 0
                        select new OrderInfo
                        {
                            Id = d.Id,
                            ThumbPicUrl = d.ThumbPicUrl,
                            GoodsName = d.GoodsName,
                            ActualPayment = d.ActualPayment,
                            ReceiveGift = d.ReceiveGift,
                            AppType = d.AppType
                        };
            var result = from d in order
                         where d.ReceiveGift.OrderId != d.Id
                         select new OrderInfoSimpleDto
                         {
                             Id = d.Id,
                             ThumbPicUrl = d.ThumbPicUrl,
                             GoodsName = d.GoodsName,
                             ActualPayment = d.ActualPayment,
                             appType = d.AppType
                         };
            orderInfoSimpleResult = await result.ToListAsync();
            orderReceiveGiftCount = await dalReceiveGift.GetAll().CountAsync(e => e.CustomerId == customerId && e.OrderId == null);
            int count = orderInfoSimpleResult.Count() - orderReceiveGiftCount;
            var resultList = orderInfoSimpleResult.Take(count < 0 ? 0 : count).OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            FxPageInfo<OrderInfoSimpleDto> writeOffOrderInfo = new FxPageInfo<OrderInfoSimpleDto>();
            writeOffOrderInfo.TotalCount = count;
            foreach (var x in resultList)
            {
                var sendOrderInfo = await _sendOrderInfoService.GetSendOrderInfoByOrderId(x.Id);
                if (sendOrderInfo.Count != 0)
                {
                    x.AppointmentHospital = sendOrderInfo.First().HospitalName;
                }
            }
            writeOffOrderInfo.List = resultList;
            return writeOffOrderInfo;
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
            var orders = from d in dalTikTokOrderInfo.GetAll()
                         where d.IsReturnBackPrice == true && d.ReturnBackDate.Value >= startrq && d.ReturnBackDate.Value < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.ReturnBackDate.Value.Date).Select(x => new OrderPriceConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderPrice = x.Sum(z => z.ReturnBackPrice.Value) }).ToList();
        }

        public async Task<List<TikTokOrderDto>> GetTikTokOrderListAsync(DateTime? startDate, DateTime? endDate, string statusCode, int employeeId, bool isHidePhone)
        {
            try
            {
                var orders = from d in dalTikTokOrderInfo.GetAll()
                             where (string.IsNullOrWhiteSpace(statusCode) || d.StatusCode == statusCode.Trim())
                             select d;

                if (startDate != null && endDate != null)
                {
                    DateTime startrq = ((DateTime)startDate);
                    DateTime endrq = ((DateTime)endDate).AddDays(1);
                    orders = from d in orders
                             where d.CreateDate >= startrq && d.CreateDate < endrq
                             select d;
                }
                var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                {
                    orders = from d in orders
                             where dalBindCustomerService.GetAll().Count(e => e.CustomerServiceId == employeeId && e.BuyerPhone == d.Phone) > 0
                             select d;
                }

                var order = from d in orders
                            select new TikTokOrderDto
                            {
                                Id = d.Id,
                                GoodsId = d.GoodsId,
                                GoodsName = d.GoodsName,
                                BuyerNick = d.BuyerNick,
                                BelongEmpId = d.BelongEmpId,
                                ThumbPicUrl = d.ThumbPicUrl,
                                Phone = isHidePhone == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                AppointmentHospital = d.AppointmentHospital,
                                IsAppointment = d.IsAppointment,
                                StatusCode = d.StatusCode,
                                StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                                ActualPayment = d.ActualPayment,
                                CreateDate = d.CreateDate,
                                AccountReceivable = d.AccountReceivable,
                                WriteOffDate = d.WriteOffDate,
                                AppType = d.AppType,
                                AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                                OrderType = d.OrderType,
                                OrderTypeText = d.OrderType != null ? ServiceClass.GetOrderTypeText((byte)d.OrderType) : "",
                                OrderNature = d.OrderNature,
                                OrderNatureText = d.OrderNature != null ? ServiceClass.GetOrderNatureText((byte)d.OrderNature) : "",
                                Quantity = d.Quantity,
                                IntegrationQuantity = d.IntegrationQuantity,
                                ExchangeType = d.ExchangeType,
                                ExchangeTypeText = ServiceClass.GetExchangeTypeText((byte)d.ExchangeType),
                                TradeId = d.TradeId,
                                FinalConsumptionHospital = d.FinalConsumptionHospital,
                                LiveAnchorId = d.LiveAnchorId,
                            };


                List<TikTokOrderDto> orderInfo = new List<TikTokOrderDto>();
                orderInfo = await order.OrderByDescending(e => e.CreateDate).ToListAsync();
                foreach (var x in orderInfo)
                {
                    if (x.LiveAnchorId != 0)
                    {
                        var liveanchor = await liveAnchorService.GetByIdAsync(x.LiveAnchorId);
                        x.LiveAnchorName = liveanchor.Name;
                        if (!string.IsNullOrEmpty(liveanchor.ContentPlateFormId))
                        {
                            x.ContentPlatFormId = liveanchor.ContentPlateFormId;
                            var contentplatFormInfo = await contentPlatFormService.GetByIdAsync(liveanchor.ContentPlateFormId);
                            x.LiveAnchorPlatForm = contentplatFormInfo.ContentPlatformName;
                        }
                    }
                    if (x.BelongEmpId != 0)
                    {
                        var customerService = await dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == x.BelongEmpId);
                        x.BelongEmpName = customerService.Name;
                    }
                }
                return orderInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取今日关闭订单数量
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTodayClosedQuantityAsync()
        {
            DateTime date = DateTime.Now;
            var order = from d in dalTikTokOrderInfo.GetAll()
                        where ((DateTime)d.UpdateDate).Date == date.Date
                        && (d.StatusCode == "TRADE_CLOSED_BY_TAOBAO" || d.StatusCode == "TRADE_CLOSED")
                        select d;
            int quantity = await order.CountAsync();
            return quantity;
        }
        /// <summary>
        /// 获取今天新增订单
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<TikTokOrderDto>> GetTodayIncrementListAsync(int pageNum, int pageSize)
        {
            DateTime date = DateTime.Now;
            var orders = from d in dalTikTokOrderInfo.GetAll()
                         select d;


            var config = await _wxAppConfigService.GetCallCenterConfig();
            var order = from d in orders
                        where ((DateTime)d.CreateDate).Date == date.Date
                        select new TikTokOrderDto
                        {
                            Id = d.Id,
                            GoodsId = d.GoodsId,
                            GoodsName = d.GoodsName,
                            ThumbPicUrl = d.ThumbPicUrl,
                            Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                            EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                            AppointmentHospital = d.AppointmentHospital,
                            IsAppointment = d.IsAppointment,
                            StatusCode = d.StatusCode,
                            StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                            ActualPayment = d.ActualPayment,
                            CreateDate = d.CreateDate,
                            UpdateDate = d.UpdateDate,
                            AppType = d.AppType,
                            AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                            Quantity = d.Quantity,
                            IntegrationQuantity = d.IntegrationQuantity,
                            ExchangeType = d.ExchangeType,
                            ExchangeTypeText = ServiceClass.GetExchangeTypeText((byte)d.ExchangeType),
                            TradeId = d.TradeId,

                        };

            FxPageInfo<TikTokOrderDto> orderPageInfo = new FxPageInfo<TikTokOrderDto>();
            orderPageInfo.TotalCount = await order.CountAsync();
            orderPageInfo.List = await order.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return orderPageInfo;
        }
        /// <summary>
        /// 获取今日新增订单数量
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTodayIncrementQuantityAsync(int employeeId)
        {
            DateTime date = DateTime.Now;
            var order = from d in dalTikTokOrderInfo.GetAll()
                        where ((DateTime)d.CreateDate).Date == date.Date
                        select d;
            if (employeeId != -1)
            {
                var bindCustomerService = await dalBindCustomerService.GetAll().Where(e => e.CustomerServiceId == employeeId).ToListAsync();
                List<string> phoneList = new List<string>();
                foreach (var item in bindCustomerService)
                {
                    phoneList.Add(item.BuyerPhone);
                }
                order = from d in order
                        where phoneList.Contains(d.Phone)
                        select d;
            }
            int quantity = await order.CountAsync();
            return quantity;
        }
        /// <summary>
        /// 获取今日新增订单数
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTodayIncrementQuantityAsync()
        {
            DateTime date = DateTime.Now;
            var order = from d in dalTikTokOrderInfo.GetAll()
                        where ((DateTime)d.CreateDate).Date == date.Date
                        select d;
            int quantity = await order.CountAsync();
            var contentPlatFormOrder = from c in _dalContentPlatFormOrder.GetAll()
                                       where ((DateTime)c.CreateDate).Date == date.Date
                                       select c;
            quantity += await contentPlatFormOrder.CountAsync();
            return quantity;
        }
        /// <summary>
        /// 获取今日录单订单数量
        /// </summary>
        /// <returns></returns>
        public async Task<List<TodayOrderAddDto>> GetTodayOrderAddAsync()
        {
            DateTime date = DateTime.Now;
            var order = from d in _dalContentPlatFormOrder.GetAll()
                        where ((DateTime)d.CreateDate).Date == date.Date
                        select d;
            var orderResult = from d in order
                              select new TodayOrderAddDto
                              {
                                  OrderId = d.Id,
                                  CustomerName = d.CustomerName,
                                  ProjectName = d.AmiyaGoodsDemand.ProjectNname,
                                  OrderType = ServiceClass.GetContentPlateFormOrderTypeText((byte)d.OrderType),
                              };
            return orderResult.ToList();
        }

        public async Task<string> GetTodayOrderCount()
        {
            try
            {
                var date = DateTime.Today;
                var model = from d in dalTikTokOrderInfo.GetAll() where (d.CreateDate >= date && d.CreateDate < date.AddDays(1)) select d;
                return model.CountAsync().Result.ToString();
            }
            catch (Exception e)
            {
                return "0";
            }
        }
        /// <summary>
        /// 获取今日订单状态发生改变的订单列表
        /// </summary>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<TikTokOrderDto>> GetTodayStatusChangeListAsync(int employeeId, string keyword, string statusCode, int pageNum, int pageSize)
        {
            DateTime date = DateTime.Now;
            var orders = from d in dalTikTokOrderInfo.GetAll()
                         where ((DateTime)d.UpdateDate).Date == date.Date && ((DateTime)d.CreateDate).Date != date.Date
                         && (string.IsNullOrWhiteSpace(keyword) || d.GoodsName.Contains(keyword) || d.Id.Contains(keyword) ||
                         d.Phone == keyword || d.AppointmentHospital.Contains(keyword))
                         && (string.IsNullOrWhiteSpace(statusCode) || d.StatusCode == statusCode)
                         select d;

            if (employeeId != -1)
            {
                var bindCustomerService = await dalBindCustomerService.GetAll().Where(e => e.CustomerServiceId == employeeId).ToListAsync();
                List<string> phoneList = new List<string>();
                foreach (var item in bindCustomerService)
                {
                    phoneList.Add(item.BuyerPhone);
                }
                orders = from d in orders
                         where phoneList.Contains(d.Phone)
                         select d;
            }

            var config = await _wxAppConfigService.GetCallCenterConfig();
            var orderInfo = from d in orders

                            select new TikTokOrderDto
                            {
                                Id = d.Id,
                                GoodsId = d.GoodsId,
                                GoodsName = d.GoodsName,
                                ThumbPicUrl = d.ThumbPicUrl,
                                Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                AppointmentHospital = d.AppointmentHospital,
                                IsAppointment = d.IsAppointment,
                                StatusCode = d.StatusCode,
                                StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                                ActualPayment = d.ActualPayment,
                                CreateDate = d.CreateDate,
                                UpdateDate = d.UpdateDate,
                                AppType = d.AppType,
                                AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                                Quantity = d.Quantity,
                                IntegrationQuantity = d.IntegrationQuantity,
                                ExchangeType = d.ExchangeType,
                                ExchangeTypeText = ServiceClass.GetExchangeTypeText((byte)d.ExchangeType),
                                TradeId = d.TradeId,
                            };

            FxPageInfo<TikTokOrderDto> orderPageInfo = new FxPageInfo<TikTokOrderDto>();
            orderPageInfo.TotalCount = await orderInfo.CountAsync();
            orderPageInfo.List = await orderInfo.OrderByDescending(e => e.UpdateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return orderPageInfo;
        }
        /// <summary>
        /// 获取今日核销订单数量
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTodayWriteOffQuantityAsync()
        {
            DateTime date = DateTime.Now;
            var order = from d in dalTikTokOrderInfo.GetAll()
                        where ((DateTime)d.WriteOffDate).Date == date.Date
                        select d;
            int quantity = await order.CountAsync();
            var contentPlatFormOrder = from c in _dalContentPlatFormOrder.GetAll()
                                       where ((DateTime)c.UpdateDate).Date == date.Date
                                       && c.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete
                                       select c;
            quantity += await contentPlatFormOrder.CountAsync();
            return quantity;
        }
        /// <summary>
        /// 获取总订单数量
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTotalOrderQuantityAsync(int employeeId)
        {
            var order = from d in dalTikTokOrderInfo.GetAll()
                        select d;

            if (employeeId != -1)
            {
                var bindCustomerService = await dalBindCustomerService.GetAll().Where(e => e.CustomerServiceId == employeeId).ToListAsync();
                List<string> phoneList = new List<string>();
                foreach (var item in bindCustomerService)
                {
                    phoneList.Add(item.BuyerPhone);
                }
                order = from d in order
                        where phoneList.Contains(d.Phone)
                        select d;
            }

            int quantity = await order.CountAsync();
            return quantity;
        }

        public async Task<decimal> GetTradeFinishAmountByPhoneAsync(string phone)
        {
            var amount = await dalTikTokOrderInfo.GetAll().Where(e => e.Phone == phone && e.StatusCode == OrderStatusCode.TRADE_FINISHED).SumAsync(e => e.ActualPayment);
            return (decimal)amount;
        }
        /// <summary>
        /// 根据客户编号获取已核销订单
        /// </summary>
        /// <returns></returns>
        public async Task<List<CustomerOrderDto>> GetTradeFinishOrderListByCustomerIdAsync(string customerId)
        {
            var orders = from d in dalTikTokOrderInfo.GetAll()
                         join c in dalCustomerInfo.GetAll() on d.Phone equals c.Phone
                         where d.ActualPayment >= 1 && d.StatusCode == OrderStatusCode.TRADE_FINISHED && c.Id == customerId
                         select new CustomerOrderDto
                         {
                             Id = d.Id,
                             Phone = d.Phone,
                             ActualPayment = (decimal)d.ActualPayment,
                             CustomerId = c.Id
                         };
            return await orders.ToListAsync();
        }

        public async Task<FxPageInfo<TikTokOrderDto>> GetUnBindCustomerServiceOrderListAsync(string status, string keyword, decimal? minPayment, decimal? maxPayment, byte? appType, int pageNum, int pageSize)
        {
            var order = await dalTikTokOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == keyword);
            if (order != null)
            {
                if (string.IsNullOrWhiteSpace(order.Phone))
                    throw new Exception("该订单没有手机号，不能绑定客服");
                keyword = order.Phone;
            }


            var bind = await dalBindCustomerService.GetAll()
               .Include(e => e.CustomerServiceAmiyaEmployee)
               .SingleOrDefaultAsync(e => e.BuyerPhone == keyword);

            if (bind != null)
                throw new Exception("该客户已绑定给" + bind.CustomerServiceAmiyaEmployee.Name);



            List<string> phoneList = new List<string>();
            var bindCustomerServices = await dalBindCustomerService.GetAll().ToListAsync();
            foreach (var item in bindCustomerServices)
            {
                phoneList.Add(item.BuyerPhone);
            }

            var q = from d in dalTikTokOrderInfo.GetAll()
                    where (string.IsNullOrWhiteSpace(status) || d.StatusCode == status.Trim())
                    && string.IsNullOrWhiteSpace(d.Phone) == false
                    && phoneList.Contains(d.Phone) == false
                    && (keyword == null || d.Id == keyword || d.GoodsName.Contains(keyword) || d.Phone == keyword)
                    && (appType == null || d.AppType == appType)
                    select d;


            if (minPayment != null && maxPayment != null)
            {
                q = from d in q
                    where d.ActualPayment >= minPayment && d.ActualPayment <= maxPayment
                    select d;
            }

            var config = await _wxAppConfigService.GetCallCenterConfig();
            var orders = from d in q
                         select new TikTokOrderDto
                         {
                             Id = d.Id,
                             GoodsId = d.GoodsId,
                             GoodsName = d.GoodsName,
                             Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                             EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                             AppointmentHospital = d.AppointmentHospital,
                             IsAppointment = d.IsAppointment,
                             StatusCode = d.StatusCode,
                             StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                             ActualPayment = d.ActualPayment,
                             CreateDate = d.CreateDate,
                             ThumbPicUrl = d.ThumbPicUrl,
                             AppType = d.AppType,
                             AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                             Quantity = d.Quantity,
                             IntegrationQuantity = d.IntegrationQuantity,
                             ExchangeType = d.ExchangeType,
                             ExchangeTypeText = ServiceClass.GetExchangeTypeText((byte)d.ExchangeType),
                             TradeId = d.TradeId,
                         };

            FxPageInfo<TikTokOrderDto> orderPageInfo = new FxPageInfo<TikTokOrderDto>();
            orderPageInfo.TotalCount = await orders.CountAsync();
            orderPageInfo.List = await orders.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return orderPageInfo;
        }
        /// <summary>
        /// 获取未绑定客服订单数量
        /// </summary>
        /// <returns></returns>
        public async Task<int?> GetUnBindOrderQuantityAsync(int employeeId)
        {
            if (employeeId != -1)
            {
                var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee.IsCustomerService && employee.AmiyaPositionInfo.IsDirector == false)
                {
                    return null;
                }
            }

            List<string> phoneList = new List<string>();
            var bindCustomerServices = await dalBindCustomerService.GetAll().ToListAsync();
            foreach (var item in bindCustomerServices)
            {
                phoneList.Add(item.BuyerPhone);
            }

            var quantity = await dalTikTokOrderInfo.GetAll().CountAsync(e => phoneList.Contains(e.Phone) == false);
            return quantity;
        }
        /// <summary>
        /// 根据客户编号获取未领取礼品的订单列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<List<OrderInfoSimpleDto>> GetUnReceiveGiftOrderListByCustomerIdAsync(string customerId)
        {
            var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == customerId);

            var order = from d in dalTikTokOrderInfo.GetAll()
                        where d.Phone == customer.Phone
                        && d.StatusCode == OrderStatusCode.TRADE_FINISHED
                        && d.ReceiveGift.OrderId != d.Id
                        && d.ActualPayment > 1
                        select new OrderInfoSimpleDto
                        {
                            Id = d.Id,
                            ThumbPicUrl = d.ThumbPicUrl,
                            GoodsName = d.GoodsName,
                            ActualPayment = d.ActualPayment
                        };

            var unBindOrderReceiveGiftCount = await dalReceiveGift.GetAll().CountAsync(e => e.CustomerId == customerId && e.OrderId == null);
            int count = await order.CountAsync() - unBindOrderReceiveGiftCount;
            return await order.Take(count < 0 ? 0 : count).ToListAsync();
        }
        /// <summary>
        /// 获取未派单订单数量
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetUnSendOrderQuantityAsync(int employeeId)
        {
            var order = from d in dalTikTokOrderInfo.GetAll()
                        where d.SendOrderInfoList.Count() == 0
                        select d;
            if (employeeId != -1)
            {
                var bindCustomerService = await dalBindCustomerService.GetAll().Where(e => e.CustomerServiceId == employeeId).ToListAsync();
                List<string> phoneList = new List<string>();
                foreach (var item in bindCustomerService)
                {
                    phoneList.Add(item.BuyerPhone);
                }
                order = from d in order
                        where phoneList.Contains(d.Phone)
                        select d;
            }
            var quantity = await order.CountAsync();
            return quantity;
        }

        public Task<bool> IsExistPhoneAsync(string phone)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 订单回款
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task ReturnBackOrderAsync(ReturnBackOrderDto input)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var order = await dalTikTokOrderInfo.GetAll().Where(x => x.Id == input.OrderId).SingleOrDefaultAsync();
                if (order == null)
                {
                    throw new Exception("未找到该订单的相关信息！");
                }
                order.IsReturnBackPrice = true;
                order.ReturnBackPrice = input.ReturnBackPrice;
                order.ReturnBackDate = input.ReturnBackDate;
                await dalTikTokOrderInfo.UpdateAsync(order, true);

                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
            }
        }
        /// <summary>
        /// 发货
        /// </summary>
        /// <param name="sendGoodsDto"></param>
        /// <returns></returns>
        public async Task SendGoodsAsync(SendGoodsDto sendGoodsDto)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var orderTrade = await dalOrderTrade.GetAll().Include(e => e.TikTokOrderInfoList).SingleOrDefaultAsync(e => e.TradeId == sendGoodsDto.TradeId);
                if (orderTrade == null)
                    throw new Exception("交易编号错误");

                var sendGoodsRecord = await dalSendGoodsRecord.GetAll().SingleOrDefaultAsync(e => e.TradeId == sendGoodsDto.TradeId);
                if (sendGoodsRecord != null)
                    throw new Exception("该交易已发货，请勿重复操作");

                DateTime date = DateTime.Now;
                foreach (var item in orderTrade.TikTokOrderInfoList)
                {
                    item.StatusCode = OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS;
                    item.UpdateDate = date;
                    await dalTikTokOrderInfo.UpdateAsync(item, true);
                }
                orderTrade.StatusCode = OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS;
                orderTrade.UpdateDate = date;
                await dalOrderTrade.UpdateAsync(orderTrade, true);

                SendGoodsRecord model = new SendGoodsRecord();
                model.TradeId = sendGoodsDto.TradeId;
                model.Date = date;
                model.HandleBy = sendGoodsDto.HandleBy;
                model.CourierNumber = sendGoodsDto.CourierNumber;
                model.ExpressId = sendGoodsDto.ExpressId;
                await dalSendGoodsRecord.AddAsync(model, true);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
        /// <summary>
        /// 获取超时未支付阿美雅订单列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrderInfoSimpleDto>> TimeOutOrderAsync()
        {
            DateTime date = DateTime.Now;


            var orders = from d in dalTikTokOrderInfo.GetAll()
                         where d.StatusCode == OrderStatusCode.WAIT_BUYER_PAY
                         && d.AppType == (byte)AppType.MiniProgram
                         && (DateTime)d.CreateDate < date.AddHours(-1)
                         select new OrderInfoSimpleDto
                         {
                             Id = d.Id,
                             ThumbPicUrl = d.ThumbPicUrl,
                             GoodsId = d.GoodsId,
                             GoodsName = d.GoodsName,
                             ActualPayment = d.ActualPayment.Value,
                             Phone = d.Phone,
                             Quantity = d.Quantity.Value
                         };

            return await orders.ToListAsync();
        }
        /// <summary>
        /// 修改录单订单
        /// </summary>
        /// <param name="updateListDto"></param>
        /// <returns></returns>
        public async Task UpdateAddedOrderAsync(TikTokOrderInfoUpdateDto updateDto)
        {
            try
            {
                var orderInfo = await dalTikTokOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                orderInfo.GoodsName = updateDto.GoodsName;
                orderInfo.GoodsId = updateDto.GoodsId;
                orderInfo.Phone = updateDto.Phone;
                orderInfo.AppointmentHospital = updateDto.AppointmentHospital;
                orderInfo.StatusCode = updateDto.StatusCode;
                orderInfo.ActualPayment = updateDto.ActualPayment;
                orderInfo.CreateDate = DateTime.Now;
                orderInfo.ThumbPicUrl = _amiyaGoodsDemandService.GetByIdAsync(updateDto.GoodsId).Result.ThumbPictureUrl.ToString();
                orderInfo.BuyerNick = updateDto.BuyerNick;
                orderInfo.AppType = updateDto.AppType;
                orderInfo.BuyerNick = updateDto.BuyerNick;
                orderInfo.Description = updateDto.Description;
                orderInfo.IsAppointment = updateDto.IsAppointment;
                orderInfo.OrderType = updateDto.OrderType;
                orderInfo.OrderNature = (updateDto.OrderNature.HasValue) ? updateDto.OrderNature.Value : (byte)0;
                orderInfo.Quantity = (updateDto.Quantity.HasValue) ? updateDto.Quantity : 0;
                orderInfo.IntegrationQuantity = 0;
                orderInfo.ExchangeType = updateDto.ExchangeType;
                await dalTikTokOrderInfo.UpdateAsync(orderInfo, true);

            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }

        public async Task UpdateAsync(List<UpdateTikTokOrderDto> updateListDto)
        {
            try
            {
                var emailConfig = true;
                //订单号集合
                string orderId = "";
                string phone = "";
                string goodsName = "";
                byte appType = 0;
                decimal intergration_quantity = 0M;
                unitOfWork.BeginTransaction();
                DateTime date = DateTime.Now;
                List<OrderTradeForWxDto> tradeList = new List<OrderTradeForWxDto>();
                foreach (var item in updateListDto)
                {
                    appType = item.AppType.Value;
                    if (item.IntergrationQuantity.HasValue)
                        intergration_quantity = item.IntergrationQuantity.Value;
                    var orderInfo = await dalTikTokOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == item.OrderId);
                    if (orderInfo != null)
                    {
                        orderInfo.StatusCode = item.StatusCode;
                        orderInfo.WriteOffCode = item.WriteOffCode;
                        if (orderInfo.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS)
                        {
                            orderId += orderInfo.Id + ",";
                            goodsName += orderInfo.GoodsName + ",";
                            phone = orderInfo.Phone;
                            //组织邮件信息
                            if (emailConfig == true)
                            {
                                BuildSendMailInfo(appType, orderInfo.Id, intergration_quantity, goodsName, orderInfo.Phone);
                            }
                        }
                        if (orderInfo.OrderType == 0 && item.StatusCode == OrderStatusCode.TRADE_FINISHED)
                        {
                            orderInfo.WriteOffDate = orderInfo.UpdateDate;
                        }
                        if (item.AppType == (byte)AppType.MiniProgram)
                        {
                            orderInfo.UpdateDate = orderInfo.UpdateDate;
                            if (!tradeList.Exists(e => e.TradeId == orderInfo.TradeId))
                            {
                                OrderTradeForWxDto orderTradeDto = new OrderTradeForWxDto();
                                orderTradeDto.TradeId = orderInfo.TradeId;
                                orderTradeDto.StatusCode = item.StatusCode;
                                tradeList.Add(orderTradeDto);
                            }
                            await dalTikTokOrderInfo.UpdateAsync(orderInfo, true);
                        }

                        if (!string.IsNullOrWhiteSpace(item.AppointmentHospital))
                            orderInfo.AppointmentHospital = item.AppointmentHospital;
                        await dalTikTokOrderInfo.UpdateAsync(orderInfo, true);

                    }
                }

                foreach (var item in tradeList)
                {
                    var orderTrade = await dalOrderTrade.GetAll().SingleOrDefaultAsync(e => e.TradeId == item.TradeId);
                    orderTrade.StatusCode = item.StatusCode;
                    orderTrade.UpdateDate = date;
                    await dalOrderTrade.UpdateAsync(orderTrade, true);
                }

                unitOfWork.Commit();
                //发送短信通知(todo;)
                if (!string.IsNullOrEmpty(orderId))
                {
                    if (appType == (byte)AppType.MiniProgram && intergration_quantity > 0)
                    {
                        string templateName = "order_intergrationpay_commit";
                        orderId = orderId.ToString().Trim(',');
                        await _smsSender.SendSingleAsync(phone, templateName, JsonConvert.SerializeObject(new { intergration = intergration_quantity.ToString("0").ToString().Trim(',') }));
                    }
                    else
                    {
                        string templateName = "order_buyerpay_commit";
                        orderId = orderId.ToString().Trim(',');
                        await _smsSender.SendSingleAsync(phone, templateName, JsonConvert.SerializeObject(new { orderId = orderId.ToString().Trim(',') }));
                    }
                }
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
        /// <summary>
        /// 发送邮箱方法
        /// </summary>
        /// <param name="appType"></param>
        /// <param name="orderId"></param>
        /// <param name="intergrationQuantity"></param>
        /// <param name="goodsName"></param>
        /// <param name="Phone"></param>
        private void BuildSendMailInfo(byte appType, string orderId, decimal intergrationQuantity, string goodsName, string Phone)
        {
            SendMails sendMails = new SendMails();
            var sub = "有新顾客在“" + ServiceClass.GetAppTypeText(appType) + "”下单啦，订单号为：" + orderId + "，请及时跟进哦！";
            if (appType == (byte)AppType.MiniProgram && intergrationQuantity > 0)
            {
                sub = "有新的顾客在“积分兑换”中兑换了礼品“" + goodsName + "”，请及时跟进哦！";
            }
            //向管理员发送邮箱通知
            var bindCustomerInfos = from z in dalBindCustomerService.GetAll()
                                    where z.BuyerPhone == Phone
                                    select z;
            var bindCustmerInfo = bindCustomerInfos.FirstOrDefault();
            var empInfos = from k in dalAmiyaEmployee.GetAll()
                           select k;
            if (bindCustmerInfo != null)
            {
                var empId = bindCustmerInfo.CustomerServiceId;
                var empInfoRes = from m in empInfos
                                 where m.Id == empId
                                 select m;
                var empInfo = empInfoRes.FirstOrDefault();
                if (empInfo != null)
                {
                    var email = empInfo.Email;
                    if (email == "0" || string.IsNullOrEmpty(email))
                    {
                        var employee = empInfos.Include(e => e.AmiyaPositionInfo).Where(e => e.AmiyaPositionInfo.Name == "客服主管" && e.Valid == true).ToListAsync();
                        foreach (var x in employee.Result)
                        {
                            email = x.Email;
                            if (email == "0" || string.IsNullOrEmpty(email))
                                continue;
                            sendMails.sendMail("smtp.qq.com", "3023330386@qq.com", "kivbmbikthsmdejf", "阿美雅", "3023330386@qq.com", email, "客户下单提示", sub);
                        }
                    }
                    else
                    {
                        sendMails.sendMail("smtp.qq.com", "3023330386@qq.com", "kivbmbikthsmdejf", "阿美雅", "3023330386@qq.com", email, "客户下单提示", sub);
                    }
                }
            }
            else
            {
                var employee = empInfos.Include(e => e.AmiyaPositionInfo).Where(e => e.AmiyaPositionInfo.Name == "客服主管" && e.Valid == true).ToListAsync();
                foreach (var x in employee.Result)
                {
                    var email = x.Email;
                    if (email == "0" || string.IsNullOrEmpty(email))
                        continue;
                    sendMails.sendMail("smtp.qq.com", "3023330386@qq.com", "kivbmbikthsmdejf", "阿美雅", "3023330386@qq.com", email, "客户下单提示", sub);
                }
            }
        }
        /// <summary>
        /// 修改订单所属客服
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateOrderBelongEmpIdAsync(UpdateBelongEmpInfoOrderDto input)
        {
            try
            {
                unitOfWork.BeginTransaction();
                foreach (var x in input.OrderId)
                {
                    var orderInfo = await dalTikTokOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == x);
                    if (orderInfo == null)
                    { throw new Exception("未找到该订单，归属客服失败！"); }
                    orderInfo.BelongEmpId = input.BelongEmpId;
                    await dalTikTokOrderInfo.UpdateAsync(orderInfo, true);
                }
                unitOfWork.Commit();
            }
            catch (Exception e)
            {
                unitOfWork.RollBack();
                throw e;
            }
        }

        public async Task UpdateOrderFinalConsumptionHospital(string orderId, int hospitalId)
        {
            var orderInfo = await dalTikTokOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == orderId);
            if (orderInfo == null)
            {
                throw new Exception("未找到相关订单！");
            }
            if (orderInfo.StatusCode != OrderStatusCode.TRADE_FINISHED)
            {
                throw new Exception("该订单未完成，无法修改最终消费医院！");
            }
            //修改订单信息
            var hospitalInfo = _hospitalInfoService.GetBaseByIdAsync(hospitalId);
            orderInfo.FinalConsumptionHospital = hospitalInfo.Result.Name.ToString();
            await dalTikTokOrderInfo.UpdateAsync(orderInfo, true);
        }
        /// <summary>
        /// 修改订单归属主播
        /// </summary>
        /// <param name="updateListDto"></param>
        /// <returns></returns>
        public async Task UpdateOrderLiveAnchorAsync(UpdateLiveAnchorOrderDto dto)
        {
            try
            {
                unitOfWork.BeginTransaction();
                foreach (var x in dto.OrderId)
                {
                    var orderInfo = await dalTikTokOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == x);
                    if (orderInfo == null)
                    { throw new Exception("未找到该订单，归属主播失败！"); }
                    orderInfo.LiveAnchorId = dto.LiveAnchorId;
                    await dalTikTokOrderInfo.UpdateAsync(orderInfo, true);
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
        /// 订单校对
        /// </summary>
        /// <param name="updateListDto"></param>
        /// <returns></returns>
        public async Task UpdateOrderStatusAsync(string OrderId, string OrderStatus, decimal? ActuralPayment, decimal? AccountReceivable, DateTime? UpdateTime, DateTime? WriteOffDate)
        {
            var orderInfo = await dalTikTokOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == OrderId);
            if (orderInfo == null)
            { throw new Exception("未找到该订单，校对失败！"); }
            orderInfo.StatusCode = OrderStatus;
            orderInfo.OrderType = 0;
            if (ActuralPayment.HasValue)
            {
                orderInfo.ActualPayment = ActuralPayment;
            }
            if (AccountReceivable.HasValue)
            {
                orderInfo.AccountReceivable = AccountReceivable;
            }
            if (UpdateTime.HasValue)
            {
                orderInfo.UpdateDate = UpdateTime;
            }
            if (OrderStatus == "TRADE_FINISHED")
            {
                orderInfo.WriteOffDate = WriteOffDate;
            }
            await dalTikTokOrderInfo.UpdateAsync(orderInfo, true);
            //退款扣除积分
            if (OrderStatus == "TRADE_CLOSED" || OrderStatus == "TRADE_CLOSED_BY_TAOBAO")
            {
                var customerId = await customerService.GetCustomerIdByPhoneAsync(orderInfo.Phone);
                var memberCard = await memberCardService.GetMemberCardHandelByCustomerIdAsync(customerId);
                var intergrationQuantity = 0M;
                if (memberCard != null)
                {
                    intergrationQuantity = Math.Floor(memberCard.GenerateIntegrationPercent * (decimal)orderInfo.ActualPayment);
                }
                else
                {
                    var memberRank = await memberRankInfoService.GetMinGeneratePercentMemberRankInfoAsync();
                    intergrationQuantity = Math.Floor(memberRank.GenerateIntegrationPercent * (decimal)orderInfo.ActualPayment);
                }

                UseIntegrationDto useIntegrationDto = new UseIntegrationDto();
                useIntegrationDto.CustomerId = customerId;
                useIntegrationDto.OrderId = orderInfo.Id;
                useIntegrationDto.Date = DateTime.Now;
                useIntegrationDto.UseQuantity = intergrationQuantity;
                await integrationAccountService.UseByGoodsConsumption(useIntegrationDto);
            }
        }
        /// <summary>
        /// 修改交易信息
        /// </summary>
        /// <param name="updateOrderTrade"></param>
        /// <returns></returns>
        public async Task UpdateOrderTradeAsync(UpdateOrderTradeDto updateOrderTrade)
        {
            var orderTrade = await dalOrderTrade.GetAll().SingleOrDefaultAsync(e => e.TradeId == updateOrderTrade.TradeId);
            if (orderTrade == null)
                throw new Exception("交易编号错误");
            orderTrade.StatusCode = updateOrderTrade.StatusCode;
            orderTrade.UpdateDate = DateTime.Now;
            orderTrade.AddressId = updateOrderTrade.AddressId;
            await dalOrderTrade.UpdateAsync(orderTrade, true);
        }

        public Task UpdateRefundOfJdAsync(string id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 订单核销
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task WriteOffAsync(string orderId, int hospitalId)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var orderInfo = await dalTikTokOrderInfo.GetAll().FirstOrDefaultAsync(e => e.Id == orderId);
                if (orderInfo == null)
                {
                    throw new Exception("未找到相关订单！");
                }
                //验证订单是否派单
                var sendOrderInfoList = await _sendOrderInfoService.GetSendOrderInfoByOrderId(orderId);
                if (sendOrderInfoList.Count == 0)
                {
                    throw new Exception("该订单未派单，无法核销！");
                }
                if (orderInfo.StatusCode == OrderStatusCode.TRADE_FINISHED)
                {
                    throw new Exception("该订单已完成，无需核销！");
                }
                //修改订单信息
                orderInfo.AlreadyWriteOffAmount += 1;
                if (orderInfo.AlreadyWriteOffAmount == orderInfo.Quantity)
                {
                    orderInfo.StatusCode = OrderStatusCode.TRADE_FINISHED;
                    var hospitalInfo = _hospitalInfoService.GetBaseByIdAsync(hospitalId);
                    orderInfo.FinalConsumptionHospital = hospitalInfo.Result.Name.ToString();
                }
                orderInfo.WriteOffDate = DateTime.Now;
                await dalTikTokOrderInfo.UpdateAsync(orderInfo, true);
                //新增核销信息
                OrderWriteOffInfoAddDto addOrderWriteOffInfoAddDto = new OrderWriteOffInfoAddDto();
                addOrderWriteOffInfoAddDto.CreateDate = DateTime.UtcNow;
                addOrderWriteOffInfoAddDto.WriteOffOrderId = orderId;
                addOrderWriteOffInfoAddDto.WriteOffAmount = 1;
                if (orderInfo.Quantity.Value == 0 || orderInfo.Quantity == null)
                {
                    throw new Exception("订单数量错误，无法核销！");
                }
                addOrderWriteOffInfoAddDto.OrderLeaseAmount = orderInfo.Quantity.Value - 1;
                addOrderWriteOffInfoAddDto.WriteOffGoods = orderInfo.GoodsName;
                addOrderWriteOffInfoAddDto.HospitalId = Convert.ToInt16(hospitalId);
                await _orderWriteOffInfoService.AddOrderWriteOffInfoAsync(addOrderWriteOffInfoAddDto);

                var findInfo = await _bindCustomerServiceService.GetEmployeeIdByPhone(orderInfo.Phone);
                if (findInfo != 0)
                {
                    await _bindCustomerServiceService.UpdateConsumePriceAsync(orderInfo.Phone, orderInfo.ActualPayment.Value, (int)OrderFrom.ThirdPartyOrder);
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
        /// 发送邮箱方法
        /// </summary>
        /// <param name="appType"></param>
        /// <param name="orderId"></param>
        /// <param name="intergrationQuantity"></param>
        /// <param name="goodsName"></param>
        /// <param name="Phone"></param>
        private void BuildSendMailInfo(byte appType, string orderId, string goodsName, string Phone)
        {
            SendMails sendMails = new SendMails();
            var sub = "有新顾客在“" + ServiceClass.GetAppTypeText(appType) + "”下单啦，订单号为：" + orderId + "，请及时跟进哦！";
            var empInfos = from k in dalAmiyaEmployee.GetAll()
                           select k;
            //如果手机号为空则直接给客服主管发送提示信息
            if (string.IsNullOrEmpty(Phone)) {
                var employee = empInfos.Include(e => e.AmiyaPositionInfo).Where(e => e.AmiyaPositionInfo.Name == "客服主管" && e.Valid == true).ToListAsync();
                foreach (var x in employee.Result)
                {
                    var email = x.Email;
                    if (email == "0" || string.IsNullOrEmpty(email))
                        continue;
                    sendMails.sendMail("smtp.qq.com", "3023330386@qq.com", "kivbmbikthsmdejf", "阿美雅", "3023330386@qq.com", email, "客户下单提示", sub);
                }
                return;
            }
            //向管理员发送邮箱通知
            var bindCustomerInfos = from z in dalBindCustomerService.GetAll()
                                    where z.BuyerPhone == Phone
                                    select z;
            var bindCustmerInfo = bindCustomerInfos.FirstOrDefault();           
            if (bindCustmerInfo != null)
            {
                var empId = bindCustmerInfo.CustomerServiceId;
                var empInfoRes = from m in empInfos
                                 where m.Id == empId
                                 select m;
                var empInfo = empInfoRes.FirstOrDefault();
                if (empInfo != null)
                {
                    var email = empInfo.Email;
                    if (email == "0" || string.IsNullOrEmpty(email))
                    {
                        var employee = empInfos.Include(e => e.AmiyaPositionInfo).Where(e => e.AmiyaPositionInfo.Name == "客服主管" && e.Valid == true).ToListAsync();
                        foreach (var x in employee.Result)
                        {
                            email = x.Email;
                            if (email == "0" || string.IsNullOrEmpty(email))
                                continue;
                            sendMails.sendMail("smtp.qq.com", "3023330386@qq.com", "kivbmbikthsmdejf", "阿美雅", "3023330386@qq.com", email, "客户下单提示", sub);
                        }
                    }
                    else
                    {
                        sendMails.sendMail("smtp.qq.com", "3023330386@qq.com", "kivbmbikthsmdejf", "阿美雅", "3023330386@qq.com", email, "客户下单提示", sub);
                    }
                }
            }
            else
            {
                var employee = empInfos.Include(e => e.AmiyaPositionInfo).Where(e => e.AmiyaPositionInfo.Name == "客服主管" && e.Valid == true).ToListAsync();
                foreach (var x in employee.Result)
                {
                    var email = x.Email;
                    if (email == "0" || string.IsNullOrEmpty(email))
                        continue;
                    sendMails.sendMail("smtp.qq.com", "3023330386@qq.com", "kivbmbikthsmdejf", "阿美雅", "3023330386@qq.com", email, "客户下单提示", sub);
                }
            }
        }
        /// <summary>
        /// 发送手机号方法
        /// </summary>
        /// <param name="orderPhoneDict"></param>
        /// <param name="appType"></param>
        /// <param name="intergrationQuantity"></param>
        private async void SendPhoneInfo(Dictionary<string, string> orderPhoneDict, byte appType)
        {
            if (orderPhoneDict.Count > 0)
            {
                string templateName = "order_buyerpay_commit";
                foreach (var z in orderPhoneDict)
                {
                    await _smsSender.SendSingleAsync(z.Value, templateName, JsonConvert.SerializeObject(new { orderId = z.Key }));
                }
            }
        }
    }
}
