using Fx.Amiya.BusinessWeChat.Api.Vo;
using Fx.Amiya.BusinessWeChat.Api.Vo.FansMeetingDetails;
using Fx.Amiya.Dto.FansMeetingDetails.Input;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Controllers
{
    /// <summary>
    /// 粉丝见面会
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class FansMeetingDetailsController : ControllerBase
    {
        private readonly IFansMeetingDetailsService fansMeetingDetailsService;
        private readonly IFansMeetingService fansMeetingService;
        public FansMeetingDetailsController(IFansMeetingDetailsService fansMeetingDetailsService, IFansMeetingService fansMeetingService)
        {
            this.fansMeetingDetailsService = fansMeetingDetailsService;
            this.fansMeetingService = fansMeetingService;
        }

        /// <summary>
        /// 是否参加粉丝见面会
        /// </summary>
        /// <returns></returns>
        [HttpGet("isAttend")]
        public async Task<ResultData<bool>> isAttendMeeting([FromQuery] AttendMeetingQueryVo query)
        {
            AttendMeetingQueryDto queryDto = new AttendMeetingQueryDto();
            queryDto.Id = query.Id;
            queryDto.Phone = query.Phone;
            queryDto.HospitalId = query.HospitalId;
            var res = await fansMeetingDetailsService.IsAttendMeeting(queryDto);
            return ResultData<bool>.Success().AddData("isAttend", res);
        }
        /// <summary>
        /// 获取有效的粉丝见面会信息（下拉框使用）
        /// </summary>
        /// <returns></returns>
        [HttpGet("ValidKeyAndValue")]
      
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetValidByKeyAndValueAsync()
        {
            try
            {
                var q = await fansMeetingService.GetValidListAsync();
                var fansMeeting = from d in q
                                  select new BaseIdAndNameVo
                                  {
                                      Id = d.Key,
                                      Name = d.Value,
                                  };

                return ResultData<List<BaseIdAndNameVo>>.Success().AddData("fansMeeting", fansMeeting.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<BaseIdAndNameVo>>.Fail(ex.Message);
            }
        }
    }
}
