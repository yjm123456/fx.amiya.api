using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.LeaveMessage;
using Fx.Amiya.Dto.LeaveMessage;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 留言 api
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class LeaveMessageController : ControllerBase
    {
        private ILeaveMessageService leaveMessageService;
        private IHttpContextAccessor httpContextAccessor;
        public LeaveMessageController(ILeaveMessageService leaveMessageService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.leaveMessageService = leaveMessageService;
            this.httpContextAccessor = httpContextAccessor;
        }


            [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<LeaveMessageUserVo>>> GetListWithPageAsync(int pageNum, int pageSize)
        {
           var q= await leaveMessageService.GetListWithPageAsync(pageNum, pageSize);

            var leaveMessage = from d in q.List
                               select new LeaveMessageUserVo
                               {
                                   UserId=d.UserId,
                                   Avatar=d.Avatar,
                                   NickName=d.NickName,
                                   LeaveMessageDateList=(from t in d.LeaveMessageDateList
                                                         select new LeaveMessageDateVo
                                                         { 
                                                            Date=t.Date,
                                                            LeaveMessageList=(from m in t.LeaveMessageList
                                                                              select new LeaveMessageVo {
                                                                                UserId=m.UserId,
                                                                                Date=m.Date,
                                                                                Content=m.Content,
                                                                                MsgId=m.MsgId,
                                                                                MsgType=m.MsgType,
                                                                                EmployeeId=m.EmployeeId,
                                                                                EmployeeName=m.EmployeeName,
                                                                                Type=m.Type,
                                                                                TypeText=m.TypeText,
                                                                                IsReply=m.IsReply
                                                                              }).ToList()
                                                         }).ToList()
                               };
            FxPageInfo<LeaveMessageUserVo> leaveMessagePageInfo = new FxPageInfo<LeaveMessageUserVo>();
            leaveMessagePageInfo.TotalCount = q.TotalCount;
            leaveMessagePageInfo.List = leaveMessage;
            return ResultData<FxPageInfo<LeaveMessageUserVo>>.Success().AddData("leaveMessage", leaveMessagePageInfo);
        }
    }
}