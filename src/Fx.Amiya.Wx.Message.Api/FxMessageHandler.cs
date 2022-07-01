using Fx.Amiya.Common;
using Fx.Amiya.IService;
using Fx.Weixin.MP.AdvanceApi;
using Fx.Weixin.MP.Message;
using Fx.Weixin.MP.Message.Request;
using Fx.Weixin.MP.Message.Request.Events;
using Fx.Weixin.MP.Message.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Fx.Infrastructure.Utils;
using Fx.Common.Extensions;
using Fx.Common.Utils;

namespace Fx.Amiya.Wx.Message.Api
{
    public class FxMessageHandler : MessageHandler
    {
        private MpUserInfoApi _mpUserInfoApi;
        private IFxMessageCenter _messageCenter;
        private IUserService _userService;
        private FxAppGlobal _fxAppGlobal;
        private IAccessTokenReader _accessTokenReader;
        private IWxEventResponseSettingService _wxEventResponseSettingService;
        public FxMessageHandler(IWxPostMessageIdBucket wxPostMessageIdBucket,
            IUserService userService, MpUserInfoApi mpUserInfoApi, FxAppGlobal fxAppGlobal,
            IAccessTokenReader accessTokenReader,
            IWxEventResponseSettingService wxEventResponseSettingService) 
            : base(wxPostMessageIdBucket)
        {
            _userService = userService;
            _accessTokenReader = accessTokenReader;
            _mpUserInfoApi = mpUserInfoApi;
            _fxAppGlobal = fxAppGlobal;
            _wxEventResponseSettingService = wxEventResponseSettingService;
            var fxMessageCenterConfig = fxAppGlobal.AppConfig.FxMessageCenterConfig;
            if (_messageCenter == null)
            {
                if (fxMessageCenterConfig.EnableMessageCenter)
                {
                    if (fxMessageCenterConfig.EnableMessageQueue)
                    {
                        _messageCenter = new DefaultFxMessageCenter(fxMessageCenterConfig.MQHostName, fxMessageCenterConfig.Port,
                            fxMessageCenterConfig.MQUserName, fxMessageCenterConfig.MQPassword, fxMessageCenterConfig.MQQueueName);
                    }
                    else
                    {
                        _messageCenter = new WebSocketMessageCenter(fxMessageCenterConfig.MessageCenterWebSocketUrl);
                    }
                }
            }
        }


        public override async Task<ResponseMessageBase> DefaultResponseMessageAsync(RequestMessageBase requestMessage)
        {

            var rspMessage = requestMessage.CreateResponseMessage<ResponseMessageText>();
            rspMessage.Content = "方旋（杭州）欢迎您！当前时间：{0}".FormatWith(DateTime.Now);
            return rspMessage;
        }
        public override async Task<ResponseMessageBase> OnTextRequestMessageAsync(RequestMessageText requestMessage)
        {
            //return await base.OnTextRequestMessageAsync(requestMessage);
            if (_messageCenter != null)
            {
               
                await requestMessage.SendToAsync(_messageCenter);
                return null;
            }
            else
            {
                var message = requestMessage.CreateResponseMessage<ResponseMessageText>();
                message.Content = "您输入了：{0}".FormatWith(requestMessage.Content);
                return message;
            }

        }

        public override async Task<ResponseMessageBase> OnImageRequestMessageAsync(RequestMessageImage requestMessage)
        {
            if(_messageCenter != null)
            {
                await requestMessage.SendToAsync(_messageCenter);
                
            }
            return null;
        }



        public override async Task<ResponseMessageBase> OnEvent_UserEnterTempSession(EventUserEnterTempSessionMessage eventMessage)
        {
            if (_messageCenter != null)
            {
                await eventMessage.SendToAsync(_messageCenter);

            }
            return null;
        }

