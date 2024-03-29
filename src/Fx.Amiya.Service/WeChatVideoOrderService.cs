﻿using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.BindCustomerService;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.Dto.WechatVideoOrder;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Common.Utils;
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
    /// <summary>
    /// 视频号订单
    /// </summary>
    public class WeChatVideoOrderService : IWeChatVideoOrderService
    {
        private IDalWeChatVideoOrderInfo dalWeChatVideoOrderInfo;
        private IFxSmsBasedTemplateSender _smsSender;
        private IDalAmiyaEmployee dalAmiyaEmployee;
        private IDalBindCustomerService dalBindCustomerService;
        private IIntegrationAccount integrationAccountService;
        private IMemberCard memberCardService;
        private IMemberRankInfo memberRankInfoService;
        private IBindCustomerServiceService _bindCustomerService;
        private readonly ICustomerService customerService;
        private IOrderService orderService;
        private IDalLiveAnchor dalLiveAnchor;
        private IDalCustomerInfo dalCustomerInfo;
        private IWxAppConfigService _wxAppConfigService;
        public WeChatVideoOrderService(IDalWeChatVideoOrderInfo dalWeChatVideoOrderInfo, IFxSmsBasedTemplateSender smsSender, IDalAmiyaEmployee dalAmiyaEmployee, IDalBindCustomerService dalBindCustomerService, IIntegrationAccount integrationAccountService, IMemberCard memberCardService, IMemberRankInfo memberRankInfoService, IBindCustomerServiceService bindCustomerService, ICustomerService customerService, IOrderService orderService, IDalLiveAnchor dalLiveAnchor, IDalCustomerInfo dalCustomerInfo, IWxAppConfigService wxAppConfigService)
        {
            this.dalWeChatVideoOrderInfo = dalWeChatVideoOrderInfo;
            _smsSender = smsSender;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
            this.dalBindCustomerService = dalBindCustomerService;
            this.integrationAccountService = integrationAccountService;
            this.memberCardService = memberCardService;
            this.memberRankInfoService = memberRankInfoService;
            _bindCustomerService = bindCustomerService;
            this.customerService = customerService;
            this.orderService = orderService;
            this.dalLiveAnchor = dalLiveAnchor;
            this.dalCustomerInfo = dalCustomerInfo;
            _wxAppConfigService = wxAppConfigService;
        }

        /// <summary>
        /// 添加视频号订单
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        public async Task AddAsync(List<WechatVideoAddDto> addList)
        {
            try
            {
               
                var emailConfig = false;
                //订单号集合
                string goodsName = "";
                Dictionary<string, string> orderPhoneDict = new Dictionary<string, string>();
                byte appType = 7;
                List<WeChatVideoOrderInfo> orderInfoList = new List<WeChatVideoOrderInfo>();
                
                foreach (var orderItem in addList)
                {
                    var orderInfos = from d in dalWeChatVideoOrderInfo.GetAll()
                                     where d.Id == orderItem.Id
                                     select d;
                    var orderInfo = orderInfos.FirstOrDefault();
                    
                    if (orderInfo != null)
                    {
                        //根据是否包含手机号判断该订单是否已经解密
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
                        orderInfo.ThumbPicUrl = orderItem.ThumbPicUrl;
                        orderInfo.BelongLiveAnchorId = orderItem.BelongLiveAnchorId;
                        await dalWeChatVideoOrderInfo.UpdateAsync(orderInfo, true);
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
                                await _bindCustomerService.UpdateConsumePriceAsync(orderInfo.Phone, orderInfo.ActualPayment.Value, (int)OrderFrom.ThirdPartyOrder, "", "", "抖音", 1);
                            }
                        }
                    }
                    else
                    {
                        WeChatVideoOrderInfo order = new WeChatVideoOrderInfo();
                        order.Id = orderItem.Id;
                        order.GoodsId = orderItem.GoodsId;
                        order.GoodsName = orderItem.GoodsName;
                        order.Phone = orderItem.Phone;
                        order.StatusCode = orderItem.StatusCode;
                        order.ActualPayment = orderItem.ActualPayment;
                        order.AccountReceivable = orderItem.AccountReceivable;
                        order.CreateDate = orderItem.CreateDate;
                        order.UpdateDate = orderItem.UpdateDate;
                        order.ThumbPicUrl = orderItem.ThumbPicUrl;
                        order.BuyerNick = orderItem.BuyerNick;
                        order.CheckState = (int)CheckType.NotChecked;
                        order.OrderType = orderItem.OrderType;
                        order.Quantity = orderItem.Quantity;
                        order.BelongLiveAnchorId = orderItem.BelongLiveAnchorId;
                        
                        order.Valid = true;
                        var orderStatus = ServiceClass.GetTikTokOrderStatusText(order.StatusCode);
                        var bindCustomerId =await _bindCustomerService.GetEmployeeIdByPhone(orderItem.Phone);

                        if (bindCustomerId!=0) {
                            order.BelongEmpId = bindCustomerId;
                        }
                        await dalWeChatVideoOrderInfo.AddAsync(order, true);

                    }
                }
               
                //发送短信通知
                SendPhoneInfo(orderPhoneDict, appType);

            }
            catch (Exception ex)
            {
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
            if (string.IsNullOrEmpty(Phone))
            {
                var employee = empInfos.Include(e => e.AmiyaPositionInfo).Where(e => e.AmiyaPositionInfo.Name == "客服主管" && e.Valid == true).ToListAsync();
                foreach (var x in employee.Result)
                {
                    var email = x.Email;
                    if (email == "0" || string.IsNullOrEmpty(email))
                        continue;
                    sendMails.sendMail("smtp.qq.com", "3023330386@qq.com", "kivbmbikthsmdejf", "啊美雅", "3023330386@qq.com", email, "客户下单提示", sub);
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
                            sendMails.sendMail("smtp.qq.com", "3023330386@qq.com", "kivbmbikthsmdejf", "啊美雅", "3023330386@qq.com", email, "客户下单提示", sub);
                        }
                    }
                    else
                    {
                        sendMails.sendMail("smtp.qq.com", "3023330386@qq.com", "kivbmbikthsmdejf", "啊美雅", "3023330386@qq.com", email, "客户下单提示", sub);
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
                    sendMails.sendMail("smtp.qq.com", "3023330386@qq.com", "kivbmbikthsmdejf", "啊美雅", "3023330386@qq.com", email, "客户下单提示", sub);
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

        public async Task<FxPageInfo<WechatVideoOrderInfoDto>> GetListByPageAsync(string keyWord,DateTime? startDate, DateTime? endDate, int? belongLiveAnchorId, string status, int? orderType, int pageSize, int pageNum)
        {
            var config = await _wxAppConfigService.GetCallCenterConfig();
            var order= dalWeChatVideoOrderInfo.GetAll().Where(e => !startDate.HasValue|| e.CreateDate >= startDate.Value.Date)
                .Where(e => !endDate.HasValue || e.CreateDate <= endDate.Value.AddDays(1).Date)
                .Where(e => !belongLiveAnchorId.HasValue || e.BelongLiveAnchorId == belongLiveAnchorId)
                .Where(e => string.IsNullOrEmpty(status) || e.StatusCode == status)
                .Where(e => !orderType.HasValue || e.OrderType == orderType)
                .Where(e=>string.IsNullOrEmpty(keyWord)||(e.Phone.Contains(keyWord)||e.GoodsName.Contains(keyWord))||e.Id.Contains(keyWord)).OrderByDescending
                (e=>e.CreateDate);
            FxPageInfo<WechatVideoOrderInfoDto> fxPageInfo = new FxPageInfo<WechatVideoOrderInfoDto>();
            fxPageInfo.TotalCount =await order.CountAsync();
            fxPageInfo.List = order.Skip((pageNum - 1) * pageSize).Take(pageSize).Select(e => new WechatVideoOrderInfoDto {
                Id = e.Id,
                GoodsName = e.GoodsName,
                GoodsId = e.GoodsId,
                Phone = config.HidePhoneNumber == true ? ServiceClass.GetIncompletePhone(e.Phone) : e.Phone,
                StatusCode = e.StatusCode,
                StatusCodeText = ServiceClass.GetOrderStatusText(e.StatusCode),
                ActualPayment = e.ActualPayment,
                AccountReceivable = e.AccountReceivable,
                CreateDate = e.CreateDate,
                UpdateDate = e.UpdateDate,
                ThumbPicUrl = e.ThumbPicUrl,
                BuyerNick = e.BuyerNick,
                OrderType = e.OrderType,
                OrderTypeText = ServiceClass.GetWechatOrderTypeText(e.OrderType.Value),
                Quantity = e.Quantity,
                BelongLiveAnchorId = e.BelongLiveAnchorId,
                BelongLiveAnchorName=dalLiveAnchor.GetAll().Where(e=>e.Id==belongLiveAnchorId).SingleOrDefault().Name
            }).ToList();
            return fxPageInfo;
        }
    }
}
