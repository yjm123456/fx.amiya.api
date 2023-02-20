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
    /// 内容平台管理功能接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class ContentPlatFormController : ControllerBase
    {
        private IContentPlatformService _contentPalteFormService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="contentPalteFormService"></param>
        public ContentPlatFormController(IContentPlatformService contentPalteFormService)
        {
            _contentPalteFormService = contentPalteFormService;
        }


        /// <summary>
        /// 获取有效的内容平台列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("validList")]
        public async Task<ResultData<List<BaseKeyAndValueVo>>> GetValidListAsync(string name)
        {
            var contentPalteForms = from d in await _contentPalteFormService.GetListAsync(name, true)
                                    select new BaseKeyAndValueVo
                                    {
                                        Id = d.Id,
                                        Name = d.ContentPlatformName,
                                    };
            return ResultData<List<BaseKeyAndValueVo>>.Success().AddData("contentPalteForms", contentPalteForms.ToList());
        }
    }
}