        public override async Task<ResponseMessageBase> OnEvent_SubscribeAsync(EventSubscribeMessage subscribeMessage)
        {
            //关注事件，考虑到需要实时同步的情况，此处就不发送到消息队列做异步处理
            var appInfo = _fxAppGlobal.WxAppInfoList.SingleOrDefault(t => t.AccountId == subscribeMessage.ToUserName);
            if (appInfo == null)
                throw new Exception("无效的accountId，请检查帐号设置");
            //此用需要取到完整用户信息
            var accessToken = await _accessTokenReader.GetAccessTokenAsync(appInfo.WxAppId);
            var userInfo = await _mpUserInfoApi.GetUserInfoAsync(accessToken, subscribeMessage.FromUserName);  //从微信服务器获取完整的用户信息
            //App.Dto.UserInfo.WxMpUserInfoDto wxMpUser =await  _userService.GetWxMpUserAsync(subscribeMessage.FromUserName);
            var result = await _userService.WxMpUserSubscribeAsync(new Dto.UserInfo.WxMpUserInfoDto()
            {
                City = userInfo.City,
                Country = userInfo.Country,
                GroupId = userInfo.Groupid,
                Avatar = userInfo.Headimgurl,
                Language = userInfo.Language,
                Nickname = userInfo.Nickname,
                Openid = userInfo.Openid,
                Province = userInfo.Province,
                QrScene = userInfo.Qr_scene,
                QrSceneStr = userInfo.Qr_scene_str,
                Remark = userInfo.Remark,
                Sex = userInfo.Sex,
                Subscribe = userInfo.Subscribe,
                SubscribeScene = userInfo.Subscribe_scene,
                SubscribeTime = userInfo.Subscribe_time,
                TagidList = userInfo.Tagid_list,
                Unionid = userInfo.Unionid,
                AppId = appInfo.WxAppId
            });

            if (result.SubscribeCount == 1)  //首次关注
            {
               
                var eventResponse = await _wxEventResponseSettingService.GetEventResponseByEventTypeAsync((byte)WxEventType.FirstSubscribe);
                XElement root = XDocument.Parse(eventResponse.RspMsgXml).Root;
             
                if (eventResponse.RspMsgType == (byte)WxRspMsgType.TextMessage)//文本消息
                {
                    var responseMsg = subscribeMessage.CreateResponseMessage<ResponseMessageText>();
                    responseMsg.Content = root.Element("content").Value;
                    return responseMsg;
                }
                else//图文消息
                {
                    

                    var responseMsg = subscribeMessage.CreateResponseMessage<ResponseMessageNews>();
                    var items = root.Element("Articles").ToString();
                    ResponseMessageNewsArticles responseMessageNewsArticles = XmlUtil.Deserialize<ResponseMessageNewsArticles>(items);
                    responseMsg.Articles = responseMessageNewsArticles.Items;
                    responseMsg.ArticleCount = responseMessageNewsArticles.Items.Count();
                    return responseMsg;
                  
                }
            }
            else  //再次关注
            {
               
                var eventResponse = await _wxEventResponseSettingService.GetEventResponseByEventTypeAsync((byte)WxEventType.AgainSubscribe);
                XElement root = XDocument.Parse(eventResponse.RspMsgXml).Root;
              
                if (eventResponse.RspMsgType == (byte)WxRspMsgType.TextMessage)
                {
                    var responseMsg = subscribeMessage.CreateResponseMessage<ResponseMessageText>();
                    responseMsg.Content = root.Element("content").Value;
                    return responseMsg;
                }
                else
                {
                    var responseMsg = subscribeMessage.CreateResponseMessage<ResponseMessageNews>();
                    var items = root.Element("Articles").ToString();
                    ResponseMessageNewsArticles responseMessageNewsArticles = XmlUtil.Deserialize<ResponseMessageNewsArticles>(items);
                    responseMsg.Articles = responseMessageNewsArticles.Items;
                    responseMsg.ArticleCount = responseMessageNewsArticles.Items.Count();
                    return responseMsg;
                }
               
            }


        }

        public override async Task<ResponseMessageBase> OnLocationRequestMessageAsync(RequestMessageLocation requestMessage)
        {
            var rspMsg = requestMessage.CreateResponseMessage<ResponseMessageText>();
            rspMsg.Content = $"x:{requestMessage.Location_X},y:{requestMessage.Location_Y},scale:{requestMessage.Scale},label:{requestMessage.Label}";
            return rspMsg;
        }

        public override async Task<ResponseMessageBase> OnEvent_UnsubscribeAsync(EventSubscribeMessage subscribeMessage)
        {
            await _userService.WxMpUserUnsubscribeAsync(subscribeMessage.FromUserName);
            return null;
        }
    }
}
