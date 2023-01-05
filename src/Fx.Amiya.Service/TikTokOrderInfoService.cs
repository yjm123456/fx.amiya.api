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
using Fx.Amiya.Dto.TikTokUserInfo;
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
        private readonly ILiveAnchorBaseInfoService liveAnchorBaseInfoService;
        private IDalSendGoodsRecord dalSendGoodsRecord;
        private IOrderWriteOffInfoService _orderWriteOffInfoService;
        private IExpressManageService _expressManageService;
        private ITikTokUserInfoService tikTokUserInfoService;
        private IBindCustomerServiceService _bindCustomerService;

        public TikTokOrderInfoService(IDalTikTokOrderInfo dalTikTokOrderInfo, IFxSmsBasedTemplateSender smsSender, IDalBindCustomerService dalBindCustomerService, ISendOrderInfoService sendOrderInfoService, IDalAmiyaEmployee dalAmiyaEmployee, IDalOrderInfo dalOrderInfo, IWxAppConfigService wxAppConfigService, ILiveAnchorService liveAnchorService, IContentPlatformService contentPlatFormService, IUnitOfWork unitOfWork, IDalOrderTrade dalOrderTrade, IAmiyaGoodsDemandService amiyaGoodsDemandService, ICustomerService customerService, IMemberCard memberCardService, IMemberRankInfo memberRankInfoService, IIntegrationAccount integrationAccountService, IBindCustomerServiceService bindCustomerServiceService, IOrderCheckPictureService orderCheckPictureService, IDalCustomerInfo dalCustomerInfo, IDalReceiveGift dalReceiveGift, IGoodsInfo goodsInfoService, IDalContentPlatformOrder dalContentPlatFormOrder, IHospitalInfoService hospitalInfoService, IDalSendGoodsRecord dalSendGoodsRecord, IOrderWriteOffInfoService orderWriteOffInfoService, IExpressManageService expressManageService, ITikTokUserInfoService tikTokUserInfoService, ILiveAnchorBaseInfoService liveAnchorBaseInfoService, IBindCustomerServiceService bindCustomerService)
        {
            this.dalTikTokOrderInfo = dalTikTokOrderInfo;
            _smsSender = smsSender;
            this.dalBindCustomerService = dalBindCustomerService;
            _sendOrderInfoService = sendOrderInfoService;
            this.liveAnchorBaseInfoService = liveAnchorBaseInfoService;
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
            this.tikTokUserInfoService = tikTokUserInfoService;
            _bindCustomerService = bindCustomerService;
        }

        public async Task<string> AddAmiyaOrderAsync(OrderTradeAddDto orderTradeAddDto)
        {
            try
            {
                unitOfWork.BeginTransaction();

                /*OrderTrade orderTrade = new OrderTrade();
                orderTrade.TradeId = Guid.NewGuid().ToString("N");
                orderTrade.CustomerId = orderTradeAddDto.CustomerId;
                orderTrade.CreateDate = orderTradeAddDto.CreateDate;
                orderTrade.TotalAmount = orderTradeAddDto.TikTokOrderInfoAddList.Sum(e => e.ActualPayment);
                orderTrade.Remark = orderTradeAddDto.Remark;
                orderTrade.IsAdminAdd = orderTradeAddDto.IsAdminAdd;
                orderTrade.StatusCode = OrderStatusCode.WAIT_BUYER_PAY;
                await dalOrderTrade.AddAsync(orderTrade, true);

                foreach (var item in orderTradeAddDto.TikTokOrderInfoAddList)
                {
                    item.TradeId = orderTrade.TradeId;
                }*/
                await AddOrderAsync(orderTradeAddDto.TikTokOrderInfoAddList);

                unitOfWork.Commit();
                return "";
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
                        //根据是否包含手机号判断该订单是否已经解密
                        if (!string.IsNullOrEmpty(orderInfo.Phone))
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
                            orderInfo.FinishDate = orderItem.FinishDate;
                            orderInfo.BelongLiveAnchorId = orderItem.BelongLiveAnchorId;
                            await dalTikTokOrderInfo.UpdateAsync(orderInfo, true);
                            //计算积分,如果订单信息包含手机号则计算积分,否则暂时不计算
                            if (orderInfo.StatusCode == "TRADE_FINISHED" && orderInfo.ActualPayment >= 1 && !string.IsNullOrWhiteSpace(orderInfo.Phone))
                            {
                                bool isIntegrationGenerateRecord = await integrationAccountService.GetIsIntegrationGenerateRecordByOrderIdAsync(orderInfo.Id);
                                if (isIntegrationGenerateRecord == true)
                                    continue;
                                var customerId = await customerService.GetCustomerIdByPhoneAsync(orderInfo.Phone);
                                if (string.IsNullOrWhiteSpace(customerId))
                                    continue;
                                ConsumptionIntegrationDto consumptionIntegration = new ConsumptionIntegrationDto();
                                consumptionIntegration.CustomerId = customerId;
                                consumptionIntegration.OrderId = orderInfo.Id;
                                consumptionIntegration.AmountOfConsumption = (decimal)orderInfo.ActualPayment;
                                consumptionIntegration.Date = DateTime.Now;

                                var memberCard = await memberCardService.GetMemberCardHandelByCustomerIdAsync(customerId);
                                if (memberCard != null)
                                {
                                    consumptionIntegration.Quantity = Math.Floor(memberCard.GenerateIntegrationPercent * (decimal)orderInfo.ActualPayment);
                                    consumptionIntegration.Percent = memberCard.GenerateIntegrationPercent;
                                }
                                else
                                {
                                    var memberRank = await memberRankInfoService.GetMinGeneratePercentMemberRankInfoAsync();
                                    consumptionIntegration.Quantity = Math.Floor(memberRank.GenerateIntegrationPercent * (decimal)orderInfo.ActualPayment);
                                    consumptionIntegration.Percent = memberRank.GenerateIntegrationPercent;

                                }

                                if (consumptionIntegration.Quantity > 0)
                                    await integrationAccountService.AddByConsumptionAsync(consumptionIntegration);
                                //根据phone获取获取绑定的员工
                                var findInfo = await _bindCustomerService.GetEmployeeIdByPhone(orderInfo.Phone);
                                if (findInfo != 0)
                                {
                                    await _bindCustomerService.UpdateConsumePriceAsync(orderInfo.Phone, orderInfo.ActualPayment.Value, (int)OrderFrom.ThirdPartyOrder, 1);
                                }
                            }


                        }
                        else
                        {
                            //订单信息没有解密
                            if (orderInfo.StatusCode == orderItem.StatusCode)
                            {
                                continue;
                            }
                            orderInfo.StatusCode = orderItem.StatusCode;
                            orderInfo.UpdateDate = orderItem.UpdateDate;
                            orderInfo.ActualPayment = orderItem.ActualPayment;
                            orderInfo.AccountReceivable = orderItem.AccountReceivable;
                            orderInfo.OrderType = orderItem.OrderType;
                            orderInfo.AppointmentHospital = orderItem.AppointmentHospital;
                            orderInfo.ThumbPicUrl = orderItem.ThumbPicUrl;
                            orderInfo.FinishDate = orderItem.FinishDate;
                            await dalTikTokOrderInfo.UpdateAsync(orderInfo, true);
                        }
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
                        order.ActualPayment = orderItem.ActualPayment;
                        order.AccountReceivable = orderItem.AccountReceivable;
                        order.CreateDate = orderItem.CreateDate;
                        order.UpdateDate = orderItem.UpdateDate;
                        order.FinishDate = orderItem.FinishDate;
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
                        order.BelongLiveAnchorId = orderItem.BelongLiveAnchorId;
                        order.WriteOffCode = "";
                        order.AlreadyWriteOffAmount = 0;
                        order.BelongEmpId = orderItem.BelongEmpId;
                        order.TikTokUserInfoId = orderItem.TikTokUserId;
                        AddTikTokUserDto addTikTokUserDto = new AddTikTokUserDto();
                        addTikTokUserDto.CipherName = orderItem.CipherName;
                        addTikTokUserDto.CipherPhone = orderItem.CipherPhone;
                        addTikTokUserDto.Id = GuidUtil.NewGuidShortString();
                        await tikTokUserInfoService.AddAsync(addTikTokUserDto);
                        order.TikTokUserInfoId = addTikTokUserDto.Id;
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

        public async Task AddOrderAsync(List<TikTokOrderAddDto> orderList)
        {
            var emailConfig = false;
            string goodsName = "";
            Dictionary<string, string> orderPhoneDict = new Dictionary<string, string>();
            byte appType = 0;
            List<TikTokOrderInfo> orderInfoList = new List<TikTokOrderInfo>();
            foreach (var item in orderList)
            {
                if (!string.IsNullOrEmpty(item.Phone))
                {
                    TikTokOrderInfo order = new TikTokOrderInfo();
                    order.Id = item.Id;
                    order.GoodsId = item.GoodsId;
                    order.GoodsName = item.GoodsName;
                    order.Phone = item.Phone;
                    order.AppointmentHospital = item.AppointmentHospital;
                    order.StatusCode = item.StatusCode;
                    if (item.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS || item.StatusCode == OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS)
                    {
                        goodsName += item.GoodsName + ",";
                        if (!string.IsNullOrEmpty(order.Phone))
                        {
                            orderPhoneDict.Add(item.Id, item.Phone);
                        }
                        //组织邮件信息
                        if (emailConfig == true)
                        {
                            BuildSendMailInfo(appType, item.Id, goodsName, item.Phone);
                        }

                    }
                    order.ActualPayment = item.ActualPayment;
                    order.AccountReceivable = item.AccountReceivable;
                    order.CreateDate = item.CreateDate;
                    order.UpdateDate = item.UpdateDate;
                    order.ThumbPicUrl = item.ThumbPicUrl;
                    order.BuyerNick = item.BuyerNick;
                    order.CheckState = (int)CheckType.NotChecked;
                    order.AppType = item.AppType;
                    order.IsAppointment = item.IsAppointment;
                    order.OrderType = item.OrderType;
                    order.OrderNature = item.OrderNature.HasValue ? item.OrderNature.Value : (byte)0;
                    order.Description = item.Description;
                    order.Standard = item.Standard;
                    order.Parts = item.Part;
                    order.Quantity = item.Quantity;
                    order.IntegrationQuantity = item.IntegrationQuantity;
                    order.ExchangeType = item.ExchangeType;
                    order.WriteOffCode = "";
                    order.BelongLiveAnchorId = item.BelongLiveAnchorId;
                    order.AlreadyWriteOffAmount = 0;
                    order.TikTokUserInfoId = item.TikTokUserId;
                    orderInfoList.Add(order);
                }
                else
                {
                    TikTokOrderInfo order = new TikTokOrderInfo();
                    order.Id = item.Id;
                    order.GoodsId = item.GoodsId;
                    order.GoodsName = item.GoodsName;
                    order.AppointmentHospital = item.AppointmentHospital;
                    order.StatusCode = item.StatusCode;
                    if (item.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS || item.StatusCode == OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS)
                    {
                        goodsName += item.GoodsName + ",";
                        //组织邮件信息
                        if (emailConfig == true)
                        {
                            BuildSendMailInfo(appType, item.Id, goodsName, item.Phone);
                        }

                    }
                    order.ActualPayment = item.ActualPayment;
                    order.AccountReceivable = item.AccountReceivable;
                    order.CreateDate = item.CreateDate;
                    order.UpdateDate = item.UpdateDate;
                    order.ThumbPicUrl = item.ThumbPicUrl;
                    order.CheckState = (int)CheckType.NotChecked;
                    order.AppType = item.AppType;
                    order.IsAppointment = item.IsAppointment;
                    order.BelongLiveAnchorId = item.BelongLiveAnchorId;
                    order.OrderType = item.OrderType;
                    order.OrderNature = item.OrderNature.HasValue ? item.OrderNature.Value : (byte)0;
                    order.Description = item.Description;
                    order.Standard = item.Standard;
                    order.Parts = item.Part;
                    order.Quantity = item.Quantity;
                    order.IntegrationQuantity = item.IntegrationQuantity;
                    order.ExchangeType = item.ExchangeType;
                    order.WriteOffCode = "";
                    order.AlreadyWriteOffAmount = 0;
                    order.BelongEmpId = item.BelongEmpId;
                    order.TikTokUserInfoId = item.TikTokUserId;
                    AddTikTokUserDto addTikTokUserDto = new AddTikTokUserDto();
                    addTikTokUserDto.CipherName = item.CipherName;
                    addTikTokUserDto.CipherPhone = item.CipherPhone;
                    addTikTokUserDto.Id = GuidUtil.NewGuidShortString();
                    await tikTokUserInfoService.AddAsync(addTikTokUserDto);
                    order.TikTokUserInfoId = addTikTokUserDto.Id;
                    orderInfoList.Add(order);
                }

            }
            await dalTikTokOrderInfo.AddCollectionAsync(orderInfoList, true);
            //发送短信通知
            SendPhoneInfo(orderPhoneDict, appType);
        }



        /// <summary>
        /// 根据订单编号获取订单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TikTokOrderDto> GetOrderById(string orderId)
        {
            var config = await _wxAppConfigService.GetCallCenterConfig();
            var order = await dalTikTokOrderInfo.GetAll()
                .SingleOrDefaultAsync(e => e.Id == orderId);
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
            orderInfo.StatusText = ServiceClass.GetTikTokOrderStatusText(order.StatusCode);
            orderInfo.ActualPayment = order.ActualPayment;
            orderInfo.CreateDate = order.CreateDate;
            orderInfo.UpdateDate = order.UpdateDate;
            orderInfo.OrderType = order.OrderType;
            orderInfo.OrderTypeText = ServiceClass.GetTikTokOrderTypeText((byte)order.OrderType);
            orderInfo.Description = order.Description;
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
            orderInfo.AccountReceivable = order.AccountReceivable;
            return orderInfo;
        }

        public async Task<FxPageInfo<TikTokOrderDto>> GetOrderListWithPageAsync(DateTime? startDate, DateTime? endDate, string keyword, string belongLiveAnchorId, int pageNum, int pageSize)
        {
            try
            {
                var orders = from d in dalTikTokOrderInfo.GetAll()
                             where (string.IsNullOrWhiteSpace(keyword) || d.Id.Contains(keyword) || d.GoodsName.Contains(keyword)
                             || d.Phone == keyword || d.AppointmentHospital.Contains(keyword))
                             && (string.IsNullOrWhiteSpace(belongLiveAnchorId) || d.BelongLiveAnchorId == belongLiveAnchorId)
                             select d;

                if (startDate != null && endDate != null)
                {
                    DateTime startrq = ((DateTime)startDate);
                    DateTime endrq = ((DateTime)endDate).AddDays(1);
                    orders = from d in orders
                             where d.CreateDate >= startrq && d.CreateDate < endrq
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
                                IsAppointment = d.IsAppointment,
                                StatusCode = d.StatusCode,
                                StatusText = ServiceClass.GetTikTokOrderStatusText(d.StatusCode),
                                ActualPayment = d.ActualPayment,
                                CreateDate = d.CreateDate,
                                UpdateDate = d.UpdateDate,
                                FinishDate = d.FinishDate,
                                AppType = d.AppType,
                                BelongLiveAnchorId = d.BelongLiveAnchorId,
                                AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                                OrderType = d.OrderType,
                                Description = d.Description,
                                OrderTypeText = d.OrderType != null ? ServiceClass.GetTikTokOrderTypeText((byte)d.OrderType) : "",
                                Quantity = d.Quantity,
                                ExchangeType = d.ExchangeType,
                                ExchangeTypeText = ServiceClass.GetExchangeTypeText((byte)d.ExchangeType),
                                LiveAnchorId = d.LiveAnchorId,
                            };


                FxPageInfo<TikTokOrderDto> orderPageInfo = new FxPageInfo<TikTokOrderDto>();
                orderPageInfo.TotalCount = await order.CountAsync();
                orderPageInfo.List = await order.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                foreach (var x in orderPageInfo.List)
                {
                    //if (x.LiveAnchorId != 0)
                    //{
                    //    var liveanchor = await liveAnchorService.GetByIdAsync(x.LiveAnchorId);
                    //    x.LiveAnchorName = liveanchor.Name;
                    //    if (!string.IsNullOrEmpty(liveanchor.ContentPlateFormId))
                    //    {
                    //        x.ContentPlatFormId = liveanchor.ContentPlateFormId;
                    //        var contentplatFormInfo = await contentPlatFormService.GetByIdAsync(liveanchor.ContentPlateFormId);
                    //        x.LiveAnchorPlatForm = contentplatFormInfo.ContentPlatformName;
                    //    }
                    //}

                    //if (x.BelongEmpId != 0)
                    //{
                    //    var customerService = await dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == x.BelongEmpId);
                    //    x.BelongEmpName = customerService.Name;
                    //}

                    if (!string.IsNullOrEmpty(x.BelongLiveAnchorId))
                    {
                        var liveAnchorInfoService = await liveAnchorBaseInfoService.GetByIdAsync(x.BelongLiveAnchorId);
                        x.BelongLiveAnchorName = liveAnchorInfoService.LiveAnchorName;
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
        /// 更新订单信息
        /// </summary>
        /// <param name="tikTokOrderInfoUpdateDto"></param>
        /// <returns></returns>
        public async Task UpdateOrderAsync(TikTokOrderInfoUpdateDto tikTokOrderInfoUpdateDto)
        {
            var tikTokOrder = await dalTikTokOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == tikTokOrderInfoUpdateDto.Id);
            if (tikTokOrder == null)
            {
                throw new Exception("订单编号错误");
            }
            if (string.IsNullOrEmpty(tikTokOrder.Phone))
            {
                tikTokOrder.Phone = tikTokOrderInfoUpdateDto.Phone;
                tikTokOrder.BuyerNick = tikTokOrderInfoUpdateDto.NickName;
                await dalTikTokOrderInfo.UpdateAsync(tikTokOrder, true);

                //计算积分,如果订单信息包含手机号则计算积分,否则暂时不计算
                if (tikTokOrder.StatusCode == "TRADE_FINISHED" && tikTokOrder.ActualPayment >= 1 && !string.IsNullOrWhiteSpace(tikTokOrder.Phone))
                {
                    bool isIntegrationGenerateRecord = await integrationAccountService.GetIsIntegrationGenerateRecordByOrderIdAsync(tikTokOrder.Id);
                    if (isIntegrationGenerateRecord == true)
                        return;
                    var customerId = await customerService.GetCustomerIdByPhoneAsync(tikTokOrder.Phone);
                    if (string.IsNullOrWhiteSpace(customerId))
                        return;
                    ConsumptionIntegrationDto consumptionIntegration = new ConsumptionIntegrationDto();
                    consumptionIntegration.CustomerId = customerId;
                    consumptionIntegration.OrderId = tikTokOrder.Id;
                    consumptionIntegration.AmountOfConsumption = (decimal)tikTokOrder.ActualPayment;
                    consumptionIntegration.Date = DateTime.Now;

                    var memberCard = await memberCardService.GetMemberCardHandelByCustomerIdAsync(customerId);
                    if (memberCard != null)
                    {
                        consumptionIntegration.Quantity = Math.Floor(memberCard.GenerateIntegrationPercent * (decimal)tikTokOrder.ActualPayment);
                        consumptionIntegration.Percent = memberCard.GenerateIntegrationPercent;
                    }
                    else
                    {
                        var memberRank = await memberRankInfoService.GetMinGeneratePercentMemberRankInfoAsync();
                        consumptionIntegration.Quantity = Math.Floor(memberRank.GenerateIntegrationPercent * (decimal)tikTokOrder.ActualPayment);
                        consumptionIntegration.Percent = memberRank.GenerateIntegrationPercent;

                    }

                    if (consumptionIntegration.Quantity > 0)
                        await integrationAccountService.AddByConsumptionAsync(consumptionIntegration);
                    //根据phone获取获取绑定的员工
                    var findInfo = await _bindCustomerService.GetEmployeeIdByPhone(tikTokOrder.Phone);
                    if (findInfo != 0)
                    {
                        await _bindCustomerService.UpdateConsumePriceAsync(tikTokOrder.Phone, 0, (int)OrderFrom.ThirdPartyOrder, 0);
                    }
                }
            }
            else
            {
                tikTokOrder.Phone = tikTokOrderInfoUpdateDto.Phone;
                tikTokOrder.BuyerNick = tikTokOrderInfoUpdateDto.NickName;
                await dalTikTokOrderInfo.UpdateAsync(tikTokOrder, true);
            }



        }
        /// <summary>
        /// 校对订单状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statusCode"></param>
        /// <param name="actualPayment"></param>
        /// <param name="accountReceivable"></param>
        /// <param name="updateDate"></param>
        /// <returns></returns>
        public async Task UpdateOrderStatusAsync(string id, string statusCode, decimal? actualPayment, decimal? accountReceivable, DateTime? updateDate, DateTime? finishDate)
        {
            var order = dalTikTokOrderInfo.GetAll().FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                throw new Exception("未找到该订单,请核对后订单号后重试");
            }
            order.StatusCode = statusCode;
            order.ActualPayment = actualPayment;
            order.AccountReceivable = accountReceivable;
            order.UpdateDate = updateDate;
            order.FinishDate = finishDate;
            await dalTikTokOrderInfo.UpdateAsync(order, true);
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
            if (string.IsNullOrEmpty(Phone))
            {
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
