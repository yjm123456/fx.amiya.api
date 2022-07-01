using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.WxEventResponseSetting;
using Fx.Amiya.Dto.WxEventResponseSetting;
using Fx.Amiya.IService;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 微信回复消息API
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class WxEventResponseSettingController : ControllerBase
    {
        private IWxEventResponseSettingService wxEventResponseSettingService;

        public WxEventResponseSettingController(IWxEventResponseSettingService wxEventResponseSettingService)
        {
            this.wxEventResponseSettingService = wxEventResponseSettingService;

        }



        /// <summary>
        /// 获取微信事件回复消息列表
        /// </summary>
        /// <param name="title">标题，可空</param>
        /// <param name="eventType">事件类型：1=首次关注，2=再次关注，可空</param>
        /// <param name="rspMsgType">消息类型：1=文本消息，2=图文消息，可空</param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<List<WxEventResponseSettingVo>>> GetWxEventRspMsgListAsync(string title, byte? eventType, byte? rspMsgType)
        {
            try
            {
                var q = from d in await wxEventResponseSettingService.GetWxEventRspMsgListAsync(title, eventType, rspMsgType)
                        select new WxEventResponseSettingVo
                        {
                            Id = d.Id,
                            IsValid = d.IsValid,
                            Title = d.Title,
                            RspMsgXml = d.RspMsgXml,
                            EventType = d.EventType,
                            EventTypeName = d.EventTypeName,
                            CreateDate = d.CreateDate,
                            UpdateDate = d.UpdateDate,
                            RspMsgType = d.RspMsgType,
                            RspMsgTypeName = d.RspMsgTypeName
                        };

                return ResultData<List<WxEventResponseSettingVo>>.Success().AddData("wxEventRspMsgList", q.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<WxEventResponseSettingVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据编号获取回复消息信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<WxEventResponseSettingXmlDeserializeVo>> GetByIdAsync(int id)
        {
            try
            {
                var rspMsgInfo = await wxEventResponseSettingService.GetByIdAsync(id);
                WxEventResponseSettingXmlDeserializeVo wxEventResponseSetting = new WxEventResponseSettingXmlDeserializeVo();
                wxEventResponseSetting.Id = rspMsgInfo.Id;
                wxEventResponseSetting.IsValid = rspMsgInfo.IsValid;
                wxEventResponseSetting.Title = rspMsgInfo.Title;
                wxEventResponseSetting.EventType = rspMsgInfo.EventType;
                wxEventResponseSetting.EventTypeName = rspMsgInfo.EventTypeName;
                wxEventResponseSetting.CreateDate = rspMsgInfo.CreateDate;
                wxEventResponseSetting.UpdateDate = rspMsgInfo.UpdateDate;
                wxEventResponseSetting.RspMsgType = rspMsgInfo.RspMsgType;
                wxEventResponseSetting.RspMsgTypeName = rspMsgInfo.RspMsgTypeName;
                if (rspMsgInfo.RspMsgType == (byte)WxRspMsgType.TextMessage)
                {
                    wxEventResponseSetting.TextMsg = new ResponseMessageTextVo() { Content = rspMsgInfo.TextMsg.Content };
                }
                else
                {
                    wxEventResponseSetting.ArticleMsgList = (from d in rspMsgInfo.Articles
                                                       select new ResponseMessageNewsItemVo
                                                       {
                                                           Title = d.Title,
                                                           Description = d.Description,
                                                           PicUrl = d.PicUrl,
                                                           Url = d.Url
                                                       }).ToList();
                }
              

                return ResultData<WxEventResponseSettingXmlDeserializeVo>.Success().AddData("wxEventRspMsgInfo", wxEventResponseSetting);
            }
            catch (Exception ex)
            {
                return ResultData<WxEventResponseSettingXmlDeserializeVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 添加事件消息回复
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddWxEventRspMsgAsync(AddWxEventResponseSettingVo addVo)
        {
            try
            {
                AddWxEventResponseSettingDto addDto = new AddWxEventResponseSettingDto();
                addDto.Title = addVo.Title;
                addDto.EventType = addVo.EventType;
                addDto.RspMsgType = addVo.RspMsgType;
                addDto.TextMsg = new ResponseMessageTextDto() { Content = addVo.TextMsg.Content };

                addDto.Articles = (from d in addVo.ArticleMsgList
                                   select new ResponseMessageNewsItemDto
                                   {
                                       Title = d.Title,
                                       Description = d.Description,
                                       PicUrl = d.PicUrl,
                                       Url = d.Url
                                   }).ToList();

                await wxEventResponseSettingService.AddWxEventRspMsgAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改事件回复消息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
      [HttpPut]
        public async Task<ResultData> UpdateWxEventRspMsgAsync(UpdateWxEventResponseSettingVo updateVo)
        {
            try
            {
                UpdateWxEventResponseSettingDto updateDto = new UpdateWxEventResponseSettingDto();
                updateDto.Id = updateVo.Id;
                updateDto.EventType = updateVo.EventType;
                updateDto.RspMsgType = updateVo.RspMsgType;
                updateDto.Title = updateVo.Title;
                updateDto.TextMsg = new ResponseMessageTextDto() { Content = updateVo.TextMsg.Content };
                updateDto.Articles = (from d in updateVo.ArticleMsgList
                                   select new ResponseMessageNewsItemDto
                                   {
                                       Title = d.Title,
                                       Description = d.Description,
                                       PicUrl = d.PicUrl,
                                       Url = d.Url
                                   }).ToList();
                await wxEventResponseSettingService.UpdateWxEventRspMsgAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

    }
}