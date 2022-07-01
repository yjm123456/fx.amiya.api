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

namespace Fx.Amiya.Service
{
    public class OrderHistoryService : IOrderHistoryService
    {

        private IDalOrderInfo dalOrderInfo;
        private IDalCustomerInfo dalCustomerInfo;
        private IUnitOfWork unitOfWork;
        private IDalBindCustomerService dalBindCustomerService;
        private IDalAmiyaEmployee dalAmiyaEmployee;
        private IDalConfig dalConfig;
        private IDalReceiveGift dalReceiveGift;
        private ILogger<OrderService> logger;
        private IDalOrderTrade dalOrderTrade;
        private IDalSendGoodsRecord dalSendGoodsRecord;
        private readonly IItemInfoService _itemInfoService;
        private IGoodsCategory goodsCategoryService;
        private IOrderWriteOffInfoService _orderWriteOffInfoService;
        private IGoodsInfo _goodsInfoService;
        private IHospitalInfoService _hospitalInfoService;
        private ISendOrderInfoService _sendOrderInfoService;
        private IFxSmsBasedTemplateSender _smsSender;
        private IExpressManageService _expressManageService;
        private IAmiyaGoodsDemandService _amiyaGoodsDemandService;
        public OrderHistoryService(
            IDalOrderInfo dalOrderInfo,
            IDalCustomerInfo dalCustomerInfo,
            IUnitOfWork unitOfWork,
            IDalBindCustomerService dalBindCustomerService,
            IDalAmiyaEmployee dalAmiyaEmployee,
            IDalConfig dalConfig,
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
            IFxSmsBasedTemplateSender smsSender)
        {
            this.dalOrderInfo = dalOrderInfo;
            this.dalCustomerInfo = dalCustomerInfo;
            this.unitOfWork = unitOfWork;
            this.dalBindCustomerService = dalBindCustomerService;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
            this.dalConfig = dalConfig;
            this.dalReceiveGift = dalReceiveGift;
            this.logger = logger;
            this.dalOrderTrade = dalOrderTrade;
            this.dalSendGoodsRecord = dalSendGoodsRecord;
            _amiyaGoodsDemandService = amiyaGoodsDemandService;
            _itemInfoService = itemInfoService;
            _goodsInfoService = goodsInfoService;
            _orderWriteOffInfoService = orderWriteOffService;
            _hospitalInfoService = hospitalInfoService;
            _sendOrderInfoService = sendOrderInfoService;
            _smsSender = smsSender;
            _expressManageService = expressManageService;
        }
        WxPayAccount _payAccount = new WxPayAccount("wx695942e4818de445", "0b2e89d17e84a947244569d0ec63b816", "1611476157", "asdfg67890asdfg67890asdfg67890as", false, "", "");

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
        /// <param name="employeeId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<OrderInfoDto>> GetOrderListWithPageAsync(DateTime? startDate, DateTime? endDate, DateTime? writeOffStartDate, DateTime? writeOffEndDate, string keyword, string statusCode, byte? appType, byte? orderNature, int employeeId, int pageNum, int pageSize)
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

                var config = await GetCallCenterConfig();
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
                                FinalConsumptionHospital=d.FinalConsumptionHospital
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
        public async Task<List<OrderInfoDto>> ExportOrderListAsync(DateTime? startDate, DateTime? endDate, DateTime? writeOffStartDate, DateTime? writeOffEndDate, string keyword, string statusCode, byte? appType, byte? orderNature, int employeeId)
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
                                Phone = d.Phone,
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
                var config = await GetCallCenterConfig();
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

            var config = await GetCallCenterConfig();
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

            var config = await GetCallCenterConfig();
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



        private async Task<CallCenterConfigDto> GetCallCenterConfig()
        {
            var config = await dalConfig.GetAll().SingleOrDefaultAsync();
            return JsonConvert.DeserializeObject<WxAppConfigDto>(config.ConfigJson).CallCenterConfig;
        }



       


