using Fx.Amiya.Dto.HuiShouQianPay;
using Fx.Amiya.Dto.HuiShouQianPayNotify;
using Fx.Amiya.Dto.OperationLog;
using Fx.Amiya.Dto.Order;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Amiya.Service;
using Fx.Infrastructure.DataAccess;
using Fx.Open.Infrastructure.Web.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private readonly IDalWechatPayInfo dalWechatPayInfo;
        private readonly IUnitOfWork unitOfWork;
        private readonly IOrderService orderService;
        private readonly IOperationLogService operationLogService;
        private readonly IDalBindCustomerService _dalBindCustomerService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public NotifyController(IDalWechatPayInfo dalWechatPayInfo, IUnitOfWork unitOfWork, IOrderService orderService, IOperationLogService operationLogService, IDalBindCustomerService dalBindCustomerService, IHttpContextAccessor httpContextAccessor)
        {
            this.dalWechatPayInfo = dalWechatPayInfo;
            this.unitOfWork = unitOfWork;
            this.orderService = orderService;
            this.operationLogService = operationLogService;
            _dalBindCustomerService = dalBindCustomerService;
            this.httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// 慧收钱支付回调
        /// </summary>
        /// <returns></returns>
        [HttpPost("hsqPayResult")]
        public async Task<string> HSQPayOrderNotifyUrl()
        {
            OperationAddDto operationLog2 = new OperationAddDto();
            HuiShouQianNotifyParam notifyParam = new HuiShouQianNotifyParam();
            try
            {
                operationLog2.OperationBy = null;
                operationLog2.Code = 0;
                HuiShouQianPackageInfo huiShouQianPackageInfo = new HuiShouQianPackageInfo();
                var payInfo = dalWechatPayInfo.GetAll().Where(e => e.Id == "202306281235").FirstOrDefault();
                huiShouQianPackageInfo.Key = payInfo.PartnerKey;
                huiShouQianPackageInfo.PrivateKey = payInfo.PrivateKey;
                huiShouQianPackageInfo.PublicKey = payInfo.PublickKey;
                using Stream stream = HttpContext.Request.Body;
                byte[] buffer = new byte[HttpContext.Request.ContentLength.Value];
                await stream.ReadAsync(buffer);
                string notify = System.Text.Encoding.UTF8.GetString(buffer);
                notify = HttpUtility.UrlDecode(notify);
                var list = notify.Split("&");
                string signContent = "";
                string sign = "";
                foreach (var item in list)
                {
                    var arr = item.Split("=");
                    if (arr[0] == "signContent")
                    {
                        signContent = arr[1];
                    }
                    if (arr[0] == "sign")
                    {
                        sign = arr[1];
                    }
                }
                notifyParam = JsonConvert.DeserializeObject<HuiShouQianNotifyParam>(signContent);
                var signContent1 = BuildPayParamString("CALLBACK", "1.0.0", "JSON", payInfo.AppId, "RSA2", signContent, huiShouQianPackageInfo.Key);
                RSAHelper rsa = new RSAHelper(RSAType.RSA2, Encoding.UTF8, huiShouQianPackageInfo.PrivateKey, huiShouQianPackageInfo.PublicKey);
                var verify = rsa.Verify(signContent1, sign);
                if (verify)
                {
                    if (notifyParam.orderStatus.ToUpper() == "SUCCESS")
                    {
                        bool isMaterialOrder = false;
                        var orderTrade = await orderService.GetOrderTradeByTradeIdAsync(notifyParam.extend);
                        if (orderTrade.StatusCode == OrderStatusCode.WAIT_BUYER_PAY)
                        {
                            List<UpdateOrderDto> updateOrderList = new List<UpdateOrderDto>();
                            foreach (var item in orderTrade.OrderInfoList)
                            {
                                UpdateOrderDto updateOrder = new UpdateOrderDto();
                                updateOrder.OrderId = item.Id;
                                if (item.OrderType == (byte)OrderType.MaterialOrder)
                                {
                                    updateOrder.StatusCode = OrderStatusCode.WAIT_SELLER_SEND_GOODS;
                                    isMaterialOrder = true;
                                }
                                else if (item.OrderType == (byte)OrderType.VirtualOrder)
                                {
                                    updateOrder.StatusCode = OrderStatusCode.TRADE_BUYER_PAID;                                                                                                         
                                }
                                if (item.ActualPayment.HasValue)
                                {
                                    updateOrder.Actual_payment = item.ActualPayment.Value;

                                    var bind = await _dalBindCustomerService.GetAll().FirstOrDefaultAsync(e => e.BuyerPhone == item.Phone);
                                    if (bind != null)
                                    {
                                        bind.NewConsumptionDate = DateTime.Now;
                                        bind.NewConsumptionContentPlatform = (int)OrderFrom.ThirdPartyOrder;
                                        bind.NewContentPlatForm = ServiceClass.GetAppTypeText(item.AppType);
                                        bind.AllPrice += item.ActualPayment.Value;
                                        bind.AllOrderCount += item.Quantity;
                                        await _dalBindCustomerService.UpdateAsync(bind, true);
                                    }
                                }
                                if (item.IntegrationQuantity.HasValue)
                                {
                                    updateOrder.IntergrationQuantity = item.IntegrationQuantity;
                                }
                                Random random = new Random();
                                updateOrder.AppType = item.AppType;
                                updateOrder.WriteOffCode = random.Next().ToString().Substring(0, 8);
                                updateOrderList.Add(updateOrder);
                            }
                            //修改订单状态
                            await orderService.UpdateAsync(updateOrderList);
                            UpdateOrderTradeDto updateOrderTrade = new UpdateOrderTradeDto();
                            updateOrderTrade.TradeId = notifyParam.extend;
                            updateOrderTrade.AddressId = orderTrade.AddressId;
                            if (isMaterialOrder)
                            {
                                updateOrderTrade.StatusCode = OrderStatusCode.WAIT_SELLER_SEND_GOODS;
                            }
                            else
                            {
                                updateOrderTrade.StatusCode = OrderStatusCode.TRADE_BUYER_PAID;
                            }
                            await orderService.UpdateOrderTradeAsync(updateOrderTrade);
                            await orderService.TradeAddChanelOrderNoAsync(orderTrade.TradeId, notifyParam.payOrderNo);
                        }
                    }
                    return "SUCCESS";
                }
                else
                {
                    return "Fail";
                }
            }
            catch (Exception ex)
            {
                operationLog2.Message = ex.Message;
                operationLog2.Code = -1;
                return "Fail";
            }
            finally
            {
                operationLog2.Source = (int)RequestSource.AmiyaBackground;
                operationLog2.Parameters = JsonConvert.SerializeObject(notifyParam);
                operationLog2.RequestType = (int)RequestType.Pay;
                operationLog2.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationLog2);
            }
        }
        /// <summary>
        /// 拼接回调请求参数
        /// </summary>
        /// <param name="method"></param>
        /// <param name="version"></param>
        /// <param name="format"></param>
        /// <param name="merchantNo"></param>
        /// <param name="signType"></param>
        /// <param name="signContent"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string BuildPayParamString(string method, string version, string format, string merchantNo, string signType, string signContent, string key)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("method=");
            builder.Append(method);
            builder.Append("&version=");
            builder.Append(version);
            builder.Append("&format=");
            builder.Append(format);
            builder.Append("&merchantNo=");
            builder.Append(merchantNo);
            builder.Append("&signType=");
            builder.Append(signType);
            builder.Append("&signContent=");
            builder.Append(signContent);
            builder.Append("&key=");
            builder.Append(key);
            return builder.ToString();
        }
    }
}
