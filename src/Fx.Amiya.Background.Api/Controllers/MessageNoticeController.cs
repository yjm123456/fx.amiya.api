using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.MessageNotice;
using Fx.Amiya.Background.Api.Vo.MessageNotice.Input;
using Fx.Amiya.Background.Api.Vo.MessageNotice.Result;
using Fx.Amiya.Dto.MessageNotice;
using Fx.Amiya.Dto.MessageNotice.Input;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 消息通知板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class MessageNoticeController : ControllerBase
    {
        private IMessageNoticeService messageNoticeService;
        private IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="messageNoticeService"></param>
        public MessageNoticeController(IMessageNoticeService messageNoticeService, IHttpContextAccessor httpContextAccessor)
        {
            this.messageNoticeService = messageNoticeService;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取我的未读消息条数
        /// </summary>
        /// <returns></returns>
        [HttpGet("getMyUnReadCount")]
        public async Task<ResultData<int>> GetMyUnReadDataCountAsync()
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var q = await messageNoticeService.GetMyUnReadAsync(employeeId);
                return ResultData<int>.Success().AddData("myUnReadNoticeMessage", q);
            }
            catch (Exception ex)
            {
                return ResultData<int>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 根据时间，用户获取消息通知列表（非分页）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<MessageNoticeVo>> GetListWithPageAsync([FromQuery] QueryMessageNoticeListVo query)
        {
            try
            {
                QueryMessageNoticeDto queryCustomerAppointSchedulePageListDto = new QueryMessageNoticeDto();
                queryCustomerAppointSchedulePageListDto.NoticeType = query.NoticeType;
                queryCustomerAppointSchedulePageListDto.AcceptBy = query.AcceptBy;
                queryCustomerAppointSchedulePageListDto.StartDate = query.StartDate;
                queryCustomerAppointSchedulePageListDto.EndDate = query.EndDate;
                var q = await messageNoticeService.GetListAsync(queryCustomerAppointSchedulePageListDto);

                var messageNotice = from d in q
                                    select new MessageNoticeDetails
                                    {
                                        Id = d.Id,
                                        AcceptBy = d.AcceptBy,
                                        CreateDate = d.CreateDate,
                                        CreateDateNotInHour = Convert.ToDateTime(d.CreateDate.ToString("yyyy-MM-dd")),
                                        UpdateDate = d.UpdateDate,
                                        DeleteDate = d.DeleteDate,
                                        Valid = d.Valid,
                                        OrderId = d.OrderId,
                                        IsRead = d.IsRead,
                                        NoticeType = d.NoticeType,
                                        NoticeTypeText = d.NoticeTypeText,
                                        NoticeContent = d.NoticeContent,
                                        AcceptByEmpName = d.AcceptByEmpName,
                                    };

                List<MessageNoticeDetails> messageNoticePageInfo = new List<MessageNoticeDetails>();
                messageNoticePageInfo = messageNotice.ToList();
                MessageNoticeVo returnResult = new MessageNoticeVo();
                returnResult.ReadCount = messageNoticePageInfo.Where(x => x.IsRead == true).Count();
                returnResult.UnReadCount = messageNoticePageInfo.Where(x => x.IsRead == false).Count();
                var messageDate = messageNoticePageInfo.GroupBy(x => x.CreateDateNotInHour).Select(x => x.Key);

                List<MessageReturnVo> messageNoticeVos = new List<MessageReturnVo>();
                foreach (var x in messageDate)
                {
                    MessageReturnVo messageNoticeVo = new MessageReturnVo();
                    messageNoticeVo.CreateDate = x;
                    messageNoticeVo.Details = messageNoticePageInfo.Where(z => z.CreateDateNotInHour == x).ToList();
                    messageNoticeVos.Add(messageNoticeVo);
                }
                returnResult.MessageReturnVos = messageNoticeVos;
                return ResultData<MessageNoticeVo>.Success().AddData("messageNoticeInfo", returnResult);
            }
            catch (Exception ex)
            {
                return ResultData<MessageNoticeVo>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 修改消息通知信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateToReadAsync(UpdateMessageNoticeToReadVo updateVo)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                UpdateMessageNoticeToReadDto updateDto = new UpdateMessageNoticeToReadDto();
                updateDto.Id = updateVo.Id;
                updateDto.EmployeeId = employeeId;
                await messageNoticeService.UpdateToReadAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        #region 枚举下拉框

        /// <summary>
        /// 获取通知类型
        /// </summary>
        /// <returns></returns>
        [HttpGet("getMessageNoticeTypeList")]
        [FxInternalAuthorize]
        public ResultData<List<BaseIdAndNameVo>> GetMessageNoticeTypeList()
        {
            var orderTypes = from d in messageNoticeService.GetMessageNoticeTypeList()
                             select new BaseIdAndNameVo
                             {
                                 Id = d.Id,
                                 Name = d.Name
                             };
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("appointmentTypeList", orderTypes.ToList());
        }
        #endregion
    }
}
