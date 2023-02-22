using Fx.Amiya.BusinessWechat.Api.Vo.Login;
using Fx.Amiya.Common;
using Fx.Amiya.IService;
using Fx.Authentication.Jwt;
using Fx.Identity.Core;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Fx.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Authorization.Attributes;
using Fx.Amiya.BusinessWeChat.Api.Vo.CustomerInfo;
using Fx.Amiya.BusinessWeChat.Api.Vo.Base;

namespace Fx.Amiya.BusinessWechat.Api.Controllers
{
    /// <summary>
    /// 主播微信账号
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class LiveAnchorWechatInfoController : ControllerBase
    {
        private ILiveAnchorWeChatInfoService liveAnchorWechatInfoService;
        private IHttpContextAccessor httpContextAccessor;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="liveAnchorWechatInfoService"></param>
        public LiveAnchorWechatInfoController(IHttpContextAccessor httpContextAccessor, ILiveAnchorWeChatInfoService liveAnchorWechatInfoService)
        {
            this.liveAnchorWechatInfoService = liveAnchorWechatInfoService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        ///  获取有效的主播微信账号列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("valid")]
        public async Task<ResultData<List<BaseKeyAndValueVo>>> GetValidListAsync()
        {
            var liveAnchorWechatInfos = from d in await liveAnchorWechatInfoService.GetValidAsync()
                              select new BaseKeyAndValueVo
                              {
                                  Id = d.Id.ToString(),
                                  Name = d.WeChatNo,
                              };
            return ResultData<List<BaseKeyAndValueVo>>.Success().AddData("liveAnchorWechatInfos", liveAnchorWechatInfos.ToList());
        }


        /// <summary>
        ///  根据主播获取有效的主播微信账号列表
        /// </summary>
        /// <param name="liveanchorId">主播id</param>
        /// <returns></returns>
        [HttpGet("validListByLiveAnchorId")]
        public async Task<ResultData<List<BaseKeyAndValueVo>>> GetValidListByLiveAnchorIdAsync(int liveanchorId)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var liveAnchorWechatInfos = from d in await liveAnchorWechatInfoService.GetValidListByLiveAnchorIdAsync(liveanchorId, employeeId)
                                        select new BaseKeyAndValueVo
                                        {
                                            Id = d.Id,
                                            Name=d.WeChatNo
                                        };
            return ResultData<List<BaseKeyAndValueVo>>.Success().AddData("liveAnchorWechatInfos", liveAnchorWechatInfos.ToList());
        }
    }
}
