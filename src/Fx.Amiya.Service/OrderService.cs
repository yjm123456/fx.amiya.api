using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Infrastructure;
using Fx.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Infrastructure.Utils;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using Newtonsoft.Json;
using Fx.Amiya.Dto.WxAppConfig;
using Top.Tmc;
using Microsoft.Extensions.Logging;
using Fx.Amiya.SyncOrder.Core;
using Fx.Amiya.SyncOrder.JD;
using Fx.Common;
using Fx.Amiya.Dto.OrderAppInfo;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Xml;
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.Dto.OrderWriteOffIno;
using Fx.Sms.Core;
using ACES.Common;
using Fx.Amiya.Dto.ExpressManage;
using jos_sdk_net.Util;
using Fx.Common.Utils;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.OrderCheckPicture;

namespace Fx.Amiya.Service
{
    public class OrderService : IOrderService
    {
        private IDalContentPlatformOrder _dalContentPlatFormOrder;
        private IDalOrderInfo dalOrderInfo;
        private IWxAppConfigService _wxAppConfigService;
        private IDalCustomerInfo dalCustomerInfo;
        private IUnitOfWork unitOfWork;
        private IContentPlatformService contentPlatFormService;
        private IOrderCheckPictureService _orderCheckPictureService;
        private IDalBindCustomerService dalBindCustomerService;
        private IBindCustomerServiceService _bindCustomerService;
        private ILiveAnchorService liveAnchorService;
        private IDalAmiyaEmployee dalAmiyaEmployee;
        private ICustomerService customerService;
        private IMemberRankInfo memberRankInfoService;
        private IDalReceiveGift dalReceiveGift;
        private IMemberCard memberCardService;
        private ILogger<OrderService> logger;
        private IDalOrderTrade dalOrderTrade;
        private IDalSendGoodsRecord dalSendGoodsRecord;
        private readonly IItemInfoService _itemInfoService;
        private IGoodsCategory goodsCategoryService;
        private IIntegrationAccount integrationAccountService;
        private IOrderWriteOffInfoService _orderWriteOffInfoService;
        private IGoodsInfo _goodsInfoService;
        private IHospitalInfoService _hospitalInfoService;
        private ISendOrderInfoService _sendOrderInfoService;
        private IFxSmsBasedTemplateSender _smsSender;
        private IDalNoticeConfig dalNoticeConfig;
        private IExpressManageService _expressManageService;
        private IAmiyaGoodsDemandService _amiyaGoodsDemandService;
        public OrderService(
            IDalContentPlatformOrder dalContentPlatFormOrder,
            IDalOrderInfo dalOrderInfo,
            IDalCustomerInfo dalCustomerInfo,
            IUnitOfWork unitOfWork,
            IWxAppConfigService wxAppConfigService,
            IBindCustomerServiceService bindCustomerService,
            IContentPlatformService contentPlatFormService,
             IMemberCard memberCardService,
            ICustomerService customerService,
            ILiveAnchorService liveAnchorService,
            IDalBindCustomerService dalBindCustomerService,
            IDalAmiyaEmployee dalAmiyaEmployee,
            IDalNoticeConfig dalNoticeConfig,
            IOrderCheckPictureService orderCheckPictureService,
            IAmiyaGoodsDemandService amiyaGoodsDemandService,
            IDalReceiveGift dalReceiveGift,
            ILogger<OrderService> logger,
            IDalOrderTrade dalOrderTrade,
            IDalSendGoodsRecord dalSendGoodsRecord,
            IOrderWriteOffInfoService orderWriteOffService,
            IGoodsInfo goodsInfoService,
            IItemInfoService itemInfoService,
            ISendOrderInfoService sendOrderInfoService,
            IHospitalInfoService hospitalInfoService,
            IExpressManageService expressManageService,
            IFxSmsBasedTemplateSender smsSender,
             IMemberRankInfo memberRankInfoService,
            IIntegrationAccount integrationAccountService)
        {
            this.dalOrderInfo = dalOrderInfo;
            this.dalCustomerInfo = dalCustomerInfo;
            this.unitOfWork = unitOfWork;
            this.dalBindCustomerService = dalBindCustomerService;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
            _bindCustomerService = bindCustomerService;
            this.contentPlatFormService = contentPlatFormService;
            this.liveAnchorService = liveAnchorService;
            this.customerService = customerService;
            this.memberCardService = memberCardService;
            this.dalNoticeConfig = dalNoticeConfig;
            this.dalReceiveGift = dalReceiveGift;
            this.logger = logger;
            this.memberRankInfoService = memberRankInfoService;
            this.integrationAccountService = integrationAccountService;
            this.dalOrderTrade = dalOrderTrade;
            this.dalSendGoodsRecord = dalSendGoodsRecord;
            _orderCheckPictureService = orderCheckPictureService;
            _amiyaGoodsDemandService = amiyaGoodsDemandService;
            _itemInfoService = itemInfoService;
            _wxAppConfigService = wxAppConfigService;
            _goodsInfoService = goodsInfoService;
            _orderWriteOffInfoService = orderWriteOffService;
            _hospitalInfoService = hospitalInfoService;
            _sendOrderInfoService = sendOrderInfoService;
            _smsSender = smsSender;
            _dalContentPlatFormOrder = dalContentPlatFormOrder;
            _expressManageService = expressManageService;
        }
        //WxPayAccount _payAccount = new WxPayAccount("wx695942e4818de445", "0b2e89d17e84a947244569d0ec63b816", "1611476157", "asdfg67890asdfg67890asdfg67890as", false, "", "");
        WxPayAccount _payAccount = new WxPayAccount("wx695942e4818de445", "0b2e89d17e84a947244569d0ec63b816", "1632393371", "Amy20202020202020202020202020202", false, "", "");
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="writeOffStartDate"></param>
        /// <param name="writeOffEndDate"></param>
        /// <param name="belongEmpId"></param>
        /// <param name="keyword"></param>
        /// <param name="statusCode"></param>
        /// <param name="appType"></param>
        /// <param name="orderNature"></param>
        /// <param name="employeeId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<OrderInfoDto>> GetOrderListWithPageAsync(DateTime? startDate, DateTime? endDate, DateTime? writeOffStartDate, DateTime? writeOffEndDate, int? belongEmpId, string keyword, string statusCode, byte? appType, byte? orderNature, int employeeId, int pageNum, int pageSize)
        {
            try
            {
                var orders = from d in dalOrderInfo.GetAll()
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
                            select new OrderInfoDto
                            {
                                Id = d.Id,
                                GoodsId = d.GoodsId,
                                GoodsName = d.GoodsName,
                                BuyerNick = d.BuyerNick,
                                BelongEmpId = d.BelongEmpId,
                                ThumbPicUrl = d.ThumbPicUrl,
                                AppointmentDate = d.AppointmentDate,
                                AppointmentCity = d.AppointmentCity,
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


                FxPageInfo<OrderInfoDto> orderPageInfo = new FxPageInfo<OrderInfoDto>();
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



        /// <summary>
        /// 获取已成交订单列表
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
        public async Task<FxPageInfo<OrderInfoDto>> GetOrderFinishListWithPageAsync(DateTime? writeOffStartDate, DateTime? writeOffEndDate, int? CheckState, bool? ReturnBackPriceState, string keyword, byte? appType, byte? orderNature, int employeeId, int pageNum, int pageSize)
        {
            try
            {
                var orders = from d in dalOrderInfo.GetAll()
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
                var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).SingleOrDefaultAsync(e => e.Id == employeeId);
                if (employee.IsCustomerService && !employee.AmiyaPositionInfo.IsDirector)
                {
                    orders = from d in orders
                             where dalBindCustomerService.GetAll().Count(e => e.CustomerServiceId == employeeId && e.BuyerPhone == d.Phone) > 0
                             select d;
                }

                var config = await _wxAppConfigService.GetCallCenterConfig();
                var order = from d in orders
                            select new OrderInfoDto
                            {
                                Id = d.Id,
                                GoodsId = d.GoodsId,
                                GoodsName = d.GoodsName,
                                BuyerNick = d.BuyerNick,
                                ThumbPicUrl = d.ThumbPicUrl,
                                Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                AppointmentDate = d.AppointmentDate,
                                AppointmentCity = d.AppointmentCity,
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
                                ReturnBackDate = d.ReturnBackDate
                            };


                FxPageInfo<OrderInfoDto> orderPageInfo = new FxPageInfo<OrderInfoDto>();
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
        /// 导出订单列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="writeOffStartDate"></param>
        /// <param name="writeOffEndDate"></param>
        /// <param name="keyword"></param>
        /// <param name="statusCode"></param>
        /// <param name="appType"></param>
        /// <param name="orderNature"></param>
        /// <param name="employeeId"></param>
        /// <param name="isHidePhone"></param>
        /// <returns></returns>
        public async Task<List<OrderInfoDto>> ExportOrderListAsync(DateTime? startDate, DateTime? endDate, DateTime? writeOffStartDate, DateTime? writeOffEndDate, string keyword, string statusCode, byte? appType, byte? orderNature, int employeeId, bool isHidePhone)
        {
            try
            {
                var orders = from d in dalOrderInfo.GetAll()
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
                            select new OrderInfoDto
                            {
                                Id = d.Id,
                                GoodsId = d.GoodsId,
                                GoodsName = d.GoodsName,
                                BuyerNick = d.BuyerNick,
                                ThumbPicUrl = d.ThumbPicUrl,
                                Phone = isHidePhone == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                                //EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                                AppointmentCity = d.AppointmentCity,
                                AppointmentDate = d.AppointmentDate,
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


                List<OrderInfoDto> orderPageInfo = new List<OrderInfoDto>();
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
        /// 根据加密手机号获取订单列表
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<OrderInfoDto>> GetListByEncryptPhoneAsync(string encryptPhone, int pageNum, int pageSize)
        {
            try
            {
                var config = await _wxAppConfigService.GetCallCenterConfig();
                string phone = ServiceClass.Decrypto(encryptPhone, config.PhoneEncryptKey);

                var order = from d in dalOrderInfo.GetAll()
                            where d.Phone == phone
                            select new OrderInfoDto
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
                                AppType = d.AppType,
                                AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                                Quantity = d.Quantity,
                                IntegrationQuantity = d.IntegrationQuantity,
                                ExchangeType = d.ExchangeType,
                                ExchangeTypeText = ServiceClass.GetExchangeTypeText((byte)d.ExchangeType),
                                TradeId = d.TradeId,
                            };
                FxPageInfo<OrderInfoDto> orderPageInfo = new FxPageInfo<OrderInfoDto>();
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
        /// 根据加密手机号获取订单列表
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns></returns>
        public async Task<bool> IsExistPhoneAsync(string phone)
        {
            bool result = false;
            try
            {
                var config = await _wxAppConfigService.GetCallCenterConfig();
                var order = from d in dalOrderInfo.GetAll()
                            where d.Phone == phone
                            select new OrderInfoDto
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
                                AppType = d.AppType,
                                AppTypeText = ServiceClass.GetAppTypeText(d.AppType),
                                Quantity = d.Quantity,
                                IntegrationQuantity = d.IntegrationQuantity,
                                ExchangeType = d.ExchangeType,
                                ExchangeTypeText = ServiceClass.GetExchangeTypeText((byte)d.ExchangeType),
                                TradeId = d.TradeId,
                            };
                var count = await order.CountAsync();
                if (count > 0)
                {
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }



        /// <summary>
        /// 获取当天所有订单号
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetTodayOrderCount()
        {
            try
            {
                var date = DateTime.Today;
                var model = from d in dalOrderInfo.GetAll() where (d.CreateDate >= date && d.CreateDate < date.AddDays(1)) select d;
                return model.CountAsync().Result.ToString();
            }
            catch (Exception e)
            {
                return "0";
            }
        }


        /// <summary>
        /// 获取未绑定客服的订单列表（分页）
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="keyword"></param> 
        /// <param name="minPayment">最小金额</param>
        /// <param name="maxPayment">最大金额</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<OrderInfoDto>> GetUnBindCustomerServiceOrderListAsync(string statusCode, string keyword, decimal? minPayment, decimal? maxPayment, byte? appType, int pageNum, int pageSize)
        {


            var order = await dalOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == keyword);
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

            var q = from d in dalOrderInfo.GetAll()
                    where (string.IsNullOrWhiteSpace(statusCode) || d.StatusCode == statusCode.Trim())
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
                         select new OrderInfoDto
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

            FxPageInfo<OrderInfoDto> orderPageInfo = new FxPageInfo<OrderInfoDto>();
            orderPageInfo.TotalCount = await orders.CountAsync();
            orderPageInfo.List = await orders.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return orderPageInfo;
        }



        /// <summary>
        /// 获取已绑定客服的订单列表
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="customerServiceId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
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
            var orders = from d in dalOrderInfo.GetAll()
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
        /// 添加订单
        /// </summary>
        /// <param name="orderList"></param>
        /// <returns></returns>
        public async Task AddOrderAsync(List<OrderInfoAddDto> orderList)
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
                decimal intergration_quantity = 0M;
                List<OrderInfo> orderInfoList = new List<OrderInfo>();
                foreach (var orderItem in orderList)
                {
                    appType = orderItem.AppType;
                    if (orderItem.IntegrationQuantity.HasValue)
                        intergration_quantity = orderItem.IntegrationQuantity.Value;
                    var orderInfos = from d in dalOrderInfo.GetAll()
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
                                BuildSendMailInfo(appType, orderItem.Id, intergration_quantity, goodsName, orderItem.Phone);
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
                        await dalOrderInfo.UpdateAsync(orderInfo, true);
                    }
                    else
                    {
                        OrderInfo order = new OrderInfo();
                        order.Id = orderItem.Id;
                        order.GoodsId = orderItem.GoodsId;
                        order.GoodsName = orderItem.GoodsName;
                        order.Phone = orderItem.Phone;
                        order.AppointmentDate = orderItem.AppointmentDate;
                        order.AppointmentCity = orderItem.AppointmentCity;
                        order.AppointmentHospital = orderItem.AppointmentHospital;
                        order.StatusCode = orderItem.StatusCode;
                        if (orderItem.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS || orderItem.StatusCode == OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS)
                        {
                            goodsName += orderItem.GoodsName + ",";
                            orderPhoneDict.Add(orderItem.Id, orderItem.Phone);
                            //组织邮件信息
                            if (emailConfig == true)
                            {
                                BuildSendMailInfo(appType, orderItem.Id, intergration_quantity, goodsName, orderItem.Phone);
                            }

                        }
                        order.ActualPayment = orderItem.ActualPayment;
                        order.AccountReceivable = orderItem.AccountReceivable;
                        order.CreateDate = orderItem.CreateDate;
                        order.BuyerNick = orderItem.BuyerNick;
                        order.UpdateDate = orderItem.UpdateDate;
                        order.ThumbPicUrl = orderItem.ThumbPicUrl;
                        order.BuyerNick = orderItem.BuyerNick;
                        order.CheckState = (int)CheckType.NotChecked;
                        order.AppType = orderItem.AppType;
                        order.IsAppointment = orderItem.IsAppointment;
                        order.OrderType = orderItem.OrderType;
                        order.OrderNature = orderItem.OrderNature.HasValue ? orderItem.OrderNature.Value : (byte)0;

                        //加入非空验证(todo;)
                        if (orderItem.AppType != (byte)AppType.MiniProgram && orderItem.AppType != (byte)AppType.WeChatOfficialAccount)
                        {
                            #region 订单加入简介/规格/部位
                            //获取项目规格
                            var itemInfo = await _itemInfoService.GetByOtherAppItemIdAsync(order.GoodsId);
                            if (itemInfo.Id != 0)
                            {
                                order.Description = itemInfo.Description;
                                order.Standard = itemInfo.Standard;
                                order.Parts = itemInfo.Parts;
                            }
                            else
                            {
                                order.Description = orderItem.Description;
                            }
                            #endregion
                        }
                        else
                        {
                            order.Description = orderItem.Description;
                            order.Standard = orderItem.Standard;
                            order.Parts = orderItem.Part;
                        }
                        order.Quantity = orderItem.Quantity;
                        order.IntegrationQuantity = orderItem.IntegrationQuantity;
                        order.ExchangeType = orderItem.ExchangeType;
                        order.TradeId = orderItem.TradeId;
                        order.WriteOffCode = "";
                        order.AlreadyWriteOffAmount = 0;
                        order.BelongEmpId = orderItem.BelongEmpId;
                        order.IsUseCoupon = orderItem.IsUseCoupon;
                        order.CouponId = orderItem.CouponId;
                        order.DeductMoney = orderItem.DeductMoney;
                        order.AppointmentCity = orderItem.AppointmentCity;
                        order.AppointmentDate = orderItem.AppointmentDate;
                        orderInfoList.Add(order);
                    }
                }
                await dalOrderInfo.AddCollectionAsync(orderInfoList, true);
                //发送短信通知
                SendPhoneInfo(orderPhoneDict, appType, intergration_quantity);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 添加阿美雅订单
        /// </summary>
        /// <param name="orderTradeAddDto"></param>
        /// <returns>交易编号</returns>
        public async Task<string> AddAmiyaOrderAsync(OrderTradeAddDto orderTradeAddDto)
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
                await AddOrderAsync(orderTradeAddDto.OrderInfoAddList);

                unitOfWork.Commit();
                return orderTrade.TradeId;
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }


        /// <summary>
        /// 根据交易编号获取订单列表
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        public async Task<List<OrderInfoDto>> GetOrderListByTradeIdAsync(string tradeId)
        {
            var config = await _wxAppConfigService.GetCallCenterConfig();
            var orders = from d in dalOrderInfo.GetAll()
                         where d.TradeId == tradeId
                         select new OrderInfoDto
                         {
                             Id = d.Id,
                             GoodsId = d.GoodsId,
                             GoodsName = d.GoodsName,
                             ThumbPicUrl = d.ThumbPicUrl,
                             Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                             EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                             AppointmentCity = d.AppointmentCity,
                             AppointmentDate = d.AppointmentDate,
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

        public async Task<List<OrderInfoDto>> GetOrderInfoByWriteOffCode(string WriteOffCode)
        {
            var config = await _wxAppConfigService.GetCallCenterConfig();
            var orders = from d in dalOrderInfo.GetAll()
                         where d.WriteOffCode == WriteOffCode
                         select new OrderInfoDto
                         {
                             Id = d.Id,
                             GoodsId = d.GoodsId,
                             GoodsName = d.GoodsName,
                             ThumbPicUrl = d.ThumbPicUrl,
                             Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(d.Phone) : d.Phone,
                             EncryptPhone = ServiceClass.Encrypt(d.Phone, config.PhoneEncryptKey),
                             AppointmentHospital = d.AppointmentHospital,
                             AppointmentCity = d.AppointmentCity,
                             AppointmentDate = d.AppointmentDate,
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
        /// 修改订单
        /// </summary>
        /// <param name="updateListDto"></param>
        /// <returns></returns>
        public async Task UpdateAsync(List<UpdateOrderDto> updateListDto)
        {
            var emailConfig = true;
            //订单号集合
            string orderId = "";
            string phone = "";
            string goodsName = "";
            byte appType = 0;
            decimal intergration_quantity = 0M;
            try
            {
                unitOfWork.BeginTransaction();
                DateTime date = DateTime.Now;
                List<OrderTradeForWxDto> tradeList = new List<OrderTradeForWxDto>();
                foreach (var item in updateListDto)
                {
                    appType = item.AppType.Value;
                    if (item.IntergrationQuantity.HasValue)
                        intergration_quantity = item.IntergrationQuantity.Value;
                    var orderInfo = await dalOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == item.OrderId);
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
                        if (orderInfo.StatusCode == OrderStatusCode.TRADE_BUYER_PAID && item.AppType == (byte)AppType.MiniProgram)
                        {
                            orderId += orderInfo.Id + ",";
                            goodsName += orderInfo.GoodsName + ",";
                            phone = orderInfo.Phone;
                            //组织邮件信息
                            if (emailConfig == true)
                            {
                                //BuildSendMailInfo(appType, orderInfo.Id, intergration_quantity, goodsName, orderInfo.Phone);
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
                            await dalOrderInfo.UpdateAsync(orderInfo, true);
                        }

                        if (!string.IsNullOrWhiteSpace(item.AppointmentHospital))
                            orderInfo.AppointmentHospital = item.AppointmentHospital;
                        await dalOrderInfo.UpdateAsync(orderInfo, true);

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
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
            try
            {
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


            }

        }

        /// <summary>
        /// 修改录单订单
        /// </summary>
        /// <param name="updateListDto"></param>
        /// <returns></returns>
        public async Task UpdateAddedOrderAsync(OrderInfoUpdateDto updateDto)
        {
            try
            {
                var orderInfo = await dalOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                orderInfo.GoodsName = updateDto.GoodsName;
                orderInfo.GoodsId = updateDto.GoodsId;
                orderInfo.Phone = updateDto.Phone;
                orderInfo.AppointmentCity = updateDto.AppointmentCity;
                orderInfo.AppointmentDate = updateDto.AppointmentDate;
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
                await dalOrderInfo.UpdateAsync(orderInfo, true);

            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }

        /// <summary>
        /// 订单校对
        /// </summary>
        /// <param name="updateListDto"></param>
        /// <returns></returns>
        public async Task UpdateOrderStatusAsync(string OrderId, string OrderStatus, decimal? ActuralPayment, decimal? AccountReceivable, DateTime? UpdateTime, DateTime? WriteOffDate)
        {
            var orderInfo = await dalOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == OrderId);
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
            await dalOrderInfo.UpdateAsync(orderInfo, true);
            if (orderInfo.StatusCode == "TRADE_FINISHED" && orderInfo.ActualPayment >= 1 && !string.IsNullOrWhiteSpace(orderInfo.Phone))
            {
                List<ConsumptionIntegrationDto> consumptionIntegrationList = new List<ConsumptionIntegrationDto>();
                bool isIntegrationGenerateRecord = await integrationAccountService.GetIsIntegrationGenerateRecordByOrderIdAsync(orderInfo.Id);
                if (isIntegrationGenerateRecord == false)
                {
                    var customerId = await customerService.GetCustomerIdByPhoneAsync(orderInfo.Phone);
                    if (!string.IsNullOrWhiteSpace(customerId))
                    {
                        ConsumptionIntegrationDto consumptionIntegration = new ConsumptionIntegrationDto();
                        consumptionIntegration.CustomerId = customerId;
                        consumptionIntegration.OrderId = orderInfo.Id;
                        consumptionIntegration.AmountOfConsumption = (decimal)orderInfo.ActualPayment;
                        consumptionIntegration.Date = orderInfo.WriteOffDate.Value;

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
                            consumptionIntegrationList.Add(consumptionIntegration);
                        var findInfo = await _bindCustomerService.GetEmployeeIdByPhone(orderInfo.Phone);

                        if (findInfo != 0)
                        {
                            var dealPriceDetails = ActuralPayment - orderInfo.ActualPayment;
                            await _bindCustomerService.UpdateConsumePriceAsync(orderInfo.Phone, orderInfo.ActualPayment.Value, (int)OrderFrom.ThirdPartyOrder, 0);
                        }
                    }
                }
                foreach (var item in consumptionIntegrationList)
                {
                    await integrationAccountService.AddByConsumptionAsync(item);
                }
            }
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
        /// 修改订单归属主播
        /// </summary>
        /// <param name="updateListDto"></param>
        /// <returns></returns>
        public async Task UpdateOrderLiveAnchorAsync(UpdateLiveAnchorOrderDto input)
        {
            try
            {
                unitOfWork.BeginTransaction();
                foreach (var x in input.OrderId)
                {
                    var orderInfo = await dalOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == x);
                    if (orderInfo == null)
                    { throw new Exception("未找到该订单，归属主播失败！"); }
                    orderInfo.LiveAnchorId = input.LiveAnchorId;
                    await dalOrderInfo.UpdateAsync(orderInfo, true);
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
                    var orderInfo = await dalOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == x);
                    if (orderInfo == null)
                    { throw new Exception("未找到该订单，归属客服失败！"); }
                    orderInfo.BelongEmpId = input.BelongEmpId;
                    await dalOrderInfo.UpdateAsync(orderInfo, true);
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
        /// 完成订单
        /// </summary>
        /// <param name="updateListDto"></param>
        /// <returns></returns>
        public async Task FinishOrderAsync(string orderId)
        {
            try
            {
                var orderInfo = await dalOrderInfo.GetAll().FirstOrDefaultAsync(e => e.Id == orderId);
                if (orderInfo == null)
                { throw new Exception("未找到该订单，完成订单失败！"); }
                orderInfo.StatusCode = OrderStatusCode.TRADE_FINISHED;
                if (!orderInfo.WriteOffDate.HasValue)
                { throw new Exception("该订单暂无核销时间，无法分配医院！请先在下单平台订单列表中校对订单或者在派单列表中完成订单后操作，若无法校对订单，请联系管理员"); }
                orderInfo.UpdateDate = DateTime.Now;
                await dalOrderInfo.UpdateAsync(orderInfo, true);

                await _bindCustomerService.UpdateConsumePriceAsync(orderInfo.Phone, 0, (int)OrderFrom.ThirdPartyOrder, 0);
            }
            catch (Exception e)
            {
                throw e;
            }
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
                var order = await dalOrderInfo.GetAll().Where(x => x.Id == input.Id).SingleOrDefaultAsync();
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
                await dalOrderInfo.UpdateAsync(order, true);

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
                var order = await dalOrderInfo.GetAll().Where(x => x.Id == input.OrderId).SingleOrDefaultAsync();
                if (order == null)
                {
                    throw new Exception("未找到该订单的相关信息！");
                }
                order.IsReturnBackPrice = true;
                order.ReturnBackPrice = input.ReturnBackPrice;
                order.ReturnBackDate = input.ReturnBackDate;
                await dalOrderInfo.UpdateAsync(order, true);

                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
            }
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
            var orderInfo = await dalOrderInfo.GetAll()
                .SingleOrDefaultAsync(e => e.Id == id);
            await dalOrderInfo.DeleteAsync(orderInfo, true);


        }

        /// <summary>
        /// 修改交易信息
        /// </summary>
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



        /// <summary>
        /// 获取超时未支付阿美雅订单列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrderInfoSimpleDto>> TimeOutOrderAsync()
        {
            DateTime date = DateTime.Now;


            var orders = from d in dalOrderInfo.GetAll()
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
                             Quantity = d.Quantity.Value,
                             IsUseCoupon = d.IsUseCoupon,
                             CouponId = d.CouponId
                         };

            return await orders.ToListAsync();

        }





        /// <summary>
        /// 根据客户编号获取未领取礼品的订单列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<List<OrderInfoSimpleDto>> GetUnReceiveGiftOrderListByCustomerIdAsync(string customerId)
        {
            var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == customerId);

            var order = from d in dalOrderInfo.GetAll()
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
        /// 获取核销好礼接口数据订单
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<OrderInfoSimpleDto>> GetReceiveGiftOrderListByCustomerIdAsync(string customerId, int pageNum, int pageSize)
        {
            var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == customerId);
            List<OrderInfoSimpleDto> orderInfoSimpleResult = new List<OrderInfoSimpleDto>();
            int orderReceiveGiftCount = 0;
            var order = from d in dalOrderInfo.GetAll().OrderByDescending(x => x.CreateDate)
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
        /// 根据客户编号获取已购买订单列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="ExchangeType"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<OrderInfoSimpleDto>> GetAlreadyBuyOrderListAsync(string customerId, int ExchangeType, int pageNum, int pageSize)
        {
            List<OrderInfoSimpleDto> orderInfoSimpleResult = new List<OrderInfoSimpleDto>();
            var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == customerId);
            var order = from d in dalOrderInfo.GetAll()
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
            var result = from d in order
                         where d.ExchangeType == 0
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
            orderInfoSimpleResult.AddRange(await result.ToListAsync());
            var result2 = from d in order
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
            orderInfoSimpleResult.AddRange(await result2.ToListAsync());

            var orderAlreadyBuyList = orderInfoSimpleResult.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            FxPageInfo<OrderInfoSimpleDto> OrderAlreadyBuyInfoList = new FxPageInfo<OrderInfoSimpleDto>();
            OrderAlreadyBuyInfoList.TotalCount = orderInfoSimpleResult.Count;
            OrderAlreadyBuyInfoList.List = orderAlreadyBuyList;
            return OrderAlreadyBuyInfoList;
        }




        /// <summary>
        /// 获取总订单数量
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTotalOrderQuantityAsync(int employeeId)
        {
            var order = from d in dalOrderInfo.GetAll()
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
        /// 获取今日新增订单数量
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTodayIncrementQuantityAsync(int employeeId)
        {
            DateTime date = DateTime.Now;
            var order = from d in dalOrderInfo.GetAll()
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
        /// 获取今日新增订单数量
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTodayIncrementQuantityAsync()
        {
            DateTime date = DateTime.Now;
            var order = from d in dalOrderInfo.GetAll()
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

        /// <summary>
        /// 获取今日核销订单数量
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTodayWriteOffQuantityAsync()
        {
            DateTime date = DateTime.Now;
            var order = from d in dalOrderInfo.GetAll()
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
        /// 获取今日关闭订单数量
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTodayClosedQuantityAsync()
        {
            DateTime date = DateTime.Now;
            var order = from d in dalOrderInfo.GetAll()
                        where ((DateTime)d.UpdateDate).Date == date.Date
                        && (d.StatusCode == "TRADE_CLOSED_BY_TAOBAO" || d.StatusCode == "TRADE_CLOSED")
                        select d;
            int quantity = await order.CountAsync();
            return quantity;
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

            var quantity = await dalOrderInfo.GetAll().CountAsync(e => phoneList.Contains(e.Phone) == false);
            return quantity;
        }



        /// <summary>
        /// 获取未派单订单数量
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetUnSendOrderQuantityAsync(int employeeId)
        {
            var order = from d in dalOrderInfo.GetAll()
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
                orderStatusData = from d in dalOrderInfo.GetAll()
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
                orderStatusData = from d in dalOrderInfo.GetAll()
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
        /// 获取最新订单状态改变时间
        /// </summary>
        /// <returns></returns>
        public async Task<DateTime?> GetLatelyStatusChangeDateAsync(int employeeId)
        {
            DateTime date = DateTime.Now;

            var orders = from d in dalOrderInfo.GetAll()
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



        /// <summary>
        /// 获取今天新增订单
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<OrderInfoDto>> GetTodayIncrementListAsync(int pageNum, int pageSize)
        {
            DateTime date = DateTime.Now;
            var orders = from d in dalOrderInfo.GetAll()
                         select d;


            var config = await _wxAppConfigService.GetCallCenterConfig();
            var order = from d in orders
                        where ((DateTime)d.CreateDate).Date == date.Date
                        select new OrderInfoDto
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

            FxPageInfo<OrderInfoDto> orderPageInfo = new FxPageInfo<OrderInfoDto>();
            orderPageInfo.TotalCount = await order.CountAsync();
            orderPageInfo.List = await order.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return orderPageInfo;
        }



        /// <summary>
        /// 获取今日订单状态发生改变的订单列表
        /// </summary>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<OrderInfoDto>> GetTodayStatusChangeListAsync(int employeeId, string keyword, string statusCode, int pageNum, int pageSize)
        {
            DateTime date = DateTime.Now;
            var orders = from d in dalOrderInfo.GetAll()
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

                            select new OrderInfoDto
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

            FxPageInfo<OrderInfoDto> orderPageInfo = new FxPageInfo<OrderInfoDto>();
            orderPageInfo.TotalCount = await orderInfo.CountAsync();
            orderPageInfo.List = await orderInfo.OrderByDescending(e => e.UpdateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return orderPageInfo;
        }





        public async Task<FxPageInfo<OrderInfoDto>> GetOrderByEmployeeIdAsync(int employeeId, string statusCode, string keyword, int pageNum, int pageSize)
        {
            var orders = from d in dalOrderInfo.GetAll()
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
                            select new OrderInfoDto
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
            FxPageInfo<OrderInfoDto> orderPageInfo = new FxPageInfo<OrderInfoDto>();
            orderPageInfo.TotalCount = await orderInfo.CountAsync();
            orderPageInfo.List = await orderInfo.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return orderPageInfo;
        }



        /// <summary>
        /// 根据订单编号获取订单信息(小程序用)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OrderInfoDto> GetByIdAsync(string id)
        {
            var config = await _wxAppConfigService.GetCallCenterConfig();
            var order = await dalOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);
            if (order == null)
                throw new Exception("订单编号错误");
            if (order.StatusCode == "SEEK_ADVICE")
                throw new Exception("该订单为咨询订单，无法展示！");
            if (order.StatusCode == "BARGAIN_MONEY")
                throw new Exception("该订单为定金订单，无法展示！");

            OrderInfoDto orderInfo = new OrderInfoDto();
            orderInfo.Id = order.Id;
            orderInfo.GoodsName = order.GoodsName;
            orderInfo.GoodsId = order.GoodsId;
            orderInfo.ThumbPicUrl = order.ThumbPicUrl;
            orderInfo.BuyerNick = order.BuyerNick;
            orderInfo.Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(order.Phone) : order.Phone;
            orderInfo.EncryptPhone = ServiceClass.Encrypt(order.Phone, config.PhoneEncryptKey);
            orderInfo.AppointmentDate = order.AppointmentDate;
            orderInfo.AppointmentCity = order.AppointmentCity;
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
            orderInfo.IsUseCoupon = order.IsUseCoupon;
            orderInfo.DeductMoney = order.DeductMoney;
            return orderInfo;

        }


        /// <summary>
        /// 根据订单编号获取订单信息(crm系统用)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OrderInfoDto> GetByIdInCRMAsync(string id)
        {
            var config = await _wxAppConfigService.GetCallCenterConfig();
            var order = await dalOrderInfo.GetAll().Include(x => x.SendOrderInfoList).SingleOrDefaultAsync(e => e.Id == id);
            if (order == null)
                throw new Exception("订单编号错误");

            OrderInfoDto orderInfo = new OrderInfoDto();
            orderInfo.Id = order.Id;
            orderInfo.GoodsName = order.GoodsName;
            orderInfo.GoodsId = order.GoodsId;
            orderInfo.ThumbPicUrl = order.ThumbPicUrl;
            orderInfo.BuyerNick = order.BuyerNick;
            orderInfo.Phone = order.Phone;
            orderInfo.EncryptPhone = ServiceClass.Encrypt(order.Phone, config.PhoneEncryptKey);
            var bindCustomerServiceInfo = await _bindCustomerService.GetEmployeeDetailsByPhoneAsync(order.Phone);
            orderInfo.UserId = bindCustomerServiceInfo.UserId;
            orderInfo.AppointmentCity = order.AppointmentCity;
            orderInfo.AppointmentDate = order.AppointmentDate;
            orderInfo.AppointmentHospital = order.AppointmentHospital;
            orderInfo.IsAppointment = order.IsAppointment;
            orderInfo.StatusCode = order.StatusCode;
            orderInfo.StatusText = ServiceClass.GetOrderStatusText(order.StatusCode);
            orderInfo.ActualPayment = order.ActualPayment;
            orderInfo.CreateDate = order.CreateDate;
            orderInfo.UpdateDate = order.UpdateDate;
            orderInfo.OrderType = order.OrderType;
            orderInfo.OrderTypeText = order.OrderType.HasValue ? ServiceClass.GetOrderTypeText(order.OrderType.Value) : "虚拟订单";
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
        /// 修改京东退款成功的订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateRefundOfJdAsync(string id)
        {
            var order = await dalOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);

            if (order == null)
                throw new Exception("订单编号错误");

            if (order.AppType != (byte)AppType.JD)
                throw new Exception("该订单不是京东订单");

            order.StatusCode = OrderStatusCode.TRADE_CLOSED;
            await dalOrderInfo.UpdateAsync(order, true);
        }
        /// <summary>
        /// 更改订单状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        public async Task UpdateOrderStatus(string orderId, string orderStatus)
        {
            var order = dalOrderInfo.GetAll().Where(e => e.Id == orderId).FirstOrDefault();
            order.StatusCode = orderStatus;
            await dalOrderInfo.UpdateAsync(order, true);
        }

        /// <summary>
        /// 获取所有已核销客户注册过小程序的订单
        /// </summary>
        /// <returns></returns>
        public async Task<List<CustomerOrderDto>> GetCustomerTradeFinishOrderListAsync()
        {
            var orders = from d in dalOrderInfo.GetAll()
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
        /// 根据客户编号获取已核销订单
        /// </summary>
        /// <returns></returns>
        public async Task<List<CustomerOrderDto>> GetTradeFinishOrderListByCustomerIdAsync(string customerId)
        {
            var orders = from d in dalOrderInfo.GetAll()
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




        /// <summary>
        /// 根据订单编号获取客户订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<CustomerOrderDto> GetOrderByIdAsync(string orderId)
        {
            var order = from d in dalOrderInfo.GetAll()
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



        /// <summary>
        /// 根据客户编号获取订单列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="statusCode"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<OrderTradeForWxDto>> GetOrderListForAmiyaByCustomerId(string customerId, string statusCode, int pageNum, int pageSize)
        {
            var orders = from d in dalOrderTrade.GetAll()
                         .Include(e => e.OrderInfoList)
                         where d.CustomerId == customerId
                         && (string.IsNullOrWhiteSpace(statusCode) || (d.StatusCode == statusCode && d.OrderInfoList.Count(e => e.AppType == (byte)AppType.MiniProgram) > 0))
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
                             OrderInfoList = (from o in d.OrderInfoList
                                              select new OrderInfoDto
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
                                                  IsUseCoupon = o.IsUseCoupon,
                                                  DeductMoney = o.DeductMoney
                                              }).ToList()
                         };
            FxPageInfo<OrderTradeForWxDto> orderTradePageInfo = new FxPageInfo<OrderTradeForWxDto>();
            orderTradePageInfo.TotalCount = await orders.CountAsync();
            orderTradePageInfo.List = await orders.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return orderTradePageInfo;
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
            orderTradeDto.OrderInfoList = (from o in orderTrade.OrderInfoList
                                           select new OrderInfoDto
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
                                               IsUseCoupon = o.IsUseCoupon,
                                               CouponId = o.CouponId,
                                               DeductMoney = o.DeductMoney
                                           }).ToList();
            return orderTradeDto;
        }



        /// <summary>
        /// 获取小程序实物订单交易列表
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="isSendGoods">是否已发货</param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<OrderTradeDto>> GetMiniProgramMaterialOrderTradeList(DateTime startDate, DateTime endDate, int employeeId, bool? isSendGoods, string keyword, int pageNum, int pageSize)
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
            var orderTrades = from d in dalOrderTrade.GetAll()
                              where d.OrderInfoList.Count(e => e.AppType == (byte)AppType.MiniProgram && e.OrderType == (byte)OrderType.MaterialOrder) > 0
                              && (string.IsNullOrWhiteSpace(keyword) || d.CustomerInfo.Phone == keyword)
                              && (d.CreateDate >= startDate && d.CreateDate <= endDate)
                              select d;

            if (isSendGoods == null)
            {
                orderTrades = from d in orderTrades
                              where d.StatusCode == OrderStatusCode.TRADE_FINISHED
                              || d.StatusCode == OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS
                              || d.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS
                              select d;
            }
            else if (isSendGoods == true)
            {
                orderTrades = from d in orderTrades
                              where d.StatusCode == OrderStatusCode.TRADE_FINISHED
                              || d.StatusCode == OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS
                              select d;
            }
            else
            {
                orderTrades = from d in orderTrades
                              where d.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS
                              select d;
            }

            var orderTradeList = from d in orderTrades
                                 select new OrderTradeDto
                                 {
                                     TradeId = d.TradeId,
                                     CustomerId = d.CustomerId,
                                     Phone = hidePhone == true ? ServiceClass.GetIncompletePhone(d.CustomerInfo.Phone) : d.CustomerInfo.Phone,
                                     CreateDate = d.CreateDate,
                                     UpdateDate = d.UpdateDate,
                                     TotalAmount = d.TotalAmount,
                                     TotalIntegration = d.TotalIntegration,
                                     Remark = d.Remark,
                                     StatusCode = d.StatusCode,
                                     StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                                     OrderIdsList = d.OrderInfoList.Select(x => x.Id).ToList(),
                                     Quantities = d.OrderInfoList.Sum(x => x.Quantity).Value,
                                     IntergrationAccounts = d.OrderInfoList.Sum(x => x.IntegrationQuantity).Value,
                                     GoodsList = d.OrderInfoList.Select(x => x.GoodsName).ToList(),
                                     AddressId = d.AddressId,
                                     Address = d.Address.Province + d.Address.City + d.Address.District + d.Address.Other,
                                     ReceiveName = d.Address.Contact,
                                     ReceivePhone = hidePhone == true ? ServiceClass.GetIncompletePhone(d.Address.Phone) : d.Address.Phone,
                                     SendGoodsBy = d.SendGoodsRecord.HandleBy,
                                     SendGoodsName = d.SendGoodsRecord.AmiyaEmployee.Name,
                                     SendGoodsDate = d.SendGoodsRecord.Date,
                                     CourierNumber = d.SendGoodsRecord.CourierNumber,
                                     ExpressId = d.SendGoodsRecord.ExpressId
                                 };
            FxPageInfo<OrderTradeDto> orderTradePageInfo = new FxPageInfo<OrderTradeDto>();
            orderTradePageInfo.TotalCount = await orderTradeList.CountAsync();
            orderTradePageInfo.List = await orderTradeList.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            foreach (var x in orderTradePageInfo.List)
            {
                if (x.OrderIdsList.Count > 0)
                {
                    foreach (var z in x.OrderIdsList)
                    {
                        x.OrderIds += z + ",";
                    }
                    x.OrderIds = x.OrderIds.Substring(0, x.OrderIds.Length - 1);
                }
                if (x.GoodsList.Count > 0)
                {
                    foreach (var y in x.GoodsList)
                    {
                        x.GoodsName += y + ",";
                    }
                    x.GoodsName = x.GoodsName.Substring(0, x.GoodsName.Length - 1);
                }
            }
            return orderTradePageInfo;
        }

        /// <summary>
        /// 导出小程序实物订单交易列表
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="isSendGoods">是否已发货</param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<OrderTradeDto>> ExportMiniProgramMaterialOrderTradeList(DateTime startDate, DateTime endDate, int employeeId, bool? isSendGoods, string keyword)
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
            var orderTrades = from d in dalOrderTrade.GetAll()
                              where d.OrderInfoList.Count(e => e.AppType == (byte)AppType.MiniProgram && e.OrderType == (byte)OrderType.MaterialOrder) > 0
                              && (string.IsNullOrWhiteSpace(keyword) || d.CustomerInfo.Phone == keyword)
                              && (d.CreateDate >= startDate && d.CreateDate <= endDate)
                              select d;

            if (isSendGoods == null)
            {
                orderTrades = from d in orderTrades
                              where d.StatusCode == OrderStatusCode.TRADE_FINISHED
                              || d.StatusCode == OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS
                              || d.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS
                              select d;
            }
            else if (isSendGoods == true)
            {
                orderTrades = from d in orderTrades
                              where d.StatusCode == OrderStatusCode.TRADE_FINISHED
                              || d.StatusCode == OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS
                              select d;
            }
            else
            {
                orderTrades = from d in orderTrades
                              where d.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS
                              select d;
            }

            var orderTradeList = from d in orderTrades
                                 select new OrderTradeDto
                                 {
                                     TradeId = d.TradeId,
                                     CustomerId = d.CustomerId,
                                     Phone = hidePhone == true ? ServiceClass.GetIncompletePhone(d.CustomerInfo.Phone) : d.CustomerInfo.Phone,
                                     CreateDate = d.CreateDate,
                                     UpdateDate = d.UpdateDate,
                                     TotalAmount = d.TotalAmount,
                                     TotalIntegration = d.TotalIntegration,
                                     Remark = d.Remark,
                                     StatusCode = d.StatusCode,
                                     StatusText = ServiceClass.GetOrderStatusText(d.StatusCode),
                                     AddressId = d.AddressId,
                                     OrderIdsList = d.OrderInfoList.Select(x => x.Id).ToList(),
                                     Quantities = d.OrderInfoList.Sum(x => x.Quantity).Value,
                                     IntergrationAccounts = d.OrderInfoList.Sum(x => x.IntegrationQuantity).Value,
                                     GoodsList = d.OrderInfoList.Select(x => x.GoodsName).ToList(),
                                     Address = d.Address.Province + d.Address.City + d.Address.District + d.Address.Other,
                                     ReceiveName = d.Address.Contact,
                                     ReceivePhone = hidePhone == true ? ServiceClass.GetIncompletePhone(d.Address.Phone) : d.Address.Phone,
                                     SendGoodsBy = d.SendGoodsRecord.HandleBy,
                                     SendGoodsName = d.SendGoodsRecord.AmiyaEmployee.Name,
                                     SendGoodsDate = d.SendGoodsRecord.Date,
                                     CourierNumber = d.SendGoodsRecord.CourierNumber,
                                     ExpressId = d.SendGoodsRecord.ExpressId
                                 };
            List<OrderTradeDto> orderTradePageInfo = new List<OrderTradeDto>();
            orderTradePageInfo = await orderTradeList.OrderByDescending(e => e.CreateDate).ToListAsync();
            foreach (var x in orderTradePageInfo)
            {
                if (x.OrderIdsList.Count > 0)
                {
                    foreach (var z in x.OrderIdsList)
                    {
                        x.OrderIds += z + ",";
                    }
                    x.OrderIds = x.OrderIds.Substring(0, x.OrderIds.Length - 1);
                }
                if (x.GoodsList.Count > 0)
                {
                    foreach (var y in x.GoodsList)
                    {
                        x.GoodsName += y + ",";
                    }
                    x.GoodsName = x.GoodsName.Substring(0, x.GoodsName.Length - 1);
                }
            }
            return orderTradePageInfo;
        }




        /// <summary>
        /// 根据交易编号获取订单列表
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        public async Task<List<OrderInfoDto>> GetListByTradeIdAsync(int employeeId, string tradeId)
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

            var orders = from d in dalOrderInfo.GetAll()
                         where d.TradeId == tradeId
                         select new OrderInfoDto
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

                var orderTrade = await dalOrderTrade.GetAll().Include(e => e.OrderInfoList).SingleOrDefaultAsync(e => e.TradeId == sendGoodsDto.TradeId);
                if (orderTrade == null)
                    throw new Exception("交易编号错误");

                var sendGoodsRecord = await dalSendGoodsRecord.GetAll().SingleOrDefaultAsync(e => e.TradeId == sendGoodsDto.TradeId);
                if (sendGoodsRecord != null)
                    throw new Exception("该交易已发货，请勿重复操作");

                DateTime date = DateTime.Now;
                foreach (var item in orderTrade.OrderInfoList)
                {
                    item.StatusCode = OrderStatusCode.WAIT_BUYER_CONFIRM_GOODS;
                    item.UpdateDate = date;
                    await dalOrderInfo.UpdateAsync(item, true);
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

        /// <summary>
        /// 根据电话号获取已核销的总金额
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public async Task<decimal> GetTradeFinishAmountByPhoneAsync(string phone)
        {
            var amount = await dalOrderInfo.GetAll().Where(e => e.Phone == phone && e.StatusCode == OrderStatusCode.TRADE_FINISHED).SumAsync(e => e.ActualPayment);
            return (decimal)amount;
        }

        public async Task<WxPayRequestInfo> BuildPayRequest(WxPackageInfo packageInfo)
        {
            WxPayRequestInfo payRequestInfo = new WxPayRequestInfo();
            payRequestInfo.appId = this._payAccount.AppId;
            payRequestInfo.package = await BuildPackage(packageInfo);
            payRequestInfo.timeStamp = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            payRequestInfo.nonceStr = Guid.NewGuid().ToString("N");
            SignHelper signHelper = new SignHelper();
            payRequestInfo.paySign = await signHelper.SignPay(new PayDictionary
            {
                {
                    "appId",
                    this._payAccount.AppId
                },
                {
                    "timeStamp",
                    payRequestInfo.timeStamp
                },
                {
                    "package",
                    payRequestInfo.package
                },
                {
                    "nonceStr",
                    payRequestInfo.nonceStr
                },
                {
                    "signType",
                    "MD5"
                }
            }, this._payAccount.PartnerKey);
            return payRequestInfo;
        }

        public bool CheckVxSetParams(out string errmsg)
        {
            errmsg = "";
            bool flag = true;
            bool result;
            if (this._payAccount == null)
            {
                flag = false;
                errmsg = "微信支付参数未初始化！";
            }
            else if (!this._payAccount.EnableSP)
            {
                if (string.IsNullOrEmpty(this._payAccount.AppId) || this._payAccount.AppId.Length < 15)
                {
                    errmsg = "商户公众号未正确配置！";
                    result = false;
                    return result;
                }
                if (string.IsNullOrEmpty(this._payAccount.PartnerId) || this._payAccount.PartnerId.Length < 8)
                {
                    errmsg = "商户号未正确配置！";
                    result = false;
                    return result;
                }
                if (string.IsNullOrEmpty(this._payAccount.PartnerKey) || this._payAccount.PartnerKey.Length < 8)
                {
                    errmsg = "商户KEY未正确配置！";
                    result = false;
                    return result;
                }
                if (string.IsNullOrEmpty(this._payAccount.AppSecret) || this._payAccount.AppSecret.Length < 8)
                {
                    errmsg = "公众号AppSecret未正确配置！";
                    result = false;
                    return result;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(this._payAccount.AppId) || this._payAccount.AppId.Length < 15)
                {
                    errmsg = "服务商公众号未正确配置！";
                    result = false;
                    return result;
                }
                if (string.IsNullOrEmpty(this._payAccount.PartnerId) || this._payAccount.PartnerId.Length < 8)
                {
                    errmsg = "服务商商户号未正确配置！";
                    result = false;
                    return result;
                }
                if (string.IsNullOrEmpty(this._payAccount.PartnerKey) || this._payAccount.PartnerKey.Length < 8)
                {
                    errmsg = "服务商KEY未正确配置！";
                    result = false;
                    return result;
                }
                if (string.IsNullOrEmpty(this._payAccount.AppSecret) || this._payAccount.AppSecret.Length < 8)
                {
                    errmsg = "公众号AppSecret未正确配置！";
                    result = false;
                    return result;
                }
                if (string.IsNullOrEmpty(this._payAccount.Sub_appid) || this._payAccount.Sub_appid.Length < 8)
                {
                    errmsg = "商户公众号未正确配置！";
                    result = false;
                    return result;
                }
                if (string.IsNullOrEmpty(this._payAccount.Sub_mch_id) || this._payAccount.Sub_mch_id.Length < 8)
                {
                    errmsg = "子商户号未正确配置！";
                    result = false;
                    return result;
                }
            }
            result = flag;
            return result;
        }

        public bool CheckVxPackage(WxPackageInfo package, out string errmsg)
        {
            bool flag = true;
            errmsg = "";
            bool result;
            if (string.IsNullOrEmpty(package.NotifyUrl) || package.NotifyUrl.Length < 5)
            {
                errmsg = "返回地址NotifyUrl未配置！";
                result = false;
            }
            else if (string.IsNullOrEmpty(package.OpenId) || package.OpenId.Length < 8)
            {
                errmsg = "用户OPENID不正确！";
                result = false;
            }
            else if (string.IsNullOrEmpty(package.OutTradeNo))
            {
                errmsg = "交易订单号不能为空";
                result = false;
            }
            else if (package.TotalFee == 0m)
            {
                errmsg = "支付金额不能为零";
                result = false;
            }
            else
            {
                result = flag;
            }
            return result;
        }

        public async Task<string> BuildPackage(WxPackageInfo package)
        {
            PayDictionary payDictionary = new PayDictionary();
            payDictionary.Add("appid", this._payAccount.AppId);
            payDictionary.Add("mch_id", this._payAccount.PartnerId);
            if (this._payAccount.EnableSP)
            {
                payDictionary.Add("sub_appid", this._payAccount.Sub_appid);
                payDictionary.Add("sub_mch_id", this._payAccount.Sub_mch_id);
                payDictionary.Add("sub_openid", package.OpenId);
            }
            else
            {
                payDictionary.Add("openid", package.OpenId);
            }
            payDictionary.Add("device_info", "");
            payDictionary.Add("nonce_str", Guid.NewGuid().ToString("N"));
            payDictionary.Add("body", package.Body);
            payDictionary.Add("attach", "");
            payDictionary.Add("out_trade_no", package.OutTradeNo);
            payDictionary.Add("total_fee", (int)package.TotalFee);
            payDictionary.Add("spbill_create_ip", package.SpbillCreateIp);
            payDictionary.Add("time_start", package.TimeExpire);
            payDictionary.Add("time_expire", "");
            payDictionary.Add("goods_tag", package.GoodsTag);
            payDictionary.Add("notify_url", package.NotifyUrl);
            payDictionary.Add("trade_type", "JSAPI");
            payDictionary.Add("product_id", "");
            SignHelper signHelper = new SignHelper();
            string sign = await signHelper.SignPackage(payDictionary, this._payAccount.PartnerKey);
            string text = await this.GetPrepay_id(payDictionary, sign);
            if (text.Length > 64)
            {
                text = "";
            }
            return string.Format("prepay_id=" + text, new object[0]);
        }
        public async Task<string> GetPrepay_id(PayDictionary dict, string sign)
        {
            dict.Add("sign", sign);
            SignHelper signHelper = new SignHelper();
            string text = await signHelper.BuildQueryAsync(dict, false);
            string postData = await signHelper.BuildXmlAsync(dict, false);
            string prepay_id_Url = "https://api.mch.weixin.qq.com/pay/unifiedorder";
            return this.PostData(prepay_id_Url, postData);
        }
        /// <summary>
        /// 根据交易id更改订单状态
        /// </summary>
        /// <param name="tradeId"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public async Task UpdateStatusByTradeIdAsync(string tradeId, string statusCode)
        {
            var trade = await dalOrderTrade.GetAll().Where(e => e.TradeId == tradeId).Include(e => e.OrderInfoList).SingleOrDefaultAsync();
            if (trade == null)
            {
                throw new Exception("交易编号错误");
            }
            trade.StatusCode = statusCode;
            await dalOrderTrade.UpdateAsync(trade, true);
            foreach (var item in trade.OrderInfoList)
            {
                item.StatusCode = statusCode;
                await dalOrderInfo.UpdateAsync(item, true);
            }
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
                var orderInfo = await dalOrderInfo.GetAll().FirstOrDefaultAsync(e => e.Id == orderId);
                if (orderInfo == null)
                {
                    throw new Exception("未找到相关订单！");
                }
                //验证订单是否派单
                var sendOrderInfoList = await _sendOrderInfoService.GetSendOrderInfoByOrderId(orderId);
                if (orderInfo.StatusCode != OrderStatusCode.TRADE_BUYER_PAID)
                {
                    if (sendOrderInfoList.Count == 0)
                    {
                        throw new Exception("该订单未派单，无法核销！");
                    }
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
                await dalOrderInfo.UpdateAsync(orderInfo, true);

                //修改订单trade信息
                await this.UpdateStatusByTradeIdAsync(orderInfo.TradeId, OrderStatusCode.TRADE_FINISHED);

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

                var findInfo = await _bindCustomerService.GetEmployeeIdByPhone(orderInfo.Phone);
                if (findInfo != 0)
                {
                    await _bindCustomerService.UpdateConsumePriceAsync(orderInfo.Phone, 0, (int)OrderFrom.ThirdPartyOrder, 0);
                }
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }


        public async Task UpdateOrderFinalConsumptionHospital(string orderId, int hospitalId)
        {
            var orderInfo = await dalOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == orderId);
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
            await dalOrderInfo.UpdateAsync(orderInfo, true);
        }


        public async Task<OrderExpressInfoDto> GetOrderExpressInfoAsync(string tradeId)
        {
            var sendGoodsRecordInfoList = await dalSendGoodsRecord.GetAll().ToListAsync();
            var sendGoodsRecordInfo = sendGoodsRecordInfoList.Where(x => x.TradeId == tradeId).FirstOrDefault();
            if (sendGoodsRecordInfo == null)
            {
                throw new Exception("未找到该交易编号！");
            }
            var orderList = from d in dalOrderInfo.GetAll()
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
        /// 获取下级订单
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<SubordinateOrderDto>> GetSubordinateOrder(string customerId, int pageNum, int pageSize)
        {
            List<SubordinateOrderDto> orderInfoSimpleResult = new List<SubordinateOrderDto>();
            var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == customerId);
            var order = from d in dalOrderInfo.GetAll()
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
            var result2 = from d in order
                          where d.ExchangeType != 0
                          select new SubordinateOrderDto
                          {
                              GoodsImgUrl = d.ThumbPicUrl,
                              GoodsName = d.GoodsName,
                              Price = d.ActualPayment.Value,
                              OrderDate = d.CreateDate.Value,
                              StatusCodeText = ServiceClass.GetOrderStatusText(d.StatusCode),
                          };
            orderInfoSimpleResult.AddRange(await result2.ToListAsync());

            var orderAlreadyBuyList = orderInfoSimpleResult.OrderByDescending(e => e.OrderDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            FxPageInfo<SubordinateOrderDto> OrderAlreadyBuyInfoList = new FxPageInfo<SubordinateOrderDto>();
            OrderAlreadyBuyInfoList.TotalCount = orderInfoSimpleResult.Count;
            OrderAlreadyBuyInfoList.List = orderAlreadyBuyList;
            return OrderAlreadyBuyInfoList;
        }
        /// <summary>
        /// 根据phone获取订单id列表
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public async Task<List<string>> GetOrderIdListByPhone(string phone)
        {
            return await dalOrderInfo.GetAll().Where(e => e.Phone == phone).Select(e => e.Id).ToListAsync();
        }



        #region 报表相关
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="statusCode"></param>
        /// <param name="employeeId"></param>
        /// <param name="isHidePhone"></param>
        /// <returns></returns>
        public async Task<List<OrderInfoDto>> GetTmallOrderListAsync(DateTime? startDate, DateTime? endDate, string statusCode, int employeeId, bool isHidePhone)
        {
            try
            {
                var orders = from d in dalOrderInfo.GetAll()
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
                            select new OrderInfoDto
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


                List<OrderInfoDto> orderInfo = new List<OrderInfoDto>();
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
        public async Task<List<OrderOperationConditionDto>> GetOrderOperationConditionAsync(DateTime? startDate, DateTime? endDate)
        {
            var orders = from d in dalOrderInfo.GetAll()
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

        public async Task<List<BuyOrderReportDto>> GetOrderBuyAsync(DateTime? startDate, DateTime? endDate, int belongEmpId, bool isHidePhone)
        {
            var orders = from d in dalOrderInfo.GetAll()
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

        public async Task<List<BuyOrderReportDto>> GetOrderCloseAsync(DateTime? startDate, DateTime? endDate, bool isHidePhone)
        {
            var orders = from d in dalOrderInfo.GetAll()
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

        public async Task<List<OrderWriteOffDto>> GetOrderWriteOffAsync(DateTime? startDate, DateTime? endDate, bool isHidePhone)
        {
            var orders = from d in dalOrderInfo.GetAll()
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

        public async Task<List<OrderWriteOffDto>> GetCustomerOrderReceivableAsync(DateTime? startDate, DateTime? endDate, int? appType, int? CheckState, bool? ReturnBackPriceState, string customerName, bool isHidePhone)
        {
            var orders = from d in dalOrderInfo.GetAll()
                         where (d.StatusCode == OrderStatusCode.TRADE_FINISHED)
                         && d.OrderType == (byte)OrderType.VirtualOrder
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
            if (appType.HasValue)
            {
                orders = from d in orders
                         where d.AppType == appType.Value
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

        public async Task<List<OrderWriteOffDto>> GetCustomerPaidOrderReceivableAsync(DateTime? startDate, DateTime? endDate, int? CheckState, bool? ReturnBackPriceState, string customerName, bool isHidePhone)
        {
            var orders = from d in dalOrderInfo.GetAll()
                         where (d.StatusCode == OrderStatusCode.TRADE_BUYER_PAID)
                         && d.OrderType == (byte)OrderType.VirtualOrder
                         select d;

            if (startDate != null && endDate != null)
            {
                DateTime startrqWriteOff = ((DateTime)startDate);
                DateTime endrqWriteOff = ((DateTime)endDate).Date.AddDays(1);
                orders = from d in orders
                         where d.UpdateDate >= startrqWriteOff && d.UpdateDate < endrqWriteOff
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
        #endregion



        #region 内部方法

        /// <summary>
        /// 微信支付帮助方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        internal string PostData(string url, string postData)
        {
            string text = string.Empty;
            string result;
            try
            {
                Uri requestUri = new Uri(url);
                HttpWebRequest httpWebRequest;
                if (url.ToLower().StartsWith("https"))
                {
                    ServicePointManager.ServerCertificateValidationCallback = ((object s, X509Certificate c, X509Chain ch, SslPolicyErrors e) => true);
                    httpWebRequest = (HttpWebRequest)WebRequest.CreateDefault(requestUri);
                }
                else
                {
                    httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);
                }
                Encoding uTF = Encoding.UTF8;
                byte[] bytes = uTF.GetBytes(postData);
                httpWebRequest.Method = "POST";
                httpWebRequest.KeepAlive = true;
                Stream requestStream = httpWebRequest.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                requestStream.Dispose();
                using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using (Stream responseStream = httpWebResponse.GetResponseStream())
                    {
                        Encoding uTF2 = Encoding.UTF8;
                        StreamReader streamReader = new StreamReader(responseStream, uTF2);
                        text = streamReader.ReadToEnd();
                        XmlDocument xmlDocument = new XmlDocument();
                        try
                        {
                            xmlDocument.LoadXml(text);
                        }
                        catch (Exception ex)
                        {
                            text = string.Format("获取信息错误doc.load：{0}", ex.Message) + text;
                        }
                        try
                        {
                            if (xmlDocument == null)
                            {
                                result = text;
                                return result;
                            }
                            XmlNode xmlNode = xmlDocument.SelectSingleNode("xml/return_code");
                            if (xmlNode == null)
                            {
                                result = text;
                                return result;
                            }
                            if (xmlNode.InnerText == "SUCCESS")
                            {
                                XmlNode xmlNode2 = xmlDocument.SelectSingleNode("xml/prepay_id");
                                if (xmlNode2 != null)
                                {
                                    result = xmlNode2.InnerText;
                                    return result;
                                }
                            }
                            else
                            {
                                XmlNode xmlNode3 = xmlDocument.SelectSingleNode("xml/return_msg");
                                if (xmlNode3 != null)
                                {
                                    result = xmlNode3.InnerText;
                                    return result;
                                }
                                result = xmlDocument.InnerXml;
                                return result;
                            }
                        }
                        catch (Exception ex)
                        {
                            text = string.Format("获取信息错误node.load：{0}", ex.Message) + text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                text = string.Format("获取信息错误post error：{0}", ex.Message) + text;
            }
            result = text;
            return result;
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
        /// 发送手机号方法
        /// </summary>
        /// <param name="orderPhoneDict"></param>
        /// <param name="appType"></param>
        /// <param name="intergrationQuantity"></param>
        private async void SendPhoneInfo(Dictionary<string, string> orderPhoneDict, byte appType, decimal intergrationQuantity)
        {
            if (orderPhoneDict.Count > 0)
            {
                if (appType == (byte)AppType.MiniProgram && intergrationQuantity > 0)
                {
                    string templateName = "order_intergrationpay_commit";
                    foreach (var z in orderPhoneDict)
                    {
                        await _smsSender.SendSingleAsync(z.Value, templateName, JsonConvert.SerializeObject(new { orderId = z.Key }));
                    }
                }
                else
                {
                    string templateName = "order_buyerpay_commit";
                    foreach (var z in orderPhoneDict)
                    {
                        await _smsSender.SendSingleAsync(z.Value, templateName, JsonConvert.SerializeObject(new { orderId = z.Key }));
                    }
                }
            }
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
            var orders = from d in dalOrderInfo.GetAll()
                         where d.StatusCode == "TRADE_FINISHED" && d.WriteOffDate.Value >= startrq && d.WriteOffDate.Value < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.WriteOffDate.Value.Date).Select(x => new OrderPriceConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderPrice = x.Sum(z => z.ActualPayment.Value) }).ToList();
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
            var orders = from d in dalOrderInfo.GetAll()
                         where d.StatusCode == "TRADE_FINISHED" && d.WriteOffDate.Value >= startrq && d.WriteOffDate.Value < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.WriteOffDate.Value.Date).Select(x => new OrderOperationConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderNum = x.ToList().Count }).ToList();
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
            var orders = from d in dalOrderInfo.GetAll()
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
            var orders = from d in dalOrderInfo.GetAll()
                         where d.IsReturnBackPrice == true && d.ReturnBackDate.Value >= startrq && d.ReturnBackDate.Value < endrq
                         select d;
            var orderList = orders.ToList();
            return orderList.GroupBy(x => x.ReturnBackDate.Value.Date).Select(x => new OrderPriceConditionDto { Date = x.Key.ToString("yyyy-MM-dd"), OrderPrice = x.Sum(z => z.ReturnBackPrice.Value) }).ToList();
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
            var orders = from d in dalOrderInfo.GetAll()
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
        /// 根据客户编号获取所有平台订单列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="statusCode"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>

        public async Task<FxPageInfo<OrderTradeForWxDto>> GetOrderListForAllAmiyaByCustomerId(string customerId, string statusCode, int pageNum, int pageSize)
        {
            List<OrderInfoSimpleDto> orderInfoSimpleResult = new List<OrderInfoSimpleDto>();
            var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.Id == customerId);
            var order = (from d in dalOrderInfo.GetAll().Include(e => e.OrderTrade)
                         where d.Phone == customer.Phone
                         && d.CreateDate >= Convert.ToDateTime("2021-06-01")
                         //过滤掉定金订单和咨询订单
                         && d.StatusCode != "BARGAIN_MONEY" && d.StatusCode != "SEEK_ADVICE"
                         && (d.StatusCode == statusCode || statusCode == null)
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
                             TradeId = d.TradeId,
                             OrderTrade = d.OrderTrade,
                             OrderType = d.OrderType
                         }).ToList();
            var orders = order.GroupBy(e => e.OrderTrade).Select(g => new OrderTradeForWxDto
            {
                TradeId = g.Key == null ? "" : g.Key.TradeId,
                CustomerId = g.Key == null ? "" : g.Key.CustomerId,
                CreateDate = g.Key == null ? null : g.Key.CreateDate,
                AddressId = g.Key == null ? null : g.Key.AddressId,
                TotalAmount = g.Key == null ? 0.00m : g.Key.TotalAmount,
                TotalIntegration = g.Key == null ? 0.00m : g.Key.TotalIntegration,
                Remark = g.Key == null ? "" : g.Key.Remark,
                StatusCode = g.Key == null ? "" : g.Key.StatusCode,
                StatusText = g.Key == null ? "" : ServiceClass.GetOrderStatusText(g.Key.StatusCode),
                OrderInfoList = (from o in g
                                 select new OrderInfoDto
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
                                     ExchangeTypeText = ServiceClass.GetExchangeTypeText((byte)(o.ExchangeType == null ? 255 : (o.ExchangeType))),
                                     TradeId = o.TradeId,
                                     AppType = o.AppType,
                                     StatusText = ServiceClass.GetOrderStatusText(o.StatusCode),
                                     AppTypeText = ServiceClass.GetAppTypeText((byte)o.AppType)
                                 }).ToList()
            }).ToList();
            var orderAlreadyBuyList = orders.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            FxPageInfo<OrderTradeForWxDto> OrderAlreadyBuyInfoList = new FxPageInfo<OrderTradeForWxDto>();
            OrderAlreadyBuyInfoList.TotalCount = orderInfoSimpleResult.Count;
            OrderAlreadyBuyInfoList.List = orderAlreadyBuyList;
            return OrderAlreadyBuyInfoList;
        }

        public async Task<bool> IsExistMFCard(string customerId)
        {
            var order = from d in dalOrderTrade.GetAll()
                           .Include(e => e.OrderInfoList)
                        where d.CustomerId == customerId
                        select d;
            var list = (await order.ToListAsync()).SelectMany(e => e.OrderInfoList);
            int count = list.Count(e => e.GoodsName.Contains("美肤券") && (e.StatusCode == OrderStatusCode.TRADE_BUYER_PAID || e.StatusCode == OrderStatusCode.TRADE_FINISHED));
            if (count > 0) return true;
            return false;

        }

        





        #endregion
    }
}