        /// <summary>
        /// 根据交易编号获取订单列表
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        public async Task<List<OrderInfoDto>> GetOrderListByTradeIdAsync(string tradeId)
        {
            var config = await GetCallCenterConfig();
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
            var config = await GetCallCenterConfig();
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
            try
            {
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
                            SendMails sendMails = new SendMails();
                            var sub = "有新顾客在“" + ServiceClass.GetAppTypeText(orderInfo.AppType) + "”下单啦，订单号为：" + orderInfo.Id + "，请及时跟进哦！";
                            if (appType == (byte)AppType.MiniProgram && intergration_quantity > 0)
                            {
                                sub = "有新的顾客在“积分兑换”中兑换了礼品“" + orderInfo.GoodsName + "”，请及时跟进哦！";
                            }
                            //向管理员发送邮箱通知
                            var bindCustmerInfo = await dalBindCustomerService.GetAll().SingleOrDefaultAsync(e => e.BuyerPhone == phone);
                            if (bindCustmerInfo != null)
                            {
                                var empId = bindCustmerInfo.CustomerServiceId;
                                var empInfo = await dalAmiyaEmployee.GetAll().SingleOrDefaultAsync(e => e.Id == empId);
                                if (empInfo != null)
                                {
                                    var email = empInfo.Email;
                                    if (email == "0" || string.IsNullOrEmpty(email))
                                    {
                                        var empInfos = from k in dalAmiyaEmployee.GetAll()
                                                       select k;
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
                                var employee = await dalAmiyaEmployee.GetAll().Include(e => e.AmiyaPositionInfo).Where(e => e.AmiyaPositionInfo.Name == "客服主管" && e.Valid == true).ToListAsync();
                                foreach (var x in employee)
                                {
                                    var email = x.Email;
                                    if (email == "0" || string.IsNullOrEmpty(email))
                                        continue;
                                    sendMails.sendMail("smtp.qq.com", "3023330386@qq.com", "kivbmbikthsmdejf", "阿美雅", "3023330386@qq.com", email, "客户下单提示", sub);
                                }
                            }
                        }
                        if (orderInfo.OrderType == 0 && item.StatusCode == OrderStatusCode.TRADE_FINISHED)
                        {
                            orderInfo.WriteOffDate = date;
                        }
                        if (item.AppType == (byte)AppType.MiniProgram)
                        {
                            orderInfo.UpdateDate = date;
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
                orderInfo.AppointmentHospital = updateDto.AppointmentHospital;
                orderInfo.StatusCode = updateDto.StatusCode;
                orderInfo.ActualPayment = updateDto.ActualPayment;
                orderInfo.CreateDate = DateTime.Now;
                orderInfo.ThumbPicUrl = _amiyaGoodsDemandService.GetByIdAsync(updateDto.GoodsId).Result.ThumbPictureUrl.ToString();
                orderInfo.BuyerNick = updateDto.BuyerNick;
                orderInfo.AppType = updateDto.AppType;
                orderInfo.BuyerNick = updateDto.BuyerNick;
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
        /// 删除录单订单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
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
                             Quantity = d.Quantity.Value
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
            var config = await GetCallCenterConfig();
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
            var config = await GetCallCenterConfig();
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
        public async Task<OrderInfoDto> GetByIdInCRMAsync(string id)
        {
            var config = await GetCallCenterConfig();
            var order = await dalOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == id);
            if (order == null)
                throw new Exception("订单编号错误");

            OrderInfoDto orderInfo = new OrderInfoDto();
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
            orderInfo.OrderNature = order.OrderNature;
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



        /// <summary>
        /// 获取小程序实物订单交易列表
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="isSendGoods">是否已发货</param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<OrderTradeDto>> GetMiniProgramMaterialOrderTradeList(int employeeId, bool? isSendGoods, string keyword, int pageNum, int pageSize)
        {
            bool hidePhone = false;
            var config = await GetCallCenterConfig();
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
            var config = await GetCallCenterConfig();
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
                var orderInfo = await dalOrderInfo.GetAll().SingleOrDefaultAsync(e => e.Id == orderId);
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
                await dalOrderInfo.UpdateAsync(orderInfo, true);
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


        #region 报表相关

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

        public async Task<List<OrderWriteOffDto>> GetCustomerOrderReceivableAsync(DateTime? startDate, DateTime? endDate, string customerName, bool isHidePhone)
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
            if (!string.IsNullOrEmpty(customerName))
            {
                orders = from d in orders
                         where d.BuyerNick.Contains(customerName)
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
                            FinalConsumptionHospital = d.FinalConsumptionHospital
                        };

            List<OrderWriteOffDto> orderPageInfo = new List<OrderWriteOffDto>();
            orderPageInfo = await order.ToListAsync();
            foreach (var x in orderPageInfo)
            {
                var sendOrderInfo = await _sendOrderInfoService.GetSendOrderInfoByOrderId(x.Id);
                if (sendOrderInfo.Count != 0)
                {
                    x.SendOrderHospital = sendOrderInfo.First().HospitalName;
                }
            }
            return orderPageInfo.OrderByDescending(z => z.NickName).ThenByDescending(z => z.WriteOffDate).ToList();
        }
        #endregion

        #region 内部方法

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
        /// 根据手机号，快递单号，物流公司id获取快递信息
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="num">快递单号</param>
        /// <param name="expressId">物流公司id</param>
        /// <returns></returns>
        private async Task<OrderExpressInfoDto> GetExpressInfo(string phone, string num, string expressId)
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


        #endregion

    }
}
