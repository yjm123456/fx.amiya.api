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
    /// 主播账号
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class LiveAnchorController : ControllerBase
    {
        private ILiveAnchorService liveAnchorService;
        private IHttpContextAccessor httpContextAccessor;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="liveAnchorService"></param>
        public LiveAnchorController(IHttpContextAccessor httpContextAccessor, ILiveAnchorService liveAnchorService)
        {
            this.liveAnchorService = liveAnchorService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        ///  获取有效的主播账号列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("valid")]
        public async Task<ResultData<List<BaseKeyAndValueVo>>> GetValidListAsync()
        {
            var liveAnchors = from d in await liveAnchorService.GetValidAsync()
                              select new BaseKeyAndValueVo
                              {
                                  Id = d.Id.ToString(),
                                  Name = (string.IsNullOrEmpty(d.ContentPlateFormName)) ? d.Name.ToString() : d.Name.ToString() + "(" + d.ContentPlateFormName + ")",
                              };
            return ResultData<List<BaseKeyAndValueVo>>.Success().AddData("liveAnchors", liveAnchors.ToList());
        }
    }
}
