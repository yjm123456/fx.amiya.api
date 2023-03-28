using Fx.Amiya.Dto.MiniProgramSendMessage;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class MiniProgramTemplateMessageSendService : IMiniProgramTemplateMessageSendService
    {
        private IDockingHospitalCustomerInfoService dockingHospitalCustomerInfoService;
        private IDalWxMiniUserInfo dalWxMiniUserInfo;
        private ICustomerService customerService;

        public MiniProgramTemplateMessageSendService(IDockingHospitalCustomerInfoService dockingHospitalCustomerInfoService, ICustomerService customerService, IDalWxMiniUserInfo dalWxMiniUserInfo)
        {
            this.dockingHospitalCustomerInfoService = dockingHospitalCustomerInfoService;

            this.customerService = customerService;
            this.dalWxMiniUserInfo = dalWxMiniUserInfo;
        }
        /// <summary>
        /// 发送美学设计完成消息
        /// </summary>
        /// <param name="sendAestheticsDesignMessageDto"></param>
        /// <returns></returns>
        public async Task SendAestheticsDesignMessage(SendAestheticsDesignMessageDto sendAestheticsDesignMessageDto)
        {
            try
            {
                var customer = await customerService.GetByIdAsync(sendAestheticsDesignMessageDto.CustomerId);
                if (customer == null) throw new Exception("用户编号错误");
                var openId = dalWxMiniUserInfo.GetAll().Where(e => e.UserId == customer.UserId).Select(e => e.OpenId).FirstOrDefault();
                if (string.IsNullOrEmpty(openId))
                {
                    return;
                }
                var appInfo = await dockingHospitalCustomerInfoService.GetMiniProgramAccessTokenInfo(4);
                var requestUrl = $"https://api.weixin.qq.com/cgi-bin/message/subscribe/send?access_token={appInfo.AccessToken}";
                var messageBody = new
                {
                    template_id = MessageTemplateIds.AestheticsDesignCompleteMessage,
                    touser = openId,
                    page = $"/pages/aestheticsDesignReport/aestheticsDesignReport?reportId={sendAestheticsDesignMessageDto.ReportId}&status='design'",// 点击提示信息要进入的小程序页面
                    miniprogram_state = "trial",
                    lang = "zh_CN",
                    data = new
                    {
                        thing3 = new { value = "美学设计报告" },
                        thing6 = new { value = sendAestheticsDesignMessageDto.Remark },
                        time2 = new { value = $"{DateTime.Now.Year}年{DateTime.Now.Month}月{DateTime.Now.Day}号 {DateTime.Now.Hour}:{DateTime.Now.Minute}" },
                    }
                };
                string body = JsonConvert.SerializeObject(messageBody);
                var result = HttpUtil.HTTPJsonPost(requestUrl, body);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {


            }
        }

        /// <summary>
        /// 发送预约状态变更消息
        /// </summary>
        /// <param name="sendAppointmentMessageDto"></param>
        /// <returns></returns>
        public async Task SendAppointmentMessageAsync(SendAppointmentMessageDto sendAppointmentMessageDto)
        {
            try
            {
                var customer = await customerService.GetByIdAsync(sendAppointmentMessageDto.CustomerId);
                if (customer == null) throw new Exception("用户编号错误");
                var openId = dalWxMiniUserInfo.GetAll().Where(e => e.UserId == customer.UserId).Select(e => e.OpenId).FirstOrDefault();
                if (string.IsNullOrEmpty(openId))
                {
                    return;
                }
                var appInfo = await dockingHospitalCustomerInfoService.GetMiniProgramAccessTokenInfo(192);
                var requestUrl = $"https://api.weixin.qq.com/cgi-bin/message/subscribe/send?access_token={appInfo.AccessToken}";
                var messageBody = new
                {
                    template_id = MessageTemplateIds.ApointmentMessage,
                    touser = openId,
                    page = "/pages/index/index",// 点击提示信息要进入的小程序页面
                    miniprogram_state = "formal",
                    lang = "zh_CN",
                    data = new
                    {
                        thing21 = new { value = sendAppointmentMessageDto.Name },
                        phone_number4 = new { value = sendAppointmentMessageDto.Phone },
                        date3 = new { value = sendAppointmentMessageDto.AppointmentDate },
                        phrase45 = new { value = sendAppointmentMessageDto.AppointmentStatus },
                        thing7 = new { value = sendAppointmentMessageDto.Remark }
                    }
                };
                string body = JsonConvert.SerializeObject(messageBody);
                var result = HttpUtil.HTTPJsonPost(requestUrl, body);
            }
            catch (Exception ex)
            {

                
            }
        }
        /// <summary>
        /// 发放赠送礼品消息
        /// </summary>
        /// <param name="sendGiftPresentMessage"></param>
        /// <returns></returns>
        public async Task SendGiftPresentMessageAsync(SendGiftPresentMessageDto sendGiftPresentMessage)
        {
            try
            {
                var customer = await customerService.GetByIdAsync(sendGiftPresentMessage.CustomerId);
                if (customer == null) throw new Exception("用户编号错误");
                var openId = dalWxMiniUserInfo.GetAll().Where(e => e.UserId == customer.UserId).Select(e => e.OpenId).FirstOrDefault();
                if (string.IsNullOrEmpty(openId))
                {
                    return;
                }
                var appInfo = await dockingHospitalCustomerInfoService.GetMiniProgramAccessTokenInfo(192);
                var requestUrl = $"https://api.weixin.qq.com/cgi-bin/message/subscribe/send?access_token={appInfo.AccessToken}";
                var messageBody = new
                {
                    template_id = MessageTemplateIds.GiftPresentMessage,
                    touser = openId,
                    page = "/pages/index/index",// 点击提示信息要进入的小程序页面
                    miniprogram_state = "formal",
                    lang = "zh_CN",
                    data = new
                    {
                        /*character_string1 = new { value = sendGiftPresentMessage.OrderId },*/
                        thing1 = new { value = sendGiftPresentMessage.GiftName },
                        number2 = new { value = 1 }
                    }
                };
                string body = JsonConvert.SerializeObject(messageBody);
                var result = HttpUtil.HTTPJsonPost(requestUrl, body);
            }
            catch (Exception ex)
            {


            }
        }

        /// <summary>
        /// 发送积分变更消息
        /// </summary>
        /// <returns></returns>
        public async Task SendPointChangeMessgaeAsync(SendPointMessageDto sendPointMessageDto)
        {
            try
            {
                var customer = await customerService.GetByIdAsync(sendPointMessageDto.CustomerId);
                if (customer == null) throw new Exception("用户编号错误");
                var openId = dalWxMiniUserInfo.GetAll().Where(e => e.UserId == customer.UserId).Select(e => e.OpenId).FirstOrDefault();
                if (string.IsNullOrEmpty(openId))
                {
                    return;
                }
                var appInfo = await dockingHospitalCustomerInfoService.GetMiniProgramAccessTokenInfo(192);
                var requestUrl = $"https://api.weixin.qq.com/cgi-bin/message/subscribe/send?access_token={appInfo.AccessToken}";
                var messageBody = new
                {
                    template_id = MessageTemplateIds.PointMessage,
                    touser = openId,
                    page = "/pages/index/index",// 点击提示信息要进入的小程序页面
                    miniprogram_state = "formal",
                    lang = "zh_CN",
                    data = new
                    {
                        /*thing1 = new { value = sendPointMessageDto.MerchantName },
                        thing2 = new { value = sendPointMessageDto.Title },
                        character_string4 = new { value = sendPointMessageDto.ChangeCount },
                        time5 = new { value = sendPointMessageDto.ExpireDate },
                        number10 = new { value = sendPointMessageDto.PointBalance }*/
                        thing1=new { value= $"{sendPointMessageDto.PointBalance}分" },
                        thing2=new {value= $"{sendPointMessageDto.ChangeCount}积分"},
                        thing3= new { value = sendPointMessageDto.Title },
                        date4= new { value = DateTime.Now.ToString("yyyy-MM-dd") }
                    }
                };
                string body = JsonConvert.SerializeObject(messageBody);
                var result = HttpUtil.HTTPJsonPost(requestUrl, body);
            }
            catch (Exception ex)
            {

                
            }
        }
        /// <summary>
        /// 发送优惠券发送消息
        /// </summary>
        /// <param name="sendVoucherMessageDto"></param>
        /// <returns></returns>
        public async Task SendVoucherMessageAsync(SendVoucherMessageDto sendVoucherMessageDto)
        {
            try
            {
                var customer = await customerService.GetByIdAsync(sendVoucherMessageDto.CustomerId);
                if (customer == null) throw new Exception("用户编号错误");
                var openId = dalWxMiniUserInfo.GetAll().Where(e => e.UserId == customer.UserId).Select(e => e.OpenId).FirstOrDefault();
                if (string.IsNullOrEmpty(openId))
                {
                    return;
                }
                var appInfo = await dockingHospitalCustomerInfoService.GetMiniProgramAccessTokenInfo(192);
                var requestUrl = $"https://api.weixin.qq.com/cgi-bin/message/subscribe/send?access_token={appInfo.AccessToken}";
                var messageBody = new
                {
                    template_id = MessageTemplateIds.VoucherMessage,
                    touser = openId,
                    page = "/pages/index/index",// 点击提示信息要进入的小程序页面
                    miniprogram_state = "formal",
                    lang = "zh_CN",
                    data = new
                    {
                        thing1 = new { value = sendVoucherMessageDto.VoucherName },
                        thing5 = new { value = sendVoucherMessageDto.DeductMoney },
                        time2 = new { value = sendVoucherMessageDto.ExpireDate },
                        thing3 = new { value = sendVoucherMessageDto.Remark }
                    }
                };
                string body = JsonConvert.SerializeObject(messageBody);
                var result = HttpUtil.HTTPJsonPost(requestUrl, body);
            }
            catch (Exception ex)
            {

                
            }
        }
    }
}
