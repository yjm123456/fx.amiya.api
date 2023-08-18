using Fx.Amiya.Dto.WxEventResponseSetting;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Xml.Linq;
using Fx.Infrastructure.Utils;
using Fx.Weixin.MP.Message.Response;
using Fx.Amiya.DbModels.Model;
using Fx.Common.Utils;

namespace Fx.Amiya.Service
{
    public class WxEventResponseSettingService : IWxEventResponseSettingService
    {
        private IDalWxEventResponseSetting dalWxEventResponseSetting;

        public WxEventResponseSettingService(IDalWxEventResponseSetting dalWxEventResponseSetting)
        {
            this.dalWxEventResponseSetting = dalWxEventResponseSetting;
        }

        public async Task<WxEventResponseSettingDto> GetEventResponseByEventTypeAsync(byte eventType)
        {
            try
            {
                var eventResponse = await dalWxEventResponseSetting.GetAll()
                    .SingleOrDefaultAsync(e => e.EventType == eventType && e.IsValid == true);

                WxEventResponseSettingDto wxEventResponseSettingDto = new WxEventResponseSettingDto()
                {
                    Id = eventResponse.Id,
                    IsValid = eventResponse.IsValid,
                    Title = eventResponse.Title,
                    RspMsgXml = eventResponse.RspMsgXml,
                    EventType = eventResponse.EventType,
                    CreateDate = eventResponse.CreateDate,
                    UpdateDate = eventResponse.UpdateDate,
                    RspMsgType = eventResponse.RspMsgType,

                };

                return wxEventResponseSettingDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }


        /// <summary>
        /// 获取微信事件回复消息列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<WxEventResponseSettingDto>> GetWxEventRspMsgListAsync(string title, byte? eventType, byte? rspMsgType)
        {
            try
            {
                var q = from d in dalWxEventResponseSetting.GetAll()
                        where (title==null||d.Title==title)
                        &&(eventType==null||d.EventType==eventType)
                        &&(rspMsgType ==null|| d.RspMsgType== rspMsgType)
                        select new WxEventResponseSettingDto
                        {
                            Id=d.Id,
                            IsValid=d.IsValid,
                            Title=d.Title,
                            RspMsgXml=d.RspMsgXml,
                            EventType=d.EventType,
                            EventTypeName=d.EventType==(byte)WxEventType.AgainSubscribe?"首次关注":"再次关注",
                            CreateDate=d.CreateDate,
                            UpdateDate=d.UpdateDate,
                            RspMsgType=d.RspMsgType,
                            RspMsgTypeName=d.RspMsgType==(byte)WxRspMsgType.TextMessage?"文本消息":"图文消息"
                        };

                return await q.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        /// <summary>
        /// 添加事件消息回复
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        public async Task AddWxEventRspMsgAsync(AddWxEventResponseSettingDto addDto)
        {
            try
            {
                var count = await dalWxEventResponseSetting.GetAll().CountAsync(e => e.IsValid && e.EventType == addDto.EventType);
                if (count > 0)
                {
                    string eventTypeText = addDto.EventType == 1 ? "首次关注" : "再次关注";
                    throw new Exception("已存在有效的" + eventTypeText + "回复消息");
                }
                string rspMsgXml = "";
                if (addDto.RspMsgType == (byte)WxRspMsgType.TextMessage)
                {
                    if (addDto.TextMsg == null || string.IsNullOrWhiteSpace(addDto.TextMsg.Content))
                        throw new Exception("文本消息回复内容不能为空");

                    rspMsgXml = string.Format("<xml><content>{0}</content></xml>", addDto.TextMsg.Content);
                }
                else
                {
                    if (addDto.Articles.Count == 0)
                        throw new Exception("图文消息信息不能为空");
                   
                    rspMsgXml = XmlUtil.Serialize(addDto);
                }
               

                WxEventResponseSetting wxEventResponseSetting = new WxEventResponseSetting();
                wxEventResponseSetting.IsValid = true;
                wxEventResponseSetting.Title = addDto.Title;
                wxEventResponseSetting.RspMsgXml = rspMsgXml;
                wxEventResponseSetting.EventType = addDto.EventType;
                wxEventResponseSetting.CreateDate = DateTime.Now;
                wxEventResponseSetting.RspMsgType = addDto.RspMsgType;

                await dalWxEventResponseSetting.AddAsync(wxEventResponseSetting, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        /// <summary>
        /// 根据编号获取回复消息信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WxEventResponseSettingXmlDeserializeDto> GetByIdAsync(int id)
        {
            try
            {
                var rspMsgInfo = await dalWxEventResponseSetting.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (rspMsgInfo == null)
                    throw new Exception("编号错误");
                XElement root = XDocument.Parse(rspMsgInfo.RspMsgXml).Root;

                WxEventResponseSettingXmlDeserializeDto wxEventResponseSetting = new WxEventResponseSettingXmlDeserializeDto();
                wxEventResponseSetting.Id = rspMsgInfo.Id;
                wxEventResponseSetting.IsValid = rspMsgInfo.IsValid;
                wxEventResponseSetting.Title = rspMsgInfo.Title;
                wxEventResponseSetting.EventType = rspMsgInfo.EventType;
                wxEventResponseSetting.EventTypeName = rspMsgInfo.EventType==(byte)WxEventType.FirstSubscribe?"首次关注":"再次关注";
                wxEventResponseSetting.CreateDate = rspMsgInfo.CreateDate;
                wxEventResponseSetting.UpdateDate = rspMsgInfo.UpdateDate;
                wxEventResponseSetting.RspMsgType = rspMsgInfo.RspMsgType;
                wxEventResponseSetting.RspMsgTypeName = rspMsgInfo.RspMsgType==(byte)WxRspMsgType.TextMessage?"文本消息":"图文消息";

                if (rspMsgInfo.RspMsgType == (byte)WxRspMsgType.TextMessage)
                {
                    wxEventResponseSetting.TextMsg = new ResponseMessageTextDto { Content = root.Element("content").Value };
                }
                else
                {
                     wxEventResponseSetting.Articles = XmlUtil.Deserialize<WxEventResponseSettingXmlDeserializeDto>(root.ToString()).Articles;
                }

                return wxEventResponseSetting;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }



        /// <summary>
        /// 修改事件回复消息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateWxEventRspMsgAsync(UpdateWxEventResponseSettingDto updateDto)
        {
            try
            {
                var rspMsgInfo = await dalWxEventResponseSetting.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (rspMsgInfo == null)
                    throw new Exception("消息回复编号错误");

                string rspMsgXml = "";
                if (updateDto.RspMsgType == (byte)WxRspMsgType.TextMessage)
                {
                    if (updateDto.TextMsg == null || string.IsNullOrWhiteSpace(updateDto.TextMsg.Content))
                        throw new Exception("文本消息回复内容不能为空");

                    rspMsgInfo.RspMsgXml = string.Format("<xml><content>{0}</content></xml>", updateDto.TextMsg.Content);
                }
                else
                {
                    if (updateDto.Articles.Count == 0)
                        throw new Exception("图文消息信息不能为空");

                    rspMsgXml = XmlUtil.Serialize(updateDto);
                }

                rspMsgInfo.IsValid = updateDto.IsValid;
                rspMsgInfo.Title = updateDto.Title;
                rspMsgInfo.EventType = updateDto.EventType;
                rspMsgInfo.RspMsgType = updateDto.RspMsgType;
                rspMsgInfo.UpdateDate = DateTime.Now;
                rspMsgInfo.RspMsgXml = rspMsgXml;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }



    }
}
